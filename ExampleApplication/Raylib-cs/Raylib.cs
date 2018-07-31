using System;
using System.Runtime.InteropServices;

// quick reference
// http://www.raylib.com/cheatsheet/cheatsheet.html
namespace Raylib
{
    #region Raylib# Enums
 
    [Flags]
    public enum LogType
    {
        LOG_INFO = 1,
        LOG_WARNING = 2,
        LOG_ERROR = 4,
        LOG_DEBUG = 8,
        LOG_OTHER = 16
    }

    public enum ShaderLocationIndex
    {
        LOC_VERTEX_POSITION = 0,
        LOC_VERTEX_TEXCOORD01 = 1,
        LOC_VERTEX_TEXCOORD02 = 2,
        LOC_VERTEX_NORMAL = 3,
        LOC_VERTEX_TANGENT = 4,
        LOC_VERTEX_COLOR = 5,
        LOC_MATRIX_MVP = 6,
        LOC_MATRIX_MODEL = 7,
        LOC_MATRIX_VIEW = 8,
        LOC_MATRIX_PROJECTION = 9,
        LOC_VECTOR_VIEW = 10,
        LOC_COLOR_DIFFUSE = 11,
        LOC_COLOR_SPECULAR = 12,
        LOC_COLOR_AMBIENT = 13,
        LOC_MAP_ALBEDO = 14,
        LOC_MAP_METALNESS = 15,
        LOC_MAP_NORMAL = 16,
        LOC_MAP_ROUGHNESS = 17,
        LOC_MAP_OCCLUSION = 18,
        LOC_MAP_EMISSION = 19,
        LOC_MAP_HEIGHT = 20,
        LOC_MAP_CUBEMAP = 21,
        LOC_MAP_IRRADIANCE = 22,
        LOC_MAP_PREFILTER = 23,
        LOC_MAP_BRDF = 24
    }

    public enum TexmapIndex
    {
        MAP_ALBEDO = 0,
        MAP_METALNESS = 1,
        MAP_NORMAL = 2,
        MAP_ROUGHNESS = 3,
        MAP_OCCLUSION = 4,
        MAP_EMISSION = 5,
        MAP_HEIGHT = 6,
        MAP_CUBEMAP = 7,
        MAP_IRRADIANCE = 8,
        MAP_PREFILTER = 9,
        MAP_BRDF = 10
    }

    public enum PixelFormat
    {
        UNCOMPRESSED_GRAYSCALE = 1,
        UNCOMPRESSED_GRAY_ALPHA = 2,
        UNCOMPRESSED_R5G6B5 = 3,
        UNCOMPRESSED_R8G8B8 = 4,
        UNCOMPRESSED_R5G5B5A1 = 5,
        UNCOMPRESSED_R4G4B4A4 = 6,
        UNCOMPRESSED_R8G8B8A8 = 7,
        UNCOMPRESSED_R32 = 8,
        UNCOMPRESSED_R32G32B32 = 9,
        UNCOMPRESSED_R32G32B32A32 = 10,
        COMPRESSED_DXT1RGB = 11,
        COMPRESSED_DXT1RGBA = 12,
        COMPRESSED_DXT3RGBA = 13,
        COMPRESSED_DXT5RGBA = 14,
        COMPRESSED_ETC1RGB = 15,
        COMPRESSED_ETC2RGB = 16,
        COMPRESSED_ETC2EAC_RGBA = 17,
        COMPRESSED_PVRT_RGB = 18,
        COMPRESSED_PVRT_RGBA = 19,
        COMPRESSED_ASTC_4x4RGBA = 20,
        COMPRESSED_ASTC_8x8RGBA = 21
    }

    public enum TextureFilterMode
    {
        FILTER_POINT = 0,
        FILTER_BILINEAR = 1,
        FILTER_TRILINEAR = 2,
        FILTER_ANISOTROPIC_4X = 3,
        FILTER_ANISOTROPIC_8X = 4,
        FILTER_ANISOTROPIC_16X = 5
    }

    public enum TextureWrapMode
    {
        WRAP_REPEAT = 0,
        WRAP_CLAMP = 1,
        WRAP_MIRROR = 2
    }

    public enum BlendMode
    {
        BLEND_ALPHA = 0,
        BLEND_ADDITIVE = 1,
        BLEND_MULTIPLIED = 2
    }

    [Flags]
    public enum Gestures
    {
        GESTURE_NONE = 0,
        GESTURE_TAP = 1,
        GESTURE_DOUBLETAP = 2,
        GESTURE_HOLD = 4,
        GESTURE_DRAG = 8,
        GESTURE_SWIPE_RIGHT = 16,
        GESTURE_SWIPE_LEFT = 32,
        GESTURE_SWIPE_UP = 64,
        GESTURE_SWIPE_DOWN = 128,
        GESTURE_PINCH_IN = 256,
        GESTURE_PINCH_OUT = 512
    }

    public enum CameraMode
    {
        CAMERA_CUSTOM = 0,
        CAMERA_FREE = 1,
        CAMERA_ORBITAL = 2,
        CAMERA_FIRST_PERSON = 3,
        CAMERA_THIRD_PERSON = 4
    }

    public enum CameraType
    {
        CAMERA_PERSPECTIVE = 0,
        CAMERA_ORTHOGRAPHIC = 1
    }

    public enum VrDeviceType
    {
        HMD_DEFAULT_DEVICE = 0,
        HMD_OCULUS_RIFT_DK2 = 1,
        HMD_OCULUS_RIFT_CV1 = 2,
        HMD_OCULUS_GO = 3,
        HMD_VALVE_HTC_VIVE = 4,
        HMD_SONY_PSVR = 5
    }

    [Flags]
    public enum Flag
    {
        SHOW_LOGO = 1,
        FULLSCREEN_MODE = 2,
        WINDOW_RESIZABLE = 4,
        WINDOW_UNDECORATED = 8,
        WINDOW_TRANSPARENT = 16,
        MSAA_4X_HINT = 32,
        VSYNC_HINT = 64
    }

    // Keyboard Function Keys
    public enum Keys
    {
        SPACE = 32,
        ESCAPE = 256,
        ENTER = 257,
        TAB = 258,
        BACKSPACE = 259,
        INSERT = 260,
        DELETE = 261,
        RIGHT = 262,
        LEFT = 263,
        DOWN = 264,
        UP = 265,
        PAGE_UP = 266,
        PAGE_DOWN = 267,
        HOME = 268,
        END = 269,
        CAPS_LOCK = 280,
        SCROLL_LOCK = 281,
        NUM_LOCK = 282,
        PRINT_SCREEN = 283,
        PAUSE = 284,
        F1 = 290,
        F2 = 291,
        F3 = 292,
        F4 = 293,
        F5 = 294,
        F6 = 295,
        F7 = 296,
        F8 = 297,
        F9 = 298,
        F10 = 299,
        F11 = 300,
        F12 = 301,
        LEFT_SHIFT = 340,
        LEFT_CONTROL = 341,
        LEFT_ALT = 342,
        RIGHT_SHIFT = 344,
        RIGHT_CONTROL = 345,
        RIGHT_ALT = 346,
        GRAVE = 96,
        SLASH = 47,
        BACKSLASH = 92,

        // Keyboard Alpha Numeric Keys
        ZERO = 48,
        ONE = 49,
        TWO = 50,
        THREE = 51,
        FOUR = 52,
        FIVE = 53,
        SIX = 54,
        SEVEN = 55,
        EIGHT = 56,
        NINE = 57,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,

        // Android Physical Buttons
        BACK = 4,
        MENU = 82,
        VOLUME_UP = 24,
        VOLUME_DOWN = 25
    }

    // Mouse Buttons
    public enum Mouse
    {
        LEFT_BUTTON = 0,
        RIGHT_BUTTON = 1,
        MIDDLE_BUTTON = 2
    }

    public enum Gamepad
    {
        PLAYER1 = 0,
        PLAYER2 = 1,
        PLAYER3 = 2,
        PLAYER4 = 3,
        PS3BUTTON_TRIANGLE = 0,
        PS3BUTTON_CIRCLE = 1,
        PS3BUTTON_CROSS = 2,
        PS3BUTTON_SQUARE = 3,
        PS3BUTTON_L1 = 6,
        PS3BUTTON_R1 = 7,
        PS3BUTTON_L2 = 4,
        PS3BUTTON_R2 = 5,
        PS3BUTTON_START = 8,
        PS3BUTTON_SELECT = 9,
        PS3BUTTON_UP = 24,
        PS3BUTTON_RIGHT = 25,
        PS3BUTTON_DOWN = 26,
        PS3BUTTON_LEFT = 27,
        PS3BUTTON_PS = 12,
        PS3AXIS_LEFT_X = 0,
        PS3AXIS_LEFT_Y = 1,
        PS3AXIS_RIGHT_X = 2,
        PS3AXIS_RIGHT_Y = 5,
        PS3AXIS_L2 = 3,
        PS3AXIS_R2 = 4,
        XBOX_BUTTON_A = 0,
        XBOX_BUTTON_B = 1,
        XBOX_BUTTON_X = 2,
        XBOX_BUTTON_Y = 3,
        XBOX_BUTTON_LB = 4,
        XBOX_BUTTON_RB = 5,
        XBOX_BUTTON_SELECT = 6,
        XBOX_BUTTON_START = 7,
        XBOX_BUTTON_UP = 10,
        XBOX_BUTTON_RIGHT = 11,
        XBOX_BUTTON_DOWN = 12,
        XBOX_BUTTON_LEFT = 13,
        XBOX_BUTTON_HOME = 8,
        ANDROID_DPAD_UP = 19,
        ANDROID_DPAD_DOWN = 20,
        ANDROID_DPAD_LEFT = 21,
        ANDROID_DPAD_RIGHT = 22,
        ANDROID_DPAD_CENTER = 23,
        ANDROID_BUTTON_A = 96,
        ANDROID_BUTTON_B = 97,
        ANDROID_BUTTON_C = 98,
        ANDROID_BUTTON_X = 99,
        ANDROID_BUTTON_Y = 100,
        ANDROID_BUTTON_Z = 101,
        ANDROID_BUTTON_L1 = 102,
        ANDROID_BUTTON_R1 = 103,
        ANDROID_BUTTON_L2 = 104,
        ANDROID_BUTTON_R2 = 105,
        XBOX_AXIS_LEFT_X = 0,
        XBOX_AXIS_LEFT_Y = 1,
        XBOX_AXIS_RIGHT_X = 2,
        XBOX_AXIS_RIGHT_Y = 3,
        XBOX_AXIS_LT = 4,
        XBOX_AXIS_RT = 5
    }

    #endregion

    #region Raylib# Types
   
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

    // public static Color Font Font     // Font type fallback, defaults to Font

    // Camera type, defines a camera position/orientation in 3d space
    public struct Camera
    {
        public Vector3 position; // Camera position
        public Vector3 target; // Camera target it looks-at
        public Vector3 up; // Camera up vector (rotation over its axis)

        public float fovy; // Camera field-of-view apperture in Y (degrees) in perspective, used as near plane width in orthographic

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
    public unsafe struct Shader
    {
        public uint id; // Shader program id
        public fixed int locs[rl.MAX_SHADER_LOCATIONS]; // Shader locations array
    }

    // Material texture map
    public struct MaterialMap
    {
        public Texture2D texture; // Material map texture
        public Color color; // Material map color
        public float value; // Material map value
    }

    // Material type (generic)
    public class Material
    {
        public Shader shader; // Material shader
        MaterialMap[] maps = new MaterialMap[rl.MAX_MATERIAL_MAPS]; // Material maps
        float[] param;          // Material generic parameters (if required)
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
    //public struct MusicData
    //{
    //}

    // Audio stream type
    // NOTE: Useful to create custom audio streams not bound to a specific file
    public class AudioStream
    {
        public uint sampleRate; // Frequency (samples per second)
        public uint sampleSize; // Bit depth (bits per sample): 8, 16, 32 (24 not supported)
        public uint channels; // Number of channels (1-mono, 2-stereo)
        public IntPtr audioBuffer; // Pointer to internal data used by the audio system.
        public int format; // Audio format specifier

        public uint source; // Audio source id
        public uint[] buffers = new uint[2];    // Audio buffers (double buffering)
    }

    // Head-Mounted-Display device parameters
    public class VrDeviceInfo
    {
        public int hResolution; // HMD horizontal resolution in pixels
        public int vResolution; // HMD vertical resolution in pixels
        public float hScreenSize; // HMD horizontal size in meters
        public float vScreenSize; // HMD vertical size in meters
        public float vScreenCenter; // HMD screen center in meters
        public float eyeToScreenDistance; // HMD distance between eye and display in meters
        public float lensSeparationDistance; // HMD lens separation distance in meters

        public float interpupillaryDistance; // HMD IPD (distance between pupils) in meters
        public float[] lensDistortionValues = new float[4];  // HMD lens distortion constant parameters
        public float[] chromaAbCorrection = new float[4];    // HMD chromatic aberration correction parameters
    }
    
    #endregion
    
    public static partial class rl
    {
        /// <summary>
        /// Copy raylib dll to output folder automatically
        /// Needed to run bindings
        /// </summary>
        /*public static void LoadApp()
        {
            var libFolder = (Environment.Is64BitProcess ? "x64" : "x86");
            var dllPath = AppDomain.CurrentDomain.BaseDirectory + "../../../raylib-cs\\" + libFolder + "\\raylib.dll";
            var binPath = AppDomain.CurrentDomain.BaseDirectory + "raylib.dll";
            if (File.Exists(dllPath))  
                File.Copy(dllPath, binPath, true);
        }*/

        #region Raylib# Variables

        /* Used by DllImport to load the native library. */
        private const string nativeLibName = "raylib.dll";
        public const int MAX_SHADER_LOCATIONS = 32;
        public const int MAX_MATERIAL_MAPS = 12;

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

        #region Raylib.h

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
            ImageTextEx(Font font, string text, int fontSize, int spacing,
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
        public static extern void ImageDrawTextEx(ref Image dst, Vector2 position, Font font, string text,
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

        // Font loading/unloading functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font GetDefaultFont(); // Get the default Font

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFont(string fileName); // Load a Font image into GPU memory

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font
            LoadFontEx(string fileName, int fontSize, int numChars,
                int fontChars); // Load a Font from TTF font with parameters

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFont(Font spriteFont); // Unload Font from GPU memory

        // Text drawing functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawFPS(int posX, int posY); // Shows current FPS on top-left corner

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void
            DrawText(string text, int posX, int posY, int fontSize, Color color); // Draw text (using default font)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextEx(Font spriteFont, string text, Vector2 position, int fontSize,
            int spacing, Color tint); // Draw text using Font and additional parameters

        // Text misc. functions
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MeasureText(string text, int fontSize); // Measure string width for default font

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2
            MeasureTextEx(Font spriteFont, string text, int fontSize,
                int spacing); // Measure string size for Font

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
        public static extern IntPtr LoadMusicStream(string fileName); // Load music stream from file

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMusicStream(IntPtr music); // Unload music stream

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayMusicStream(IntPtr music); // Start music playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMusicStream(IntPtr music); // Updates buffers for music streaming

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopMusicStream(IntPtr music); // Stop music playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseMusicStream(IntPtr music); // Pause music playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeMusicStream(IntPtr music); // Resume playing paused music

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMusicPlaying(IntPtr music); // Check if music is playing

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicVolume(IntPtr music, float volume); // Set volume for music (1.0 is max level)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicPitch(IntPtr music, float pitch); // Set pitch for a music (1.0 is base level)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicLoopCount(IntPtr music, float count); // Set music loop count (loop repeats)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimeLength(IntPtr music); // Get music time length (in seconds)

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimePlayed(IntPtr music); // Get current music time played (in seconds)

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
    }
}