using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
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
}