/*******************************************************************************************
*
*   raylib [shapes] example - draw ring (with gui options)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Shapes;

public class DrawRing
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw ring");

        Vector2 center = new((GetScreenWidth() - 300) / 2, GetScreenHeight() / 2);

        float innerRadius = 80.0f;
        float outerRadius = 190.0f;

        int startAngle = 0;
        int endAngle = 360;
        int segments = 0;
        int minSegments = 4;

        bool drawRing = true;
        bool drawRingLines = false;
        bool drawCircleLines = false;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // NOTE: All variables update happens inside GUI control functions
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawLine(500, 0, 500, GetScreenHeight(), ColorAlpha(Color.LightGray, 0.6f));
            DrawRectangle(500, 0, GetScreenWidth() - 500, GetScreenHeight(), ColorAlpha(Color.LightGray, 0.3f));

            if (drawRing)
            {
                DrawRing(
                    center,
                    innerRadius,
                    outerRadius,
                    startAngle,
                    endAngle,
                    segments,
                    ColorAlpha(Color.Maroon, 0.3f)
                );
            }
            if (drawRingLines)
            {
                DrawRingLines(
                    center,
                    innerRadius,
                    outerRadius,
                    startAngle,
                    endAngle,
                    segments,
                    ColorAlpha(Color.Black, 0.4f)
                );
            }
            if (drawCircleLines)
            {
                DrawCircleSectorLines(
                    center,
                    outerRadius,
                    startAngle,
                    endAngle,
                    segments,
                    ColorAlpha(Color.Black, 0.4f)
                );
            }

            // Draw GUI controls
            //------------------------------------------------------------------------------
            /*startAngle = GuiSliderBar(new Rectangle( 600, 40, 120, 20 ), "StartAngle", startAngle, -450, 450, true);
            endAngle = GuiSliderBar(new Rectangle( 600, 70, 120, 20 ), "EndAngle", endAngle, -450, 450, true);

            innerRadius = GuiSliderBar(new Rectangle( 600, 140, 120, 20 ), "InnerRadius", innerRadius, 0, 100, true);
            outerRadius = GuiSliderBar(new Rectangle( 600, 170, 120, 20 ), "OuterRadius", outerRadius, 0, 200, true);

            segments = GuiSliderBar(new Rectangle( 600, 240, 120, 20 ), "Segments", segments, 0, 100, true);

            drawRing = GuiCheckBox(new Rectangle( 600, 320, 20, 20 ), "Draw Ring", drawRing);
            drawRingLines = GuiCheckBox(new Rectangle( 600, 350, 20, 20 ), "Draw RingLines", drawRingLines);
            drawCircleLines = GuiCheckBox(new Rectangle( 600, 380, 20, 20 ), "Draw CircleLines", drawCircleLines);*/
            //------------------------------------------------------------------------------

            minSegments = (int)MathF.Ceiling((endAngle - startAngle) / 90);
            Color color = (segments >= minSegments) ? Color.Maroon : Color.DarkGray;
            DrawText($"MODE: {((segments >= minSegments) ? "MANUAL" : "AUTO")}", 600, 270, 10, color);

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
