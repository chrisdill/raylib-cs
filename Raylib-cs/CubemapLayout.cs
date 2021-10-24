namespace Raylib_cs
{
    /// <summary>Cubemap layouts</summary>
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
}