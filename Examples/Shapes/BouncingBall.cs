/*******************************************************************************************
*
*   raylib [shapes] example - bouncing ball
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Shapes;

public class BouncingBall
{
    public static int Main()
    {
        // Initialization
        //---------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - bouncing ball");

        Vector2 ballPosition = new(GetScreenWidth() / 2, GetScreenHeight() / 2);
        Vector2 ballSpeed = new(5.0f, 4.0f);
        int ballRadius = 20;

        bool pause = false;
        int framesCounter = 0;

        SetTargetFPS(60);
        //----------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //-----------------------------------------------------
            if (IsKeyPressed(KeyboardKey.Space))
            {
                pause = !pause;
            }

            if (!pause)
            {
                ballPosition.X += ballSpeed.X;
                ballPosition.Y += ballSpeed.Y;

                // Check walls collision for bouncing
                if ((ballPosition.X >= (GetScreenWidth() - ballRadius)) || (ballPosition.X <= ballRadius))
                {
                    ballSpeed.X *= -1.0f;
                }
                if ((ballPosition.Y >= (GetScreenHeight() - ballRadius)) || (ballPosition.Y <= ballRadius))
                {
                    ballSpeed.Y *= -1.0f;
                }
            }
            else
            {
                framesCounter += 1;
            }
            //-----------------------------------------------------

            // Draw
            //-----------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawCircleV(ballPosition, ballRadius, Color.Maroon);
            DrawText("PRESS SPACE to PAUSE BALL MOVEMENT", 10, GetScreenHeight() - 25, 20, Color.LightGray);

            // On pause, we draw a blinking message
            if (pause && ((framesCounter / 30) % 2) == 0)
            {
                DrawText("PAUSED", 350, 200, 30, Color.Gray);
            }
            DrawFPS(10, 10);

            EndDrawing();
            //-----------------------------------------------------
        }

        // De-Initialization
        //---------------------------------------------------------
        CloseWindow();
        //----------------------------------------------------------

        return 0;
    }
}

