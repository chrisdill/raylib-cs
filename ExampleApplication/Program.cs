using Raylib;
using static Raylib.rl;

namespace ExampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // LoadApp();
            Run();
        }

        public static int Run()
        {
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

                DrawText("Congrats! You created your first window!", 190, 200, 20, LIGHTGRAY);
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