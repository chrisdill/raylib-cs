# raylib-cs

C# bindings for raylib 2.0, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

## Installation
Tested on windows 10 64 bit.

1. Download the repository 
2. Run ExampleApplication.exe in ExampleApplication/bin/Debug/

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
- Finish binding generator
- Use raylib in windows forms
- Bind physac, raygui, easings

## Contributing
If you have any ideas, feel free to open an issue and tell me what you think.

If you'd like to contribute, please fork the repository and make changes as
you'd like. Pull requests are warmly welcome.

## Licensing
raylib-cs is licensed under an unmodified zlib/libpng license, which is an OSI-certified, BSD-like license that allows static linking with closed source software. Check [LICENSE](LICENSE) for further details.
