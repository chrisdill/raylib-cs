/*******************************************************************************************
*
*   raylib [shaders] example - Texture Waves
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Anata (@anatagawa) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Anata (@anatagawa) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Shaders;

public class TextureWaves
{
    const int GlslVersion = 330;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - texture waves");

        // Load texture texture to apply shaders
        Texture2D texture = LoadTexture("resources/space.png");

        // Load shader and setup location points and values
        Shader shader = LoadShader(null, $"resources/shaders/glsl{GlslVersion}/wave.fs");

        int secondsLoc = GetShaderLocation(shader, "secondes");
        int freqXLoc = GetShaderLocation(shader, "freqX");
        int freqYLoc = GetShaderLocation(shader, "freqY");
        int ampXLoc = GetShaderLocation(shader, "ampX");
        int ampYLoc = GetShaderLocation(shader, "ampY");
        int speedXLoc = GetShaderLocation(shader, "speedX");
        int speedYLoc = GetShaderLocation(shader, "speedY");

        // Shader uniform values that can be updated at any time
        float freqX = 25.0f;
        float freqY = 25.0f;
        float ampX = 5.0f;
        float ampY = 5.0f;
        float speedX = 8.0f;
        float speedY = 8.0f;

        float[] screenSize = { (float)GetScreenWidth(), (float)GetScreenHeight() };
        Raylib.SetShaderValue(
            shader,
            GetShaderLocation(shader, "size"),
            screenSize,
            ShaderUniformDataType.Vec2
        );
        Raylib.SetShaderValue(shader, freqXLoc, freqX, ShaderUniformDataType.Float);
        Raylib.SetShaderValue(shader, freqYLoc, freqY, ShaderUniformDataType.Float);
        Raylib.SetShaderValue(shader, ampXLoc, ampX, ShaderUniformDataType.Float);
        Raylib.SetShaderValue(shader, ampYLoc, ampY, ShaderUniformDataType.Float);
        Raylib.SetShaderValue(shader, speedXLoc, speedX, ShaderUniformDataType.Float);
        Raylib.SetShaderValue(shader, speedYLoc, speedY, ShaderUniformDataType.Float);

        float seconds = 0.0f;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            seconds += GetFrameTime();

            Raylib.SetShaderValue(shader, secondsLoc, seconds, ShaderUniformDataType.Float);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginShaderMode(shader);

            DrawTexture(texture, 0, 0, Color.White);
            DrawTexture(texture, texture.Width, 0, Color.White);

            EndShaderMode();

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadShader(shader);
        UnloadTexture(texture);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
