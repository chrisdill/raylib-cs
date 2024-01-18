/*******************************************************************************************
*
*   raylib [textures] example - Texture source and destination rectangles
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class SrcRecDstRec
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        string title = "raylib [textures] examples - texture source and destination rectangles";
        InitWindow(screenWidth, screenHeight, title);

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Texture2D scarfy = LoadTexture("resources/scarfy.png");

        int frameWidth = scarfy.Width / 6;
        int frameHeight = scarfy.Height;

        // NOTE: Source rectangle (part of the texture to use for drawing)
        Rectangle sourceRec = new(0, 0, frameWidth, frameHeight);

        // NOTE: Destination rectangle (screen rectangle where drawing part of texture)
        Rectangle destRec = new(screenWidth / 2, screenHeight / 2, frameWidth * 2, frameHeight * 2);

        // NOTE: Origin of the texture (rotation/scale point), it's relative to destination rectangle size
        Vector2 origin = new(frameWidth, frameHeight);

        int rotation = 0;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            rotation++;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            // NOTE: Using DrawTexturePro() we can easily rotate and scale the part of the texture we draw
            // sourceRec defines the part of the texture we use for drawing
            // destRec defines the rectangle where our texture part will fit (scaling it to fit)
            // origin defines the point of the texture used as reference for rotation and scaling
            // rotation defines the texture rotation (using origin as rotation point)
            DrawTexturePro(scarfy, sourceRec, destRec, origin, rotation, Color.White);

            DrawLine((int)destRec.X, 0, (int)destRec.X, screenHeight, Color.Gray);
            DrawLine(0, (int)destRec.Y, screenWidth, (int)destRec.Y, Color.Gray);

            DrawText("(c) Scarfy sprite by Eiden Marsal", screenWidth - 200, screenHeight - 20, 10, Color.Gray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(scarfy);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
