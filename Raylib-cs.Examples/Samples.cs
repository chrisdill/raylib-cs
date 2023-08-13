namespace Raylib_cs.Examples;

public sealed class Samples : IDisposable
{
    public Samples()
    {
        Raylib.InitWindow(800, 450, nameof(Samples));
        Raylib.SetTargetFPS(60);
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.DrawText(
                "Congrats! You created your first window!",
                190,
                200,
                20,
                Color.LIGHTGRAY
            );
            Raylib.EndDrawing();
        }
    }

    public void Dispose()
    {
        Raylib.CloseWindow();
    }
}
