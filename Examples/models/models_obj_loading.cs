using Raylib;
using static Raylib.Raylib;
using static Raylib.CameraType;
using static Raylib.TexmapIndex;

public partial class models_obj_loading
{
    /*******************************************************************************************
    *
    *   raylib [models] example - Load and draw a 3d model (OBJ)
    *
    *   This example has been created using raylib 1.3 (www.raylib.com)
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

        InitWindow(screenWidth, screenHeight, "raylib [models] example - obj model loading");

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D();
        camera.position = new Vector3( 8.0f, 8.0f, 8.0f );    // Camera3D position
        camera.target = new Vector3( 0.0f, 2.5f, 0.0f );      // Camera3D looking at point
        camera.up = new Vector3( 0.0f, 1.0f, 0.0f );          // Camera3D up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera3D field-of-view Y
        camera.type = CAMERA_PERSPECTIVE;                   // Camera3D mode type

        Model model = LoadModel("resources/models/castle.obj");                 // Load OBJ model
        Texture2D texture = LoadTexture("resources/models/castle_diffuse.png"); // Load model texture
        model.material.maps[(int)MAP_ALBEDO].texture = texture;                     // Set map diffuse texture
        Vector3 position = new Vector3( 0.0f, 0.0f, 0.0f );                                // Set model position

        SetTargetFPS(60);   // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            //...
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

                ClearBackground(RAYWHITE);

                BeginMode3D(camera);

                    DrawModel(model, position, 0.2f, WHITE);   // Draw 3d model with texture

                    DrawGrid(10, 1.0f);         // Draw a grid

                    DrawGizmo(position);        // Draw gizmo

                EndMode3D();

                DrawText("(c) Castle 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, GRAY);

                DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texture);     // Unload texture
        UnloadModel(model);         // Unload model

        CloseWindow();              // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
