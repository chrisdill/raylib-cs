/*******************************************************************************************
*
*   raylib [models] example - Detect basic 3d collisions (box vs sphere vs box)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Models;

public class BoxCollisions
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - box collisions");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(0.0f, 10.0f, 10.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        Vector3 playerPosition = new(0.0f, 1.0f, 2.0f);
        Vector3 playerSize = new(1.0f, 2.0f, 1.0f);
        Color playerColor = Color.Green;

        Vector3 enemyBoxPos = new(-4.0f, 1.0f, 0.0f);
        Vector3 enemyBoxSize = new(2.0f, 2.0f, 2.0f);

        Vector3 enemySpherePos = new(4.0f, 0.0f, 0.0f);
        float enemySphereSize = 1.5f;

        bool collision = false;

        SetTargetFPS(60);   // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------

            // Move player
            if (IsKeyDown(KeyboardKey.Right))
            {
                playerPosition.X += 0.2f;
            }
            else if (IsKeyDown(KeyboardKey.Left))
            {
                playerPosition.X -= 0.2f;
            }
            else if (IsKeyDown(KeyboardKey.Down))
            {
                playerPosition.Z += 0.2f;
            }
            else if (IsKeyDown(KeyboardKey.Up))
            {
                playerPosition.Z -= 0.2f;
            }

            collision = false;

            // Check collisions player vs enemy-box
            BoundingBox box1 = new(
                playerPosition - (playerSize / 2),
                playerPosition + (playerSize / 2)
            );
            BoundingBox box2 = new(
                enemyBoxPos - (enemyBoxSize / 2),
                enemyBoxPos + (enemyBoxSize / 2)
            );

            if (CheckCollisionBoxes(box1, box2))
            {
                collision = true;
            }

            // Check collisions player vs enemy-sphere
            if (CheckCollisionBoxSphere(box1, enemySpherePos, enemySphereSize))
            {
                collision = true;
            }

            if (collision)
            {
                playerColor = Color.Red;
            }
            else
            {
                playerColor = Color.Green;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            // Draw enemy-box
            DrawCube(enemyBoxPos, enemyBoxSize.X, enemyBoxSize.Y, enemyBoxSize.Z, Color.Gray);
            DrawCubeWires(enemyBoxPos, enemyBoxSize.X, enemyBoxSize.Y, enemyBoxSize.Z, Color.DarkGray);

            // Draw enemy-sphere
            DrawSphere(enemySpherePos, enemySphereSize, Color.Gray);
            DrawSphereWires(enemySpherePos, enemySphereSize, 16, 16, Color.DarkGray);

            // Draw player
            DrawCubeV(playerPosition, playerSize, playerColor);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawText("Move player with cursors to collide", 220, 40, 20, Color.Gray);
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
