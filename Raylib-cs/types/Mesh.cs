using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Vertex data definning a mesh<br/>
    /// NOTE: Data stored in CPU memory (and GPU)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct Mesh
    {
        /// <summary>
        ///  Number of vertices stored in arrays
        /// </summary>
        public int vertexCount;

        /// <summary>
        /// Number of triangles stored (indexed or not)
        /// </summary>
        public int triangleCount;

        #region Default vertex data

        /// <summary>
        /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0)
        /// </summary>
        public float* vertices;

        /// <summary>
        /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1)
        /// </summary>
        public float* texcoords;

        /// <summary>
        /// Vertex second texture coordinates (useful for lightmaps) (shader-location = 5)
        /// </summary>
        public float* texcoords2;

        /// <summary>
        /// Vertex normals (XYZ - 3 components per vertex) (shader-location = 2)
        /// </summary>
        public float* normals;

        /// <summary>
        /// Vertex tangents (XYZW - 4 components per vertex) (shader-location = 4)
        /// </summary>
        public float* tangents;

        /// <summary>
        /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3)
        /// </summary>
        public byte* colors;

        /// <summary>
        /// Vertex indices (in case vertex data comes indexed)
        /// </summary>
        public ushort* indices;

        #endregion

        #region Animation vertex data

        /// <summary>
        /// Animated vertex positions (after bones transformations)
        /// </summary>
        public float* animVertices;

        /// <summary>
        /// Animated normals (after bones transformations)
        /// </summary>
        public float* animNormals;

        /// <summary>
        /// Vertex bone ids, up to 4 bones influence by vertex (skinning)
        /// </summary>
        public byte* boneIds;

        /// <summary>
        /// Vertex bone weight, up to 4 bones influence by vertex (skinning)
        /// </summary>
        public float* boneWeights;

        #endregion

        #region OpenGL identifiers

        /// <summary>
        /// OpenGL Vertex Array Object id
        /// </summary>
        public uint vaoId;

        /// <summary>
        /// OpenGL Vertex Buffer Objects id (default vertex data, uint[])
        /// </summary>
        public uint* vboId;

        #endregion
    }
}
