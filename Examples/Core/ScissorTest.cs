/*******************************************************************************************
*
*   raylib [core] example - Scissor test
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Dill (@MysteriousSpace) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Chris Dill (@MysteriousSpace)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Core;

public class ScissorTest
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - scissor test");

        Rectangle scissorArea = new(0, 0, 300, 300);
        bool scissorMode = true;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.S))
            {
                scissorMode = !scissorMode;
            }

            // Centre the scissor area around the mouse position
            scissorArea.X = GetMouseX() - scissorArea.Width / 2;
            scissorArea.Y = GetMouseY() - scissorArea.Height / 2;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            if (scissorMode)
            {
                BeginScissorMode((int)scissorArea.X, (int)scissorArea.Y, (int)scissorArea.Width, (int)scissorArea.Height);
            }

            // Draw full screen rectangle and some text
            // NOTE: Only part defined by scissor area will be rendered
            DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Color.Red);
            DrawText("Move the mouse around to reveal this text!", 190, 200, 20, Color.LightGray);

            if (scissorMode)
            {
                EndScissorMode();
            }

            DrawRectangleLinesEx(scissorArea, 1, Color.Black);
            DrawText("Press S to toggle scissor test", 10, 10, 20, Color.Black);

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
