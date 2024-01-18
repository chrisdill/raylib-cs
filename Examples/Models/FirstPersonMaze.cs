/*******************************************************************************************
*
*   raylib [models] example - first person maze
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Models;

public class FirstPersonMaze
{
    public unsafe static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - first person maze");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(0.2f, 0.4f, 0.2f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        Image imMap = LoadImage("resources/cubicmap.png");
        Texture2D cubicmap = LoadTextureFromImage(imMap);
        Mesh mesh = GenMeshCubicmap(imMap, new Vector3(1.0f, 1.0f, 1.0f));
        Model model = LoadModelFromMesh(mesh);

        // NOTE: By default each cube is mapped to one part of texture atlas
        Texture2D texture = LoadTexture("resources/cubicmap_atlas.png");

        // Set map diffuse texture
        Raylib.SetMaterialTexture(ref model, 0, MaterialMapIndex.Albedo, ref texture);

        // Get map image data to be used for collision detection
        Color* mapPixels = LoadImageColors(imMap);
        UnloadImage(imMap);

        Vector3 mapPosition = new(-16.0f, 0.0f, -8.0f);
        Vector3 playerPosition = camera.Position;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            Vector3 oldCamPos = camera.Position;

            UpdateCamera(ref camera, CameraMode.FirstPerson);

            // Check player collision (we simplify to 2D collision detection)
            Vector2 playerPos = new(camera.Position.X, camera.Position.Z);

            // Collision radius (player is modelled as a cilinder for collision)
            float playerRadius = 0.1f;

            int playerCellX = (int)(playerPos.X - mapPosition.X + 0.5f);
            int playerCellY = (int)(playerPos.Y - mapPosition.Z + 0.5f);

            // Out-of-limits security check
            if (playerCellX < 0)
            {
                playerCellX = 0;
            }
            else if (playerCellX >= cubicmap.Width)
            {
                playerCellX = cubicmap.Width - 1;
            }

            if (playerCellY < 0)
            {
                playerCellY = 0;
            }
            else if (playerCellY >= cubicmap.Height)
            {
                playerCellY = cubicmap.Height - 1;
            }

            // Check map collisions using image data and player position
            // TODO: Improvement: Just check player surrounding cells for collision
            for (int y = 0; y < cubicmap.Height; y++)
            {
                for (int x = 0; x < cubicmap.Width; x++)
                {
                    Color* mapPixelsData = mapPixels;

                    // Collision: Color.white pixel, only check R channel
                    Rectangle rec = new(
                        mapPosition.X - 0.5f + x * 1.0f,
                        mapPosition.Z - 0.5f + y * 1.0f,
                        1.0f,
                        1.0f
                    );

                    bool collision = CheckCollisionCircleRec(playerPos, playerRadius, rec);
                    if ((mapPixelsData[y * cubicmap.Width + x].R == 255) && collision)
                    {
                        // Collision detected, reset camera position
                        camera.Position = oldCamPos;
                    }
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            // Draw maze map
            BeginMode3D(camera);
            DrawModel(model, mapPosition, 1.0f, Color.White);
            EndMode3D();

            DrawTextureEx(cubicmap, new Vector2(GetScreenWidth() - cubicmap.Width * 4 - 20, 20), 0.0f, 4.0f, Color.White);
            DrawRectangleLines(GetScreenWidth() - cubicmap.Width * 4 - 20, 20, cubicmap.Width * 4, cubicmap.Height * 4, Color.Green);

            // Draw player position radar
            DrawRectangle(GetScreenWidth() - cubicmap.Width * 4 - 20 + playerCellX * 4, 20 + playerCellY * 4, 4, 4, Color.Red);

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadImageColors(mapPixels);

        UnloadTexture(cubicmap);
        UnloadTexture(texture);
        UnloadModel(model);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
