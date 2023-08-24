/*******************************************************************************************
*
*   raylib [shapes] example - Colors palette
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Shapes;

public class ColorsPalette
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - colors palette");

        Color[] colors = new[]
        {
                Color.DARKGRAY,
                Color.MAROON,
                Color.ORANGE,
                Color.DARKGREEN,
                Color.DARKBLUE,
                Color.DARKPURPLE,
                Color.DARKBROWN,
                Color.GRAY,
                Color.RED,
                Color.GOLD,
                Color.LIME,
                Color.BLUE,
                Color.VIOLET,
                Color.BROWN,
                Color.LIGHTGRAY,
                Color.PINK,
                Color.YELLOW,
                Color.GREEN,
                Color.SKYBLUE,
                Color.PURPLE,
                Color.BEIGE
            };

        string[] colorNames = new[]
        {
                "DARKGRAY",
                "MAROON",
                "ORANGE",
                "DARKGREEN",
                "DARKBLUE",
                "DARKPURPLE",
                "DARKBROWN",
                "GRAY",
                "RED",
                "GOLD",
                "LIME",
                "BLUE",
                "VIOLET",
                "BROWN",
                "LIGHTGRAY",
                "PINK",
                "YELLOW",
                "GREEN",
                "SKYBLUE",
                "PURPLE",
                "BEIGE"
            };

        // Rectangles array
        Rectangle[] colorsRecs = new Rectangle[colors.Length];

        // Fills colorsRecs data (for every rectangle)
        for (int i = 0; i < colorsRecs.Length; i++)
        {
            colorsRecs[i].X = 20 + 100 * (i % 7) + 10 * (i % 7);
            colorsRecs[i].Y = 80 + 100 * (i / 7) + 10 * (i / 7);
            colorsRecs[i].Width = 100;
            colorsRecs[i].Height = 100;
        }

        // Color state: 0-DEFAULT, 1-MOUSE_HOVER
        int[] colorState = new int[colors.Length];

        Vector2 mousePoint = new(0.0f, 0.0f);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            mousePoint = GetMousePosition();

            for (int i = 0; i < colors.Length; i++)
            {
                if (CheckCollisionPointRec(mousePoint, colorsRecs[i]))
                {
                    colorState[i] = 1;
                }
                else
                {
                    colorState[i] = 0;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            DrawText("raylib colors palette", 28, 42, 20, Color.BLACK);
            DrawText(
                "press SPACE to see all colors",
                GetScreenWidth() - 180,
                GetScreenHeight() - 40,
                10,
                Color.GRAY
            );

            // Draw all rectangles
            for (int i = 0; i < colorsRecs.Length; i++)
            {
                DrawRectangleRec(colorsRecs[i], ColorAlpha(colors[i], colorState[i] != 0 ? 0.6f : 1.0f));

                if (IsKeyDown(KeyboardKey.KEY_SPACE) || colorState[i] != 0)
                {
                    DrawRectangle(
                        (int)colorsRecs[i].X,
                        (int)(colorsRecs[i].Y + colorsRecs[i].Height - 26),
                        (int)colorsRecs[i].Width,
                        20,
                        Color.BLACK
                    );
                    DrawRectangleLinesEx(colorsRecs[i], 6, ColorAlpha(Color.BLACK, 0.3f));
                    DrawText(
                        colorNames[i],
                        (int)(colorsRecs[i].X + colorsRecs[i].Width - MeasureText(colorNames[i], 10) - 12),
                        (int)(colorsRecs[i].Y + colorsRecs[i].Height - 20),
                        10,
                        colors[i]
                    );
                }
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

