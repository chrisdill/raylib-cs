/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*   raylib official webpage: www.raylib.com
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Core;

enum GameScreen
{
    Logo = 0,
    Title,
    Gameplay,
    Ending
}

public class BasicScreenManager
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - basic screen manager");

        GameScreen currentScreen = GameScreen.Logo;

        // TODO: Initialize all required variables and load all required data here!

        // Useful to count frames
        int framesCounter = 0;

        SetTargetFPS(60);               // Set desired framerate (frames-per-second)
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            switch (currentScreen)
            {
                case GameScreen.Logo:
                    {
                        // TODO: Update LOGO screen variables here!

                        // Count frames
                        framesCounter++;

                        // Wait for 2 seconds (120 frames) before jumping to TITLE screen
                        if (framesCounter > 120)
                        {
                            currentScreen = GameScreen.Title;
                        }
                    }
                    break;
                case GameScreen.Title:
                    {
                        // TODO: Update TITLE screen variables here!

                        // Press enter to change to GAMEPLAY screen
                        if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                        {
                            currentScreen = GameScreen.Gameplay;
                        }
                    }
                    break;
                case GameScreen.Gameplay:
                    {
                        // TODO: Update GAMEPLAY screen variables here!

                        // Press enter to change to ENDING screen
                        if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                        {
                            currentScreen = GameScreen.Ending;
                        }
                    }
                    break;
                case GameScreen.Ending:
                    {
                        // TODO: Update ENDING screen variables here!

                        // Press enter to return to TITLE screen
                        if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                        {
                            currentScreen = GameScreen.Title;
                        }
                    }
                    break;
                default:
                    break;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            switch (currentScreen)
            {
                case GameScreen.Logo:
                    {
                        // TODO: Draw LOGO screen here!
                        DrawText("LOGO SCREEN", 20, 20, 40, Color.LightGray);
                        DrawText("WAIT for 2 SECONDS...", 290, 220, 20, Color.Gray);

                    }
                    break;
                case GameScreen.Title:
                    {
                        // TODO: Draw TITLE screen here!
                        DrawRectangle(0, 0, screenWidth, screenHeight, Color.Green);
                        DrawText("TITLE SCREEN", 20, 20, 40, Color.DarkGreen);
                        DrawText("PRESS ENTER or TAP to JUMP to GAMEPLAY SCREEN", 120, 220, 20, Color.DarkGreen);

                    }
                    break;
                case GameScreen.Gameplay:
                    {
                        // TODO: Draw GAMEPLAY screen here!
                        DrawRectangle(0, 0, screenWidth, screenHeight, Color.Purple);
                        DrawText("GAMEPLAY SCREEN", 20, 20, 40, Color.Maroon);
                        DrawText("PRESS ENTER or TAP to JUMP to ENDING SCREEN", 130, 220, 20, Color.Maroon);

                    }
                    break;
                case GameScreen.Ending:
                    {
                        // TODO: Draw ENDING screen here!
                        DrawRectangle(0, 0, screenWidth, screenHeight, Color.Blue);
                        DrawText("ENDING SCREEN", 20, 20, 40, Color.DarkBlue);
                        DrawText("PRESS ENTER or TAP to RETURN to TITLE SCREEN", 120, 220, 20, Color.DarkBlue);

                    }
                    break;
                default:
                    break;
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------

        // TODO: Unload all loaded data (textures, fonts, audio) here!

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
