/*******************************************************************************************
*
*   raylib [shapes] example - collision area
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Shapes;

public class CollisionArea
{
    public static int Main()
    {
        // Initialization
        //---------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - collision area");

        // Box A: Moving box
        Rectangle boxA = new(10, GetScreenHeight() / 2 - 50, 200, 100);
        int boxASpeedX = 4;

        // Box B: Mouse moved box
        Rectangle boxB = new(GetScreenWidth() / 2 - 30, GetScreenHeight() / 2 - 30, 60, 60);
        Rectangle boxCollision = new();

        int screenUpperLimit = 40;

        // Movement pause
        bool pause = false;
        bool collision = false;

        SetTargetFPS(60);
        //----------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //-----------------------------------------------------
            // Move box if not paused
            if (!pause)
            {
                boxA.X += boxASpeedX;
            }

            // Bounce box on x screen limits
            if (((boxA.X + boxA.Width) >= GetScreenWidth()) || (boxA.X <= 0))
            {
                boxASpeedX *= -1;
            }

            // Update player-controlled-box (box02)
            boxB.X = GetMouseX() - boxB.Width / 2;
            boxB.Y = GetMouseY() - boxB.Height / 2;

            // Make sure Box B does not go out of move area limits
            if ((boxB.X + boxB.Width) >= GetScreenWidth())
            {
                boxB.X = GetScreenWidth() - boxB.Width;
            }
            else if (boxB.X <= 0)
            {
                boxB.X = 0;
            }

            if ((boxB.Y + boxB.Height) >= GetScreenHeight())
            {
                boxB.Y = GetScreenHeight() - boxB.Height;
            }
            else if (boxB.Y <= screenUpperLimit)
            {
                boxB.Y = screenUpperLimit;
            }

            // Check boxes collision
            collision = CheckCollisionRecs(boxA, boxB);

            // Get collision rectangle (only on collision)
            if (collision)
            {
                boxCollision = GetCollisionRec(boxA, boxB);
            }

            // Pause Box A movement
            if (IsKeyPressed(KeyboardKey.Space))
            {
                pause = !pause;
            }
            //-----------------------------------------------------

            // Draw
            //-----------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawRectangle(0, 0, screenWidth, screenUpperLimit, collision ? Color.Red : Color.Black);

            DrawRectangleRec(boxA, Color.Gold);
            DrawRectangleRec(boxB, Color.Blue);

            if (collision)
            {
                // Draw collision area
                DrawRectangleRec(boxCollision, Color.Lime);

                // Draw collision message
                int cx = GetScreenWidth() / 2 - MeasureText("COLLISION!", 20) / 2;
                int cy = screenUpperLimit / 2 - 10;
                DrawText("COLLISION!", cx, cy, 20, Color.Black);

                // Draw collision area
                string text = $"Collision Area: {(int)boxCollision.Width * (int)boxCollision.Height}";
                DrawText(text, GetScreenWidth() / 2 - 100, screenUpperLimit + 10, 20, Color.Black);
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
