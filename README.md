![Raylib-cs Logo](https://github.com/ChrisDill/Raylib-cs/blob/master/Logo/raylib-cs_256x256.png "Raylib-cs Logo")

# Raylib-cs

C# bindings for raylib 2.0, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

## Installation
So far, I have only tested on Windows. Tips on making things work smoothly on all platforms is appreciated.

Use the [nuget package](https://www.nuget.org/packages/Raylib-cs/) or install manually from this repo. 

Look at the Examples and Test projects for reference.

Enjoy!

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

## Custom build
Gives access to extra modules from C#.

1. Add [raygui](https://github.com/raysan5/raygui)
2. Add a C file with the following
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
