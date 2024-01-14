/*******************************************************************************************
*
*   raylib [shaders] example - Apply a postprocessing shader to a scene
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Shaders;

public class PostProcessing
{
    public const int GLSL_VERSION = 330;

    enum PostproShader
    {
        FxGrayScale = 0,
        FxPosterization,
        FxDreamVision,
        FxPixelizer,
        FxCrossHatching,
        FxCrossStiching,
        FxPredatorView,
        FxScanLines,
        FxFishEye,
        FxSobel,
        FxBloom,
        FxBlur,
        //FX_FXAA
        Max
    }

    static string[] postproShaderText = new string[] {
            "GRAYSCALE",
            "POSTERIZATION",
            "DREAM_VISION",
            "PIXELIZER",
            "CROSS_HATCHING",
            "CROSS_STITCHING",
            "PREDATOR_VIEW",
            "SCANLINES",
            "FISHEYE",
            "SOBEL",
            "BLOOM",
            "BLUR",
            //"FXAA"
        };

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Enable Multi Sampling Anti Aliasing 4x (if available)
        SetConfigFlags(ConfigFlags.Msaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - postprocessing shader");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.Position = new Vector3(2.0f, 3.0f, 2.0f);
        camera.Target = new Vector3(0.0f, 1.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        Model model = LoadModel("resources/models/obj/church.obj");
        Texture2D texture = LoadTexture("resources/models/obj/church_diffuse.png");

        // Set model diffuse texture
        Raylib.SetMaterialTexture(ref model, 0, MaterialMapIndex.Albedo, ref texture);

        Vector3 position = new(0.0f, 0.0f, 0.0f);

        // Load all postpro shaders
        // NOTE 1: All postpro shader use the base vertex shader (DEFAULT_VERTEX_SHADER)
        // NOTE 2: We load the correct shader depending on GLSL version
        Shader[] shaders = new Shader[(int)PostproShader.Max];

        // NOTE: Defining null (NULL) for vertex shader forces usage of internal default vertex shader
        string shaderPath = "resources/shaders/glsl330";
        shaders[(int)PostproShader.FxGrayScale] = LoadShader(null, $"{shaderPath}/grayscale.fs");
        shaders[(int)PostproShader.FxPosterization] = LoadShader(null, $"{shaderPath}/posterization.fs");
        shaders[(int)PostproShader.FxDreamVision] = LoadShader(null, $"{shaderPath}/dream_vision.fs");
        shaders[(int)PostproShader.FxPixelizer] = LoadShader(null, $"{shaderPath}/pixelizer.fs");
        shaders[(int)PostproShader.FxCrossHatching] = LoadShader(null, $"{shaderPath}/cross_hatching.fs");
        shaders[(int)PostproShader.FxCrossStiching] = LoadShader(null, $"{shaderPath}/cross_stitching.fs");
        shaders[(int)PostproShader.FxPredatorView] = LoadShader(null, $"{shaderPath}/predator.fs");
        shaders[(int)PostproShader.FxScanLines] = LoadShader(null, $"{shaderPath}/scanlines.fs");
        shaders[(int)PostproShader.FxFishEye] = LoadShader(null, $"{shaderPath}/fisheye.fs");
        shaders[(int)PostproShader.FxSobel] = LoadShader(null, $"{shaderPath}/sobel.fs");
        shaders[(int)PostproShader.FxBloom] = LoadShader(null, $"{shaderPath}/bloom.fs");
        shaders[(int)PostproShader.FxBlur] = LoadShader(null, $"{shaderPath}/blur.fs");

        int currentShader = (int)PostproShader.FxGrayScale;

        // Create a RenderTexture2D to be used for render to texture
        RenderTexture2D target = LoadRenderTexture(screenWidth, screenHeight);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.Orbital);

            if (IsKeyPressed(KeyboardKey.Right))
            {
                currentShader++;
            }
            else if (IsKeyPressed(KeyboardKey.Left))
            {
                currentShader--;
            }

            if (currentShader >= (int)PostproShader.Max)
            {
                currentShader = 0;
            }
            else if (currentShader < 0)
            {
                currentShader = (int)PostproShader.Max - 1;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            // Enable drawing to texture
            BeginTextureMode(target);
            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            DrawModel(model, position, 0.1f, Color.White);

            DrawGrid(10, 1.0f);

            EndMode3D();

            // End drawing to texture (now we have a texture available for next passes)
            EndTextureMode();

            // Render previously generated texture using selected postpro shader
            BeginShaderMode(shaders[currentShader]);

            // NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
            DrawTextureRec(
                target.Texture,
                new Rectangle(0, 0, target.Texture.Width, -target.Texture.Height),
                new Vector2(0, 0),
                Color.White
            );

            EndShaderMode();

            DrawRectangle(0, 9, 580, 30, ColorAlpha(Color.LightGray, 0.7f));

            DrawText("(c) Church 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, Color.Gray);

            DrawText("CURRENT POSTPRO SHADER:", 10, 15, 20, Color.Black);
            DrawText(postproShaderText[currentShader], 330, 15, 20, Color.Red);
            DrawText("< >", 540, 10, 30, Color.DarkBlue);

            DrawFPS(700, 15);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        for (int i = 0; i < (int)PostproShader.Max; i++)
        {
            UnloadShader(shaders[i]);
        }

        UnloadTexture(texture);
        UnloadModel(model);
        UnloadRenderTexture(target);

        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
