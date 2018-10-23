using System;
using System.IO;
using Raylib;
using static Raylib.Raylib;

namespace Test.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to raylib-cs!");

            var dir = Environment.CurrentDirectory;
            while (true)
            {
                Console.WriteLine("Select raylib example(core/core_2d_camera)");

                var filePath = Console.ReadLine();;
                Console.WriteLine("Running example " + filePath + "...");

                dir = Directory.GetParent(dir).FullName;
                dir = Directory.GetParent(dir).FullName;
                dir = Directory.GetParent(dir).FullName;
                dir = Directory.GetParent(dir).FullName;
                dir += "\\Examples\\";

                var folder = dir + Path.GetDirectoryName(filePath);
                ChangeDirectory(folder);
                Type.GetType(filePath)?.GetMethod("Main")?.Invoke(null, args);
                Console.WriteLine();
            }
        }
    }
}
