namespace Raylib_cs
{
    /// <summary>Color blending modes (pre-defined)</summary>
    public enum BlendMode
    {
        /// <summary>
        /// Blend textures considering alpha (default)
        /// </summary>
        BLEND_ALPHA = 0,

        /// <summary>
        /// Blend textures adding colors
        /// </summary>
        BLEND_ADDITIVE,

        /// <summary>
        /// Blend textures multiplying colors
        /// </summary>
        BLEND_MULTIPLIED,

        /// <summary>
        /// Blend textures adding colors (alternative)
        /// </summary>
        BLEND_ADD_COLORS,

        /// <summary>
        /// Blend textures subtracting colors (alternative)
        /// </summary>
        BLEND_SUBTRACT_COLORS,

        /// <summary>
        /// Blend textures using custom src/dst factors (use rlSetBlendMode())
        /// </summary>
        BLEND_CUSTOM
    }
}