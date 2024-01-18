using System;

namespace Raylib_cs;

/// <summary>
/// System config flags<br/>
/// NOTE: Every bit registers one state (use it with bit masks)<br/>
/// By default all flags are set to 0
/// </summary>
[Flags]
public enum ConfigFlags : uint
{
    /// <summary>
    /// Set to try enabling V-Sync on GPU
    /// </summary>
    VSyncHint = 0x00000040,

    /// <summary>
    /// Set to run program in fullscreen
    /// </summary>
    FullscreenMode = 0x00000002,

    /// <summary>
    /// Set to allow resizable window
    /// </summary>
    ResizableWindow = 0x00000004,

    /// <summary>
    /// Set to disable window decoration (frame and buttons)
    /// </summary>
    UndecoratedWindow = 0x00000008,

    /// <summary>
    /// Set to hide window
    /// </summary>
    HiddenWindow = 0x00000080,

    /// <summary>
    /// Set to minimize window (iconify)
    /// </summary>
    MinimizedWindow = 0x00000200,

    /// <summary>
    /// Set to maximize window (expanded to monitor)
    /// </summary>
    MaximizedWindow = 0x00000400,

    /// <summary>
    /// Set to window non focused
    /// </summary>
    UnfocusedWindow = 0x00000800,

    /// <summary>
    /// Set to window always on top
    /// </summary>
    TopmostWindow = 0x00001000,

    /// <summary>
    /// Set to allow windows running while minimized
    /// </summary>
    AlwaysRunWindow = 0x00000100,

    /// <summary>
    /// Set to allow transparent framebuffer
    /// </summary>
    TransparentWindow = 0x00000010,

    /// <summary>
    /// Set to support HighDPI
    /// </summary>
    HighDpiWindow = 0x00002000,

    /// <summary>
    /// Set to support mouse passthrough, only supported when FLAG_WINDOW_UNDECORATED
    /// </summary>
    MousePassthroughWindow = 0x00004000,

    /// <summary>
    /// Set to run program in borderless windowed mode
    /// </summary>
    BorderlessWindowMode = 0x00008000,

    /// <summary>
    /// Set to try enabling MSAA 4X
    /// </summary>
    Msaa4xHint = 0x00000020,

    /// <summary>
    /// Set to try enabling interlaced video format (for V3D)
    /// </summary>
    InterlacedHint = 0x00010000,
}

/// <summary>
/// Trace log level<br/>
/// NOTE: Organized by priority level
/// </summary>
public enum TraceLogLevel
{
    /// <summary>
    /// Display all logs
    /// </summary>
    All = 0,

    /// <summary>
    /// Trace logging, intended for internal use only
    /// </summary>
    Trace,

    /// <summary>
    /// Debug logging, used for internal debugging, it should be disabled on release builds
    /// </summary>
    Debug,

    /// <summary>
    /// Info logging, used for program execution info
    /// </summary>
    Info,

    /// <summary>
    /// Warning logging, used on recoverable failures
    /// </summary>
    Warning,

    /// <summary>
    /// Error logging, used on unrecoverable failures
    /// </summary>
    Error,

    /// <summary>
    /// Fatal logging, used to abort program: exit(EXIT_FAILURE)
    /// </summary>
    Fatal,

    /// <summary>
    /// Disable logging
    /// </summary>
    None
}

/// <summary>
/// Color blending modes (pre-defined)
/// </summary>
public enum BlendMode
{
    /// <summary>
    /// Blend textures considering alpha (default)
    /// </summary>
    Alpha = 0,

    /// <summary>
    /// Blend textures adding colors
    /// </summary>
    Additive,

    /// <summary>
    /// Blend textures multiplying colors
    /// </summary>
    Multiplied,

    /// <summary>
    /// Blend textures adding colors (alternative)
    /// </summary>
    AddColors,

    /// <summary>
    /// Blend textures subtracting colors (alternative)
    /// </summary>
    SubtractColors,

    /// <summary>
    /// Blend premultiplied textures considering alpha
    /// </summary>
    AlphaPremultiply,

    /// <summary>
    /// Blend textures using custom src/dst factors (use rlSetBlendFactors())
    /// </summary>
    Custom,

    /// <summary>
    /// Blend textures using custom rgb/alpha separate src/dst factors (use rlSetBlendFactorsSeparate())
    /// </summary>
    CustomSeparate
}
