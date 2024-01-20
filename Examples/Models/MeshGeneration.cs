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
        Image isChecked = GenImageChecked(2, 2, 1, 1, Color.Red, Color.Green);
        Texture2D texture = LoadTextureFromImage(isChecked);
        UnloadImage(isChecked);

        Model[] models = new Model[9];

        models[0] = LoadModelFromMesh(GenMeshPlane(2, 2, 5, 5));
        models[1] = LoadModelFromMesh(GenMeshCube(2.0f, 1.0f, 2.0f));
        models[2] = LoadModelFromMesh(GenMeshSphere(2, 32, 32));
        models[3] = LoadModelFromMesh(GenMeshHemiSphere(2, 16, 16));
        models[4] = LoadModelFromMesh(GenMeshCylinder(1, 2, 16));
        models[5] = LoadModelFromMesh(GenMeshTorus(0.25f, 4.0f, 16, 32));
        models[6] = LoadModelFromMesh(GenMeshKnot(1.0f, 2.0f, 16, 128));
        models[7] = LoadModelFromMesh(GenMeshPoly(5, 2.0f));
        models[8] = LoadModelFromMesh(GenMeshCustom());

        // Set isChecked texture as default diffuse component for all models material
        for (int i = 0; i < models.Length; i++)
        {
            // Set map diffuse texture
            Raylib.SetMaterialTexture(ref models[i], 0, MaterialMapIndex.Albedo, ref texture);
        }

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(5.0f, 5.0f, 5.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

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
            UpdateCamera(ref camera, CameraMode.Orbital);

            if (IsMouseButtonPressed(MouseButton.Left))
            {
                // Cycle between the textures
                currentModel = (currentModel + 1) % models.Length;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            DrawModel(models[currentModel], position, 1.0f, Color.White);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawRectangle(30, 400, 310, 30, ColorAlpha(Color.SkyBlue, 0.5f));
            DrawRectangleLines(30, 400, 310, 30, ColorAlpha(Color.DarkBlue, 0.5f));
            DrawText("MOUSE LEFT BUTTON to CYCLE PROCEDURAL MODELS", 40, 410, 10, Color.Blue);

            switch (currentModel)
            {
                case 0:
                    DrawText("PLANE", 680, 10, 20, Color.DarkBlue);
                    break;
                case 1:
                    DrawText("CUBE", 680, 10, 20, Color.DarkBlue);
                    break;
                case 2:
                    DrawText("SPHERE", 680, 10, 20, Color.DarkBlue);
                    break;
                case 3:
                    DrawText("HEMISPHERE", 640, 10, 20, Color.DarkBlue);
                    break;
                case 4:
                    DrawText("CYLINDER", 680, 10, 20, Color.DarkBlue);
                    break;
                case 5:
                    DrawText("TORUS", 680, 10, 20, Color.DarkBlue);
                    break;
                case 6:
                    DrawText("KNOT", 680, 10, 20, Color.DarkBlue);
                    break;
                case 7:
                    DrawText("POLY", 680, 10, 20, Color.DarkBlue);
                    break;
                case 8:
                    DrawText("Custom (triagnle)", 580, 10, 20, Color.DarkBlue);
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

    // Generate a simple triangle mesh from code
    private static Mesh GenMeshCustom()
    {
        Mesh mesh = new(3, 1);
        mesh.AllocVertices();
        mesh.AllocTexCoords();
        mesh.AllocNormals();
        Span<Vector3> vertices = mesh.VerticesAs<Vector3>();
        Span<Vector2> texcoords = mesh.TexCoordsAs<Vector2>();
        Span<Vector3> normals = mesh.NormalsAs<Vector3>();

        // Vertex at (0, 0, 0)
        vertices[0] = new(0, 0, 0);
        normals[0] = new(0, 1, 0);
        texcoords[0] = new(0, 0);

        // Vertex at (1, 0, 2)
        vertices[1] = new(1, 0, 2);
        normals[1] = new(0, 1, 0);
        texcoords[1] = new(0.5f, 1.0f);

        // Vertex at (2, 0, 0)
        vertices[2] = new(2, 0, 0);
        normals[2] = new(0, 1, 0);
        texcoords[2] = new(1, 0);

        // Upload mesh data from CPU (RAM) to GPU (VRAM) memory
        UploadMesh(ref mesh, false);

        return mesh;
    }
}
