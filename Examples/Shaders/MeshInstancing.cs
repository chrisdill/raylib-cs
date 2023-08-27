/*******************************************************************************************
*
*   raylib [shaders] example - rlgl module usage for instanced meshes
*
*   This example uses [rlgl] module funtionality (pseudo-OpenGL 1.1 style coding)
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by @seanpringle and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2020 @seanpringle
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;
using Examples.Shared;

namespace Examples.Shaders;

public class MeshInstancing
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;
        const int fps = 60;

        // Enable Multi Sampling Anti Aliasing 4x (if available)
        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - rlgl mesh instanced");

        // Speed of jump animation
        int speed = 30;
        // Count of separate groups jumping around
        int groups = 2;
        // Maximum amplitude of jump
        float amp = 10;
        // Global variance in jump height
        float variance = 0.8f;
        // Individual cube's computed loop timer
        float loop = 0.0f;

        // Used for various 3D coordinate & vector ops
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(-125.0f, 125.0f, -125.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.CAMERA_PERSPECTIVE;

        // Number of instances to display
        const int instances = 10000;
        Mesh cube = GenMeshCube(1.0f, 1.0f, 1.0f);

        // Rotation state of instances
        Matrix4x4[] rotations = new Matrix4x4[instances];
        // Per-frame rotation animation of instances
        Matrix4x4[] rotationsInc = new Matrix4x4[instances];
        // Locations of instances
        Matrix4x4[] translations = new Matrix4x4[instances];

        // Scatter random cubes around
        for (int i = 0; i < instances; i++)
        {
            x = GetRandomValue(-50, 50);
            y = GetRandomValue(-50, 50);
            z = GetRandomValue(-50, 50);
            translations[i] = Matrix4x4.CreateTranslation(x, y, z);

            x = GetRandomValue(0, 360);
            y = GetRandomValue(0, 360);
            z = GetRandomValue(0, 360);
            Vector3 axis = Vector3.Normalize(new Vector3(x, y, z));
            float angle = (float)GetRandomValue(0, 10) * DEG2RAD;

            rotationsInc[i] = Matrix4x4.CreateFromAxisAngle(axis, angle);
            rotations[i] = Matrix4x4.Identity;
        }

        // Pre-multiplied transformations passed to rlgl
        Matrix4x4[] transforms = new Matrix4x4[instances];
        Shader shader = LoadShader(
            "resources/shaders/glsl330/lighting_instancing.vs",
            "resources/shaders/glsl330/lighting.fs"
        );

        // Get some shader loactions
        unsafe
        {
            int* locs = (int*)shader.Locs;
            locs[(int)ShaderLocationIndex.SHADER_LOC_MATRIX_MVP] = GetShaderLocation(shader, "mvp");
            locs[(int)ShaderLocationIndex.SHADER_LOC_VECTOR_VIEW] = GetShaderLocation(shader, "viewPos");
            locs[(int)ShaderLocationIndex.SHADER_LOC_MATRIX_MODEL] = GetShaderLocationAttrib(
                shader,
                "instanceTransform"
            );
        }

        // Ambient light level
        int ambientLoc = GetShaderLocation(shader, "ambient");
        Raylib.SetShaderValue(
            shader,
            ambientLoc,
            new float[] { 0.2f, 0.2f, 0.2f, 1.0f },
            ShaderUniformDataType.SHADER_UNIFORM_VEC4
        );

        Rlights.CreateLight(
            0,
            LightType.Directorional,
            new Vector3(50, 50, 0),
            Vector3.Zero,
            Color.WHITE,
            shader
        );

        Material material = LoadMaterialDefault();
        material.Shader = shader;
        unsafe
        {
            material.Maps[(int)MaterialMapIndex.MATERIAL_MAP_DIFFUSE].Color = Color.RED;
        }

        int textPositionY = 300;

        // Simple frames counter to manage animation
        int framesCounter = 0;

        SetTargetFPS(fps);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.CAMERA_FREE);

            textPositionY = 300;
            framesCounter += 1;

            if (IsKeyDown(KeyboardKey.KEY_UP))
            {
                amp += 0.5f;
            }

            if (IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                amp = (amp <= 1) ? 1.0f : (amp - 1.0f);
            }

            if (IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                variance = (variance <= 0.0f) ? 0.0f : (variance - 0.01f);
            }

            if (IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                variance = (variance >= 1.0f) ? 1.0f : (variance + 0.01f);
            }

            if (IsKeyDown(KeyboardKey.KEY_ONE))
            {
                groups = 1;
            }

            if (IsKeyDown(KeyboardKey.KEY_TWO))
            {
                groups = 2;
            }

            if (IsKeyDown(KeyboardKey.KEY_THREE))
            {
                groups = 3;
            }

            if (IsKeyDown(KeyboardKey.KEY_FOUR))
            {
                groups = 4;
            }

            if (IsKeyDown(KeyboardKey.KEY_FIVE))
            {
                groups = 5;
            }

            if (IsKeyDown(KeyboardKey.KEY_SIX))
            {
                groups = 6;
            }

            if (IsKeyDown(KeyboardKey.KEY_SEVEN))
            {
                groups = 7;
            }

            if (IsKeyDown(KeyboardKey.KEY_EIGHT))
            {
                groups = 8;
            }

            if (IsKeyDown(KeyboardKey.KEY_NINE))
            {
                groups = 9;
            }

            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                groups = 7;
                amp = 25;
                speed = 18;
                variance = 0.70f;
            }

            if (IsKeyDown(KeyboardKey.KEY_EQUAL))
            {
                speed = (speed <= (int)(fps * 0.25f)) ? (int)(fps * 0.25f) : (int)(speed * 0.95f);
            }

            if (IsKeyDown(KeyboardKey.KEY_KP_ADD))
            {
                speed = (speed <= (int)(fps * 0.25f)) ? (int)(fps * 0.25f) : (int)(speed * 0.95f);
            }

            if (IsKeyDown(KeyboardKey.KEY_MINUS))
            {
                speed = (int)MathF.Max(speed * 1.02f, speed + 1);
            }

            if (IsKeyDown(KeyboardKey.KEY_KP_SUBTRACT))
            {
                speed = (int)MathF.Max(speed * 1.02f, speed + 1);
            }

            // Update the light shader with the camera view position
            float[] cameraPos = { camera.Position.X, camera.Position.Y, camera.Position.Z };
            Raylib.SetShaderValue(
                shader,
                (int)ShaderLocationIndex.SHADER_LOC_VECTOR_VIEW,
                cameraPos,
                ShaderUniformDataType.SHADER_UNIFORM_VEC3
            );

            // Apply per-instance transformations
            for (int i = 0; i < instances; i++)
            {
                rotations[i] = Matrix4x4.Multiply(rotations[i], rotationsInc[i]);
                transforms[i] = Matrix4x4.Multiply(rotations[i], translations[i]);

                // Get the animation cycle's framesCounter for this instance
                loop = (float)((framesCounter + (int)(((float)(i % groups) / groups) * speed)) % speed) / speed;

                // Calculate the y according to loop cycle
                y = (MathF.Sin(loop * MathF.PI * 2)) * amp * ((1 - variance) + (variance * (float)(i % (groups * 10)) / (groups * 10)));

                // Clamp to floor
                y = (y < 0) ? 0.0f : y;

                transforms[i] = Matrix4x4.Multiply(transforms[i], Matrix4x4.CreateTranslation(0.0f, y, 0.0f));
                transforms[i] = Matrix4x4.Transpose(transforms[i]);
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            BeginMode3D(camera);
            DrawMeshInstanced(cube, material, transforms, instances);
            EndMode3D();

            DrawText("A CUBE OF DANCING CUBES!", 490, 10, 20, Color.MAROON);
            DrawText("PRESS KEYS:", 10, textPositionY, 20, Color.BLACK);

            DrawText("1 - 9", 10, textPositionY += 25, 10, Color.BLACK);
            DrawText(": Number of groups", 50, textPositionY, 10, Color.BLACK);
            DrawText($": {groups}", 160, textPositionY, 10, Color.BLACK);

            DrawText("UP", 10, textPositionY += 15, 10, Color.BLACK);
            DrawText(": increase amplitude", 50, textPositionY, 10, Color.BLACK);
            DrawText($": {amp}%.2f", 160, textPositionY, 10, Color.BLACK);

            DrawText("DOWN", 10, textPositionY += 15, 10, Color.BLACK);
            DrawText(": decrease amplitude", 50, textPositionY, 10, Color.BLACK);

            DrawText("LEFT", 10, textPositionY += 15, 10, Color.BLACK);
            DrawText(": decrease variance", 50, textPositionY, 10, Color.BLACK);
            DrawText($": {variance}.2f", 160, textPositionY, 10, Color.BLACK);

            DrawText("RIGHT", 10, textPositionY += 15, 10, Color.BLACK);
            DrawText(": increase variance", 50, textPositionY, 10, Color.BLACK);

            DrawText("+/=", 10, textPositionY += 15, 10, Color.BLACK);
            DrawText(": increase speed", 50, textPositionY, 10, Color.BLACK);
            DrawText($": {speed} = {((float)fps / speed)} loops/sec", 160, textPositionY, 10, Color.BLACK);

            DrawText("-", 10, textPositionY += 15, 10, Color.BLACK);
            DrawText(": decrease speed", 50, textPositionY, 10, Color.BLACK);

            DrawText("W", 10, textPositionY += 15, 10, Color.BLACK);
            DrawText(": Wild setup!", 50, textPositionY, 10, Color.BLACK);

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
