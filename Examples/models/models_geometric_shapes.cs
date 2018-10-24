using Raylib;
using static Raylib.Raylib;
using static Raylib.CameraType;

public partial class models_geometric_shapes
{
    /*******************************************************************************************
    *
    *   raylib [models] example - Draw some basic geometric shapes (cube, sphere, cylinder...)
    *
    *   This example has been created using raylib 1.0 (www.raylib.com)
    *   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
    *
    *   Copyright (c) 2014 Ramon Santamaria (@raysan5)
    *
    ********************************************************************************************/


    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D();
        camera.position = new Vector3( 0.0f, 10.0f, 10.0f );
        camera.target = new Vector3( 0.0f, 0.0f, 0.0f );
        camera.up = new Vector3( 0.0f, 1.0f, 0.0f );
        camera.fovy = 45.0f;
        camera.type = CAMERA_PERSPECTIVE;

        SetTargetFPS(60);   // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
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
