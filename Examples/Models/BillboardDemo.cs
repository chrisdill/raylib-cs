/*******************************************************************************************
*
*   raylib [models] example - Drawing billboards
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

public class BillboardDemo
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - drawing billboards");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(5.0f, 4.0f, 5.0f);
        camera.Target = new Vector3(0.0f, 2.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        // Our texture billboard
        Texture2D bill = LoadTexture("resources/billboard.png");

        // Position of billboard billboard
        Vector3 billPositionStatic = new(0.0f, 2.0f, 0.0f);
        Vector3 billPositionRotating = new(1.0f, 2.0f, 1.0f);

        // Entire billboard texture, source is used to take a segment from a larger texture.
        Rectangle source = new(0.0f, 0.0f, (float)bill.Width, (float)bill.Height);

        // NOTE: Billboard locked on axis-Y
        Vector3 billUp = new(0.0f, 1.0f, 0.0f);

        // Rotate around origin
        // Here we choose to rotate around the image center
        // NOTE: (-1, 1) is the range where origin.X, origin.Y is inside the texture
        Vector2 rotateOrigin = Vector2.Zero;

        // Distance is needed for the correct billboard draw order
        // Larger distance (further away from the camera) should be drawn prior to smaller distance.
        float distanceStatic = 0.0f;
        float distanceRotating = 0.0f;

        float rotation = 0.0f;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.Orbital);
            rotation += 0.4f;
            distanceStatic = Vector3.Distance(camera.Position, billPositionStatic);
            distanceRotating = Vector3.Distance(camera.Position, billPositionRotating);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            DrawGrid(10, 1.0f);

            // Draw order matters!
            if (distanceStatic > distanceRotating)
            {
                DrawBillboard(camera, bill, billPositionStatic, 2.0f, Color.White);
                DrawBillboardPro(
                    camera,
                    bill,
                    source,
                    billPositionRotating,
                    billUp,
                    new Vector2(1.0f, 1.0f),
                    rotateOrigin,
                    rotation,
                    Color.White
                );
            }
            else
            {
                DrawBillboardPro(
                    camera,
                    bill,
                    source,
                    billPositionRotating,
                    billUp,
                    new Vector2(1.0f, 1.0f),
                    rotateOrigin,
                    rotation,
                    Color.White
                );
                DrawBillboard(camera, bill, billPositionStatic, 2.0f, Color.White);
            }

            EndMode3D();

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(bill);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}

