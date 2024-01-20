/*******************************************************************************************
*
*   raylib example - particles blending
*
*   This example has been created using raylib 1.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class ParticlesBlending
{
    public const int MaxParticles = 200;

    // Particle structure with basic data
    struct Particle
    {
        public Vector2 Position;
        public Color Color;
        public float Alpha;
        public float Size;
        public float Rotation;
        // NOTE: Use it to activate/deactive particle
        public bool Active;
    }

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - particles blending");

        // Particles pool, reuse them!
        Particle[] mouseTail = new Particle[MaxParticles];

        // Initialize particles
        for (int i = 0; i < mouseTail.Length; i++)
        {
            mouseTail[i].Position = new Vector2(0, 0);
            mouseTail[i].Color = new Color(
                GetRandomValue(0, 255),
                GetRandomValue(0, 255),
                GetRandomValue(0, 255),
                255
            );
            mouseTail[i].Alpha = 1.0f;
            mouseTail[i].Size = (float)GetRandomValue(1, 30) / 20.0f;
            mouseTail[i].Rotation = GetRandomValue(0, 360);
            mouseTail[i].Active = false;
        }

        float gravity = 3.0f;
        Texture2D smoke = LoadTexture("resources/spark_flame.png");
        BlendMode blending = BlendMode.Alpha;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------

            // Activate one particle every frame and Update active particles
            // NOTE: Particles initial position should be mouse position when activated
            // NOTE: Particles fall down with gravity and rotation... and disappear after 2 seconds (alpha = 0)
            // NOTE: When a particle disappears, active = false and it can be reused.
            for (int i = 0; i < mouseTail.Length; i++)
            {
                if (!mouseTail[i].Active)
                {
                    mouseTail[i].Active = true;
                    mouseTail[i].Alpha = 1.0f;
                    mouseTail[i].Position = GetMousePosition();
                    i = mouseTail.Length;
                }
            }

            for (int i = 0; i < mouseTail.Length; i++)
            {
                if (mouseTail[i].Active)
                {
                    mouseTail[i].Position.Y += gravity / 2;
                    mouseTail[i].Alpha -= 0.005f;

                    if (mouseTail[i].Alpha <= 0.0f)
                    {
                        mouseTail[i].Active = false;
                    }

                    mouseTail[i].Rotation += 2.0f;
                }
            }

            if (IsKeyPressed(KeyboardKey.Space))
            {
                if (blending == BlendMode.Alpha)
                {
                    blending = BlendMode.Additive;
                }
                else
                {
                    blending = BlendMode.Alpha;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.DarkGray);

            BeginBlendMode(blending);

            // Draw active particles
            for (int i = 0; i < mouseTail.Length; i++)
            {
                if (mouseTail[i].Active)
                {
                    Rectangle source = new(0, 0, smoke.Width, smoke.Height);
                    Rectangle dest = new(
                        mouseTail[i].Position.X,
                        mouseTail[i].Position.Y,
                        smoke.Width * mouseTail[i].Size,
                        smoke.Height * mouseTail[i].Size
                    );
                    Vector2 position = new(
                        smoke.Width * mouseTail[i].Size / 2,
                        smoke.Height * mouseTail[i].Size / 2
                    );
                    Color color = ColorAlpha(mouseTail[i].Color, mouseTail[i].Alpha);
                    DrawTexturePro(smoke, source, dest, position, mouseTail[i].Rotation, color);
                }
            }

            EndBlendMode();

            DrawText("PRESS SPACE to CHANGE BLENDING MODE", 180, 20, 20, Color.Black);

            if (blending == BlendMode.Alpha)
            {
                DrawText("ALPHA BLENDING", 290, screenHeight - 40, 20, Color.Black);
            }
            else
            {
                DrawText("ADDITIVE BLENDING", 280, screenHeight - 40, 20, Color.RayWhite);
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(smoke);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
