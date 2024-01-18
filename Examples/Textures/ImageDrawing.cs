/*******************************************************************************************
*
*   raylib [textures] example - Image loading and drawing on it
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 1.4 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class ImageDrawing
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - image drawing");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)

        Image cat = LoadImage("resources/cat.png");
        ImageCrop(ref cat, new Rectangle(100, 10, 280, 380));
        ImageFlipHorizontal(ref cat);
        ImageResize(ref cat, 150, 200);

        Image parrots = LoadImage("resources/parrots.png");

        // Draw one image over the other with a scaling of 1.5f
        Rectangle src = new(0, 0, cat.Width, cat.Height);
        ImageDraw(ref parrots, cat, src, new Rectangle(30, 40, cat.Width * 1.5f, cat.Height * 1.5f), Color.White);
        ImageCrop(ref parrots, new Rectangle(0, 50, parrots.Width, parrots.Height - 100));

        // Draw on the image with a few image draw methods
        ImageDrawPixel(ref parrots, 10, 10, Color.RayWhite);
        ImageDrawCircle(ref parrots, 10, 10, 5, Color.RayWhite);
        ImageDrawRectangle(ref parrots, 5, 20, 10, 10, Color.RayWhite);

        UnloadImage(cat);

        // Load custom font for frawing on image
        Font font = LoadFont("resources/fonts/custom_jupiter_crash.png");

        // Draw over image using custom font
        ImageDrawTextEx(ref parrots, font, "PARROTS & CAT", new Vector2(300, 230), font.BaseSize, -2, Color.White);

        // Unload custom spritefont (already drawn used on image)
        UnloadFont(font);

        Texture2D texture = LoadTextureFromImage(parrots);
        UnloadImage(parrots);

        SetTargetFPS(60);
        //---------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            int x = screenWidth / 2 - texture.Width / 2;
            int y = screenHeight / 2 - texture.Height / 2;
            DrawTexture(texture, x, y - 40, Color.White);
            DrawRectangleLines(x, y - 40, texture.Width, texture.Height, Color.DarkGray);

            DrawText("We are drawing only one texture from various images composed!", 240, 350, 10, Color.DarkGray);

            string text = "Source images have been cropped, scaled, flipped and copied one over the other.";
            DrawText(text, 90, 370, 10, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texture);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
