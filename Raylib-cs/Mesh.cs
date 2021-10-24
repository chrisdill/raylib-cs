using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Vertex data definning a mesh
    /// NOTE: Data stored in CPU memory (and GPU)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Mesh
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
        /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0, float *)
        /// </summary>
        public IntPtr vertices;

        /// <summary>
        /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1, float *)
        /// </summary>
        public IntPtr texcoords;

        /// <summary>
        /// Vertex second texture coordinates (useful for lightmaps) (shader-location = 5, float *)
        /// </summary>
        public IntPtr texcoords2;

        /// <summary>
        /// Vertex normals (XYZ - 3 components per vertex) (shader-location = 2, float *)
        /// </summary>
        public IntPtr normals;

        /// <summary>
        /// Vertex tangents (XYZW - 4 components per vertex) (shader-location = 4, float *)
        /// </summary>
        public IntPtr tangents;

        /// <summary>
        /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3,  unsigned char *)
        /// </summary>
        public IntPtr colors;

        /// <summary>
        /// Vertex indices (in case vertex data comes indexed, unsigned short *)
        /// </summary>
        public IntPtr indices;

        #endregion

        #region Animation vertex data

        /// <summary>
        /// Animated vertex positions (after bones transformations, float *)
        /// </summary>
        public IntPtr animVertices;

        /// <summary>
        /// Animated normals (after bones transformations, float *)
        /// </summary>
        public IntPtr animNormals;

        /// <summary>
        /// Vertex bone ids, up to 4 bones influence by vertex (skinning, int *)
        /// </summary>
        public IntPtr boneIds;

        /// <summary>
        /// Vertex bone weight, up to 4 bones influence by vertex (skinning, float *)
        /// </summary>
        public IntPtr boneWeights;

        #endregion

        #region OpenGL identifiers

        /// <summary>
        /// OpenGL Vertex Array Object id
        /// </summary>
        public uint vaoId;

        /// <summary>
        /// OpenGL Vertex Buffer Objects id (default vertex data, uint[])
        /// </summary>
        public IntPtr vboId;

        #endregion
    }
}