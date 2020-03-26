![Raylib-cs Logo](https://github.com/ChrisDill/Raylib-cs/blob/master/Logo/raylib-cs_256x256.png "Raylib-cs Logo")

# Raylib-cs

C# bindings for raylib 2.5, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

# UPDATE

Currently raygui and physac are a work in progress and are not easy to setup. I do not recommend using them at this time.
I am also nearly ready to update the master branch with alot changes for raylib 3.0 so be prepared.

# Installation

So far, I have only done a few tests on Windows and Linux.

1. Add the bindings to your project. See the test projects for reference.

2. Download the native libraries using the [official 2.5 release](https://github.com/raysan5/raylib/releases/tag/2.5.0).

3. Make sure the native library matches the platform you are using and can be found in the search path. See https://www.mono-project.com/docs/advanced/pinvoke/ for more details.

4. Start coding!

```csharp
using Raylib;
using rl = Raylib.Raylib;

static class Program
{
    public static void Main() 
    {
        rl.InitWindow(640, 480, "Hello World");

        while (!rl.WindowShouldClose())
        {
            rl.BeginDrawing();

            rl.ClearBackground(Color.WHITE);
            rl.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

            rl.EndDrawing();
        }

        rl.CloseWindow();
    }
}
```

# Tech notes

- Certain funtions take a enum instead of a int such as `IsKeyPressed`.
- Colors stored in the `Color` struct. `RED` changes to `Color.RED`
- Uses `string.Format` instead of `TextFormat`.
- Adds constructors for structs.
- Adds operator overloads for math structs.

# Contributing

If you have any ideas, feel free to open an issue and tell me what you think.
If you'd like to contribute, please fork the repository and make changes as
you'd like. Pull requests are warmly welcome.

If you want to [request features](https://github.com/raysan5/raylib/pulls) or [report bugs](https://github.com/raysan5/raylib/issues) related to the library (in contrast to this binding), please refer to the [author's project repo](https://github.com/raysan5/raylib).

# License

raylib-cs (and raylib) is licensed under an unmodified zlib/libpng license, which is an OSI-certified, BSD-like license that allows static linking with closed source software. Check [LICENSE](LICENSE) for further details.
