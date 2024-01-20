/*******************************************************************************************
*
*   raylib [text] example - Sprite font loading
*
*   Loaded sprite fonts have been generated following XNA SpriteFont conventions:
*     - Characters must be ordered starting with character 32 (Space)
*     - Every character must be contained within the same Rectangle height
*     - Every character and every line must be separated the same distance
*     - Rectangles must be defined by a magenta color background
*
*   If following this constraints, a font can be provided just by an image,
*   this is quite handy to avoid additional information files (like BMFonts use).
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Text;

public class FontSpritefont
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - sprite font loading");

        string msg1 = "THIS IS A custom SPRITE FONT...";
        string msg2 = "...and this is ANOTHER CUSTOM font...";
        string msg3 = "...and a THIRD one! GREAT! :D";

        // NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)
        Font font1 = LoadFont("resources/fonts/custom_mecha.png");
        Font font2 = LoadFont("resources/fonts/custom_alagard.png");
        Font font3 = LoadFont("resources/fonts/custom_jupiter_crash.png");

        Vector2 fontPosition1 = new(
            screenWidth / 2 - MeasureTextEx(font1, msg1, font1.BaseSize, -3).X / 2,
            screenHeight / 2 - font1.BaseSize / 2 - 80
        );

        Vector2 fontPosition2 = new(
            screenWidth / 2 - MeasureTextEx(font2, msg2, font2.BaseSize, -2).X / 2,
            screenHeight / 2 - font2.BaseSize / 2 - 10
        );

        Vector2 fontPosition3 = new(
            screenWidth / 2 - MeasureTextEx(font3, msg3, font3.BaseSize, 2).X / 2,
            screenHeight / 2 - font3.BaseSize / 2 + 50
        );

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update variables here...
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawTextEx(font1, msg1, fontPosition1, font1.BaseSize, -3, Color.White);
            DrawTextEx(font2, msg2, fontPosition2, font2.BaseSize, -2, Color.White);
            DrawTextEx(font3, msg3, fontPosition3, font3.BaseSize, 2, Color.White);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadFont(font1);
        UnloadFont(font2);
        UnloadFont(font3);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
