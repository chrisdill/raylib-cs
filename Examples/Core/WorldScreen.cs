/*******************************************************************************************
*
*   raylib [core] example - World to screen
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

public class WorldScreen
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera free");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(10.0f, 10.0f, 10.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        Vector3 cubePosition = new(0.0f, 0.0f, 0.0f);
        Vector2 cubeScreenPosition;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.Free);

            // Calculate cube screen space position (with a little offset to be in top)
            cubeScreenPosition = GetWorldToScreen(
                new Vector3(cubePosition.X, cubePosition.Y + 2.5f, cubePosition.Z),
                camera
            );
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Color.Red);
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Color.Maroon);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawText(
                "Enemy: 100 / 100",
                (int)cubeScreenPosition.X - MeasureText("Enemy: 100 / 100", 20) / 2,
                (int)cubeScreenPosition.Y,
                20,
                Color.Black
            );
            DrawText(
                "Text is always on top of the cube",
                (screenWidth - MeasureText("Text is always on top of the cube", 20)) / 2,
                25,
                20,
                Color.Gray
            );

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

