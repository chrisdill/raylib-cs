using Raylib;
using static Raylib.Raylib;
using static Raylib.CameraType;
using static Raylib.CameraMode;

public partial class models_orthographic_projection
{
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


    public const float FOVY_PERSPECTIVE = 45.0f;
    public const float WIDTH_ORTHOGRAPHIC = 10.0f;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D(new Vector3( 0.0f, 10.0f, 10.0f ), new Vector3( 0.0f, 0.0f, 0.0f ), new Vector3( 0.0f, 1.0f, 0.0f ), FOVY_PERSPECTIVE, CAMERA_PERSPECTIVE );

        SetTargetFPS(60);   // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                if (camera.type == CAMERA_PERSPECTIVE)
                {
                    camera.fovy = WIDTH_ORTHOGRAPHIC;
                    camera.type = CAMERA_ORTHOGRAPHIC;
                }
                else
                {
                    camera.fovy = FOVY_PERSPECTIVE;
                    camera.type = CAMERA_PERSPECTIVE;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

                ClearBackground(RAYWHITE);

                BeginMode3D(camera);

                    DrawCube(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, RED);
                    DrawCubeWires(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, GOLD);
                    DrawCubeWires(new Vector3(-4.0f, 0.0f, -2.0f), 3.0f, 6.0f, 2.0f, MAROON);

                    DrawSphere(new Vector3(-1.0f, 0.0f, -2.0f), 1.0f, GREEN);
                    DrawSphereWires(new Vector3(1.0f, 0.0f, 2.0f), 2.0f, 16, 16, LIME);

                    DrawCylinder(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, SKYBLUE);
                    DrawCylinderWires(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, DARKBLUE);
                    DrawCylinderWires(new Vector3(4.5f, -1.0f, 2.0f), 1.0f, 1.0f, 2.0f, 6, BROWN);

                    DrawCylinder(new Vector3(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, GOLD);
                    DrawCylinderWires(new Vector3(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, PINK);

                    DrawGrid(10, 1.0f);        // Draw a grid

                EndMode3D();

                DrawText("Press Spacebar to switch camera type", 10, GetScreenHeight() - 30, 20, DARKGRAY);

                if (camera.type == CAMERA_ORTHOGRAPHIC) DrawText("ORTHOGRAPHIC", 10, 40, 20, BLACK);
                else if (camera.type == CAMERA_PERSPECTIVE) DrawText("PERSPECTIVE", 10, 40, 20, BLACK);

                DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();        // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
