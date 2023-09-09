/*******************************************************************************************
*
*   raylib [core] example - Gamepad input
*
*   NOTE: This example requires a Gamepad connected to the system
*         raylib is configured to work with the following gamepads:
*                - Xbox 360 Controller (Xbox 360, Xbox One)
*                - PLAYSTATION(R)3 Controller
*         Check raylib.h for buttons configuration
*
*   This example has been created using raylib 1.6 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Examples.Core;

public class InputGamepad
{
    // NOTE: Gamepad name ID depends on drivers and OS
    // These are some possible names the gamepads could have.
    public const string XBOX360_LEGACY_NAME_ID = "Xbox Controller";
    public const string XBOX360_NAME_ID = "Xbox 360 Controller";
    public const string XBOX360_NAME_ID_RPI = "Microsoft X-Box 360 pad";
    public const string PS3_NAME_ID = "PLAYSTATION(R)3 Controller";

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Set MSAA 4X hint before windows creation
        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - gamepad input");

        Texture2D texPs3Pad = LoadTexture("resources/ps3.png");
        Texture2D texXboxPad = LoadTexture("resources/xbox.png");

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // ...
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            if (IsGamepadAvailable(0))
            {
                string gamepadName = GetGamepadName_(0);
                DrawText($"GP1: {gamepadName}", 10, 10, 10, Color.BLACK);

                if (gamepadName == XBOX360_LEGACY_NAME_ID ||
                    gamepadName == XBOX360_NAME_ID ||
                    gamepadName == XBOX360_NAME_ID_RPI)
                {
                    DrawTexture(texXboxPad, 0, 0, Color.DARKGRAY);

                    // Draw buttons: xbox home
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_MIDDLE))
                    {
                        DrawCircle(394, 89, 19, Color.RED);
                    }

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_MIDDLE_RIGHT))
                    {
                        DrawCircle(436, 150, 9, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_MIDDLE_LEFT))
                    {
                        DrawCircle(352, 150, 9, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_LEFT))
                    {
                        DrawCircle(501, 151, 15, Color.BLUE);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_DOWN))
                    {
                        DrawCircle(536, 187, 15, Color.LIME);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_RIGHT))
                    {
                        DrawCircle(572, 151, 15, Color.MAROON);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_UP))
                    {
                        DrawCircle(536, 115, 15, Color.GOLD);
                    }

                    // Draw buttons: d-pad
                    DrawRectangle(317, 202, 19, 71, Color.BLACK);
                    DrawRectangle(293, 228, 69, 19, Color.BLACK);
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_UP))
                    {
                        DrawRectangle(317, 202, 19, 26, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_DOWN))
                    {
                        DrawRectangle(317, 202 + 45, 19, 26, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_LEFT))
                    {
                        DrawRectangle(292, 228, 25, 19, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_RIGHT))
                    {
                        DrawRectangle(292 + 44, 228, 26, 19, Color.RED);
                    }

                    // Draw buttons: left-right back
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_1))
                    {
                        DrawCircle(259, 61, 20, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_1))
                    {
                        DrawCircle(536, 61, 20, Color.RED);
                    }

                    // Draw axis: left joystick
                    DrawCircle(259, 152, 39, Color.BLACK);
                    DrawCircle(259, 152, 34, Color.LIGHTGRAY);
                    DrawCircle(
                        259 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_LEFT_X) * 20),
                        152 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_LEFT_Y) * 20),
                        25,
                        Color.BLACK
                    );

                    // Draw axis: right joystick
                    DrawCircle(461, 237, 38, Color.BLACK);
                    DrawCircle(461, 237, 33, Color.LIGHTGRAY);
                    DrawCircle(
                        461 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_RIGHT_X) * 20),
                        237 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_RIGHT_Y) * 20),
                        25, Color.BLACK
                    );

                    // Draw axis: left-right triggers
                    float leftTriggerX = GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_LEFT_TRIGGER);
                    float rightTriggerX = GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_RIGHT_TRIGGER);
                    DrawRectangle(170, 30, 15, 70, Color.GRAY);
                    DrawRectangle(604, 30, 15, 70, Color.GRAY);
                    DrawRectangle(170, 30, 15, (int)(((1.0f + leftTriggerX) / 2.0f) * 70), Color.RED);
                    DrawRectangle(604, 30, 15, (int)(((1.0f + rightTriggerX) / 2.0f) * 70), Color.RED);
                }
                else if (gamepadName == PS3_NAME_ID)
                {
                    DrawTexture(texPs3Pad, 0, 0, Color.DARKGRAY);

                    // Draw buttons: ps
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_MIDDLE))
                    {
                        DrawCircle(396, 222, 13, Color.RED);
                    }

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_MIDDLE_LEFT))
                    {
                        DrawRectangle(328, 170, 32, 13, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_MIDDLE_RIGHT))
                    {
                        DrawTriangle(
                            new Vector2(436, 168),
                            new Vector2(436, 185),
                            new Vector2(464, 177),
                            Color.RED
                        );
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_UP))
                    {
                        DrawCircle(557, 144, 13, Color.LIME);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_RIGHT))
                    {
                        DrawCircle(586, 173, 13, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_DOWN))
                    {
                        DrawCircle(557, 203, 13, Color.VIOLET);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_LEFT))
                    {
                        DrawCircle(527, 173, 13, Color.PINK);
                    }

                    // Draw buttons: d-pad
                    DrawRectangle(225, 132, 24, 84, Color.BLACK);
                    DrawRectangle(195, 161, 84, 25, Color.BLACK);
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_UP))
                    {
                        DrawRectangle(225, 132, 24, 29, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_DOWN))
                    {
                        DrawRectangle(225, 132 + 54, 24, 30, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_LEFT))
                    {
                        DrawRectangle(195, 161, 30, 25, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_RIGHT))
                    {
                        DrawRectangle(195 + 54, 161, 30, 25, Color.RED);
                    }

                    // Draw buttons: left-right back buttons
                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_1))
                    {
                        DrawCircle(239, 82, 20, Color.RED);
                    }

                    if (IsGamepadButtonDown(0, GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_1))
                    {
                        DrawCircle(557, 82, 20, Color.RED);
                    }

                    // Draw axis: left joystick
                    DrawCircle(319, 255, 35, Color.BLACK);
                    DrawCircle(319, 255, 31, Color.LIGHTGRAY);
                    DrawCircle(
                        319 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_LEFT_X) * 20),
                        255 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_LEFT_Y) * 20),
                        25,
                        Color.BLACK
                    );

                    // Draw axis: right joystick
                    DrawCircle(475, 255, 35, Color.BLACK);
                    DrawCircle(475, 255, 31, Color.LIGHTGRAY);
                    DrawCircle(
                        475 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_RIGHT_X) * 20),
                        255 + (int)(GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_RIGHT_Y) * 20),
                        25,
                        Color.BLACK
                    );

                    // Draw axis: left-right triggers
                    float leftTriggerX = GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_LEFT_TRIGGER);
                    float rightTriggerX = GetGamepadAxisMovement(0, GamepadAxis.GAMEPAD_AXIS_RIGHT_TRIGGER);
                    DrawRectangle(169, 48, 15, 70, Color.GRAY);
                    DrawRectangle(611, 48, 15, 70, Color.GRAY);
                    DrawRectangle(169, 48, 15, (int)(((1.0f - leftTriggerX) / 2.0f) * 70), Color.RED);
                    DrawRectangle(611, 48, 15, (int)(((1.0f - rightTriggerX) / 2.0f) * 70), Color.RED);
                }
                else
                {
                    DrawText("- GENERIC GAMEPAD -", 280, 180, 20, Color.GRAY);
                    // TODO: Draw generic gamepad
                }

                DrawText($"DETECTED AXIS [{GetGamepadAxisCount(0)}]:", 10, 50, 10, Color.MAROON);

                for (int i = 0; i < GetGamepadAxisCount(0); i++)
                {
                    DrawText(
                        $"AXIS {i}: {GetGamepadAxisMovement(0, (GamepadAxis)i)}",
                        20,
                        70 + 20 * i,
                        10,
                        Color.DARKGRAY
                    );
                }

                if (GetGamepadButtonPressed() != (int)GamepadButton.GAMEPAD_BUTTON_UNKNOWN)
                {
                    DrawText($"DETECTED BUTTON: {GetGamepadButtonPressed()}", 10, 430, 10, Color.RED);
                }
                else
                {
                    DrawText("DETECTED BUTTON: NONE", 10, 430, 10, Color.GRAY);
                }
            }
            else
            {
                DrawText("GP1: NOT DETECTED", 10, 10, 10, Color.GRAY);
                DrawTexture(texXboxPad, 0, 0, Color.LIGHTGRAY);
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texPs3Pad);
        UnloadTexture(texXboxPad);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
