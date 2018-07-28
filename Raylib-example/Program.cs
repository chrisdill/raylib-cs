using raylib;
using static raylib.raylib;

namespace Raylibexample
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
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