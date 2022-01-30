using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Shader location index
    /// </summary>
    public enum ShaderLocationIndex
    {
        SHADER_LOC_VERTEX_POSITION = 0,
        SHADER_LOC_VERTEX_TEXCOORD01,
        SHADER_LOC_VERTEX_TEXCOORD02,
        SHADER_LOC_VERTEX_NORMAL,
        SHADER_LOC_VERTEX_TANGENT,
        SHADER_LOC_VERTEX_COLOR,
        SHADER_LOC_MATRIX_MVP,
        SHADER_LOC_MATRIX_VIEW,
        SHADER_LOC_MATRIX_PROJECTION,
        SHADER_LOC_MATRIX_MODEL,
        SHADER_LOC_MATRIX_NORMAL,
        SHADER_LOC_VECTOR_VIEW,
        SHADER_LOC_COLOR_DIFFUSE,
        SHADER_LOC_COLOR_SPECULAR,
        SHADER_LOC_COLOR_AMBIENT,
        SHADER_LOC_MAP_ALBEDO,
        SHADER_LOC_MAP_METALNESS,
        SHADER_LOC_MAP_NORMAL,
        SHADER_LOC_MAP_ROUGHNESS,
        SHADER_LOC_MAP_OCCLUSION,
        SHADER_LOC_MAP_EMISSION,
        SHADER_LOC_MAP_HEIGHT,
        SHADER_LOC_MAP_CUBEMAP,
        SHADER_LOC_MAP_IRRADIANCE,
        SHADER_LOC_MAP_PREFILTER,
        SHADER_LOC_MAP_BRDF,

        SHADER_LOC_MAP_DIFFUSE = SHADER_LOC_MAP_ALBEDO,
        SHADER_LOC_MAP_SPECULAR = SHADER_LOC_MAP_METALNESS,
    }

    /// <summary>
    /// Shader attribute data types
    /// </summary>
    public enum ShaderAttributeDataType
    {
        SHADER_ATTRIB_FLOAT = 0,
        SHADER_ATTRIB_VEC2,
        SHADER_ATTRIB_VEC3,
        SHADER_ATTRIB_VEC4
    }

    /// <summary>
    /// Shader uniform data type
    /// </summary>
    public enum ShaderUniformDataType
    {
        SHADER_UNIFORM_FLOAT = 0,
        SHADER_UNIFORM_VEC2,
        SHADER_UNIFORM_VEC3,
        SHADER_UNIFORM_VEC4,
        SHADER_UNIFORM_INT,
        SHADER_UNIFORM_IVEC2,
        SHADER_UNIFORM_IVEC3,
        SHADER_UNIFORM_IVEC4,
        SHADER_UNIFORM_SAMPLER2D
    }

    /// <summary>
    /// Shader type (generic)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct Shader
    {
        /// <summary>
        /// Shader program id
        /// </summary>
        public uint id;

        /// <summary>
        /// Shader locations array (MAX_SHADER_LOCATIONS, int *)
        /// </summary>
        public int* locs;
    }
}
