namespace Raylib_cs
{
    /// <summary>Material map index</summary>
    public enum MaterialMapIndex
    {
        /// <summary>
        /// MAP_DIFFUSE
        /// </summary>
        MATERIAL_MAP_ALBEDO = 0,

        /// <summary>
        /// MAP_SPECULAR
        /// </summary>
        MATERIAL_MAP_METALNESS = 1,

        MATERIAL_MAP_NORMAL = 2,
        MATERIAL_MAP_ROUGHNESS = 3,
        MATERIAL_MAP_OCCLUSION,
        MATERIAL_MAP_EMISSION,
        MATERIAL_MAP_HEIGHT,

        /// <summary>
        /// NOTE: Uses GL_TEXTURE_CUBE_MAP
        /// </summary>
        MATERIAL_MAP_CUBEMAP,

        /// <summary>
        /// NOTE: Uses GL_TEXTURE_CUBE_MAP
        /// </summary>
        MATERIAL_MAP_IRRADIANCE,

        /// <summary>
        /// NOTE: Uses GL_TEXTURE_CUBE_MAP
        /// </summary>
        MATERIAL_MAP_PREFILTER,

        MATERIAL_MAP_BRDF,

        MATERIAL_MAP_DIFFUSE = MATERIAL_MAP_ALBEDO,
        MATERIAL_MAP_SPECULAR = MATERIAL_MAP_METALNESS,
    }
}