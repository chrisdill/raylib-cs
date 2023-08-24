/*******************************************************************************************
*
*   raylib example - procedural mesh generation
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (Ray San)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Models;

public class MeshGeneration
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh generation");

        // We generate a isChecked image for texturing
        Image isChecked = GenImageChecked(2, 2, 1, 1, Color.RED, Color.GREEN);
        Texture2D texture = LoadTextureFromImage(isChecked);
        UnloadImage(isChecked);

        Model[] models = new Model[7];

        models[0] = LoadModelFromMesh(GenMeshPlane(2, 2, 5, 5));
        models[1] = LoadModelFromMesh(GenMeshCube(2.0f, 1.0f, 2.0f));
        models[2] = LoadModelFromMesh(GenMeshSphere(2, 32, 32));
        models[3] = LoadModelFromMesh(GenMeshHemiSphere(2, 16, 16));
        models[4] = LoadModelFromMesh(GenMeshCylinder(1, 2, 16));
        models[5] = LoadModelFromMesh(GenMeshTorus(0.25f, 4.0f, 16, 32));
        models[6] = LoadModelFromMesh(GenMeshKnot(1.0f, 2.0f, 16, 128));

        // Set isChecked texture as default diffuse component for all models material
        for (int i = 0; i < models.Length; i++)
        {
            // Set map diffuse texture
            Raylib.SetMaterialTexture(ref models[i], 0, MaterialMapIndex.MATERIAL_MAP_ALBEDO, ref texture);
        }

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(5.0f, 5.0f, 5.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.CAMERA_PERSPECTIVE;

        // Model drawing position
        Vector3 position = new(0.0f, 0.0f, 0.0f);

        int currentModel = 0;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.CAMERA_ORBITAL);

            if (IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                // Cycle between the textures
                currentModel = (currentModel + 1) % models.Length;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RAYWHITE);

            BeginMode3D(camera);

            DrawModel(models[currentModel], position, 1.0f, Color.WHITE);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawRectangle(30, 400, 310, 30, ColorAlpha(Color.SKYBLUE, 0.5f));
            DrawRectangleLines(30, 400, 310, 30, ColorAlpha(Color.DARKBLUE, 0.5f));
            DrawText("MOUSE LEFT BUTTON to CYCLE PROCEDURAL MODELS", 40, 410, 10, Color.BLUE);

            switch (currentModel)
            {
                case 0:
                    DrawText("PLANE", 680, 10, 20, Color.DARKBLUE);
                    break;
                case 1:
                    DrawText("CUBE", 680, 10, 20, Color.DARKBLUE);
                    break;
                case 2:
                    DrawText("SPHERE", 680, 10, 20, Color.DARKBLUE);
                    break;
                case 3:
                    DrawText("HEMISPHERE", 640, 10, 20, Color.DARKBLUE);
                    break;
                case 4:
                    DrawText("CYLINDER", 680, 10, 20, Color.DARKBLUE);
                    break;
                case 5:
                    DrawText("TORUS", 680, 10, 20, Color.DARKBLUE);
                    break;
                case 6:
                    DrawText("KNOT", 680, 10, 20, Color.DARKBLUE);
                    break;
                default:
                    break;
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        for (int i = 0; i < models.Length; i++)
        {
            UnloadModel(models[i]);
        }

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
