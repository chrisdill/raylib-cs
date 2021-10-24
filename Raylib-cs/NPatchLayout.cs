namespace Raylib_cs
{
    /// <summary>N-patch layout</summary>
    public enum NPatchLayout
    {
        /// <summary>
        /// Npatch defined by 3x3 tiles
        /// </summary>
        NPATCH_NINE_PATCH = 0,

        /// <summary>
        /// Npatch defined by 1x3 tiles
        /// </summary>
        NPATCH_THREE_PATCH_VERTICAL,

        /// <summary>
        /// Npatch defined by 3x1 tiles
        /// </summary>
        NPATCH_THREE_PATCH_HORIZONTAL
    }
}