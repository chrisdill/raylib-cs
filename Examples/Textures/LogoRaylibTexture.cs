/*******************************************************************************************
*
*   raylib [textures] example - Texture loading and drawing
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class LogoRaylibTexture
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - texture loading and drawing");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Texture2D texture = LoadTexture("resources/raylib-cs_logo.png");
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

            DrawTexture(
                texture,
                screenWidth / 2 - texture.Width / 2,
                screenHeight / 2 - texture.Height / 2,
                Color.White
            );

            DrawText("this IS a texture!", 360, 370, 10, Color.Gray);

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
