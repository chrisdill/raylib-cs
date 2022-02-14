using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Material map index
    /// </summary>
    public enum MaterialMapIndex
    {
        /// <summary>
        /// NOTE: Same as MATERIAL_MAP_DIFFUSE
        /// </summary>
        MATERIAL_MAP_ALBEDO = 0,

        /// <summary>
        /// NOTE: Same as MATERIAL_MAP_SPECULAR
        /// </summary>
        MATERIAL_MAP_METALNESS,

        MATERIAL_MAP_NORMAL,
        MATERIAL_MAP_ROUGHNESS,
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

    /// <summary>
    /// Material texture map
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MaterialMap
    {
        /// <summary>
        /// Material map texture
        /// </summary>
        public Texture2D texture;

        /// <summary>
        /// Material map color
        /// </summary>
        public Color color;

        /// <summary>
        /// Material map value
        /// </summary>
        public float value;
    }

    /// <summary>
    /// Material type (generic)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct Material
    {
        /// <summary>
        /// Material shader
        /// </summary>
        public Shader shader;

        //TODO: convert
        /// <summary>
        /// Material maps
        /// </summary>
        public MaterialMap* maps;

        /// <summary>
        /// Material generic parameters (if required)
        /// </summary>
        public fixed float param[4];
    }
}
