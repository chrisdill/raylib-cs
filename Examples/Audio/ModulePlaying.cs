/*******************************************************************************************
*
*   raylib [audio] example - Module playing (streaming)
*
*   NOTE: This example requires OpenAL Soft library installed
*
*   This example has been created using raylib 1.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Audio;

public class ModulePlaying
{
    const int MaxCircles = 64;

    struct CircleWave
    {
        public Vector2 Position;
        public float Radius;
        public float Alpha;
        public float Speed;
        public Color Color;
    }

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);      // NOTE: Try to enable MSAA 4X

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - module playing (streaming)");

        InitAudioDevice();

        Color[] colors = new Color[14] {
            Color.ORANGE,
            Color.RED,
            Color.GOLD,
            Color.LIME,
            Color.BLUE,
            Color.VIOLET,
            Color.BROWN,
            Color.LIGHTGRAY,
            Color.PINK,
            Color.YELLOW,
            Color.GREEN,
            Color.SKYBLUE,
            Color.PURPLE,
            Color.BEIGE
        };

        // Creates ome circles for visual effect
        CircleWave[] circles = new CircleWave[MaxCircles];

        for (int i = MaxCircles - 1; i >= 0; i--)
        {
            circles[i].Alpha = 0.0f;
            circles[i].Radius = GetRandomValue(10, 40);
            circles[i].Position.X = GetRandomValue((int)circles[i].Radius, screenWidth - (int)circles[i].Radius);
            circles[i].Position.Y = GetRandomValue((int)circles[i].Radius, screenHeight - (int)circles[i].Radius);
            circles[i].Speed = (float)GetRandomValue(1, 100) / 20000.0f;
            circles[i].Color = colors[GetRandomValue(0, 13)];
        }

        Music music = LoadMusicStream("resources/audio/mini1111.xm");
        music.Looping = false;
        float pitch = 1.0f;

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

            if (IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                pitch -= 0.01f;
            }
            else if (IsKeyDown(KeyboardKey.KEY_UP))
            {
                pitch += 0.01f;
            }

            SetMusicPitch(music, pitch);

            // Get timePlayed scaled to bar dimensions
            timePlayed = GetMusicTimePlayed(music) / GetMusicTimeLength(music) * (screenWidth - 40);

            // Color circles animation
            for (int i = MaxCircles - 1; (i >= 0) && !pause; i--)
            {
                circles[i].Alpha += circles[i].Speed;
                circles[i].Radius += circles[i].Speed * 10.0f;

                if (circles[i].Alpha > 1.0f)
                {
                    circles[i].Speed *= -1;
                }

                if (circles[i].Alpha <= 0.0f)
                {
                    circles[i].Alpha = 0.0f;
                    circles[i].Radius = GetRandomValue(10, 40);
                    circles[i].Position.X = GetRandomValue(
                        (int)circles[i].Radius,
                        screenWidth - (int)circles[i].Radius
                    );
                    circles[i].Position.Y = GetRandomValue(
                        (int)circles[i].Radius,
                        screenHeight - (int)circles[i].Radius
                    );
                    circles[i].Color = colors[GetRandomValue(0, 13)];
                    circles[i].Speed = (float)GetRandomValue(1, 100) / 2000.0f;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            for (int i = MaxCircles - 1; i >= 0; i--)
            {
                DrawCircleV(
                    circles[i].Position,
                    circles[i].Radius,
                    ColorAlpha(circles[i].Color, circles[i].Alpha)
                );
            }

            // Draw time bar
            DrawRectangle(20, screenHeight - 20 - 12, screenWidth - 40, 12, Color.LIGHTGRAY);
            DrawRectangle(20, screenHeight - 20 - 12, (int)timePlayed, 12, Color.MAROON);
            DrawRectangleLines(20, screenHeight - 20 - 12, screenWidth - 40, 12, Color.GRAY);

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
