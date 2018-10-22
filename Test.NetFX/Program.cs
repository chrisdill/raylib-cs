using System;
using System.IO;
using System.Windows.Forms;
using Raylib;
using static Raylib.Raylib;

namespace Test.NetFX
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to raylib-cs!");

            var dir = Environment.CurrentDirectory + "../../../Examples";
            while (true)
            {
                var ofd = new OpenFileDialog
                {
                    Filter = @"C#|*.cs",
                    Title = @"Select raylib example",
                    InitialDirectory = dir
                };

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                var test = Path.GetFileNameWithoutExtension(ofd.FileName);
                Console.WriteLine("Running example " + test + "...");

                ChangeDirectory(Path.GetDirectoryName(ofd.FileName));
                Type.GetType(test)?.GetMethod("Main")?.Invoke(null, args);
                Console.WriteLine();
            }
        }
    }
}
