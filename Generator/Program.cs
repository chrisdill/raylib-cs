using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Generator
{
    public struct TypeMember
    {
        public string Name;
        public Type Type;
        public int Offset;
        public TypeMember(string name, Type type, int offset)
        {
            Name = name;
            Type = type;
            Offset = offset;
        }
    }

    public struct UserDefinedEnumData
    {
        public string Name;
        public List<KeyValuePair<string, int>> Enums;
        public UserDefinedEnumData(string name)
        {
            Name = name;
            Enums = new List<KeyValuePair<string, int>>();
        }
    }

    public struct UserDefinedTypeData
    {
        public string Name;
        public List<TypeMember> Members;

        public UserDefinedTypeData(string name)
        {
            Name = name;
            Members = new List<TypeMember>();
        }
    }


    public struct Function
    {
        public string Name;
        public Type ReturnType;
        public List<FunctionParam> Params;

        public Function(string name, string returnType, params FunctionParam[] parameters)
        {
            var Isreturnpointer = name[0] == '*';
            Name = Isreturnpointer ? name.Replace("*","") : name;
            ReturnType = new Type(returnType, Isreturnpointer);
            Params = new List<FunctionParam>(parameters);

        }


        public override string ToString()
        {
            var str = $"{ReturnType} {Name}(";
            for (int i = 0; i < Params.Count; i++)
            {
                if (i != 0) str += ",";
                str += $"{Params[i].ToString()}";
            }
            str += ")";
            return str;
        }
    }

    public struct Type
    {
        public string Name;
        public bool IsPointer;

        public Type(string name, bool isPointer)
        {
            Name = name;
            IsPointer = isPointer;
        }


        public override string ToString()
        {
            return Name + (IsPointer == true ? "*" : "");
        }
    }

    public struct FunctionParam
    {
        public string Name;
        public Type Type;

        public FunctionParam(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public FunctionParam(string FullParam)
        {
            FullParam = FullParam.Trim();
            if (FullParam.Split(' ').Length == 2)
            {
                var Isreturnpointer = FullParam.Split(' ')[1][0] == '*';
                Name = Isreturnpointer ? FullParam.Replace("*", "").Split(' ')[1] : FullParam.Split(' ')[1];
                Type = new Type(FullParam.Replace("*", "").Split(' ')[0], Isreturnpointer);
            }
            else
            {
                var Isreturnpointer = FullParam.Split(' ')[2][0] == '*';
                Name = Isreturnpointer ? FullParam.Replace("*","").Split(' ')[2] : FullParam.Split(' ')[2];
                Type = new Type(FullParam.Replace("*", "").Split(' ')[0] + " " + FullParam.Replace("*", "").Split(' ')[1], Isreturnpointer);
            }
        }

        public override string ToString()
        {
            return Name == "..." ? "..." : $"{Type.ToString()} {Name}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var process = Process.Start(new ProcessStartInfo("Dia2Dump.exe", " -t raylib.pdb") { RedirectStandardOutput = true, UseShellExecute = false });
            string typedata = "";
            var ischkout = process.StandardOutput;
            while (process.HasExited == false)
            {
                typedata += ischkout.ReadToEnd();
            }
            File.WriteAllText("types.txt", typedata);
            var typesfile = File.ReadAllLines("types.txt");
            var TypeMap = new Dictionary<string, string>();
            typesfile = typesfile.Where(x => x != "").ToArray();

            var sources = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>( "raylib.h","RLAPI") , new KeyValuePair<string, string>("physac.h", "PHYSACDEF"),
                new KeyValuePair<string, string>( "easings.h","EASEDEF"),new KeyValuePair<string, string>( "raygui.h","RAYGUIDEF")};
            foreach (var sourcefilenameandexporttag in sources)
            {
                var functions = new List<string>();
                var types = new HashSet<string>();
                var enums = new HashSet<string>();
                var Funcs = new List<Function>();
                var tps = new Dictionary<string, UserDefinedTypeData>();
                var eps = new Dictionary<string, UserDefinedEnumData>();
                var sourcefilename = sourcefilenameandexporttag.Key;
                var FileName = new CultureInfo("en-us", false).TextInfo.ToTitleCase(sourcefilename.Replace(".h", ""));
                var ExportTag = sourcefilenameandexporttag.Value;
                var sourcefile = File.ReadAllLines(sourcefilename);

                for (int i = 0; i < sourcefile.Length; i++)
                {
                    var source = sourcefile[i].Split("//".ToCharArray())[0].Trim();
                    if (source.Contains(ExportTag))
                    {
                        if (!source.Contains("#define"))
                        {
                            source = source.TrimStart(ExportTag.ToCharArray()).Trim();
                            if (!source.Contains("{")) functions.Add(source);
                        }
                    }

                    if (source.Contains("typedef"))
                    {
                        if (source.Split(' ')[1].Trim() == "struct")
                        {
                            if (source.Contains('}'))
                            {
                                types.Add(source.Split('}', ';')[1].Trim());
                            }
                            else
                            {
                                int t = 1;
                                var src = sourcefile[i + t];
                                while (!src.Contains('}'))
                                {
                                    src = sourcefile[i + t];
                                    t++;
                                }
                                types.Add(src.Trim('}', ';').Trim());
                            }

                        }
                    }
                }

                for (int i = 0; i < functions.Count; i++)
                {
                    var func = functions[i];
                    var returntype = func.Split('(')[0].Split(' ').Length == 3 ? func.Split('(')[0].Split(' ')[0] + " " + func.Split('(')[0].Split(' ')[1] : func.Split('(')[0].Split(' ')[0];
                    types.Add(returntype);
                    func = func.Substring(returntype.Length).Trim();
                    var funcname = func.Split('(')[0].Trim();
                    var Func = new Function(funcname, returntype);
                    if (func.Contains(','))
                    {
                        var Params = func.Split('(', ')')[1].Split(',');
                        for (int t = 0; t < Params.Length; t++)
                        {
                            var Param = Params[t];
                            Param = Param.Trim();
                            if (Param == "...")
                            {
                                Func.Params.Add(new FunctionParam(Param, new Type("...", false)));
                            }
                            else
                            {

                                var TypeAndVar = Param.Trim().Split(' ');
                                if (TypeAndVar.Length == 2)
                                {
                                    var type = TypeAndVar[0];
                                    var Var = TypeAndVar[1];
                                    types.Add(type);
                                }
                                else if (TypeAndVar.Length == 3)
                                {
                                    var type = TypeAndVar[0] + " " + TypeAndVar[1];
                                    var Var = TypeAndVar[2];
                                    types.Add(type);
                                }

                                Func.Params.Add(new FunctionParam(Param));

                            }
                        }
                    }
                    else if (func.Contains(' '))
                    {
                        var Param = func.Split('(', ')')[1];
                        var TypeAndVar = Param.Trim().Split(' ');
                        var type = TypeAndVar[0];
                        var Var = TypeAndVar[1];
                        types.Add(type);
                        Func.Params.Add(new FunctionParam(Param));
                    }
                    Funcs.Add(Func);
                }

                for (int i = 0; i < sourcefile.Length; i++)
                {
                    var source = sourcefile[i].Split("//".ToCharArray())[0].Trim();
                    if (source.Contains("typedef"))
                    {
                        if (source.Split(' ')[1].Trim() != "struct")
                        {
                            if (source.Split(' ')[1].Trim() == "enum")
                            {
                                if (source.Contains('}'))
                                {
                                    enums.Add(source.Split('}', ';')[1].Trim());
                                }
                                else
                                {
                                    int t = 1;
                                    var src = sourcefile[i + t];
                                    while (!src.Contains('}'))
                                    {
                                        src = sourcefile[i + t];
                                        t++;
                                    }
                                    enums.Add(src.Trim('}', ';').Trim());
                                }
                            }
                            else
                            {
                                TypeMap.Add(source.Split(" ".ToCharArray(), 3)[2].Trim(';').Trim(), source.Split(" ".ToCharArray(), 3)[1].Trim());
                            }
                        }
                        else
                        {

                        }
                    }
                    else if (source.Contains("#define") && source.Split(' ').Length > 2 && source.Split(' ')[1] != (ExportTag))
                    {
                        if (types.Contains(source.Split(" ".ToCharArray(), 3)[1].Trim(';').Trim())) TypeMap.Add(source.Split(" ".ToCharArray(), 3)[1].Trim(';').Trim(), source.Split(" ".ToCharArray(), 3)[2].Trim());
                    }
                }


                for (int i = 0; i < Funcs.Count; i++)
                {
                    var Func = Funcs[i];
                    if (TypeMap.ContainsKey(Func.ReturnType.Name))
                    {
                        Func.ReturnType.Name = TypeMap[Func.ReturnType.Name];
                    }
                    for (int t = 0; t < Func.Params.Count; t++)
                    {
                        if (TypeMap.ContainsKey(Func.Params[t].Type.Name))
                        {

                            Func.Params[t] = new FunctionParam(Func.Params[t].Name, new Type(TypeMap[Func.Params[t].Type.Name], Func.Params[t].Type.IsPointer));
                        }
                    }
                    Funcs[i] = Func;
                }
                for (int i = 0; i < typesfile.Length; i++)
                {
                    var typestr = typesfile[i];
                    if (typestr.Contains("UserDefinedType: ") && !typestr.Contains("UserDefinedType:  "))
                    {
                        var type = typestr.Substring("UserDefinedType: ".Length).Trim();
                        if (types.Contains(type) && type[0] != ' ' && !tps.Any(x => x.Key == type))
                        {
                            var usertype = new UserDefinedTypeData(type);
                            int t = 1;
                            typestr = typesfile[i + t];
                            while (!(typestr.Contains("UserDefinedType: ") && typestr["UserDefinedType: ".Length - 1] == ' '))
                            {
                                if (typestr.Contains("Member"))
                                {
                                    var tpsrc = typesfile[i + t];
                                    var MemberNameandType = tpsrc.Substring(tpsrc.IndexOf("Type:") + "Type:".Length).Trim().Split(',');
                                    var MemberName = MemberNameandType[1].Trim();
                                    var MemberType = MemberNameandType[0].Trim();
                                    if (MemberType.Contains("<unnamed-enum-false>"))
                                    {
                                        MemberType = "bool";
                                    }
                                    var isptr = MemberType[MemberType.Length - 1] == '*';
                                    var offset = int.Parse(tpsrc.Split(',')[0].Split(':')[1].Trim().Substring("this+0x".Length), System.Globalization.NumberStyles.HexNumber);
                                    if (isptr)
                                    {
                                        MemberType = MemberType.Remove(MemberType.Length - 1);
                                    }
                                    usertype.Members.Add(new TypeMember(MemberName, new Type(MemberType, isptr), offset));
                                    if (typesfile[i + t + 1].Contains(MemberType.Trim("struct".ToCharArray())) &&
                                        typesfile[i + t + 1].Contains("UserDefinedType:  "))
                                    {
                                        t++;
                                    }
                                }
                                t++;
                                typestr = typesfile[i + t];
                            }
                            tps.Add(usertype.Name, usertype);
                        }
                    }
                    if (typestr.Contains("Enum           : "))
                    {
                        var Enum = typestr.Substring("Enum           : ".Length).Split(',')[0].Trim();
                        if (enums.Contains(Enum) && Enum != "bool")
                        {
                            var UserDefineEnum = new UserDefinedEnumData(Enum);
                            int t = 1;
                            typestr = typesfile[i + t];
                            while (typestr.Contains("Constant"))
                            {
                                var intstr = typestr.Split(",".ToCharArray(), 2)[0].Split(':')[1].Split(' ')[4].Substring("0x".Length).Trim();
                                int Int = int.Parse(intstr, System.Globalization.NumberStyles.HexNumber);
                                var name = typestr.Split(",".ToCharArray(), 4)[3].Trim();
                                UserDefineEnum.Enums.Add(new KeyValuePair<string, int>(name, Int));
                                t++;
                                typestr = typesfile[i + t];
                            }
                            eps.Add(Enum, UserDefineEnum);
                        }
                    }
                }
                types.IntersectWith(tps.Select(x => x.Key));


                var codetree = CompilationUnit().AddUsings(UsingDirective(ParseName("System")))
                    .AddUsings(UsingDirective(ParseName("System.IO")))
                    .AddUsings(UsingDirective(ParseName("System.Collections.Generic")))
                    .AddUsings(UsingDirective(ParseName("System.Security")))
                    .AddUsings(UsingDirective(ParseName("System.Runtime.InteropServices")))
                    ;
                var Raylibnamespace = NamespaceDeclaration(ParseName("Raylib")).NormalizeWhitespace();

                foreach (var Enumtype in eps.Values)
                {
                    var Enum = EnumDeclaration(Enumtype.Name)
            .WithModifiers(
                TokenList(
                    Token(SyntaxKind.PublicKeyword)));
                    foreach (var Member in Enumtype.Enums)
                    {

                        var enummember = EnumMemberDeclaration(
                                Identifier(Member.Key))
                            .WithEqualsValue(
                                EqualsValueClause(
                                    LiteralExpression(
                                        SyntaxKind.NumericLiteralExpression,
                                        Literal(Member.Value))));
                        Enum = Enum.AddMembers(enummember);
                    }
                    Raylibnamespace = Raylibnamespace.AddMembers(Enum);
                }
                foreach (var Type in tps.Values)
                {
                    var Struct = StructDeclaration(Type.Name).WithAttributeLists(
                SingletonList(
                    AttributeList(
                        SingletonSeparatedList(
                            Attribute(
                                IdentifierName("StructLayout"))
                            .WithArgumentList(
                                AttributeArgumentList(
                                    SeparatedList<AttributeArgumentSyntax>(
                                        new SyntaxNodeOrToken[]{
                                        AttributeArgument(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                IdentifierName("LayoutKind"),
                                                IdentifierName("Sequential"))),
                                        Token(SyntaxKind.CommaToken),
                                        AttributeArgument(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                IdentifierName("CharSet"),
                                                IdentifierName("Ansi")))
                                        .WithNameEquals(
                                            NameEquals(
                                                IdentifierName("CharSet")))})))))))
            .WithModifiers(
                TokenList(
                    Token(SyntaxKind.PublicKeyword)));
                    bool IsUnsafe = false;
                    var FixedStructTypes = new List<string>();
                    foreach (var Member in Type.Members)
                    {
                        var IsStruct = false;
                        var TypeName = (Member.Type.IsPointer ? "IntPtr" : Member.Type.Name).Trim();
                        if (TypeName.Contains("struct"))
                        {
                            IsStruct = true;
                            TypeName = TypeName.Substring(TypeName.LastIndexOf("struct") + "struct".Length);
                        }

                        if (TypeName.Contains("enum"))
                        {
                            TypeName = TypeName.Substring(TypeName.LastIndexOf("enum") + "enum".Length);
                        }

                        if (TypeName.Contains("unsigned int"))
                        {
                            TypeName = TypeName.Replace("unsigned int", "uint");
                        }

                        if (TypeName.Contains("unsigned char"))
                        {
                            TypeName = TypeName.Replace("unsigned char", "byte");
                        }


                        var IsFixed = false;
                        var VariableDec = VariableDeclarator(Member.Name);
                        if (TypeName.Contains("["))
                        {
                            int arraycount = int.Parse(TypeName.Split('[', ']')[1].Substring("0x".Length), System.Globalization.NumberStyles.HexNumber);
                            TypeName = TypeName.Split('[', ']')[0].Trim();
                            if (IsStruct)
                            {
                                if (!FixedStructTypes.Contains($"_{TypeName}_e_FixedBuffer_{arraycount}"))
                                {
                                    FixedStructTypes.Add($"_{TypeName}_e_FixedBuffer_{arraycount}");
                                    var FixedBufferStruct = StructDeclaration($"_{TypeName}_e_FixedBuffer_{arraycount}")
                .WithModifiers(
                    TokenList(
                        new[]{
                    Token(SyntaxKind.PublicKeyword),
                    Token(SyntaxKind.UnsafeKeyword)}));

                                    for (int i = 0; i < arraycount; i++)
                                    {
                                        FixedBufferStruct = FixedBufferStruct.AddMembers(
                            FieldDeclaration(
                                VariableDeclaration(
                                    IdentifierName(TypeName))
                                .WithVariables(
                                    SingletonSeparatedList<VariableDeclaratorSyntax>(
                                        VariableDeclarator(
                                            Identifier($"{Member.Name}{i}")))))
                            .WithModifiers(
                                TokenList(
                                    Token(SyntaxKind.PublicKeyword))));
                                    }


                                    FixedBufferStruct = FixedBufferStruct.AddMembers(IndexerDeclaration(
                            RefType(
                                IdentifierName(TypeName)))
                        .WithModifiers(
                            TokenList(
                                Token(SyntaxKind.PublicKeyword)))
                        .WithParameterList(
                            BracketedParameterList(
                                SingletonSeparatedList<ParameterSyntax>(
                                    Parameter(
                                        Identifier("index"))
                                    .WithType(
                                        PredefinedType(
                                            Token(SyntaxKind.IntKeyword))))))
                        .WithAccessorList(
                            AccessorList(
                                SingletonList<AccessorDeclarationSyntax>(
                                    AccessorDeclaration(
                                        SyntaxKind.GetAccessorDeclaration)
                                    .WithBody(
                                        Block(
                                            SingletonList<StatementSyntax>(
                                                FixedStatement(
                                                    VariableDeclaration(
                                                        PointerType(
                                                            IdentifierName(TypeName)))
                                                    .WithVariables(
                                                        SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                            VariableDeclarator(
                                                                Identifier("e"))
                                                            .WithInitializer(
                                                                EqualsValueClause(
                                                                    PrefixUnaryExpression(
                                                                        SyntaxKind.AddressOfExpression,
                                                                        IdentifierName($"{Member.Name}0")))))),
                                                    ReturnStatement(
                                                        RefExpression(
                                                            ElementAccessExpression(
                                                                IdentifierName("e"))
                                                            .WithArgumentList(
                                                                BracketedArgumentList(
                                                                    SingletonSeparatedList<ArgumentSyntax>(
                                                                        Argument(
                                                                            IdentifierName("index")))))))))))))));
                                    Raylibnamespace = Raylibnamespace.AddMembers(FixedBufferStruct);
                                }
                                TypeName = $"_{TypeName}_e_FixedBuffer_{arraycount}";
                            }
                            else
                            {
                                VariableDec = VariableDec.WithArgumentList(
                                        BracketedArgumentList(
                                            SingletonSeparatedList<ArgumentSyntax>(
                                                Argument(
                                                    LiteralExpression(
                                                        SyntaxKind.NumericLiteralExpression,
                                                        Literal(arraycount))))));
                                IsFixed = true;
                                IsUnsafe = true;
                            }
                        }
                        var variable = VariableDeclaration(ParseTypeName(TypeName)).AddVariables(VariableDec);
                        var field = FieldDeclaration(variable).AddModifiers(Token(SyntaxKind.PublicKeyword));
                        if (IsFixed) field = field.AddModifiers(Token(SyntaxKind.FixedKeyword));
                        Struct = Struct.AddMembers(field);
                    }
                    if (IsUnsafe) Struct = Struct.AddModifiers(Token(SyntaxKind.UnsafeKeyword));
                    Raylibnamespace = Raylibnamespace.AddMembers(Struct);
                }

                {
                    var RaylibClass = ClassDeclaration(FileName)
            .WithAttributeLists(
                SingletonList<AttributeListSyntax>(
                    AttributeList(
                        SingletonSeparatedList<AttributeSyntax>(
                            Attribute(
                                IdentifierName("SuppressUnmanagedCodeSecurity"))))))
            .WithModifiers(
                TokenList(
                    new[]{
                    Token(SyntaxKind.PublicKeyword),
                    Token(SyntaxKind.StaticKeyword),
                    Token(SyntaxKind.PartialKeyword)}));

                    var LibraryNameField = FieldDeclaration(
                        VariableDeclaration(
                            PredefinedType(
                                Token(SyntaxKind.StringKeyword)))
                        .WithVariables(
                            SingletonSeparatedList<VariableDeclaratorSyntax>(
                                VariableDeclarator(
                                    Identifier("nativeLibName"))
                                .WithInitializer(
                                    EqualsValueClause(
                                        LiteralExpression(
                                            SyntaxKind.StringLiteralExpression,
                                            Literal("raylib")))))))
                    .WithModifiers(
                        TokenList(
                            new[]{
                            Token(SyntaxKind.PublicKeyword),
                            Token(SyntaxKind.ConstKeyword)}));
                    RaylibClass = RaylibClass.AddMembers(LibraryNameField);
                    foreach (var Func in Funcs)
                    {
                        var typename = Func.ReturnType.IsPointer ? "IntPtr" : Func.ReturnType.Name;
                        var Function = MethodDeclaration(ParseTypeName(typename),
                        Identifier(Func.Name))
                    .WithAttributeLists(
                        SingletonList(
                            AttributeList(
                                SingletonSeparatedList(
                                    Attribute(
                                        IdentifierName("DllImport"))
                                    .WithArgumentList(
                                        AttributeArgumentList(
                                            SeparatedList<AttributeArgumentSyntax>(
                                                new SyntaxNodeOrToken[]{
                                                AttributeArgument(
                                                    IdentifierName("nativeLibName")),
                                                Token(SyntaxKind.CommaToken),
                                                AttributeArgument(
                                                    MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        IdentifierName("CallingConvention"),
                                                        IdentifierName("Cdecl")))
                                                .WithNameEquals(
                                                    NameEquals(
                                                        IdentifierName("CallingConvention")))})))))))
                    .WithModifiers(
                        TokenList(
                            new[]{
                            Token(SyntaxKind.PublicKeyword),
                            Token(SyntaxKind.StaticKeyword),
                            Token(SyntaxKind.ExternKeyword)
                            })).WithSemicolonToken(Token(SyntaxKind.SemicolonToken));

                        for (int i=0; i < Func.Params.Count;i++)
                        {
                            var Param = Func.Params[i];
                            var TypeName = (Param.Type.IsPointer ? "IntPtr" : Param.Type.Name).Trim();
                            if (TypeName.Contains("unsigned int"))
                            {
                                TypeName = TypeName.Replace("unsigned int", "uint");
                            }

                            if (TypeName.Contains("..."))
                            {
                                TypeName = "params object[]";
                                Param.Name = "args";
                            }

                            if (TypeName.Contains("unsigned char"))
                            {
                                TypeName = TypeName.Replace("unsigned char", "byte");
                            }

                            if (TypeName.Contains("struct"))
                            {
                                TypeName = TypeName.Substring(TypeName.LastIndexOf("struct") + "struct".Length);
                            }
                            Function = Function.AddParameterListParameters(
                            Parameter(
                                Identifier(Param.Name))
                            .WithType(
                                IdentifierName(TypeName)));
                        }

                        RaylibClass = RaylibClass.AddMembers(Function);
                    }
                    Raylibnamespace = Raylibnamespace.AddMembers(RaylibClass);
                }
                codetree = codetree.AddMembers(Raylibnamespace);
                Console.WriteLine(codetree.NormalizeWhitespace().ToFullString());
                File.WriteAllText($"{FileName}.cs", codetree.NormalizeWhitespace().ToFullString());

            }
            Console.ReadLine();
        }

    }
}

