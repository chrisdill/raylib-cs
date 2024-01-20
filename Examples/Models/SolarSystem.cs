/*******************************************************************************************
*
*   raylib [models] example - rlgl module usage with push/pop matrix transformations
*
*   This example uses [rlgl] module funtionality (pseudo-OpenGL 1.1 style coding)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2018 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Models;

public class SolarSystem
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        const float sunRadius = 4.0f;
        const float earthRadius = 0.6f;
        const float earthOrbitRadius = 8.0f;
        const float moonRadius = 0.16f;
        const float moonOrbitRadius = 1.5f;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - rlgl module usage with push/pop matrix transformations");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(16.0f, 16.0f, 16.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        // General system rotation speed
        float rotationSpeed = 0.2f;
        // Rotation of earth around itself (days) in degrees
        float earthRotation = 0.0f;
        // Rotation of earth around the Sun (years) in degrees
        float earthOrbitRotation = 0.0f;
        // Rotation of moon around itself
        float moonRotation = 0.0f;
        // Rotation of moon around earth in degrees
        float moonOrbitRotation = 0.0f;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.Free);

            earthRotation += (5.0f * rotationSpeed);
            earthOrbitRotation += (365 / 360.0f * (5.0f * rotationSpeed) * rotationSpeed);
            moonRotation += (2.0f * rotationSpeed);
            moonOrbitRotation += (8.0f * rotationSpeed);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            Rlgl.PushMatrix();
            // Scale Sun
            Rlgl.Scalef(sunRadius, sunRadius, sunRadius);
            // Draw the Sun
            DrawSphereBasic(Color.Gold);
            Rlgl.PopMatrix();

            Rlgl.PushMatrix();
            // Rotation for Earth orbit around Sun
            Rlgl.Rotatef(earthOrbitRotation, 0.0f, 1.0f, 0.0f);
            // Translation for Earth orbit
            Rlgl.Translatef(earthOrbitRadius, 0.0f, 0.0f);
            // Rotation for Earth orbit around Sun inverted
            Rlgl.Rotatef(-earthOrbitRotation, 0.0f, 1.0f, 0.0f);

            Rlgl.PushMatrix();
            // Rotation for Earth itself
            Rlgl.Rotatef(earthRotation, 0.25f, 1.0f, 0.0f);
            // Scale Earth
            Rlgl.Scalef(earthRadius, earthRadius, earthRadius);

            // Draw the Earth
            DrawSphereBasic(Color.Blue);
            Rlgl.PopMatrix();

            // Rotation for Moon orbit around Earth
            Rlgl.Rotatef(moonOrbitRotation, 0.0f, 1.0f, 0.0f);
            // Translation for Moon orbit
            Rlgl.Translatef(moonOrbitRadius, 0.0f, 0.0f);
            // Rotation for Moon orbit around Earth inverted
            Rlgl.Rotatef(-moonOrbitRotation, 0.0f, 1.0f, 0.0f);
            // Rotation for Moon itself
            Rlgl.Rotatef(moonRotation, 0.0f, 1.0f, 0.0f);
            // Scale Moon
            Rlgl.Scalef(moonRadius, moonRadius, moonRadius);

            // Draw the Moon
            DrawSphereBasic(Color.LightGray);
            Rlgl.PopMatrix();

            // Some reference elements (not affected by previous matrix transformations)
            DrawCircle3D(
                new Vector3(0.0f, 0.0f, 0.0f),
                earthOrbitRadius,
                new Vector3(1, 0, 0),
                90.0f,
                ColorAlpha(Color.Red, 0.5f)
            );
            DrawGrid(20, 1.0f);

            EndMode3D();

            DrawText("EARTH ORBITING AROUND THE SUN!", 400, 10, 20, Color.Maroon);
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

    // Draw sphere without any matrix transformation
    // NOTE: Sphere is drawn in world position ( 0, 0, 0 ) with radius 1.0f
    static void DrawSphereBasic(Color color)
    {
        int rings = 16;
        int slices = 16;

        Rlgl.Begin(DrawMode.Triangles);
        Rlgl.Color4ub(color.R, color.G, color.B, color.A);

        for (int i = 0; i < (rings + 2); i++)
        {
            for (int j = 0; j < slices; j++)
            {
                Rlgl.Vertex3f(
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Sin(DEG2RAD * (j * 360 / slices)),
                    MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Cos(DEG2RAD * (j * 360 / slices))
                );
                Rlgl.Vertex3f(
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Sin(DEG2RAD * ((j + 1) * 360 / slices)),
                    MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Cos(DEG2RAD * ((j + 1) * 360 / slices))
                );
                Rlgl.Vertex3f(
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Sin(DEG2RAD * (j * 360 / slices)),
                    MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Cos(DEG2RAD * (j * 360 / slices))
                );

                Rlgl.Vertex3f(
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Sin(DEG2RAD * (j * 360 / slices)),
                    MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Cos(DEG2RAD * (j * 360 / slices))
                );
                Rlgl.Vertex3f(
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * MathF.Sin(DEG2RAD * ((j + 1) * 360 / slices)),
                    MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i))),
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * MathF.Cos(DEG2RAD * ((j + 1) * 360 / slices))
                );
                Rlgl.Vertex3f(
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Sin(DEG2RAD * ((j + 1) * 360 / slices)),
                    MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
                    MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Cos(DEG2RAD * ((j + 1) * 360 / slices))
                );
            }
        }
        Rlgl.End();
    }
}

