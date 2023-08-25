/*******************************************************************************************
*
*   raylib [core] example - VR Simulator (Oculus Rift CV1 parameters)
*
*   This example has been created using raylib 1.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Core;

public class VrSimulator
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 1080;
        const int screenHeight = 600;

        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - vr simulator");

        // VR device parameters definition
        VrDeviceInfo device = new VrDeviceInfo
        {
            // Oculus Rift CV1 parameters for simulator
            HResolution = 2160,
            VResolution = 1200,
            HScreenSize = 0.133793f,
            VScreenSize = 0.0669f,
            VScreenCenter = 0.04678f,
            EyeToScreenDistance = 0.041f,
            LensSeparationDistance = 0.07f,
            InterpupillaryDistance = 0.07f,
        };

        // NOTE: CV1 uses a Fresnel-hybrid-asymmetric lenses with specific distortion compute shaders.
        // Following parameters are an approximation to distortion stereo rendering but results differ from actual
        // device.
        unsafe
        {
            device.LensDistortionValues[0] = 1.0f;
            device.LensDistortionValues[1] = 0.22f;
            device.LensDistortionValues[2] = 0.24f;
            device.LensDistortionValues[3] = 0.0f;
            device.ChromaAbCorrection[0] = 0.996f;
            device.ChromaAbCorrection[1] = -0.004f;
            device.ChromaAbCorrection[2] = 1.014f;
            device.ChromaAbCorrection[3] = 0.0f;
        }

        // Load VR stereo config for VR device parameteres (Oculus Rift CV1 parameters)
        VrStereoConfig config = LoadVrStereoConfig(device);

        // Distortion shader (uses device lens distortion and chroma)
        Shader distortion = LoadShader(null, "resources/distortion330.fs");

        // Update distortion shader with lens and distortion-scale parameters
        Raylib.SetShaderValue(
            distortion,
            GetShaderLocation(distortion, "leftLensCenter"),
            config.LeftLensCenter,
            ShaderUniformDataType.SHADER_UNIFORM_VEC2
        );
        Raylib.SetShaderValue(
            distortion,
            GetShaderLocation(distortion, "rightLensCenter"),
            config.RightLensCenter,
            ShaderUniformDataType.SHADER_UNIFORM_VEC2
        );
        Raylib.SetShaderValue(
            distortion,
            GetShaderLocation(distortion, "leftScreenCenter"),
            config.LeftScreenCenter,
            ShaderUniformDataType.SHADER_UNIFORM_VEC2
        );
        Raylib.SetShaderValue(
            distortion,
            GetShaderLocation(distortion, "rightScreenCenter"),
            config.RightScreenCenter,
            ShaderUniformDataType.SHADER_UNIFORM_VEC2
        );

        Raylib.SetShaderValue(
            distortion,
            GetShaderLocation(distortion, "scale"),
            config.Scale,
            ShaderUniformDataType.SHADER_UNIFORM_VEC2
        );
        Raylib.SetShaderValue(
            distortion,
            GetShaderLocation(distortion, "scaleIn"),
            config.ScaleIn,
            ShaderUniformDataType.SHADER_UNIFORM_VEC2
        );

        unsafe
        {
            SetShaderValue(
                distortion,
                GetShaderLocation(distortion, "deviceWarpParam"),
                device.LensDistortionValues,
                ShaderUniformDataType.SHADER_UNIFORM_VEC4
            );
            SetShaderValue(
                distortion,
                GetShaderLocation(distortion, "chromaAbParam"),
                device.ChromaAbCorrection,
                ShaderUniformDataType.SHADER_UNIFORM_VEC4
            );
        }

        // Initialize framebuffer for stereo rendering
        // NOTE: Screen size should match HMD aspect ratio
        RenderTexture2D target = LoadRenderTexture(GetScreenWidth(), GetScreenHeight());

        // Define the camera to look into our 3d world
        Camera3D camera;
        camera.Position = new Vector3(5.0f, 2.0f, 5.0f);
        camera.Target = new Vector3(0.0f, 2.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 60.0f;
        camera.Projection = CameraProjection.CAMERA_PERSPECTIVE;

        Vector3 cubePosition = new(0.0f, 0.0f, 0.0f);

        SetTargetFPS(90);                   // Set our game to run at 90 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.CAMERA_FIRST_PERSON);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            BeginTextureMode(target);
            ClearBackground(Color.RAYWHITE);

            BeginVrStereoMode(config);
            BeginMode3D(camera);

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Color.RED);
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Color.MAROON);
            DrawGrid(40, 1.0f);

            EndMode3D();
            EndVrStereoMode();
            EndTextureMode();

            BeginShaderMode(distortion);
            DrawTextureRec(
                target.Texture,
                new Rectangle(0, 0, (float)target.Texture.Width, (float)-target.Texture.Height),
                new Vector2(0.0f, 0.0f),
                Color.WHITE
            );
            EndShaderMode();

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadVrStereoConfig(config);
        UnloadRenderTexture(target);
        UnloadShader(distortion);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}

