using System;
using static Raylibcs.Raylibcs;

namespace Raylibcs
{
    class Program
    {
        static void Main(string[] args)
        {
            InitWindow(800, 450, "Raylibcs 0.1");
            SetTargetFPS(60);
            SetExitKey(256);

            var sound = LoadSound("alive.wav");
            PlaySound(ref sound);

            var t = LoadTexture("crimbocore.png");
            //var f = LoadSpriteFont("Vera.ttf");

            var w = new Color(255, 255, 255, 255);
            var c = new Color(124, 124, 124, 255);
            var g = new Color(230, 230, 230, 255);

            while (!WindowShouldClose())
            {
                if (IsKeyPressed(257))
                {
                    TakeScreenshot("test.png");
                }               

                BeginDrawing();
                ClearBackground(c);

                DrawTexture(t, 0, 0, w);
                DrawFPS(0, 0);
                //DrawTextEx(f, "Congrats! You created your first window!", new Vector2(190, 200), 20, 0, w);
              
                EndDrawing();
            }
            CloseWindow();
        }
    }
}