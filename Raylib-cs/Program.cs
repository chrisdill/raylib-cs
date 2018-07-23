using CppSharp;
using raylib;
using static raylib.raymath;
using static raylib.raylib;
using System;

namespace Raylibcs
{
    class Program
    {
        static void Main(string[] args)
        {
            // ConsoleDriver.Run(new SampleLibrary());
            Test();
            // Console.Read();
        }

        public static void Test()
        {
            InitWindow(800, 450, "Raylib-cs [2.0]");
            InitAudioDevice();          
            SetTargetFPS(60);
            SetExitKey(256);
   
            var sound = LoadSound("Data/alive.wav");
            // PlaySound(sound);

            var t = LoadTexture("Data/test.png");

            int a = 0;
            var f = LoadFontEx("Data/Vera.ttf", 96, 0, ref a);

            var c = new Color();
            c.R = 255;
            c.G = 255;
            c.B = 255;
            c.A = 255;

            while (!WindowShouldClose())
            {
                BeginDrawing();
                ClearBackground(c);
                DrawTexture(t, 0, 0, c);
                // DrawTextEx(f, "testing", new Vector2 { X = 100, Y = 100 }, 20, 10, c);
                // DrawFPS(0, 0);
                EndDrawing();
            }

            UnloadTexture(t);
            CloseAudioDevice();
            CloseWindow();
        }
    }
}