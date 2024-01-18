/*******************************************************************************************
*
*   raylib [text] example - Font filters
*
*   After font loading, font texture atlas filter could be configured for a softer
*   display of the font when scaling it to different sizes, that way, it's not required
*   to generate multiple fonts at multiple sizes (as long as the scaling is not very different)
*
*   This example has been created using raylib 1.3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Text;

public class FontFilters
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - font filters");

        string msg = "Loaded Font";

        // NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

        // TTF Font loading with custom generation parameters
        Font font = LoadFontEx("resources/fonts/KAISG.ttf", 96, null, 0);

        // Generate mipmap levels to use trilinear filtering
        // NOTE: On 2D drawing it won't be noticeable, it looks like TEXTURE_FILTER_BILINEAR
        GenTextureMipmaps(ref font.Texture);

        float fontSize = font.BaseSize;
        Vector2 fontPosition = new(40, screenHeight / 2 - 80);
        Vector2 textSize = new(0.0f, 0.0f);

        // Setup texture scaling filter
        SetTextureFilter(font.Texture, TextureFilter.Point);
        TextureFilter currentFontFilter = TextureFilter.Point;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            fontSize += GetMouseWheelMove() * 4.0f;

            // Choose font texture filter method
            if (IsKeyPressed(KeyboardKey.One))
            {
                SetTextureFilter(font.Texture, TextureFilter.Point);
                currentFontFilter = TextureFilter.Point;
            }
            else if (IsKeyPressed(KeyboardKey.Two))
            {
                SetTextureFilter(font.Texture, TextureFilter.Bilinear);
                currentFontFilter = TextureFilter.Bilinear;
            }
            else if (IsKeyPressed(KeyboardKey.Three))
            {
                // NOTE: Trilinear filter won't be noticed on 2D drawing
                SetTextureFilter(font.Texture, TextureFilter.Trilinear);
                currentFontFilter = TextureFilter.Trilinear;
            }

            textSize = MeasureTextEx(font, msg, fontSize, 0);

            if (IsKeyDown(KeyboardKey.Left))
            {
                fontPosition.X -= 10;
            }
            else if (IsKeyDown(KeyboardKey.Right))
            {
                fontPosition.X += 10;
            }

            // Load a dropped TTF file dynamically (at current fontSize)
            if (IsFileDropped())
            {
                string[] files = Raylib.GetDroppedFiles();

                // NOTE: We only support first ttf file dropped
                if (IsFileExtension(files[0], ".ttf"))
                {
                    UnloadFont(font);
                    font = LoadFontEx(files[0], (int)fontSize, null, 0);
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawText("Use mouse wheel to change font size", 20, 20, 10, Color.Gray);
            DrawText("Use KEY_RIGHT and KEY_LEFT to move text", 20, 40, 10, Color.Gray);
            DrawText("Use 1, 2, 3 to change texture filter", 20, 60, 10, Color.Gray);
            DrawText("Drop a new TTF font for dynamic loading", 20, 80, 10, Color.DarkGray);

            DrawTextEx(font, msg, fontPosition, fontSize, 0, Color.Black);

            DrawRectangle(0, screenHeight - 80, screenWidth, 80, Color.LightGray);
            DrawText("CURRENT TEXTURE FILTER:", 250, 400, 20, Color.Gray);

            if (currentFontFilter == TextureFilter.Point)
            {
                DrawText("POINT", 570, 400, 20, Color.Black);
            }
            else if (currentFontFilter == TextureFilter.Point)
            {
                DrawText("BILINEAR", 570, 400, 20, Color.Black);
            }
            else if (currentFontFilter == TextureFilter.Trilinear)
            {
                DrawText("TRILINEAR", 570, 400, 20, Color.Black);
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadFont(font);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}

