/*******************************************************************************************
*
*   raylib [core] example - Generate random values
*
*   This example has been created using raylib 1.1 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Core;

public class RandomValues
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - generate random values");

        // Variable used to count frames
        int framesCounter = 0;

        // Get a random integer number between -8 and 5 (both included)
        int randValue = GetRandomValue(-8, 5);

        SetTargetFPS(60);       // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            framesCounter++;

            // Every two seconds (120 frames) a new random value is generated
            if (((framesCounter / 120) % 2) == 1)
            {
                randValue = GetRandomValue(-8, 5);
                framesCounter = 0;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawText("Every 2 seconds a new random value is generated:", 130, 100, 20, Color.Maroon);

            DrawText($"{randValue}", 360, 180, 80, Color.LightGray);

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
