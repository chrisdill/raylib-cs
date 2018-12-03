// Raylib - https://github.com/raysan5/raylib/blob/master/src/raylib.h

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib
{
    #region Raylib-cs Enums

    //----------------------------------------------------------------------------------
    // Enumerators Definition
    //----------------------------------------------------------------------------------

    // System config flags
    // NOTE: Used for bit masks
    public enum ConfigFlag
    {
        FLAG_SHOW_LOGO = 1,           // Set to show raylib logo at startup
        FLAG_FULLSCREEN_MODE = 2,     // Set to run program in fullscreen
        FLAG_WINDOW_RESIZABLE = 4,    // Set to allow resizable window
        FLAG_WINDOW_UNDECORATED = 8,  // Set to disable window decoration (frame and buttons)
        FLAG_WINDOW_TRANSPARENT = 16, // Set to allow transparent window
        FLAG_MSAA_4X_HINT = 32,       // Set to try enabling MSAA 4X
        FLAG_VSYNC_HINT = 64          // Set to try enabling V-Sync on GPU
    }

    // Trace log type
    // NOTE: Used for bit masks
    public enum TraceLogType
    {
        LOG_INFO = 1,
        LOG_WARNING = 2,
        LOG_ERROR = 4,
        LOG_DEBUG = 8,
        LOG_OTHER = 16
    }

    // Keyboard keys
    // enum extension for constants
    // Keyboard Function Keys
    public enum KeyboardKey
    {
        // Alphanumeric keys
        KEY_APOSTROPHE = 39,
        KEY_COMMA = 44,
        KEY_MINUS = 45,
        KEY_PERIOD = 46,
        KEY_SLASH = 47,
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
        KEY_SEMICOLON = 59,
        KEY_EQUAL = 61,
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

        // Function keys
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
        KEY_LEFT_SUPER = 343,
        KEY_RIGHT_SHIFT = 344,
        KEY_RIGHT_CONTROL = 345,
        KEY_RIGHT_ALT = 346,
        KEY_RIGHT_SUPER = 347,
        KEY_KB_MENU = 348,
        KEY_LEFT_BRACKET = 91,
        KEY_BACKSLASH = 92,
        KEY_RIGHT_BRACKET = 93,
        KEY_GRAVE = 96,

        // Keypad keys
        KEY_KP_0 = 320,
        KEY_KP_1 = 321,
        KEY_KP_2 = 322,
        KEY_KP_3 = 323,
        KEY_KP_4 = 324,
        KEY_KP_5 = 325,
        KEY_KP_6 = 326,
        KEY_KP_7 = 327,
        KEY_KP_8 = 328,
        KEY_KP_9 = 329,
        KEY_KP_DECIMAL = 330,
        KEY_KP_DIVIDE = 331,
        KEY_KP_MULTIPLY = 332,
        KEY_KP_SUBTRACT = 333,
        KEY_KP_ADD = 334,
        KEY_KP_ENTER = 335,
        KEY_KP_EQUAL = 336
    }

    // Android buttons
    public enum AndroidButton
    {
        KEY_BACK = 4,
        KEY_MENU = 82,
        KEY_VOLUME_UP = 24,
        KEY_VOLUME_DOWN = 25
    }

    // Mouse Buttons
    public enum MouseButton
    {
        MOUSE_LEFT_BUTTON = 0,
        MOUSE_RIGHT_BUTTON = 1,
        MOUSE_MIDDLE_BUTTON = 2
    }

    // Gamepad number
    public enum GamepadNumber
    {
        GAMEPAD_PLAYER1 = 0,
        GAMEPAD_PLAYER2 = 1,
        GAMEPAD_PLAYER3 = 2,
        GAMEPAD_PLAYER4 = 3
    }

    // PS3 USB Controller Buttons
    // TODO: Provide a generic way to list gamepad controls schemes,
    // defining specific controls schemes is not a good option
    public enum GamepadPS3Button
    {
        GAMEPAD_PS3_BUTTON_TRIANGLE = 0,
        GAMEPAD_PS3_BUTTON_CIRCLE = 1,
        GAMEPAD_PS3_BUTTON_CROSS = 2,
        GAMEPAD_PS3_BUTTON_SQUARE = 3,
        GAMEPAD_PS3_BUTTON_L1 = 6,
        GAMEPAD_PS3_BUTTON_R1 = 7,
        GAMEPAD_PS3_BUTTON_L2 = 4,
        GAMEPAD_PS3_BUTTON_R2 = 5,
        GAMEPAD_PS3_BUTTON_START = 8,
        GAMEPAD_PS3_BUTTON_SELECT = 9,
        GAMEPAD_PS3_BUTTON_PS = 12,
        GAMEPAD_PS3_BUTTON_UP = 24,
        GAMEPAD_PS3_BUTTON_RIGHT = 25,
        GAMEPAD_PS3_BUTTON_DOWN = 26,
        GAMEPAD_PS3_BUTTON_LEFT = 27
    }

    // PS3 USB Controller Axis
    public enum GamepadPS3Axis
    {
        GAMEPAD_PS3_AXIS_LEFT_X = 0,
        GAMEPAD_PS3_AXIS_LEFT_Y = 1,
        GAMEPAD_PS3_AXIS_RIGHT_X = 2,
        GAMEPAD_PS3_AXIS_RIGHT_Y = 5,
        GAMEPAD_PS3_AXIS_L2 = 3,    // [1..-1] (pressure-level)
        GAMEPAD_PS3_AXIS_R2 = 4     // [1..-1] (pressure-level)
    }

    // Xbox360 USB Controller Buttons
    public enum GamepadXbox360Button
    {
        GAMEPAD_XBOX_BUTTON_A = 0,
        GAMEPAD_XBOX_BUTTON_B = 1,
        GAMEPAD_XBOX_BUTTON_X = 2,
        GAMEPAD_XBOX_BUTTON_Y = 3,
        GAMEPAD_XBOX_BUTTON_LB = 4,
        GAMEPAD_XBOX_BUTTON_RB = 5,
        GAMEPAD_XBOX_BUTTON_SELECT = 6,
        GAMEPAD_XBOX_BUTTON_START = 7,
        GAMEPAD_XBOX_BUTTON_HOME = 8,
        GAMEPAD_XBOX_BUTTON_UP = 10,
        GAMEPAD_XBOX_BUTTON_RIGHT = 11,
        GAMEPAD_XBOX_BUTTON_DOWN = 12,
        GAMEPAD_XBOX_BUTTON_LEFT = 13
    }

    // Xbox360 USB Controller Axis,
    // NOTE: For Raspberry Pi, axis must be reconfigured
    public enum GamepadXbox360Axis
    {
        GAMEPAD_XBOX_AXIS_LEFT_X = 0,    // [-1..1] (left->right)
        GAMEPAD_XBOX_AXIS_LEFT_Y = 1,    // [1..-1] (up->down)
        GAMEPAD_XBOX_AXIS_RIGHT_X = 2,   // [-1..1] (left->right)
        GAMEPAD_XBOX_AXIS_RIGHT_Y = 3,   // [1..-1] (up->down)
        GAMEPAD_XBOX_AXIS_LT = 4,        // [-1..1] (pressure-level)
        GAMEPAD_XBOX_AXIS_RT = 5         // [-1..1] (pressure-level)
    }

    // Android Gamepad Controller (SNES CLASSIC)
    public enum GamepadAndroid
    {
        GAMEPAD_ANDROID_DPAD_UP = 19,
        GAMEPAD_ANDROID_DPAD_DOWN = 20,
        GAMEPAD_ANDROID_DPAD_LEFT = 21,
        GAMEPAD_ANDROID_DPAD_RIGHT = 22,
        GAMEPAD_ANDROID_DPAD_CENTER = 23,
        GAMEPAD_ANDROID_BUTTON_A = 96,
        GAMEPAD_ANDROID_BUTTON_B = 97,
        GAMEPAD_ANDROID_BUTTON_C = 98,
        GAMEPAD_ANDROID_BUTTON_X = 99,
        GAMEPAD_ANDROID_BUTTON_Y = 100,
        GAMEPAD_ANDROID_BUTTON_Z = 101,
        GAMEPAD_ANDROID_BUTTON_L1 = 102,
        GAMEPAD_ANDROID_BUTTON_R1 = 103,
        GAMEPAD_ANDROID_BUTTON_L2 = 104,
        GAMEPAD_ANDROID_BUTTON_R2 = 105
    }

    // Shader location point type
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

    // Material map type
    public enum TexmapIndex
    {
        MAP_ALBEDO = 0,          // MAP_DIFFUSE
        MAP_METALNESS = 1,       // MAP_SPECULAR
        MAP_NORMAL = 2,
        MAP_ROUGHNESS = 3,
        MAP_OCCLUSION,
        MAP_EMISSION,
        MAP_HEIGHT,
        MAP_CUBEMAP,             // NOTE: Uses GL_TEXTURE_CUBE_MAP
        MAP_IRRADIANCE,          // NOTE: Uses GL_TEXTURE_CUBE_MAP
        MAP_PREFILTER,           // NOTE: Uses GL_TEXTURE_CUBE_MAP
        MAP_BRDF
    }

    // Pixel formats
    // NOTE: Support depends on OpenGL version and platform
    public enum PixelFormat
    {
        UNCOMPRESSED_GRAYSCALE = 1,     // 8 bit per pixel (no alpha)
        UNCOMPRESSED_GRAY_ALPHA,        // 8*2 bpp (2 channels)
        UNCOMPRESSED_R5G6B5,            // 16 bpp
        UNCOMPRESSED_R8G8B8,            // 24 bpp
        UNCOMPRESSED_R5G5B5A1,          // 16 bpp (1 bit alpha)
        UNCOMPRESSED_R4G4B4A4,          // 16 bpp (4 bit alpha)
        UNCOMPRESSED_R8G8B8A8,          // 32 bpp
        UNCOMPRESSED_R32,               // 32 bpp (1 channel - float)
        UNCOMPRESSED_R32G32B32,         // 32*3 bpp (3 channels - float)
        UNCOMPRESSED_R32G32B32A32,      // 32*4 bpp (4 channels - float)
        COMPRESSED_DXT1_RGB,            // 4 bpp (no alpha)
        COMPRESSED_DXT1_RGBA,           // 4 bpp (1 bit alpha)
        COMPRESSED_DXT3_RGBA,           // 8 bpp
        COMPRESSED_DXT5_RGBA,           // 8 bpp
        COMPRESSED_ETC1_RGB,            // 4 bpp
        COMPRESSED_ETC2_RGB,            // 4 bpp
        COMPRESSED_ETC2_EAC_RGBA,       // 8 bpp
        COMPRESSED_PVRT_RGB,            // 4 bpp
        COMPRESSED_PVRT_RGBA,           // 4 bpp
        COMPRESSED_ASTC_4x4_RGBA,       // 8 bpp
        COMPRESSED_ASTC_8x8_RGBA        // 2 bpp
    }

    // Texture parameters: filter mode
    // NOTE 1: Filtering considers mipmaps if available in the texture
    // NOTE 2: Filter is accordingly set for minification and magnification
    public enum TextureFilterMode
    {
        FILTER_POINT = 0,               // No filter, just pixel aproximation
        FILTER_BILINEAR,                // Linear filtering
        FILTER_TRILINEAR,               // Trilinear filtering (linear with mipmaps)
        FILTER_ANISOTROPIC_4X,          // Anisotropic filtering 4x
        FILTER_ANISOTROPIC_8X,          // Anisotropic filtering 8x
        FILTER_ANISOTROPIC_16X,         // Anisotropic filtering 16x
    }

    // Texture parameters: wrap mode
    public enum TextureWrapMode
    {
        WRAP_REPEAT = 0,        // Repeats texture in tiled mode
        WRAP_CLAMP,             // Clamps texture to edge pixel in tiled mode
        WRAP_MIRROR_REPEAT,     // Mirrors and repeats the texture in tiled mode
        WRAP_MIRROR_CLAMP       // Mirrors and clamps to border the texture in tiled mode
    }

    // Font type, defines generation method
    public enum FontType
    {
        FONT_DEFAULT = 0,       // Default font generation, anti-aliased
        FONT_BITMAP,            // Bitmap font generation, no anti-aliasing
        FONT_SDF                // SDF font generation, requires external shader
    }

    // Color blending modes (pre-defined)
    public enum BlendMode
    {
        BLEND_ALPHA = 0,        // Blend textures considering alpha (default)
        BLEND_ADDITIVE,         // Blend textures adding colors
        BLEND_MULTIPLIED        // Blend textures multiplying colors
    }

    // Gestures type
    // NOTE: It could be used as flags to enable only some gestures
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

    // Camera system modes
    public enum CameraMode
    {
        CAMERA_CUSTOM = 0,
        CAMERA_FREE,
        CAMERA_ORBITAL,
        CAMERA_FIRST_PERSON,
        CAMERA_THIRD_PERSON
    }

    // Camera projection modes
    public enum CameraType
    {
        CAMERA_PERSPECTIVE = 0,
        CAMERA_ORTHOGRAPHIC
    }

    // Head Mounted Display devices
    public enum VrDeviceType
    {
        HMD_DEFAULT_DEVICE = 0,
        HMD_OCULUS_RIFT_DK2,
        HMD_OCULUS_RIFT_CV1,
        HMD_OCULUS_GO,
        HMD_VALVE_HTC_VIVE,
        HMD_SONY_PSVR
    }

    // Type of n-patch
    public enum NPatchType
    {
        NPT_9PATCH = 0,         // Npatch defined by 3x3 tiles
        NPT_3PATCH_VERTICAL,    // Npatch defined by 1x3 tiles
        NPT_3PATCH_HORIZONTAL   // Npatch defined by 3x1 tiles
    }

    #endregion

    #region Raylib-cs Types

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

        public Color(int r, int g, int b, int a)
        {
            this.r = Convert.ToByte(r);
            this.g = Convert.ToByte(g);
            this.b = Convert.ToByte(b);
            this.a = Convert.ToByte(a);
        }

        // extension to access colours from struct
        // Custom raylib color palette for amazing visuals
        public static Color LIGHTGRAY = new Color(200, 200, 200, 255);
        public static Color GRAY = new Color(130, 130, 130, 255);
        public static Color DARKGRAY = new Color(80, 80, 80, 255);
        public static Color YELLOW = new Color(253, 249, 0, 255);
        public static Color GOLD = new Color(255, 203, 0, 255);
        public static Color ORANGE = new Color(255, 161, 0, 255);
        public static Color PINK = new Color(255, 109, 194, 255);
        public static Color RED = new Color(230, 41, 55, 255);
        public static Color MAROON = new Color(190, 33, 55, 255);
        public static Color GREEN = new Color(0, 228, 48, 255);
        public static Color LIME = new Color(0, 158, 47, 255);
        public static Color DARKGREEN = new Color(0, 117, 44, 255);
        public static Color SKYBLUE = new Color(102, 191, 255, 255);
        public static Color BLUE = new Color(0, 121, 241, 255);
        public static Color DARKBLUE = new Color(0, 82, 172, 255);
        public static Color PURPLE = new Color(200, 122, 255, 255);
        public static Color VIOLET = new Color(135, 60, 190, 255);
        public static Color DARKPURPLE = new Color(112, 31, 126, 255);
        public static Color BEIGE = new Color(211, 176, 131, 255);
        public static Color BROWN = new Color(127, 106, 79, 255);
        public static Color DARKBROWN = new Color(76, 63, 47, 255);
        public static Color WHITE = new Color(255, 255, 255, 255);
        public static Color BLACK = new Color(0, 0, 0, 255);
        public static Color BLANK = new Color(0, 0, 0, 0);
        public static Color MAGENTA = new Color(255, 0, 255, 255);
        public static Color RAYWHITE = new Color(245, 245, 245, 255);
    }

    // Rectangle type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
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
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Image
    {
        public IntPtr data;
        public int width;
        public int height;
        public int mipmaps;
        public int format;
    }

    // Texture2D type
    // NOTE: Data stored in GPU memory
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Texture2D
    {
        public uint id;
        public int width;
        public int height;
        public int mipmaps;
        public int format;
    }

    // RenderTexture2D type, for texture rendering
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RenderTexture2D
    {
        public uint id;
        public Texture2D texture;
        public Texture2D depth;
    }

    // Font character info
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CharInfo
    {
        public int value;
        public Rectangle rec;
        public int offsetX;
        public int offsetY;
        public int advanceX;
        public IntPtr data;
    }

    // Font type, includes texture and charSet array data
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Font
    {
        public Texture2D texture;
        public int baseSize;
        public int charsCount;
        public IntPtr chars;
    }

    // Camera type, defines a camera position/orientation in 3d space
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Camera3D
    {
        public Vector3 position;
        public Vector3 target;
        public Vector3 up;

        public float fovy;

        public CameraType type;

        public Camera3D(Vector3 position, Vector3 target, Vector3 up, float fovy = 90,
            CameraType type = CameraType.CAMERA_PERSPECTIVE)
        {
            this.position = position;
            this.target = target;
            this.up = up;
            this.fovy = fovy;
            this.type = type;
        }
    }

    // Camera2D type, defines a 2d camera
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Camera2D
    {
        public Vector2 offset;
        public Vector2 target;
        public float rotation;
        public float zoom;
    }

    // Bounding box type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct BoundingBox
    {
        public Vector3 min;
        public Vector3 max;

        public BoundingBox(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }
    }

    // Vertex data definning a mesh
    // NOTE: Data stored in CPU memory (and GPU)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct Mesh
    {
        public int vertexCount;
        public int triangleCount;

        // public Span<float> Vertices => new Span<float>(vertices.ToPointer(), vertexCount * 3);
        public IntPtr vertices;
        public IntPtr texcoords;
        public IntPtr texcoords2;
        public IntPtr normals;
        public IntPtr tangents;
        public IntPtr colors;
        public IntPtr indices;

        public IntPtr baseVertices;
        public IntPtr baseNormals;
        public IntPtr weightBias;
        public IntPtr weightId;

        public uint vaoId;
        public fixed uint vboId[7];
    }

    // Shader type (generic)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct Shader
    {
        public uint id;
        public fixed int locs[Raylib.MAX_SHADER_LOCATIONS];
    }

    // Material texture map
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MaterialMap
    {
        public Texture2D texture;
        public Color color;
        public float value;
    }

    public unsafe struct _MaterialMap_e_FixedBuffer
    {
        public MaterialMap maps0;
        public MaterialMap maps1;
        public MaterialMap maps2;
        public MaterialMap maps3;
        public MaterialMap maps4;
        public MaterialMap maps5;
        public MaterialMap maps6;
        public MaterialMap maps7;
        public MaterialMap maps8;
        public MaterialMap maps9;
        public MaterialMap maps10;
        public MaterialMap maps11;

        public ref MaterialMap this[int index]
        {
            get
            {
                fixed (MaterialMap* e = &maps0)
                    return ref e[index];
            }
        }
    }

    // Material type (generic)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Material
    {
        public Shader shader;
        public _MaterialMap_e_FixedBuffer maps;
        public IntPtr param;
    }

    // Model type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Model
    {
        public Mesh mesh;
        public Matrix transform;
        public Material material;
    }

    // Ray type (useful for raycast)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Ray
    {
        public Vector3 position;
        public Vector3 direction;

        public Ray(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }

    // Raycast hit information
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RayHitInfo
    {
        public byte bHit;
        public float distance;
        public Vector3 position;
        public Vector3 normal;

        // convert c bool(stored as byte) to bool
        public bool hit
        {
            get { return Convert.ToBoolean(bHit); }
            set { bHit = Convert.ToByte(hit); }
        }

        public RayHitInfo(bool hit, float distance, Vector3 position, Vector3 normal)
        {
            this.bHit = Convert.ToByte(hit);
            this.distance = distance;
            this.position = position;
            this.normal = normal;
        }
    }

    // Wave type, defines audio wave data
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Wave
    {
        public uint sampleCount;
        public uint sampleRate;
        public uint sampleSize;
        public uint channels;
        public IntPtr data;
    }

    // Sound source type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Sound
    {
        public IntPtr audioBuffer;
        public uint source;
        public uint buffer;
        public int format;
    }

    // Audio stream type
    // NOTE: Useful to create custom audio streams not bound to a specific file
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AudioStream
    {
        public uint sampleRate;
        public uint sampleSize;
        public uint channels;
        public IntPtr audioBuffer;
        public int format;

        public uint source;
        public IntPtr buffers;
    }

    // Head-Mounted-Display device parameters
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct VrDeviceInfo
    {
        public int hResolution;
        public int vResolution;
        public float hScreenSize;
        public float vScreenSize;
        public float vScreenCenter;
        public float eyeToScreenDistance;
        public float lensSeparationDistance;
        public float interpupillaryDistance;
        public fixed float lensDistortionValues[4];
        public fixed float chromaAbCorrection[4];
    }

    #endregion

    [SuppressUnmanagedCodeSecurity]
    public static partial class Raylib
    {
        #region Raylib-cs Variables

        // Used by DllImport to load the native library.
        public const string nativeLibName = "raylib";
        public const float DEG2RAD = (float)Math.PI / 180.0f;
        public const float RAD2DEG = 180.0f / (float)Math.PI;

        // raylib Config Flags
        public const int FLAG_SHOW_LOGO = 1;
        public const int FLAG_FULLSCREEN_MODE = 2;
        public const int FLAG_WINDOW_RESIZABLE = 4;
        public const int FLAG_WINDOW_UNDECORATED = 8;
        public const int FLAG_WINDOW_TRANSPARENT = 16;
        public const int FLAG_MSAA_4X_HINT = 32;
        public const int FLAG_VSYNC_HINT = 64;

        // Keyboard Function Keys
        public const int KEY_SPACE = 32;
        public const int KEY_ESCAPE = 256;
        public const int KEY_ENTER = 257;
        public const int KEY_TAB = 258;
        public const int KEY_BACKSPACE = 259;
        public const int KEY_INSERT = 260;
        public const int KEY_DELETE = 261;
        public const int KEY_RIGHT = 262;
        public const int KEY_LEFT = 263;
        public const int KEY_DOWN = 264;
        public const int KEY_UP = 265;
        public const int KEY_PAGE_UP = 266;
        public const int KEY_PAGE_DOWN = 267;
        public const int KEY_HOME = 268;
        public const int KEY_END = 269;
        public const int KEY_CAPS_LOCK = 280;
        public const int KEY_SCROLL_LOCK = 281;
        public const int KEY_NUM_LOCK = 282;
        public const int KEY_PRINT_SCREEN = 283;
        public const int KEY_PAUSE = 284;
        public const int KEY_F1 = 290;
        public const int KEY_F2 = 291;
        public const int KEY_F3 = 292;
        public const int KEY_F4 = 293;
        public const int KEY_F5 = 294;
        public const int KEY_F6 = 295;
        public const int KEY_F7 = 296;
        public const int KEY_F8 = 297;
        public const int KEY_F9 = 298;
        public const int KEY_F10 = 299;
        public const int KEY_F11 = 300;
        public const int KEY_F12 = 301;
        public const int KEY_LEFT_SHIFT = 340;
        public const int KEY_LEFT_CONTROL = 341;
        public const int KEY_LEFT_ALT = 342;
        public const int KEY_RIGHT_SHIFT = 344;
        public const int KEY_RIGHT_CONTROL = 345;
        public const int KEY_RIGHT_ALT = 346;
        public const int KEY_GRAVE = 96;
        public const int KEY_SLASH = 47;
        public const int KEY_BACKSLASH = 92;

        // Keyboard Alpha Numeric Keys
        public const int KEY_ZERO = 48;
        public const int KEY_ONE = 49;
        public const int KEY_TWO = 50;
        public const int KEY_THREE = 51;
        public const int KEY_FOUR = 52;
        public const int KEY_FIVE = 53;
        public const int KEY_SIX = 54;
        public const int KEY_SEVEN = 55;
        public const int KEY_EIGHT = 56;
        public const int KEY_NINE = 57;
        public const int KEY_A = 65;
        public const int KEY_B = 66;
        public const int KEY_C = 67;
        public const int KEY_D = 68;
        public const int KEY_E = 69;
        public const int KEY_F = 70;
        public const int KEY_G = 71;
        public const int KEY_H = 72;
        public const int KEY_I = 73;
        public const int KEY_J = 74;
        public const int KEY_K = 75;
        public const int KEY_L = 76;
        public const int KEY_M = 77;
        public const int KEY_N = 78;
        public const int KEY_O = 79;
        public const int KEY_P = 80;
        public const int KEY_Q = 81;
        public const int KEY_R = 82;
        public const int KEY_S = 83;
        public const int KEY_T = 84;
        public const int KEY_U = 85;
        public const int KEY_V = 86;
        public const int KEY_W = 87;
        public const int KEY_X = 88;
        public const int KEY_Y = 89;
        public const int KEY_Z = 90;

        // Android Physical Buttons
        public const int KEY_BACK = 4;
        public const int KEY_MENU = 82;
        public const int KEY_VOLUME_UP = 24;
        public const int KEY_VOLUME_DOWN = 25;

        // Mouse Buttons
        public const int MOUSE_LEFT_BUTTON = 0;
        public const int MOUSE_RIGHT_BUTTON = 1;
        public const int MOUSE_MIDDLE_BUTTON = 2;

        // Touch points registered
        public const int MAX_TOUCH_POINTS = 2;

        // Gamepad Number
        public const int GAMEPAD_PLAYER1 = 0;
        public const int GAMEPAD_PLAYER2 = 1;
        public const int GAMEPAD_PLAYER3 = 2;
        public const int GAMEPAD_PLAYER4 = 3;

        // Gamepad Buttons/Axis
        // PS3 USB Controller Buttons
        public const int GAMEPAD_PS3_BUTTON_TRIANGLE = 0;
        public const int GAMEPAD_PS3_BUTTON_CIRCLE = 1;
        public const int GAMEPAD_PS3_BUTTON_CROSS = 2;
        public const int GAMEPAD_PS3_BUTTON_SQUARE = 3;
        public const int GAMEPAD_PS3_BUTTON_L1 = 6;
        public const int GAMEPAD_PS3_BUTTON_R1 = 7;
        public const int GAMEPAD_PS3_BUTTON_L2 = 4;
        public const int GAMEPAD_PS3_BUTTON_R2 = 5;
        public const int GAMEPAD_PS3_BUTTON_START = 8;
        public const int GAMEPAD_PS3_BUTTON_SELECT = 9;
        public const int GAMEPAD_PS3_BUTTON_UP = 24;
        public const int GAMEPAD_PS3_BUTTON_RIGHT = 25;
        public const int GAMEPAD_PS3_BUTTON_DOWN = 26;
        public const int GAMEPAD_PS3_BUTTON_LEFT = 27;
        public const int GAMEPAD_PS3_BUTTON_PS = 12;
        // PS3 USB Controller Axis
        public const int GAMEPAD_PS3_AXIS_LEFT_X = 0;
        public const int GAMEPAD_PS3_AXIS_LEFT_Y = 1;
        public const int GAMEPAD_PS3_AXIS_RIGHT_X = 2;
        public const int GAMEPAD_PS3_AXIS_RIGHT_Y = 5;
        public const int GAMEPAD_PS3_AXIS_L2 = 3;
        public const int GAMEPAD_PS3_AXIS_R2 = 4;

        // Xbox360 USB Controller Buttons
        public const int GAMEPAD_XBOX_BUTTON_A = 0;
        public const int GAMEPAD_XBOX_BUTTON_B = 1;
        public const int GAMEPAD_XBOX_BUTTON_X = 2;
        public const int GAMEPAD_XBOX_BUTTON_Y = 3;
        public const int GAMEPAD_XBOX_BUTTON_LB = 4;
        public const int GAMEPAD_XBOX_BUTTON_RB = 5;
        public const int GAMEPAD_XBOX_BUTTON_SELECT = 6;
        public const int GAMEPAD_XBOX_BUTTON_START = 7;
        public const int GAMEPAD_XBOX_BUTTON_UP = 10;
        public const int GAMEPAD_XBOX_BUTTON_RIGHT = 11;
        public const int GAMEPAD_XBOX_BUTTON_DOWN = 12;
        public const int GAMEPAD_XBOX_BUTTON_LEFT = 13;
        public const int GAMEPAD_XBOX_BUTTON_HOME = 8;

        // Android Gamepad Controller (SNES CLASSIC)
        public const int GAMEPAD_ANDROID_DPAD_UP = 19;
        public const int GAMEPAD_ANDROID_DPAD_DOWN = 20;
        public const int GAMEPAD_ANDROID_DPAD_LEFT = 21;
        public const int GAMEPAD_ANDROID_DPAD_RIGHT = 22;
        public const int GAMEPAD_ANDROID_DPAD_CENTER = 23;
        public const int GAMEPAD_ANDROID_BUTTON_A = 96;
        public const int GAMEPAD_ANDROID_BUTTON_B = 97;
        public const int GAMEPAD_ANDROID_BUTTON_C = 98;
        public const int GAMEPAD_ANDROID_BUTTON_X = 99;
        public const int GAMEPAD_ANDROID_BUTTON_Y = 100;
        public const int GAMEPAD_ANDROID_BUTTON_Z = 101;
        public const int GAMEPAD_ANDROID_BUTTON_L1 = 102;
        public const int GAMEPAD_ANDROID_BUTTON_R1 = 103;
        public const int GAMEPAD_ANDROID_BUTTON_L2 = 104;
        public const int GAMEPAD_ANDROID_BUTTON_R2 = 105;

        // Xbox360 USB Controller Axis
        // TODO: For Raspberry Pi, axis must be reconfigured
        public const int GAMEPAD_XBOX_AXIS_LEFT_X = 0;
        public const int GAMEPAD_XBOX_AXIS_LEFT_Y = 1;
        public const int GAMEPAD_XBOX_AXIS_RIGHT_X = 2;
        public const int GAMEPAD_XBOX_AXIS_RIGHT_Y = 3;
        public const int GAMEPAD_XBOX_AXIS_LT = 4;
        public const int GAMEPAD_XBOX_AXIS_RT = 5;

        // Custom raylib color palette for amazing visuals
        public static Color LIGHTGRAY = new Color(200, 200, 200, 255);
        public static Color GRAY = new Color(130, 130, 130, 255);
        public static Color DARKGRAY = new Color(80, 80, 80, 255);
        public static Color YELLOW = new Color(253, 249, 0, 255);
        public static Color GOLD = new Color(255, 203, 0, 255);
        public static Color ORANGE = new Color(255, 161, 0, 255);
        public static Color PINK = new Color(255, 109, 194, 255);
        public static Color RED = new Color(230, 41, 55, 255);
        public static Color MAROON = new Color(190, 33, 55, 255);
        public static Color GREEN = new Color(0, 228, 48, 255);
        public static Color LIME = new Color(0, 158, 47, 255);
        public static Color DARKGREEN = new Color(0, 117, 44, 255);
        public static Color SKYBLUE = new Color(102, 191, 255, 255);
        public static Color BLUE = new Color(0, 121, 241, 255);
        public static Color DARKBLUE = new Color(0, 82, 172, 255);
        public static Color PURPLE = new Color(200, 122, 255, 255);
        public static Color VIOLET = new Color(135, 60, 190, 255);
        public static Color DARKPURPLE = new Color(112, 31, 126, 255);
        public static Color BEIGE = new Color(211, 176, 131, 255);
        public static Color BROWN = new Color(127, 106, 79, 255);
        public static Color DARKBROWN = new Color(76, 63, 47, 255);
        public static Color WHITE = new Color(255, 255, 255, 255);
        public static Color BLACK = new Color(0, 0, 0, 255);
        public static Color BLANK = new Color(0, 0, 0, 0);
        public static Color MAGENTA = new Color(255, 0, 255, 255);
        public static Color RAYWHITE = new Color(245, 245, 245, 255);

        public const int MAX_SHADER_LOCATIONS = 32;
        public const int MAX_MATERIAL_MAPS = 12;

        #endregion

        #region Raylib-cs Functions

        //------------------------------------------------------------------------------------
        // Window and Graphics Device Functions (Module: core)
        //------------------------------------------------------------------------------------

        // Initialize window and OpenGL context
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InitWindow(int width, int height, string title);

         // Close window and unload OpenGL context
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseWindow();

        // Check if window has been initialized successfully
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsWindowReady();

        // Check if KEY_ESCAPE pressed or Close icon pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WindowShouldClose();

        // Check if window has been minimized (or lost focus)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsWindowMinimized();

        // Toggle fullscreen mode (only PLATFORM_DESKTOP)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ToggleFullscreen();

        // Set icon for window (only PLATFORM_DESKTOP)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowIcon(Image image);

        // Set title for window (only PLATFORM_DESKTOP)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowTitle(string title);

        // Set window position on screen (only PLATFORM_DESKTOP)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowPosition(int x, int y);

        // Set monitor for the current window (fullscreen mode)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMonitor(int monitor);

        // Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMinSize(int width, int height);

        // Set window dimensions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowSize(int width, int height);

        // Get current screen width
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenWidth();

        // Get current screen height
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenHeight();

         // Get number of connected monitors
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorCount();

        // Get primary monitor width
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorWidth(int monitor);

        // Get primary monitor height
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorHeight(int monitor);

        // Get primary monitor physical width in millimetres
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorPhysicalWidth(int monitor);

        // Get primary monitor physical height in millimetres
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorPhysicalHeight(int monitor);

        // Get the human-readable, UTF-8 encoded name of the primary monitor
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetMonitorName(int monitor);

        // Get handle from window
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWindowHandle();

        // Get current clipboard text
        //[DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        //public static extern string GetClipboard();

        // Set current clipboard text
        //[DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        //public static extern void SetClipboard(string text);

        // Cursor-related functions
        // Shows cursor
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowCursor();

        // Hides cursor
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideCursor();

        // Check if cursor is not visible
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsCursorHidden();

        // Enables cursor (unlock cursor)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableCursor();

        // Disables cursor (lock cursor)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableCursor();

        // Drawing-related functions
        // Set background color (framebuffer clear color)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearBackground(Color color);

        // Setup canvas (framebuffer) to start drawing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginDrawing();

        // End canvas drawing and swap buffers (double buffering)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndDrawing();

        // Initialize 2D mode with custom camera (2D)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginMode2D(Camera2D camera);

        // Ends 2D mode with custom camera
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndMode2D();

        // Initializes 3D mode with custom camera (3D)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginMode3D(Camera3D camera);

        // Ends 3D mode and returns to default 2D orthographic mode
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndMode3D();

        // Initializes render texture for drawing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginTextureMode(RenderTexture2D target);

        // Ends drawing to render texture
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndTextureMode();

        // Screen-space-related functions
        // Returns a ray trace from mouse position
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Ray GetMouseRay(Vector2 mousePosition, Camera3D camera);

        // Returns the screen space position for a 3d world space position
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreen(Vector3 position, Camera3D camera);

        // Returns camera transform matrix (view matrix)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix GetCameraMatrix(Camera3D camera);

        // timing-related functions
        // Set target FPS (maximum)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTargetFPS(int fps);

        // Returns current FPS
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFPS();

        // Returns time in seconds for last frame drawn
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetFrameTime();

        // Returns elapsed time in seconds since InitWindow()
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetTime();

        // Color-related functions
        // Returns hexadecimal value for a Color
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int ColorToInt(Color color);

        // Returns color normalized as float [0..1]
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4 ColorNormalize(Color color);

        // Returns HSV values for a Color
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 ColorToHSV(Color color);

        // Returns a Color struct from hexadecimal value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetColor(int hexValue);

        // Color fade-in or fade-out, alpha goes from 0.0f to 1.0f
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Color Fade(Color color, float alpha);

        // Misc. functions
        // Activate raylib logo at startup (can be done with flags)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowLogo();

        // Setup window configuration flags (view FLAGS)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetConfigFlags(byte flags);

        // Enable trace log message types (bit flags based)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLog(byte types);

        // Show trace log messages (LOG_INFO, LOG_WARNING, LOG_ERROR, LOG_DEBUG)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void TraceLog(int logType, string text, params object[] args);

        // Takes a screenshot of current screen (saved a .png)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void TakeScreenshot(string fileName);

        // Returns a random value between min and max (both included)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRandomValue(int min, int max);

        // Files management functions
        // Check file extension
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsFileExtension(string fileName, string ext);

        // Get pointer to extension for a filename string
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetExtension(string fileName);

        // Get pointer to filename for a path string
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetFileName(string filePath);

        // Get full path for a given fileName (uses static string)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetDirectoryPath(string fileName);

        // Get current working directory (uses static string)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetWorkingDirectory();

        // Change working directory, returns true if success
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ChangeDirectory(string dir);

        // Check if a file has been dropped into window
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsFileDropped();

        // Get dropped files names
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr GetDroppedFiles( ref int count);
		// Get Dropped files Pointer translation
		public static string[] GetDroppedFiles()
		{
			int count = 0;
			IntPtr pointer = GetDroppedFiles(ref count);

			string[] s = new string[count];
			char[] word;
			int i, j, size;

			//TODO: this is a mess, find a better way
			unsafe
			{
				byte** str = (byte**)pointer.ToPointer();

				i = 0;
				while (i < count)
				{
					j = 0;
					while (str[i][j] != 0)
						j++;
					size = j;
					word = new char[size];
					j = 0;
					while (str[i][j] != 0)
					{
						word[j] = (char)str[i][j];
						j++;
					}
					s[i] = new string(word);

					i++;
				}
			}
			return s;
		}

        // Clear dropped files paths buffer
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearDroppedFiles();

        // Persistent storage management
        // Save integer value to storage file (to defined position)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void StorageSaveValue(int position, int value);

        // Load integer value from storage file (from defined position)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int StorageLoadValue(int position);

        //------------------------------------------------------------------------------------
        // Input Handling Functions (Module: core)
        //------------------------------------------------------------------------------------

        // Input-related functions: keyboard
        // Detect if a key has been pressed once
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyPressed(int key);

        // Detect if a key is being pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyDown(int key);

        // Detect if a key has been released once
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyReleased(int key);

        // Detect if a key is NOT being pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyUp(int key);

        // Get latest key pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetKeyPressed();

        // Set a custom key to exit program (default is ESC)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetExitKey(int key);

        // Input-related functions: gamepads
        // Detect if a gamepad is available
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadAvailable(int gamepad);

        // Check gamepad name (if available)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadName(int gamepad, string name);

        // Return gamepad internal name id
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetGamepadName(int gamepad);

        // Detect if a gamepad button has been pressed once
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonPressed(int gamepad, int button);

        // Detect if a gamepad button is being pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonDown(int gamepad, int button);

        // Detect if a gamepad button has been released once
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonReleased(int gamepad, int button);

        // Detect if a gamepad button is NOT being pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonUp(int gamepad, int button);

        // Get the last gamepad button pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadButtonPressed();

        // Return gamepad axis count for a gamepad
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadAxisCount(int gamepad);

        // Return axis movement value for a gamepad axis
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGamepadAxisMovement(int gamepad, int axis);

        // Input-related functions: mouse
        // Detect if a mouse button has been pressed once
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonPressed(int button);

        // Detect if a mouse button is being pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonDown(int button);

        // Detect if a mouse button has been released once
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonReleased(int button);

        // Detect if a mouse button is NOT being pressed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonUp(int button);

        // Returns mouse position X
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseX();

        // Returns mouse position Y
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseY();

        // Returns mouse position XY
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMousePosition();

        // Set mouse position XY
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMousePosition(Vector2 position);

        // Set mouse scaling
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMouseScale(float scale);

        // Returns mouse wheel movement Y
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseWheelMove();

        // Input-related functions: touch
        // Returns touch position X for touch point 0 (relative to screen size)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchX();

        // Returns touch position Y for touch point 0 (relative to screen size)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchY();

        // Returns touch position XY for a touch point index (relative to screen size)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetTouchPosition(int index);

        //------------------------------------------------------------------------------------
        // Gestures and Touch Handling Functions (Module: gestures)
        //------------------------------------------------------------------------------------
        // Enable a set of gestures using flags
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGesturesEnabled(uint gestureFlags);

        // Check if a gesture have been detected
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGestureDetected(int gesture);

        // Get latest detected gesture
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGestureDetected();

        // Get touch points count
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchPointsCount();

        // Get gesture hold time in milliseconds
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureHoldDuration();

        // Get gesture drag vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGestureDragVector();

        // Get gesture drag angle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureDragAngle();

        // Get gesture pinch delta
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGesturePinchVector();

        // Get gesture pinch angle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGesturePinchAngle();

        //------------------------------------------------------------------------------------
        // Camera System Functions (Module: camera)
        //------------------------------------------------------------------------------------

        // Set camera mode (multiple camera modes available)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMode(Camera3D camera, int mode);

        // Update camera position for selected mode
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateCamera(ref Camera3D camera);

        // Set camera pan key to combine with mouse movement (free camera)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraPanControl(int panKey);

        // Set camera alt key to combine with mouse movement (free camera)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraAltControl(int altKey);

        // Set camera smooth zoom key to combine with mouse (free camera)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraSmoothZoomControl(int szKey);

        // Set camera move controls (1st person and 3rd person cameras)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMoveControls(int frontKey, int backKey, int rightKey, int leftKey, int upKey, int downKey);

        //------------------------------------------------------------------------------------
        // Basic Shapes Drawing Functions (Module: shapes)
        //------------------------------------------------------------------------------------

        // Draw a pixel
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixel(int posX, int posY, Color color);

        // Draw a pixel (Vector version)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixelV(Vector2 position, Color color);

        // Draw a line
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color);

        // Draw a line (Vector version)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineV(Vector2 startPos, Vector2 endPos, Color color);

        // Draw a line defining thickness
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color);

        // Draw a line using cubic-bezier curves in-out
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color);

        // Draw a color-filled circle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircle(int centerX, int centerY, float radius, Color color);

        // Draw a gradient-filled circle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2);

        // Draw a color-filled circle (Vector version)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleV(Vector2 center, float radius, Color color);

        // Draw circle outline
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleLines(int centerX, int centerY, float radius, Color color);

        // Draw a color-filled rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangle(int posX, int posY, int width, int height, Color color);

        // Draw a color-filled rectangle (Vector version)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleV(Vector2 position, Vector2 size, Color color);

        // Draw a color-filled rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRec(Rectangle rec, Color color);

        // Draw a color-filled rectangle with pro parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color);

        // Draw a vertical-gradient-filled rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2);

        // Draw a horizontal-gradient-filled rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2);

        // Draw a gradient-filled rectangle with custom vertex colors
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4);

        // Draw rectangle outline
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleLines(int posX, int posY, int width, int height, Color color);

        // Draw rectangle outline with extended parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleLinesEx(Rectangle rec, int lineThick, Color color);

        // Draw a color-filled triangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

        // Draw triangle outline
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

        // Draw a regular polygon (Vector version)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color);

        // Draw a closed polygon defined by points
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPolyEx(Vector2[] points, int numPoints, Color color);

        // Draw polygon lines
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPolyExLines(Vector2[] points, int numPoints, Color color);

        // Check collision between two rectangles
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRecs(Rectangle rec1, Rectangle rec2);

        // Check collision between two circles
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2);

        // Check collision between circle and rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec);

        // Get collision rectangle for two rectangles collision
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2);

        // Check if point is inside rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionPointRec(Vector2 point, Rectangle rec);

        // Check if point is inside circle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius);

        // Check if point is inside a triangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3);

        //------------------------------------------------------------------------------------
        // Texture Loading and Drawing Functions (Module: textures)
        //------------------------------------------------------------------------------------

        // Load image from file into CPU memory (RAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImage(string fileName);

        // Load image from Color array data (RGBA - 32bit)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageEx(Color[] pixels, int width, int height);

        // Load image from raw data with parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImagePro(IntPtr data, int width, int height, int format);

        // Load image from RAW file data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageRaw(string fileName, int width, int height, int format, int headerSize);

        // Export image as a PNG file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportImage(string fileName, Image image);

        // Load texture from file into GPU memory (VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTexture(string fileName);

        // Load texture from image data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTextureFromImage(Image image);

        // Load texture for rendering (framebuffer)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderTexture2D LoadRenderTexture(int width, int height);

        // Unload image from CPU memory (RAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImage(Image image);

        // Unload texture from GPU memory (VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadTexture(Texture2D texture);

        // Unload render texture from GPU memory (VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadRenderTexture(RenderTexture2D target);

        // Get pixel data from image as a Color struct array
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetImageData(Image image);

        // Get pixel data from image as Vector4 array (float normalized)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4[] GetImageDataNormalized(Image image);

        // Get pixel data size in bytes (image or texture)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPixelDataSize(int width, int height, int format);

        // Get pixel data from GPU texture and return an Image
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GetTextureData(Texture2D texture);

        // Update GPU texture with new data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateTexture(Texture2D texture, IntPtr pixels);

        // Image manipulation functions
        // Create an image duplicate (useful for transformations)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageCopy(Image image);

        // Convert image to POT (power-of-two)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageToPOT(ref Image image, Color fillColor);

        // Convert image data to desired format
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFormat(ref Image image, int newFormat);

        // Apply alpha mask to image
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaMask(ref Image image, Image alphaMask);

        // Clear alpha channel to desired color
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaClear(ref Image image, Color color, float threshold);

        // Crop image depending on alpha value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaCrop(ref Image image, float threshold);

        // Premultiply alpha channel
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaPremultiply(ref Image image);

        // Crop an image to a defined rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageCrop(ref Image image, Rectangle crop);

        // Resize image (bilinear filtering)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResize(ref Image image, int newWidth, int newHeight);

        // Resize image (Nearest-Neighbor scaling algorithm)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeNN(ref Image image, int newWidth,int newHeight);

        // Resize canvas and fill with color
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeCanvas(ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color color);

        // Generate all mipmap levels for a provided image
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageMipmaps(ref Image image);

        // Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDither(ref Image image, int rBpp, int gBpp, int bBpp, int aBpp);

        // Create an image from text (default font)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageText(string text, int fontSize, Color color);

        // Create an image from text (custom sprite font)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint);

        // Draw a source image within a destination image
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDraw(ref Image dst, Image src, Rectangle srcRec, Rectangle dstRec);

        // Draw rectangle within an image
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangle(ref Image dst, Vector2 position, Rectangle rec, Color color);

        // Draw text (default font) within an image (destination)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawText(ref Image dst, Vector2 position, string text, int fontSize, Color color);

        // Draw text (custom sprite font) within an image (destination)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawTextEx(ref Image dst, Vector2 position, Font font, string text, float fontSize, float spacing, Color color);

        // Flip image vertically
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipVertical(ref Image image);

        // Flip image horizontally
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipHorizontal(ref Image image);

        // Rotate image clockwise 90deg
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCW(Image image);

        // Rotate image counter-clockwise 90deg
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCCW(Image image);

        // Modify image color: tint
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorTint(ref Image image, Color color);

        // Modify image color: invert
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorInvert(ref Image image);

        // Modify image color: grayscale
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorGrayscale(ref Image image);

        // Modify image color: contrast (-100 to 100)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorContrast(ref Image image, float contrast);

        // Modify image color: brightness (-255 to 255)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorBrightness(ref Image image, int brightness);

        // Modify image color: replace color
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorReplace(Image image, Color color, Color replace);

        // Image generation functions
        // Generate image: plain color
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageColor(int width, int height, Color color);

        // Generate image: vertical gradient
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientV(int width, int height, Color top, Color bottom);

        // Generate image: horizontal gradient
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientH(int width, int height, Color left, Color right);

        // Generate image: radial gradient
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer);

        // Generate image: checked
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2);

        // Generate image: white noise
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageWhiteNoise(int width, int height, float factor);

        // Generate image: perlin noise
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImagePerlinNoise(int width, int height, int offsetX, int offsetY, float scale);

        // Generate image: cellular algorithm. Bigger tileSize means bigger cells
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageCellular(int width, int height, int tileSize);

        // Texture2D configuration functions
        // Generate GPU mipmaps for a texture
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenTextureMipmaps(ref Texture2D texture);

        // Set texture scaling filter mode
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextureFilter(Texture2D texture, int filterMode);

        // Set texture wrapping mode
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextureWrap(Texture2D texture, int wrapMode);

        // Texture2D drawing functions
        // Draw a Texture2D
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexture(Texture2D texture, int posX, int posY, Color tint);

        // Draw a Texture2D with position defined as Vector2
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureV(Texture2D texture, Vector2 position, Color tint);

        // Draw a Texture2D with extended parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint);

        // Draw a part of a texture defined by a rectangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureRec(Texture2D texture, Rectangle sourceRec, Vector2 position, Color tint);

        // Draw a part of a texture defined by a rectangle with 'pro' parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexturePro(Texture2D texture, Rectangle sourceRec, Rectangle destRec, Vector2 origin, float rotation, Color tint);

        //------------------------------------------------------------------------------------
        // Font Loading and Text Drawing Functions (Module: text)
        //------------------------------------------------------------------------------------

        // Font loading/unloading functions
        // Get the default Font
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Font GetFontDefault();

        // Load font from file into GPU memory (VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFont(string fileName);

        // Load font from file with extended parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontEx(string fileName, int fontSize, int charsCount, int[] fontChars);

        // Load font data for further use
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadFontData(string fileName, int fontSize, int[] fontChars, int charsCount, bool sdf);

        // Generate image font atlas using chars info
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageFontAtlas(IntPtr chars, int fontSize, int charsCount, int padding, int packMethod);

        // Unload Font from GPU memory (VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFont(Font font);

        // Text drawing functions
        // Shows current FPS
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawFPS(int posX, int posY);

        // Draw text (using default font)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawText(string text, int posX, int posY, int fontSize, Color color);

        // Draw text using font and additional parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint);

        // Measure string width for default font
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int MeasureText(string text, int fontSize);

        // Text misc. functions
        // Measure string size for Font
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing);

        // extension providing SubText
        public static string SubText(this string input, int position, int length)
        {
            return input.Substring(position, Math.Min(length, input.Length));
        }

        // Get index position for a unicode character on font
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGlyphIndex(Font font, int character);

        //------------------------------------------------------------------------------------
        // Basic 3d Shapes Drawing Functions (Module: models)
        //------------------------------------------------------------------------------------

        // Basic geometric 3D shapes drawing functions
        // Draw a line in 3D world space
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color);

        // Draw a circle in 3D world space
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color);

        // Draw cube
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCube(Vector3 position, float width, float height, float length, Color color);

        // Draw cube (Vector version)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeV(Vector3 position, Vector3 size, Color color);

        // Draw cube wires
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeWires(Vector3 position, float width, float height, float length, Color color);

        // Draw cube textured
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeTexture(Texture2D texture, Vector3 position, float width, float height, float length, Color color);

        // Draw sphere
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphere(Vector3 centerPos, float radius, Color color);

        // Draw sphere with extended parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color);

        // Draw sphere wires
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color);

        // Draw a cylinder/cone
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);

        // Draw a cylinder/cone wires
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);

        // Draw a plane XZ
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPlane(Vector3 centerPos, Vector2 size, Color color);

        // Draw a ray line
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRay(Ray ray, Color color);

        // Draw a grid (centered at (0, 0, 0))
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawGrid(int slices, float spacing);

        // Draw simple gizmo
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawGizmo(Vector3 position);

        //------------------------------------------------------------------------------------
        // Model 3d Loading and Drawing Functions (Module: models)
        //------------------------------------------------------------------------------------

        // Model loading/unloading functions
        // Load model from files (mesh and material)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModel(string fileName);

        // Load model from generated mesh
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModelFromMesh(Mesh mesh);

        // Unload model from memory (RAM and/or VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModel(Model model);

        // Mesh loading/unloading functions
        // Load mesh from file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh LoadMesh(string fileName);

        // Unload mesh from memory (RAM and/or VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMesh(ref Mesh mesh);

        // Export mesh as an OBJ file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportMesh(string fileName, Mesh mesh);

        // Mesh manipulation functions
        // Compute mesh bounding box limits
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern BoundingBox MeshBoundingBox(Mesh mesh);

        // Compute mesh tangents
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void MeshTangents(ref Mesh mesh);

        // Compute mesh binormals
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void MeshBinormals(ref Mesh mesh);

        // Mesh generation functions
        // Generate plane mesh (with subdivisions)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshPlane(float width, float length, int resX, int resZ);

        // Generate cuboid mesh
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCube(float width, float height, float length);

        // Generate sphere mesh (standard sphere)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshSphere(float radius, int rings, int slices);

        // Generate half-sphere mesh (no bottom cap)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshHemiSphere(float radius, int rings, int slices);

        // Generate cylinder mesh
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCylinder(float radius, float height, int slices);

        // Generate torus mesh
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshTorus(float radius, float size, int radSeg, int sides);

        // Generate trefoil knot mesh
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshKnot(float radius, float size, int radSeg, int sides);

        // Generate heightmap mesh from image data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshHeightmap(Image heightmap, Vector3 size);

        // Generate cubes-based map mesh from image data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize);

        // Material loading/unloading functions
        // Load material from file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Material LoadMaterial(string fileName);

        // Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Material LoadMaterialDefault();

        // Unload material from GPU memory (VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMaterial(Material material);

        // Model drawing functions
        // Draw a model (with texture if set)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModel(Model model, Vector3 position, float scale, Color tint);

        // Draw a model with extended parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);

        // Draw a model wires (with texture if set)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelWires(Model model, Vector3 position, float scale, Color tint);

        // Draw a model wires (with texture if set) with extended parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);

        // Draw bounding box (wires)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBoundingBox(BoundingBox box, Color color);

        // Draw a billboard texture
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboard(Camera3D camera, Texture2D texture, Vector3 center, float size, Color tint);

        // Draw a billboard texture defined by sourceRec
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboardRec(Camera3D camera, Texture2D texture, Rectangle sourceRec, Vector3 center, float size, Color tint);

        // Collision detection functions
        // Detect collision between two spheres
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionSpheres(Vector3 centerA, float radiusA, Vector3 centerB, float radiusB);

        // Detect collision between two bounding boxes
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2);

        // Detect collision between box and sphere
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionBoxSphere(BoundingBox box, Vector3 centerSphere, float radiusSphere);

        // Detect collision between ray and sphere
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRaySphere(Ray ray, Vector3 spherePosition, float sphereRadius);

        // Detect collision between ray and sphere, returns collision point
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRaySphereEx(Ray ray, Vector3 spherePosition, float sphereRadius, Vector3 collisionPoint);

        // Detect collision between ray and box
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRayBox(Ray ray, BoundingBox box);

        // Get collision info between ray and model
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayModel(Ray ray, ref Model model);

        // Get collision info between ray and triangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3);

        // Get collision info between ray and ground plane (Y-normal plane)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayGround(Ray ray, float groundHeight);

        //------------------------------------------------------------------------------------
        // Shaders System Functions (Module: rlgl)
        // NOTE: This functions are useless when using OpenGL 1.1
        //------------------------------------------------------------------------------------

        // Shader loading/unloading functions
        // Load chars array from text file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern string LoadText(string fileName);

        // Load shader from files and bind default locations
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader LoadShader(string vsFileName, string fsFileName);

        // Load shader from code strings and bind default locations
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader LoadShaderCode(string vsCode, string fsCode);

        // Unload shader from GPU memory (VRAM)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadShader(Shader shader);

        // Get default shader
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader GetShaderDefault();

        // Get default texture
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GetTextureDefault();

        // Shader configuration functions
        // Get shader uniform location
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetShaderLocation(Shader shader, string uniformName);

        // Set shader uniform value (float)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValue(Shader shader, int uniformLoc, float[] value, int size);

        // Set shader uniform value (int)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValuei(Shader shader, int uniformLoc, int[] value, int size);

        // Set shader uniform value (matrix 4x4)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueMatrix(Shader shader, int uniformLoc, Matrix mat);

        // Set a custom projection matrix (replaces internal projection matrix)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMatrixProjection(Matrix proj);

        // Set a custom modelview matrix (replaces internal modelview matrix)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMatrixModelview(Matrix view);

        // Get internal modelview matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix GetMatrixModelview();

        // Texture maps generation (PBR)
        // NOTE: Required shaders should be provided
        // Generate cubemap texture from HDR texture
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTextureCubemap(Shader shader, Texture2D skyHDR, int size);

        // Generate irradiance texture using cubemap data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTextureIrradiance(Shader shader, Texture2D cubemap, int size);

        // Generate prefilter texture using cubemap data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTexturePrefilter(Shader shader, Texture2D cubemap, int size);

        // Generate BRDF texture using cubemap data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTextureBRDF(Shader shader, Texture2D cubemap, int size);

        // Shading begin/end functions
        // Begin custom shader drawing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginShaderMode(Shader shader);

        // End custom shader drawing (use default shader)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndShaderMode();

        // Begin blending mode (alpha, additive, multiplied)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginBlendMode(int mode);

        // End blending mode (reset to default: alpha blending)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndBlendMode();

        // VR control functions
        // Get VR device information for some standard devices
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern VrDeviceInfo GetVrDeviceInfo(int vrDeviceType);

        // Init VR simulator for selected device parameters
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitVrSimulator(VrDeviceInfo info);

        // Close VR simulator for current device
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseVrSimulator();

        // Detect if VR simulator is ready
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsVrSimulatorReady();

        // Set VR distortion shader for stereoscopic rendering
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVrDistortionShader(Shader shader);

        // Update VR tracking (position and orientation) and camera
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateVrTracking(Camera3D camera);

        // Enable/Disable VR experience
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ToggleVrMode();

        // Begin VR simulator stereo rendering
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginVrDrawing();

        // End VR simulator stereo rendering
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndVrDrawing();

        //------------------------------------------------------------------------------------
        // Audio Loading and Playing Functions (Module: audio)
        //------------------------------------------------------------------------------------

        // Audio device management functions
        // Initialize audio device and context
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitAudioDevice();

        // Close the audio device and context
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioDevice();

        // Check if audio device has been initialized successfully
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsAudioDeviceReady();

        // Set master volume (listener)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMasterVolume(float volume);

        // Wave/Sound loading/unloading functions
        // Load wave data from file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWave(string fileName);

        // Load wave data from raw array data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWaveEx(IntPtr data, int sampleCount, int sampleRate, int sampleSize, int channels);

        // Load sound from file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSound(string fileName);

        // Load sound from wave data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSoundFromWave(Wave wave);

        // Update sound buffer with new data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateSound(Sound sound, byte[] data, int samplesCount);

        // Unload wave data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadWave(Wave wave);

        // Unload sound
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadSound(Sound sound);

        // Wave/Sound management functions
        // Play a sound
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlaySound(Sound sound);

        // Pause a sound
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseSound(Sound sound);

        // Resume a paused sound
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeSound(Sound sound);

        // Stop playing a sound
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopSound(Sound sound);

        // Check if a sound is currently playing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsSoundPlaying(Sound sound);

        // Set volume for a sound (1.0 is max level)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundVolume(Sound sound, float volume);

        // Set pitch for a sound (1.0 is base level)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundPitch(Sound sound, float pitch);

        // Convert wave data to desired format
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveFormat(ref Wave wave, int sampleRate, int sampleSize, int channels);

        // Copy a wave to a new wave
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave WaveCopy(Wave wave);

        // Crop a wave to defined samples range
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveCrop(ref Wave wave, int initSample, int finalSample);

        // Get samples data from wave as a floats array
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float[] GetWaveData(Wave wave);

        // Music management functions
        // Load IntPtr stream from file
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadMusicStream(string fileName);

        // Unload IntPtr stream
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMusicStream(IntPtr music);

        // Start IntPtr playing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayMusicStream(IntPtr music);

        // Updates buffers for IntPtr streaming
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMusicStream(IntPtr music);

        // Stop IntPtr playing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopMusicStream(IntPtr music);

        // Pause IntPtr playing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseMusicStream(IntPtr music);

        // Resume playing paused music
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeMusicStream(IntPtr music);

        // Check if IntPtr is playing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMusicPlaying(IntPtr music);

        // Set volume for IntPtr (1.0 is max level)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicVolume(IntPtr music, float volume);

        // Set pitch for a IntPtr (1.0 is base level)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicPitch(IntPtr music, float pitch);

        // Set IntPtr loop count (loop repeats)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicLoopCount(IntPtr music, int count);

        // Get IntPtr time length (in seconds)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimeLength(IntPtr music);

        // Get current IntPtr time played (in seconds)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimePlayed(IntPtr music);

        // AudioStream management functions
        // Init audio stream (to stream raw audio pcm data)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern AudioStream InitAudioStream(uint sampleRate, uint sampleSize, uint channels);

        // Update audio stream buffers with data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl, EntryPoint = "UpdateAudioStream")]
        private static extern void UpdateAudioStreamInternal(AudioStream stream, IntPtr data, int samplesCount);

        // Update audio stream buffers with data(byte)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateAudioStream(AudioStream stream, ref byte[] data, int samplesCount);

        // Update audio stream buffers with data(short)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateAudioStream(AudioStream stream, ref short[] data, int samplesCount);

        // Update audio stream buffers with data(float)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateAudioStream(AudioStream stream, ref float[] data, int samplesCount);

        // Close audio stream and free memory
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioStream(AudioStream stream);

        // Check if any audio stream buffers requires refill
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsAudioBufferProcessed(AudioStream stream);

        // Play audio stream
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayAudioStream(AudioStream stream);

        // Pause audio stream
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseAudioStream(AudioStream stream);

        // Resume audio stream
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeAudioStream(AudioStream stream);

        // Check if audio stream is playing
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsAudioStreamPlaying(AudioStream stream);

        // Stop audio stream
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopAudioStream(AudioStream stream);

        // Set volume for audio stream (1.0 is max level)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamVolume(AudioStream stream, float volume);

        // Set pitch for audio stream (1.0 is base level)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamPitch(AudioStream stream, float pitch);

        #endregion
    }
}
