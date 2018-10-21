using System;
using Raylib;
using static Raylib.Raylib;

class Program
{ 
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        // SetConfigFlags((int)Flag.WINDOW_UNDECORATED);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

        var model = LoadModel("bridge.obj");
        model.mesh.Vertices[0] = 5f;

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
            
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------   
        CloseWindow();        // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}
