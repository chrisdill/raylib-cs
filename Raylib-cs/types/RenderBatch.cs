using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// RenderBatch type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderBatch
    {
        /// <summary>
        /// Number of vertex buffers (multi-buffering support)
        /// </summary>
        int buffersCount;

        /// <summary>
        /// Current buffer tracking in case of multi-buffering
        /// </summary>
        int currentBuffer;

        /// <summary>
        /// Dynamic buffer(s) for vertex data
        /// </summary>
        IntPtr vertexBuffer;

        /// <summary>
        /// Draw calls array, depends on textureId
        /// </summary>
        IntPtr draws;

        /// <summary>
        /// Draw calls counter
        /// </summary>
        int drawsCounter;

        /// <summary>
        /// Current depth value for next draw
        /// </summary>
        float currentDepth;
    }

    /// <summary>
    /// Dynamic vertex buffers (position + texcoords + colors + indices arrays)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VertexBuffer
    {
        /// <summary>
        /// Number of elements in the buffer (QUADS)
        /// </summary>
        public int elementCount;

        /// <summary>
        /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0, float *)
        /// </summary>
        public IntPtr vertices;

        /// <summary>
        /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1, float *)
        /// </summary>
        public IntPtr texcoords;

        /// <summary>
        /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3, unsigned char *) 
        /// </summary>
        public IntPtr colors;

        /// <summary>
        /// Vertex indices (in case vertex data comes indexed) (6 indices per quad)<br/>
        /// unsigned int * for GRAPHICS_API_OPENGL_11 or GRAPHICS_API_OPENGL_33<br/>
        /// unsigned short * for GRAPHICS_API_OPENGL_ES2
        /// </summary>
        public IntPtr indices;

        /// <summary>
        /// OpenGL Vertex Array Object id
        /// </summary>
        public uint vaoId;

        /// <summary>
        /// OpenGL Vertex Buffer Objects id (4 types of vertex data)
        /// </summary>
        public fixed uint vboId[4];
    }

    /// <summary>
    /// Dynamic vertex buffers (position + texcoords + colors + indices arrays)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DrawCall
    {
        /// <summary>
        /// Drawing mode: LINES, TRIANGLES, QUADS
        /// </summary>
        int mode;

        /// <summary>
        /// Number of vertices for the draw call
        /// </summary>
        int vertexCount;

        /// <summary>
        /// Number of vertices required for index alignment (LINES, TRIANGLES)
        /// </summary>
        int vertexAlignment;

        /// <summary>
        /// Texture id to be used on the draw -> Use to create new draw call if changes
        /// </summary>
        uint textureId;
    }

    public enum GlVersion
    {
        OPENGL_11 = 1,
        OPENGL_21,
        OPENGL_33,
        OPENGL_43,
        OPENGL_ES_20
    }

    public enum FramebufferAttachType
    {
        RL_ATTACHMENT_COLOR_CHANNEL0 = 0,
        RL_ATTACHMENT_COLOR_CHANNEL1,
        RL_ATTACHMENT_COLOR_CHANNEL2,
        RL_ATTACHMENT_COLOR_CHANNEL3,
        RL_ATTACHMENT_COLOR_CHANNEL4,
        RL_ATTACHMENT_COLOR_CHANNEL5,
        RL_ATTACHMENT_COLOR_CHANNEL6,
        RL_ATTACHMENT_COLOR_CHANNEL7,
        RL_ATTACHMENT_DEPTH = 100,
        RL_ATTACHMENT_STENCIL = 200,
    }

    public enum FramebufferAttachTextureType
    {
        RL_ATTACHMENT_CUBEMAP_POSITIVE_X = 0,
        RL_ATTACHMENT_CUBEMAP_NEGATIVE_X,
        RL_ATTACHMENT_CUBEMAP_POSITIVE_Y,
        RL_ATTACHMENT_CUBEMAP_NEGATIVE_Y,
        RL_ATTACHMENT_CUBEMAP_POSITIVE_Z,
        RL_ATTACHMENT_CUBEMAP_NEGATIVE_Z,
        RL_ATTACHMENT_TEXTURE2D = 100,
        RL_ATTACHMENT_RENDERBUFFER = 200,
    }
}
