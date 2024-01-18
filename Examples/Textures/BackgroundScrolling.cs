/*******************************************************************************************
*
*   raylib [textures] example - Background scrolling
*
*   This example has been created using raylib 2.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class BackgroundScrolling
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - background scrolling");

        // NOTE: Be careful, background width must be equal or bigger than screen width
        // if not, texture should be draw more than two times for scrolling effect
        Texture2D background = LoadTexture("resources/cyberpunk_street_background.png");
        Texture2D midground = LoadTexture("resources/cyberpunk_street_midground.png");
        Texture2D foreground = LoadTexture("resources/cyberpunk_street_foreground.png");

        float scrollingBack = 0.0f;
        float scrollingMid = 0.0f;
        float scrollingFore = 0.0f;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            scrollingBack -= 0.1f;
            scrollingMid -= 0.5f;
            scrollingFore -= 1.0f;

            // NOTE: Texture is scaled twice its size, so it sould be considered on scrolling
            if (scrollingBack <= -background.Width * 2)
            {
                scrollingBack = 0;
            }
            if (scrollingMid <= -midground.Width * 2)
            {
                scrollingMid = 0;
            }
            if (scrollingFore <= -foreground.Width * 2)
            {
                scrollingFore = 0;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(GetColor(0x052c46ff));

            // Draw background image twice
            // NOTE: Texture is scaled twice its size
            DrawTextureEx(background, new Vector2(scrollingBack, 20), 0.0f, 2.0f, Color.White);
            DrawTextureEx(
                background,
                new Vector2(background.Width * 2 + scrollingBack, 20),
                0.0f,
                2.0f,
                Color.White
            );

            // Draw midground image twice
            DrawTextureEx(midground, new Vector2(scrollingMid, 20), 0.0f, 2.0f, Color.White);
            DrawTextureEx(midground, new Vector2(midground.Width * 2 + scrollingMid, 20), 0.0f, 2.0f, Color.White);

            // Draw foreground image twice
            DrawTextureEx(foreground, new Vector2(scrollingFore, 70), 0.0f, 2.0f, Color.White);
            DrawTextureEx(
                foreground,
                new Vector2(foreground.Width * 2 + scrollingFore, 70),
                0.0f,
                2.0f,
                Color.White
            );

            DrawText("BACKGROUND SCROLLING & PARALLAX", 10, 10, 20, Color.Red);

            int x = screenWidth - 330;
            int y = screenHeight - 20;
            DrawText("(c) Cyberpunk Street Environment by Luis Zuno (@ansimuz)", x, y, 10, Color.RayWhite);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(background);
        UnloadTexture(midground);
        UnloadTexture(foreground);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
