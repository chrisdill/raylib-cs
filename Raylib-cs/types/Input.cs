using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Keyboard keys (US keyboard layout)<br/>
    /// NOTE: Use GetKeyPressed() to allow redefining required keys for alternative layouts
    /// </summary>
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

    /// <summary>
    /// Mouse buttons
    /// </summary>
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
        /// Mouse button forward (advanced mouse device)
        /// </summary>
        MOUSE_BUTTON_FORWARD = 5,

        /// <summary>
        /// Mouse button back (advanced mouse device)
        /// </summary>
        MOUSE_BUTTON_BACK = 6,

        MOUSE_LEFT_BUTTON = MOUSE_BUTTON_LEFT,
        MOUSE_RIGHT_BUTTON = MOUSE_BUTTON_RIGHT,
        MOUSE_MIDDLE_BUTTON = MOUSE_BUTTON_MIDDLE,
    }

    /// <summary>
    /// Mouse cursor
    /// </summary>
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

    /// <summary>
    /// Gamepad buttons
    /// </summary>
    public enum GamepadButton
    {
        /// <summary>
        /// Unknown button, just for error checking
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

        /// <summary>
        /// Gamepad top/back trigger left (first), it could be a trailing button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_TRIGGER_1,

        /// <summary>
        /// Gamepad top/back trigger left (second), it could be a trailing button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_TRIGGER_2,
        
        /// <summary>
        /// Gamepad top/back trigger right (first), it could be a trailing button
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_TRIGGER_1,
        
        /// <summary>
        /// Gamepad top/back trigger right (second), it could be a trailing button
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_TRIGGER_2,

        /// <summary>
        /// Gamepad center buttons, left one (i.e. PS3: Select)
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE_LEFT,

        /// <summary>
        /// Gamepad center buttons, middle one (i.e. PS3: PS, Xbox: XBOX)
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE,

        /// <summary>
        /// Gamepad center buttons, right one (i.e. PS3: Start)
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE_RIGHT,

        /// <summary>
        /// Gamepad joystick pressed button left
        /// </summary>
        GAMEPAD_BUTTON_LEFT_THUMB,

        /// <summary>
        /// Gamepad joystick pressed button right
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_THUMB
    }

    /// <summary>
    /// Gesture
    /// NOTE: It could be used as flags to enable only some gestures
    /// </summary>
    [Flags]
    public enum Gesture : uint
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

    /// <summary>
    /// Head-Mounted-Display device parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct VrDeviceInfo
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

    /// <summary>
    /// VR Stereo rendering configuration for simulator
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct VrStereoConfig
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
}
