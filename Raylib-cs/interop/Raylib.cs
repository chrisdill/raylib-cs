using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    [SuppressUnmanagedCodeSecurity]
    public static unsafe partial class Raylib
    {
        /// <summary>
        /// Used by DllImport to load the native library
        /// </summary>
        public const string nativeLibName = "raylib";

        public const string RAYLIB_VERSION = "4.2";

        public const float DEG2RAD = MathF.PI / 180.0f;
        public const float RAD2DEG = 180.0f / MathF.PI;

        /// <summary>
        /// Get color with alpha applied, alpha goes from 0.0f to 1.0f<br/>
        /// NOTE: Added for compatability with previous versions
        /// </summary>
        public static Color Fade(Color color, float alpha) => ColorAlpha(color, alpha);

        //------------------------------------------------------------------------------------
        // Window and Graphics Device Functions (Module: core)
        //------------------------------------------------------------------------------------

        // Window-related functions

        /// <summary>Initialize window and OpenGL context</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitWindow(int width, int height, sbyte* title);

        /// <summary>Check if KEY_ESCAPE pressed or Close icon pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool WindowShouldClose();

        /// <summary>Close window and unload OpenGL context</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseWindow();

        /// <summary>Check if window has been initialized successfully</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowReady();

        /// <summary>Check if window is currently fullscreen</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowFullscreen();

        /// <summary>Check if window is currently hidden (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowHidden();

        /// <summary>Check if window is currently minimized (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowMinimized();

        /// <summary>Check if window is currently maximized (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowMaximized();

        /// <summary>Check if window is currently focused (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowFocused();

        /// <summary>Check if window has been resized last frame</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowResized();

        /// <summary>Check if one specific window flag is enabled</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsWindowState(ConfigFlags flag);

        /// <summary>Set window configuration state using flags</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool SetWindowState(ConfigFlags flag);

        /// <summary>Clear window configuration state flags</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearWindowState(ConfigFlags flag);

        /// <summary>Toggle window state: fullscreen/windowed (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ToggleFullscreen();

        /// <summary>Set window state: maximized, if resizable (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MaximizeWindow();

        /// <summary>Set window state: minimized, if resizable (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MinimizeWindow();

        /// <summary>Set window state: not minimized/maximized (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RestoreWindow();

        /// <summary>Set icon for window (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowIcon(Image image);

        /// <summary>Set title for window (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowTitle(sbyte* title);

        /// <summary>Set window position on screen (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowPosition(int x, int y);

        /// <summary>Set monitor for the current window (fullscreen mode)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMonitor(int monitor);

        /// <summary>Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMinSize(int width, int height);

        /// <summary>Set window dimensions</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowSize(int width, int height);

        /// <summary>Set window opacity [0.0f..1.0f] (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowOpacity(float opacity);

        /// <summary>Get native window handle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* GetWindowHandle();

        /// <summary>Get current screen width</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenWidth();

        /// <summary>Get current screen height</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenHeight();

        /// <summary>Get current render width (it considers HiDPI)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderWidth();

        /// <summary>Get current render height (it considers HiDPI)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderHeight();

        /// <summary>Get number of connected monitors</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorCount();

        /// <summary>Get current connected monitor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCurrentMonitor();

        /// <summary>Get specified monitor position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMonitorPosition(int monitor);

        /// <summary>Get specified monitor width</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorWidth(int monitor);

        /// <summary>Get specified monitor height</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorHeight(int monitor);

        /// <summary>Get specified monitor physical width in millimetres</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorPhysicalWidth(int monitor);

        /// <summary>Get specified monitor physical height in millimetres</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorPhysicalHeight(int monitor);

        /// <summary>Get specified monitor refresh rate</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorRefreshRate(int monitor);

        /// <summary>Get window position XY on monitor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWindowPosition();

        /// <summary>Get window scale DPI factor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWindowScaleDPI();

        /// <summary>Get the human-readable, UTF-8 encoded name of the specified monitor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetMonitorName(int monitor);

        /// <summary>Get clipboard text content</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetClipboardText();

        /// <summary>Set clipboard text content</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetClipboardText(sbyte* text);

        /// <summary>Enable waiting for events on EndDrawing(), no automatic event polling</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableEventWaiting();

        /// <summary>Disable waiting for events on EndDrawing(), automatic events polling</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableEventWaiting();

        // Custom frame control functions
        // NOTE: Those functions are intended for advance users that want full control over the frame processing
        // By default EndDrawing() does this job: draws everything + SwapScreenBuffer() + manage frame timming + PollInputEvents()
        // To avoid that behaviour and control frame processes manually, enable in config.h: SUPPORT_CUSTOM_FRAME_CONTROL

        /// <summary>Swap back buffer with front buffer (screen drawing)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SwapScreenBuffer();

        /// <summary>Register all input events</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PollInputEvents();

        /// <summary>Wait for some time (halt program execution)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaitTime(double seconds);

        // Cursor-related functions

        /// <summary>Shows cursor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowCursor();

        /// <summary>Hides cursor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideCursor();

        /// <summary>Check if cursor is not visible</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsCursorHidden();

        /// <summary>Enables cursor (unlock cursor)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableCursor();

        /// <summary>Disables cursor (lock cursor)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableCursor();

        /// <summary>Disables cursor (lock cursor)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsCursorOnScreen();


        // Drawing-related functions

        /// <summary>Set background color (framebuffer clear color)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearBackground(Color color);

        /// <summary>Setup canvas (framebuffer) to start drawing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginDrawing();

        /// <summary>End canvas drawing and swap buffers (double buffering)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndDrawing();

        /// <summary>Initialize 2D mode with custom camera (2D)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginMode2D(Camera2D camera);

        /// <summary>Ends 2D mode with custom camera</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndMode2D();

        /// <summary>Initializes 3D mode with custom camera (3D)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginMode3D(Camera3D camera);

        /// <summary>Ends 3D mode and returns to default 2D orthographic mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndMode3D();

        /// <summary>Initializes render texture for drawing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginTextureMode(RenderTexture2D target);

        /// <summary>Ends drawing to render texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndTextureMode();

        /// <summary>Begin custom shader drawing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginShaderMode(Shader shader);

        /// <summary>End custom shader drawing (use default shader)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndShaderMode();

        /// <summary>Begin blending mode (alpha, additive, multiplied)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginBlendMode(BlendMode mode);

        /// <summary>End blending mode (reset to default: alpha blending)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndBlendMode();

        /// <summary>Begin scissor mode (define screen area for following drawing)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginScissorMode(int x, int y, int width, int height);

        /// <summary>End scissor mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndScissorMode();

        /// <summary>Begin stereo rendering (requires VR simulator)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginVrStereoMode(VrStereoConfig config);

        /// <summary>End stereo rendering (requires VR simulator)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndVrStereoMode();


        // VR stereo config functions for VR simulator

        /// <summary>Load VR stereo config for VR simulator device parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern VrStereoConfig LoadVrStereoConfig(VrDeviceInfo device);

        /// <summary>Unload VR stereo configs</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadVrStereoConfig(VrStereoConfig config);


        // Shader management functions

        /// <summary>Load shader from files and bind default locations</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader LoadShader(sbyte* vsFileName, sbyte* fsFileName);

        /// <summary>Load shader from code strings and bind default locations</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader LoadShaderFromMemory(sbyte* vsCode, sbyte* fsCode);

        /// <summary>Get shader uniform location</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetShaderLocation(Shader shader, sbyte* uniformName);

        /// <summary>Get shader attribute location</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetShaderLocationAttrib(Shader shader, sbyte* attribName);

        /// <summary>Set shader uniform value</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValue(Shader shader, int uniformLoc, void* value, ShaderUniformDataType uniformType);

        /// <summary>Set shader uniform value vector</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueV(Shader shader, int uniformLoc, void* value, ShaderUniformDataType uniformType, int count);

        /// <summary>Set shader uniform value (matrix 4x4)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueMatrix(Shader shader, int uniformLoc, Matrix4x4 mat);

        /// <summary>Set shader uniform value for texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueTexture(Shader shader, int uniformLoc, Texture2D texture);

        /// <summary>Unload shader from GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadShader(Shader shader);


        // Screen-space-related functions

        /// <summary>Get a ray trace from mouse position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Ray GetMouseRay(Vector2 mousePosition, Camera3D camera);

        /// <summary>Get camera transform matrix (view matrix)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 GetCameraMatrix(Camera3D camera);

        /// <summary>Get camera 2d transform matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 GetCameraMatrix2D(Camera2D camera);

        /// <summary>Get the screen space position for a 3d world space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreen(Vector3 position, Camera3D camera);

        /// <summary>Get size position for a 3d world space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreenEx(Vector3 position, Camera3D camera, int width, int height);

        /// <summary>Get the screen space position for a 2d camera world space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreen2D(Vector2 position, Camera2D camera);

        /// <summary>Get the world space position for a 2d camera screen space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetScreenToWorld2D(Vector2 position, Camera2D camera);


        // Timing-related functions

        /// <summary>Set target FPS (maximum)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTargetFPS(int fps);

        /// <summary>Get current FPS</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFPS();

        /// <summary>Get time in seconds for last frame drawn</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetFrameTime();

        /// <summary>Get elapsed time in seconds since InitWindow()</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetTime();


        // Misc. functions

        /// <summary>Get a random value between min and max (both included)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRandomValue(int min, int max);

        /// <summary>Set the seed for the random number generator</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRandomSeed(uint seed);

        /// <summary>Takes a screenshot of current screen (saved a .png)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TakeScreenshot(sbyte* fileName);

        /// <summary>Setup window configuration flags (view FLAGS)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetConfigFlags(ConfigFlags flags);

        /// <summary>Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TraceLog(TraceLogLevel logLevel, sbyte* text);

        /// <summary>Set the current threshold (minimum) log level</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLogLevel(TraceLogLevel logLevel);

        /// <summary>Internal memory allocator</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* MemAlloc(int size);

        /// <summary>Internal memory reallocator</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* MemRealloc(void* ptr, int size);

        /// <summary>Internal memory free</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MemFree(void* ptr);


        // Set custom callbacks
        // WARNING: Callbacks setup is intended for advance users

        /// <summary>Set custom trace log</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLogCallback(delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void> callback);

        /// <summary>Set custom file binary data loader</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLoadFileDataCallback(delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*> callback);

        /// <summary>Set custom file binary data saver</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSaveFileDataCallback(delegate* unmanaged[Cdecl]<sbyte*, void*, uint, CBool> callback);

        /// <summary>Set custom file text data loader</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLoadFileTextCallback(delegate* unmanaged[Cdecl]<sbyte*, sbyte*> callback);

        /// <summary>Set custom file text data saver</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSaveFileTextCallback(delegate* unmanaged[Cdecl]<sbyte*, sbyte*, CBool> callback);


        // Files management functions

        /// <summary>Load file data as byte array (read)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* LoadFileData(sbyte* fileName, uint* bytesRead);

        /// <summary>Unload file data allocated by LoadFileData()</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFileData(byte* data);

        /// <summary>Save data to file from byte array (write)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool SaveFileData(sbyte* fileName, void* data, uint bytesToWrite);

        /// <summary>Export data to code (.h), returns true on success</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ExportDataAsCode(sbyte* data, uint size, sbyte* fileName);

        // Load text data from file (read), returns a '\0' terminated string
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char* LoadFileText(sbyte* fileName);

        // Unload file text data allocated by LoadFileText()
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFileText(char* text);

        // Save text data to file (write), string must be '\0' terminated, returns true on success
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool SaveFileText(sbyte* fileName, char* text);

        // Check if file exists
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool FileExists(sbyte* fileName);

        // Check if a directory path exists
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool DirectoryExists(sbyte* dirPath);

        /// <summary>Check file extension</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsFileExtension(sbyte* fileName, sbyte* ext);

        /// <summary> Get file length in bytes</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFileLength(sbyte* fileName);

        /// <summary>Get pointer to extension for a filename string (includes dot: '.png')</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetFileExtension(sbyte* fileName);

        /// <summary>Get pointer to filename for a path string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetFileName(sbyte* filePath);

        /// <summary>Get filename string without extension (uses static string)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetFileNameWithoutExt(sbyte* filePath);

        /// <summary>Get full path for a given fileName with path (uses static string)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetDirectoryPath(sbyte* filePath);

        /// <summary>Get previous directory path for a given path (uses static string)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetPrevDirectoryPath(sbyte* dirPath);

        /// <summary>Get current working directory (uses static string)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetWorkingDirectory();

        /// <summary>Get the directory of the running application (uses static string)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetApplicationDirectory();

        /// <summary>Get filenames in a directory path (memory should be freed)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FilePathList LoadDirectoryFiles(sbyte* dirPath, int* count);

        /// <summary>Clear directory files paths buffers (free memory)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadDirectoryFiles(FilePathList files);

        /// <summary>Check if a given path is a file or a directory</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsPathFile(sbyte* path);

        /// <summary>Change working directory, return true on success</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ChangeDirectory(sbyte* dir);

        /// <summary>Check if a file has been dropped into window</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsFileDropped();

        /// <summary>Get dropped files names (memory should be freed)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FilePathList LoadDroppedFiles();

        /// <summary>Clear dropped files paths buffer (free memory)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadDroppedFiles(FilePathList files);

        /// <summary>Get file modification time (last write time)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFileModTime(sbyte* fileName);


        // Compression/Encoding functionality

        /// <summary>Compress data (DEFLATE algorithm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* CompressData(byte* data, int dataLength, int* compDataLength);

        /// <summary>Decompress data (DEFLATE algorithm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* DecompressData(byte* compData, int compDataLength, int* dataLength);

        /// <summary>Encode data to Base64 string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* EncodeDataBase64(byte* data, int dataLength, int* outputLength);

        /// <summary>Decode Base64 string data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* DecodeDataBase64(byte* data, int* outputLength);

        /// <summary>Open URL with default system browser (if available)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenURL(sbyte* url);

        //------------------------------------------------------------------------------------
        // Input Handling Functions (Module: core)
        //------------------------------------------------------------------------------------

        // Input-related functions: keyboard

        /// <summary>Detect if a key has been pressed once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsKeyPressed(KeyboardKey key);

        /// <summary>Detect if a key is being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsKeyDown(KeyboardKey key);

        /// <summary>Detect if a key has been released once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsKeyReleased(KeyboardKey key);

        /// <summary>Detect if a key is NOT being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsKeyUp(KeyboardKey key);

        /// <summary>Set a custom key to exit program (default is ESC)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetExitKey(KeyboardKey key);

        /// <summary>Get key pressed (keycode), call it multiple times for keys queued</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetKeyPressed();

        /// <summary>Get char pressed (unicode), call it multiple times for chars queued</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCharPressed();


        // Input-related functions: gamepads

        /// <summary>Detect if a gamepad is available</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsGamepadAvailable(int gamepad);

        /// <summary>Get gamepad internal name id</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* GetGamepadName(int gamepad);

        /// <summary>Detect if a gamepad button has been pressed once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsGamepadButtonPressed(int gamepad, GamepadButton button);

        /// <summary>Detect if a gamepad button is being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsGamepadButtonDown(int gamepad, GamepadButton button);

        /// <summary>Detect if a gamepad button has been released once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsGamepadButtonReleased(int gamepad, GamepadButton button);

        /// <summary>Detect if a gamepad button is NOT being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsGamepadButtonUp(int gamepad, GamepadButton button);

        /// <summary>Get the last gamepad button pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadButtonPressed();

        /// <summary>Get gamepad axis count for a gamepad</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadAxisCount(int gamepad);

        /// <summary>Get axis movement value for a gamepad axis</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGamepadAxisMovement(int gamepad, GamepadAxis axis);

        /// <summary>Set internal gamepad mappings (SDL_GameControllerDB)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetGamepadMappings(sbyte* mappings);


        // Input-related functions: mouse

        /// <summary>Detect if a mouse button has been pressed once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsMouseButtonPressed(MouseButton button);

        /// <summary>Detect if a mouse button is being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsMouseButtonDown(MouseButton button);

        /// <summary>Detect if a mouse button has been released once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsMouseButtonReleased(MouseButton button);

        /// <summary>Detect if a mouse button is NOT being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsMouseButtonUp(MouseButton button);

        /// <summary>Get mouse position X</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseX();

        /// <summary>Get mouse position Y</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseY();

        /// <summary>Get mouse position XY</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMousePosition();

        /// <summary>Get mouse delta between frames</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMouseDelta();

        /// <summary>Set mouse position XY</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMousePosition(int x, int y);

        /// <summary>Set mouse offset</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMouseOffset(int offsetX, int offsetY);

        /// <summary>Set mouse scaling</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMouseScale(float scaleX, float scaleY);

        /// <summary>Get mouse wheel movement for X or Y, whichever is larger</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMouseWheelMove();

        /// <summary>Get mouse wheel movement for both X and Y</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMouseWheelMoveV();

        /// <summary>Set mouse cursor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMouseCursor(MouseCursor cursor);


        // Input-related functions: touch

        /// <summary>Get touch position X for touch point 0 (relative to screen size)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchX();

        /// <summary>Get touch position Y for touch point 0 (relative to screen size)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchY();

        /// <summary>Get touch position XY for a touch point index (relative to screen size)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetTouchPosition(int index);

        /// <summary>Get touch point identifier for given index</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchPointId(int index);

        /// <summary>Get number of touch points</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchPointCount();

        //------------------------------------------------------------------------------------
        // Gestures and Touch Handling Functions (Module: gestures)
        //------------------------------------------------------------------------------------

        /// <summary>Enable a set of gestures using flags</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGesturesEnabled(Gesture flags);

        /// <summary>Check if a gesture have been detected</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsGestureDetected(Gesture gesture);


        /// <summary>Get latest detected gesture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Gesture GetGestureDetected();

        /// <summary>Get touch points count</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchPointsCount();

        /// <summary>Get gesture hold time in milliseconds</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureHoldDuration();

        /// <summary>Get gesture drag vector</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGestureDragVector();

        /// <summary>Get gesture drag angle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureDragAngle();

        /// <summary>Get gesture pinch delta</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGesturePinchVector();

        /// <summary>Get gesture pinch angle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGesturePinchAngle();

        //------------------------------------------------------------------------------------
        // Camera System Functions (Module: camera)
        //------------------------------------------------------------------------------------

        /// <summary>Set camera mode (multiple camera modes available)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMode(Camera3D camera, CameraMode mode);

        /// <summary>Update camera position for selected mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateCamera(Camera3D* camera);

        /// <summary>Set camera pan key to combine with mouse movement (free camera)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraPanControl(KeyboardKey panKey);

        /// <summary>Set camera alt key to combine with mouse movement (free camera)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraAltControl(KeyboardKey altKey);

        /// <summary>Set camera smooth zoom key to combine with mouse (free camera)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraSmoothZoomControl(KeyboardKey szKey);

        /// <summary>Set camera move controls (1st person and 3rd person cameras)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMoveControls(KeyboardKey frontKey, KeyboardKey backKey, KeyboardKey rightKey, KeyboardKey leftKey, KeyboardKey upKey, KeyboardKey downKey);

        //------------------------------------------------------------------------------------
        // Basic Shapes Drawing Functions (Module: shapes)
        //------------------------------------------------------------------------------------

        /// <summary>
        /// Set texture and rectangle to be used on shapes drawing<br/>
        /// NOTE: It can be useful when using basic shapes and one single font.<br/>
        /// Defining a white rectangle would allow drawing everything in a single draw call.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShapesTexture(Texture2D texture, Rectangle source);

        // Basic shapes drawing functions

        /// <summary>Draw a pixel</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixel(int posX, int posY, Color color);

        /// <summary>Draw a pixel (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixelV(Vector2 position, Color color);

        /// <summary>Draw a line</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color);

        /// <summary>Draw a line (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineV(Vector2 startPos, Vector2 endPos, Color color);

        /// <summary>Draw a line defining thickness</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color);

        /// <summary>Draw a line using cubic-bezier curves in-out</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color);

        /// <summary>Draw line using quadratic bezier curves with a control point</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineBezierQuad(Vector2 startPos, Vector2 endPos, Vector2 controlPos, float thick, Color color);

        /// <summary>Draw line using cubic bezier curves with 2 control points</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineBezierCubic(Vector2 startPos, Vector2 endPos, Vector2 startControlPos, Vector2 endControlPos, float thick, Color color);


        /// <summary>Draw lines sequence</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineStrip(Vector2* points, int numPoints, Color color);

        /// <summary>Draw a color-filled circle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircle(int centerX, int centerY, float radius, Color color);

        /// <summary>Draw a piece of a circle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleSector(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color);

        /// <summary>Draw circle sector outline</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleSectorLines(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color);

        /// <summary>Draw a gradient-filled circle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2);

        /// <summary>Draw a color-filled circle (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleV(Vector2 center, float radius, Color color);

        /// <summary>Draw circle outline</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleLines(int centerX, int centerY, float radius, Color color);

        /// <summary>Draw ellipse</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawEllipse(int centerX, int centerY, float radiusH, float radiusV, Color color);

        /// <summary>Draw ellipse outline</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawEllipseLines(int centerX, int centerY, float radiusH, float radiusV, Color color);

        /// <summary>Draw ring</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRing(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color);

        /// <summary>Draw ring outline</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRingLines(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color);

        /// <summary>Draw a color-filled rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangle(int posX, int posY, int width, int height, Color color);

        /// <summary>Draw a color-filled rectangle (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleV(Vector2 position, Vector2 size, Color color);

        /// <summary>Draw a color-filled rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRec(Rectangle rec, Color color);

        /// <summary>Draw a color-filled rectangle with pro parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color);

        /// <summary>Draw a vertical-gradient-filled rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2);

        /// <summary>Draw a horizontal-gradient-filled rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2);

        /// <summary>Draw a gradient-filled rectangle with custom vertex colors</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4);

        /// <summary>Draw rectangle outline</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleLines(int posX, int posY, int width, int height, Color color);

        /// <summary>Draw rectangle outline with extended parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleLinesEx(Rectangle rec, float lineThick, Color color);

        /// <summary>Draw rectangle with rounded edges</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color);

        /// <summary>Draw rectangle with rounded edges outline</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, float lineThick, Color color);

        /// <summary>Draw a color-filled triangle (vertex in counter-clockwise order!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

        /// <summary>Draw triangle outline (vertex in counter-clockwise order!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

        /// <summary>Draw a triangle fan defined by points (first vertex is the center)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleFan(Vector2* points, int numPoints, Color color);

        /// <summary>Draw a triangle strip defined by points</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleStrip(Vector2* points, int pointsCount, Color color);

        /// <summary>Draw a regular polygon (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color);

        /// <summary>Draw a polygon outline of n sides</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPolyLines(Vector2 center, int sides, float radius, float rotation, Color color);

        /// <summary>Draw a polygon outline of n sides with extended parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPolyLinesEx(Vector2 center, int sides, float radius, float rotation, float lineThick, Color color);

        // Basic shapes collision detection functions

        /// <summary>Check collision between two rectangles</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionRecs(Rectangle rec1, Rectangle rec2);

        /// <summary>Check collision between two circles</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2);

        /// <summary>Check collision between circle and rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec);

        /// <summary>Check if point is inside rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionPointRec(Vector2 point, Rectangle rec);

        /// <summary>Check if point is inside circle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius);

        /// <summary>Check if point is inside a triangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3);

        /// <summary>Check the collision between two lines defined by two points each, returns collision point by reference</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, Vector2* collisionPoint);

        /// <summary>Check if point belongs to line created between two points [p1] and [p2] with defined margin in pixels [threshold]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionPointLine(Vector2 point, Vector2 p1, Vector2 p2, int threshold);

        /// <summary>Get collision rectangle for two rectangles collision</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2);


        //------------------------------------------------------------------------------------
        // Texture Loading and Drawing Functions (Module: textures)
        //------------------------------------------------------------------------------------

        // Image loading functions
        // NOTE: This functions do not require GPU access

        /// <summary>Load image from file into CPU memory (RAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImage(sbyte* fileName);

        /// <summary>Load image from RAW file data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageRaw(sbyte* fileName, int width, int height, PixelFormat format, int headerSize);

        /// <summary>Load image sequence from file (frames appended to image.data)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageAnim(sbyte* fileName, int* frames);

        /// <summary>Load image from memory buffer, fileType refers to extension: i.e. "png"</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageFromMemory(sbyte* fileType, byte* fileData, int dataSize);

        /// <summary>Load image from GPU texture data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageFromTexture(Texture2D texture);

        /// <summary>Load image from screen buffer and (screenshot)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageFromScreen();

        /// <summary>Unload image from CPU memory (RAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImage(Image image);

        /// <summary>Export image data to file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ExportImage(Image image, sbyte* fileName);

        /// <summary>Export image as code file defining an array of bytes</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ExportImageAsCode(Image image, sbyte* fileName);


        // Image generation functions

        /// <summary>Generate image: plain color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageColor(int width, int height, Color color);

        /// <summary>Generate image: vertical gradient</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientV(int width, int height, Color top, Color bottom);

        /// <summary>Generate image: horizontal gradient</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientH(int width, int height, Color left, Color right);

        /// <summary>Generate image: radial gradient</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer);

        /// <summary>Generate image: checked</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2);

        /// <summary>Generate image: white noise</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageWhiteNoise(int width, int height, float factor);

        /// <summary>Generate image: cellular algorithm, bigger tileSize means bigger cells</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageCellular(int width, int height, int tileSize);


        // Image manipulation functions

        /// <summary>Create an image duplicate (useful for transformations)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageCopy(Image image);

        /// <summary>Create an image from another image piece</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageFromImage(Image image, Rectangle rec);

        /// <summary>Create an image from text (default font)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageText(sbyte* text, int fontSize, Color color);

        /// <summary>Create an image from text (custom sprite font)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageTextEx(Font font, sbyte* text, float fontSize, float spacing, Color tint);

        /// <summary>Convert image to POT (power-of-two)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageToPOT(Image* image, Color fill);

        /// <summary>Convert image data to desired format</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFormat(Image* image, PixelFormat newFormat);

        /// <summary>Apply alpha mask to image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaMask(Image* image, Image alphaMask);

        /// <summary>Clear alpha channel to desired color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaClear(Image* image, Color color, float threshold);

        /// <summary>Crop image depending on alpha value</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaCrop(Image* image, float threshold);

        /// <summary>Premultiply alpha channel</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaPremultiply(Image* image);

        /// <summary>Crop an image to a defined rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageCrop(Image* image, Rectangle crop);

        /// <summary>Resize image (Bicubic scaling algorithm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResize(Image* image, int newWidth, int newHeight);

        /// <summary>Resize image (Nearest-Neighbor scaling algorithm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeNN(Image* image, int newWidth, int newHeight);

        /// <summary>Resize canvas and fill with color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeCanvas(Image* image, int newWidth, int newHeight, int offsetX, int offsetY, Color color);

        /// <summary>Generate all mipmap levels for a provided image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageMipmaps(Image* image);

        /// <summary>Dither image data to 16bpp or lower (Floyd-Steinberg dithering)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDither(Image* image, int rBpp, int gBpp, int bBpp, int aBpp);

        /// <summary>Flip image vertically</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipVertical(Image* image);

        /// <summary>Flip image horizontally</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipHorizontal(Image* image);

        /// <summary>Rotate image clockwise 90deg</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCW(Image* image);

        /// <summary>Rotate image counter-clockwise 90deg</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCCW(Image* image);

        /// <summary>Modify image color: tint</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorTint(Image* image, Color color);

        /// <summary>Modify image color: invert</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorInvert(Image* image);

        /// <summary>Modify image color: grayscale</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorGrayscale(Image* image);

        /// <summary>Modify image color: contrast (-100 to 100)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorContrast(Image* image, float contrast);

        /// <summary>Modify image color: brightness (-255 to 255)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorBrightness(Image* image, int brightness);

        /// <summary>Modify image color: replace color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorReplace(Image* image, Color color, Color replace);

        /// <summary>Load color data from image as a Color array (RGBA - 32bit)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color* LoadImageColors(Image image);

        /// <summary>Load colors palette from image as a Color array (RGBA - 32bit)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color* LoadImagePalette(Image image, int maxPaletteSize, int* colorsCount);

        /// <summary>Unload color data loaded with LoadImageColors()</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImageColors(Color* colors);

        /// <summary>Unload colors palette loaded with LoadImagePalette()</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImagePalette(Color* colors);

        /// <summary>Get image alpha border rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle GetImageAlphaBorder(Image image, float threshold);

        /// <summary>Get image pixel color at (x, y) position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetImageColor(Image image, int x, int y);


        // Image drawing functions
        // NOTE: Image software-rendering functions (CPU)

        /// <summary>Clear image background with given color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageClearBackground(Image* dst, Color color);

        /// <summary>Draw pixel within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawPixel(Image* dst, int posX, int posY, Color color);

        /// <summary>Draw pixel within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawPixelV(Image* dst, Vector2 position, Color color);

        /// <summary>Draw line within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawLine(Image* dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color);

        /// <summary>Draw line within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawLineV(Image* dst, Vector2 start, Vector2 end, Color color);

        /// <summary>Draw circle within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawCircle(Image* dst, int centerX, int centerY, int radius, Color color);

        /// <summary>Draw circle within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawCircleV(Image* dst, Vector2 center, int radius, Color color);

        /// <summary>Draw rectangle within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangle(Image* dst, int posX, int posY, int width, int height, Color color);

        /// <summary>Draw rectangle within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangleV(Image* dst, Vector2 position, Vector2 size, Color color);

        /// <summary>Draw rectangle within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangleRec(Image* dst, Rectangle rec, Color color);

        /// <summary>Draw rectangle lines within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangleLines(Image* dst, Rectangle rec, int thick, Color color);

        /// <summary>Draw a source image within a destination image (tint applied to source)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDraw(Image* dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint);

        /// <summary>Draw text (using default font) within an image (destination)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawText(Image* dst, sbyte* text, int x, int y, int fontSize, Color color);

        /// <summary>Draw text (custom sprite font) within an image (destination)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawTextEx(Image* dst, Font font, sbyte* text, Vector2 position, float fontSize, float spacing, Color tint);


        // Texture loading functions
        // NOTE: These functions require GPU access

        /// <summary>Load texture from file into GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTexture(sbyte* fileName);

        /// <summary>Load texture from image data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTextureFromImage(Image image);

        /// <summary>Load cubemap from image, multiple image cubemap layouts supported</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTextureCubemap(Image image, CubemapLayout layout);

        /// <summary>Load texture for rendering (framebuffer)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderTexture2D LoadRenderTexture(int width, int height);

        /// <summary>Unload texture from GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadTexture(Texture2D texture);

        /// <summary>Unload render texture from GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadRenderTexture(RenderTexture2D target);

        /// <summary>Update GPU texture with new data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateTexture(Texture2D texture, void* pixels);

        /// <summary>Update GPU texture rectangle with new data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateTextureRec(Texture2D texture, Rectangle rec, void* pixels);


        // Texture configuration functions

        /// <summary>Generate GPU mipmaps for a texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenTextureMipmaps(Texture2D* texture);

        /// <summary>Set texture scaling filter mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextureFilter(Texture2D texture, TextureFilter filter);

        /// <summary>Set texture wrapping mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextureWrap(Texture2D texture, TextureWrap wrap);


        // Texture drawing functions

        /// <summary>Draw a Texture2D</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexture(Texture2D texture, int posX, int posY, Color tint);

        /// <summary>Draw a Texture2D with position defined as Vector2</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureV(Texture2D texture, Vector2 position, Color tint);

        /// <summary>Draw a Texture2D with extended parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint);

        /// <summary>Draw a part of a texture defined by a rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureRec(Texture2D texture, Rectangle source, Vector2 position, Color tint);

        /// <summary>Draw texture quad with tiling and offset parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureQuad(Texture2D texture, Vector2 tiling, Vector2 offset, Rectangle quad, Color tint);

        /// <summary>Draw part of a texture (defined by a rectangle) with rotation and scale tiled into dest</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureTiled(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, float scale, Color tint);

        /// <summary>Draw a part of a texture defined by a rectangle with 'pro' parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexturePro(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint);

        /// <summary>Draws a texture (or part of it) that stretches or shrinks nicely</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureNPatch(Texture2D texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint);

        /// <summary>Draw a textured polygon</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexturePoly(Texture2D texture, Vector2 center, Vector2* points, Vector2* texcoords, int pointsCount, Color tint);


        // Color/pixel related functions

        /// <summary>Get hexadecimal value for a Color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ColorToInt(Color color);

        /// <summary>Get color normalized as float [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4 ColorNormalize(Color color);

        /// <summary>Get color from normalized values [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorFromNormalized(Vector4 normalized);

        /// <summary>Get HSV values for a Color, hue [0..360], saturation/value [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 ColorToHSV(Color color);

        /// <summary>Get a Color from HSV values, hue [0..360], saturation/value [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorFromHSV(float hue, float saturation, float value);

        /// <summary>Get color with alpha applied, alpha goes from 0.0f to 1.0f</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorAlpha(Color color, float alpha);

        /// <summary>Get src alpha-blended into dst color with tint</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorAlphaBlend(Color dst, Color src, Color tint);

        /// <summary>Get Color structure from hexadecimal value</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetColor(uint hexValue);

        /// <summary>Get Color from a source pixel pointer of certain format</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetPixelColor(void* srcPtr, PixelFormat format);

        /// <summary>Set color formatted into destination pixel pointer</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPixelColor(void* dstPtr, Color color, PixelFormat format);

        /// <summary>Get pixel data size in bytes for certain format</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPixelDataSize(int width, int height, PixelFormat format);


        //------------------------------------------------------------------------------------
        // Font Loading and Text Drawing Functions (Module: text)
        //------------------------------------------------------------------------------------

        // Font loading/unloading functions

        /// <summary>Get the default Font</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font GetFontDefault();

        /// <summary>Load font from file into GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFont(sbyte* fileName);

        /// <summary>
        /// Load font from file with extended parameters, use NULL for fontChars and 0 for glyphCount to load
        /// the default character set
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontEx(sbyte* fileName, int fontSize, int* fontChars, int glyphCount);

        /// <summary>Load font from Image (XNA style)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontFromImage(Image image, Color key, int firstChar);

        /// <summary>Load font from memory buffer, fileType refers to extension: i.e. "ttf"</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontFromMemory(sbyte* fileType, byte* fileData, int dataSize, int fontSize, int* fontChars, int glyphCount);

        /// <summary>Load font data for further use</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlyphInfo* LoadFontData(byte* fileData, int dataSize, int fontSize, int* fontChars, int glyphCount, FontType type);

        /// <summary>Generate image font atlas using chars info</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageFontAtlas(GlyphInfo* chars, Rectangle** recs, int glyphCount, int fontSize, int padding, int packMethod);

        /// <summary>Unload font chars info data (RAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFontData(GlyphInfo* chars, int glyphCount);

        /// <summary>Unload Font from GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFont(Font font);

        /// <summary>Export font as code file, returns true on success</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ExportFontAsCode(Font font, sbyte* fileName);


        // Text drawing functions

        /// <summary>Shows current FPS</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawFPS(int posX, int posY);

        /// <summary>Draw text (using default font)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawText(sbyte* text, int posX, int posY, int fontSize, Color color);

        /// <summary>Draw text using font and additional parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextEx(Font font, sbyte* text, Vector2 position, float fontSize, float spacing, Color tint);

        /// <summary>Draw text using Font and pro parameters (rotation)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextPro(Font font, sbyte* text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint);

        /// <summary>Draw one character (codepoint)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float fontSize, Color tint);

        /// <summary>Draw multiple characters (codepoint)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextCodepoints(Font font, int* codepoints, int count, Vector2 position, float fontSize, float spacing, Color tint);

        // Text font info functions

        /// <summary>Measure string width for default font</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MeasureText(sbyte* text, int fontSize);

        /// <summary>Measure string size for Font</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 MeasureTextEx(Font font, sbyte* text, float fontSize, float spacing);

        /// <summary>Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGlyphIndex(Font font, int character);

        /// <summary>Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlyphInfo GetGlyphInfo(Font font, int codepoint);

        /// <summary>Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle GetGlyphAtlasRec(Font font, int codepoint);


        // Text codepoints management functions (unicode characters)

        /// <summary>Get all codepoints in a string, codepoints count returned by parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int* LoadCodepoints(sbyte* text, int* count);

        /// <summary>Unload codepoints data from memory</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadCodepoints(int* codepoints);

        /// <summary>Get total number of characters (codepoints) in a UTF8 encoded string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCodepointCount(sbyte* text);

        /// <summary>Get next codepoint in a UTF8 encoded string; 0x3f('?') is returned on failure</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCodepoint(sbyte* text, int* bytesProcessed);

        /// <summary>Encode codepoint into utf8 text (char array length returned as parameter)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* CodepointToUTF8(int codepoint, int* byteSize);

        /// <summary>Encode text as codepoints array into UTF-8 text string (WARNING: memory must be freed!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TextCodepointsToUTF8(int* codepoints, int length);


        // Text strings management functions (no UTF-8 strings, only byte chars)
        // NOTE: Some strings allocate memory internally for returned strings, just be careful!

        // <summary>Copy one string to another, returns bytes copied</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextCopy(char* dst, sbyte* src);

        /// <summary>Check if two text string are equal</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool TextIsEqual(sbyte* text1, sbyte* text2);

        /// <summary>Get text length, checks for '\0' ending</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint TextLength(sbyte* text);

        /// <summary>Text formatting with variables (sprintf style)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TextFormat(sbyte* text);

        /// <summary>Get a piece of a text string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TextSubtext(sbyte* text, int position, int length);

        /// <summary>Replace text string (WARNING: memory must be freed!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char* TextReplace(char* text, sbyte* replace, sbyte* by);

        /// <summary>Insert text in a position (WARNING: memory must be freed!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char* TextInsert(sbyte* text, sbyte* insert, int position);

        /// <summary>Join text strings with delimiter</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TextJoin(sbyte** textList, int count, sbyte* delimiter);

        /// <summary>Split text into multiple strings</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte** TextSplit(sbyte* text, char delimiter, int* count);

        /// <summary>Append text at specific position and move cursor!</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TextAppend(sbyte* text, sbyte* append, int* position);

        /// <summary>Find first text occurrence within a string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextFindIndex(sbyte* text, sbyte* find);

        /// <summary>Get upper case version of provided string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TextToUpper(sbyte* text);

        /// <summary>Get lower case version of provided string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TextToLower(sbyte* text);

        /// <summary>Get Pascal case notation version of provided string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TextToPascal(sbyte* text);

        /// <summary>Get integer value from text (negative values not supported)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextToInteger(sbyte* text);


        //------------------------------------------------------------------------------------
        // Basic 3d Shapes Drawing Functions (Module: models)
        //------------------------------------------------------------------------------------

        // Basic geometric 3D shapes drawing functions

        /// <summary>Draw a line in 3D world space</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color);

        /// <summary>Draw a point in 3D space, actually a small line</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPoint3D(Vector3 position, Color color);

        /// <summary>Draw a circle in 3D world space</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color);

        /// <summary>Draw a color-filled triangle (vertex in counter-clockwise order!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, Color color);

        /// <summary>Draw a triangle strip defined by points</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleStrip3D(Vector3* points, int pointsCount, Color color);

        /// <summary>Draw cube</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCube(Vector3 position, float width, float height, float length, Color color);

        /// <summary>Draw cube (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeV(Vector3 position, Vector3 size, Color color);

        /// <summary>Draw cube wires</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeWires(Vector3 position, float width, float height, float length, Color color);

        /// <summary>Draw cube wires (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeWiresV(Vector3 position, Vector3 size, Color color);

        /// <summary>Draw cube textured</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeTexture(Texture2D texture, Vector3 position, float width, float height, float length, Color color);

        /// <summary>Draw cube with a region of a texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeTextureRec(Texture2D texture, Vector3 position, float width, float height, float length, Color color);

        /// <summary>Draw sphere</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphere(Vector3 centerPos, float radius, Color color);

        /// <summary>Draw sphere with extended parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color);

        /// <summary>Draw sphere wires</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color);

        /// <summary>Draw a cylinder/cone</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);

        /// <summary>Draw a cylinder with base at startPos and top at endPos</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinderEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color);

        /// <summary>Draw a cylinder/cone wires</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);

        /// <summary>Draw a cylinder wires with base at startPos and top at endPos</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinderWiresEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color);

        /// <summary>Draw a plane XZ</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPlane(Vector3 centerPos, Vector2 size, Color color);

        /// <summary>Draw a ray line</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRay(Ray ray, Color color);

        /// <summary>Draw a grid (centered at (0, 0, 0))</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawGrid(int slices, float spacing);


        //------------------------------------------------------------------------------------
        // Model 3d Loading and Drawing Functions (Module: models)
        //------------------------------------------------------------------------------------

        // Model loading/unloading functions

        /// <summary>Load model from files (meshes and materials)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModel(sbyte* fileName);

        /// <summary>Load model from generated mesh (default material)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModelFromMesh(Mesh mesh);

        /// <summary>Unload model from memory (RAM and/or VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModel(Model model);

        /// <summary>Unload model (but not meshes) from memory (RAM and/or VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModelKeepMeshes(Model model);

        /// <summary>Compute model bounding box limits (considers all meshes)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern BoundingBox GetModelBoundingBox(Model model);

        // Mesh loading/unloading functions

        /// <summary>Upload vertex data into GPU and provided VAO/VBO ids</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UploadMesh(Mesh* mesh, CBool dynamic);

        /// <summary>Update mesh vertex data in GPU for a specific buffer index</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMeshBuffer(Mesh mesh, int index, void* data, int dataSize, int offset);

        /// <summary>Unload mesh from memory (RAM and/or VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMesh(Mesh* mesh);

        /// <summary>Draw a 3d mesh with material and transform</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawMesh(Mesh mesh, Material material, Matrix4x4 transform);

        /// <summary>Draw multiple mesh instances with material and different transforms</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawMeshInstanced(Mesh mesh, Material material, Matrix4x4* transforms, int instances);

        /// <summary>Export mesh data to file, returns true on success</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ExportMesh(Mesh mesh, sbyte* fileName);

        /// <summary>Compute mesh bounding box limits</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern BoundingBox GetMeshBoundingBox(Mesh mesh);

        /// <summary>Compute mesh tangents</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenMeshTangents(Mesh* mesh);

        // Material loading/unloading functions

        //TODO: safe Helper method
        /// <summary>Load materials from model file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Material* LoadMaterials(sbyte* fileName, int* materialCount);

        /// <summary>Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Material LoadMaterialDefault();

        /// <summary>Unload material from GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMaterial(Material material);

        /// <summary>Set texture for a material map type (MAP_DIFFUSE, MAP_SPECULAR...)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMaterialTexture(Material* material, MaterialMapIndex mapType, Texture2D texture);

        /// <summary>Set material for a mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModelMeshMaterial(Model* model, int meshId, int materialId);


        // Mesh generation functions

        /// <summary>Generate polygonal mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshPoly(int sides, float radius);

        /// <summary>Generate plane mesh (with subdivisions)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshPlane(float width, float length, int resX, int resZ);

        /// <summary>Generate cuboid mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCube(float width, float height, float length);

        /// <summary>Generate sphere mesh (standard sphere)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshSphere(float radius, int rings, int slices);

        /// <summary>Generate half-sphere mesh (no bottom cap)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshHemiSphere(float radius, int rings, int slices);

        /// <summary>Generate cylinder mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCylinder(float radius, float height, int slices);

        /// <summary>Generate cone/pyramid mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCone(float radius, float height, int slices);

        /// <summary>Generate torus mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshTorus(float radius, float size, int radSeg, int sides);

        /// <summary>Generate trefoil knot mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshKnot(float radius, float size, int radSeg, int sides);

        /// <summary>Generate heightmap mesh from image data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshHeightmap(Image heightmap, Vector3 size);

        /// <summary>Generate cubes-based map mesh from image data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize);

        // Model drawing functions

        /// <summary>Draw a model (with texture if set)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModel(Model model, Vector3 position, float scale, Color tint);

        /// <summary>Draw a model with extended parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);

        /// <summary>Draw a model wires (with texture if set)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelWires(Model model, Vector3 position, float scale, Color tint);

        /// <summary>Draw a model wires (with texture if set) with extended parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);

        /// <summary>Draw bounding box (wires)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBoundingBox(BoundingBox box, Color color);

        /// <summary>Draw a billboard texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboard(Camera3D camera, Texture2D texture, Vector3 center, float size, Color tint);

        /// <summary>Draw a billboard texture defined by source</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboardRec(Camera3D camera, Texture2D texture, Rectangle source, Vector3 position, Vector2 size, Color tint);

        /// <summary>Draw a billboard texture defined by source and rotation</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboardPro(Camera3D camera, Texture2D texture, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint);

        // Model animations loading/unloading functions

        /// <summary>Load model animations from file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ModelAnimation* LoadModelAnimations(sbyte* fileName, uint* animsCount);

        /// <summary>Update model animation pose</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateModelAnimation(Model model, ModelAnimation anim, int frame);

        /// <summary>Unload animation data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModelAnimation(ModelAnimation anim);

        /// <summary>Unload animation array data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModelAnimations(ModelAnimation[] animations, uint count);

        /// <summary>Check model animation skeleton match</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsModelAnimationValid(Model model, ModelAnimation anim);

        // Collision detection functions

        /// <summary>Detect collision between two spheres</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionSpheres(Vector3 center1, float radius1, Vector3 center2, float radius2);

        /// <summary>Detect collision between two bounding boxes</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2);

        /// <summary>Detect collision between box and sphere</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool CheckCollisionBoxSphere(BoundingBox box, Vector3 center, float radius);

        /// <summary>Detect collision between ray and sphere</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayCollision GetRayCollisionSphere(Ray ray, Vector3 center, float radius);

        /// <summary>Detect collision between ray and box</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayCollision GetRayCollisionBox(Ray ray, BoundingBox box);

        /// <summary>Get collision info between ray and mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayCollision GetRayCollisionMesh(Ray ray, Mesh mesh, Matrix4x4 transform);

        /// <summary>Get collision info between ray and triangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayCollision GetRayCollisionTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3);

        /// <summary>Get collision info between ray and quad</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayCollision GetRayCollisionQuad(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4);


        //------------------------------------------------------------------------------------
        // Audio Loading and Playing Functions (Module: audio)
        //------------------------------------------------------------------------------------

        // Audio device management functions

        /// <summary>Initialize audio device and context</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitAudioDevice();

        /// <summary>Close the audio device and context</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioDevice();

        /// <summary>Check if audio device has been initialized successfully</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsAudioDeviceReady();

        /// <summary>Set master volume (listener)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMasterVolume(float volume);


        // Wave/Sound loading/unloading functions

        /// <summary>Load wave data from file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWave(sbyte* fileName);

        /// <summary>Load wave from memory buffer, fileType refers to extension: i.e. "wav"</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWaveFromMemory(sbyte* fileType, byte* fileData, int dataSize);

        /// <summary>Load sound from file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSound(sbyte* fileName);

        /// <summary>Load sound from wave data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSoundFromWave(Wave wave);

        /// <summary>Update sound buffer with new data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateSound(Sound sound, void* data, int samplesCount);

        /// <summary>Unload wave data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadWave(Wave wave);

        /// <summary>Unload sound</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadSound(Sound sound);

        /// <summary>Export wave data to file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ExportWave(Wave wave, sbyte* fileName);

        /// <summary>Export wave sample data to code (.h)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool ExportWaveAsCode(Wave wave, sbyte* fileName);


        // Wave/Sound management functions

        /// <summary>Play a sound</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlaySound(Sound sound);

        /// <summary>Stop playing a sound</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopSound(Sound sound);

        /// <summary>Pause a sound</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseSound(Sound sound);

        /// <summary>Resume a paused sound</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeSound(Sound sound);

        /// <summary>Play a sound (using multichannel buffer pool)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlaySoundMulti(Sound sound);

        /// <summary>Stop any sound playing (using multichannel buffer pool)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopSoundMulti();

        /// <summary>Get number of sounds playing in the multichannel</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetSoundsPlaying();

        /// <summary>Check if a sound is currently playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsSoundPlaying(Sound sound);

        /// <summary>Set volume for a sound (1.0 is max level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundVolume(Sound sound, float volume);

        /// <summary>Set pitch for a sound (1.0 is base level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundPitch(Sound sound, float pitch);

        /// <summary>Set pan for a sound (0.5 is center)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundPan(Sound sound, float pan);

        /// <summary>Copy a wave to a new wave</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave WaveCopy(Wave wave);

        /// <summary>Crop a wave to defined samples range</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveCrop(Wave* wave, int initSample, int finalSample);

        /// <summary>Convert wave data to desired format</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveFormat(Wave* wave, int sampleRate, int sampleSize, int channels);

        /// <summary>Get samples data from wave as a floats array</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float* LoadWaveSamples(Wave wave);

        /// <summary>Unload samples data loaded with LoadWaveSamples()</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadWaveSamples(float* samples);

        // Music management functions

        /// <summary>Load music stream from file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Music LoadMusicStream(sbyte* fileName);

        //TODO: Span/Helper method
        /// <summary>Load music stream from data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Music LoadMusicStreamFromMemory(sbyte* fileType, byte* data, int dataSize);

        /// <summary>Unload music stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMusicStream(Music music);

        /// <summary>Start music playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayMusicStream(Music music);

        /// <summary>Check if music is playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsMusicStreamPlaying(Music music);

        /// <summary>Updates buffers for music streaming</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMusicStream(Music music);

        /// <summary>Stop music playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopMusicStream(Music music);

        /// <summary>Pause music playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseMusicStream(Music music);

        /// <summary>Resume playing paused music</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeMusicStream(Music music);

        /// <summary>Seek music to a position (in seconds)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SeekMusicStream(Music music, float position);

        /// <summary>Set volume for music (1.0 is max level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicVolume(Music music, float volume);

        /// <summary>Set pitch for a music (1.0 is base level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicPitch(Music music, float pitch);

        /// <summary>Set pan for a music (0.5 is center)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicPan(Music music, float pan);

        /// <summary>Get music time length (in seconds)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimeLength(Music music);

        /// <summary>Get current music time played (in seconds)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimePlayed(Music music);


        // AudioStream management functions

        /// <summary>Init audio stream (to stream raw audio pcm data)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern AudioStream LoadAudioStream(uint sampleRate, uint sampleSize, uint channels);

        /// <summary>Unload audio stream and free memory</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadAudioStream(AudioStream stream);

        /// <summary>Update audio stream buffers with data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateAudioStream(AudioStream stream, void* data, int samplesCount);

        /// <summary>Check if any audio stream buffers requires refill</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsAudioStreamProcessed(AudioStream stream);

        /// <summary>Play audio stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayAudioStream(AudioStream stream);

        /// <summary>Pause audio stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseAudioStream(AudioStream stream);

        /// <summary>Resume audio stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeAudioStream(AudioStream stream);

        /// <summary>Check if audio stream is playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool IsAudioStreamPlaying(AudioStream stream);

        /// <summary>Stop audio stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopAudioStream(AudioStream stream);

        /// <summary>Set volume for audio stream (1.0 is max level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamVolume(AudioStream stream, float volume);

        /// <summary>Set pitch for audio stream (1.0 is base level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamPitch(AudioStream stream, float pitch);

        /// <summary>Set pan for audio stream (0.5 is centered)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamPan(AudioStream stream, float pan);

        /// <summary>Default size for new audio streams</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamBufferSizeDefault(int size);

        /// <summary>Audio thread callback to request new data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamCallback(AudioStream stream, delegate* unmanaged[Cdecl]<sbyte*, uint, void> callback);

        /// <summary>Attach audio stream processor to stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void AttachAudioStreamProcessor(AudioStream stream, delegate* unmanaged[Cdecl]<sbyte*, uint, void> processor);

        /// <summary>Detach audio stream processor from stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DetachAudioStreamProcessor(AudioStream stream, delegate* unmanaged[Cdecl]<sbyte*, uint, void> processor);
    }
}
