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
using static Raylib.rl;

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
- Binding generator improvements
- Managed bindings(Marhsall etc)
- .Net Core support
- Windows forms support
- Finish examples
- Add as a nuget package
- Add templates
- Auto select x86/x64 dll as needed

## Contributing
If you have any ideas, feel free to open an issue and tell me what you think.

If you'd like to contribute, please fork the repository and make changes as
you'd like. Pull requests are warmly welcome.

## Licensing
raylib-cs is licensed under an unmodified zlib/libpng license, which is an OSI-certified, BSD-like license that allows static linking with closed source software. Check [LICENSE](LICENSE) for further details.
