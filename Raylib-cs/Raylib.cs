using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    /// <summary>
    /// Color type, RGBA (32bit)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        // Example - Color.RED instead of RED
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

        public override string ToString()
        {
            return string.Concat(r.ToString(), " ", g.ToString(), " ", b.ToString(), " ", a.ToString());
        }
    }

    /// <summary>
    /// Rectangle type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
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

    /// <summary>
    /// Image type, bpp always RGBA (32bit)
    /// <br/>
    /// NOTE: Data stored in CPU memory (RAM)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Image
    {
        /// <summary>
        /// Image raw data (void *)
        /// </summary>
        public IntPtr data;

        /// <summary>
        /// Image base width
        /// </summary>
        public int width;

        /// <summary>
        /// Image base height
        /// </summary>
        public int height;

        /// <summary>
        /// Mipmap levels, 1 by default
        /// </summary>
        public int mipmaps;

        /// <summary>
        /// Data format (PixelFormat type)
        /// </summary>
        public PixelFormat format;
    }

    /// <summary>
    /// Texture2D type
    /// <br />
    /// NOTE: Data stored in GPU memory
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Texture2D
    {
        /// <summary>
        /// OpenGL texture id
        /// </summary>
        public uint id;

        /// <summary>
        /// Texture base width
        /// </summary>
        public int width;

        /// <summary>
        /// Texture base height
        /// </summary>
        public int height;

        /// <summary>
        /// Mipmap levels, 1 by default
        /// </summary>
        public int mipmaps;

        /// <summary>
        /// Data format (PixelFormat type)
        /// </summary>
        public PixelFormat format;
    }

    /// <summary>
    /// RenderTexture2D type, for texture rendering
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderTexture2D
    {
        /// <summary>
        /// OpenGL Framebuffer Object (FBO) id
        /// </summary>
        public uint id;

        /// <summary>
        ///  Color buffer attachment texture
        /// </summary>
        public Texture2D texture;

        /// <summary>
        /// Depth buffer attachment texture
        /// </summary>
        public Texture2D depth;
    }

    /// <summary>
    /// N-Patch layout info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NPatchInfo
    {
        /// <summary>
        /// Texture source rectangle
        /// </summary>
        public Rectangle source;

        /// <summary>
        /// Left border offset
        /// </summary>
        public int left;

        /// <summary>
        /// Top border offset
        /// </summary>
        public int top;

        /// <summary>
        /// Right border offset
        /// </summary>
        public int right;

        /// <summary>
        /// Bottom border offset
        /// </summary>
        public int bottom;

        /// <summary>
        /// Layout of the n-patch: 3x3, 1x3 or 3x1
        /// </summary>
        public NPatchLayout layout;
    }

    /// <summary>
    /// Font character info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CharInfo
    {
        /// <summary>
        /// Character value (Unicode)
        /// </summary>
        public int value;

        /// <summary>
        /// Character offset X when drawing
        /// </summary>
        public int offsetX;

        /// <summary>
        /// Character offset Y when drawing
        /// </summary>
        public int offsetY;

        /// <summary>
        /// Character advance position X
        /// </summary>
        public int advanceX;

        /// <summary>
        /// Character image data
        /// </summary>
        public Image image;
    }

    /// <summary>
    /// Font, font texture and GlyphInfo array data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Font
    {
        /// <summary>
        /// Base size (default chars height)
        /// </summary>
        public int baseSize;

        /// <summary>
        /// Number of characters
        /// </summary>
        public int glyphCount;

        /// <summary>
        /// Padding around the glyph characters
        /// </summary>
        public int glyphPadding;

        /// <summary>
        /// Texture atlas containing the glyphs
        /// </summary>
        public Texture2D texture;

        /// <summary>
        /// Rectangles in texture for the glyphs
        /// </summary>
        public IntPtr recs;

        /// <summary>
        /// Glyphs info data
        /// </summary>
        public IntPtr glyphs;
    }

    /// <summary>
    /// Camera3D, defines position/orientation in 3d space
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Camera3D
    {
        /// <summary>
        /// Camera position
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// Camera target it looks-at
        /// </summary>
        public Vector3 target;

        /// <summary>
        /// Camera up vector (rotation over its axis)
        /// </summary>
        public Vector3 up;

        /// <summary>
        /// Camera field-of-view apperture in Y (degrees) in perspective, used as near plane width in orthographic
        /// </summary>
        public float fovy;

        /// <summary>
        /// Camera type, defines projection type: CAMERA_PERSPECTIVE or CAMERA_ORTHOGRAPHIC
        /// </summary>
        public CameraProjection projection;

        public Camera3D(Vector3 position, Vector3 target, Vector3 up, float fovy, CameraProjection projection)
        {
            this.position = position;
            this.target = target;
            this.up = up;
            this.fovy = fovy;
            this.projection = projection;
        }
    }

    /// <summary>Camera2D, defines position/orientation in 2d space</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Camera2D
    {
        /// <summary>
        /// Camera offset (displacement from target)
        /// </summary>
        public Vector2 offset;

        /// <summary>
        /// Camera target (rotation and zoom origin)
        /// </summary>
        public Vector2 target;

        /// <summary>
        ///  Camera rotation in degrees
        /// </summary>
        public float rotation;

        /// <summary>
        /// Camera zoom (scaling), should be 1.0f by default
        /// </summary>
        public float zoom;

        public Camera2D(Vector2 offset, Vector2 target, float rotation, float zoom)
        {
            this.offset = offset;
            this.target = target;
            this.rotation = rotation;
            this.zoom = zoom;
        }
    }

    /// <summary>
    /// Vertex data definning a mesh
    /// NOTE: Data stored in CPU memory (and GPU)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Mesh
    {
        /// <summary>
        ///  Number of vertices stored in arrays
        /// </summary>
        public int vertexCount;

        /// <summary>
        /// Number of triangles stored (indexed or not)
        /// </summary>
        public int triangleCount;

        #region Default vertex data

        /// <summary>
        /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0, float *)
        /// </summary>
        public IntPtr vertices;

        /// <summary>
        /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1, float *)
        /// </summary>
        public IntPtr texcoords;

        /// <summary>
        /// Vertex second texture coordinates (useful for lightmaps) (shader-location = 5, float *)
        /// </summary>
        public IntPtr texcoords2;

        /// <summary>
        /// Vertex normals (XYZ - 3 components per vertex) (shader-location = 2, float *)
        /// </summary>
        public IntPtr normals;

        /// <summary>
        /// Vertex tangents (XYZW - 4 components per vertex) (shader-location = 4, float *)
        /// </summary>
        public IntPtr tangents;

        /// <summary>
        /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3,  unsigned char *)
        /// </summary>
        public IntPtr colors;

        /// <summary>
        /// Vertex indices (in case vertex data comes indexed, unsigned short *)
        /// </summary>
        public IntPtr indices;

        #endregion

        #region Animation vertex data

        /// <summary>
        /// Animated vertex positions (after bones transformations, float *)
        /// </summary>
        public IntPtr animVertices;

        /// <summary>
        /// Animated normals (after bones transformations, float *)
        /// </summary>
        public IntPtr animNormals;

        /// <summary>
        /// Vertex bone ids, up to 4 bones influence by vertex (skinning, int *)
        /// </summary>
        public IntPtr boneIds;

        /// <summary>
        /// Vertex bone weight, up to 4 bones influence by vertex (skinning, float *)
        /// </summary>
        public IntPtr boneWeights;

        #endregion

        #region OpenGL identifiers

        /// <summary>
        /// OpenGL Vertex Array Object id
        /// </summary>
        public uint vaoId;

        /// <summary>
        /// OpenGL Vertex Buffer Objects id (default vertex data, uint[])
        /// </summary>
        public IntPtr vboId;

        #endregion
    }

    /// <summary>
    /// Shader type (generic)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Shader
    {
        /// <summary>
        /// Shader program id
        /// </summary>
        public uint id;

        /// <summary>
        /// Shader locations array (MAX_SHADER_LOCATIONS,  int *)
        /// </summary>
        public IntPtr locs;
    }

    /// <summary>
    /// Material texture map
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MaterialMap
    {
        /// <summary>
        /// Material map texture
        /// </summary>
        public Texture2D texture;

        /// <summary>
        /// Material map color
        /// </summary>
        public Color color;

        /// <summary>
        /// Material map value
        /// </summary>
        public float value;
    }

    /// <summary>
    /// Material type (generic)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Material
    {
        /// <summary>
        /// Material shader
        /// </summary>
        public Shader shader;

        /// <summary>
        /// Material maps (MaterialMap *)
        /// </summary>
        public IntPtr maps;

        /// <summary>
        /// Material generic parameters (if required, float *)
        /// </summary>
        public IntPtr param;
    }

    /// <summary>
    /// Transform, vectex transformation data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Transform
    {
        /// <summary>
        /// Translation
        /// </summary>
        public Vector3 translation;

        /// <summary>
        /// Rotation
        /// </summary>
        public Vector4 rotation;

        /// <summary>
        /// Scale
        /// </summary>
        public Vector3 scale;
    }

    /// <summary>
    /// Bone information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BoneInfo
    {
        /// <summary>
        /// Bone name (char[32])
        /// </summary>
        public IntPtr name;

        /// <summary>
        /// Bone parent
        /// </summary>
        public int parent;
    }

    /// <summary>
    /// Model type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Model
    {
        /// <summary>
        /// Local transform matrix
        /// </summary>
        public Matrix4x4 transform;

        /// <summary>
        /// Number of meshes
        /// </summary>
        public int meshCount;

        /// <summary>
        /// Number of materials
        /// </summary>
        public int materialCount;

        /// <summary>
        /// Meshes array (Mesh *)
        /// </summary>
        public IntPtr meshes;

        /// <summary>
        /// Materials array (Material *)
        /// </summary>
        public IntPtr materials;

        /// <summary>
        /// Mesh material number (int *)
        /// </summary>
        public IntPtr meshMaterial;

        /// <summary>
        /// Number of bones
        /// </summary>
        public int boneCount;

        /// <summary>
        /// Bones information (skeleton, BoneInfo *)
        /// </summary>
        public IntPtr bones;

        /// <summary>
        /// Bones base transformation (pose, Transform *)
        /// </summary>
        public IntPtr bindPose;
    }

    /// <summary>Model animation</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ModelAnimation
    {
        /// <summary>
        /// Number of bones
        /// </summary>
        public int boneCount;

        /// <summary>
        /// Number of animation frames
        /// </summary>
        public int frameCount;

        /// <summary>
        /// Bones information (skeleton, BoneInfo *)
        /// </summary>
        public IntPtr bones;

        /// <summary>
        /// Poses array by frame (Transform **)
        /// </summary>
        public IntPtr framePoses;
    }

    /// <summary>Ray, ray for raycasting</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Ray
    {
        /// <summary>
        /// Ray position (origin)
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// Ray direction
        /// </summary>
        public Vector3 direction;

        public Ray(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }

    /// <summary>Raycast hit information</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RayHitInfo
    {
        /// <summary>
        /// Did the ray hit something?
        /// </summary>
        public byte hit;

        /// <summary>
        /// Distance to nearest hit
        /// </summary>
        public float distance;

        /// <summary>
        /// Position of nearest hit
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// Surface normal of hit
        /// </summary>
        public Vector3 normal;
    }

    /// <summary>Bounding box type</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox
    {
        /// <summary>
        /// Minimum vertex box-corner
        /// </summary>
        public Vector3 min;

        /// <summary>
        /// Maximum vertex box-corner
        /// </summary>
        public Vector3 max;

        public BoundingBox(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }
    }

    /// <summary>Wave type, defines audio wave data</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Wave
    {
        /// <summary>
        /// Number of samples
        /// </summary>
        public uint sampleCount;

        /// <summary>
        /// Frequency (samples per second)
        /// </summary>
        public uint sampleRate;

        /// <summary>
        /// Bit depth (bits per sample): 8, 16, 32 (24 not supported)
        /// </summary>
        public uint sampleSize;

        /// <summary>
        /// Number of channels (1-mono, 2-stereo)
        /// </summary>
        public uint channels;

        /// <summary>
        /// Buffer data pointer (void *)
        /// </summary>
        public IntPtr data;
    }

    /// <summary>Audio stream type
    /// NOTE: Useful to create custom audio streams not bound to a specific file</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioStream
    {
        /// <summary>
        /// Pointer to internal data(rAudioBuffer *) used by the audio system
        /// </summary>
        public IntPtr audioBuffer;

        /// <summary>
        /// Frequency (samples per second)
        /// </summary>
        public uint sampleRate;

        /// <summary>
        /// Bit depth (bits per sample): 8, 16, 32 (24 not supported)
        /// </summary>
        public uint sampleSize;

        /// <summary>
        /// Number of channels (1-mono, 2-stereo)
        /// </summary>
        public uint channels;
    }

    /// <summary>Sound source type</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Sound
    {
        /// <summary>
        /// Audio stream
        /// </summary>
        public AudioStream stream;

        /// <summary>
        /// Total number of frames (considering channels)
        /// </summary>
        public uint frameCount;
    }

    /// <summary>Music stream type (audio file streaming from memory)
    /// NOTE: Anything longer than ~10 seconds should be streamed</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Music
    {
        /// <summary>
        /// Audio stream
        /// </summary>
        public AudioStream stream;

        /// <summary>
        /// Total number of samples
        /// </summary>
        public uint frameCount;

        /// <summary>
        /// Music looping enable
        /// </summary>
        public byte looping;

        /// <summary>
        /// Type of music context (audio filetype)
        /// </summary>
        public int ctxType;

        /// <summary>
        /// Audio context data, depends on type (void *)
        /// </summary>
        public IntPtr ctxData;
    }

    /// <summary>Head-Mounted-Display device parameters</summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VrDeviceInfo
    {
        /// <summary>
        /// HMD horizontal resolution in pixels
        /// </summary>
        public int hResolution;

        /// <summary>
        /// HMD vertical resolution in pixels
        /// </summary>
        public int vResolution;

        /// <summary>
        /// HMD horizontal size in meters
        /// </summary>
        public float hScreenSize;

        /// <summary>
        /// HMD vertical size in meters
        /// </summary>
        public float vScreenSize;

        /// <summary>
        /// HMD screen center in meters
        /// </summary>
        public float vScreenCenter;

        /// <summary>
        /// HMD distance between eye and display in meters
        /// </summary>
        public float eyeToScreenDistance;

        /// <summary>
        /// HMD lens separation distance in meters
        /// </summary>
        public float lensSeparationDistance;

        /// <summary>
        /// HMD IPD (distance between pupils) in meters
        /// </summary>
        public float interpupillaryDistance;

        /// <summary>
        /// HMD lens distortion constant parameters
        /// </summary>
        public fixed float lensDistortionValues[4];

        /// <summary>
        /// HMD chromatic aberration correction parameters
        /// </summary>
        public fixed float chromaAbCorrection[4];
    }

    /// <summary>VR Stereo rendering configuration for simulator</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VrStereoConfig
    {
        /// <summary>
        /// VR projection matrices (per eye)
        /// </summary>
        public Matrix4x4 projection1;

        /// <summary>
        /// VR projection matrices (per eye)
        /// </summary>
        public Matrix4x4 projection2;

        /// <summary>
        /// VR view offset matrices (per eye)
        /// </summary>
        public Matrix4x4 viewOffset1;

        /// <summary>
        /// VR view offset matrices (per eye)
        /// </summary>
        public Matrix4x4 viewOffset2;

        /// <summary>
        /// VR left lens center
        /// </summary>
        public Vector2 leftLensCenter;

        /// <summary>
        /// VR right lens center
        /// </summary>
        public Vector2 rightLensCenter;

        /// <summary>
        /// VR left screen center
        /// </summary>
        public Vector2 leftScreenCenter;

        /// <summary>
        /// VR right screen center
        /// </summary>
        public Vector2 rightScreenCenter;

        /// <summary>
        /// VR distortion scale
        /// </summary>
        public Vector2 scale;

        /// <summary>
        /// VR distortion scale in
        /// </summary>
        public Vector2 scaleIn;
    }

    /// <summary>System config flags
    /// NOTE: Every bit registers one state (use it with bit masks)
    /// By default all flags are set to 0</summary>
    [Flags]
    public enum ConfigFlags
    {
        /// <summary>
        /// Set to try enabling V-Sync on GPU
        /// </summary>
        FLAG_VSYNC_HINT = 0x00000040,

        /// <summary>
        /// Set to run program in fullscreen
        /// </summary>
        FLAG_FULLSCREEN_MODE = 0x00000002,

        /// <summary>
        /// Set to allow resizable window
        /// </summary>
        FLAG_WINDOW_RESIZABLE = 0x00000004,

        /// <summary>
        /// Set to disable window decoration (frame and buttons)
        /// </summary>
        FLAG_WINDOW_UNDECORATED = 0x00000008,

        /// <summary>
        /// Set to hide window
        /// </summary>
        FLAG_WINDOW_HIDDEN = 0x00000080,

        /// <summary>
        /// Set to minimize window (iconify)
        /// </summary>
        FLAG_WINDOW_MINIMIZED = 0x00000200,

        /// <summary>
        /// Set to maximize window (expanded to monitor)
        /// </summary>
        FLAG_WINDOW_MAXIMIZED = 0x00000400,

        /// <summary>
        /// Set to window non focused
        /// </summary>
        FLAG_WINDOW_UNFOCUSED = 0x00000800,

        /// <summary>
        /// Set to window always on top
        /// </summary>
        FLAG_WINDOW_TOPMOST = 0x00001000,

        /// <summary>
        /// Set to allow windows running while minimized
        /// </summary>
        FLAG_WINDOW_ALWAYS_RUN = 0x00000100,

        /// <summary>
        /// Set to allow transparent framebuffer
        /// </summary>
        FLAG_WINDOW_TRANSPARENT = 0x00000010,

        /// <summary>
        /// Set to support HighDPI
        /// </summary>
        FLAG_WINDOW_HIGHDPI = 0x00002000,

        /// <summary>
        /// Set to try enabling MSAA 4X
        /// </summary>
        FLAG_MSAA_4X_HINT = 0x00000020,

        /// <summary>
        /// Set to try enabling interlaced video format (for V3D)
        /// </summary>
        FLAG_INTERLACED_HINT = 0x00010000,
    }

    /// <summary>Trace log level
    /// NOTE: Organized by priority level</summary>
    public enum TraceLogLevel
    {
        /// <summary>
        /// Display all logs
        /// </summary>
        LOG_ALL = 0,

        /// <summary>
        /// Trace logging, intended for internal use only
        /// </summary>
        LOG_TRACE,

        /// <summary>
        /// Debug logging, used for internal debugging, it should be disabled on release builds
        /// </summary>
        LOG_DEBUG,

        /// <summary>
        /// Info logging, used for program execution info
        /// </summary>
        LOG_INFO,

        /// <summary>
        /// Warning logging, used on recoverable failures
        /// </summary>
        LOG_WARNING,

        /// <summary>
        /// Error logging, used on unrecoverable failures
        /// </summary>
        LOG_ERROR,

        /// <summary>
        /// Fatal logging, used to abort program: exit(EXIT_FAILURE)
        /// </summary>
        LOG_FATAL,

        /// <summary>
        /// Disable logging
        /// </summary>
        LOG_NONE
    }

    /// <summary>Keyboard keys (US keyboard layout)
    /// NOTE: Use GetKeyPressed() to allow redefining
    /// required keys for alternative layouts</summary>
    public enum KeyboardKey
    {
        /// <summary>
        /// NULL, used for no key pressed
        /// </summary>
        KEY_NULL = 0,

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
        KEY_KP_EQUAL = 336,

        // Android key buttons
        KEY_BACK = 4,
        KEY_MENU = 82,
        KEY_VOLUME_UP = 24,
        KEY_VOLUME_DOWN = 25
    }

    /// <summary>Mouse buttons</summary>
    public enum MouseButton
    {
        /// <summary>
        /// Mouse button left
        /// </summary>
        MOUSE_BUTTON_LEFT = 0,

        /// <summary>
        /// Mouse button right
        /// </summary>
        MOUSE_BUTTON_RIGHT = 1,

        /// <summary>
        /// Mouse button middle (pressed wheel)
        /// </summary>
        MOUSE_BUTTON_MIDDLE = 2,

        /// <summary>
        /// Mouse button side (advanced mouse device)
        /// </summary>
        MOUSE_BUTTON_SIDE = 3,

        /// <summary>
        /// Mouse button extra (advanced mouse device)
        /// </summary>
        MOUSE_BUTTON_EXTRA = 4,

        /// <summary>
        /// Mouse button fordward (advanced mouse device)
        /// </summary>
        MOUSE_BUTTON_FORWARD = 5,

        /// <summary>
        /// Mouse button back (advanced mouse device)
        /// </summary>
        MOUSE_BUTTON_BACK = 6,
    }

    /// <summary>Mouse cursor</summary>
    public enum MouseCursor
    {
        /// <summary>
        /// Default pointer shape
        /// </summary>
        MOUSE_CURSOR_DEFAULT = 0,

        /// <summary>
        /// Arrow shape
        /// </summary>
        MOUSE_CURSOR_ARROW = 1,

        /// <summary>
        /// Text writing cursor shape
        /// </summary>
        MOUSE_CURSOR_IBEAM = 2,

        /// <summary>
        /// Cross shape
        /// </summary>
        MOUSE_CURSOR_CROSSHAIR = 3,

        /// <summary>
        /// Pointing hand cursor
        /// </summary>
        MOUSE_CURSOR_POINTING_HAND = 4,

        /// <summary>
        /// Horizontal resize/move arrow shape
        /// </summary>
        MOUSE_CURSOR_RESIZE_EW = 5,

        /// <summary>
        /// Vertical resize/move arrow shape
        /// </summary>
        MOUSE_CURSOR_RESIZE_NS = 6,

        /// <summary>
        /// Top-left to bottom-right diagonal resize/move arrow shape
        /// </summary>
        MOUSE_CURSOR_RESIZE_NWSE = 7,

        /// <summary>
        /// The top-right to bottom-left diagonal resize/move arrow shape
        /// </summary>
        MOUSE_CURSOR_RESIZE_NESW = 8,

        /// <summary>
        /// The omni-directional resize/move cursor shape
        /// </summary>
        MOUSE_CURSOR_RESIZE_ALL = 9,

        /// <summary>
        /// The operation-not-allowed shape
        /// </summary>
        MOUSE_CURSOR_NOT_ALLOWED = 10
    }

    /// <summary>Gamepad buttons</summary>
    public enum GamepadButton
    {
        /// <summary>
        /// This is here just for error checking
        /// </summary>
        GAMEPAD_BUTTON_UNKNOWN = 0,

        /// <summary>
        /// Gamepad left DPAD up button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_UP,

        /// <summary>
        /// Gamepad left DPAD right button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_RIGHT,

        /// <summary>
        /// Gamepad left DPAD down button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_DOWN,

        /// <summary>
        /// Gamepad left DPAD left button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_LEFT,

        /// <summary>
        /// Gamepad right button up (i.e. PS3: Triangle, Xbox: Y)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_UP,

        /// <summary>
        /// Gamepad right button right (i.e. PS3: Square, Xbox: X)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_RIGHT,

        /// <summary>
        /// Gamepad right button down (i.e. PS3: Cross, Xbox: A)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_DOWN,

        /// <summary>
        /// Gamepad right button left (i.e. PS3: Circle, Xbox: B)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_LEFT,

        // Triggers
        GAMEPAD_BUTTON_LEFT_TRIGGER_1,
        GAMEPAD_BUTTON_LEFT_TRIGGER_2,
        GAMEPAD_BUTTON_RIGHT_TRIGGER_1,
        GAMEPAD_BUTTON_RIGHT_TRIGGER_2,

        // These are buttons in the center of the gamepad

        /// <summary>
        /// PS3 Select
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE_LEFT,

        /// <summary>
        /// PS Button/XBOX Button
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE,

        /// <summary>
        /// PS3 Start
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE_RIGHT,

        /// <summary>
        /// Left joystick press button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_THUMB,

        /// <summary>
        /// Right joystick press button
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_THUMB
    }

    /// <summary>Gamepad axis</summary>
    public enum GamepadAxis
    {
        /// <summary>
        /// Gamepad left stick X axis
        /// </summary>
        GAMEPAD_AXIS_LEFT_X = 0,

        /// <summary>
        /// Gamepad left stick Y axis
        /// </summary>
        GAMEPAD_AXIS_LEFT_Y = 1,

        /// <summary>
        /// Gamepad right stick X axis
        /// </summary>
        GAMEPAD_AXIS_RIGHT_X = 2,

        /// <summary>
        /// Gamepad right stick Y axis
        /// </summary>
        GAMEPAD_AXIS_RIGHT_Y = 3,

        /// <summary>
        /// Gamepad back trigger left, pressure level: [1..-1]
        /// </summary>
        GAMEPAD_AXIS_LEFT_TRIGGER = 4,

        /// <summary>
        /// Gamepad back trigger right, pressure level: [1..-1]
        /// </summary>
        GAMEPAD_AXIS_RIGHT_TRIGGER = 5
    }

    /// <summary>Material map index</summary>
    public enum MaterialMapIndex
    {
        /// <summary>
        /// MAP_DIFFUSE
        /// </summary>
        MATERIAL_MAP_ALBEDO = 0,

        /// <summary>
        /// MAP_SPECULAR
        /// </summary>
        MATERIAL_MAP_METALNESS = 1,

        MATERIAL_MAP_NORMAL = 2,
        MATERIAL_MAP_ROUGHNESS = 3,
        MATERIAL_MAP_OCCLUSION,
        MATERIAL_MAP_EMISSION,
        MATERIAL_MAP_HEIGHT,

        /// <summary>
        /// NOTE: Uses GL_TEXTURE_CUBE_MAP
        /// </summary>
        MATERIAL_MAP_CUBEMAP,

        /// <summary>
        /// NOTE: Uses GL_TEXTURE_CUBE_MAP
        /// </summary>
        MATERIAL_MAP_IRRADIANCE,

        /// <summary>
        /// NOTE: Uses GL_TEXTURE_CUBE_MAP
        /// </summary>
        MATERIAL_MAP_PREFILTER,

        MATERIAL_MAP_BRDF,

        MATERIAL_MAP_DIFFUSE = MATERIAL_MAP_ALBEDO,
        MATERIAL_MAP_SPECULAR = MATERIAL_MAP_METALNESS,
    }

    /// <summary>Shader location index</summary>
    public enum ShaderLocationIndex
    {
        SHADER_LOC_VERTEX_POSITION = 0,
        SHADER_LOC_VERTEX_TEXCOORD01,
        SHADER_LOC_VERTEX_TEXCOORD02,
        SHADER_LOC_VERTEX_NORMAL,
        SHADER_LOC_VERTEX_TANGENT,
        SHADER_LOC_VERTEX_COLOR,
        SHADER_LOC_MATRIX_MVP,
        SHADER_LOC_MATRIX_VIEW,
        SHADER_LOC_MATRIX_PROJECTION,
        SHADER_LOC_MATRIX_MODEL,
        SHADER_LOC_MATRIX_NORMAL,
        SHADER_LOC_VECTOR_VIEW,
        SHADER_LOC_COLOR_DIFFUSE,
        SHADER_LOC_COLOR_SPECULAR,
        SHADER_LOC_COLOR_AMBIENT,
        SHADER_LOC_MAP_ALBEDO,
        SHADER_LOC_MAP_METALNESS,
        SHADER_LOC_MAP_NORMAL,
        SHADER_LOC_MAP_ROUGHNESS,
        SHADER_LOC_MAP_OCCLUSION,
        SHADER_LOC_MAP_EMISSION,
        SHADER_LOC_MAP_HEIGHT,
        SHADER_LOC_MAP_CUBEMAP,
        SHADER_LOC_MAP_IRRADIANCE,
        SHADER_LOC_MAP_PREFILTER,
        SHADER_LOC_MAP_BRDF,

        SHADER_LOC_MAP_DIFFUSE = SHADER_LOC_MAP_ALBEDO,
        SHADER_LOC_MAP_SPECULAR = SHADER_LOC_MAP_METALNESS,
    }

    /// <summary>Shader uniform data type</summary>
    public enum ShaderUniformDataType
    {
        SHADER_UNIFORM_FLOAT = 0,
        SHADER_UNIFORM_VEC2,
        SHADER_UNIFORM_VEC3,
        SHADER_UNIFORM_VEC4,
        SHADER_UNIFORM_INT,
        SHADER_UNIFORM_IVEC2,
        SHADER_UNIFORM_IVEC3,
        SHADER_UNIFORM_IVEC4,
        SHADER_UNIFORM_SAMPLER2D
    }

    // Shader attribute data types
    public enum ShaderAttributeDataType
    {
        SHADER_ATTRIB_FLOAT = 0,
        SHADER_ATTRIB_VEC2,
        SHADER_ATTRIB_VEC3,
        SHADER_ATTRIB_VEC4
    }

    /// <summary>Pixel formats
    /// NOTE: Support depends on OpenGL version and platform</summary>
    public enum PixelFormat
    {
        /// <summary>
        /// 8 bit per pixel (no alpha)
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_GRAYSCALE = 1,

        /// <summary>
        /// 8*2 bpp (2 channels)
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_GRAY_ALPHA,

        /// <summary>
        /// 16 bpp
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R5G6B5,

        /// <summary>
        /// 24 bpp
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R8G8B8,

        /// <summary>
        /// 16 bpp (1 bit alpha)
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R5G5B5A1,

        /// <summary>
        /// 16 bpp (4 bit alpha)
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R4G4B4A4,

        /// <summary>
        /// 32 bpp
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R8G8B8A8,

        /// <summary>
        /// 32 bpp (1 channel - float)
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R32,

        /// <summary>
        /// 32*3 bpp (3 channels - float)
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R32G32B32,

        /// <summary>
        /// 32*4 bpp (4 channels - float)
        /// </summary>
        PIXELFORMAT_UNCOMPRESSED_R32G32B32A32,

        /// <summary>
        /// 4 bpp (no alpha)
        /// </summary>
        PIXELFORMAT_COMPRESSED_DXT1_RGB,

        /// <summary>
        /// 4 bpp (1 bit alpha)
        /// </summary>
        PIXELFORMAT_COMPRESSED_DXT1_RGBA,

        /// <summary>
        /// 8 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_DXT3_RGBA,

        /// <summary>
        /// 8 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_DXT5_RGBA,

        /// <summary>
        /// 4 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_ETC1_RGB,

        /// <summary>
        /// 4 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_ETC2_RGB,

        /// <summary>
        /// 8 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_ETC2_EAC_RGBA,

        /// <summary>
        /// 4 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_PVRT_RGB,

        /// <summary>
        /// 4 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_PVRT_RGBA,

        /// <summary>
        /// 8 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_ASTC_4x4_RGBA,

        /// <summary>
        /// 2 bpp
        /// </summary>
        PIXELFORMAT_COMPRESSED_ASTC_8x8_RGBA
    }

    /// <summary>Texture parameters: filter mode
    /// NOTE 1: Filtering considers mipmaps if available in the texture
    /// NOTE 2: Filter is accordingly set for minification and magnification</summary>
    public enum TextureFilter
    {
        /// <summary>
        /// No filter, just pixel aproximation
        /// </summary>
        TEXTURE_FILTER_POINT = 0,

        /// <summary>
        /// Linear filtering
        /// </summary>
        TEXTURE_FILTER_BILINEAR,

        /// <summary>
        /// Trilinear filtering (linear with mipmaps)
        /// </summary>
        TEXTURE_FILTER_TRILINEAR,

        /// <summary>
        /// Anisotropic filtering 4x
        /// </summary>
        TEXTURE_FILTER_ANISOTROPIC_4X,

        /// <summary>
        /// Anisotropic filtering 8x
        /// </summary>
        TEXTURE_FILTER_ANISOTROPIC_8X,

        /// <summary>
        /// Anisotropic filtering 16x
        /// </summary>
        TEXTURE_FILTER_ANISOTROPIC_16X,
    }

    /// <summary>Texture parameters: wrap mode</summary>
    public enum TextureWrap
    {
        /// <summary>
        /// Repeats texture in tiled mode
        /// </summary>
        TEXTURE_WRAP_REPEAT = 0,

        /// <summary>
        /// Clamps texture to edge pixel in tiled mode
        /// </summary>
        TEXTURE_WRAP_CLAMP,

        /// <summary>
        /// Mirrors and repeats the texture in tiled mode
        /// </summary>
        TEXTURE_WRAP_MIRROR_REPEAT,

        /// <summary>
        /// Mirrors and clamps to border the texture in tiled mode
        /// </summary>
        TEXTURE_WRAP_MIRROR_CLAMP
    }

    /// <summary>Cubemap layouts</summary>
    public enum CubemapLayout
    {
        /// <summary>
        /// Automatically detect layout type
        /// </summary>
        CUBEMAP_LAYOUT_AUTO_DETECT = 0,

        /// <summary>
        /// Layout is defined by a vertical line with faces
        /// </summary>
        CUBEMAP_LAYOUT_LINE_VERTICAL,

        /// <summary>
        /// Layout is defined by an horizontal line with faces
        /// </summary>
        CUBEMAP_LAYOUT_LINE_HORIZONTAL,

        /// <summary>
        /// Layout is defined by a 3x4 cross with cubemap faces
        /// </summary>
        CUBEMAP_LAYOUT_CROSS_THREE_BY_FOUR,

        /// <summary>
        /// Layout is defined by a 4x3 cross with cubemap faces
        /// </summary>
        CUBEMAP_LAYOUT_CROSS_FOUR_BY_THREE,

        /// <summary>
        /// Layout is defined by a panorama image (equirectangular map)
        /// </summary>
        CUBEMAP_LAYOUT_PANORAMA
    }

    /// <summary>Font type, defines generation method</summary>
    public enum FontType
    {
        /// <summary>
        /// Default font generation, anti-aliased
        /// </summary>
        FONT_DEFAULT = 0,

        /// <summary>
        /// Bitmap font generation, no anti-aliasing
        /// </summary>
        FONT_BITMAP,

        /// <summary>
        /// SDF font generation, requires external shader
        /// </summary>
        FONT_SDF
    }

    /// <summary>Color blending modes (pre-defined)</summary>
    public enum BlendMode
    {
        /// <summary>
        /// Blend textures considering alpha (default)
        /// </summary>
        BLEND_ALPHA = 0,

        /// <summary>
        /// Blend textures adding colors
        /// </summary>
        BLEND_ADDITIVE,

        /// <summary>
        /// Blend textures multiplying colors
        /// </summary>
        BLEND_MULTIPLIED,

        /// <summary>
        /// Blend textures adding colors (alternative)
        /// </summary>
        BLEND_ADD_COLORS,

        /// <summary>
        /// Blend textures subtracting colors (alternative)
        /// </summary>
        BLEND_SUBTRACT_COLORS,

        /// <summary>
        /// Blend textures using custom src/dst factors (use rlSetBlendMode())
        /// </summary>
        BLEND_CUSTOM
    }

    /// <summary>Gestures
    /// NOTE: It could be used as flags to enable only some gestures</summary>
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

    /// <summary>Camera system modes</summary>
    public enum CameraMode
    {
        CAMERA_CUSTOM = 0,
        CAMERA_FREE,
        CAMERA_ORBITAL,
        CAMERA_FIRST_PERSON,
        CAMERA_THIRD_PERSON
    }

    /// <summary>Camera projection</summary>
    public enum CameraProjection
    {
        CAMERA_PERSPECTIVE = 0,
        CAMERA_ORTHOGRAPHIC
    }

    /// <summary>N-patch layout</summary>
    public enum NPatchLayout
    {
        /// <summary>
        /// Npatch defined by 3x3 tiles
        /// </summary>
        NPATCH_NINE_PATCH = 0,

        /// <summary>
        /// Npatch defined by 1x3 tiles
        /// </summary>
        NPATCH_THREE_PATCH_VERTICAL,

        /// <summary>
        /// Npatch defined by 3x1 tiles
        /// </summary>
        NPATCH_THREE_PATCH_HORIZONTAL
    }

    [SuppressUnmanagedCodeSecurity]
    public static class Raylib
    {
        // Used by DllImport to load the native library.
        public const string nativeLibName = "raylib";

        public const string RAYLIB_VERSION = "3.7";

        public const float DEG2RAD = MathF.PI / 180.0f;
        public const float RAD2DEG = 180.0f / MathF.PI;

        public const int MAX_SHADER_LOCATIONS = 32;
        public const int MAX_MATERIAL_MAPS = 12;
        public const int MAX_TOUCH_POINTS = 10;

        // Callbacks to hook some internal functions
        // WARNING: This callbacks are intended for advance users

        // Logging: Redirect trace log messages
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void TraceLogCallback(TraceLogLevel logLevel, string text, IntPtr args);

        // FileIO: Load binary data
        // IntPtr refers to a unsigned char *
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr LoadFileDataCallback(string fileName, ref int bytesRead);

        // FileIO: Save binary data
        // IntPtr refers to a void *
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool SaveFileDataCallback(string fileName, IntPtr data, ref int bytesToWrite);

        // FileIO: Load text data
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate string LoadFileTextCallback(string fileName);

        // FileIO: Save text data
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool SaveFileTextCallback(string fileName, string text);

        // Returns color with alpha applied, alpha goes from 0.0f to 1.0f
        // NOTE: Added for compatability with previous versions
        public static Color Fade(Color color, float alpha) => ColorAlpha(color, alpha);


        //------------------------------------------------------------------------------------
        // Window and Graphics Device Functions (Module: core)
        //------------------------------------------------------------------------------------

        // Window-related functions

        /// <summary>Initialize window and OpenGL context</summary>
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

        /// <summary>Set shader uniform value
        /// value refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValue(Shader shader, int uniformLoc, ref int value, ShaderUniformDataType uniformType);

        /// <summary>Set shader uniform value
        /// value refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValue(Shader shader, int uniformLoc, ref float value, ShaderUniformDataType uniformType);

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
        public static extern IntPtr GetDroppedFiles(ref int count);

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

        /// <summary>Check gamepad name (if available)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGamepadName(int gamepad, string name);

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

        //------------------------------------------------------------------------------------
        // Gestures and Touch Handling Functions (Module: gestures)
        //------------------------------------------------------------------------------------

        /// <summary>Enable a set of gestures using flags</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGesturesEnabled(Gestures flags);

        /// <summary>Check if a gesture have been detected</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsGestureDetected(Gestures gesture);

        /// <summary>Get latest detected gesture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Gestures GetGestureDetected();

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

        /// <summary>Generate image: perlin noise</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImagePerlinNoise(int width, int height, int offsetX, int offsetY, float scale);

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

        /// <summary>Get pixel data from GPU texture and return an Image</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GetTextureData(Texture2D texture);

        /// <summary>Get pixel data from screen buffer and return an Image (screenshot)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GetScreenData();


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
        public static extern void DrawTextureRec(Texture2D texture, Rectangle sourceRec, Vector2 position, Color tint);

        /// <summary>Draw texture quad with tiling and offset parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureQuad(Texture2D texture, Vector2 tiling, Vector2 offset, Rectangle quad, Color tint);

        /// <summary>Draw part of a texture (defined by a rectangle) with rotation and scale tiled into dest.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureTiled(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, float scale, Color tint);

        /// <summary>Draw a part of a texture defined by a rectangle with 'pro' parameters</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexturePro(Texture2D texture, Rectangle sourceRec, Rectangle destRec, Vector2 origin, float rotation, Color tint);

        /// <summary>Draws a texture (or part of it) that stretches or shrinks nicely</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureNPatch(Texture2D texture, NPatchInfo nPatchInfo, Rectangle destRec, Vector2 origin, float rotation, Color tint);

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
        public static extern void SetPixelColor(IntPtr srcPtr, Color color, PixelFormat format);

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
        /// IntPtr refers to CharInfo *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadFontData(IntPtr fileData, int dataSize, int fontSize, int[] fontChars, int charsCount, FontType type);

        /// <summary>Generate image font atlas using chars info</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageFontAtlas(IntPtr chars, ref IntPtr recs, int charsCount, int fontSize, int padding, int packMethod);

        /// <summary>Unload font chars info data (RAM)
        /// chars refers to CharInfo *</summary>
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

        /// <summary>Draw text using font inside rectangle limits</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextRec(Font font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint);

        /// <summary>Draw text using font inside rectangle limits with support for text selection</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextRecEx(Font font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectText, Color selectBack);

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

        /// <summary>Get index position for a unicode character on font</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGlyphIndex(Font font, int character);

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

        /// <summary>Draw a cylinder/cone wires</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);

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


        // Mesh loading/unloading functions

        /// <summary>Upload vertex data into GPU and provided VAO/VBO ids</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UploadMesh(ref Mesh mesh, bool dynamic);

        /// <summary>Update mesh vertex data in GPU for a specific buffer index</summary>
        /// <summary>data refers to a void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMeshBuffer(Mesh mesh, int index, IntPtr data, int dataSize, int offset);

        /// <summary>Draw a 3d mesh with material and transform</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawMesh(Mesh mesh, Material material, Matrix4x4 transform);

        /// <summary>Draw multiple mesh instances with material and different transforms</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawMeshInstanced(Mesh mesh, Material material, Matrix4x4[] transforms, int instances);

        /// <summary>Unload mesh from memory (RAM and/or VRAM)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMesh(ref Mesh mesh);

        /// <summary>Export mesh data to file, returns true on success</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ExportMesh(Mesh mesh, string fileName);


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


        // Mesh manipulation functions

        /// <summary>Compute mesh bounding box limits</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern BoundingBox MeshBoundingBox(Mesh mesh);

        /// <summary>Compute mesh tangents</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MeshTangents(ref Mesh mesh);

        /// <summary>Compute mesh binormals</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MeshBinormals(ref Mesh mesh);


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

        /// <summary>Draw a billboard texture defined by sourceRec</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboardRec(Camera3D camera, Texture2D texture, Rectangle sourceRec, Vector3 center, float size, Color tint);


        // Collision detection functions

        /// <summary>Detect collision between two spheres</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionSpheres(Vector3 centerA, float radiusA, Vector3 centerB, float radiusB);

        /// <summary>Detect collision between two bounding boxes</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2);

        /// <summary>Detect collision between box and sphere</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionBoxSphere(BoundingBox box, Vector3 centerSphere, float radiusSphere);

        /// <summary>Detect collision between ray and sphere</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionRaySphere(Ray ray, Vector3 spherePosition, float sphereRadius);

        /// <summary>Detect collision between ray and sphere, returns collision point</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionRaySphereEx(Ray ray, Vector3 spherePosition, float sphereRadius, ref Vector3 collisionPoint);

        /// <summary>Detect collision between ray and box</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CheckCollisionRayBox(Ray ray, BoundingBox box);

        /// <summary>Get collision info between ray and model</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayModel(Ray ray, Model model);

        /// <summary>Get collision info between ray and triangle</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3);

        /// <summary>Get collision info between ray and ground plane (Y-normal plane)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayGround(Ray ray, float groundHeight);


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

        /// <summary>Check if music is playing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsMusicPlaying(Music music);

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
        public static extern AudioStream InitAudioStream(uint sampleRate, uint sampleSize, uint channels);

        /// <summary>Update audio stream buffers with data
        /// data refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateAudioStream(AudioStream stream, IntPtr data, int samplesCount);

        /// <summary>Close audio stream and free memory</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioStream(AudioStream stream);

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
