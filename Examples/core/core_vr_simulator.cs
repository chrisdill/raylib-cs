using Raylib;
using static Raylib.Raylib;
using static Raylib.CameraType;
using static Raylib.CameraMode;
using static Raylib.VrDeviceType;

public partial class core_vr_simulator
{
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


    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 1080;
        int screenHeight = 600;

        // NOTE: screenWidth/screenHeight should match VR device aspect ratio

        InitWindow(screenWidth, screenHeight, "raylib [core] example - vr simulator");

        // Init VR simulator (Oculus Rift CV1 parameters)
        // fails?
        var a = GetVrDeviceInfo((int)HMD_OCULUS_RIFT_CV1);
        InitVrSimulator(GetVrDeviceInfo((int)HMD_OCULUS_RIFT_CV1));

        // Define the camera to look into our 3d world
        Camera3D camera;
        camera.position = new Vector3( 5.0f, 2.0f, 5.0f );    // Camera3D position
        camera.target = new Vector3( 0.0f, 2.0f, 0.0f );      // Camera3D looking at point
        camera.up = new Vector3( 0.0f, 1.0f, 0.0f );          // Camera3D up vector (rotation towards target)
        camera.fovy = 60.0f;                                // Camera3D field-of-view Y
        camera.type = (int)CAMERA_PERSPECTIVE;                   // Camera3D type

        Vector3 cubePosition = new Vector3( 0.0f, 0.0f, 0.0f );

        SetCameraMode(camera, (int)CAMERA_FIRST_PERSON);         // Set first person camera mode

        SetTargetFPS(90);                   // Set our game to run at 90 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera);          // Update camera (simulator mode)

            if (IsKeyPressed(KEY_SPACE)) ToggleVrMode();    // Toggle VR mode
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

                ClearBackground(RAYWHITE);

                BeginVrDrawing();

                    BeginMode3D(camera);

                        DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, RED);
                        DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, MAROON);

                        DrawGrid(40, 1.0f);

                    EndMode3D();

                EndVrDrawing();

                DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseVrSimulator();     // Close VR simulator

        CloseWindow();          // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
