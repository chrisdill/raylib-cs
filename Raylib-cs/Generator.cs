using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;

namespace Raylibcs
{
    /// <summary>
    /// Generates the bindings for raylib
    /// ConsoleDriver.Run(new SampleLibrary());
    /// </summary>
    public class SampleLibrary : ILibrary
    {
        void ILibrary.Setup(Driver driver)
        {
            var options = driver.Options;
            var module = options.AddModule("raylib");
            module.IncludeDirs.Add("C:\\raylib\\raylib\\release\\include");
            // module.IncludeDirs.Add("C:\\raylib\\raylib\\src");
            module.Headers.Add("raylib.h");
            // module.Headers.Add("raymath.h");
            module.LibraryDirs.Add("C:\\raylib\\raylib\\release\\libs\\win32\\msvc");
            module.Libraries.Add("raylib.lib");

            var parserOptions = driver.ParserOptions;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.Verbose = true;
        }

        void ILibrary.SetupPasses(Driver driver)
        {
            driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Any);
            // driver.AddTranslationUnitPass(new FunctionToInstanceMethodPass());
            // driver.AddTranslationUnitPass(new HandleDefaultParamValuesPass());
            // driver.AddTranslationUnitPass(new CheckOperatorsOverloadsPass());
            // driver.Context.TranslationUnitPasses.RemovePrefix("KEY_");
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            ctx.SetNameOfEnumWithMatchingItem("KEY_UNKOWN", "Key");
            ctx.GenerateEnumFromMacros("Flag", "FLAG_(.*)");
            ctx.GenerateEnumFromMacros("Key", "KEY_(.*)");
            ctx.GenerateEnumFromMacros("Mouse", "MOUSE_(.*)");
            // ctx.GenerateEnumFromMacros("Gamepad", "GAMEPAD_(.*)");
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
            
        }        
    }
}