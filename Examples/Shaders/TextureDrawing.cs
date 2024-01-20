/*******************************************************************************************
*
*   raylib [textures] example - Texture drawing
*
*   This example illustrates how to draw on a blank texture using a shader
*
*   This example has been created using raylib 2.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Michał Ciesielski and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Michał Ciesielski and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Shaders;

public class TextureDrawing
{
    const int GlslVersion = 330;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - texture drawing");

        // Load blank texture to fill on shader
        Image imBlank = GenImageColor(1024, 1024, Color.Blank);
        Texture2D texture = LoadTextureFromImage(imBlank);
        UnloadImage(imBlank);

        // NOTE: Using GLSL 330 shader version, on OpenGL ES 2.0 use GLSL 100 shader version
        Shader shader = LoadShader(null, $"resources/shaders/glsl{GlslVersion}/cubes_panning.fs");

        float time = 0.0f;
        int timeLoc = GetShaderLocation(shader, "uTime");
        Raylib.SetShaderValue(shader, timeLoc, time, ShaderUniformDataType.Float);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            time = (float)GetTime();
            Raylib.SetShaderValue(shader, timeLoc, time, ShaderUniformDataType.Float);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            // Enable our custom shader for next shapes/textures drawings
            BeginShaderMode(shader);

            // Drawing blank texture, all magic happens on shader
            DrawTexture(texture, 0, 0, Color.White);

            // Disable our custom shader, return to default shader
            EndShaderMode();

            DrawText("BACKGROUND is PAINTED and ANIMATED on SHADER!", 10, 10, 20, Color.Maroon);

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
