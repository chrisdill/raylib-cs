namespace Raylib_cs
{
    /// <summary>Font type, defines generation method</summary>
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
}