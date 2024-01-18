/*******************************************************************************************
*
*   raylib [shaders] example - Color palette switch
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
*
*   This example has been created using raylib 2.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Marco Lizza (@MarcoLizza) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Marco Lizza (@MarcoLizza) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Shaders;

public class PaletteSwitch
{
    const int GlslVersion = 330;
    const int ColorsPerPalette = 8;
    const int VALUES_PER_COLOR = 3;

    static int[][] Palettes = new int[][] {
            // 3-BIT RGB
            new int[] {
                0, 0, 0,
                255, 0, 0,
                0, 255, 0,
                0, 0, 255,
                0, 255, 255,
                255, 0, 255,
                255, 255, 0,
                255, 255, 255,
            },
            // AMMO-8 (GameBoy-like)
            new int[] {
                4, 12, 6,
                17, 35, 24,
                30, 58, 41,
                48, 93, 66,
                77, 128, 97,
                137, 162, 87,
                190, 220, 127,
                238, 255, 204,
            },
            // RKBV (2-strip film)
            new int[] {
                21, 25, 26,
                138, 76, 88,
                217, 98, 117,
                230, 184, 193,
                69, 107, 115,
                75, 151, 166,
                165, 189, 194,
                255, 245, 247,
            }
        };

    static string[] PaletteText = new string[] {
            "3-BIT RGB",
            "AMMO-8 (GameBoy-like)",
            "RKBV (2-strip film)"
        };

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - color palette switch");

        // Load shader to be used on some parts drawing
        // NOTE 1: Using GLSL 330 shader version, on OpenGL ES 2.0 use GLSL 100 shader version
        // NOTE 2: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
        Shader shader = LoadShader(null, $"resources/shaders/glsl{GlslVersion}/palette_switch.fs");

        // Get variable (uniform) location on the shader to connect with the program
        // NOTE: If uniform variable could not be found in the shader, function returns -1
        int paletteLoc = GetShaderLocation(shader, "palette");

        int currentPalette = 0;
        int lineHeight = screenHeight / ColorsPerPalette;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.Right))
            {
                currentPalette++;
            }
            else if (IsKeyPressed(KeyboardKey.Left))
            {
                currentPalette--;
            }

            if (currentPalette >= Palettes.Length)
            {
                currentPalette = 0;
            }
            else if (currentPalette < 0)
            {
                currentPalette = Palettes.Length - 1;
            }

            // Send new value to the shader to be used on drawing.
            // NOTE: We are sending RGB triplets w/o the alpha channel
            Raylib.SetShaderValueV(
                shader,
                paletteLoc,
                Palettes[currentPalette],
                ShaderUniformDataType.IVec3,
                ColorsPerPalette
            );
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginShaderMode(shader);

            for (int i = 0; i < ColorsPerPalette; i++)
            {
                // Draw horizontal screen-wide rectangles with increasing "palette index"
                // The used palette index is encoded in the RGB components of the pixel
                DrawRectangle(0, lineHeight * i, GetScreenWidth(), lineHeight, new Color(i, i, i, 255));
            }

            EndShaderMode();

            DrawText("< >", 10, 10, 30, Color.DarkBlue);
            DrawText("CURRENT PALETTE:", 60, 15, 20, Color.RayWhite);
            DrawText(PaletteText[currentPalette], 300, 15, 20, Color.Red);

            DrawFPS(700, 15);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadShader(shader);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
