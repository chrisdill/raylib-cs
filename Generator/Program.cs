using System;

namespace Raylibcs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Raylib-cs generator");
            // Generator.Process("raylib.h", "RLAPI");
            Generator.ProcessExamples();
            Console.WriteLine("Press enter to exit");
            Console.Read();
        }
    }
}
