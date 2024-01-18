/*******************************************************************************************
*
*   raylib [core] example - Picking in 3d mode
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Core;

public class Picking3d
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d picking");

        // Define the camera to look into our 3d world
        Camera3D camera;
        camera.Position = new Vector3(10.0f, 10.0f, 10.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        Vector3 cubePosition = new(0.0f, 1.0f, 0.0f);
        Vector3 cubeSize = new(2.0f, 2.0f, 2.0f);

        // Picking line ray
        Ray ray = new(new Vector3(0.0f, 0.0f, 0.0f), Vector3.Zero);
        RayCollision collision = new();

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.Free);

            if (IsMouseButtonPressed(MouseButton.Left))
            {
                if (!collision.Hit)
                {
                    ray = GetMouseRay(GetMousePosition(), camera);

                    // Check collision between ray and box
                    BoundingBox box = new(
                        cubePosition - cubeSize / 2,
                        cubePosition + cubeSize / 2
                    );
                    collision = GetRayCollisionBox(ray, box);
                }
                else
                {
                    collision.Hit = false;
                }

                ray = GetMouseRay(GetMousePosition(), camera);
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            if (collision.Hit)
            {
                DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Red);
                DrawCubeWires(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Maroon);

                DrawCubeWires(cubePosition, cubeSize.X + 0.2f, cubeSize.Y + 0.2f, cubeSize.Z + 0.2f, Color.Green);
            }
            else
            {
                DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Gray);
                DrawCubeWires(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.DarkGray);
            }

            DrawRay(ray, Color.Maroon);
            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawText("Try selecting the box with mouse!", 240, 10, 20, Color.DarkGray);

            if (collision.Hit)
            {
                int posX = (screenWidth - MeasureText("BOX SELECTED", 30)) / 2;
                DrawText("BOX SELECTED", posX, (int)(screenHeight * 0.1f), 30, Color.Green);
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

