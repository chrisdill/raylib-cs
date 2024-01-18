/*******************************************************************************************
*
*   raylib [core] example - window flags
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2020 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.ConfigFlags;

namespace Examples.Core;

public class WindowFlags
{
    public static int Main()
    {
        // Initialization
        //---------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Possible window flags
        /*
        FLAG_VSYNC_HINT
        FLAG_FULLSCREEN_MODE    -> not working properly -> wrong scaling!
        FLAG_WINDOW_RESIZABLE
        FLAG_WINDOW_UNDECORATED
        FLAG_WINDOW_TRANSPARENT
        FLAG_WINDOW_HIDDEN
        FLAG_WINDOW_MINIMIZED   -> Not supported on window creation
        FLAG_WINDOW_MAXIMIZED   -> Not supported on window creation
        FLAG_WINDOW_UNFOCUSED
        FLAG_WINDOW_TOPMOST
        FLAG_WINDOW_HIGHDPI     -> errors after minimize-resize, fb size is recalculated
        FLAG_WINDOW_ALWAYS_RUN
        FLAG_MSAA_4X_HINT
        */

        // Set configuration flags for window creation
        SetConfigFlags(VSyncHint | Msaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - window flags");

        Vector2 ballPosition = new(GetScreenWidth() / 2, GetScreenHeight() / 2);
        Vector2 ballSpeed = new(5.0f, 4.0f);
        int ballRadius = 20;

        int framesCounter = 0;
        //----------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //-----------------------------------------------------
            if (IsKeyPressed(KeyboardKey.F))
            {
                // modifies window size when scaling!
                ToggleFullscreen();
            }

            if (IsKeyPressed(KeyboardKey.R))
            {
                if (IsWindowState(ResizableWindow))
                {
                    ClearWindowState(ResizableWindow);
                }
                else
                {
                    SetWindowState(ResizableWindow);
                }
            }

            if (IsKeyPressed(KeyboardKey.D))
            {
                if (IsWindowState(UndecoratedWindow))
                {
                    ClearWindowState(UndecoratedWindow);
                }
                else
                {
                    SetWindowState(UndecoratedWindow);
                }
            }

            if (IsKeyPressed(KeyboardKey.H))
            {
                if (!IsWindowState(HiddenWindow))
                {
                    SetWindowState(HiddenWindow);
                }

                framesCounter = 0;
            }

            if (IsWindowState(HiddenWindow))
            {
                framesCounter++;
                if (framesCounter >= 240)
                {
                    // Show window after 3 seconds
                    ClearWindowState(HiddenWindow);
                }
            }

            if (IsKeyPressed(KeyboardKey.N))
            {
                if (!IsWindowState(MinimizedWindow))
                {
                    MinimizeWindow();
                }

                framesCounter = 0;
            }

            if (IsWindowState(MinimizedWindow))
            {
                framesCounter++;
                if (framesCounter >= 240)
                {
                    // Restore window after 3 seconds
                    RestoreWindow();
                }
            }

            if (IsKeyPressed(KeyboardKey.M))
            {
                // NOTE: Requires FLAG_WINDOW_RESIZABLE enabled!
                if (IsWindowState(MaximizedWindow))
                {
                    RestoreWindow();
                }
                else
                {
                    MaximizeWindow();
                }
            }

            if (IsKeyPressed(KeyboardKey.U))
            {
                if (IsWindowState(UnfocusedWindow))
                {
                    ClearWindowState(UnfocusedWindow);
                }
                else
                {
                    SetWindowState(UnfocusedWindow);
                }
            }

            if (IsKeyPressed(KeyboardKey.T))
            {
                if (IsWindowState(TopmostWindow))
                {
                    ClearWindowState(TopmostWindow);
                }
                else
                {
                    SetWindowState(TopmostWindow);
                }
            }

            if (IsKeyPressed(KeyboardKey.A))
            {
                if (IsWindowState(AlwaysRunWindow))
                {
                    ClearWindowState(AlwaysRunWindow);
                }
                else
                {
                    SetWindowState(AlwaysRunWindow);
                }
            }

            if (IsKeyPressed(KeyboardKey.V))
            {
                if (IsWindowState(VSyncHint))
                {
                    ClearWindowState(VSyncHint);
                }
                else
                {
                    SetWindowState(VSyncHint);
                }
            }

            // Bouncing ball logic
            ballPosition.X += ballSpeed.X;
            ballPosition.Y += ballSpeed.Y;
            if ((ballPosition.X >= (GetScreenWidth() - ballRadius)) || (ballPosition.X <= ballRadius))
            {
                ballSpeed.X *= -1.0f;
            }
            if ((ballPosition.Y >= (GetScreenHeight() - ballRadius)) || (ballPosition.Y <= ballRadius))
            {
                ballSpeed.Y *= -1.0f;
            }
            //-----------------------------------------------------

            // Draw
            //-----------------------------------------------------
            BeginDrawing();

            if (IsWindowState(TransparentWindow))
            {
                ClearBackground(Color.Blank);
            }
            else
            {
                ClearBackground(Color.RayWhite);
            }

            DrawCircleV(ballPosition, ballRadius, Color.Maroon);
            DrawRectangleLinesEx(new Rectangle(0, 0, GetScreenWidth(), GetScreenHeight()), 4, Color.RayWhite);

            DrawCircleV(GetMousePosition(), 10, Color.DarkBlue);

            DrawFPS(10, 10);

            DrawText($"Screen Size: [{GetScreenWidth()}, {GetScreenHeight()}]", 10, 40, 10, Color.Green);

            // Draw window state info
            Color on = Color.Lime;
            Color off = Color.Maroon;

            DrawText("Following flags can be set after window creation:", 10, 60, 10, Color.Gray);

            DrawWindowState(FullscreenMode, "[F] FLAG_FULLSCREEN_MODE: ", 10, 80, 10);
            DrawWindowState(ResizableWindow, "[R] FLAG_WINDOW_RESIZABLE: ", 10, 100, 10);
            DrawWindowState(UndecoratedWindow, "[D] FLAG_WINDOW_UNDECORATED: ", 10, 120, 10);
            DrawWindowState(HiddenWindow, "[H] FLAG_WINDOW_HIDDEN: ", 10, 140, 10);
            DrawWindowState(MinimizedWindow, "[N] FLAG_WINDOW_MINIMIZED: ", 10, 160, 10);
            DrawWindowState(MaximizedWindow, "[M] FLAG_WINDOW_MAXIMIZED: ", 10, 180, 10);
            DrawWindowState(UnfocusedWindow, "[G] FLAG_WINDOW_UNFOCUSED: ", 10, 200, 10);
            DrawWindowState(TopmostWindow, "[T] FLAG_WINDOW_TOPMOST: ", 10, 220, 10);
            DrawWindowState(AlwaysRunWindow, "[A] FLAG_WINDOW_ALWAYS_RUN: ", 10, 240, 10);
            DrawWindowState(VSyncHint, "[V] FLAG_VSYNC_HINT: ", 10, 260, 10);

            DrawText("Following flags can only be set before window creation:", 10, 300, 10, Color.Gray);

            DrawWindowState(HighDpiWindow, "[F] FLAG_WINDOW_HIGHDPI: ", 10, 320, 10);
            DrawWindowState(TransparentWindow, "[F] FLAG_WINDOW_TRANSPARENT: ", 10, 340, 10);
            DrawWindowState(Msaa4xHint, "[F] FLAG_MSAA_4X_HINT: ", 10, 360, 10);

            EndDrawing();
            //-----------------------------------------------------
        }

        // De-Initialization
        //---------------------------------------------------------
        CloseWindow();
        //----------------------------------------------------------

        return 0;
    }

    static void DrawWindowState(ConfigFlags flag, string text, int posX, int posY, int fontSize)
    {
        Color onColor = Color.Lime;
        Color offColor = Color.Maroon;

        if (Raylib.IsWindowState(flag))
        {
            DrawText($"{text} on", posX, posY, fontSize, onColor);
        }
        else
        {
            DrawText($"{text} off", posX, posY, fontSize, offColor);
        }
    }
}

