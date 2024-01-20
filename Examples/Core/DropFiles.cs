/*******************************************************************************************
*
*   raylib [core] example - Windows drop files
*
*   This example only works on platforms that support drag ref drop (Windows, Linux, OSX, Html5?)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Core;

public class DropFiles
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - drop files");

        string[] files = new string[0];

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsFileDropped())
            {
                files = Raylib.GetDroppedFiles();
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            if (files.Length == 0)
            {
                DrawText("Drop your files to this window!", 100, 40, 20, Color.DarkGray);
            }
            else
            {
                DrawText("Dropped files:", 100, 40, 20, Color.DarkGray);

                for (int i = 0; i < files.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        DrawRectangle(0, 85 + 40 * i, screenWidth, 40, ColorAlpha(Color.LightGray, 0.5f));
                    }
                    else
                    {
                        DrawRectangle(0, 85 + 40 * i, screenWidth, 40, ColorAlpha(Color.LightGray, 0.3f));
                    }
                    DrawText(files[i], 120, 100 + 40 * i, 10, Color.Gray);
                }

                DrawText("Drop new files...", 100, 110 + 40 * files.Length, 20, Color.DarkGray);
            }

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
