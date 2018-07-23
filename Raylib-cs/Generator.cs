using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;

namespace Raylibcs
{
    /// <summary>
    /// Generates the bindings for raylib
    /// ConsoleDriver.Run(new SampleLibrary());
    /// </summary>
    public class SampleLibrary : ILibrary
    {
        public void Preprocess(Driver driver, ASTContext ctx)
        {
            
            // ctx.SetNameOfEnumWithMatchingItem("KEY_", "Keys");

            // throw new NotImplementedException();
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
            //throw new NotImplementedException();
        }

        void ILibrary.Setup(Driver driver)
        {
            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.Verbose = true;

            var module = options.AddModule("raylib");
            module.IncludeDirs.Add("C:\\raylib\\raylib\\src");
            module.Headers.Add("raylib.h");
            module.Headers.Add("raymath.h");
            module.LibraryDirs.Add("C:\\raylib\\raylib\\release\\libs\\win32\\msvc");
            module.Libraries.Add("raylib.lib");
            module.Defines.Add("KEY_SPACE");
        }
        
        void ILibrary.SetupPasses(Driver driver)
        {
            // throw new NotImplementedException();
        }
    }
}