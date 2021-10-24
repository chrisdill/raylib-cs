using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
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
}