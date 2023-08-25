/*******************************************************************************************
*
*   raylib example - loading thread
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Threading;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.KeyboardKey;

namespace Examples.Core;

enum State
{
    STATE_WAITING,
    STATE_LOADING,
    STATE_FINISHED
}

public class LoadingThread
{
    // C# bool is atomic. Used for synchronization
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/variables#atomicity-of-variable-references
    // Data Loaded completion indicator
    static bool dataLoaded = false;

    // Data progress accumulator
    static int dataProgress = 0;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - loading thread");

        // Loading data thread id
        Thread thread = new(new ThreadStart(LoadDataThread));

        State state = State.STATE_WAITING;
        int framesCounter = 0;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            switch (state)
            {
                case State.STATE_WAITING:
                    {
                        if (IsKeyPressed(KEY_ENTER))
                        {
                            thread.Start();
                            //int error = pthread_create(ref, NULL, ref, NULL);
                            //if (error != 0) TraceLog(TraceLogLevel.LOG_ERROR, "Error creating loading thread");
                            //else TraceLog(TraceLogLevel.LOG_INFO, "Loading thread initialized successfully");

                            state = State.STATE_LOADING;
                        }
                    }
                    break;
                case State.STATE_LOADING:
                    {
                        framesCounter++;
                        if (dataLoaded)
                        {
                            framesCounter = 0;
                            state = State.STATE_FINISHED;
                        }
                    }
                    break;
                case State.STATE_FINISHED:
                    {
                        if (IsKeyPressed(KEY_ENTER))
                        {
                            // Reset everything to launch again
                            // atomic_store(ref, false);
                            dataProgress = 0;
                            state = State.STATE_WAITING;
                        }
                    }
                    break;
                default: break;
            }

            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(RAYWHITE);

            switch (state)
            {
                case State.STATE_WAITING:
                    DrawText("PRESS ENTER to START LOADING DATA", 150, 170, 20, DARKGRAY);
                    break;
                case State.STATE_LOADING:
                    {
                        DrawRectangle(150, 200, dataProgress, 60, SKYBLUE);
                        if ((framesCounter / 15) % 2 == 0) DrawText("LOADING DATA...", 240, 210, 40, DARKBLUE);
                    }
                    break;
                case State.STATE_FINISHED:
                    {
                        DrawRectangle(150, 200, 500, 60, LIME);
                        DrawText("DATA LOADED!", 250, 210, 40, GREEN);
                    }
                    break;
                default: break;
            }

            DrawRectangleLines(150, 200, 500, 60, DARKGRAY);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

        return 0;
    }

    // Loading data thread function definition
    static void LoadDataThread()
    {
        int timeCounter = 0;               // Time counted in ms
                                           // clock_t prevTime = clock();     // Previous time

        // We simulate data loading with a time counter for 5 seconds
        while (timeCounter < 5000)
        {
            //clock_t currentTime = clock() - prevTime;
            //timeCounter = currentTime*1000/CLOCKS_PER_SEC;
            timeCounter += 1;

            // We accumulate time over a global variable to be used in
            // main thread as a progress bar
            dataProgress = timeCounter / 10;
        }

        // When data has finished loading, we set global variable
        dataLoaded = true;
    }
}

