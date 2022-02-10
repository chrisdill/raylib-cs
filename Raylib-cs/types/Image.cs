using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Pixel formats<br/>
    /// NOTE: Support depends on OpenGL version and platform
    /// </summary>
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

    /// <summary>
    /// Image, pixel data stored in CPU memory (RAM)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct Image
    {
        /// <summary>
        /// Image raw data
        /// </summary>
        public void* data;

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
