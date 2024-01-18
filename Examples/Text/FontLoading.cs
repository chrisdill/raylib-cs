/*******************************************************************************************
*
*   raylib [text] example - Font loading
*
*   raylib can load fonts from multiple file formats:
*
*     - TTF/OTF > Sprite font atlas is generated on loading, user can configure
*                 some of the generation parameters (size, characters to include)
*     - BMFonts > Angel code font fileformat, sprite font image must be provided
*                 together with the .fnt file, font generation cna not be configured
*     - XNA Spritefont > Sprite font image, following XNA Spritefont conventions,
*                 Characters in image must follow some spacing and order rules
*
*   This example has been created using raylib 2.6 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Text;

public class FontLoading
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - font loading");

        // Define characters to draw
        // NOTE: raylib supports UTF-8 encoding, following list is actually codified as UTF8 internally
        string msg = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHI\nJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmn\nopqrstuvwxyz{|}~¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓ\nÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷\nøùúûüýþÿ";

        // NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

        // BMFont (AngelCode) : Font data and image atlas have been generated using external program
        Font fontBm = LoadFont("resources/fonts/pixantiqua.fnt");

        // TTF font : Font data and atlas are generated directly from TTF
        // NOTE: We define a font base size of 32 pixels tall and up-to 250 characters
        Font fontTtf = LoadFontEx("resources/fonts/pixantiqua.ttf", 32, null, 250);

        bool useTtf = false;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyDown(KeyboardKey.Space))
            {
                useTtf = true;
            }
            else
            {
                useTtf = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawText("Hold SPACE to use TTF generated font", 20, 20, 20, Color.LightGray);

            if (!useTtf)
            {
                DrawTextEx(fontBm, msg, new Vector2(20.0f, 100.0f), fontBm.BaseSize, 2, Color.Maroon);
                DrawText("Using BMFont (Angelcode) imported", 20, GetScreenHeight() - 30, 20, Color.Gray);
            }
            else
            {
                DrawTextEx(fontTtf, msg, new Vector2(20.0f, 100.0f), fontTtf.BaseSize, 2, Color.Lime);
                DrawText("Using TTF font generated", 20, GetScreenHeight() - 30, 20, Color.Gray);
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadFont(fontBm);
        UnloadFont(fontTtf);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
