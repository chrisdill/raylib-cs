using Raylib;
using static Raylib.Raylib;
using static Raylib.CameraType;

public partial class core_3d_mode
{
    /*******************************************************************************************
    *
    *   raylib [core] example - Initialize 3d mode
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
    
        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d mode");
    
        // Define the camera to look into our 3d world
        Camera3D camera;
        camera.position = new Vector3( 0.0f, 10.0f, 10.0f );  // Camera3D position
        camera.target = new Vector3( 0.0f, 0.0f, 0.0f );      // Camera3D looking at point
        camera.up = new Vector3( 0.0f, 1.0f, 0.0f );          // Camera3D up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera3D field-of-view Y
        camera.type = CAMERA_PERSPECTIVE;                   // Camera3D mode type
    
        Vector3 cubePosition = new Vector3( 0.0f, 0.0f, 0.0f );
    
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
    
                    DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, RED);
                    DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, MAROON);
    
                    DrawGrid(10, 1.0f);
    
                EndMode3D();
    
                DrawText("Welcome to the third dimension!", 10, 40, 20, DARKGRAY);
    
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
