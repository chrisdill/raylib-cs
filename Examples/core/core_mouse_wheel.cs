using Raylib;
using static Raylib.Raylib;

public partial class core_mouse_wheel
{
    /*******************************************************************************************
    *
    *   raylib [core] examples - Mouse wheel
    *
    *   This test has been created using raylib 1.1 (www.raylib.com)
    *   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
    *
    *   Copyright (c) 2014 Ramon Santamaria (@raysan5)
    *
    ********************************************************************************************/


    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - mouse wheel");

        int boxPositionY = screenHeight/2 - 40;
        int scrollSpeed = 4;            // Scrolling speed in pixels

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            boxPositionY -= (GetMouseWheelMove()*scrollSpeed);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

                ClearBackground(RAYWHITE);

                DrawRectangle(screenWidth/2 - 40, boxPositionY, 80, 80, MAROON);

                DrawText("Use mouse wheel to move the cube up and down!", 10, 10, 20, GRAY);
                DrawText(string.Format("Box position Y: {0:000}", boxPositionY), 10, 40, 20, LIGHTGRAY);
                DrawText($"Box position Y: {boxPositionY}", 10, 40, 20, LIGHTGRAY);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();        // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
