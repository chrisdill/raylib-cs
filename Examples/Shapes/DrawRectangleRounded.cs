/*******************************************************************************************
*
*   raylib [shapes] example - draw rectangle rounded (with gui options)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Shapes;

public class DrawRectangleRounded
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw rectangle rounded");

        float roundness = 0.2f;
        int width = 400;
        int height = 200;
        int segments = 0;
        int lineThick = 10;

        bool drawRect = false;
        bool drawRoundedRect = false;
        bool drawRoundedLines = true;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            Rectangle rec = new(
                (GetScreenWidth() - width - 250) / 2.0f,
                (GetScreenHeight() - height) / 2.0f,
                (float)width,
                (float)height
            );
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawLine(560, 0, 560, GetScreenHeight(), ColorAlpha(Color.LightGray, 0.6f));
            DrawRectangle(560, 0, GetScreenWidth() - 500, GetScreenHeight(), ColorAlpha(Color.LightGray, 0.3f));

            if (drawRect)
            {
                DrawRectangleRec(rec, ColorAlpha(Color.Gold, 0.6f));
            }
            if (drawRoundedRect)
            {
                DrawRectangleRounded(rec, roundness, segments, ColorAlpha(Color.Maroon, 0.2f));
            }
            if (drawRoundedLines)
            {
                DrawRectangleRoundedLines(rec, roundness, segments, (float)lineThick, ColorAlpha(Color.Maroon, 0.4f));
            }

            // Draw GUI controls
            //------------------------------------------------------------------------------
            /*width = GuiSliderBar(new Rectangle( 640, 40, 105, 20 ), "Width", width, 0, GetScreenWidth() - 300, true );
            height = GuiSliderBar(new Rectangle( 640, 70, 105, 20 ), "Height", height, 0, GetScreenHeight() - 50, true);
            roundness = GuiSliderBar(new Rectangle( 640, 140, 105, 20 ), "Roundness", roundness, 0.0f, 1.0f, true);
            lineThick = GuiSliderBar(new Rectangle( 640, 170, 105, 20 ), "Thickness", lineThick, 0, 20, true);
            segments = GuiSliderBar(new Rectangle( 640, 240, 105, 20), "Segments", segments, 0, 60, true);

            drawRoundedRect = GuiCheckBox(new Rectangle( 640, 320, 20, 20 ), "DrawRoundedRect", drawRoundedRect);
            drawRoundedLines = GuiCheckBox(new Rectangle( 640, 350, 20, 20 ), "DrawRoundedLines", drawRoundedLines);
            drawRect = GuiCheckBox(new Rectangle( 640, 380, 20, 20), "DrawRect", drawRect);*/
            //------------------------------------------------------------------------------

            string text = $"MODE: {((segments >= 4) ? "MANUAL" : "AUTO")}";
            DrawText(text, 640, 280, 10, (segments >= 4) ? Color.Maroon : Color.DarkGray);
            DrawFPS(10, 10);

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

