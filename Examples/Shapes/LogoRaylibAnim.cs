/*******************************************************************************************
*
*   raylib [shapes] example - raylib logo animation
*
*   This example has been created using raylib 1.4 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Shapes;

public class LogoRaylibAnim
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - raylib logo animation");

        int logoPositionX = screenWidth / 2 - 128;
        int logoPositionY = screenHeight / 2 - 128;

        int framesCounter = 0;
        int lettersCount = 0;

        int topSideRecWidth = 16;
        int leftSideRecHeight = 16;

        int bottomSideRecWidth = 16;
        int rightSideRecHeight = 16;

        // Tracking animation states (State Machine)
        int state = 0;

        // Useful for fading
        float alpha = 1.0f;

        Color outline = new(139, 71, 135, 255);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // State 0: Small box blinking
            if (state == 0)
            {
                framesCounter++;

                // Reset counter... will be used later...
                if (framesCounter == 120)
                {
                    state = 1;
                    framesCounter = 0;
                }
            }
            // State 1: Top and left bars growing
            else if (state == 1)
            {
                topSideRecWidth += 4;
                leftSideRecHeight += 4;

                if (topSideRecWidth == 256)
                {
                    state = 2;
                }
            }
            // State 2: Bottom and right bars growing
            else if (state == 2)
            {
                bottomSideRecWidth += 4;
                rightSideRecHeight += 4;

                if (bottomSideRecWidth == 256)
                {
                    state = 3;
                }
            }
            // State 3: Letters appearing (one by one)
            else if (state == 3)
            {
                framesCounter++;

                // Every 12 frames, one more letter!
                if (framesCounter / 12 != 0)
                {
                    lettersCount++;
                    framesCounter = 0;
                }

                // When all letters have appeared, just fade out everything
                if (lettersCount >= 10)
                {
                    alpha -= 0.02f;

                    if (alpha <= 0.0f)
                    {
                        alpha = 0.0f;
                        state = 4;
                    }
                }
            }
            // State 4: Reset and Replay
            else if (state == 4)
            {
                if (IsKeyPressed(KeyboardKey.R))
                {
                    framesCounter = 0;
                    lettersCount = 0;

                    topSideRecWidth = 16;
                    leftSideRecHeight = 16;

                    bottomSideRecWidth = 16;
                    rightSideRecHeight = 16;

                    // Return to State 0
                    alpha = 1.0f;
                    state = 0;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            if (state == 0)
            {
                if ((framesCounter / 15) % 2 != 0)
                {
                    DrawRectangle(logoPositionX, logoPositionY, 16, 16, outline);
                }
            }
            else if (state == 1)
            {
                DrawRectangle(logoPositionX, logoPositionY, topSideRecWidth, 16, outline);
                DrawRectangle(logoPositionX, logoPositionY, 16, leftSideRecHeight, outline);
            }
            else if (state == 2)
            {
                DrawRectangle(logoPositionX, logoPositionY, topSideRecWidth, 16, outline);
                DrawRectangle(logoPositionX, logoPositionY, 16, leftSideRecHeight, outline);

                DrawRectangle(logoPositionX + 240, logoPositionY, 16, rightSideRecHeight, outline);
                DrawRectangle(logoPositionX, logoPositionY + 240, bottomSideRecWidth, 16, outline);
            }
            else if (state == 3)
            {
                Color outlineFade = ColorAlpha(outline, alpha);
                DrawRectangle(logoPositionX, logoPositionY, topSideRecWidth, 16, outlineFade);
                DrawRectangle(logoPositionX, logoPositionY + 16, 16, leftSideRecHeight - 32, outlineFade);

                DrawRectangle(logoPositionX + 240, logoPositionY + 16, 16, rightSideRecHeight - 32, outlineFade);
                DrawRectangle(logoPositionX, logoPositionY + 240, bottomSideRecWidth, 16, outlineFade);

                Color whiteFade = ColorAlpha(Color.RayWhite, alpha);
                DrawRectangle(screenWidth / 2 - 112, screenHeight / 2 - 112, 224, 224, whiteFade);

                Color label = ColorAlpha(new Color(155, 79, 151, 255), alpha);
                string text = "raylib".SubText(0, lettersCount);
                DrawText(text, screenWidth / 2 - 44, screenHeight / 2 + 28, 50, label);

                DrawText("cs".SubText(0, lettersCount), screenWidth / 2 - 44, screenHeight / 2 + 58, 50, label);
            }
            else if (state == 4)
            {
                DrawText("[R] REPLAY", 340, 200, 20, Color.Gray);
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
