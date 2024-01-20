/*******************************************************************************************
*
*   raylib [textures] example - Image processing
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 1.4 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Textures;

public class ImageProcessing
{
    public const int NumProcesses = 9;

    enum ImageProcess
    {
        None = 0,
        ColorGrayScale,
        ColorTint,
        ColorInvert,
        ColorContrast,
        ColorBrightness,
        GaussianBlur,
        FlipVertical,
        FlipHorizontal
    }

    static string[] processText = {
            "NO PROCESSING",
            "COLOR GRAYSCALE",
            "COLOR TINT",
            "COLOR INVERT",
            "COLOR CONTRAST",
            "COLOR BRIGHTNESS",
            "GAUSSIAN BLUR",
            "FLIP VERTICAL",
            "FLIP HORIZONTAL"
        };

    public unsafe static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - image processing");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Image imageOrigin = LoadImage("resources/parrots.png");
        ImageFormat(ref imageOrigin, PixelFormat.UncompressedR8G8B8A8);
        Texture2D texture = LoadTextureFromImage(imageOrigin);

        Image imageCopy = ImageCopy(imageOrigin);

        ImageProcess currentProcess = ImageProcess.None;
        bool textureReload = false;

        Rectangle[] toggleRecs = new Rectangle[NumProcesses];
        int mouseHoverRec = -1;

        for (int i = 0; i < NumProcesses; i++)
        {
            toggleRecs[i] = new Rectangle(40, 50 + 32 * i, 150, 30);
        }

        SetTargetFPS(60);
        //---------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------

            // Mouse toggle group logic
            for (int i = 0; i < NumProcesses; i++)
            {
                if (CheckCollisionPointRec(GetMousePosition(), toggleRecs[i]))
                {
                    mouseHoverRec = i;

                    if (IsMouseButtonReleased(MouseButton.Left))
                    {
                        currentProcess = (ImageProcess)i;
                        textureReload = true;
                    }
                    break;
                }
                else
                {
                    mouseHoverRec = -1;
                }
            }

            // Keyboard toggle group logic
            if (IsKeyPressed(KeyboardKey.Down))
            {
                currentProcess++;
                if ((int)currentProcess > (NumProcesses - 1))
                {
                    currentProcess = 0;
                }

                textureReload = true;
            }
            else if (IsKeyPressed(KeyboardKey.Up))
            {
                currentProcess--;
                if (currentProcess < 0)
                {
                    currentProcess = ImageProcess.FlipHorizontal;
                }

                textureReload = true;
            }

            if (textureReload)
            {
                UnloadImage(imageCopy);
                imageCopy = ImageCopy(imageOrigin);

                // NOTE: Image processing is a costly CPU process to be done every frame,
                // If image processing is required in a frame-basis, it should be done
                // with a texture and by shaders
                switch (currentProcess)
                {
                    case ImageProcess.ColorGrayScale:
                        ImageColorGrayscale(ref imageCopy);
                        break;
                    case ImageProcess.ColorTint:
                        ImageColorTint(ref imageCopy, Color.Green);
                        break;
                    case ImageProcess.ColorInvert:
                        ImageColorInvert(ref imageCopy);
                        break;
                    case ImageProcess.ColorContrast:
                        ImageColorContrast(ref imageCopy, -40);
                        break;
                    case ImageProcess.ColorBrightness:
                        ImageColorBrightness(ref imageCopy, -80);
                        break;
                    case ImageProcess.GaussianBlur:
                        ImageBlurGaussian(ref imageCopy, 10);
                        break;
                    case ImageProcess.FlipVertical:
                        ImageFlipVertical(ref imageCopy);
                        break;
                    case ImageProcess.FlipHorizontal:
                        ImageFlipHorizontal(ref imageCopy);
                        break;
                    default:
                        break;
                }

                // Get pixel data from image (RGBA 32bit)
                Color* pixels = LoadImageColors(imageCopy);
                UpdateTexture(texture, pixels);
                UnloadImageColors(pixels);

                textureReload = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawText("IMAGE PROCESSING:", 40, 30, 10, Color.DarkGray);

            // Draw rectangles
            for (int i = 0; i < NumProcesses; i++)
            {
                DrawRectangleRec(toggleRecs[i], (i == (int)currentProcess) ? Color.SkyBlue : Color.LightGray);
                DrawRectangleLines(
                    (int)toggleRecs[i].X,
                    (int)toggleRecs[i].Y,
                    (int)toggleRecs[i].Width,
                    (int)toggleRecs[i].Height,
                    (i == (int)currentProcess) ? Color.Blue : Color.Gray
                );

                int labelX = (int)(toggleRecs[i].X + toggleRecs[i].Width / 2);
                DrawText(
                    processText[i],
                    (int)(labelX - MeasureText(processText[i], 10) / 2),
                    (int)toggleRecs[i].Y + 11,
                    10,
                    (i == (int)currentProcess) ? Color.DarkBlue : Color.DarkGray
                );
            }

            int x = screenWidth - texture.Width - 60;
            int y = screenHeight / 2 - texture.Height / 2;
            DrawTexture(texture, x, y, Color.White);
            DrawRectangleLines(x, y, texture.Width, texture.Height, Color.Black);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadTexture(texture);
        UnloadImage(imageOrigin);
        UnloadImage(imageCopy);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
