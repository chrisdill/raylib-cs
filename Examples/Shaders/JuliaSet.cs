/*******************************************************************************************
*
*   raylib [shaders] example - julia sets
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by eggmund (@eggmund) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 eggmund (@eggmund) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Shaders;

public class JuliaSet
{
    const int GlslVersion = 330;

    // A few good julia sets
    static float[][] PointsOfInterest = new float[][] {
            new float[] { -0.348827f, 0.607167f },
            new float[] { -0.786268f, 0.169728f },
            new float[] { -0.8f, 0.156f },
            new float[] { 0.285f, 0.0f },
            new float[] { -0.835f, -0.2321f },
            new float[] { -0.70176f, -0.3842f },
        };

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - julia sets");

        // Load julia set shader
        // NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
        Shader shader = LoadShader(null, $"resources/shaders/glsl{GlslVersion}/julia_set.fs");

        // c constant to use in z^2 + c
        float[] c = { PointsOfInterest[0][0], PointsOfInterest[0][1] };

        // Offset and zoom to draw the julia set at. (centered on screen and default size)
        float[] offset = { -(float)screenWidth / 2, -(float)screenHeight / 2 };
        float zoom = 1.0f;

        Vector2 offsetSpeed = new(0.0f, 0.0f);

        // Get variable (uniform) locations on the shader to connect with the program
        // NOTE: If uniform variable could not be found in the shader, function returns -1
        int cLoc = GetShaderLocation(shader, "c");
        int zoomLoc = GetShaderLocation(shader, "zoom");
        int offsetLoc = GetShaderLocation(shader, "offset");

        // Tell the shader what the screen dimensions, zoom, offset and c are
        float[] screenDims = { (float)screenWidth, (float)screenHeight };
        Raylib.SetShaderValue(
            shader,
            GetShaderLocation(shader, "screenDims"),
            screenDims,
            ShaderUniformDataType.SHADER_UNIFORM_VEC2
        );

        Raylib.SetShaderValue(shader, cLoc, c, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        Raylib.SetShaderValue(shader, zoomLoc, zoomLoc, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
        Raylib.SetShaderValue(shader, offsetLoc, offset, ShaderUniformDataType.SHADER_UNIFORM_VEC2);

        // Create a RenderTexture2D to be used for render to texture
        RenderTexture2D target = LoadRenderTexture(screenWidth, screenHeight);

        // Multiplier of speed to change c value
        int incrementSpeed = 0;
        // Show controls
        bool showControls = true;
        // Pause animation
        bool pause = false;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // Press [1 - 6] to reset c to a point of interest
            if (IsKeyPressed(KeyboardKey.KEY_ONE) ||
                IsKeyPressed(KeyboardKey.KEY_TWO) ||
                IsKeyPressed(KeyboardKey.KEY_THREE) ||
                IsKeyPressed(KeyboardKey.KEY_FOUR) ||
                IsKeyPressed(KeyboardKey.KEY_FIVE) ||
                IsKeyPressed(KeyboardKey.KEY_SIX))
            {

                if (IsKeyPressed(KeyboardKey.KEY_ONE))
                {
                    c[0] = PointsOfInterest[0][0];
                    c[1] = PointsOfInterest[0][1];
                }
                else if (IsKeyPressed(KeyboardKey.KEY_TWO))
                {
                    c[0] = PointsOfInterest[1][0];
                    c[1] = PointsOfInterest[1][1];
                }
                else if (IsKeyPressed(KeyboardKey.KEY_THREE))
                {
                    c[0] = PointsOfInterest[2][0];
                    c[1] = PointsOfInterest[2][1];
                }
                else if (IsKeyPressed(KeyboardKey.KEY_FOUR))
                {
                    c[0] = PointsOfInterest[3][0];
                    c[1] = PointsOfInterest[3][1];
                }
                else if (IsKeyPressed(KeyboardKey.KEY_FIVE))
                {
                    c[0] = PointsOfInterest[4][0];
                    c[1] = PointsOfInterest[4][1];
                }
                else if (IsKeyPressed(KeyboardKey.KEY_SIX))
                {
                    c[0] = PointsOfInterest[5][0];
                    c[1] = PointsOfInterest[5][1];
                }
                Raylib.SetShaderValue(shader, cLoc, c, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
            }

            // Pause animation (c change)
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                pause = !pause;
            }

            // Toggle whether or not to show controls
            if (IsKeyPressed(KeyboardKey.KEY_F1))
            {
                showControls = !showControls;
            }

            if (!pause)
            {
                if (IsKeyPressed(KeyboardKey.KEY_RIGHT))
                {
                    incrementSpeed++;
                }
                else if (IsKeyPressed(KeyboardKey.KEY_LEFT))
                {
                    incrementSpeed--;
                }

                // TODO: The idea is to zoom and move around with mouse
                // Probably offset movement should be proportional to zoom level
                if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON) || IsMouseButtonDown(MouseButton.MOUSE_RIGHT_BUTTON))
                {
                    if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        zoom += zoom * 0.003f;
                    }

                    if (IsMouseButtonDown(MouseButton.MOUSE_RIGHT_BUTTON))
                    {
                        zoom -= zoom * 0.003f;
                    }

                    Vector2 mousePos = GetMousePosition();

                    offsetSpeed.X = mousePos.X - (float)screenWidth / 2;
                    offsetSpeed.Y = mousePos.Y - (float)screenHeight / 2;

                    // Slowly move camera to targetOffset
                    offset[0] += GetFrameTime() * offsetSpeed.X * 0.8f;
                    offset[1] += GetFrameTime() * offsetSpeed.Y * 0.8f;
                }
                else
                {
                    offsetSpeed = new Vector2(0.0f, 0.0f);
                }

                Raylib.SetShaderValue(shader, zoomLoc, zoom, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
                Raylib.SetShaderValue(shader, offsetLoc, offset, ShaderUniformDataType.SHADER_UNIFORM_VEC2);

                // Increment c value with time
                float amount = GetFrameTime() * incrementSpeed * 0.0005f;
                c[0] += amount;
                c[1] += amount;

                Raylib.SetShaderValue(shader, cLoc, c, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.BLACK);

            // Using a render texture to draw Julia set
            // Enable drawing to texture
            BeginTextureMode(target);
            ClearBackground(Color.BLACK);

            // Draw a rectangle in shader mode to be used as shader canvas
            // NOTE: Rectangle uses font Color.white character texture coordinates,
            // so shader can not be applied here directly because input vertexTexCoord
            // do not represent full screen coordinates (space where want to apply shader)
            DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Color.BLACK);
            EndTextureMode();

            // Draw the saved texture and rendered julia set with shader
            // NOTE: We do not invert texture on Y, already considered inside shader
            BeginShaderMode(shader);
            DrawTexture(target.Texture, 0, 0, Color.WHITE);
            EndShaderMode();

            if (showControls)
            {
                DrawText("Press Mouse buttons right/left to zoom in/out and move", 10, 15, 10, Color.RAYWHITE);
                DrawText("Press KEY_F1 to toggle these controls", 10, 30, 10, Color.RAYWHITE);
                DrawText("Press KEYS [1 - 6] to change point of interest", 10, 45, 10, Color.RAYWHITE);
                DrawText("Press KEY_LEFT | KEY_RIGHT to change speed", 10, 60, 10, Color.RAYWHITE);
                DrawText("Press KEY_SPACE to pause movement animation", 10, 75, 10, Color.RAYWHITE);
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadShader(shader);
        UnloadRenderTexture(target);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
