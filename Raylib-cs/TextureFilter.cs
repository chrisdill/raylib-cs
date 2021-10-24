namespace Raylib_cs
{
    /// <summary>Texture parameters: filter mode
    /// NOTE 1: Filtering considers mipmaps if available in the texture
    /// NOTE 2: Filter is accordingly set for minification and magnification</summary>
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
}