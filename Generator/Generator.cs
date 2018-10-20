using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Generator
{
    static class Generator
    {
        public static string RaylibDirectory = "C:\\raylib\\raylib\\";
        public static string RaylibDirectory2 = "C:\\Users\\Chris\\Documents\\projects\\raylib\\";

        // string extensions
        private static string CapitalizeFirstCharacter(string format)
        {
            if (string.IsNullOrEmpty(format))
                return string.Empty;
            else
                return char.ToUpper(format[0]) + format.ToLower().Substring(1);
        }

        public static string Indent(this string value, int size)
        {
            var strArray = value.Split('\n');
            var sb = new StringBuilder();
            foreach (var s in strArray)
                sb.Append(new string(' ', size)).Append(s);
            return sb.ToString();
        }

        // testing regex
        public static string ReplaceEx(this string input, string pattern, string replacement)
        {
            var matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                //Console.WriteLine(match.Value);
            }
            return Regex.Replace(input, pattern, replacement);
        }

        // Create binding code
        public static void Process(string filePath, string api)
        {
            var lines = File.ReadAllLines(RaylibDirectory + "src//" + filePath);
            var output = "";

            output += "using Raylib;\n";
            output += "using static Raylib.Raylib;\n\n";
            output += "public partial class Examples\n{\n";

            // convert functions to c#
            foreach (string line in lines)
            {
                if (line.StartsWith(api))
                {
                    output += "\t\t[DllImport(nativeLibName)]\n";
                    string newLine = line.Clone().ToString();
                    newLine = newLine.Replace(api, "public static extern");

                    // add converted function
                    output += "\t\t" + newLine + "\n\n";
                }
            }
            output += "\t\t#endregion\n";

            //output += text;
            output += "\n}";

            output = output.Replace("(void)", "()");
            output = output.Replace("const char *", "string ");
            output = output.Replace("const char * ", "string");
            output = output.Replace("const char*", "string");
            output = output.Replace("unsigned int", "uint");
            output = output.Replace("unsigned char", "byte");
            output = output.Replace("const void *", "byte[] ");
            output = output.Replace("const float *", "float[] ");
            output = output.Replace("const int *", "int[] ");
            output = output.Replace("...", "params object[] args");
            output = output.Replace("Music ", "IntPtr ");

            Console.WriteLine(output);
   
            filePath = Path.GetFileNameWithoutExtension(filePath);
            filePath = CapitalizeFirstCharacter(filePath);

            Directory.CreateDirectory("Raylib-cs");
            File.WriteAllText("Raylib-cs/ " + filePath + ".cs", output);
        }

        // Convert c style to c#
        // Design is close to raylib so only a few changes needed
        public static void ProcessExample(string file, string folder, string path)
        {
            // load and setup
            var fileName = Path.GetFileNameWithoutExtension(file);
            var text = File.ReadAllText(file);
            var result = "";
            var output = "";
            output += "using Raylib;\n";
            output += "using static Raylib.Raylib;\n\n";
            output += "public partial class " + folder + "\n{\n";
            // text = text.Replace("\r", "\r\n");

            // rough file conversion
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // ignore certain preprocess symbols
                if (line.Contains("#include"))
                    continue;
                else if (line.Contains("#if"))
                    continue;
                else if (line.Contains("#else"))
                    continue;
                else if (line.Contains("#endif"))
                    continue;

                else if (line.Contains("#define"))
                {
                    var str = line.Replace("#define", "");
                    var arr = str.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length < 2)
                        continue;

                    bool isNumeric = int.TryParse(arr[1], out var n);
                    if (isNumeric)
                        result += "public const int " + arr[0] + " = " + arr[1] + ";\r\n";
                    else
                        result += "public const string " + arr[0] + " = " + arr[1] + ";\r\n";
                }

                // change main signature
                else if (line.StartsWith("int main"))
                    result += "public static void Main()\r\n";

                // remove typedef and mark members as public
                else if (line.StartsWith("typedef struct"))
                {
                    var members = "";
                    while (!line.StartsWith("}"))
                    {
                        i++;
                        line = lines[i];
                        members += "public " + line + "\n";
                    }

                    line = line.Replace(" ", "");
                    line = line.Replace("}", "");
                    line = line.Replace(";", "");
                    result += "struct " + line + "{\n\n";
                    result += members;
                }

                // copy line by default
                else
                    result += line + "\n";
            }

            // regex

            // (Type){...} -> new Type(...)
            // e.g (Vector2){ 100, 100 } -> new Vector2( 100, 100 );
            result = result.ReplaceEx(@"\((\w+)\){(.*)}", @"new $1($2);");
            result = result.ReplaceEx(@"\((\w+)\) \w+ = {(.*)}", @"new $1($2);");

            // Type name[size] -> Type[] name = new Type[size];
            // e.g Rectangle buildings[MAX_BUILDINGS]; -> Rectangle[] buildings = new Rectangle[MAX_BUILDINGS];
            result = result.ReplaceEx(@"(\w+) (\w+)\[(.*)\];", "$1[] $2 = new $1[$3];");

            result = result.Replace("Music ", "IntPtr ");
            result = result.Replace("(void)", "()");

            // defines to enums(might use defines as variables aswell not sure)
            result = result.ReplaceEx(@"KEY_(\w+)", @"(int)Key.$1");
            result = result.ReplaceEx(@"MOUSE_(\w+)", @"(int)Mouse.$1");
            result = result.ReplaceEx(@"FLAG_(\w+)", @"(int)Flag.$1");
            // result = result.ReplaceEx(@"FLAG_(\w+)", @"(int)Flag.$1");

            // add result
            result = result.Indent(4);
            output += result;
            output += "\n}\n";

            // saves relative to executable location
            var loc = path + "//" + fileName + ".cs";
            File.WriteAllText(loc, output);
            Console.WriteLine("Generated " + fileName + ".cs");
        }
    }
}
