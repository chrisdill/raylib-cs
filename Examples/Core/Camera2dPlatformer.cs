/*******************************************************************************************
*
*   raylib [core] example - 2d camera platformer
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by arvyy (@arvyy) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 arvyy (@arvyy)
*
********************************************************************************************/

using System;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Raymath;

namespace Examples.Core;

public class Camera2dPlatformer
{
    const int G = 400;
    const float PlayerJumpSpeed = 350.0f;
    const float PlayerHorSpeed = 200.0f;

    struct Player
    {
        public Vector2 Position;
        public float Speed;
        public bool CanJump;
    }

    struct EnvItem
    {
        public Rectangle Rect;
        public int Blocking;
        public Color Color;

        public EnvItem(Rectangle rect, int blocking, Color color)
        {
            this.Rect = rect;
            this.Blocking = blocking;
            this.Color = color;
        }
    }

    delegate void CameraUpdaterCallback(
        ref Camera2D camera,
        ref Player player,
        EnvItem[] envItems,
        float delta,
        int width,
        int height
    );

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        Player player = new();
        player.Position = new Vector2(400, 280);
        player.Speed = 0;
        player.CanJump = false;

        EnvItem[] envItems = new EnvItem[]
        {
            new EnvItem(new Rectangle(0, 0, 1000, 400), 0, Color.LightGray),
            new EnvItem(new Rectangle(0, 400, 1000, 200), 1, Color.Gray),
            new EnvItem(new Rectangle(300, 200, 400, 10), 1, Color.Gray),
            new EnvItem(new Rectangle(250, 300, 100, 10), 1, Color.Gray),
            new EnvItem(new Rectangle(650, 300, 100, 10), 1, Color.Gray)
        };

        Camera2D camera = new();
        camera.Target = player.Position;
        camera.Offset = new Vector2(screenWidth / 2, screenHeight / 2);
        camera.Rotation = 0.0f;
        camera.Zoom = 1.0f;

        // Store callbacks to the multiple update camera functions
        CameraUpdaterCallback[] cameraUpdaters = new CameraUpdaterCallback[]
        {
            UpdateCameraCenter,
            UpdateCameraCenterInsideMap,
            UpdateCameraCenterSmoothFollow,
            UpdateCameraEvenOutOnLanding,
            UpdateCameraPlayerBoundsPush
        };

        int cameraOption = 0;
        int cameraUpdatersLength = cameraUpdaters.Length;

        string[] cameraDescriptions = new string[]{
            "Follow player center",
            "Follow player center, but clamp to map edges",
            "Follow player center; smoothed",
            "Follow player center horizontally; update player center vertically after landing",
            "Player push camera on getting too close to screen edge"
        };

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            float deltaTime = GetFrameTime();

            UpdatePlayer(ref player, envItems, deltaTime);

            camera.Zoom += ((float)GetMouseWheelMove() * 0.05f);

            if (camera.Zoom > 3.0f)
            {
                camera.Zoom = 3.0f;
            }
            else if (camera.Zoom < 0.25f)
            {
                camera.Zoom = 0.25f;
            }

            if (IsKeyPressed(KeyboardKey.R))
            {
                camera.Zoom = 1.0f;
                player.Position = new Vector2(400, 280);
            }

            if (IsKeyPressed(KeyboardKey.C))
            {
                cameraOption = (cameraOption + 1) % cameraUpdatersLength;
            }

            // Call update camera function by its pointer
            cameraUpdaters[cameraOption](ref camera, ref player, envItems, deltaTime, screenWidth, screenHeight);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.LightGray);

            BeginMode2D(camera);

            for (int i = 0; i < envItems.Length; i++)
            {
                DrawRectangleRec(envItems[i].Rect, envItems[i].Color);
            }

            Rectangle playerRect = new(player.Position.X - 20, player.Position.Y - 40, 40, 40);
            DrawRectangleRec(playerRect, Color.Red);

            EndMode2D();

            DrawText("Controls:", 20, 20, 10, Color.Black);
            DrawText("- Right/Left to move", 40, 40, 10, Color.DarkGray);
            DrawText("- Space to jump", 40, 60, 10, Color.DarkGray);
            DrawText("- Mouse Wheel to Zoom in-out, R to reset zoom", 40, 80, 10, Color.DarkGray);
            DrawText("- C to change camera mode", 40, 100, 10, Color.DarkGray);
            DrawText("Current camera mode:", 20, 120, 10, Color.Black);
            DrawText(cameraDescriptions[cameraOption], 40, 140, 10, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }

    static void UpdatePlayer(ref Player player, EnvItem[] envItems, float delta)
    {
        if (IsKeyDown(KeyboardKey.Left))
        {
            player.Position.X -= PlayerHorSpeed * delta;
        }

        if (IsKeyDown(KeyboardKey.Right))
        {
            player.Position.X += PlayerHorSpeed * delta;
        }

        if (IsKeyDown(KeyboardKey.Space) && player.CanJump)
        {
            player.Speed = -PlayerJumpSpeed;
            player.CanJump = false;
        }

        int hitObstacle = 0;
        for (int i = 0; i < envItems.Length; i++)
        {
            EnvItem ei = envItems[i];
            Vector2 p = player.Position;
            if (ei.Blocking != 0 &&
                ei.Rect.X <= p.X &&
                ei.Rect.X + ei.Rect.Width >= p.X &&
                ei.Rect.Y >= p.Y &&
                ei.Rect.Y <= p.Y + player.Speed * delta)
            {
                hitObstacle = 1;
                player.Speed = 0.0f;
                player.Position.Y = ei.Rect.Y;
            }
        }

        if (hitObstacle == 0)
        {
            player.Position.Y += player.Speed * delta;
            player.Speed += G * delta;
            player.CanJump = false;
        }
        else
        {
            player.CanJump = true;
        }
    }

    static void UpdateCameraCenter(
        ref Camera2D camera,
        ref Player player,
        EnvItem[] envItems,
        float delta,
        int width,
        int height
    )
    {
        camera.Offset = new Vector2(width / 2, height / 2);
        camera.Target = player.Position;
    }

    static void UpdateCameraCenterInsideMap(
        ref Camera2D camera,
        ref Player player,
        EnvItem[] envItems,
        float delta,
        int width,
        int height)
    {
        camera.Target = player.Position;
        camera.Offset = new Vector2(width / 2, height / 2);
        float minX = 1000, minY = 1000, maxX = -1000, maxY = -1000;

        for (int i = 0; i < envItems.Length; i++)
        {
            EnvItem ei = envItems[i];
            minX = Math.Min(ei.Rect.X, minX);
            maxX = Math.Max(ei.Rect.X + ei.Rect.Width, maxX);
            minY = Math.Min(ei.Rect.Y, minY);
            maxY = Math.Max(ei.Rect.Y + ei.Rect.Height, maxY);
        }

        Vector2 max = GetWorldToScreen2D(new Vector2(maxX, maxY), camera);
        Vector2 min = GetWorldToScreen2D(new Vector2(minX, minY), camera);

        if (max.X < width)
        {
            camera.Offset.X = width - (max.X - width / 2);
        }

        if (max.Y < height)
        {
            camera.Offset.Y = height - (max.Y - height / 2);
        }

        if (min.X > 0)
        {
            camera.Offset.X = width / 2 - min.X;
        }

        if (min.Y > 0)
        {
            camera.Offset.Y = height / 2 - min.Y;
        }
    }

    static void UpdateCameraCenterSmoothFollow(
        ref Camera2D camera,
        ref Player player,
        EnvItem[] envItems,
        float delta,
        int width,
        int height
    )
    {
        const float minSpeed = 30;
        const float minEffectLength = 10;
        const float fractionSpeed = 0.8f;

        camera.Offset = new Vector2(width / 2, height / 2);
        Vector2 diff = Vector2Subtract(player.Position, camera.Target);
        float length = Vector2Length(diff);

        if (length > minEffectLength)
        {
            float speed = Math.Max(fractionSpeed * length, minSpeed);
            camera.Target = Vector2Add(camera.Target, Vector2Scale(diff, speed * delta / length));
        }
    }

    static void UpdateCameraEvenOutOnLanding(
        ref Camera2D camera,
        ref Player player,
        EnvItem[] envItems,
        float delta,
        int width,
        int height
    )
    {
        float evenOutSpeed = 700;
        int eveningOut = 0;
        float evenOutTarget = 0.0f;

        camera.Offset = new Vector2(width / 2, height / 2);
        camera.Target.X = player.Position.X;

        if (eveningOut != 0)
        {
            if (evenOutTarget > camera.Target.Y)
            {
                camera.Target.Y += evenOutSpeed * delta;

                if (camera.Target.Y > evenOutTarget)
                {
                    camera.Target.Y = evenOutTarget;
                    eveningOut = 0;
                }
            }
            else
            {
                camera.Target.Y -= evenOutSpeed * delta;

                if (camera.Target.Y < evenOutTarget)
                {
                    camera.Target.Y = evenOutTarget;
                    eveningOut = 0;
                }
            }
        }
        else
        {
            if (player.CanJump && (player.Speed == 0) && (player.Position.Y != camera.Target.Y))
            {
                eveningOut = 1;
                evenOutTarget = player.Position.Y;
            }
        }
    }

    static void UpdateCameraPlayerBoundsPush(
        ref Camera2D camera,
        ref Player player,
        EnvItem[] envItems,
        float delta,
        int width,
        int height
    )
    {
        Vector2 bbox = new(0.2f, 0.2f);

        Vector2 bboxWorldMin = GetScreenToWorld2D(
            new Vector2((1 - bbox.X) * 0.5f * width, (1 - bbox.Y) * 0.5f * height),
            camera
        );
        Vector2 bboxWorldMax = GetScreenToWorld2D(
            new Vector2((1 + bbox.X) * 0.5f * width,
            (1 + bbox.Y) * 0.5f * height),
            camera
        );
        camera.Offset = new Vector2((1 - bbox.X) * 0.5f * width, (1 - bbox.Y) * 0.5f * height);

        if (player.Position.X < bboxWorldMin.X)
        {
            camera.Target.X = player.Position.X;
        }

        if (player.Position.Y < bboxWorldMin.Y)
        {
            camera.Target.Y = player.Position.Y;
        }

        if (player.Position.X > bboxWorldMax.X)
        {
            camera.Target.X = bboxWorldMin.X + (player.Position.X - bboxWorldMax.X);
        }

        if (player.Position.Y > bboxWorldMax.Y)
        {
            camera.Target.Y = bboxWorldMin.Y + (player.Position.Y - bboxWorldMax.Y);
        }
    }
}
