namespace Raylib_cs
{
    /// <summary>Texture parameters: wrap mode</summary>
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
}