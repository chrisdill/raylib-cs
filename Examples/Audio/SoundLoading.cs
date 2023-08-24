/*******************************************************************************************
*
*   raylib [audio] example - Sound loading and playing
*
*   NOTE: This example requires OpenAL Soft library installed
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Audio;

public class SoundLoading
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - sound loading and playing");
        InitAudioDevice();

        Sound fxWav = LoadSound("resources/audio/sound.wav");
        Sound fxOgg = LoadSound("resources/audio/target.ogg");

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                PlaySound(fxWav);
            }

            if (IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                PlaySound(fxOgg);
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            DrawText("Press SPACE to PLAY the WAV sound!", 200, 180, 20, Color.LIGHTGRAY);
            DrawText("Press ENTER to PLAY the OGG sound!", 200, 220, 20, Color.LIGHTGRAY);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadSound(fxWav);
        UnloadSound(fxOgg);

        CloseAudioDevice();

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
