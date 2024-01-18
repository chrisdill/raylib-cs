/*******************************************************************************************
*
*   raylib [textures] example - Procedural images generation
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2O17 Wilhem Barbier (@nounoursheureux)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class ImageGeneration
{
    public const int NumTextures = 6;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - procedural images generation");

        Image verticalGradient = GenImageGradientLinear(screenWidth, screenHeight, 0, Color.Red, Color.Blue);
        Image horizontalGradient = GenImageGradientLinear(screenWidth, screenHeight, 90, Color.Red, Color.Blue);
        Image radialGradient = GenImageGradientRadial(screenWidth, screenHeight, 0.0f, Color.White, Color.Black);
        Image isChecked = GenImageChecked(screenWidth, screenHeight, 32, 32, Color.Red, Color.Blue);
        Image whiteNoise = GenImageWhiteNoise(screenWidth, screenHeight, 0.5f);
        Image cellular = GenImageCellular(screenWidth, screenHeight, 32);

        Texture2D[] textures = new Texture2D[NumTextures];
        textures[0] = LoadTextureFromImage(verticalGradient);
        textures[1] = LoadTextureFromImage(horizontalGradient);
        textures[2] = LoadTextureFromImage(radialGradient);
        textures[3] = LoadTextureFromImage(isChecked);
        textures[4] = LoadTextureFromImage(whiteNoise);
        textures[5] = LoadTextureFromImage(cellular);

        UnloadImage(verticalGradient);
        UnloadImage(horizontalGradient);
        UnloadImage(radialGradient);
        UnloadImage(isChecked);
        UnloadImage(whiteNoise);
        UnloadImage(cellular);

        int currentTexture = 0;

        SetTargetFPS(60);
        //---------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsMouseButtonPressed(MouseButton.Left) || IsKeyPressed(KeyboardKey.Right))
            {
                // Cycle between the textures
                currentTexture = (currentTexture + 1) % NumTextures;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawTexture(textures[currentTexture], 0, 0, Color.White);

            DrawRectangle(30, 400, 325, 30, ColorAlpha(Color.SkyBlue, 0.5f));
            DrawRectangleLines(30, 400, 325, 30, ColorAlpha(Color.White, 0.5f));
            DrawText("MOUSE LEFT BUTTON to CYCLE PROCEDURAL TEXTURES", 40, 410, 10, Color.White);

            switch (currentTexture)
            {
                case 0:
                    DrawText("VERTICAL GRADIENT", 560, 10, 20, Color.RayWhite);
                    break;
                case 1:
                    DrawText("HORIZONTAL GRADIENT", 540, 10, 20, Color.RayWhite);
                    break;
                case 2:
                    DrawText("RADIAL GRADIENT", 580, 10, 20, Color.LightGray);
                    break;
                case 3:
                    DrawText("CHECKED", 680, 10, 20, Color.RayWhite);
                    break;
                case 4:
                    DrawText("Color.WHITE NOISE", 640, 10, 20, Color.Red);
                    break;
                case 5:
                    DrawText("CELLULAR", 670, 10, 20, Color.RayWhite);
                    break;
                default:
                    break;
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        for (int i = 0; i < textures.Length; i++)
        {
            UnloadTexture(textures[i]);
        }

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
