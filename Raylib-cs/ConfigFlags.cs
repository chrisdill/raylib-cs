using System;

namespace Raylib_cs
{
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
}