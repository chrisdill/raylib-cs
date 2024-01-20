/*******************************************************************************************
*
*   raylib [shaders] example - Simple shader mask
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@codifies) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Chris Camacho (@codifies) and Ramon Santamaria (@raysan5)
*
********************************************************************************************
*
*   After a model is loaded it has a default material, this material can be
*   modified in place rather than creating one from scratch...
*   While all of the maps have particular names, they can be used for any purpose
*   except for three maps that are applied as cubic maps (see below)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Raymath;

namespace Examples.Shaders;

public class SimpleMask
{
    public unsafe static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib - simple shader mask");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(0.0f, 1.0f, 2.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        // Define our three models to show the shader on
        Mesh torus = GenMeshTorus(.3f, 1, 16, 32);
        Model model1 = LoadModelFromMesh(torus);

        Mesh cube = GenMeshCube(.8f, .8f, .8f);
        Model model2 = LoadModelFromMesh(cube);

        // Generate model to be shaded just to see the gaps in the other two
        Mesh sphere = GenMeshSphere(1, 16, 16);
        Model model3 = LoadModelFromMesh(sphere);

        // Load the shader
        Shader shader = LoadShader("resources/shaders/glsl330/mask.vs", "resources/shaders/glsl330/mask.fs");

        // Load and apply the diffuse texture (colour map)
        Texture2D texDiffuse = LoadTexture("resources/plasma.png");

        Material* materials = model1.Materials;
        MaterialMap* maps = materials[0].Maps;
        model1.Materials[0].Maps[(int)MaterialMapIndex.Albedo].Texture = texDiffuse;

        materials = model2.Materials;
        maps = materials[0].Maps;
        maps[(int)MaterialMapIndex.Albedo].Texture = texDiffuse;

        // Using MAP_EMISSION as a spare slot to use for 2nd texture
        // NOTE: Don't use MAP_IRRADIANCE, MAP_PREFILTER or  MAP_CUBEMAP
        // as they are bound as cube maps
        Texture2D texMask = LoadTexture("resources/mask.png");

        materials = model1.Materials;
        maps = (MaterialMap*)materials[0].Maps;
        maps[(int)MaterialMapIndex.Emission].Texture = texMask;

        materials = model2.Materials;
        maps = (MaterialMap*)materials[0].Maps;
        maps[(int)MaterialMapIndex.Emission].Texture = texMask;

        int* locs = shader.Locs;
        locs[(int)ShaderLocationIndex.MapEmission] = GetShaderLocation(shader, "mask");

        // Frame is incremented each frame to animate the shader
        int shaderFrame = GetShaderLocation(shader, "framesCounter");

        // Apply the shader to the two models
        materials = model1.Materials;
        materials[0].Shader = shader;

        materials = (Material*)model2.Materials;
        materials[0].Shader = shader;

        int framesCounter = 0;

        // Model rotation angles
        Vector3 rotation = new(0, 0, 0);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            framesCounter++;
            rotation.X += 0.01f;
            rotation.Y += 0.005f;
            rotation.Z -= 0.0025f;

            // Send frames counter to shader for animation
            Raylib.SetShaderValue(shader, shaderFrame, framesCounter, ShaderUniformDataType.Int);

            // Rotate one of the models
            model1.Transform = MatrixRotateXYZ(rotation);

            UpdateCamera(ref camera, CameraMode.Custom);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.DarkBlue);

            BeginMode3D(camera);

            DrawModel(model1, new Vector3(0.5f, 0, 0), 1, Color.White);
            DrawModelEx(model2, new Vector3(-.5f, 0, 0), new Vector3(1, 1, 0), 50, new Vector3(1, 1, 1), Color.White);
            DrawModel(model3, new Vector3(0, 0, -1.5f), 1, Color.White);
            DrawGrid(10, 1.0f);

            EndMode3D();

            string frameText = $"Frame: {framesCounter}";
            DrawRectangle(16, 698, MeasureText(frameText, 20) + 8, 42, Color.Blue);
            DrawText(frameText, 20, 700, 20, Color.White);

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadModel(model1);
        UnloadModel(model2);
        UnloadModel(model3);

        UnloadTexture(texDiffuse);
        UnloadTexture(texMask);

        UnloadShader(shader);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
