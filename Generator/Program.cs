using System;
using System.IO;

namespace Generator
{
    /// <summary>
    /// Rough generator for creating bindings and ports for raylib
    /// Not a full parser so generated code is not perfect
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Raylib-cs generator");
            GenerateBindings();
            // GeneratePort("Examples");
            // GeneratePort("Templates");
            // GeneratePort("Games");
            Console.WriteLine("Finished generating. Enjoy! :)");
            Console.WriteLine("Press enter to exit");
            Console.Read();
        }

        /// <summary>
        /// Requires raylib headers
        /// </summary>
        static void GenerateBindings()
        {
            Console.WriteLine("Generating bindings");
            Generator.Process("raylib.h", "RLAPI");
            Generator.Process("raymath.h", "RMDEF");
            Generator.Process("physac.h", "PDEF");
            Generator.Process("rlgl.h", "RLGL");
        }

        /// <summary>
        /// Porting C to C#
        /// </summary>
        static void GeneratePort(string folder)
        {
            Console.WriteLine("Generating examples");

            // output folder
            Directory.CreateDirectory(folder);
            var path = Generator.RaylibDirectory + folder.ToLower();
            var dirs = Directory.GetDirectories(path);

            var files = Directory.GetFiles(path, "*.c", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                // create sub folder in output
                var dirName = Path.GetDirectoryName(file);
                var name = new DirectoryInfo(dirName).Name;
                if (!Directory.Exists(folder + name))
                    Directory.CreateDirectory(folder + "//" + name);
                Generator.ProcessExample(file, folder, folder + "//" + name);
            }
        }
    }
}
