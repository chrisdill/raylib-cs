/*******************************************************************************************
*
*   raylib [models] example - Mesh picking in 3d mode, ground plane, triangle, mesh
*
*   This example has been created using raylib 1.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*   Example contributed by Joel Davis (@joeld42)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Raymath;

namespace Examples.Models;

public class MeshPicking
{
    public unsafe static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh picking");

        // Define the camera to look into our 3d world
        Camera3D camera;
        camera.Position = new Vector3(20.0f, 20.0f, 20.0f);
        camera.Target = new Vector3(0.0f, 8.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.6f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.CAMERA_PERSPECTIVE;

        // Picking ray
        Ray ray = new();

        Model tower = LoadModel("resources/models/obj/turret.obj");
        Texture2D texture = LoadTexture("resources/models/obj/turret_diffuse.png");
        Raylib.SetMaterialTexture(ref tower, 0, MaterialMapIndex.MATERIAL_MAP_ALBEDO, ref texture);

        Vector3 towerPos = new(0.0f, 0.0f, 0.0f);
        BoundingBox towerBBox = GetMeshBoundingBox(tower.Meshes[0]);

        // Ground quad
        Vector3 g0 = new(-50.0f, 0.0f, -50.0f);
        Vector3 g1 = new(-50.0f, 0.0f, 50.0f);
        Vector3 g2 = new(50.0f, 0.0f, 50.0f);
        Vector3 g3 = new(50.0f, 0.0f, -50.0f);

        // Test triangle
        Vector3 ta = new(-25.0f, 0.5f, 0.0f);
        Vector3 tb = new(-4.0f, 2.5f, 1.0f);
        Vector3 tc = new(-8.0f, 6.5f, 0.0f);

        Vector3 bary = new(0.0f, 0.0f, 0.0f);

        // Test sphere
        Vector3 sp = new(-30.0f, 5.0f, 5.0f);
        float sr = 4.0f;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------
        // Main game loop
        //--------------------------------------------------------------------------------------
        while (!WindowShouldClose())
        {
            //----------------------------------------------------------------------------------
            // Update
            //----------------------------------------------------------------------------------
            if (IsCursorHidden())
            {
                UpdateCamera(ref camera, CameraMode.CAMERA_FIRST_PERSON);
            }

            // Toggle camera controls
            if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                if (IsCursorHidden())
                {
                    EnableCursor();
                }
                else
                {
                    DisableCursor();
                }
            }

            // Display information about closest hit
            RayCollision collision = new();
            string hitObjectName = "None";
            collision.Distance = float.MaxValue;
            collision.Hit = false;
            Color cursorColor = Color.WHITE;

            // Get ray and test against objects
            ray = GetMouseRay(GetMousePosition(), camera);

            // Check ray collision aginst ground quad
            RayCollision groundHitInfo = GetRayCollisionQuad(ray, g0, g1, g2, g3);
            if (groundHitInfo.Hit && (groundHitInfo.Distance < collision.Distance))
            {
                collision = groundHitInfo;
                cursorColor = Color.GREEN;
                hitObjectName = "Ground";
            }

            // Check ray collision against test triangle
            RayCollision triHitInfo = GetRayCollisionTriangle(ray, ta, tb, tc);
            if (triHitInfo.Hit && (triHitInfo.Distance < collision.Distance))
            {
                collision = triHitInfo;
                cursorColor = Color.PURPLE;
                hitObjectName = "Triangle";

                bary = Vector3Barycenter(collision.Point, ta, tb, tc);
            }

            // Check ray collision against test sphere
            RayCollision sphereHitInfo = GetRayCollisionSphere(ray, sp, sr);
            if ((sphereHitInfo.Hit) && (sphereHitInfo.Distance < collision.Distance))
            {
                collision = sphereHitInfo;
                cursorColor = Color.ORANGE;
                hitObjectName = "Sphere";
            }

            // Check ray collision against bounding box first, before trying the full ray-mesh test
            RayCollision boxHitInfo = GetRayCollisionBox(ray, towerBBox);
            if (boxHitInfo.Hit && boxHitInfo.Distance < collision.Distance)
            {
                collision = boxHitInfo;
                cursorColor = Color.ORANGE;
                hitObjectName = "Box";

                // Check ray collision against model meshes
                RayCollision meshHitInfo = new();
                for (int m = 0; m < tower.MeshCount; m++)
                {
                    // NOTE: We consider the model.Transform for the collision check but
                    // it can be checked against any transform matrix, used when checking against same
                    // model drawn multiple times with multiple transforms
                    meshHitInfo = GetRayCollisionMesh(ray, tower.Meshes[m], tower.Transform);
                    if (meshHitInfo.Hit)
                    {
                        // Save the closest hit mesh
                        if ((!collision.Hit) || (collision.Distance > meshHitInfo.Distance))
                        {
                            collision = meshHitInfo;
                        }
                        break;
                    }
                }

                if (meshHitInfo.Hit)
                {
                    collision = meshHitInfo;
                    cursorColor = Color.ORANGE;
                    hitObjectName = "Mesh";
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            BeginMode3D(camera);

            // Draw the tower
            DrawModel(tower, towerPos, 1.0f, Color.WHITE);

            // Draw the test triangle
            DrawLine3D(ta, tb, Color.PURPLE);
            DrawLine3D(tb, tc, Color.PURPLE);
            DrawLine3D(tc, ta, Color.PURPLE);

            // Draw the test sphere
            DrawSphereWires(sp, sr, 8, 8, Color.PURPLE);

            // Draw the mesh bbox if we hit it
            if (boxHitInfo.Hit)
            {
                DrawBoundingBox(towerBBox, Color.LIME);
            }

            // If we hit something, draw the cursor at the hit point
            if (collision.Hit)
            {
                DrawCube(collision.Point, 0.3f, 0.3f, 0.3f, cursorColor);
                DrawCubeWires(collision.Point, 0.3f, 0.3f, 0.3f, Color.RED);

                Vector3 normalEnd = collision.Point + collision.Normal;
                DrawLine3D(collision.Point, normalEnd, Color.RED);
            }

            DrawRay(ray, Color.MAROON);

            DrawGrid(10, 10.0f);

            EndMode3D();

            // Draw some debug GUI text
            DrawText($"Hit Object: {hitObjectName}", 10, 50, 10, Color.BLACK);

            if (collision.Hit)
            {
                int ypos = 70;

                DrawText($"Distance: {collision.Distance}", 10, ypos, 10, Color.BLACK);

                DrawText($"Hit Pos: {collision.Point}", 10, ypos + 15, 10, Color.BLACK);

                DrawText($"Hit Norm: {collision.Normal}", 10, ypos + 30, 10, Color.BLACK);

                if (triHitInfo.Hit)
                {
                    DrawText($"Barycenter: {bary}", 10, ypos + 45, 10, Color.BLACK);
                }
            }

            DrawText("Right click mouse to toggle camera controls", 10, 430, 10, Color.GRAY);

            DrawText("(c) Turret 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, Color.GRAY);

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadModel(tower);
        UnloadTexture(texture);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
