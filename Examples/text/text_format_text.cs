using Raylib;
using static Raylib.Raylib;

public partial class text_format_text
{
    /*******************************************************************************************
    *
    *   raylib [text] example - Text formatting
    *
    *   This example has been created using raylib 1.1 (www.raylib.com)
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

        InitWindow(screenWidth, screenHeight, "raylib [text] example - text formatting");

        int score = 100020;
        int hiscore = 200450;
        int lives = 5;

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
            
                DrawText(string.Format("Score: {0:00000000}", score), 200, 80, 20, RED);

                DrawText(string.Format("HiScore: {0:00000000}", hiscore), 200, 120, 20, GREEN);

                DrawText(string.Format("Lives: {0:00}", lives), 200, 160, 40, BLUE);

                DrawText(string.Format("Elapsed Time: {0:00.00} ms", GetFrameTime()*1000), 200, 220, 20, BLACK);

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
