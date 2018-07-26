#region License

/* Raylib# - C# Wrapper for raylib 2.0
 *
 *
 */

#endregion

#region Using Statements

using System;
using System.Runtime.InteropServices;

#endregion

namespace Raylibcs
{
    #region Raylib# Enums

    // Keyboard Function Keys
    public enum Keys
    {
        KEY_SPACE = 32,
        KEY_ESCAPE = 256,
        KEY_ENTER = 257,
        KEY_TAB = 258,
        KEY_BACKSPACE = 259,
        KEY_INSERT = 260,
        KEY_DELETE = 261,
        KEY_RIGHT = 262,
        KEY_LEFT = 263,
        KEY_DOWN = 264,
        KEY_UP = 265,
        KEY_PAGE_UP = 266,
        KEY_PAGE_DOWN = 267,
        KEY_HOME = 268,
        KEY_END = 269,
        KEY_CAPS_LOCK = 280,
        KEY_SCROLL_LOCK = 281,
        KEY_NUM_LOCK = 282,
        KEY_PRINT_SCREEN = 283,
        KEY_PAUSE = 284,
        KEY_F1 = 290,
        KEY_F2 = 291,
        KEY_F3 = 292,
        KEY_F4 = 293,
        KEY_F5 = 294,
        KEY_F6 = 295,
        KEY_F7 = 296,
        KEY_F8 = 297,
        KEY_F9 = 298,
        KEY_F10 = 299,
        KEY_F11 = 300,
        KEY_F12 = 301,
        KEY_LEFT_SHIFT = 340,
        KEY_LEFT_CONTROL = 341,
        KEY_LEFT_ALT = 342,
        KEY_RIGHT_SHIFT = 344,
        KEY_RIGHT_CONTROL = 345,
        KEY_RIGHT_ALT = 346,
        KEY_GRAVE = 96,
        KEY_SLASH = 47,
        KEY_BACKSLASH = 92,

        // Keyboard Alpha Numeric Keys
        KEY_ZERO = 48,
        KEY_ONE = 49,
        KEY_TWO = 50,
        KEY_THREE = 51,
        KEY_FOUR = 52,
        KEY_FIVE = 53,
        KEY_SIX = 54,
        KEY_SEVEN = 55,
        KEY_EIGHT = 56,
        KEY_NINE = 57,
        KEY_A = 65,
        KEY_B = 66,
        KEY_C = 67,
        KEY_D = 68,
        KEY_E = 69,
        KEY_F = 70,
        KEY_G = 71,
        KEY_H = 72,
        KEY_I = 73,
        KEY_J = 74,
        KEY_K = 75,
        KEY_L = 76,
        KEY_M = 77,
        KEY_N = 78,
        KEY_O = 79,
        KEY_P = 80,
        KEY_Q = 81,
        KEY_R = 82,
        KEY_S = 83,
        KEY_T = 84,
        KEY_U = 85,
        KEY_V = 86,
        KEY_W = 87,
        KEY_X = 88,
        KEY_Y = 89,
        KEY_Z = 90,

        // Android Physical Buttons
        KEY_BACK = 4,
        KEY_MENU = 82,
        KEY_VOLUME_UP = 24,
        KEY_VOLUME_DOWN = 25
    }

    // Mouse Buttons
    public enum Mouse
    {
        MOUSE_LEFT_BUTTON = 0,
        MOUSE_RIGHT_BUTTON = 1,
        MOUSE_MIDDLE_BUTTON = 2
    }
  
    #endregion

    public static class Raylibcs
    {
        #region Raylib# Variables

        /* Used by DllImport to load the native library. */
        private const string nativeLibName = "raylib.dll";
        private const int MAX_SHADER_LOCATIONS = 32;
        private const int MAX_MATERIAL_MAPS = 12;

        #endregion

        #region Raylib.h

        // Vector2 type
        public struct Vector2
        {
            public float x;
            public float y;

            public Vector2(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }

        // Vector3 type
        public struct Vector3
        {
            public float x;
            public float y;
            public float z;

            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        // Vector4 type
        public struct Vector4
        {
            public float x;
            public float y;
            public float z;
            public float w;

            public Vector4(float x, float y, float z, float w)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.w = w;
            }
        }

        // Matrix type (OpenGL style 4x4 - right handed, column major)
        public struct Matrix
        {
            public float m0, m4, m8, m12;
            public float m1, m5, m9, m13;
            public float m2, m6, m10, m14;
            public float m3, m7, m11, m15;
        }

        // Color type, RGBA (32bit)
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct Color
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;

            public Color(byte r, byte g, byte b, byte a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }
        }

        // Rectangle type
        public struct Rectangle
        {
            public float x;
            public float y;
            public float width;
            public float height;

            public Rectangle(float x, float y, float width, float height)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }
        }

        // Image type, bpp always RGBA (32bit)
        // NOTE: Data stored in CPU memory (RAM)
        public struct Image
        {
            public IntPtr data; // Image raw data
            public int width; // Image base width
            public int height; // Image base height
            public int mipmaps; // Mipmap levels, 1 by default
            public int format; // Data format (PixelFormat type)
        }

        // Texture2D type
        // NOTE: Data stored in GPU memory
        public struct Texture2D
        {
            public uint id; // OpenGL texture id
            public int width; // Texture base width
            public int height; // Texture base height
            public int mipmaps; // Mipmap levels, 1 by default
            public int format; // Data format (PixelFormat type)
        }

        // Texture type, same as Texture2D
        // typedef Texture2D Texture;

        // RenderTexture2D type, for texture rendering
        public struct RenderTexture2D
        {
            public uint id; // OpenGL Framebuffer Object (FBO) id
            public Texture2D texture; // Color buffer attachment texture
            public Texture2D depth; // Depth buffer attachment texture
        }

        // RenderTexture type, same as RenderTexture2D
        // typedef RenderTexture2D RenderTexture;

        // Font character info
        public struct CharInfo
        {
            public int value; // Character value (Unicode)
            public Rectangle rec; // Character rectangle in sprite font
            public int offsetX; // Character offset X when drawing
            public int offsetY; // Character offset Y when drawing
            public int advanceX; // Character advance position X
            public byte[] data; // Character pixel data (grayscale)
        }

        // Font type, includes texture and charSet array data
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct Font
        {
            public Texture2D texture; // Font texture
            public int baseSize; // Base size (default chars height)
            public int charsCount; // Number of characters
            public CharInfo[] chars; // Characters info data
        }

        // public static Color SpriteFont Font     // SpriteFont type fallback, defaults to Font

        // Camera type, defines a camera position/orientation in 3d space
        public struct Camera3D
        {
            public Vector3 position; // Camera position
            public Vector3 target; // Camera target it looks-at
            public Vector3 up; // Camera up vector (rotation over its axis)

            public float
                fovy; // Camera field-of-view apperture in Y (degrees) in perspective, used as near plane width in orthographic

            public int type; // Camera type, defines projection type: CAMERA_PERSPECTIVE or CAMERA_ORTHOGRAPHIC
        }

        // public static Color Camera Camera3D     // Camera type fallback, defaults to Camera3D

        // Camera2D type, defines a 2d camera
        public struct Camera2D
        {
            public Vector2 offset; // Camera offset (displacement from target)
            public Vector2 target; // Camera target (rotation and zoom origin)
            public float rotation; // Camera rotation in degrees
            public float zoom; // Camera zoom (scaling), should be 1.0f by default
        }

        // Bounding box type
        public struct BoundingBox
        {
            public Vector3 min; // Minimum vertex box-corner
            public Vector3 max; // Maximum vertex box-corner
        }

        // Vertex data definning a mesh
        // NOTE: Data stored in CPU memory (and GPU)
        public struct Mesh
        {
            public int vertexCount; // Number of vertices stored in arrays
            public int triangleCount; // Number of triangles stored (indexed or not)
            public float[] vertices; // Vertex position (XYZ - 3 components per vertex) (shader-location = 0)
            public float[] texcoords; // Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1)
            public float[] texcoords2; // Vertex second texture coordinates (useful for lightmaps) (shader-location = 5)
            public float[] normals; // Vertex normals (XYZ - 3 components per vertex) (shader-location = 2)
            public float[] tangents; // Vertex tangents (XYZW - 4 components per vertex) (shader-location = 4)
            public byte[] colors; // Vertex colors (RGBA - 4 components per vertex) (shader-location = 3)
            public ushort[] indices; // Vertex indices (in case vertex data comes indexed)

            public uint vaoId; // OpenGL Vertex Array Object id
            //public uint vboId[7];        // OpenGL Vertex Buffer Objects id (7 types of vertex data)
        }

        // Shader type (generic)
        public struct Shader
        {
            public uint id; // Shader program id
            //public int locs[MAX_SHADER_LOCATIONS]; // Shader locations array
        }

        // Material texture map
        public struct MaterialMap
        {
            public Texture2D texture; // Material map texture
            public Color color; // Material map color
            public float value; // Material map value
        }

        // Material type (generic)
        public struct Material
        {
            public Shader shader; // Material shader
            //MaterialMap maps[MAX_MATERIAL_MAPS]; // Material maps
            //float[] params;          // Material generic parameters (if required)
        }

        // Model type
        public struct Model
        {
            public Mesh mesh; // Vertex data buffers (RAM and VRAM)
            public Matrix transform; // Local transform matrix
            public Material material; // Shader and textures data
        }

        // Ray type (useful for raycast)
        public struct Ray
        {
            public Vector3 position; // Ray position (origin)
            public Vector3 direction; // Ray direction

            public Ray(Vector3 position, Vector3 direction)
            {
                this.position = position;
                this.direction = direction;
            }
        }

        // Raycast hit information
        public struct RayHitInfo
        {
            public bool hit; // Did the ray hit something?
            public float distance; // Distance to nearest hit
            public Vector3 position; // Position of nearest hit
            public Vector3 normal; // Surface normal of hit
        }

        // Wave type, defines audio wave data
        public struct Wave
        {
            public uint sampleCount; // Number of samples
            public uint sampleRate; // Frequency (samples per second)
            public uint sampleSize; // Bit depth (bits per sample): 8, 16, 32 (24 not supported)
            public uint channels; // Number of channels (1-mono, 2-stereo)
            public IntPtr data; // Buffer data pointer
        }

        // Sound source type
        [StructLayout(LayoutKind.Sequential)]
        public struct Sound
        {
            public IntPtr audioBuffer; // Pointer to internal data used by the audio system
            public uint source; // Audio source id
            public uint buffer; // Audio buffer id
            public int format; // Audio format specifier
        }

        // Music type (file streaming from memory)
        // NOTE: Anything longer than ~10 seconds should be streamed
        // typedef struct MusicData *Music;
        public struct MusicData
        {
        }

        // Audio stream type
        // NOTE: Useful to create custom audio streams not bound to a specific file
        public struct AudioStream
        {
            public uint sampleRate; // Frequency (samples per second)
            public uint sampleSize; // Bit depth (bits per sample): 8, 16, 32 (24 not supported)
            public uint channels; // Number of channels (1-mono, 2-stereo)
            public IntPtr audioBuffer; // Pointer to internal data used by the audio system.
            public int format; // Audio format specifier

            public uint source; // Audio source id
            //public uint buffers[2];    // Audio buffers (double buffering)
        }

        // Head-Mounted-Display device parameters
        public struct VrDeviceInfo
        {
            public int hResolution; // HMD horizontal resolution in pixels
            public int vResolution; // HMD vertical resolution in pixels
            public float hScreenSize; // HMD horizontal size in meters
            public float vScreenSize; // HMD vertical size in meters
            public float vScreenCenter; // HMD screen center in meters
            public float eyeToScreenDistance; // HMD distance between eye and display in meters
            public float lensSeparationDistance; // HMD lens separation distance in meters

            public float interpupillaryDistance; // HMD IPD (distance between pupils) in meters
            //public float lensDistortionValues[4];  // HMD lens distortion constant parameters
            //public float chromaAbCorrection[4];    // HMD chromatic aberration correction parameters
        }

        // Window-related functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            InitWindow(int width, int height, string title); // Initialize Window and Graphics Context (OpenGL)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseWindow(); // Close window and unload OpenGL context

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WindowShouldClose(); // Check if KEY_ESCAPE pressed or Close icon pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsWindowMinimized(); // Check if window has been minimized (or lost focus)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ToggleFullscreen(); // Toggle fullscreen mode (only PLATFORM_DESKTOP)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowIcon(Image image); // Set icon for window (only PLATFORM_DESKTOP)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowTitle(string title); // Set title for window (only PLATFORM_DESKTOP)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetWindowPosition(int x, int y); // Set window position on screen (only PLATFORM_DESKTOP)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMonitor(int monitor); // Set monitor for the current window (fullscreen mode)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetWindowMinSize(int width, int height); // Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenWidth(); // Get current screen width

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenHeight(); // Get current screen height

        // Cursor-related functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowCursor(); // Shows cursor

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideCursor(); // Hides cursor

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsCursorHidden(); // Check if cursor is not visible

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableCursor(); // Enables cursor (unlock cursor)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableCursor(); // Disables cursor (lock cursor)

        // Drawing-related functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearBackground(Color color); // Set background color (framebuffer clear color)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginDrawing(); // Setup canvas (framebuffer) to start drawing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndDrawing(); // End canvas drawing and swap buffers (double buffering)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Begin2dMode(Camera2D camera); // Initialize 2D mode with custom camera (2D)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void End2dMode(); // Ends 2D mode with custom camera

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Begin3dMode(Camera camera); // Initializes 3D mode with custom camera (3D)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void End3dMode(); // Ends 3D mode and returns to default 2D orthographic mode

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginTextureMode(RenderTexture2D target); // Initializes render texture for drawing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndTextureMode(); // Ends drawing to render texture

        // Screen-space-related functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Ray
            GetMouseRay(Vector2 mousePosition, Camera camera); // Returns a ray trace from mouse position

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2
            GetWorldToScreen(Vector3 position,
                Camera camera); // Returns the screen space position for a 3d world space position

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix GetCameraMatrix(Camera camera); // Returns camera transform matrix (view matrix)

        // Timming-related functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTargetFPS(int fps); // Set target FPS (maximum)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFPS(); // Returns current FPS

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetFrameTime(); // Returns time in seconds for last frame drawn

        // Color-related functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetHexValue(Color color); // Returns hexadecimal value for a Color

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetColor(int hexValue); // Returns a Color struct from hexadecimal value

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color
            Fade(Color color, float alpha); // Color fade-in or fade-out, alpha goes from 0.0f to 1.0f

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float[] ColorToFloat(Color color); // Converts Color to float array and normalizes

        // Math useful functions (available from raymath.h)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float[] VectorToFloat(Vector3 vec); // Returns Vector3 as float array

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float[] MatrixToFloat(Matrix mat); // Returns Matrix as float array

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Zero(); // Vector with components value 0.0f

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3One(); // Vector with components value 1.0f

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixIdentity(); // Returns identity matrix

        // Misc. functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowLogo(); // Activate raylib logo at startup (can be done with flags)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetConfigFlags(char flags); // Setup window configuration flags (view FLAGS)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            TraceLog(int logType, string text, object[] args); // Show trace log messages (INFO, WARNING, ERROR, DEBUG)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            TakeScreenshot(string fileName); // Takes a screenshot of current screen (saved a .png)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int
            GetRandomValue(int min, int max); // Returns a random value between min and max (both included)

        // Files management functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsFileExtension(string fileName, string ext); // Check file extension

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetExtension(string fileName); // Get file extension

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetDirectoryPath(string fileName); // Get directory for a given fileName (with path)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetWorkingDirectory(); // Get current working directory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ChangeDirectory(string dir); // Change working directory, returns true if success

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsFileDropped(); // Check if a file has been dropped into window

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char[][] GetDroppedFiles(int[] count); // Get dropped files names

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearDroppedFiles(); // Clear dropped files paths buffer

        // Persistent storage management
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            StorageSaveValue(int position, int value); // Save integer value to storage file (to defined position)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int
            StorageLoadValue(int position); // Load integer value from storage file (from defined position)

        // Input-related functions: keyboard
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyPressed(int key); // Detect if a key has been pressed once

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyDown(int key); // Detect if a key is being pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyReleased(int key); // Detect if a key has been released once

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyUp(int key); // Detect if a key is NOT being pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetKeyPressed(); // Get latest key pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetExitKey(int key); // Set a custom key to exit program (default is ESC)

        // Input-related functions: gamepads
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadAvailable(int gamepad); // Detect if a gamepad is available

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadName(int gamepad, string name); // Check gamepad name (if available)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetGamepadName(int gamepad); // Return gamepad internal name id

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            IsGamepadButtonPressed(int gamepad, int button); // Detect if a gamepad button has been pressed once

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            IsGamepadButtonDown(int gamepad, int button); // Detect if a gamepad button is being pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            IsGamepadButtonReleased(int gamepad, int button); // Detect if a gamepad button has been released once

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            IsGamepadButtonUp(int gamepad, int button); // Detect if a gamepad button is NOT being pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadButtonPressed(); // Get the last gamepad button pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadAxisCount(int gamepad); // Return gamepad axis count for a gamepad

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float
            GetGamepadAxisMovement(int gamepad, int axis); // Return axis movement value for a gamepad axis

        // Input-related functions: mouse
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonPressed(int button); // Detect if a mouse button has been pressed once

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonDown(int button); // Detect if a mouse button is being pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonReleased(int button); // Detect if a mouse button has been released once

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonUp(int button); // Detect if a mouse button is NOT being pressed

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseX(); // Returns mouse position X

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseY(); // Returns mouse position Y

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMousePosition(); // Returns mouse position XY

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMousePosition(Vector2 position); // Set mouse position XY

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseWheelMove(); // Returns mouse wheel movement Y

        // Input-related functions: touch
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchX(); // Get touch position X for touch point 0 (relative to screen size)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchY(); // Get touch position Y for touch point 0 (relative to screen size)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2
            GetTouchPosition(int index); // Get touch position XY for a touch point index (relative to screen size)

        // Gestures-related functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGesturesEnabled(uint gestureFlags); // Enable a set of gestures using flags

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGestureDetected(int gesture); // Check if a gesture have been detected

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGestureDetected(); // Get latest detected gesture

        // Get touch points count
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchPointsCount();

        // Get gesture hold time in milliseconds
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureHoldDuration();

        // Get gesture drag vector
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGestureDragVector();

        // Get gesture drag angle
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureDragAngle();

        // Get gesture pinch delta
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGesturePinchVector();

        // Get gesture pinch angle
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGesturePinchAngle();

        // Camera-related functions

        // Set camera mode (multiple camera modes available)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMode(Camera camera, int mode);

        // Update camera position for selected mode
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateCamera(ref Camera camera);

        // Set camera pan key to combine with mouse movement (free camera)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraPanControl(int panKey);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetCameraAltControl(int altKey); // Set camera alt key to combine with mouse movement (free camera)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetCameraSmoothZoomControl(int szKey); // Set camera smooth zoom key to combine with mouse (free camera)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMoveControls(int frontKey, int backKey, int rightKey, int leftKey, int upKey,
            int downKey); // Set camera move controls (1st person and 3rd person cameras)

        // module: shapes

        // Basic shapes drawing functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixel(int posX, int posY, Color color); // Draw a pixel

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixelV(Vector2 position, Color color); // Draw a pixel (Vector version)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color); // Draw a line

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawLineV(Vector2 startPos, Vector2 endPos, Color color); // Draw a line (Vector version)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color); // Draw a line defining thickness

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick,
                Color color); // Draw a line using cubic-bezier curves in-out

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawCircle(int centerX, int centerY, float radius, Color color); // Draw a color-filled circle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawCircleGradient(int centerX, int centerY, float radius, Color color1,
                Color color2); // Draw a gradient-filled circle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawCircleV(Vector2 center, float radius, Color color); // Draw a color-filled circle (Vector version)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawCircleLines(int centerX, int centerY, float radius, Color color); // Draw circle outline

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawRectangle(int posX, int posY, int width, int height, Color color); // Draw a color-filled rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRec(Rectangle rec, Color color); // Draw a color-filled rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation,
                Color color); // Draw a color-filled rectangle with pro parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1,
            Color color2); // Draw a vertical-gradient-filled rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1,
            Color color2); // Draw a horizontal-gradient-filled rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3,
                Color col4); // Draw a gradient-filled rectangle with custom vertex colors

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawRectangleV(Vector2 position, Vector2 size,
                Color color); // Draw a color-filled rectangle (Vector version)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawRectangleLines(int posX, int posY, int width, int height, Color color); // Draw rectangle outline

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawRectangleT(int posX, int posY, int width, int height,
                Color color); // Draw rectangle using text character

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color); // Draw a color-filled triangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color); // Draw triangle outline

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawPoly(Vector2 center, int sides, float radius, float rotation,
                Color color); // Draw a regular polygon (Vector version)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawPolyEx(Vector2[] points, int numPoints, Color color); // Draw a closed polygon defined by points

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPolyExLines(Vector2[] points, int numPoints, Color color); // Draw polygon lines

        // Basic shapes collision detection functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionRecs(Rectangle rec1, Rectangle rec2); // Check collision between two rectangles

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2,
                float radius2); // Check collision between two circles

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionCircleRec(Vector2 center, float radius,
                Rectangle rec); // Check collision between circle and rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle
            GetCollisionRec(Rectangle rec1, Rectangle rec2); // Get collision rectangle for two rectangles collision

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionPointRec(Vector2 point, Rectangle rec); // Check if point is inside rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius); // Check if point is inside circle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2,
                Vector2 p3); // Check if point is inside a triangle

        // module: textures

        // Image/Texture2D data loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImage(string fileName); // Load an image into CPU memory (RAM)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            LoadImageEx(Color[] pixels, int width, int height); // Load image data from Color array data (RGBA - 32bit)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            LoadImagePro(IntPtr data, int width, int height, int format); // Load image from raw data with parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            LoadImageRaw(string fileName, int width, int height, int format,
                int headerSize); // Load image data from RAW file

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTexture(string fileName); // Load an image as texture into GPU memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTextureFromImage(Image image); // Load a texture from image data

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderTexture2D
            LoadRenderTexture(int width, int height); // Load a texture to be used for rendering

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImage(Image image); // Unload image from CPU memory (RAM)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadTexture(Texture2D texture); // Unload texture from GPU memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadRenderTexture(RenderTexture2D target); // Unload render texture from GPU memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color[] GetImageData(Image image); // Get pixel data from image as a Color struct array

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            GetTextureData(Texture2D texture); // Get pixel data from GPU texture and return an Image

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateTexture(Texture2D texture, IntPtr pixels); // Update GPU texture with new data

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SaveImageAs(string fileName, Image image); // Save image to a PNG file

        // Image manipulation functions

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageToPOT(ref Image image, Color fillColor); // Convert image to POT (power-of-two)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFormat(ref Image image, int newFormat); // Convert image data to desired format

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaMask(ref Image image, Image alphaMask); // Apply alpha mask to image

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            ImageDither(ref Image image, int rBpp, int gBpp, int bBpp,
                int aBpp); // Dither image data to 16bpp or lower (Floyd-Steinberg dithering)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageCopy(Image image); // Create an image duplicate (useful for transformations)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageCrop(ref Image image, Rectangle crop); // Crop an image to a defined rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            ImageResize(ref Image image, int newWidth, int newHeight); // Resize and image (bilinear filtering)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            ImageResizeNN(ref Image image, int newWidth,
                int newHeight); // Resize and image (Nearest-Neighbor scaling algorithm)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            ImageText(string text, int fontSize, Color color); // Create an image from text (default font)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            ImageTextEx(SpriteFont font, string text, int fontSize, int spacing,
                Color tint); // Create an image from text (custom sprite font)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            ImageDraw(ref Image dst, Image src, Rectangle srcRec,
                Rectangle dstRec); // Draw a source image within a destination image

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            ImageDrawText(ref Image dst, Vector2 position, string text, int fontSize,
                Color color); // Draw text (default font) within an image (destination)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawTextEx(ref Image dst, Vector2 position, SpriteFont font, string text,
            int fontSize, int spacing, Color color); // Draw text (custom sprite font) within image

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipVertical(ref Image image); // Flip image vertically

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipHorizontal(ref Image image); // Flip image horizontally

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorTint(ref Image image, Color color); // Modify image color: tint

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorInvert(ref Image image); // Modify image color: invert

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorGrayscale(ref Image image); // Modify bimage color: grayscale

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            ImageColorContrast(ref Image image, float contrast); // Modify image color: contrast (-100 to 100)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            ImageColorBrightness(ref Image image, int brightness); // Modify image color: brightness (-255 to 255)

        // Image generation functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            GenImageGradientV(int width, int height, Color top, Color bottom); // Generate image: vertical gradient

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            GenImageGradientH(int width, int height, Color left, Color right); // Generate image: horizontal gradient

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientRadial(int width, int height, float density, Color inner,
            Color outer); // Generate image: radial gradient

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1,
            Color col2); // Generate image: checked

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            GenImageWhiteNoise(int width, int height, float factor); // Generate image: white noise

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            GenImagePerlinNoise(int width, int height, float scale); // Generate image: perlin noise

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image
            GenImageCellular(int width, int height,
                int tileSize); // Generate image: cellular algorithm. Bigger tileSize means bigger cells

        // Texture2D configuration functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenTextureMipmaps(ref Texture2D texture); // Generate GPU mipmaps for a texture

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetTextureFilter(Texture2D texture, int filterMode); // Set texture scaling filter mode

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextureWrap(Texture2D texture, int wrapMode); // Set texture wrapping mode

        // Texture2D drawing functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexture(Texture2D texture, int posX, int posY, Color tint); // Draw a Texture2D

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawTextureV(Texture2D texture, Vector2 position,
                Color tint); // Draw a Texture2D with position defined as Vector2

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale,
            Color tint); // Draw a Texture2D with extended parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawTextureRec(Texture2D texture, Rectangle sourceRec, Vector2 position,
                Color tint); // Draw a part of a texture defined by a rectangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexturePro(Texture2D texture, Rectangle sourceRec, Rectangle destRec,
            Vector2 origin, // Draw a part of a texture defined by a rectangle with 'pro' parameters
            float rotation, Color tint);

        // module: text

        // SpriteFont loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SpriteFont GetDefaultFont(); // Get the default SpriteFont

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SpriteFont LoadSpriteFont(string fileName); // Load a SpriteFont image into GPU memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SpriteFont
            LoadSpriteFontEx(string fileName, int fontSize, int numChars,
                int fontChars); // Load a SpriteFont from TTF font with parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadSpriteFont(SpriteFont spriteFont); // Unload SpriteFont from GPU memory

        // Text drawing functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawFPS(int posX, int posY); // Shows current FPS on top-left corner

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawText(string text, int posX, int posY, int fontSize, Color color); // Draw text (using default font)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextEx(SpriteFont spriteFont, string text, Vector2 position, int fontSize,
            int spacing, Color tint); // Draw text using SpriteFont and additional parameters

        // Text misc. functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MeasureText(string text, int fontSize); // Measure string width for default font

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2
            MeasureTextEx(SpriteFont spriteFont, string text, int fontSize,
                int spacing); // Measure string size for SpriteFont

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string
            FormatText(string text, object[] args); // Formatting of text with variables to 'embed'

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string SubText(string text, int position, int length); // Get a piece of a text string

        // module: models

        // Basic geometric 3D shapes drawing functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawLine3D(Vector3 startPos, Vector3 endPos, Color color); // Draw a line in 3D world space

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle,
            Color color); // Draw a circle in 3D world space

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawCube(Vector3 position, float width, float height, float length, Color color); // Draw cube

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeV(Vector3 position, Vector3 size, Color color); // Draw cube (Vector version)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawCubeWires(Vector3 position, float width, float height, float length, Color color); // Draw cube wires

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeTexture(Texture2D texture, Vector3 position, float width, float height,
            float length, Color color); // Draw cube textured

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphere(Vector3 centerPos, float radius, Color color); // Draw sphere

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices,
                Color color); // Draw sphere with extended parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color); // Draw sphere wires

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height,
            int slices, Color color); // Draw a cylinder/cone

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height,
            int slices, Color color); // Draw a cylinder/cone wires

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPlane(Vector3 centerPos, Vector2 size, Color color); // Draw a plane XZ

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRay(Ray ray, Color color); // Draw a ray line

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawGrid(int slices, float spacing); // Draw a grid (centered at (0, 0, 0))

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawGizmo(Vector3 position); // Draw simple gizmo

        // Model loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModel(string fileName); // Load model from files (mesh and material)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModelFromMesh(Mesh mesh); // Load model from generated mesh

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModel(Model model); // Unload model from memory (RAM and/or VRAM)

        // Mesh loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh LoadMesh(string fileName); // Load mesh from file

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMesh(ref Mesh mesh); // Unload mesh from memory (RAM and/or VRAM)

        // Mesh generation functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh
            GenMeshPlane(float width, float length, int resX, int resZ); // Generate plane mesh (with subdivisions)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCube(float width, float height, float length); // Generate cuboid mesh

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh
            GenMeshSphere(float radius, int rings, int slices); // Generate sphere mesh (standard sphere)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh
            GenMeshHemiSphere(float radius, int rings, int slices); // Generate half-sphere mesh (no bottom cap)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCylinder(float radius, float height, int slices); // Generate cylinder mesh

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshTorus(float radius, float size, int radSeg, int sides); // Generate torus mesh

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh
            GenMeshKnot(float radius, float size, int radSeg, int sides); // Generate trefoil knot mesh

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh
            GenMeshHeightmap(Image heightmap, Vector3 size); // Generate heightmap mesh from image data

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh
            GenMeshCubicmap(Image cubicmap, Vector3 cubeSize); // Generate cubes-based map mesh from image data

        // Material loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Material LoadMaterial(string fileName); // Load material from file

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Material
            LoadMaterialDefault(); // Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMaterial(Material material); // Unload material from GPU memory (VRAM)

        // Model drawing functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawModel(Model model, Vector3 position, float scale, Color tint); // Draw a model (with texture if set)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle,
            Vector3 scale, Color tint); // Draw a model with extended parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawModelWires(Model model, Vector3 position, float scale,
                Color tint); // Draw a model wires (with texture if set)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis,
            float rotationAngle, Vector3 scale, Color tint); // Draw a model wires

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBoundingBox(BoundingBox box, Color color); // Draw bounding box (wires)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboard(Camera camera, Texture2D texture, Vector3 center, float size,
            Color tint); // Draw a billboard texture

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboardRec(Camera camera, Texture2D texture, Rectangle sourceRec,
            Vector3 center, float size, Color tint); // Draw a billboard texture defined by sourceRec

        // Collision detection functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionSpheres(Vector3 centerA, float radiusA, Vector3 centerB,
                float radiusB); // Detect collision between two spheres

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionBoxes(Vector3 minBBox1, Vector3 maxBBox1, Vector3 minBBox2,
            Vector3 maxBBox2); // Detect collision between two boxes

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionBoxSphere(Vector3 minBBox, Vector3 maxBBox, Vector3 centerSphere,
            float radiusSphere); // Detect collision between box and sphere

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionRaySphere(Ray ray, Vector3 spherePosition,
                float sphereRadius); // Detect collision between ray and sphere

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRaySphereEx(Ray ray, Vector3 spherePosition, float sphereRadius,
            ref Vector3 collisionPoint); // Detect collision between ray and sphere ex.

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            CheckCollisionRayBox(Ray ray, Vector3 minBBox, Vector3 maxBBox); // Detect collision between ray and box

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern BoundingBox CalculateBoundingBox(Mesh mesh); // Calculate mesh bounding box limits

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo
            GetCollisionRayMesh(Ray ray, ref Mesh mesh); // Get collision info between ray and mesh

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo
            GetCollisionRayTriangle(Ray ray, Vector3 p1, Vector3 p2,
                Vector3 p3); // Get collision info between ray and triangle

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo
            GetCollisionRayGround(Ray ray,
                float groundHeight); // Get collision info between ray and ground plane (Y-normal plane)

        // module: shaders (rlgl)

        // Shader loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string LoadText(string fileName); // Load chars array from text file

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader
            LoadShader(string vsFileName, string fsFileName); // Load a custom shader and bind default locations

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadShader(Shader shader); // Unload a custom shader from memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader GetDefaultShader(); // Get default shader

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GetDefaultTexture(); // Get default texture

        // Shader access functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetShaderLocation(Shader shader, string uniformName); // Get shader uniform location

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetShaderValue(Shader shader, int uniformLoc, float[] value, int size); // Set shader uniform value (float)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetShaderValuei(Shader shader, int uniformLoc, int[] value, int size); // Set shader uniform value (int)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetShaderValueMatrix(Shader shader, int uniformLoc, Matrix mat); // Set shader uniform value (matrix 4x4)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetMatrixProjection(Matrix proj); // Set a custom projection matrix (replaces internal projection matrix)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetMatrixModelview(Matrix view); // Set a custom modelview matrix (replaces internal modelview matrix)

        // Shading beegin/end functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginShaderMode(Shader shader); // Begin custom shader drawing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndShaderMode(); // End custom shader drawing (use default shader)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginBlendMode(int mode); // Begin blending mode (alpha, additive, multiplied)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndBlendMode(); // End blending mode (reset to default: alpha blending)

        // VR control functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern VrDeviceInfo
            GetVrDeviceInfo(int vrDeviceType); // Get VR device information for some standard devices

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            InitVrSimulator(VrDeviceInfo info); // Init VR simulator for selected device parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseVrSimulator(); // Close VR simulator for current device

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsVrSimulatorReady(); // Detect if VR simulator is ready

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            UpdateVrTracking(ref Camera camera); // Update VR tracking (position and orientation) and camera

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ToggleVrMode(); // Enable/Disable VR experience

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginVrDrawing(); // Begin VR simulator stereo rendering

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndVrDrawing(); // End VR simulator stereo rendering

        //module: audio

        // Audio device management functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitAudioDevice(); // Initialize audio device and context

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioDevice(); // Close the audio device and context (and music stream)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsAudioDeviceReady(); // Check if audio device is ready

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMasterVolume(float volume); // Set master volume (listener)

        // Wave/Sound loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWave(string fileName); // Load wave data from file into RAM

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWaveEx(float[] data, int sampleCount, int sampleRate, int sampleSize,
            int channels); // Load wave data from float array data (32bit)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSound(string fileName); // Load sound to memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSoundFromWave(Wave wave); // Load sound to memory from wave data

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            UpdateSound(Sound sound, IntPtr data, int numSamples); // Update sound buffer with new data

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadWave(Wave wave); // Unload wave data

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadSound(Sound sound); // Unload sound

        // Wave/Sound management functions

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlaySound(Sound sound); // Play a sound

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseSound(Sound sound); // Pause a sound

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeSound(Sound sound); // Resume a paused sound

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopSound(Sound sound); // Stop playing a sound

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsSoundPlaying(Sound sound); // Check if a sound is currently playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            SetSoundVolume(Sound sound, float volume); // Set volume for a sound (1.0 is max level)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundPitch(Sound sound, float pitch); // Set pitch for a sound (1.0 is base level)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            WaveFormat(ref Wave wave, int sampleRate, int sampleSize,
                int channels); // Convert wave data to desired format

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave WaveCopy(Wave wave); // Copy a wave to a new wave

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            WaveCrop(ref Wave wave, int initSample, int finalSample); // Crop a wave to defined samples range

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float[] GetWaveData(Wave wave); // Get samples data from wave as a floats array

        // Music management functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Music LoadMusicStream(string fileName); // Load music stream from file

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMusicStream(Music music); // Unload music stream

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayMusicStream(Music music); // Start music playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMusicStream(Music music); // Updates buffers for music streaming

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopMusicStream(Music music); // Stop music playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseMusicStream(Music music); // Pause music playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeMusicStream(Music music); // Resume playing paused music

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMusicPlaying(Music music); // Check if music is playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicVolume(Music music, float volume); // Set volume for music (1.0 is max level)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicPitch(Music music, float pitch); // Set pitch for a music (1.0 is base level)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicLoopCount(Music music, float count); // Set music loop count (loop repeats)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimeLength(Music music); // Get music time length (in seconds)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimePlayed(Music music); // Get current music time played (in seconds)

        // AudioStream management functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern AudioStream
            InitAudioStream(uint sampleRate, uint sampleSize,
                uint channels); // Init audio stream (to stream raw audio pcm data)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            UpdateAudioStream(AudioStream stream, IntPtr data, int numSamples); // Update audio stream buffers with data

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioStream(AudioStream stream); // Close audio stream and free memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            IsAudioBufferProcessed(AudioStream stream); // Check if any audio stream buffers requires refill

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayAudioStream(AudioStream stream); // Play audio stream

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseAudioStream(AudioStream stream); // Pause audio stream

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeAudioStream(AudioStream stream); // Resume audio stream

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopAudioStream(AudioStream stream); // Stop audio stream

        #endregion

        #region Raylib# Constants

        // raylib Config Flags
        /*#define FLAG_SHOW_LOGO              1       // Set to show raylib logo at startup
        #define FLAG_FULLSCREEN_MODE        2       // Set to run program in fullscreen
        #define FLAG_WINDOW_RESIZABLE       4       // Set to allow resizable window
        #define FLAG_WINDOW_UNDECORATED     8       // Set to disable window decoration (frame and buttons)
        #define FLAG_WINDOW_TRANSPARENT    16       // Set to allow transparent window
        #define FLAG_MSAA_4X_HINT          32       // Set to try enabling MSAA 4X
        #define FLAG_VSYNC_HINT            64       // Set to try enabling V-Sync on GPU
        */

        // Touch points registered
        /*#define MAX_TOUCH_POINTS      2

        // Gamepad Number
        #define GAMEPAD_PLAYER1       0
        #define GAMEPAD_PLAYER2       1
        #define GAMEPAD_PLAYER3       2
        #define GAMEPAD_PLAYER4       3
        
        // Gamepad Buttons/Axis

        // PS3 USB Controller Buttons
        #define GAMEPAD_PS3_BUTTON_TRIANGLE 0
        #define GAMEPAD_PS3_BUTTON_CIRCLE   1
        #define GAMEPAD_PS3_BUTTON_CROSS    2
        #define GAMEPAD_PS3_BUTTON_SQUARE   3
        #define GAMEPAD_PS3_BUTTON_L1       6
        #define GAMEPAD_PS3_BUTTON_R1       7
        #define GAMEPAD_PS3_BUTTON_L2       4
        #define GAMEPAD_PS3_BUTTON_R2       5
        #define GAMEPAD_PS3_BUTTON_START    8
        #define GAMEPAD_PS3_BUTTON_SELECT   9
        #define GAMEPAD_PS3_BUTTON_UP      24
        #define GAMEPAD_PS3_BUTTON_RIGHT   25
        #define GAMEPAD_PS3_BUTTON_DOWN    26
        #define GAMEPAD_PS3_BUTTON_LEFT    27
        #define GAMEPAD_PS3_BUTTON_PS      12

        // PS3 USB Controller Axis
        #define GAMEPAD_PS3_AXIS_LEFT_X     0
        #define GAMEPAD_PS3_AXIS_LEFT_Y     1
        #define GAMEPAD_PS3_AXIS_RIGHT_X    2
        #define GAMEPAD_PS3_AXIS_RIGHT_Y    5
        #define GAMEPAD_PS3_AXIS_L2         3       // [1..-1] (pressure-level)
        #define GAMEPAD_PS3_AXIS_R2         4       // [1..-1] (pressure-level)

        // Xbox360 USB Controller Buttons
        #define GAMEPAD_XBOX_BUTTON_A       0
        #define GAMEPAD_XBOX_BUTTON_B       1
        #define GAMEPAD_XBOX_BUTTON_X       2
        #define GAMEPAD_XBOX_BUTTON_Y       3
        #define GAMEPAD_XBOX_BUTTON_LB      4
        #define GAMEPAD_XBOX_BUTTON_RB      5
        #define GAMEPAD_XBOX_BUTTON_SELECT  6
        #define GAMEPAD_XBOX_BUTTON_START   7
        #define GAMEPAD_XBOX_BUTTON_UP      10
        #define GAMEPAD_XBOX_BUTTON_RIGHT   11
        #define GAMEPAD_XBOX_BUTTON_DOWN    12
        #define GAMEPAD_XBOX_BUTTON_LEFT    13
        #define GAMEPAD_XBOX_BUTTON_HOME    8

        // Android Gamepad Controller (SNES CLASSIC)
        #define GAMEPAD_ANDROID_DPAD_UP        19
        #define GAMEPAD_ANDROID_DPAD_DOWN      20
        #define GAMEPAD_ANDROID_DPAD_LEFT      21
        #define GAMEPAD_ANDROID_DPAD_RIGHT     22
        #define GAMEPAD_ANDROID_DPAD_CENTER    23

        #define GAMEPAD_ANDROID_BUTTON_A       96
        #define GAMEPAD_ANDROID_BUTTON_B       97
        #define GAMEPAD_ANDROID_BUTTON_C       98
        #define GAMEPAD_ANDROID_BUTTON_X       99
        #define GAMEPAD_ANDROID_BUTTON_Y       100
        #define GAMEPAD_ANDROID_BUTTON_Z       101
        #define GAMEPAD_ANDROID_BUTTON_L1      102
        #define GAMEPAD_ANDROID_BUTTON_R1      103
        #define GAMEPAD_ANDROID_BUTTON_L2      104
        #define GAMEPAD_ANDROID_BUTTON_R2      105

        // Xbox360 USB Controller Axis
        // NOTE: For Raspberry Pi, axis must be reconfigured
        #if defined(PLATFORM_RPI)
            #define GAMEPAD_XBOX_AXIS_LEFT_X    0   // [-1..1] (left->right)
            #define GAMEPAD_XBOX_AXIS_LEFT_Y    1   // [-1..1] (up->down)
            #define GAMEPAD_XBOX_AXIS_RIGHT_X   3   // [-1..1] (left->right)
            #define GAMEPAD_XBOX_AXIS_RIGHT_Y   4   // [-1..1] (up->down)
            #define GAMEPAD_XBOX_AXIS_LT        2   // [-1..1] (pressure-level)
            #define GAMEPAD_XBOX_AXIS_RT        5   // [-1..1] (pressure-level)
        #else
            #define GAMEPAD_XBOX_AXIS_LEFT_X    0   // [-1..1] (left->right)
            #define GAMEPAD_XBOX_AXIS_LEFT_Y    1   // [1..-1] (up->down)
            #define GAMEPAD_XBOX_AXIS_RIGHT_X   2   // [-1..1] (left->right)
            #define GAMEPAD_XBOX_AXIS_RIGHT_Y   3   // [1..-1] (up->down)
            #define GAMEPAD_XBOX_AXIS_LT        4   // [-1..1] (pressure-level)
            #define GAMEPAD_XBOX_AXIS_RT        5   // [-1..1] (pressure-level)
        #endif*/
            
        // colors

        // Custom raylib color palette for amazing visuals
        public static Color LIGHTGRAY = new Color(200, 200, 200, 255); // Light Gray
        public static Color GRAY = new Color(130, 130, 130, 255); // Gray
        public static Color DARKGRAY = new Color(80, 80, 80, 255); // Dark Gray
        public static Color YELLOW = new Color(253, 249, 0, 255); // Yellow
        public static Color GOLD = new Color(255, 203, 0, 255); // Gold
        public static Color ORANGE = new Color(255, 161, 0, 255); // Orange
        public static Color PINK = new Color(255, 109, 194, 255); // Pink
        public static Color RED = new Color(230, 41, 55, 255); // Red
        public static Color MAROON = new Color(190, 33, 55, 255); // Maroon
        public static Color GREEN = new Color(0, 228, 48, 255); // Green
        public static Color LIME = new Color(0, 158, 47, 255); // Lime
        public static Color DARKGREEN = new Color(0, 117, 44, 255); // Dark Green
        public static Color SKYBLUE = new Color(102, 191, 255, 255); // Sky Blue
        public static Color BLUE = new Color(0, 121, 241, 255); // Blue
        public static Color DARKBLUE = new Color(0, 82, 172, 255); // Dark Blue
        public static Color PURPLE = new Color(200, 122, 255, 255); // Purple
        public static Color VIOLET = new Color(135, 60, 190, 255); // Violet
        public static Color DARKPURPLE = new Color(112, 31, 126, 255); // Dark Purple
        public static Color BEIGE = new Color(211, 176, 131, 255); // Beige
        public static Color BROWN = new Color(127, 106, 79, 255); // Brown
        public static Color DARKBROWN = new Color(76, 63, 47, 255); // Dark Brown
        public static Color WHITE = new Color(255, 255, 255, 255); // White
        public static Color BLACK = new Color(0, 0, 0, 255); // Black
        public static Color BLANK = new Color(0, 0, 0, 0); // Transparent
        public static Color MAGENTA = new Color(255, 0, 255, 255); // Magenta
        public static Color RAYWHITE = new Color(245, 245, 245, 255); // Ray White
        
        #endregion
    }
}