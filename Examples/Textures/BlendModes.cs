/*******************************************************************************************
*
*   raylib [textures] example - blend modes
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Karlo Licudine (@accidentalrebel) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2020 Karlo Licudine (@accidentalrebel)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class BlendModes
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - blend modes");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Image bgImage = LoadImage("resources/cyberpunk_street_background.png");
        Texture2D bgTexture = LoadTextureFromImage(bgImage);

        Image fgImage = LoadImage("resources/cyberpunk_street_foreground.png");
        Texture2D fgTexture = LoadTextureFromImage(fgImage);

        // Once image has been converted to texture and uploaded to VRAM, it can be unloaded from RAM
        UnloadImage(bgImage);
        UnloadImage(fgImage);

        const int blendCountMax = 4;
        BlendMode blendMode = 0;

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.Space))
            {
                if ((int)blendMode >= (blendCountMax - 1))
                {
                    blendMode = 0;
                }
                else
                {
                    blendMode++;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            int bgX = screenWidth / 2 - bgTexture.Width / 2;
            int bgY = screenHeight / 2 - bgTexture.Height / 2;
            DrawTexture(bgTexture, bgX, bgY, Color.White);

            // Apply the blend mode and then draw the foreground texture
            BeginBlendMode(blendMode);
            int fgX = screenWidth / 2 - fgTexture.Width / 2;
            int fgY = screenHeight / 2 - fgTexture.Height / 2;
            DrawTexture(fgTexture, fgX, fgY, Color.White);
            EndBlendMode();

            // Draw the texts
            DrawText("Press SPACE to change blend modes.", 310, 350, 10, Color.Gray);

            switch (blendMode)
            {
                case BlendMode.Alpha:
                    DrawText("Current: BLEND_ALPHA", (screenWidth / 2) - 60, 370, 10, Color.Gray);
                    break;
                case BlendMode.Additive:
                    DrawText("Current: BLEND_ADDITIVE", (screenWidth / 2) - 60, 370, 10, Color.Gray);
                    break;
                case BlendMode.Multiplied:
                    DrawText("Current: BLEND_MULTIPLIED", (screenWidth / 2) - 60, 370, 10, Color.Gray);
                    break;
                case BlendMode.AddColors:
                    DrawText("Current: BLEND_ADD_COLORS", (screenWidth / 2) - 60, 370, 10, Color.Gray);
                    break;
                default:
                    break;
            }

            string text = "(c) Cyberpunk Street Environment by Luis Zuno (@ansimuz)";
            DrawText(text, screenWidth - 330, screenHeight - 20, 10, Color.Gray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(fgTexture);
        UnloadTexture(bgTexture);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
