using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Texture parameters: filter mode<br/>
    /// NOTE 1: Filtering considers mipmaps if available in the texture<br/>
    /// NOTE 2: Filter is accordingly set for minification and magnification
    /// </summary>
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

    /// <summary>
    /// Texture parameters: wrap mode
    /// </summary>
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

    /// <summary>
    /// Cubemap layouts
    /// </summary>
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

    /// <summary>
    /// Texture2D type<br/>
    /// NOTE: Data stored in GPU memory
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Texture2D
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
}
