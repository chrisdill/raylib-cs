using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs;

/// <summary>
/// Keyboard keys (US keyboard layout)<br/>
/// NOTE: Use GetKeyPressed() to allow redefining required keys for alternative layouts
/// </summary>
public enum KeyboardKey
{
    /// <summary>
    /// NULL, used for no key pressed
    /// </summary>
    Null = 0,

    // Alphanumeric keys
    Apostrophe = 39,
    Comma = 44,
    Minus = 45,
    Period = 46,
    Slash = 47,
    Zero = 48,
    One = 49,
    Two = 50,
    Three = 51,
    Four = 52,
    Five = 53,
    Six = 54,
    Seven = 55,
    Eight = 56,
    Nine = 57,
    Semicolon = 59,
    Equal = 61,
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

    // Function keys
    Space = 32,
    Escape = 256,
    Enter = 257,
    Tab = 258,
    Backspace = 259,
    Insert = 260,
    Delete = 261,
    Right = 262,
    Left = 263,
    Down = 264,
    Up = 265,
    PageUp = 266,
    PageDown = 267,
    Home = 268,
    End = 269,
    CapsLock = 280,
    ScrollLock = 281,
    NumLock = 282,
    PrintScreen = 283,
    Pause = 284,
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
    LeftShift = 340,
    LeftControl = 341,
    LeftAlt = 342,
    LeftSuper = 343,
    RightShift = 344,
    RightControl = 345,
    RightAlt = 346,
    RightSuper = 347,
    KeyboardMenu = 348,
    LeftBracket = 91,
    Backslash = 92,
    RightBracket = 93,
    Grave = 96,

    // Keypad keys
    Kp0 = 320,
    Kp1 = 321,
    Kp2 = 322,
    Kp3 = 323,
    Kp4 = 324,
    Kp5 = 325,
    Kp6 = 326,
    Kp7 = 327,
    Kp8 = 328,
    Kp9 = 329,
    KpDecimal = 330,
    KpDivide = 331,
    KpMultiply = 332,
    KpSubtract = 333,
    KpAdd = 334,
    KpEnter = 335,
    KpEqual = 336,

    // Android key buttons
    Back = 4,
    Menu = 82,
    VolumeUp = 24,
    VolumeDown = 25
}

/// <summary>
/// Mouse buttons
/// </summary>
public enum MouseButton
{
    /// <summary>
    /// Mouse button left
    /// </summary>
    Left = 0,

    /// <summary>
    /// Mouse button right
    /// </summary>
    Right = 1,

    /// <summary>
    /// Mouse button middle (pressed wheel)
    /// </summary>
    Middle = 2,

    /// <summary>
    /// Mouse button side (advanced mouse device)
    /// </summary>
    Side = 3,

    /// <summary>
    /// Mouse button extra (advanced mouse device)
    /// </summary>
    Extra = 4,

    /// <summary>
    /// Mouse button forward (advanced mouse device)
    /// </summary>
    Forward = 5,

    /// <summary>
    /// Mouse button back (advanced mouse device)
    /// </summary>
    Back = 6
}

/// <summary>
/// Mouse cursor
/// </summary>
public enum MouseCursor
{
    /// <summary>
    /// Default pointer shape
    /// </summary>
    Default = 0,

    /// <summary>
    /// Arrow shape
    /// </summary>
    Arrow = 1,

    /// <summary>
    /// Text writing cursor shape
    /// </summary>
    IBeam = 2,

    /// <summary>
    /// Cross shape
    /// </summary>
    Crosshair = 3,

    /// <summary>
    /// Pointing hand cursor
    /// </summary>
    PointingHand = 4,

    /// <summary>
    /// Horizontal resize/move arrow shape
    /// </summary>
    ResizeEw = 5,

    /// <summary>
    /// Vertical resize/move arrow shape
    /// </summary>
    ResizeNs = 6,

    /// <summary>
    /// Top-left to bottom-right diagonal resize/move arrow shape
    /// </summary>
    ResizeNwse = 7,

    /// <summary>
    /// The top-right to bottom-left diagonal resize/move arrow shape
    /// </summary>
    ResizeNesw = 8,

    /// <summary>
    /// The omnidirectional resize/move cursor shape
    /// </summary>
    ResizeAll = 9,

    /// <summary>
    /// The operation-not-allowed shape
    /// </summary>
    NotAllowed = 10
}

/// <summary>Gamepad axis</summary>
public enum GamepadAxis
{
    /// <summary>
    /// Gamepad left stick X axis
    /// </summary>
    LeftX = 0,

    /// <summary>
    /// Gamepad left stick Y axis
    /// </summary>
    LeftY = 1,

    /// <summary>
    /// Gamepad right stick X axis
    /// </summary>
    RightX = 2,

    /// <summary>
    /// Gamepad right stick Y axis
    /// </summary>
    RightY = 3,

    /// <summary>
    /// Gamepad back trigger left, pressure level: [1..-1]
    /// </summary>
    LeftTrigger = 4,

    /// <summary>
    /// Gamepad back trigger right, pressure level: [1..-1]
    /// </summary>
    RightTrigger = 5
}

/// <summary>
/// Gamepad buttons
/// </summary>
public enum GamepadButton
{
    /// <summary>
    /// Unknown button, just for error checking
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Gamepad left DPAD up button
    /// </summary>
    LeftFaceUp,

    /// <summary>
    /// Gamepad left DPAD right button
    /// </summary>
    LeftFaceRight,

    /// <summary>
    /// Gamepad left DPAD down button
    /// </summary>
    LeftFaceDown,

    /// <summary>
    /// Gamepad left DPAD left button
    /// </summary>
    LeftFaceLeft,

    /// <summary>
    /// Gamepad right button up (i.e. PS3: Triangle, Xbox: Y)
    /// </summary>
    RightFaceUp,

    /// <summary>
    /// Gamepad right button right (i.e. PS3: Square, Xbox: X)
    /// </summary>
    RightFaceRight,

    /// <summary>
    /// Gamepad right button down (i.e. PS3: Cross, Xbox: A)
    /// </summary>
    RightFaceDown,

    /// <summary>
    /// Gamepad right button left (i.e. PS3: Circle, Xbox: B)
    /// </summary>
    RightFaceLeft,

    /// <summary>
    /// Gamepad top/back trigger left (first), it could be a trailing button
    /// </summary>
    LeftTrigger1,

    /// <summary>
    /// Gamepad top/back trigger left (second), it could be a trailing button
    /// </summary>
    LeftTrigger2,

    /// <summary>
    /// Gamepad top/back trigger right (first), it could be a trailing button
    /// </summary>
    RightTrigger1,

    /// <summary>
    /// Gamepad top/back trigger right (second), it could be a trailing button
    /// </summary>
    RightTrigger2,

    /// <summary>
    /// Gamepad center buttons, left one (i.e. PS3: Select)
    /// </summary>
    MiddleLeft,

    /// <summary>
    /// Gamepad center buttons, middle one (i.e. PS3: PS, Xbox: XBOX)
    /// </summary>
    Middle,

    /// <summary>
    /// Gamepad center buttons, right one (i.e. PS3: Start)
    /// </summary>
    MiddleRight,

    /// <summary>
    /// Gamepad joystick pressed button left
    /// </summary>
    LeftThumb,

    /// <summary>
    /// Gamepad joystick pressed button right
    /// </summary>
    RightThumb
}

/// <summary>
/// Gesture
/// NOTE: It could be used as flags to enable only some gestures
/// </summary>
[Flags]
public enum Gesture : uint
{
    None = 0,
    Tap = 1,
    DoubleTap = 2,
    Hold = 4,
    Drag = 8,
    SwipeRight = 16,
    SwipeLeft = 32,
    SwipeUp = 64,
    SwipeDown = 128,
    PinchIn = 256,
    PinchOut = 512
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
    public int HResolution;

    /// <summary>
    /// HMD vertical resolution in pixels
    /// </summary>
    public int VResolution;

    /// <summary>
    /// HMD horizontal size in meters
    /// </summary>
    public float HScreenSize;

    /// <summary>
    /// HMD vertical size in meters
    /// </summary>
    public float VScreenSize;

    /// <summary>
    /// HMD screen center in meters
    /// </summary>
    public float VScreenCenter;

    /// <summary>
    /// HMD distance between eye and display in meters
    /// </summary>
    public float EyeToScreenDistance;

    /// <summary>
    /// HMD lens separation distance in meters
    /// </summary>
    public float LensSeparationDistance;

    /// <summary>
    /// HMD IPD (distance between pupils) in meters
    /// </summary>
    public float InterpupillaryDistance;

    /// <summary>
    /// HMD lens distortion constant parameters
    /// </summary>
    public fixed float LensDistortionValues[4];

    /// <summary>
    /// HMD chromatic aberration correction parameters
    /// </summary>
    public fixed float ChromaAbCorrection[4];
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
    public Matrix4x4 Projection1;

    /// <summary>
    /// VR projection matrices (per eye)
    /// </summary>
    public Matrix4x4 Projection2;

    /// <summary>
    /// VR view offset matrices (per eye)
    /// </summary>
    public Matrix4x4 ViewOffset1;

    /// <summary>
    /// VR view offset matrices (per eye)
    /// </summary>
    public Matrix4x4 ViewOffset2;

    /// <summary>
    /// VR left lens center
    /// </summary>
    public Vector2 LeftLensCenter;

    /// <summary>
    /// VR right lens center
    /// </summary>
    public Vector2 RightLensCenter;

    /// <summary>
    /// VR left screen center
    /// </summary>
    public Vector2 LeftScreenCenter;

    /// <summary>
    /// VR right screen center
    /// </summary>
    public Vector2 RightScreenCenter;

    /// <summary>
    /// VR distortion scale
    /// </summary>
    public Vector2 Scale;

    /// <summary>
    /// VR distortion scale in
    /// </summary>
    public Vector2 ScaleIn;
}
