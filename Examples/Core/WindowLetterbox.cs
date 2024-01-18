/*******************************************************************************************
*
*   raylib [core] example - window scale letterbox
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Anata (@anatagawa) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Anata (@anatagawa) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Core;

public class WindowLetterbox
{
    public static int Main()
    {
        const int windowWidth = 800;
        const int windowHeight = 450;

        // Enable config flags for resizable window and vertical synchro
        SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
        InitWindow(windowWidth, windowHeight, "raylib [core] example - window scale letterbox");
        SetWindowMinSize(320, 240);

        int gameScreenWidth = 640;
        int gameScreenHeight = 480;

        // Render texture initialization, used to hold the rendering result so we can easily resize it
        RenderTexture2D target = LoadRenderTexture(gameScreenWidth, gameScreenHeight);
        SetTextureFilter(target.Texture, TextureFilter.Bilinear);

        Color[] colors = new Color[10];
        for (int i = 0; i < 10; i++)
        {
            colors[i] = new Color(GetRandomValue(100, 250), GetRandomValue(50, 150), GetRandomValue(10, 100), 255);
        }

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // Compute required framebuffer scaling
            float scale = MathF.Min(
                (float)GetScreenWidth() / gameScreenWidth,
                (float)GetScreenHeight() / gameScreenHeight
            );

            if (IsKeyPressed(KeyboardKey.Space))
            {
                // Recalculate random colors for the bars
                for (int i = 0; i < 10; i++)
                {
                    colors[i] = new Color(
                        GetRandomValue(100, 250),
                        GetRandomValue(50, 150),
                        GetRandomValue(10, 100),
                        255
                    );
                }
            }

            // Update virtual mouse (clamped mouse value behind game screen)
            Vector2 mouse = GetMousePosition();
            Vector2 virtualMouse = Vector2.Zero;
            virtualMouse.X = (mouse.X - (GetScreenWidth() - (gameScreenWidth * scale)) * 0.5f) / scale;
            virtualMouse.Y = (mouse.Y - (GetScreenHeight() - (gameScreenHeight * scale)) * 0.5f) / scale;

            Vector2 max = new((float)gameScreenWidth, (float)gameScreenHeight);
            virtualMouse = Vector2.Clamp(virtualMouse, Vector2.Zero, max);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.Black);

            // Draw everything in the render texture, note this will not be rendered on screen, yet
            BeginTextureMode(target);
            ClearBackground(Color.RayWhite);

            for (int i = 0; i < 10; i++)
            {
                DrawRectangle(0, (gameScreenHeight / 10) * i, gameScreenWidth, gameScreenHeight / 10, colors[i]);
            }

            DrawText(
                "If executed inside a window,\nyou can resize the window,\nand see the screen scaling!",
                10,
                25,
                20,
                Color.White
            );

            DrawText($"Default Mouse: [{(int)mouse.X} {(int)mouse.Y}]", 350, 25, 20, Color.Green);
            DrawText($"Virtual Mouse: [{(int)virtualMouse.X}, {(int)virtualMouse.Y}]", 350, 55, 20, Color.Yellow);

            EndTextureMode();

            // Draw RenderTexture2D to window, properly scaled
            Rectangle sourceRec = new(
                0.0f,
                0.0f,
                (float)target.Texture.Width,
                (float)-target.Texture.Height
            );
            Rectangle destRec = new(
                (GetScreenWidth() - ((float)gameScreenWidth * scale)) * 0.5f,
                (GetScreenHeight() - ((float)gameScreenHeight * scale)) * 0.5f,
                (float)gameScreenWidth * scale,
                (float)gameScreenHeight * scale
            );
            DrawTexturePro(target.Texture, sourceRec, destRec, new Vector2(0, 0), 0.0f, Color.White);

            EndDrawing();
            //--------------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadRenderTexture(target);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}

