using System;
using System.IO;
using static Raylib.Raylib;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Examples
{
    public class Test
    {
        public static string GetExampleDirectory()
        {
            var dir = Environment.CurrentDirectory;
            dir = dir.Substring(0, dir.LastIndexOf("Raylib-cs") + 9) + "\\Examples\\";
            return dir;
        }

        // menu for testing examples
        // specify name relative to example directory
        public static void Run(string[] args)
        {
            Console.WriteLine("Welcome to raylib-cs!");
            Console.WriteLine("---------------------");

            var examples = GetExampleDirectory();
            Console.WriteLine("Looking for examples relative to " + examples);
            Console.WriteLine("For example, core/core_basic_window");

            while (true)
            {
                Console.Write("Choose a example: ");

                // select example
                var filePath = Console.ReadLine();
                var name = Path.GetFileNameWithoutExtension(filePath);
                var dir = examples + filePath + ".cs";
              
                // run example if it exists
                if (File.Exists(dir))
                {
                    ChangeDirectory(Path.GetDirectoryName(dir));
                    try
                    {
                        Type.GetType(name)?.GetMethod("Main")?.Invoke(null, args);
                    }
                    catch(TargetInvocationException e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                        Console.WriteLine(e.InnerException.StackTrace);      
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(filePath + " is not a valid example");
                } 
            }
        }
    }
}
