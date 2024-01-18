/*******************************************************************************************
*
*   raylib [texture] example - Image text drawing using TTF generated spritefont
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class ImageText
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [texture] example - image text drawing");

        // TTF Font loading with custom generation parameters
        Font font = LoadFontEx("resources/fonts/KAISG.ttf", 64, null, 95);

        Image parrots = LoadImage("resources/parrots.png");

        // Draw over image using custom font
        ImageDrawTextEx(
            ref parrots,
            font,
            "[Parrots font drawing]",
            new Vector2(20, 20),
            font.BaseSize,
            0,
            Color.White
        );

        // Image converted to texture, uploaded to GPU memory (VRAM)
        Texture2D texture = LoadTextureFromImage(parrots);
        UnloadImage(parrots);

        Vector2 position = new(
            screenWidth / 2 - texture.Width / 2,
            screenHeight / 2 - texture.Height / 2 - 20
        );

        bool showFont = false;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyDown(KeyboardKey.Space))
            {
                showFont = true;
            }
            else
            {
                showFont = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            if (!showFont)
            {
                // Draw texture with text already drawn inside
                DrawTextureV(texture, position, Color.White);

                // Draw text directly using sprite font
                Vector2 textPosition = new(position.X + 20, position.Y + 20 + 280);
                DrawTextEx(font, "[Parrots font drawing]", textPosition, font.BaseSize, 0, Color.White);
            }
            else
            {
                DrawTexture(font.Texture, screenWidth / 2 - font.Texture.Width / 2, 50, Color.Black);
            }

            DrawText("PRESS SPACE to SEE USED SPRITEFONT ", 290, 420, 10, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texture);
        UnloadFont(font);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
