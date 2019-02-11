using Raylib;
using static Raylib.Raylib;
using static Raylib.TextureFilterMode;

public partial class text_ttf_loading
{
    /*******************************************************************************************
    *
    *   raylib [text] example - TTF loading and usage
    *
    *   This example has been created using raylib 1.3.0 (www.raylib.com)
    *   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
    *
    *   Copyright (c) 2015 Ramon Santamaria (@raysan5)
    *
    ********************************************************************************************/


    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - ttf loading");

        string msg = "TTF Font";

        // NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

        // TTF Font loading with custom generation parameters
        Font font = LoadFontEx("resources/KAISG.ttf", 96, 0, null);

        // Generate mipmap levels to use trilinear filtering
        // NOTE: On 2D drawing it won't be noticeable, it looks like FILTER_BILINEAR
        GenTextureMipmaps(ref font.texture);

        float fontSize = font.baseSize;
        Vector2 fontPosition = new Vector2( 40, screenHeight/2 - 80 );
        Vector2 textSize;

        SetTextureFilter(font.texture, TextureFilterMode.FILTER_POINT);
        int currentFontFilter = 0;      // FILTER_POINT

        // NOTE: Drag and drop support only available for desktop platforms: Windows, Linux, OSX
		string[] droppedFiles;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            fontSize += GetMouseWheelMove()*4.0f;

            // Choose font texture filter method
            if (IsKeyPressed(KeyboardKey.KEY_ONE))
            {
                SetTextureFilter(font.texture, TextureFilterMode.FILTER_POINT);
                currentFontFilter = 0;
            }
            else if (IsKeyPressed(KeyboardKey.KEY_TWO))
            {
                SetTextureFilter(font.texture, TextureFilterMode.FILTER_BILINEAR);
                currentFontFilter = 1;
            }
            else if (IsKeyPressed(KeyboardKey.KEY_THREE))
            {
                // NOTE: Trilinear filter won't be noticed on 2D drawing
                SetTextureFilter(font.texture, TextureFilterMode.FILTER_TRILINEAR);
                currentFontFilter = 2;
            }

            textSize = MeasureTextEx(font, msg, fontSize, 0);

            if (IsKeyDown(KeyboardKey.KEY_LEFT)) fontPosition.x -= 10;
            else if (IsKeyDown(KeyboardKey.KEY_RIGHT)) fontPosition.x += 10;

            // Load a dropped TTF file dynamically (at current fontSize)
            if (IsFileDropped())
            {
                droppedFiles = GetDroppedFiles();
				

                if (droppedFiles.Length == 1) // Only support one ttf file dropped
                {
                    UnloadFont(font);
                    font = LoadFontEx(droppedFiles[0].ToString(), (int)fontSize, 0, null);
                    ClearDroppedFiles();
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

                ClearBackground(RAYWHITE);

                DrawText("Use mouse wheel to change font size", 20, 20, 10, GRAY);
                DrawText("Use KEY_RIGHT and KEY_LEFT to move text", 20, 40, 10, GRAY);
                DrawText("Use 1, 2, 3 to change texture filter", 20, 60, 10, GRAY);
                DrawText("Drop a new TTF font for dynamic loading", 20, 80, 10, DARKGRAY);

                DrawTextEx(font, msg, fontPosition, fontSize, 0, BLACK);

                // TODO: It seems texSize measurement is not accurate due to chars offsets...
				//TODO also fix the format text parts
                //DrawRectangleLines(fontPosition.x, fontPosition.y, textSize.x, textSize.y, RED);

                DrawRectangle(0, screenHeight - 80, screenWidth, 80, LIGHTGRAY);
                DrawText(string.Format("Font size: {0:00.00}", fontSize), 20, screenHeight - 50, 10, DARKGRAY);
                DrawText(string.Format("Text size: [{0:00.00}, {1:00.00}]", textSize.x, textSize.y), 20, screenHeight - 30, 10, DARKGRAY);
                DrawText("CURRENT TEXTURE FILTER:", 250, 400, 20, GRAY);

                if (currentFontFilter == 0) DrawText("POINT", 570, 400, 20, BLACK);
                else if (currentFontFilter == 1) DrawText("BILINEAR", 570, 400, 20, BLACK);
                else if (currentFontFilter == 2) DrawText("TRILINEAR", 570, 400, 20, BLACK);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        ClearDroppedFiles();        // Clear internal buffers
        UnloadFont(font);     // Font unloading

        CloseWindow();              // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
