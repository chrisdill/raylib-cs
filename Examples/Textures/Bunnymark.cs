/*******************************************************************************************
*
*   raylib [textures] example - Bunnymark
*
*   This example has been created using raylib 1.6 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class Bunnymark
{
    public const int MaxBunnies = 150000;

    // This is the maximum amount of elements (quads) per batch
    // NOTE: This value is defined in [rlgl] module and can be changed there
    public const int MAX_BATCH_ELEMENTS = 8192;

    struct Bunny
    {
        public Vector2 Position;
        public Vector2 Speed;
        public Color Color;
    }

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - bunnymark");

        // Load bunny texture
        Texture2D texBunny = LoadTexture("resources/wabbit_alpha.png");

        // 50K bunnies limit
        Bunny[] bunnies = new Bunny[MaxBunnies];
        int bunniesCount = 0;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsMouseButtonDown(MouseButton.Left))
            {
                // Create more bunnies
                for (int i = 0; i < 100; i++)
                {
                    if (bunniesCount < MaxBunnies)
                    {
                        bunnies[bunniesCount].Position = GetMousePosition();
                        bunnies[bunniesCount].Speed.X = (float)GetRandomValue(-250, 250) / 60.0f;
                        bunnies[bunniesCount].Speed.Y = (float)GetRandomValue(-250, 250) / 60.0f;
                        bunnies[bunniesCount].Color = new Color(
                            GetRandomValue(50, 240),
                            GetRandomValue(80, 240),
                            GetRandomValue(100, 240), 255
                        );
                        bunniesCount++;
                    }
                }
            }

            // Update bunnies
            Vector2 screen = new(GetScreenWidth(), GetScreenHeight());
            Vector2 halfSize = new Vector2(texBunny.Width, texBunny.Height) / 2;

            for (int i = 0; i < bunniesCount; i++)
            {
                bunnies[i].Position += bunnies[i].Speed;

                if (((bunnies[i].Position.X + halfSize.X) > screen.X) ||
                    ((bunnies[i].Position.X + halfSize.X) < 0))
                {
                    bunnies[i].Speed.X *= -1;
                }

                if (((bunnies[i].Position.Y + halfSize.Y) > screen.Y) ||
                    ((bunnies[i].Position.Y + halfSize.Y - 40) < 0))
                {
                    bunnies[i].Speed.Y *= -1;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            for (int i = 0; i < bunniesCount; i++)
            {
                // NOTE: When internal batch buffer limit is reached (MAX_BATCH_ELEMENTS),
                // a draw call is launched and buffer starts being filled again;
                // before issuing a draw call, updated vertex data from internal CPU buffer is send to GPU...
                // Process of sending data is costly and it could happen that GPU data has not been completely
                // processed for drawing while new data is tried to be sent (updating current in-use buffers)
                // it could generates a stall and consequently a frame drop, limiting the number of drawn bunnies
                DrawTexture(texBunny, (int)bunnies[i].Position.X, (int)bunnies[i].Position.Y, bunnies[i].Color);
            }

            DrawRectangle(0, 0, screenWidth, 40, Color.Black);
            DrawText($"bunnies: {bunniesCount}", 120, 10, 20, Color.Green);
            DrawText($"batched draw calls: {1 + bunniesCount / MAX_BATCH_ELEMENTS}", 320, 10, 20, Color.Maroon);

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texBunny);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
