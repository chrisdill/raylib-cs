/*******************************************************************************************
*
*   raylib [textures] example - Draw part of the texture tiled
*
*   This example has been created using raylib 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2020 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class DrawTiled
{
    const int OptWidth = 220;
    const int MarginSize = 8;
    const int ColorSize = 16;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        SetConfigFlags(ConfigFlags.ResizableWindow);
        InitWindow(screenWidth, screenHeight, "raylib [textures] example - Draw part of a texture tiled");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Texture2D texPattern = LoadTexture("resources/patterns.png");

        // Makes the texture smoother when upscaled
        SetTextureFilter(texPattern, TextureFilter.Trilinear);

        // Coordinates for all patterns inside the texture
        Rectangle[] recPattern = new[] {
                new Rectangle(3, 3, 66, 66),
                new Rectangle(75, 3, 100, 100),
                new Rectangle(3, 75, 66, 66),
                new Rectangle(7, 156, 50, 50),
                new Rectangle(85, 106, 90, 45),
                new Rectangle(75, 154, 100, 60)
            };

        // Setup colors
        Color[] colors = new[]
        {
                Color.Black,
                Color.Maroon,
                Color.Orange,
                Color.Blue,
                Color.Purple,
                Color.Beige,
                Color.Lime,
                Color.Red,
                Color.DarkGray,
                Color.SkyBlue
            };
        Rectangle[] colorRec = new Rectangle[colors.Length];

        // Calculate rectangle for each color
        for (int i = 0, x = 0, y = 0; i < colors.Length; i++)
        {
            colorRec[i].X = 2 + MarginSize + x;
            colorRec[i].Y = 22 + 256 + MarginSize + y;
            colorRec[i].Width = ColorSize * 2;
            colorRec[i].Height = ColorSize;

            if (i == (colors.Length / 2 - 1))
            {
                x = 0;
                y += ColorSize + MarginSize;
            }
            else
            {
                x += (ColorSize * 2 + MarginSize);
            }
        }

        int activePattern = 0, activeCol = 0;
        float scale = 1.0f, rotation = 0.0f;

        SetTargetFPS(60);
        //---------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            screenWidth = GetScreenWidth();
            screenHeight = GetScreenHeight();

            // Handle mouse
            if (IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 mouse = GetMousePosition();

                // Check which pattern was clicked and set it as the active pattern
                for (int i = 0; i < recPattern.Length; i++)
                {
                    Rectangle rec = new(
                        2 + MarginSize + recPattern[i].X,
                        40 + MarginSize + recPattern[i].Y,
                        recPattern[i].Width,
                        recPattern[i].Height
                    );
                    if (CheckCollisionPointRec(mouse, rec))
                    {
                        activePattern = i;
                        break;
                    }
                }

                // Check to see which color was clicked and set it as the active color
                for (int i = 0; i < colors.Length; ++i)
                {
                    if (CheckCollisionPointRec(mouse, colorRec[i]))
                    {
                        activeCol = i;
                        break;
                    }
                }
            }

            // Handle keys

            // Change scale
            if (IsKeyPressed(KeyboardKey.Up))
            {
                scale += 0.25f;
            }
            if (IsKeyPressed(KeyboardKey.Down))
            {
                scale -= 0.25f;
            }
            if (scale > 10.0f)
            {
                scale = 10.0f;
            }
            else if (scale <= 0.0f)
            {
                scale = 0.25f;
            }

            // Change rotation
            if (IsKeyPressed(KeyboardKey.Left))
            {
                rotation -= 25.0f;
            }
            if (IsKeyPressed(KeyboardKey.Right))
            {
                rotation += 25.0f;
            }

            // Reset
            if (IsKeyPressed(KeyboardKey.Space))
            {
                rotation = 0.0f;
                scale = 1.0f;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            // Draw the tiled area
            Rectangle source = recPattern[activePattern];
            Rectangle dest = new(
                OptWidth + MarginSize,
                MarginSize,
                screenWidth - OptWidth - 2 * MarginSize,
                screenHeight - 2 * MarginSize
            );
            DrawTextureTiled(texPattern, source, dest, Vector2.Zero, rotation, scale, colors[activeCol]);

            // Draw options
            Color color = ColorAlpha(Color.LightGray, 0.5f);
            DrawRectangle(MarginSize, MarginSize, OptWidth - MarginSize, screenHeight - 2 * MarginSize, color);

            DrawText("Select Pattern", 2 + MarginSize, 30 + MarginSize, 10, Color.Black);
            DrawTexture(texPattern, 2 + MarginSize, 40 + MarginSize, Color.Black);
            DrawRectangle(
                2 + MarginSize + (int)recPattern[activePattern].X,
                40 + MarginSize + (int)recPattern[activePattern].Y,
                (int)recPattern[activePattern].Width,
                (int)recPattern[activePattern].Height,
                ColorAlpha(Color.DarkBlue, 0.3f)
            );

            DrawText("Select Color", 2 + MarginSize, 10 + 256 + MarginSize, 10, Color.Black);
            for (int i = 0; i < colors.Length; i++)
            {
                DrawRectangleRec(colorRec[i], colors[i]);
                if (activeCol == i)
                {
                    DrawRectangleLinesEx(colorRec[i], 3, ColorAlpha(Color.White, 0.5f));
                }
            }

            DrawText("Scale (UP/DOWN to change)", 2 + MarginSize, 80 + 256 + MarginSize, 10, Color.Black);
            DrawText($"{scale}x", 2 + MarginSize, 92 + 256 + MarginSize, 20, Color.Black);

            DrawText("Rotation (LEFT/RIGHT to change)", 2 + MarginSize, 122 + 256 + MarginSize, 10, Color.Black);
            DrawText($"{rotation} degrees", 2 + MarginSize, 134 + 256 + MarginSize, 20, Color.Black);

            DrawText("Press [SPACE] to reset", 2 + MarginSize, 164 + 256 + MarginSize, 10, Color.DarkBlue);

            // Draw FPS
            DrawText($"{GetFPS()}", 2 + MarginSize, 2 + MarginSize, 20, Color.Black);
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texPattern);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }

    // Draw part of a texture (defined by a rectangle) with rotation and scale tiled into dest.
    static void DrawTextureTiled(
        Texture2D texture,
        Rectangle source,
        Rectangle dest,
        Vector2 origin,
        float rotation,
        float scale,
        Color tint
    )
    {
        if ((texture.Id <= 0) || (scale <= 0.0f))
        {
            // Wanna see a infinite loop?!...just delete this line!
            return;
        }

        if ((source.Width == 0) || (source.Height == 0))
        {
            return;
        }

        int tileWidth = (int)(source.Width * scale), tileHeight = (int)(source.Height * scale);
        if ((dest.Width < tileWidth) && (dest.Height < tileHeight))
        {
            // Can fit only one tile
            DrawTexturePro(
                texture,
                new Rectangle(
                    source.X,
                    source.Y,
                    ((float)dest.Width / tileWidth) * source.Width,
                    ((float)dest.Height / tileHeight) * source.Height
                ),
                new Rectangle(dest.X, dest.Y, dest.Width, dest.Height), origin, rotation, tint
            );
        }
        else if (dest.Width <= tileWidth)
        {
            // Tiled vertically (one column)
            int dy = 0;
            for (; dy + tileHeight < dest.Height; dy += tileHeight)
            {
                DrawTexturePro(
                    texture,
                    new Rectangle(
                        source.X,
                        source.Y,
                        ((float)dest.Width / tileWidth) * source.Width,
                        source.Height
                    ),
                    new Rectangle(dest.X, dest.Y + dy, dest.Width, (float)tileHeight),
                    origin,
                    rotation,
                    tint
                );
            }

            // Fit last tile
            if (dy < dest.Height)
            {
                DrawTexturePro(
                    texture,
                    new Rectangle(
                        source.X,
                        source.Y,
                        ((float)dest.Width / tileWidth) * source.Width,
                        ((float)(dest.Height - dy) / tileHeight) * source.Height
                    ),
                    new Rectangle(dest.X, dest.Y + dy, dest.Width, dest.Height - dy),
                    origin,
                    rotation,
                    tint
                );
            }
        }
        else if (dest.Height <= tileHeight)
        {
            // Tiled horizontally (one row)
            int dx = 0;
            for (; dx + tileWidth < dest.Width; dx += tileWidth)
            {
                DrawTexturePro(
                    texture,
                    new Rectangle(
                        source.X,
                        source.Y,
                        source.Width,
                        ((float)dest.Height / tileHeight) * source.Height
                    ),
                    new Rectangle(dest.X + dx, dest.Y, (float)tileWidth, dest.Height),
                    origin,
                    rotation,
                    tint
                );
            }

            // Fit last tile
            if (dx < dest.Width)
            {
                DrawTexturePro(
                    texture,
                    new Rectangle(
                        source.X,
                        source.Y,
                        ((float)(dest.Width - dx) / tileWidth) * source.Width,
                        ((float)dest.Height / tileHeight) * source.Height
                    ),
                    new Rectangle(
                        dest.X + dx,
                        dest.Y,
                        dest.Width - dx,
                        dest.Height
                    ),
                    origin,
                    rotation,
                    tint
                );
            }
        }
        else
        {
            // Tiled both horizontally and vertically (rows and columns)
            int dx = 0;
            for (; dx + tileWidth < dest.Width; dx += tileWidth)
            {
                int dy = 0;
                for (; dy + tileHeight < dest.Height; dy += tileHeight)
                {
                    DrawTexturePro(
                        texture,
                        source,
                        new Rectangle(
                            dest.X + dx,
                            dest.Y + dy,
                            (float)tileWidth,
                            (float)tileHeight
                        ),
                        origin,
                        rotation,
                        tint
                    );
                }

                if (dy < dest.Height)
                {
                    DrawTexturePro(
                        texture,
                        new Rectangle(
                            source.X,
                            source.Y,
                            source.Width,
                            ((float)(dest.Height - dy) / tileHeight) * source.Height
                        ),
                        new Rectangle(
                            dest.X + dx,
                            dest.Y + dy,
                            (float)tileWidth, dest.Height - dy
                        ),
                        origin,
                        rotation,
                        tint
                    );
                }
            }

            // Fit last column of tiles
            if (dx < dest.Width)
            {
                int dy = 0;
                for (; dy + tileHeight < dest.Height; dy += tileHeight)
                {
                    DrawTexturePro(
                        texture,
                        new Rectangle(
                            source.X,
                            source.Y,
                            ((float)(dest.Width - dx) / tileWidth) * source.Width,
                            source.Height
                        ),
                        new Rectangle(
                            dest.X + dx,
                            dest.Y + dy,
                            dest.Width - dx,
                            (float)tileHeight
                        ),
                        origin,
                        rotation,
                        tint
                    );
                }

                // Draw final tile in the bottom right corner
                if (dy < dest.Height)
                {
                    DrawTexturePro(
                        texture,
                        new Rectangle(
                            source.X,
                            source.Y,
                            ((float)(dest.Width - dx) / tileWidth) * source.Width,
                            ((float)(dest.Height - dy) / tileHeight) * source.Height
                        ),
                        new Rectangle(
                            dest.X + dx,
                            dest.Y + dy,
                            dest.Width - dx,
                            dest.Height - dy
                        ),
                        origin,
                        rotation,
                        tint
                    );
                }
            }
        }
    }
}

