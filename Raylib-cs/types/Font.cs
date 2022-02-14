using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Font type, defines generation method
    /// </summary>
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

    /// <summary>
    /// GlyphInfo, font characters glyphs info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct GlyphInfo
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
    public unsafe partial struct Font
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
        public Rectangle* recs;

        /// <summary>
        /// Glyphs info data
        /// </summary>
        public GlyphInfo* glyphs;
    }
}
