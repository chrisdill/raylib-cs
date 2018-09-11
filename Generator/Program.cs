using System;
using System.IO;

namespace Raylibcs
{
    /// <summary>
    /// Rough generator for Raylib-cs to help automate binding porting raylib code
    /// Output will still need to be modified as it is a work in progess
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Raylib-cs generator");

            //GenerateBindings();
            GenerateExamples();
            //GenerateTemplates();
            //GenerateGames();

            Console.WriteLine("Finished generating. Enjoy! :)");
            Console.WriteLine("Press enter to exit");
            Console.Read();
        }

        static void GenerateBindings()
        {
            Console.WriteLine("Generating bindings");
            // Generator.Generate("raylib.h", "RLAPI");
        }

        static void GenerateExamples()
        {
            Console.WriteLine("Generating examples");

            // output folder
            Directory.CreateDirectory("Examples");

            // load files
            var path = Generator.RaylibDirectory + "Examples";
            var dirs = Directory.GetDirectories(path);

            // convert each file to rough c# version
            foreach (var dir in dirs)
            {
                // create sub folder in output
                var dirName = new DirectoryInfo(dir).Name;
                Directory.CreateDirectory("Examples\\" + dirName);
                var files = Directory.GetFiles(dir, "*.c");

                foreach (var file in files)
                {
                    Generator.ProcessExample(file, dirName);
                }
            }
        }

        static void GenerateTemplates()
        {
            Console.WriteLine("Generating templates");
            // TODO

        }

        static void GenerateGames()
        {
            Console.WriteLine("Generating games");
            // TODO

        }
    }
}
