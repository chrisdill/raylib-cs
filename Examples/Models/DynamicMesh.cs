using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Models;

public class DynamicMesh
{
    public unsafe static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - dynamic mesh");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = Vector3.One * 1.5f;
        camera.Target = camera.Position + new Vector3(1f, -0.25f, 1f);
        camera.Up = Vector3.UnitY;
        camera.FovY = 60.0f;
        camera.Projection = CameraProjection.Perspective;

        // Generate a dynamic mesh using utils to allocate/access mesh attribute data
        const int triangleRows = 48;
        const int vertexRows = triangleRows + 1;
        Mesh dynamicMesh = new(vertexRows * vertexRows, triangleRows * triangleRows * 2);
        dynamicMesh.AllocVertices();
        dynamicMesh.AllocTexCoords();
        dynamicMesh.AllocIndices();
        Span<Vector3> vertices = dynamicMesh.VerticesAs<Vector3>();
        Span<Vector2> texcoords = dynamicMesh.TexCoordsAs<Vector2>();
        Span<ushort> indices = dynamicMesh.IndicesAs<ushort>();
        for (int z = 0, i = 0; z < triangleRows; z++)
        {
            for (int x = 0; x < triangleRows; x++, i += 6)
            {
                indices[i + 0] = (ushort)(x + (z * vertexRows));
                indices[i + 1] = (ushort)(indices[i] + vertexRows);
                indices[i + 2] = (ushort)(indices[i] + 1);
                indices[i + 3] = (ushort)(indices[i] + 1);
                indices[i + 4] = (ushort)(indices[i] + vertexRows);
                indices[i + 5] = (ushort)(indices[i] + vertexRows + 1);
            }
        }
        UploadMesh(ref dynamicMesh, true);

        // Allocate the texture
        Image image = GenImageColor(triangleRows, triangleRows, Color.Blank);
        Texture2D texture = LoadTextureFromImage(image);
        Color[] pixels = new Color[texture.Width * texture.Height];
        UnloadImage(image);

        // Load the material
        Material material = LoadMaterialDefault();
        SetMaterialTexture(ref material, MaterialMapIndex.Diffuse, texture);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            float time = (float)GetTime();
            Random random = new(42);

            for (int z = 0, i = 0; z < vertexRows; z++)
            {
                for (int x = 0; x < vertexRows; x++, i++)
                {
                    float noiseX = SmoothNoise(time + random.Next(10000));
                    float noiseZ = SmoothNoise(time + random.Next(10000));
                    vertices[i].X = x + noiseX - .5f;
                    vertices[i].Y = (noiseX + noiseZ) / 2;
                    vertices[i].Z = z + noiseZ - .5f;
                    texcoords[i].X = (x - noiseZ) / triangleRows;
                    texcoords[i].Y = (z - noiseX) / triangleRows;
                }
            }
            UpdateMeshBuffer<Vector3>(dynamicMesh, Mesh.VboIdIndexVertices, vertices, 0);
            UpdateMeshBuffer<Vector2>(dynamicMesh, Mesh.VboIdIndexTexCoords, texcoords, 0);

            for (int y = 0, i = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++, i++)
                {
                    pixels[i] = new(32, 178, 170, 255);
                    pixels[i] = ColorBrightness(pixels[i], (SmoothNoise(time + random.Next(10000)) / 8) - (1 / 16f));
                    pixels[i] = ColorAlpha(pixels[i], (triangleRows - new Vector2(x, y).Length()) / triangleRows);
                }
            }
            UpdateTexture(texture, pixels);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);
            DrawMesh(dynamicMesh, material, Matrix4x4.Identity);
            EndMode3D();

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadMaterial(material);
        // Raylib.UnloadTexture(texture); <- No need to unload the texture. UnloadMaterial(Material) already unloaded it for us
        UnloadMesh(dynamicMesh);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }

    private static float SmoothNoise(float value)
    {
        return ((MathF.Sin(value) + MathF.Cos(value * MathF.E)) / 4) + .5f;
    }
}
