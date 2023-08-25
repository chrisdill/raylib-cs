/*******************************************************************************************
*
*   raylib [models] example - Show the difference between perspective and orthographic projection
*
*   This program is heavily based on the geometric objects example
*
*   This example has been created using raylib 1.9.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2018 Max Danielsson ref Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Models;

public class OrthographicProjection
{
    public const float FOVY_PERSPECTIVE = 45.0f;
    public const float WIDTH_ORTHOGRAPHIC = 10.0f;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(0.0f, 10.0f, 10.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = FOVY_PERSPECTIVE;
        camera.Projection = CameraProjection.CAMERA_PERSPECTIVE;

        SetTargetFPS(60);   // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                if (camera.Projection == CameraProjection.CAMERA_PERSPECTIVE)
                {
                    camera.FovY = WIDTH_ORTHOGRAPHIC;
                    camera.Projection = CameraProjection.CAMERA_ORTHOGRAPHIC;
                }
                else
                {
                    camera.FovY = FOVY_PERSPECTIVE;
                    camera.Projection = CameraProjection.CAMERA_PERSPECTIVE;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            BeginMode3D(camera);

            DrawCube(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Color.RED);
            DrawCubeWires(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Color.GOLD);
            DrawCubeWires(new Vector3(-4.0f, 0.0f, -2.0f), 3.0f, 6.0f, 2.0f, Color.MAROON);

            DrawSphere(new Vector3(-1.0f, 0.0f, -2.0f), 1.0f, Color.GREEN);
            DrawSphereWires(new Vector3(1.0f, 0.0f, 2.0f), 2.0f, 16, 16, Color.LIME);

            DrawCylinder(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Color.SKYBLUE);
            DrawCylinderWires(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Color.DARKBLUE);
            DrawCylinderWires(new Vector3(4.5f, -1.0f, 2.0f), 1.0f, 1.0f, 2.0f, 6, Color.BROWN);

            DrawCylinder(new Vector3(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Color.GOLD);
            DrawCylinderWires(new Vector3(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Color.PINK);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawText("Press Spacebar to switch camera type", 10, GetScreenHeight() - 30, 20, Color.DARKGRAY);

            if (camera.Projection == CameraProjection.CAMERA_ORTHOGRAPHIC)
            {
                DrawText("ORTHOGRAPHIC", 10, 40, 20, Color.BLACK);
            }
            else if (camera.Projection == CameraProjection.CAMERA_PERSPECTIVE)
            {
                DrawText("PERSPECTIVE", 10, 40, 20, Color.BLACK);
            }

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
