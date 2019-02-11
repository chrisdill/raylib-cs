![Raylib-cs Logo](https://github.com/ChrisDill/Raylib-cs/blob/master/Logo/raylib-cs_256x256.png "Raylib-cs Logo")

# Raylib-cs

C# bindings for raylib 2.0, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

## Installation
So far, I have only tested on Windows. Tips on making things work smoothly on all platforms is appreciated.

1. Add the [nuget package](https://www.nuget.org/packages/Raylib-cs/)

2. Start coding!

```csharp
using Raylib;
using static Raylib.Raylib;

static class Program
{
	public static void Main() 
	{
		InitWindow(640, 480, "Hello World");

		while (!WindowShouldClose())
		{
			BeginDraw();

			ClearBackground(Color.WHITE);
			DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

			EndDrawing();
		}

		CloseWindow();
	}
}
```

# Tech notes
The bindings are close to the original with a few changes and extensions.
- Enums are passed in as type instead of int to avoid explicit casting to a int every time.
- Added constructors for some of the types.

## Custom build
1. Add [raygui](https://github.com/raysan5/raygui)
2. Add a file with the following
```c
#include "raylib.h"
#include "easings.h"

#define PHYSAC_NO_THREADS
#define PHYSAC_IMPLEMENTATION 
#include "physac.h"

#define RAYGUI_IMPLEMENTATION
#include "raygui.h"
```

## Contributing
If you have any ideas, feel free to open an issue and tell me what you think.
If you'd like to contribute, please fork the repository and make changes as
you'd like. Pull requests are warmly welcome.

If you want to [request features](https://github.com/raysan5/raylib/pulls) or [report bugs](https://github.com/raysan5/raylib/issues) related to the library (in contrast to this binding), please refer to the [author's project repo](https://github.com/raysan5/raylib).

## License
raylib-cs (and raylib) is licensed under an unmodified zlib/libpng license, which is an OSI-certified, BSD-like license that allows static linking with closed source software. Check [LICENSE](LICENSE) for further details.
