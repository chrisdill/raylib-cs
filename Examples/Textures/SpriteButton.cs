/*******************************************************************************************
*
*   raylib [textures] example - sprite button
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class SpriteButton
{
    // Number of frames (rectangles) for the button sprite texture
    public const int NumFrames = 3;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - sprite button");

        InitAudioDevice();

        Sound fxButton = LoadSound("resources/audio/buttonfx.wav");
        Texture2D button = LoadTexture("resources/button.png");

        // Define frame rectangle for drawing
        int frameHeight = button.Height / NumFrames;
        Rectangle sourceRec = new(0, 0, button.Width, frameHeight);

        // Define button bounds on screen
        Rectangle btnBounds = new(
            screenWidth / 2 - button.Width / 2,
            screenHeight / 2 - button.Height / NumFrames / 2,
            button.Width,
            frameHeight
        );

        // Button state: 0-NORMAL, 1-MOUSE_HOVER, 2-PRESSED
        int btnState = 0;

        // Button action should be activated
        bool btnAction = false;

        Vector2 mousePoint = new(0.0f, 0.0f);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            mousePoint = GetMousePosition();
            btnAction = false;

            // Check button state
            if (CheckCollisionPointRec(mousePoint, btnBounds))
            {
                if (IsMouseButtonDown(MouseButton.Left))
                {
                    btnState = 2;
                }
                else
                {
                    btnState = 1;
                }

                if (IsMouseButtonReleased(MouseButton.Left))
                {
                    btnAction = true;
                }
            }
            else
            {
                btnState = 0;
            }

            if (btnAction)
            {
                PlaySound(fxButton);
                // TODO: Any desired action
            }

            // Calculate button frame rectangle to draw depending on button state
            sourceRec.Y = btnState * frameHeight;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            // Draw button frame
            DrawTextureRec(button, sourceRec, new Vector2(btnBounds.X, btnBounds.Y), Color.White);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(button);
        UnloadSound(fxButton);

        CloseAudioDevice();
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
