/*******************************************************************************************
*
*   raylib [audio] example - IntPtr playing (streaming)
*
*   NOTE: This example requires OpenAL Soft library installed
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Audio;

public class MusicStreamDemo
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - music playing (streaming)");
        InitAudioDevice();

        Music music = LoadMusicStream("resources/audio/country.mp3");
        PlayMusicStream(music);

        float timePlayed = 0.0f;
        bool pause = false;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateMusicStream(music);        // Update music buffer with new stream data

            // Restart music playing (stop and play)
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                StopMusicStream(music);
                PlayMusicStream(music);
            }

            // Pause/Resume music playing
            if (IsKeyPressed(KeyboardKey.KEY_P))
            {
                pause = !pause;

                if (pause)
                {
                    PauseMusicStream(music);
                }
                else
                {
                    ResumeMusicStream(music);
                }
            }

            // Get timePlayed scaled to bar dimensions (400 pixels)
            timePlayed = GetMusicTimePlayed(music) / GetMusicTimeLength(music) * 400;

            if (timePlayed > 400)
            {
                StopMusicStream(music);
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            DrawText("MUSIC SHOULD BE PLAYING!", 255, 150, 20, Color.LIGHTGRAY);

            DrawRectangle(200, 200, 400, 12, Color.LIGHTGRAY);
            DrawRectangle(200, 200, (int)timePlayed, 12, Color.MAROON);
            DrawRectangleLines(200, 200, 400, 12, Color.GRAY);

            DrawText("PRESS SPACE TO RESTART MUSIC", 215, 250, 20, Color.LIGHTGRAY);
            DrawText("PRESS P TO PAUSE/RESUME MUSIC", 208, 280, 20, Color.LIGHTGRAY);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadMusicStream(music);

        CloseAudioDevice();

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
