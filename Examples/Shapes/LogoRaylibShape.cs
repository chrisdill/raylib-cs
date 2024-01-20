/*******************************************************************************************
*
*   raylib [shapes] example - Draw raylib logo using basic shapes
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Shapes;

public class LogoRaylibShape
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - raylib logo using shapes");

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawRectangle(screenWidth / 2 - 128, screenHeight / 2 - 128, 256, 256, new Color(139, 71, 135, 255));
            DrawRectangle(screenWidth / 2 - 112, screenHeight / 2 - 112, 224, 224, Color.RayWhite);
            DrawText("raylib", screenWidth / 2 - 44, screenHeight / 2 + 28, 50, new Color(155, 79, 151, 255));
            DrawText("cs", screenWidth / 2 - 44, screenHeight / 2 + 58, 50, new Color(155, 79, 151, 255));

            DrawText("this is NOT a texture!", 350, 370, 10, Color.Gray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
