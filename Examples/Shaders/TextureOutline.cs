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

public class TextureOutline
{
    const int GLSL_VERSION = 330;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - Apply an outline to a texture");

        Texture2D texture = LoadTexture("resources/fudesumi.png");
        Shader shdrOutline = LoadShader(null, $"resources/shaders/glsl{GLSL_VERSION}/outline.fs");

        float outlineSize = 2.0f;

        // Normalized red color
        float[] outlineColor = new[] { 1.0f, 0.0f, 0.0f, 1.0f };
        float[] textureSize = { (float)texture.Width, (float)texture.Height };

        // Get shader locations
        int outlineSizeLoc = GetShaderLocation(shdrOutline, "outlineSize");
        int outlineColorLoc = GetShaderLocation(shdrOutline, "outlineColor");
        int textureSizeLoc = GetShaderLocation(shdrOutline, "textureSize");

        // Set shader values (they can be changed later)
        Raylib.SetShaderValue(
            shdrOutline,
            outlineSizeLoc,
            outlineSize,
            ShaderUniformDataType.Float
        );
        Raylib.SetShaderValue(
            shdrOutline,
            outlineColorLoc,
            outlineColor,
            ShaderUniformDataType.Vec4
        );
        Raylib.SetShaderValue(
            shdrOutline,
            textureSizeLoc,
            textureSize,
            ShaderUniformDataType.Vec2
        );

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            outlineSize += GetMouseWheelMove();
            if (outlineSize < 1.0f)
            {
                outlineSize = 1.0f;
            }

            Raylib.SetShaderValue(
                shdrOutline,
                outlineSizeLoc,
                outlineSize,
                ShaderUniformDataType.Float
            );
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            BeginShaderMode(shdrOutline);
            DrawTexture(texture, GetScreenWidth() / 2 - texture.Width / 2, -30, Color.White);
            EndShaderMode();

            DrawText("Shader-based\ntexture\noutline", 10, 10, 20, Color.Gray);

            DrawText($"Outline size: {outlineSize} px", 10, 120, 20, Color.Maroon);

            DrawFPS(710, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texture);
        UnloadShader(shdrOutline);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
