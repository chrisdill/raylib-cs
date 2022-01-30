using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// RenderBatch type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct RenderBatch
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
        VertexBuffer* vertexBuffer;

        /// <summary>
        /// Draw calls array, depends on textureId
        /// </summary>
        DrawCall* draws;

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
    public unsafe partial struct VertexBuffer
    {
        /// <summary>
        /// Number of elements in the buffer (QUADS)
        /// </summary>
        public int elementCount;

        /// <summary>
        /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0)
        /// </summary>
        public float* vertices;

        /// <summary>
        /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1)
        /// </summary>
        public float* texcoords;

        /// <summary>
        /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3)
        /// </summary>
        public byte* colors;

        /// <summary>
        /// Vertex indices (in case vertex data comes indexed) (6 indices per quad)<br/>
        /// unsigned int* for GRAPHICS_API_OPENGL_11 or GRAPHICS_API_OPENGL_33<br/>
        /// unsigned short* for GRAPHICS_API_OPENGL_ES2
        /// </summary>
        public void* indices;

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
    public partial struct DrawCall
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

    /// <summary>
    /// Matrix Modes (equivalent to OpenGL)
    /// </summary>
    public enum MatrixMode
    {
        /// <summary>
        /// GL_MODELVIEW
        /// </summary>
        MODELVIEW = 0x1700,

        /// <summary>
        /// GL_PROJECTION
        /// </summary>
        PROJECTION = 0x1701,

        /// <summary>
        /// GL_TEXTURE
        /// </summary>
        TEXTURE = 0x1702
    }

    /// <summary>
    /// Primitive assembly draw modes
    /// </summary>
    public enum DrawMode
    {
        /// <summary>
        /// GL_LINES
        /// </summary>
        LINES = 0x0001,

        /// <summary>
        /// GL_TRIANGLES
        /// </summary>
        TRIANGLES = 0x0004,

        /// <summary>
        /// GL_QUADS
        /// </summary>
        QUADS = 0x0007
    }

    /// <summary>
    /// Texture parameters (equivalent to OpenGL defines)
    /// </summary>
    public enum TextureFilters
    {
        /// <summary>
        /// RL_TEXTURE_FILTER_NEAREST
        /// <br/>
        /// GL_NEAREST
        /// </summary>
        NEAREST = 0x2600,

        /// <summary>
        /// RL_TEXTURE_FILTER_LINEAR
        /// <br/>
        /// GL_LINEAR
        /// </summary>
        LINEAR = 0x2601,

        /// <summary>
        /// RL_TEXTURE_FILTER_MIP_NEAREST
        /// <br/>
        /// GL_NEAREST_MIPMAP_NEAREST
        /// </summary>
        MIP_NEAREST = 0x2700,

        /// <summary>
        /// RL_TEXTURE_FILTER_NEAREST_MIP_LINEAR
        /// <br/>
        /// GL_NEAREST_MIPMAP_LINEAR
        /// </summary>
        NEAREST_MIP_LINEAR = 0x2702,

        /// <summary>
        /// RL_TEXTURE_FILTER_LINEAR_MIP_NEAREST
        /// <br/>
        /// GL_LINEAR_MIPMAP_NEAREST
        /// </summary>
        LINEAR_MIP_NEAREST = 0x2701,

        /// <summary>
        /// RL_TEXTURE_FILTER_MIP_LINEAR
        /// <br/>
        /// GL_LINEAR_MIPMAP_LINEAR
        /// </summary>
        MIP_LINEAR = 0x2703,

        /// <summary>
        /// RL_TEXTURE_FILTER_ANISOTROPIC
        /// <br/>
        /// Anisotropic filter (custom identifier)
        /// </summary>
        ANISOTROPIC = 0x3000
    }

    /// <summary>
    /// GL Shader type
    /// </summary>
    public enum ShaderType
    {
        /// <summary>
        /// RL_FRAGMENT_SHADER
        /// <br/>
        /// GL_FRAGMENT_SHADER
        /// </summary>
        FRAGMENT = 0x8B30,

        /// <summary>
        /// RL_VERTEX_SHADER
        /// <br/>
        /// GL_VERTEX_SHADER
        /// </summary>
        VERTEX = 0x8B31,

        /// <summary>
        /// RL_COMPUTE_SHADER
        /// <br/>
        /// GL_COMPUTE_SHADER
        /// </summary>
        COMPUTE = 0x91b9
    }
}
