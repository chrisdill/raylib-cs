using Raylib;
using static Raylib.Raylib;
using static Raylib.CameraType;
using static Raylib.CameraMode;

public partial class core_world_screen
{
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


    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera free");

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D();
        camera.position = new Vector3( 10.0f, 10.0f, 10.0f );
        camera.target = new Vector3( 0.0f, 0.0f, 0.0f );
        camera.up = new Vector3( 0.0f, 1.0f, 0.0f );
        camera.fovy = 45.0f;
        camera.type = (int)CAMERA_PERSPECTIVE;

        Vector3 cubePosition = new Vector3( 0.0f, 0.0f, 0.0f );

        Vector2 cubeScreenPosition;

        SetCameraMode(camera, (int)CAMERA_FREE); // Set a free camera mode

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera);          // Update camera

            // Calculate cube screen space position (with a little offset to be in top)
            cubeScreenPosition = GetWorldToScreen(new Vector3(cubePosition.x, cubePosition.y + 2.5f, cubePosition.z), camera);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

                ClearBackground(RAYWHITE);

                BeginMode3D(camera);

                    DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, RED);
                    DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, MAROON);

                    DrawGrid(10, 1.0f);

                EndMode3D();

                DrawText("Enemy: 100 / 100", (int)cubeScreenPosition.x - MeasureText("Enemy: 100 / 100", 20) / 2, (int)cubeScreenPosition.y, 20, BLACK);
                DrawText("Text is always on top of the cube", (screenWidth - MeasureText("Text is always on top of the cube", 20)) / 2, 25, 20, GRAY);

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
