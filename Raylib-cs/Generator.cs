using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using System;
using System.IO;

namespace Raylibcs
{
    /// <summary>
    /// Generates the bindings for raylib(WIP)
    /// ConsoleDriver.Run(new SampleLibrary());
    /// </summary>
    public class SampleLibrary : ILibrary
    {
        void ILibrary.Setup(Driver driver)
        {
            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.OutputDir = Path.Combine(Environment.CurrentDirectory, "Raylib-cs");
            options.Verbose = true;
            // options.UseHeaderDirectories = true;

            var module = options.AddModule("raylib");
            module.IncludeDirs.Add("C:\\raylib\\raylib\\src");
            module.Headers.Add("raylib.h");
            // module.Headers.Add("rlgl.h");
            // module.Headers.Add("raymath.h");
            module.LibraryDirs.Add("C:\\raylib\\raylib\\projects\\VS2017\\x64\\Debug.DLL");
            module.Libraries.Add("raylib.lib");
            // module.OutputNamespace = "Raylib";
            // module.internalNamespace = "rl";
        }

        void ILibrary.SetupPasses(Driver driver)
        {
            // driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Any);
            // driver.AddTranslationUnitPass(new FunctionToInstanceMethodPass());
            // driver.AddTranslationUnitPass(new CheckOperatorsOverloadsPass());
            /*driver.Context.TranslationUnitPasses.RemovePrefix("FLAG_");
            driver.Context.TranslationUnitPasses.RemovePrefix("KEY_");
            driver.Context.TranslationUnitPasses.RemovePrefix("MOUSE_");
            driver.Context.TranslationUnitPasses.RemovePrefix("GAMEPAD_");
            driver.Context.TranslationUnitPasses.RemovePrefix("GAMEPAD_PS3_");
            driver.Context.TranslationUnitPasses.RemovePrefix("GAMEPAD_PS3_AXIS_");
            driver.Context.TranslationUnitPasses.RemovePrefix("GAMEPAD_XBOX_AXIS_");
            driver.Context.TranslationUnitPasses.RemovePrefix("GAMEPAD_ANDORID_");*/
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            ctx.SetNameOfEnumWithMatchingItem("KEY_UNKOWN", "Key");
            ctx.GenerateEnumFromMacros("Flag", "FLAG_(.*)");
            ctx.GenerateEnumFromMacros("Key", "KEY_(.*)");
            ctx.GenerateEnumFromMacros("Mouse", "MOUSE_(.*)");
            ctx.GenerateEnumFromMacros("Gamepad", "GAMEPAD_(.*)");
            ctx.GenerateEnumFromMacros("GamepadPS3", "GAMEPAD_PS3_(.*)");
            ctx.GenerateEnumFromMacros("GamepadPS3Axis", "GAMEPAD_PS3_AXIS_(.*)");
            ctx.GenerateEnumFromMacros("GamepadXbox", "GAMEPAD_XBOX_(.*)");
            ctx.GenerateEnumFromMacros("GamepadXboxAxis", "GAMEPAD_XBOX_AXIS_(.*)");
            ctx.GenerateEnumFromMacros("GamepadAndroid", "GAMEPAD_ANDROID_(.*)");
            // TODO: MaxTouchPoints, MaxShaderLocations, MaxMateiralMaps
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
            
        }        
    }
}