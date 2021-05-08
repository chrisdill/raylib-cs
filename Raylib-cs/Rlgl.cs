using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    /// <summary>RenderBatch type</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderBatch
    {
        int buffersCount;           // Number of vertex buffers (multi-buffering support)
        int currentBuffer;          // Current buffer tracking in case of multi-buffering
        IntPtr vertexBuffer;        // Dynamic buffer(s) for vertex data

        IntPtr draws;               // Draw calls array, depends on textureId
        int drawsCounter;           // Draw calls counter
        float currentDepth;         // Current depth value for next draw
    }

    public enum GlVersion
    {
        OPENGL_11 = 1,
        OPENGL_21,
        OPENGL_33,
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

    [SuppressUnmanagedCodeSecurity]
    public static class Rlgl
    {
        // Used by DllImport to load the native library.
        public const string nativeLibName = "raylib";

        public const int DEFAULT_BATCH_BUFFER_ELEMENTS = 8192;
        public const int DEFAULT_BATCH_BUFFERS = 1;
        public const int DEFAULT_BATCH_DRAWCALLS = 256;
        public const int MAX_BATCH_ACTIVE_TEXTURES = 4;
        public const int MAX_MATRIX_STACK_SIZE = 32;
        public const float RL_CULL_DISTANCE_NEAR = 0.01f;
        public const float RL_CULL_DISTANCE_FAR = 1000.0f;

        // Texture parameters (equivalent to OpenGL defines)
        public const int RL_TEXTURE_WRAP_S = 0x2802;
        public const int RL_TEXTURE_WRAP_T = 0x2803;
        public const int RL_TEXTURE_MAG_FILTER = 0x2800;
        public const int RL_TEXTURE_MIN_FILTER = 0x2801;

        public const int RL_TEXTURE_FILTER_NEAREST = 0x2600;
        public const int RL_TEXTURE_FILTER_LINEAR = 0x2601;
        public const int RL_TEXTURE_FILTER_MIP_NEAREST = 0x2700;
        public const int RL_TEXTURE_FILTER_NEAREST_MIP_LINEAR = 0x2702;
        public const int RL_TEXTURE_FILTER_LINEAR_MIP_NEAREST = 0x2701;
        public const int RL_TEXTURE_FILTER_MIP_LINEAR = 0x2703;
        public const int RL_TEXTURE_FILTER_ANISOTROPIC = 0x3000;

        public const int RL_TEXTURE_WRAP_REPEAT = 0x2901;
        public const int RL_TEXTURE_WRAP_CLAMP = 0x812F;
        public const int RL_TEXTURE_WRAP_MIRROR_REPEAT = 0x8370;
        public const int RL_TEXTURE_WRAP_MIRROR_CLAMP = 0x8742;

        // Matrix modes (equivalent to OpenGL)
        public const int RL_MODELVIEW = 0x1700;
        public const int RL_PROJECTION = 0x1701;
        public const int RL_TEXTURE = 0x1702;

        // Primitive assembly draw modes
        public const int RL_LINES = 0x0001;
        public const int RL_TRIANGLES = 0x0004;
        public const int RL_QUADS = 0x0007;

        // GL equivalent data types
        public const int RL_UNSIGNED_BYTE = 0x1401;
        public const int RL_FLOAT = 0x1406;

        // ------------------------------------------------------------------------------------
        // Functions Declaration - Matrix operations
        // ------------------------------------------------------------------------------------

        /// <summary>Choose the current matrix to be transformed</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlMatrixMode(int mode);

        /// <summary>Push the current matrix to stack</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlPushMatrix();

        /// <summary>Pop lattest inserted matrix from stack</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlPopMatrix();

        /// <summary>Reset current matrix to identity matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadIdentity();

        /// <summary>Multiply the current matrix by a translation matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTranslatef(float x, float y, float z);

        /// <summary>Multiply the current matrix by a rotation matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlRotatef(float angleDeg, float x, float y, float z);

        /// <summary>Multiply the current matrix by a scaling matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlScalef(float x, float y, float z);

        /// <summary>Multiply the current matrix by another matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlMultMatrixf(ref float[] matf);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlFrustum(double left, double right, double bottom, double top, double znear, double zfar);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlOrtho(double left, double right, double bottom, double top, double znear, double zfar);

        /// <summary>Set the viewport area</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlViewport(int x, int y, int width, int height);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - Vertex level operations
        // ------------------------------------------------------------------------------------

        /// <summary>Initialize drawing mode (how to organize vertex)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlBegin(int mode);

        /// <summary>Finish vertex providing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnd();

        /// <summary>Define one vertex (position) - 2 int</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex2i(int x, int y);

        /// <summary>Define one vertex (position) - 2 float</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex2f(float x, float y);

        /// <summary>Define one vertex (position) - 3 float</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex3f(float x, float y, float z);

        /// <summary>Define one vertex (texture coordinate) - 2 float</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTexCoord2f(float x, float y);

        /// <summary>Define one vertex (normal) - 3 float</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlNormal3f(float x, float y, float z);

        /// <summary>Define one vertex (color) - 4 byte</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor4ub(byte r, byte g, byte b, byte a);

        /// <summary>Define one vertex (color) - 3 float</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor3f(float x, float y, float z);

        /// <summary>Define one vertex (color) - 4 float</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor4f(float x, float y, float z, float w);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - OpenGL equivalent functions (common to 1.1, 3.3+, ES2)
        // NOTE: This functions are used to completely abstract raylib code from OpenGL layer
        // ------------------------------------------------------------------------------------

        /// <summary>Vertex buffers state</summary>

        /// <summary>Enable vertex array (VAO, if supported)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlEnableVertexArray(uint vaoId);

        /// <summary>Disable vertex array (VAO, if supported)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexArray();

        /// <summary>Enable vertex buffer (VBO)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexBuffer(uint id);

        /// <summary>Disable vertex buffer (VBO)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexBuffer();

        /// <summary>Enable vertex buffer element (VBO element)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexBufferElement(uint id);

        /// <summary>Disable vertex buffer element (VBO element)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexBufferElement();

        /// <summary>Enable vertex attribute index</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexAttribute(uint index);

        /// <summary>Disable vertex attribute index</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexAttribute(uint index);


        // Textures state

        /// <summary>Select and active a texture slot</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlActiveTextureSlot(int slot);

        /// <summary>Enable texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableTexture(uint id);

        /// <summary>Disable texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableTexture();

        /// <summary>Enable texture cubemap</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableTextureCubemap(uint id);

        /// <summary>Disable texture cubemap</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableTextureCubemap();

        /// <summary>Set texture parameters (filter, wrap)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTextureParameters(uint id, int param, int value);


        // Shader state

        /// <summary>Enable shader program</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableShader(uint id);

        /// <summary>Disable shader program</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableShader();


        // Framebuffer state

        /// <summary>Enable render texture (fbo)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableFramebuffer(uint id);

        /// <summary>Disable render texture (fbo), return to default framebuffer</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableFramebuffer();


        // General render state

        /// <summary>Enable depth test</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableDepthTest();

        /// <summary>Disable depth test</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableDepthTest();

        /// <summary>Enable depth write</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableDepthMask();

        /// <summary>Disable depth write</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableDepthMask();

        /// <summary>Enable backface culling</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableBackfaceCulling();

        /// <summary>Disable backface culling</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableBackfaceCulling();

        /// <summary>Enable scissor test</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableScissorTest();

        /// <summary>Disable scissor test</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableScissorTest();

        /// <summary>Scissor test</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlScissor(int x, int y, int width, int height);

        /// <summary>Enable wire mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableWireMode();

        /// <summary>Disable wire mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableWireMode();

        /// <summary>Set the line drawing width</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetLineWidth(float width);

        /// <summary>Get the line drawing width</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float rlGetLineWidth();

        /// <summary>Enable line aliasing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableSmoothLines();

        /// <summary>Disable line aliasing</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableSmoothLines();

        /// <summary>Enable stereo rendering</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableStereoRender();

        /// <summary>Disable stereo rendering</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableStereoRender();

        /// <summary>Check if stereo render is enabled</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlIsStereoRenderEnabled();

        /// <summary>Clear color buffer with color</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearColor(byte r, byte g, byte b, byte a);

        /// <summary>Clear used screen buffers (color and depth)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearScreenBuffers();

        /// <summary>Check and log OpenGL error codes</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlCheckErrors();

        /// <summary>Set blending mode</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendMode(int mode);

        /// <summary>Set blending mode factor and equation (using OpenGL factors)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendModeFactors(int glSrcFactor, int glDstFactor, int glEquation);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - rlgl functionality
        // ------------------------------------------------------------------------------------

        /// <summary>Initialize rlgl (buffers, shaders, textures, states)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglInit(int width, int height);

        /// <summary>De-inititialize rlgl (buffers, shaders, textures)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglClose();

        /// <summary>Load OpenGL extensions</summary>
        /// <summary>loader refers to a void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadExtensions(IntPtr loader);

        /// <summary>Returns current OpenGL version</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlVersion rlGetVersion();

        /// <summary>Get default framebuffer width</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetFramebufferWidth();

        /// <summary>Get default framebuffer height</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetFramebufferHeight();

        /// <summary>Get default shader</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader rlGetShaderDefault();

        /// <summary>Get default texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D rlGetTextureDefault();


        // Render batch management

        /// <summary>Load a render batch system</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderBatch rlLoadRenderBatch(int numBuffers, int bufferElements);

        /// <summary>Unload render batch system</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadRenderBatch(RenderBatch batch);

        /// <summary>Draw render batch data (Update->Draw->Reset)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawRenderBatch(ref RenderBatch batch);

        /// <summary>Set the active render batch for rlgl (NULL for default internal)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetRenderBatchActive(ref RenderBatch batch);

        /// <summary>Update and draw internal render batch</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawRenderBatchActive();

        /// <summary>Check internal buffer overflow for a given number of vertex</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlCheckRenderBatchLimit(int vCount);

        /// <summary>Set current texture for render batch and check buffers limits</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetTexture(uint id);


        // Vertex buffers management

        /// <summary>Load vertex array (vao) if supported</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexArray();

        /// <summary>Load a vertex buffer attribute</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexBuffer(IntPtr buffer, int size, bool dynamic);

        /// <summary>Load a new attributes element buffer</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexBufferElement(IntPtr buffer, int size, bool dynamic);

        /// <summary>Update GPU buffer with new data</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateVertexBuffer(int bufferId, IntPtr data, int dataSize, int offset);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadVertexArray(uint vaoId);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadVertexBuffer(uint vboId);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetVertexAttribute(uint index, int compSize, int type, bool normalized, int stride, IntPtr pointer);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetVertexAttributeDivisor(uint index, int divisor);

        /// <summary>Set vertex attribute default value</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetVertexAttributeDefault(int locIndex, IntPtr value, int attribType, int count);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArray(int offset, int count);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArrayElements(int offset, int count, IntPtr buffer);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArrayInstanced(int offset, int count, int instances);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArrayElementsInstanced(int offset, int count, IntPtr buffer, int instances);


        // Textures data management

        /// <summary>Load texture in GPU
        /// data refers to a void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTexture(IntPtr data, int width, int height, PixelFormat format, int mipmapCount);

        /// <summary>Load depth texture/renderbuffer (to be attached to fbo)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTextureDepth(int width, int height, bool useRenderBuffer);

        /// <summary>Load texture cubemap
        /// data refers to a void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTextureCubemap(IntPtr data, int size, PixelFormat format);

        /// <summary>Update GPU texture with new data
        /// data refers to a const void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateTexture(uint id, int width, int height, PixelFormat format, IntPtr data);

        /// <summary>Get OpenGL internal formats</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlGetGlTextureFormats(PixelFormat format, ref uint glInternalFormat, ref uint glFormat, ref uint glType);

        /// <summary>Unload texture from GPU memory</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadTexture(uint id);

        /// <summary>Generate mipmap data for selected texture</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlGenerateMipmaps(ref Texture2D texture);

        /// <summary>Read texture pixel data
        /// IntPtr refers to a void *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rlReadTexturePixels(Texture2D texture);

        /// <summary>Read screen pixel data (color buffer)
        /// IntPtr refers to a unsigned char *</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rlReadScreenPixels(int width, int height);


        // Framebuffer management (fbo)

        /// <summary>Load an empty framebuffer</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadFramebuffer(int width, int height);

        /// <summary>Attach texture/renderbuffer to a framebuffer</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlFramebufferAttach(uint fboId, uint texId, FramebufferAttachType attachType, FramebufferAttachTextureType texType, int mipLevel);

        /// <summary>Verify framebuffer is complete</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlFramebufferComplete(uint id);

        /// <summary>Delete framebuffer from GPU</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlUnloadFramebuffer(uint id);


        // Shaders management

        /// <summary>Load shader from code strings</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadShaderCode(string vsCode, string fsCode);

        /// <summary>Compile custom shader and return shader id (type: GL_VERTEX_SHADER, GL_FRAGMENT_SHADER)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlCompileShader(string shaderCode, int type);

        /// <summary>Load custom shader program</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadShaderProgram(uint vShaderId, uint fShaderId);

        /// <summary>Unload shader program</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadShaderProgram(uint id);

        /// <summary>Get shader location uniform</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetLocationUniform(uint shaderId, string uniformName);

        /// <summary>Get shader location attribute</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetLocationAttrib(uint shaderId, string attribName);

        /// <summary>Set shader value uniform</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniform(int locIndex, IntPtr value, int uniformType, int count);

        /// <summary>Set shader value matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniformMatrix(int locIndex, Matrix4x4 mat);

        /// <summary>Set shader value sampler</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniformSampler(int locIndex, uint textureId);

        /// <summary>Set shader currently active</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetShader(Shader shader);


        // Matrix state management

        /// <summary>Get internal modelview matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixModelView();

        /// <summary>Get internal projection matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixProjection();

        /// <summary>Get internal accumulated transform matrix</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixTramsform();

        /// <summary>Get internal projection matrix for stereo render (selected eye)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixProjectionStereo(int eye);

        /// <summary>Get internal view offset matrix for stereo render (selected eye)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixViewOffsetStereo(int eye);

        /// <summary>Set a custom projection matrix (replaces internal projection matrix)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixProjection(Matrix4x4 view);

        /// <summary>Set a custom modelview matrix (replaces internal modelview matrix)</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixModelView(Matrix4x4 proj);

        /// <summary>Set eyes projection matrices for stereo rendering</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixProjectionStereo(Matrix4x4 left, Matrix4x4 right);

        /// <summary>Set eyes view offsets matrices for stereo rendering</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixViewOffsetStereo(Matrix4x4 left, Matrix4x4 right);


        // Quick and dirty cube/quad buffers load->draw->unload

        /// <summary>Load and draw a cube</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadDrawCube();

        /// <summary>Load and draw a quad</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadDrawQuad();
    }
}
