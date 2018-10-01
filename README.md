![Raylib-cs Logo](https://github.com/ChrisDill/Raylib-cs/blob/master/Logo/raylib-cs_256x256.png "Raylib-cs Logo")

# Raylib-cs

C# bindings for raylib 2.0, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

Bindings:
* Easings
* Physac
* Raygui
* Raylib
* Raymath

## Installation
Tested on windows 10 64 bit using the mono compiler.

1. Download the repository 
2. Run Examples.exe in Examples/bin/Debug/

```csharp
using Raylib;
using static Raylib.Raylib;

static class Program
{
	public static void Main() 
	{
		InitWindow(640, 480, "Raylib-cs");

		while (!WindowShouldClose())
		{
			BeginDraw();

			ClearBackground(WHITE);
			DrawText("Hello, world!", 12, 12, 20, BLACK);

			EndDrawing();
		}
	
		CloseWindow();
	}
}
```

# TODO:
- Generator improvements
- .Net Core support
- Windows forms support
- Auto select x86/x64 dll

# Differences
- interger constants are enums. 
KEY_ENTER -> Key.ENTER

- types changed to work with C#. 
char * -> string

## Contributing
If you have any ideas, feel free to open an issue and tell me what you think.
If you'd like to contribute, please fork the repository and make changes as
you'd like. Pull requests are warmly welcome.

If you want to [request features](https://github.com/raysan5/raylib/pulls) or [report bugs](https://github.com/raysan5/raylib/issues) related to the library (in contrast to this binding), please refer to the [author's project repo](https://github.com/raysan5/raylib).

## License
raylib-cs (and raylib) is licensed under an unmodified zlib/libpng license, which is an OSI-certified, BSD-like license that allows static linking with closed source software. Check [LICENSE](LICENSE) for further details.
