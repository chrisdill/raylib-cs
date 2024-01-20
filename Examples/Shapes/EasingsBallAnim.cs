/*******************************************************************************************
*
*   raylib [shapes] example - easings ball anim
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;
using Examples.Shared;

namespace Examples.Shapes;

public class EasingsBallAnim
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings ball anim");

        // Ball variable value to be animated with easings
        int ballPositionX = -100;
        int ballRadius = 20;
        float ballAlpha = 0.0f;

        int state = 0;
        int framesCounter = 0;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (state == 0)             // Move ball position X with easing
            {
                framesCounter += 1;
                ballPositionX = (int)Easings.EaseElasticOut(framesCounter, -100, screenWidth / 2 + 100, 120);

                if (framesCounter >= 120)
                {
                    framesCounter = 0;
                    state = 1;
                }
            }
            // Increase ball radius with easing
            else if (state == 1)
            {
                framesCounter += 1;
                ballRadius = (int)Easings.EaseElasticIn(framesCounter, 20, 500, 200);

                if (framesCounter >= 200)
                {
                    framesCounter = 0;
                    state = 2;
                }
            }
            // Change ball alpha with easing (background color blending)
            else if (state == 2)
            {
                framesCounter += 1;
                ballAlpha = Easings.EaseCubicOut(framesCounter, 0.0f, 1.0f, 200);

                if (framesCounter >= 200)
                {
                    framesCounter = 0;
                    state = 3;
                }
            }
            // Reset state to play again
            else if (state == 3)
            {
                if (IsKeyPressed(KeyboardKey.Enter))
                {
                    // Reset required variables to play again
                    ballPositionX = -100;
                    ballRadius = 20;
                    ballAlpha = 0.0f;
                    state = 0;
                }
            }

            if (IsKeyPressed(KeyboardKey.R))
            {
                framesCounter = 0;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            if (state >= 2)
            {
                DrawRectangle(0, 0, screenWidth, screenHeight, Color.Green);
            }

            DrawCircle(ballPositionX, 200, ballRadius, ColorAlpha(Color.Red, 1.0f - ballAlpha));

            if (state == 3)
            {
                DrawText("PRESS [ENTER] TO PLAY AGAIN!", 240, 200, 20, Color.Black);
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

