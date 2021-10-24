using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// GlyphInfo, font characters glyphs info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GlyphInfo
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
}