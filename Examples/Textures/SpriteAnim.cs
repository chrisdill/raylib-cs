/*******************************************************************************************
*
*   raylib [textures] example - Texture loading and drawing a part defined by a rectangle
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class SpriteAnim
{
    public const int MaxFrameSpeed = 15;
    public const int MinFrameSpeed = 1;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [texture] example - texture rectangle");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Texture2D scarfy = LoadTexture("resources/scarfy.png");

        Vector2 position = new(350.0f, 280.0f);
        Rectangle frameRec = new(0.0f, 0.0f, (float)scarfy.Width / 6, (float)scarfy.Height);
        int currentFrame = 0;

        int framesCounter = 0;

        // Number of spritesheet frames shown by second
        int framesSpeed = 8;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            framesCounter++;

            if (framesCounter >= (60 / framesSpeed))
            {
                framesCounter = 0;
                currentFrame++;

                if (currentFrame > 5)
                {
                    currentFrame = 0;
                }

                frameRec.X = (float)currentFrame * (float)scarfy.Width / 6;
            }

            if (IsKeyPressed(KeyboardKey.Right))
            {
                framesSpeed++;
            }
            else if (IsKeyPressed(KeyboardKey.Left))
            {
                framesSpeed--;
            }

            framesSpeed = Math.Clamp(framesSpeed, MinFrameSpeed, MaxFrameSpeed);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawTexture(scarfy, 15, 40, Color.White);
            DrawRectangleLines(15, 40, scarfy.Width, scarfy.Height, Color.Lime);
            DrawRectangleLines(
                15 + (int)frameRec.X,
                40 + (int)frameRec.Y,
                (int)frameRec.Width,
                (int)frameRec.Height,
                Color.Red
            );

            DrawText("FRAME SPEED: ", 165, 210, 10, Color.DarkGray);
            DrawText($"{framesSpeed:2F} FPS", 575, 210, 10, Color.DarkGray);
            DrawText("PRESS RIGHT/LEFT KEYS to CHANGE SPEED!", 290, 240, 10, Color.DarkGray);

            for (int i = 0; i < MaxFrameSpeed; i++)
            {
                if (i < framesSpeed)
                {
                    DrawRectangle(250 + 21 * i, 205, 20, 20, Color.Red);
                }
                DrawRectangleLines(250 + 21 * i, 205, 20, 20, Color.Maroon);
            }

            // Draw part of the texture
            DrawTextureRec(scarfy, frameRec, position, Color.White);
            DrawText("(c) Scarfy sprite by Eiden Marsal", screenWidth - 200, screenHeight - 20, 10, Color.Gray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(scarfy);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
