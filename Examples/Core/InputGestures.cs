/*******************************************************************************************
*
*   raylib [core] example - Gestures Detection
*
*   This example has been created using raylib 1.4 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Core;

public class InputGestures
{
    public const int MaxGestureStrings = 20;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - gestures detection");

        Vector2 touchPosition = new(0, 0);
        Rectangle touchArea = new(220, 10, screenWidth - 230, screenHeight - 20);

        int gesturesCount = 0;
        string[] gestureStrings = new string[MaxGestureStrings];

        Gesture currentGesture = Gesture.GESTURE_NONE;
        Gesture lastGesture = Gesture.GESTURE_NONE;

        // SetGesturesEnabled(0b0000000000001001);   // Enable only some gestures to be detected

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            lastGesture = currentGesture;
            currentGesture = GetGestureDetected();
            touchPosition = GetTouchPosition(0);

            if (CheckCollisionPointRec(touchPosition, touchArea) && (currentGesture != Gesture.GESTURE_NONE))
            {
                if (currentGesture != lastGesture)
                {
                    // Store gesture string
                    switch ((Gesture)currentGesture)
                    {
                        case Gesture.GESTURE_TAP:
                            gestureStrings[gesturesCount] = "GESTURE TAP";
                            break;
                        case Gesture.GESTURE_DOUBLETAP:
                            gestureStrings[gesturesCount] = "GESTURE DOUBLETAP";
                            break;
                        case Gesture.GESTURE_HOLD:
                            gestureStrings[gesturesCount] = "GESTURE HOLD";
                            break;
                        case Gesture.GESTURE_DRAG:
                            gestureStrings[gesturesCount] = "GESTURE DRAG";
                            break;
                        case Gesture.GESTURE_SWIPE_RIGHT:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE RIGHT";
                            break;
                        case Gesture.GESTURE_SWIPE_LEFT:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE LEFT";
                            break;
                        case Gesture.GESTURE_SWIPE_UP:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE UP";
                            break;
                        case Gesture.GESTURE_SWIPE_DOWN:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE DOWN";
                            break;
                        case Gesture.GESTURE_PINCH_IN:
                            gestureStrings[gesturesCount] = "GESTURE PINCH IN";
                            break;
                        case Gesture.GESTURE_PINCH_OUT:
                            gestureStrings[gesturesCount] = "GESTURE PINCH OUT";
                            break;
                        default:
                            break;
                    }

                    gesturesCount++;

                    // Reset gestures strings
                    if (gesturesCount >= MaxGestureStrings)
                    {
                        for (int i = 0; i < MaxGestureStrings; i++)
                        {
                            gestureStrings[i] = " ";
                        }
                        gesturesCount = 0;
                    }
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            DrawRectangleRec(touchArea, Color.GRAY);
            DrawRectangle(225, 15, screenWidth - 240, screenHeight - 30, Color.RAYWHITE);

            DrawText("GESTURES TEST AREA", screenWidth - 270, screenHeight - 40, 20, ColorAlpha(Color.GRAY, 0.5f));

            for (int i = 0; i < gesturesCount; i++)
            {
                if (i % 2 == 0)
                {
                    DrawRectangle(10, 30 + 20 * i, 200, 20, ColorAlpha(Color.LIGHTGRAY, 0.5f));
                }
                else
                {
                    DrawRectangle(10, 30 + 20 * i, 200, 20, ColorAlpha(Color.LIGHTGRAY, 0.3f));
                }

                if (i < gesturesCount - 1)
                {
                    DrawText(gestureStrings[i], 35, 36 + 20 * i, 10, Color.DARKGRAY);
                }
                else
                {
                    DrawText(gestureStrings[i], 35, 36 + 20 * i, 10, Color.MAROON);
                }
            }

            DrawRectangleLines(10, 29, 200, screenHeight - 50, Color.GRAY);
            DrawText("DETECTED GESTURES", 50, 15, 10, Color.GRAY);

            if (currentGesture != Gesture.GESTURE_NONE)
            {
                DrawCircleV(touchPosition, 30, Color.MAROON);
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
