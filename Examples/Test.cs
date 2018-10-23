using System;
using System.IO;
using static Raylib.Raylib;

namespace Examples
{
    public class Test
    {
        // menu for testing examples
        public static void Run(string[] args)
        {
            Console.WriteLine("Welcome to raylib-cs!");

            while (true)
            {
                Console.WriteLine("Enter path to example");

                var filePath = Console.ReadLine();
                var name = Path.GetFileNameWithoutExtension(filePath);

                Console.WriteLine("Running example " + filePath);

                ChangeDirectory(filePath);
                Type.GetType(name)?.GetMethod("Main")?.Invoke(null, args);

                Console.WriteLine();
            }
        }
    }
}
