using System;
using CppSharp;

namespace Raylibcs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Raylib-cs binding generator");    
            ConsoleDriver.Run(new SampleLibrary());
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}