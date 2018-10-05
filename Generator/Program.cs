using System;
using System.IO;

namespace Raylibcs
{
    /// <summary>
    /// Rough generator for Raylib-cs to help automate binding + porting raylib code
    /// Output will still need to be modified
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Raylib-cs generator");

            GenerateBindings();
            GenerateExamples();
            GenerateTemplates();
            GenerateGames();

            Console.WriteLine("Finished generating. Enjoy! :)");
            Console.WriteLine("Press enter to exit");
            Console.Read();
        }

        static void GenerateBindings()
        {
            Console.WriteLine("Generating bindings");
            Generator.Process("raylib.h", "RLAPI");
            Generator.Process("rlgl.h", "RLGL");
        }

        static void GenerateExamples()
        {
            Console.WriteLine("Generating examples");

            // output folder
            var folder = "Examples";
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

        static void GenerateTemplates()
        {
            Console.WriteLine("Generating templates");

            // output folder
            var folder = "Templates";
            Directory.CreateDirectory(folder);
            var path = Generator.RaylibDirectory2 + folder.ToLower();
            var dirs = Directory.GetDirectories(path);

            // copy folder structure
            foreach (string dirPath in Directory.GetDirectories(path, "*",
    SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(path, folder));

            // process all c files in directory and output result
            var files = Directory.GetFiles(path, "*.c", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var dirName = Path.GetDirectoryName(file);
                var name = new DirectoryInfo(dirName).Name;
                if (name == folder.ToLower())
                {
                    Generator.ProcessExample(file, folder, folder);
                }
                else
                {
                    var t = file;
                    t = folder + t.Replace(path, "");
                    t = new FileInfo(t).Directory.FullName;
                    Generator.ProcessExample(file, folder, t);
                }
            }
        }

        static void GenerateGames()
        {
            Console.WriteLine("Generating games");
          
            // output folder
            var folder = "Games";
            Directory.CreateDirectory(folder);
            var path = Generator.RaylibDirectory2 + folder.ToLower();
            var dirs = Directory.GetDirectories(path);

            // copy folder structure
            foreach (string dirPath in Directory.GetDirectories(path, "*",
    SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(path, folder));

            // process all c files in directory and output result
            var files = Directory.GetFiles(path, "*.c", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var dirName = Path.GetDirectoryName(file);
                var name = new DirectoryInfo(dirName).Name;
                if (name == folder.ToLower())
                {
                    Generator.ProcessExample(file, folder, folder);
                }
                else
                {
                    var t = file;
                    t = folder + t.Replace(path, "");
                    t = new FileInfo(t).Directory.FullName;
                    Generator.ProcessExample(file, folder, t);
                }
            }
        }
    }
}
