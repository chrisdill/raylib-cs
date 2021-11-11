using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    [SuppressUnmanagedCodeSecurity]
    public static class Raylib
    {
        /// <summary>
        /// Used by DllImport to load the native library.
        /// </summary>
        public const string nativeLibName = "raylib";

        public const string RAYLIB_VERSION = "4.0";

        public const float DEG2RAD = MathF.PI / 180.0f;
        public const float RAD2DEG = 180.0f / MathF.PI;

        // Callbacks to hook some internal functions
        // WARNING: These callbacks are intended for advance users

        /// <summary>
        /// Logging: Redirect trace log messages
        /// WARNING: This callback is intended for advance users
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void TraceLogCallback(TraceLogLevel logLevel, string text, IntPtr args);

        /// <summary>
        /// FileIO: Load binary data
        /// WARNING: This callback is intended for advance users
        /// </summary>
        /// <returns><see cref="IntPtr"/> refers to a unsigned char *</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr LoadFileDataCallback(string fileName, ref int bytesRead);

        /// <summary>
        /// FileIO: Save binary data
        /// WARNING: This callback is intended for advance users
        /// </summary>
        /// <returns><see cref="IntPtr"/> refers to a void *</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool SaveFileDataCallback(string fileName, IntPtr data, ref int bytesToWrite);

        /// <summary>
        /// FileIO: Load text data
        /// WARNING: This callback is intended for advance users
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate string LoadFileTextCallback(string fileName);

        /// <summary>
        /// FileIO: Save text data
        /// WARNING: This callback is intended for advance users
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool SaveFileTextCallback(string fileName, string text);

        /// <summary>
        /// Returns color with alpha applied, alpha goes from 0.0f to 1.0f
        /// NOTE: Added for compatability with previous versions
        /// </summary>
        public static Color Fade(Color color, float alpha) => ColorAlpha(color, alpha);


        //------------------------------------------------------------------------------------
        // Window and Graphics Device Functions (Module: core)
        //------------------------------------------------------------------------------------

        // Window-related functions

        /// <summary>
        /// Initialize window and OpenGL context
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitWindow(int width, int height, [MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        /// <summary>Check if KEY_ESCAPE pressed or Close icon pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool WindowShouldClose();

        /// <summary>Close window and unload OpenGL context</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseWindow();

        /// <summary>Check if window has been initialized successfully</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowReady();

        /// <summary>Check if window is currently fullscreen</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowFullscreen();

        /// <summary>Check if window is currently hidden (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowHidden();

        /// <summary>Check if window is currently minimized (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowMinimized();

        /// <summary>Check if window is currently maximized (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowMaximized();

        /// <summary>Check if window is currently focused (only PLATFORM_DESKTOP)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowFocused();

        /// <summary>Check if window has been resized last frame</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowResized();

        /// <summary>Check if one specific window flag is enabled</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsWindowState(ConfigFlags flag);

        /// <summary>Set window configuration state using flags</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SetWindowState(ConfigFlags flag);

        /// <summary>Clear window configuration state flags</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearWindowState(ConfigFlags flag);

        /// <summary>Toggle fullscreen mode (only PLATFORM_DESKTOP)</summary>
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
        public static extern void SetWindowTitle([MarshalAs(UnmanagedType.LPUTF8Str)] string title);

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

        /// <summary>Get native window handle
        /// IntPtr refers to a void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWindowHandle();

        /// <summary>Get current screen width</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenWidth();

        /// <summary>Get current screen height</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenHeight();

        /// <summary>Get number of connected monitors</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorCount();

        /// <summary>Get current connected monitor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCurrentMonitor();

        /// <summary>Get specified monitor position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMonitorPosition(int monitor);

        /// <summary>Get primary monitor width</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorWidth(int monitor);

        /// <summary>Get primary monitor height</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorHeight(int monitor);

        /// <summary>Get primary monitor physical width in millimetres</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorPhysicalWidth(int monitor);

        /// <summary>Get primary monitor physical height in millimetres</summary>
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

        /// <summary>Get the human-readable, UTF-8 encoded name of the primary monitor</summary>
        [DllImport(nativeLibName, EntryPoint = "GetMonitorName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetMonitorName(int monitor);

        /// <summary>Get the human-readable, UTF-8 encoded name of the primary monitor</summary>
        public static string GetMonitorName(int monitor)
        {
            return Marshal.PtrToStringUTF8(INTERNAL_GetMonitorName(monitor));
        }

        /// <summary>Get clipboard text content</summary>
        [DllImport(nativeLibName, EntryPoint = "GetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetClipboardText();

        /// <summary>Get clipboard text content</summary>
        public static string GetClipboardText()
        {
            return Marshal.PtrToStringUTF8(INTERNAL_GetClipboardText());
        }

        /// <summary>Set clipboard text content</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetClipboardText([MarshalAs(UnmanagedType.LPUTF8Str)] string text);

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

        /// <summary>Wait for some milliseconds (halt program execution)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaitTime(float ms);

        // Cursor-related functions

        /// <summary>Shows cursor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowCursor();

        /// <summary>Hides cursor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideCursor();

        /// <summary>Check if cursor is not visible</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsCursorHidden();

        /// <summary>Enables cursor (unlock cursor)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableCursor();

        /// <summary>Disables cursor (lock cursor)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableCursor();

        /// <summary>Disables cursor (lock cursor)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsCursorOnScreen();


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
        public static extern Shader LoadShader(string vsFileName, string fsFileName);

        /// <summary>Load shader from code strings and bind default locations</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader LoadShaderFromMemory(string vsCode, string fsCode);

        /// <summary>Get shader uniform location</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetShaderLocation(Shader shader, string uniformName);

        /// <summary>Get shader attribute location</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetShaderLocationAttrib(Shader shader, string attribName);

        /// <summary>Set shader uniform value
        /// value refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValue(Shader shader, int uniformLoc, IntPtr value, ShaderUniformDataType uniformType);

        /// <summary>Set shader uniform value vector
        /// value refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueV(Shader shader, int uniformLoc, IntPtr value, ShaderUniformDataType uniformType, int count);

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

        /// <summary>Returns a ray trace from mouse position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Ray GetMouseRay(Vector2 mousePosition, Camera3D camera);

        /// <summary>Returns camera transform matrix (view matrix)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 GetCameraMatrix(Camera3D camera);

        /// <summary>Returns camera 2d transform matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 GetCameraMatrix2D(Camera2D camera);

        /// <summary>Returns the screen space position for a 3d world space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreen(Vector3 position, Camera3D camera);

        /// <summary>Returns size position for a 3d world space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreenEx(Vector3 position, Camera3D camera, int width, int height);

        /// <summary>Returns the screen space position for a 2d camera world space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreen2D(Vector2 position, Camera2D camera);

        /// <summary>Returns the world space position for a 2d camera screen space position</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetScreenToWorld2D(Vector2 position, Camera2D camera);


        // Timing-related functions

        /// <summary>Set target FPS (maximum)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTargetFPS(int fps);

        /// <summary>Returns current FPS</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFPS();

        /// <summary>Returns time in seconds for last frame drawn</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetFrameTime();

        /// <summary>Returns elapsed time in seconds since InitWindow()</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetTime();


        // Misc. functions

        /// <summary>Returns a random value between min and max (both included)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRandomValue(int min, int max);

        /// <summary>Set the seed for the random number generator</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRandomSeed(uint seed);

        /// <summary>Takes a screenshot of current screen (saved a .png)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TakeScreenshot(string fileName);

        /// <summary>Setup window configuration flags (view FLAGS)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetConfigFlags(ConfigFlags flags);

        /// <summary>Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TraceLog(TraceLogLevel logLevel, string text);

        /// <summary>Set the current threshold (minimum) log level</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLogLevel(TraceLogLevel logLevel);

        /// <summary>Internal memory allocator</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MemAlloc(int size);

        /// <summary>Internal memory reallocator</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MemRealloc(IntPtr ptr, int size);

        /// <summary>Internal memory free</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MemFree(IntPtr ptr);


        // Set custom callbacks
        // WARNING: Callbacks setup is intended for advance users

        /// <summary>Set custom trace log</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLogCallback(TraceLogCallback callback);

        /// <summary>Set custom file binary data loader</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLoadFileDataCallback(LoadFileDataCallback callback);

        /// <summary>Set custom file binary data saver</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSaveFileDataCallback(SaveFileDataCallback callback);

        /// <summary>Set custom file text data loader</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLoadFileTextCallback(LoadFileTextCallback callback);

        /// <summary>Set custom file text data saver</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSaveFileTextCallback(SaveFileTextCallback callback);


        // Files management functions

        /// <summary>Load file data as byte array (read)
        /// IntPtr refers to unsigned char *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadFileData(string fileName, ref int bytesRead);

        /// <summary>Unload file data allocated by LoadFileData()
        /// data refers to a unsigned char *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFileData(IntPtr data);

        /// <summary>Save data to file from byte array (write)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SaveFileData(string fileName, IntPtr data, int bytesToWrite);

        /// <summary>Check file extension</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsFileExtension(string fileName, string ext);

        /// <summary>Check if a file has been dropped into window</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsFileDropped();

        /// <summary>Get dropped files names (memory should be freed)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern byte** GetDroppedFiles(int* count);

        /// <summary>Clear dropped files paths buffer (free memory)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearDroppedFiles();

        /// <summary>Get file modification time (last write time)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFileModTime(string fileName);

        /// <summary>Compress data (DEFLATE algorythm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CompressData(byte[] data, int dataLength, ref int compDataLength);

        /// <summary>Decompress data (DEFLATE algorythm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DecompressData(byte[] compData, int compDataLength, ref int dataLength);


        // Persistent storage management

        /// <summary>Save integer value to storage file (to defined position)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SaveStorageValue(uint position, int value);

        /// <summary>Load integer value from storage file (from defined position)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LoadStorageValue(uint position);

        /// <summary>Open URL with default system browser (if available)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenURL(string url);

        //------------------------------------------------------------------------------------
        // Input Handling Functions (Module: core)
        //------------------------------------------------------------------------------------

        // Input-related functions: keyboard

        /// <summary>Detect if a key has been pressed once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsKeyPressed(KeyboardKey key);

        /// <summary>Detect if a key is being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsKeyDown(KeyboardKey key);

        /// <summary>Detect if a key has been released once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsKeyReleased(KeyboardKey key);

        /// <summary>Detect if a key is NOT being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsKeyUp(KeyboardKey key);

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
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGamepadAvailable(int gamepad);

        /// <summary>Return gamepad internal name id</summary>
        [DllImport(nativeLibName, EntryPoint = "GetGamepadName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetGamepadName(int gamepad);

        /// <summary>Return gamepad internal name id</summary>
        public static string GetGamepadName(int gamepad)
        {
            return Marshal.PtrToStringUTF8(INTERNAL_GetGamepadName(gamepad));
        }

        /// <summary>Detect if a gamepad button has been pressed once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGamepadButtonPressed(int gamepad, GamepadButton button);

        /// <summary>Detect if a gamepad button is being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGamepadButtonDown(int gamepad, GamepadButton button);

        /// <summary>Detect if a gamepad button has been released once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGamepadButtonReleased(int gamepad, GamepadButton button);

        /// <summary>Detect if a gamepad button is NOT being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGamepadButtonUp(int gamepad, GamepadButton button);

        /// <summary>Get the last gamepad button pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadButtonPressed();

        /// <summary>Return gamepad axis count for a gamepad</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadAxisCount(int gamepad);

        /// <summary>Return axis movement value for a gamepad axis</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGamepadAxisMovement(int gamepad, GamepadAxis axis);

        /// <summary>Set internal gamepad mappings (SDL_GameControllerDB)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetGamepadMappings(string mappings);


        // Input-related functions: mouse

        /// <summary>Detect if a mouse button has been pressed once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsMouseButtonPressed(MouseButton button);

        /// <summary>Detect if a mouse button is being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsMouseButtonDown(MouseButton button);

        /// <summary>Detect if a mouse button has been released once</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsMouseButtonReleased(MouseButton button);

        /// <summary>Detect if a mouse button is NOT being pressed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsMouseButtonUp(MouseButton button);

        /// <summary>Returns mouse position X</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseX();

        /// <summary>Returns mouse position Y</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseY();

        /// <summary>Returns mouse position XY</summary>
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

        /// <summary>Returns mouse wheel movement Y</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMouseWheelMove();

        /// <summary>Set mouse cursor</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMouseCursor(MouseCursor cursor);


        // Input-related functions: touch

        /// <summary>Returns touch position X for touch point 0 (relative to screen size)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchX();

        /// <summary>Returns touch position Y for touch point 0 (relative to screen size)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchY();

        /// <summary>Returns touch position XY for a touch point index (relative to screen size)</summary>
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
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGestureDetected(Gesture gesture);

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
        public static extern void UpdateCamera(ref Camera3D camera);

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

        /// <summary>Set texture and rectangle to be used on shapes drawing
        /// NOTE: It can be useful when using basic shapes and one single font,
        /// defining a font char white rectangle would allow drawing everything in a single draw call</summary>
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
        public static extern void DrawLineStrip(Vector2[] points, int numPoints, Color color);

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
        public static extern void DrawRectangleLinesEx(Rectangle rec, int lineThick, Color color);

        /// <summary>Draw rectangle with rounded edges</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color);

        /// <summary>Draw rectangle with rounded edges outline</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, int lineThick, Color color);

        /// <summary>Draw a color-filled triangle (vertex in counter-clockwise order!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

        /// <summary>Draw triangle outline (vertex in counter-clockwise order!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

        /// <summary>Draw a triangle fan defined by points (first vertex is the center)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleFan(Vector2[] points, int numPoints, Color color);

        /// <summary>Draw a triangle strip defined by points</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleStrip(Vector2[] points, int pointsCount, Color color);

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
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionRecs(Rectangle rec1, Rectangle rec2);

        /// <summary>Check collision between two circles</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2);

        /// <summary>Check collision between circle and rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec);

        /// <summary>Check if point is inside rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionPointRec(Vector2 point, Rectangle rec);

        /// <summary>Check if point is inside circle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius);

        /// <summary>Check if point is inside a triangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3);

        /// <summary>Check the collision between two lines defined by two points each, returns collision point by reference</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, ref Vector2 collisionPoint);

        /// <summary> Check if point belongs to line created between two points [p1] and [p2] with defined margin in pixels [threshold]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionPointLine(Vector2 point, Vector2 p1, Vector2 p2, int threshold);

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
        public static extern Image LoadImage(string fileName);

        /// <summary>Load image from RAW file data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageRaw(string fileName, int width, int height, PixelFormat format, int headerSize);

        /// <summary>Load image sequence from file (frames appended to image.data)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageAnim(string fileName, ref int frames);

        /// <summary>Load image from memory buffer, fileType refers to extension: i.e. "png"
        /// fileData refers to const unsigned char *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageFromMemory(string fileType, IntPtr fileData, int dataSize);

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
        public static extern void ExportImage(Image image, string fileName);

        /// <summary>Export image as code file defining an array of bytes</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportImageAsCode(Image image, string fileName);


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

        /// <summary>Generate image: cellular algorithm. Bigger tileSize means bigger cells</summary>
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
        public static extern Image ImageText([MarshalAs(UnmanagedType.LPUTF8Str)] string text, int fontSize, Color color);

        /// <summary>Create an image from text (custom sprite font)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageTextEx(Font font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, float fontSize, float spacing, Color tint);

        /// <summary>Convert image to POT (power-of-two)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageToPOT(ref Image image, Color fill);

        /// <summary>Convert image data to desired format</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFormat(ref Image image, PixelFormat newFormat);

        /// <summary>Apply alpha mask to image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaMask(ref Image image, Image alphaMask);

        /// <summary>Clear alpha channel to desired color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaClear(ref Image image, Color color, float threshold);

        /// <summary>Crop image depending on alpha value</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaCrop(ref Image image, float threshold);

        /// <summary>Premultiply alpha channel</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaPremultiply(ref Image image);

        /// <summary>Crop an image to a defined rectangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageCrop(ref Image image, Rectangle crop);

        /// <summary>Resize image (Bicubic scaling algorithm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResize(ref Image image, int newWidth, int newHeight);

        /// <summary>Resize image (Nearest-Neighbor scaling algorithm)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeNN(ref Image image, int newWidth, int newHeight);

        /// <summary>Resize canvas and fill with color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeCanvas(ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color color);

        /// <summary>Generate all mipmap levels for a provided image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageMipmaps(ref Image image);

        /// <summary>Dither image data to 16bpp or lower (Floyd-Steinberg dithering)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDither(ref Image image, int rBpp, int gBpp, int bBpp, int aBpp);

        /// <summary>Flip image vertically</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipVertical(ref Image image);

        /// <summary>Flip image horizontally</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipHorizontal(ref Image image);

        /// <summary>Rotate image clockwise 90deg</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCW(ref Image image);

        /// <summary>Rotate image counter-clockwise 90deg</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCCW(ref Image image);

        /// <summary>Modify image color: tint</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorTint(ref Image image, Color color);

        /// <summary>Modify image color: invert</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorInvert(ref Image image);

        /// <summary>Modify image color: grayscale</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorGrayscale(ref Image image);

        /// <summary>Modify image color: contrast (-100 to 100)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorContrast(ref Image image, float contrast);

        /// <summary>Modify image color: brightness (-255 to 255)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorBrightness(ref Image image, int brightness);

        /// <summary>Modify image color: replace color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorReplace(ref Image image, Color color, Color replace);

        /// <summary>Load color data from image as a Color array (RGBA - 32bit)
        /// IntPtr refers to Color *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadImageColors(Image image);

        /// <summary>Load colors palette from image as a Color array (RGBA - 32bit)
        /// IntPtr refers to Color *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadImagePaletee(Image image, int maxPaletteSize, ref int colorsCount);

        /// <summary>Unload color data loaded with LoadImageColors()
        /// colors refers to Color *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImageColors(IntPtr colors);

        /// <summary>Unload colors palette loaded with LoadImagePalette()
        /// colors refers to Color *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImagePaletee(IntPtr colors);

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
        public static extern void ImageClearBackground(ref Image dst, Color color);

        /// <summary>Draw pixel within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawPixel(ref Image dst, int posX, int posY, Color color);

        /// <summary>Draw pixel within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawPixelV(ref Image dst, Vector2 position, Color color);

        /// <summary>Draw line within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawLine(ref Image dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color);

        /// <summary>Draw line within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawLineV(ref Image dst, Vector2 start, Vector2 end, Color color);

        /// <summary>Draw circle within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawCircle(ref Image dst, int centerX, int centerY, int radius, Color color);

        /// <summary>Draw circle within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawCircleV(ref Image dst, Vector2 center, int radius, Color color);

        /// <summary>Draw rectangle within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangle(ref Image dst, int posX, int posY, int width, int height, Color color);

        /// <summary>Draw rectangle within an image (Vector version)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangleV(ref Image dst, Vector2 position, Vector2 size, Color color);

        /// <summary>Draw rectangle within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangleRec(ref Image dst, Rectangle rec, Color color);

        /// <summary>Draw rectangle lines within an image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangleLines(ref Image dst, Rectangle rec, int thick, Color color);

        /// <summary>Draw a source image within a destination image (tint applied to source)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDraw(ref Image dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint);

        /// <summary>Draw text (using default font) within an image (destination)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawText(ref Image dst, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, int x, int y, int fontSize, Color color);

        /// <summary>Draw text (custom sprite font) within an image (destination)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawTextEx(ref Image dst, Font font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Vector2 position, float fontSize, float spacing, Color tint);


        // Texture loading functions
        // NOTE: These functions require GPU access

        /// <summary>Load texture from file into GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTexture(string fileName);

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

        /// <summary>Update GPU texture with new data
        /// pixels refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateTexture(Texture2D texture, IntPtr pixels);

        /// <summary>Update GPU texture rectangle with new data
        /// pixels refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateTextureRec(Texture2D texture, Rectangle rec, IntPtr pixels);


        // Texture configuration functions

        /// <summary>Generate GPU mipmaps for a texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenTextureMipmaps(ref Texture2D texture);

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
        public static extern void DrawTexturePoly(Texture2D texture, Vector2 center, Vector2[] points, Vector2[] texcoords, int pointsCount, Color tint);


        // Color/pixel related functions

        /// <summary>Returns hexadecimal value for a Color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ColorToInt(Color color);

        /// <summary>Returns color normalized as float [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4 ColorNormalize(Color color);

        /// <summary>Returns color from normalized values [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorFromNormalized(Vector4 normalized);

        /// <summary>Returns HSV values for a Color, hue [0..360], saturation/value [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 ColorToHSV(Color color);

        /// <summary>Returns a Color from HSV values, hue [0..360], saturation/value [0..1]</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorFromHSV(float hue, float saturation, float value);

        /// <summary>Returns color with alpha applied, alpha goes from 0.0f to 1.0f</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorAlpha(Color color, float alpha);

        /// <summary>Returns src alpha-blended into dst color with tint</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorAlphaBlend(Color dst, Color src, Color tint);

        /// <summary>Get Color structure from hexadecimal value</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetColor(int hexValue);

        /// <summary>Get Color from a source pixel pointer of certain format</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetPixelColor(IntPtr srcPtr, PixelFormat format);

        /// <summary>Set color formatted into destination pixel pointer</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPixelColor(IntPtr dstPtr, Color color, PixelFormat format);

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
        public static extern Font LoadFont(string fileName);

        /// <summary>Load font from file with extended parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontEx(string fileName, int fontSize, int[] fontChars, int charsCount);

        /// <summary>Load font from Image (XNA style)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontFromImage(Image image, Color key, int firstChar);

        /// <summary>Load font from memory buffer, fileType refers to extension: i.e. "ttf"
        /// fileData refers to const unsigned char *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontFromMemory(string fileType, IntPtr fileData, int dataSize, int fontSize, int[] fontChars, int charsCount);

        /// <summary>Load font data for further use
        /// fileData refers to const unsigned char *
        /// IntPtr refers to GlyphInfo *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadFontData(IntPtr fileData, int dataSize, int fontSize, int[] fontChars, int charsCount, FontType type);

        /// <summary>Generate image font atlas using chars info</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageFontAtlas(IntPtr chars, ref IntPtr recs, int charsCount, int fontSize, int padding, int packMethod);

        /// <summary>Unload font chars info data (RAM)
        /// chars refers to GlpyhInfo *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFontData(IntPtr chars, int charsCount);

        /// <summary>Unload Font from GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFont(Font font);


        // Text drawing functions

        /// <summary>Shows current FPS</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawFPS(int posX, int posY);

        /// <summary>Draw text (using default font)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawText([MarshalAs(UnmanagedType.LPUTF8Str)] string text, int posX, int posY, int fontSize, Color color);

        /// <summary>Draw text using font and additional parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextEx(Font font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Vector2 position, float fontSize, float spacing, Color tint);

        /// <summary>Draw text using Font and pro parameters (rotation)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextPro(Font font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Vector2 position, float fontSize, float spacing, Color tint);

        /// <summary>Draw one character (codepoint)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float scale, Color tint);


        // Text misc. functions

        /// <summary>Measure string width for default font</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MeasureText([MarshalAs(UnmanagedType.LPUTF8Str)] string text, int fontSize);

        /// <summary>Measure string size for Font</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 MeasureTextEx(Font font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, float fontSize, float spacing);

        /// <summary>Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGlyphIndex(Font font, int character);

        /// <summary>Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlyphInfo GetGlyphInfo(Font font, int codepoint);

        /// <summary>Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle GetGlyphAtlasRec(Font font, int codepoint);

        // Text strings management functions
        // NOTE: Some strings allocate memory internally for returned strings, just be careful!

        /// <summary>Text formatting with variables (sprintf style)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string TextFormat(string text);

        /// <summary>Get a piece of a text string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string TextSubtext(string text, int position, int length);

        /// <summary>Append text at specific position and move cursor!</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TextAppend(ref char text, string append, ref int position);

        /// <summary>Get Pascal case notation version of provided string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string TextToPascal(string text);

        /// <summary>Get integer value from text (negative values not supported)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextToInteger(string text);

        /// <summary>Encode text codepoint into utf8 text (memory must be freed!)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string TextToUtf8(string text, int length);


        // UTF8 text strings management functions

        /// <summary>Get all codepoints in a string, codepoints count returned by parameters
        /// IntPtr refers to a int *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetCodepoints(string text, ref int count);

        /// <summary>Get total number of characters (codepoints) in a UTF8 encoded string</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCodepointsCount(string text);

        /// <summary>Returns next codepoint in a UTF8 encoded string; 0x3f('?') is returned on failure</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNextCodepoint(string text, ref int bytesProcessed);

        /// <summary>Encode codepoint into utf8 text (char array length returned as parameter)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string CodepointToUtf8(string text, ref int byteLength);


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
        public static extern void DrawTriangleStrip3D(Vector3[] points, int pointsCount, Color color);

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
        public static extern Model LoadModel(string fileName);

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
        public static extern void UploadMesh(ref Mesh mesh, bool dynamic);

        /// <summary>Update mesh vertex data in GPU for a specific buffer index</summary>
        /// <summary>data refers to a void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMeshBuffer(Mesh mesh, int index, IntPtr data, int dataSize, int offset);

        /// <summary>Unload mesh from memory (RAM and/or VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMesh(ref Mesh mesh);

        /// <summary>Draw a 3d mesh with material and transform</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawMesh(Mesh mesh, Material material, Matrix4x4 transform);

        /// <summary>Draw multiple mesh instances with material and different transforms</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawMeshInstanced(Mesh mesh, Material material, Matrix4x4[] transforms, int instances);

        /// <summary>Export mesh data to file, returns true on success</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ExportMesh(Mesh mesh, string fileName);

        /// <summary>Compute mesh bounding box limits</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern BoundingBox GetMeshBoundingBox(Mesh mesh);

        /// <summary>Compute mesh tangents</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenMeshTangents(ref Mesh mesh);

        /// <summary>Compute mesh binormals</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenMeshBinormals(ref Mesh mesh);


        // Material loading/unloading functions

        /// <summary>Load materials from model file</summary>
        /// <summary>IntPtr refers to Material *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadMaterials(string fileName, ref int materialCount);

        /// <summary>Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Material LoadMaterialDefault();

        /// <summary>Unload material from GPU memory (VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMaterial(Material material);

        /// <summary>Set texture for a material map type (MAP_DIFFUSE, MAP_SPECULAR...)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMaterialTexture(ref Material material, int mapType, Texture2D texture);

        /// <summary>Set material for a mesh</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModelMeshMaterial(ref Model model, int meshId, int materialId);


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
        public static extern void DrawBillboardRec(Camera3D camera, Texture2D texture, Rectangle source, Vector3 center, float size, Color tint);

        /// <summary>Draw a billboard texture defined by source and rotation</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboardPro(Camera3D camera, Texture2D texture, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint);

        // Model animations loading/unloading functions

        /// <summary>Load model animations from file
        /// IntPtr refers to ModelAnimation *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadModelAnimations(string fileName, ref int animsCount);

        /// <summary>Update model animation pose</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateModelAnimation(Model model, ModelAnimation anim, int frame);

        /// <summary>Unload animation data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModelAnimation(ModelAnimation anim);

        /// <summary>Unload animation array data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModelAnimations(ModelAnimation[] animations, int count);

        /// <summary>Check model animation skeleton match</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsModelAnimationValid(Model model, ModelAnimation anim);

        // Collision detection functions

        /// <summary>Detect collision between two spheres</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionSpheres(Vector3 center1, float radius1, Vector3 center2, float radius2);

        /// <summary>Detect collision between two bounding boxes</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2);

        /// <summary>Detect collision between box and sphere</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionBoxSphere(BoundingBox box, Vector3 center, float radius);

        /// <summary>Detect collision between ray and sphere</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GetRayCollisionSphere(Ray ray, Vector3 center, float radius);

        /// <summary>Detect collision between ray and box</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayCollision GetRayCollisionBox(Ray ray, BoundingBox box);

        /// <summary>Get collision info between ray and model</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayCollision GetRayCollisionModel(Ray ray, Model model);

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
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsAudioDeviceReady();

        /// <summary>Set master volume (listener)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMasterVolume(float volume);


        // Wave/Sound loading/unloading functions

        /// <summary>Load wave data from file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWave(string fileName);

        /// <summary>Load wave from memory buffer, fileType refers to extension: i.e. "wav"
        /// fileData refers to a const unsigned char *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWaveFromMemory(string fileType, IntPtr fileData, int dataSize);

        /// <summary>Load sound from file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSound(string fileName);

        /// <summary>Load sound from wave data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSoundFromWave(Wave wave);

        /// <summary>Update sound buffer with new data</summary>
        /// <summary>data refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateSound(Sound sound, IntPtr data, int samplesCount);

        /// <summary>Unload wave data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadWave(Wave wave);

        /// <summary>Unload sound</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadSound(Sound sound);

        /// <summary>Export wave data to file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportWave(Wave wave, string fileName);

        /// <summary>Export wave sample data to code (.h)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportWaveAsCode(Wave wave, string fileName);


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
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsSoundPlaying(Sound sound);

        /// <summary>Set volume for a sound (1.0 is max level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundVolume(Sound sound, float volume);

        /// <summary>Set pitch for a sound (1.0 is base level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundPitch(Sound sound, float pitch);

        /// <summary>Convert wave data to desired format</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveFormat(ref Wave wave, int sampleRate, int sampleSize, int channels);

        /// <summary>Copy a wave to a new wave</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave WaveCopy(Wave wave);

        /// <summary>Crop a wave to defined samples range</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveCrop(ref Wave wave, int initSample, int finalSample);

        /// <summary>Get samples data from wave as a floats array
        /// IntPtr refers to float *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadWaveSamples(Wave wave);

        /// <summary>Unload samples data loaded with LoadWaveSamples()
        /// samples refers to float *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadWaveSamples(IntPtr samples);

        // Music management functions

        /// <summary>Load music stream from file</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Music LoadMusicStream(string fileName);

        /// <summary>Load music stream from data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Music LoadMusicStreamFromMemory(string fileType, IntPtr data, int dataSize);

        /// <summary>Unload music stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMusicStream(Music music);

        /// <summary>Start music playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayMusicStream(Music music);

        /// <summary>Check if music is playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsMusicStreamPlaying(Music music);

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

        /// <summary>Update audio stream buffers with data
        /// data refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateAudioStream(AudioStream stream, IntPtr data, int samplesCount);

        /// <summary>Check if any audio stream buffers requires refill</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsAudioStreamProcessed(AudioStream stream);

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
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsAudioStreamPlaying(AudioStream stream);

        /// <summary>Stop audio stream</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopAudioStream(AudioStream stream);

        /// <summary>Set volume for audio stream (1.0 is max level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamVolume(AudioStream stream, float volume);

        /// <summary>Set pitch for audio stream (1.0 is base level)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamPitch(AudioStream stream, float pitch);

        /// <summary>Default size for new audio streams</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamBufferSizeDefault(int size);
    }
}
