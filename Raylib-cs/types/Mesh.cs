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
        public int VertexCount;

        /// <summary>
        /// Number of triangles stored (indexed or not)
        /// </summary>
        public int TriangleCount;

        #region Default vertex data

        /// <summary>
        /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0)
        /// </summary>
        public float* Vertices;

        /// <summary>
        /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1)
        /// </summary>
        public float* TexCoords;

        /// <summary>
        /// Vertex second texture coordinates (useful for lightmaps) (shader-location = 5)
        /// </summary>
        public float* TexCoords2;

        /// <summary>
        /// Vertex normals (XYZ - 3 components per vertex) (shader-location = 2)
        /// </summary>
        public float* Normals;

        /// <summary>
        /// Vertex tangents (XYZW - 4 components per vertex) (shader-location = 4)
        /// </summary>
        public float* Tangents;

        /// <summary>
        /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3)
        /// </summary>
        public byte* Colors;

        /// <summary>
        /// Vertex indices (in case vertex data comes indexed)
        /// </summary>
        public ushort* Indices;

        #endregion

        #region Animation vertex data

        /// <summary>
        /// Animated vertex positions (after bones transformations)
        /// </summary>
        public float* AnimVertices;

        /// <summary>
        /// Animated normals (after bones transformations)
        /// </summary>
        public float* AnimNormals;

        /// <summary>
        /// Vertex bone ids, up to 4 bones influence by vertex (skinning)
        /// </summary>
        public byte* BoneIds;

        /// <summary>
        /// Vertex bone weight, up to 4 bones influence by vertex (skinning)
        /// </summary>
        public float* BoneWeights;

        #endregion

        #region OpenGL identifiers

        /// <summary>
        /// OpenGL Vertex Array Object id
        /// </summary>
        public uint VaoId;

        /// <summary>
        /// OpenGL Vertex Buffer Objects id (default vertex data, uint[])
        /// </summary>
        public uint* VboId;

        #endregion
    }
}
