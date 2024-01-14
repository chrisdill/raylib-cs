/*******************************************************************************************
*
*   raylib [textures] example - Retrieve image data from texture: GetTextureData()
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class ToImage
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - texture to image");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)

        Image image = LoadImage("resources/raylib-cs_logo.png");
        Texture2D texture = LoadTextureFromImage(image);
        UnloadImage(image);

        image = LoadImageFromTexture(texture);
        UnloadTexture(texture);

        texture = LoadTextureFromImage(image);
        UnloadImage(image);
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
            DrawTexture(texture, x, y, Color.White);

            DrawText("this IS a texture loaded from an image!", 300, 370, 10, Color.Gray);

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
