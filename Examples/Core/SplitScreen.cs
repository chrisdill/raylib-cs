/*******************************************************************************************
*
*   raylib [core] example - split screen
*
*   This example has been created using raylib 3.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Jeffery Myers (@JeffM2501) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2021 Jeffery Myers (@JeffM2501)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Core;

public unsafe class SplitScreen
{
    static Texture2D TextureGrid;
    static Camera3D CameraPlayer1;
    static Camera3D CameraPlayer2;

    // Scene drawing
    static void DrawScene()
    {
        int count = 5;
        float spacing = 4;

        // Grid of cube trees on a plane to make a "world"
        // Simple world plane
        DrawPlane(new Vector3(0, 0, 0), new Vector2(50, 50), Color.Beige);

        for (float x = -count * spacing; x <= count * spacing; x += spacing)
        {
            for (float z = -count * spacing; z <= count * spacing; z += spacing)
            {
                DrawCube(new Vector3(x, 1.5f, z), 1, 1, 1, Color.Lime);
                DrawCube(new Vector3(x, 0.5f, z), 0.25f, 1, 0.25f, Color.Brown);
            }
        }

        // Draw a cube at each player's position
        DrawCube(CameraPlayer1.Position, 1, 1, 1, Color.Red);
        DrawCube(CameraPlayer2.Position, 1, 1, 1, Color.Blue);
    }

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - split screen");

        // Generate a simple texture to use for trees
        Image img = GenImageChecked(256, 256, 32, 32, Color.DarkGray, Color.White);
        TextureGrid = LoadTextureFromImage(img);
        UnloadImage(img);
        SetTextureFilter(TextureGrid, TextureFilter.Anisotropic16X);
        SetTextureWrap(TextureGrid, TextureWrap.Clamp);

        // Setup player 1 camera and screen
        CameraPlayer1.FovY = 45.0f;
        CameraPlayer1.Up.Y = 1.0f;
        CameraPlayer1.Target.Y = 1.0f;
        CameraPlayer1.Position.Z = -3.0f;
        CameraPlayer1.Position.Y = 1.0f;

        RenderTexture2D screenPlayer1 = LoadRenderTexture(screenWidth / 2, screenHeight);

        // Setup player two camera and screen
        CameraPlayer2.FovY = 45.0f;
        CameraPlayer2.Up.Y = 1.0f;
        CameraPlayer2.Target.Y = 3.0f;
        CameraPlayer2.Position.X = -3.0f;
        CameraPlayer2.Position.Y = 3.0f;

        RenderTexture2D screenPlayer2 = LoadRenderTexture(screenWidth / 2, screenHeight);

        // Build a flipped rectangle the size of the split view to use for drawing later
        Rectangle splitScreenRect = new(
            0.0f,
            0.0f,
            (float)screenPlayer1.Texture.Width,
            (float)-screenPlayer1.Texture.Height
        );

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            // If anyone moves this frame, how far will they move based on the time since the last frame
            // this moves thigns at 10 world units per second, regardless of the actual FPS
            float offsetThisFrame = 10.0f * GetFrameTime();

            // Move Player1 forward and backwards (no turning)
            if (IsKeyDown(KeyboardKey.W))
            {
                CameraPlayer1.Position.Z += offsetThisFrame;
                CameraPlayer1.Target.Z += offsetThisFrame;
            }
            else if (IsKeyDown(KeyboardKey.S))
            {
                CameraPlayer1.Position.Z -= offsetThisFrame;
                CameraPlayer1.Target.Z -= offsetThisFrame;
            }

            // Move Player2 forward and backwards (no turning)
            if (IsKeyDown(KeyboardKey.Up))
            {
                CameraPlayer2.Position.X += offsetThisFrame;
                CameraPlayer2.Target.X += offsetThisFrame;
            }
            else if (IsKeyDown(KeyboardKey.Down))
            {
                CameraPlayer2.Position.X -= offsetThisFrame;
                CameraPlayer2.Target.X -= offsetThisFrame;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            // Draw Player1 view to the render texture
            BeginTextureMode(screenPlayer1);
            ClearBackground(Color.SkyBlue);

            BeginMode3D(CameraPlayer1);
            DrawScene();
            EndMode3D();

            DrawText("PLAYER 1 W/S to move", 10, 10, 20, Color.Red);
            EndTextureMode();

            // Draw Player2 view to the render texture
            BeginTextureMode(screenPlayer2);
            ClearBackground(Color.SkyBlue);

            BeginMode3D(CameraPlayer2);
            DrawScene();
            EndMode3D();

            DrawText("PLAYER 2 UP/DOWN to move", 10, 10, 20, Color.Blue);
            EndTextureMode();

            // Draw both views render textures to the screen side by side
            BeginDrawing();
            ClearBackground(Color.Black);

            DrawTextureRec(screenPlayer1.Texture, splitScreenRect, new Vector2(0, 0), Color.White);
            DrawTextureRec(screenPlayer2.Texture, splitScreenRect, new Vector2(screenWidth / 2.0f, 0), Color.White);

            EndDrawing();
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadRenderTexture(screenPlayer1);
        UnloadRenderTexture(screenPlayer2);
        UnloadTexture(TextureGrid);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}

