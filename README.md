![Raylib-cs Logo](https://github.com/ChrisDill/Raylib-cs/blob/master/Logo/raylib-cs_256x256.png "Raylib-cs Logo")

# Raylib-cs

C# bindings for raylib, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

# Installation
So far, I have only done a few tests on Windows and Linux. 

There is a [nuget package](https://www.nuget.org/packages/Raylib-cs/) although it is currently out of date.

1. Copy or reference the bindings folder in your project. See the test projects for reference.

2. The bindings need a native library to load. It should match your platform and configuration. You can either:
    - Download a raylib [release](https://github.com/raysan5/raylib/releases).

    - Build raylib from source. Use this if your using module bindings that are not built in releases.

3. Make sure the native library is in a place your project can find it. This will vary for your platform. See https://www.mono-project.com/docs/advanced/pinvoke/ for more details.

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
- Certain funtions take a enum instead of a int such as 'IsKeyPressed'.
- Colors stored in the `Color` struct. 'RED' changes to 'Color.RED'
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
