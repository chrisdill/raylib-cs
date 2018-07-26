using System;
using CppSharp;
using raylib;
using static raylib.raylib;

namespace Raylibcs
{
    class Program
    {
        // TODO: setup windows forms gui
        static void Main(string[] args)
        {
            Console.WriteLine("Raylib-cs generator");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Regenerate bindings in .exe folder");
                Console.WriteLine("2. Run test example, requires raylib.dll in .exe folder");
                Console.WriteLine("3. Exit");

                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    ConsoleDriver.Run(new SampleLibrary());
                }
                else if (choice == "2")
                {
                    Test();
                }
                else if (choice == "3")
                {
                    break;
                }
            }
        }

        public static int Test()
        {
            var RAYWHITE = new Color { R = 255, G = 255, B = 255, A = 255 };
            var MAROON = new Color { R = 0, G = 0, B = 0, A = 255 };

            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;

            InitWindow(screenWidth, screenHeight, "Raylib-cs [core] example - basic window");

            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(RAYWHITE);

                DrawText("Congrats! You created your first window!", 190, 200, 20, MAROON);
                DrawFPS(0, 0);

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------   
            CloseWindow();        // Close window and OpenGL context
            //-----------------------------

            return 0;
        }
    }
}