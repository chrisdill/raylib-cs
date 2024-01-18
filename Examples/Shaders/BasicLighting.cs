/*******************************************************************************************
*
*   raylib [shaders] example - basic lighting
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@codifies) and reviewed by Ramon Santamaria (@raysan5)
*
*   Chris Camacho (@codifies -  http://bedroomcoders.co.uk/) notes:
*
*   This is based on the PBR lighting example, but greatly simplified to aid learning...
*   actually there is very little of the PBR example left!
*   When I first looked at the bewildering complexity of the PBR example I feared
*   I would never understand how I could do simple lighting with raylib however its
*   a testement to the authors of raylib (including rlights.h) that the example
*   came together fairly quickly.
*
*   Copyright (c) 2019 Chris Camacho (@codifies) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;
using Examples.Shared;

namespace Examples.Shaders;

public class BasicLighting
{
    const int GLSL_VERSION = 330;

    public unsafe static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Enable Multi Sampling Anti Aliasing 4x (if available)
        SetConfigFlags(ConfigFlags.Msaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - basic lighting");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(2.0f, 4.0f, 6.0f);
        camera.Target = new Vector3(0.0f, 0.5f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        // Load plane model from a generated mesh
        Model model = LoadModelFromMesh(GenMeshPlane(10.0f, 10.0f, 3, 3));
        Model cube = LoadModelFromMesh(GenMeshCube(2.0f, 4.0f, 2.0f));

        Shader shader = LoadShader(
            "resources/shaders/glsl330/lighting.vs",
            "resources/shaders/glsl330/lighting.fs"
        );

        // Get some required shader loactions
        shader.Locs[(int)ShaderLocationIndex.VectorView] = GetShaderLocation(shader, "viewPos");

        // ambient light level
        int ambientLoc = GetShaderLocation(shader, "ambient");
        float[] ambient = new[] { 0.1f, 0.1f, 0.1f, 1.0f };
        Raylib.SetShaderValue(shader, ambientLoc, ambient, ShaderUniformDataType.Vec4);

        // Assign out lighting shader to model
        model.Materials[0].Shader = shader;
        cube.Materials[0].Shader = shader;

        // Using 4 point lights: Color.gold, Color.red, Color.green and Color.blue
        Light[] lights = new Light[4];
        lights[0] = Rlights.CreateLight(
            0,
            LightType.Point,
            new Vector3(-2, 1, -2),
            Vector3.Zero,
            Color.Yellow,
            shader
        );
        lights[1] = Rlights.CreateLight(
            1,
            LightType.Point,
            new Vector3(2, 1, 2),
            Vector3.Zero,
            Color.Red,
            shader
        );
        lights[2] = Rlights.CreateLight(
            2,
            LightType.Point,
            new Vector3(-2, 1, 2),
            Vector3.Zero,
            Color.Green,
            shader
        );
        lights[3] = Rlights.CreateLight(
            3,
            LightType.Point,
            new Vector3(2, 1, -2),
            Vector3.Zero,
            Color.Blue,
            shader
        );

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.Orbital);

            if (IsKeyPressed(KeyboardKey.Y))
            {
                lights[0].Enabled = !lights[0].Enabled;
            }
            if (IsKeyPressed(KeyboardKey.R))
            {
                lights[1].Enabled = !lights[1].Enabled;
            }
            if (IsKeyPressed(KeyboardKey.G))
            {
                lights[2].Enabled = !lights[2].Enabled;
            }
            if (IsKeyPressed(KeyboardKey.B))
            {
                lights[3].Enabled = !lights[3].Enabled;
            }

            // Update light values (actually, only enable/disable them)
            Rlights.UpdateLightValues(shader, lights[0]);
            Rlights.UpdateLightValues(shader, lights[1]);
            Rlights.UpdateLightValues(shader, lights[2]);
            Rlights.UpdateLightValues(shader, lights[3]);

            // Update the light shader with the camera view position
            Raylib.SetShaderValue(
                shader,
                shader.Locs[(int)ShaderLocationIndex.VectorView],
                camera.Position,
                ShaderUniformDataType.Vec3
            );
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            DrawModel(model, Vector3.Zero, 1.0f, Color.White);
            DrawModel(cube, Vector3.Zero, 1.0f, Color.White);

            // Draw markers to show where the lights are
            if (lights[0].Enabled)
            {
                DrawSphereEx(lights[0].Position, 0.2f, 8, 8, Color.Yellow);
            }
            else
            {
                DrawSphereWires(lights[0].Position, 0.2f, 8, 8, ColorAlpha(Color.Yellow, 0.3f));
            }

            if (lights[1].Enabled)
            {
                DrawSphereEx(lights[1].Position, 0.2f, 8, 8, Color.Red);
            }
            else
            {
                DrawSphereWires(lights[1].Position, 0.2f, 8, 8, ColorAlpha(Color.Red, 0.3f));
            }

            if (lights[2].Enabled)
            {
                DrawSphereEx(lights[2].Position, 0.2f, 8, 8, Color.Green);
            }
            else
            {
                DrawSphereWires(lights[2].Position, 0.2f, 8, 8, ColorAlpha(Color.Green, 0.3f));
            }

            if (lights[3].Enabled)
            {
                DrawSphereEx(lights[3].Position, 0.2f, 8, 8, Color.Blue);
            }
            else
            {
                DrawSphereWires(lights[3].Position, 0.2f, 8, 8, ColorAlpha(Color.Blue, 0.3f));
            }

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawFPS(10, 10);
            DrawText("Use keys [Y][R][G][B] to toggle lights", 10, 40, 20, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadModel(model);
        UnloadModel(cube);
        UnloadShader(shader);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
