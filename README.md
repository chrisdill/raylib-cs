![Raylib-cs Logo](https://github.com/ChrisDill/Raylib-cs/blob/master/Logo/raylib-cs_256x256.png "Raylib-cs Logo")

# Raylib-cs

C# bindings for raylib 3.7.0, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

[![GitHub contributors](https://img.shields.io/github/contributors/ChrisDill/Raylib-cs)](https://github.com/ChrisDill/Raylib-cs/graphs/contributors)
[![License](https://img.shields.io/badge/license-zlib%2Flibpng-blue.svg)](LICENSE)

[![Chat on Discord](https://img.shields.io/discord/426912293134270465.svg?logo=discord)](https://discord.gg/raylib)
[![GitHub stars](https://img.shields.io/github/stars/ChrisDill/Raylib-cs?style=social)](https://github.com/ChrisDill/Raylib-cs/stargazers)

[![Build](https://github.com/ChrisDill/Raylib-cs/workflows/Build/badge.svg)](https://github.com/ChrisDill/Raylib-cs/actions?query=workflow%3ABuild)

Raylib-cs targets netstandard2.1 and supports netcoreapp3.0+ and net5.0.

## Installation - NuGet

This is the prefered method to get started - The package is still new so please report any [issues](https://github.com/ChrisDill/Raylib-cs/issues).

```
dotnet add package Raylib-cs --version 3.7.0
```

[![NuGet](https://img.shields.io/nuget/dt/raylib-cs)](https://www.nuget.org/packages/Raylib-cs/)

If you need to edit Raylib-cs source then you will need to add the bindings as a project (see below).

## Installation - Manual

1. Download/Clone this repo

2. Add Raylib-cs/Raylib-cs.csproj to your project as an existing project.

3. Download the native libraries for the platforms you want to build for using the [official 3.7.0 release](https://github.com/raysan5/raylib/releases/tag/3.7.0).
   **NOTE: the MSVC version is required for Windows platforms**

4. **(Recommended)** Put the native library for each platform under `Raylib-cs/runtimes/{platform}/native/`
   **(Optional)** If you want to handle the native libraries yourself, make sure they are either in the same directory as the executable and/or can be found in the search path. See https://www.mono-project.com/docs/advanced/pinvoke/ for details.

5. Start coding!

```csharp
using Raylib_cs;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(800, 480, "Hello World");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
```

## Physac-cs and Raygui-cs

There are **UNSUPPORTED & EXPERIMENTAL** bindings to physac and raygui. They are in separate projects not included in releases or via NuGet. Pull requests are welcome and encouraged.

## Documentation

Examples for Raylib-cs can be found at [Raylib-cs-Examples](https://github.com/ChrisDill/Raylib-cs-Examples).

Details about Raylib-cs can be found on the [Raylib-cs wiki](https://github.com/ChrisDill/Raylib-cs/wiki).

## Contributing

If you have any ideas, feel free to open an issue and tell me what you think.
If you'd like to contribute, please fork the repository and make changes as
you'd like. Pull requests are warmly welcome.

If you want to [request features](https://github.com/raysan5/raylib/pulls) or [report bugs](https://github.com/raysan5/raylib/issues) related to the library (in contrast to this binding), please refer to the [author's project repo](https://github.com/raysan5/raylib).

## License

See [LICENSE](LICENSE) for details.
