using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    // RenderBatch type
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

        // Choose the current matrix to be transformed
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlMatrixMode(int mode);

        // Push the current matrix to stack
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlPushMatrix();

        // Pop lattest inserted matrix from stack
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlPopMatrix();

        // Reset current matrix to identity matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadIdentity();

        // Multiply the current matrix by a translation matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTranslatef(float x, float y, float z);

        // Multiply the current matrix by a rotation matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlRotatef(float angleDeg, float x, float y, float z);

        // Multiply the current matrix by a scaling matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlScalef(float x, float y, float z);

        // Multiply the current matrix by another matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlMultMatrixf(ref float[] matf);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlFrustum(double left, double right, double bottom, double top, double znear, double zfar);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlOrtho(double left, double right, double bottom, double top, double znear, double zfar);

        // Set the viewport area
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlViewport(int x, int y, int width, int height);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - Vertex level operations
        // ------------------------------------------------------------------------------------

        // Initialize drawing mode (how to organize vertex)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlBegin(int mode);

        // Finish vertex providing
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnd();

        // Define one vertex (position) - 2 int
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex2i(int x, int y);

        // Define one vertex (position) - 2 float
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex2f(float x, float y);

        // Define one vertex (position) - 3 float
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex3f(float x, float y, float z);

        // Define one vertex (texture coordinate) - 2 float
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTexCoord2f(float x, float y);

        // Define one vertex (normal) - 3 float
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlNormal3f(float x, float y, float z);

        // Define one vertex (color) - 4 byte
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor4ub(byte r, byte g, byte b, byte a);

        // Define one vertex (color) - 3 float
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor3f(float x, float y, float z);

        // Define one vertex (color) - 4 float
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor4f(float x, float y, float z, float w);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - OpenGL equivalent functions (common to 1.1, 3.3+, ES2)
        // NOTE: This functions are used to completely abstract raylib code from OpenGL layer
        // ------------------------------------------------------------------------------------

        // Vertex buffers state

        // Enable vertex array (VAO, if supported)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlEnableVertexArray(uint vaoId);

        // Disable vertex array (VAO, if supported)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexArray();

        // Enable vertex buffer (VBO)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexBuffer(uint id);

        // Disable vertex buffer (VBO)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexBuffer();

        // Enable vertex buffer element (VBO element)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexBufferElement(uint id);

        // Disable vertex buffer element (VBO element)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexBufferElement();

        // Enable vertex attribute index
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexAttribute(uint index);

        // Disable vertex attribute index
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexAttribute(uint index);


        // Textures state

        // Select and active a texture slot
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlActiveTextureSlot(int slot);

        // Enable texture
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableTexture(uint id);

        // Disable texture
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableTexture();

        // Enable texture cubemap
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableTextureCubemap(uint id);

        // Disable texture cubemap
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableTextureCubemap();

        // Set texture parameters (filter, wrap)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTextureParameters(uint id, int param, int value);


        // Shader state

        // Enable shader program
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableShader(uint id);

        // Disable shader program
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableShader();


        // Framebuffer state

        // Enable render texture (fbo)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableFramebuffer(uint id);

        // Disable render texture (fbo), return to default framebuffer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableFramebuffer();


        // General render state

        // Enable depth test
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableDepthTest();

        // Disable depth test
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableDepthTest();

        // Enable depth write
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableDepthMask();

        // Disable depth write
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableDepthMask();

        // Enable backface culling
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableBackfaceCulling();

        // Disable backface culling
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableBackfaceCulling();

        // Enable scissor test
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableScissorTest();

        // Disable scissor test
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableScissorTest();

        // Scissor test
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlScissor(int x, int y, int width, int height);

        // Enable wire mode
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableWireMode();

        // Disable wire mode
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableWireMode();

        // Set the line drawing width
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetLineWidth(float width);

        // Get the line drawing width
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float rlGetLineWidth();

        // Enable line aliasing
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableSmoothLines();

        // Disable line aliasing
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableSmoothLines();

        // Enable stereo rendering
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableStereoRender();

        // Disable stereo rendering
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableStereoRender();

        // Check if stereo render is enabled
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlIsStereoRenderEnabled();

        // Clear color buffer with color
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearColor(byte r, byte g, byte b, byte a);

        // Clear used screen buffers (color and depth)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearScreenBuffers();

        // Check and log OpenGL error codes
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlCheckErrors();

        // Set blending mode
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendMode(int mode);

        // Set blending mode factor and equation (using OpenGL factors)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendModeFactors(int glSrcFactor, int glDstFactor, int glEquation);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - rlgl functionality
        // ------------------------------------------------------------------------------------

        // Initialize rlgl (buffers, shaders, textures, states)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglInit(int width, int height);

        // De-inititialize rlgl (buffers, shaders, textures)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglClose();

        // Load OpenGL extensions
        // loader refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadExtensions(IntPtr loader);

        // Returns current OpenGL version
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlVersion rlGetVersion();

        // Get default framebuffer width
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetFramebufferWidth();

        // Get default framebuffer height
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetFramebufferHeight();

        // Get default shader
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader rlGetShaderDefault();

        // Get default texture
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D rlGetTextureDefault();


        // Render batch management

        // Load a render batch system
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderBatch rlLoadRenderBatch(int numBuffers, int bufferElements);

        // Unload render batch system
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadRenderBatch(RenderBatch batch);

        // Draw render batch data (Update->Draw->Reset)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawRenderBatch(ref RenderBatch batch);

        // Set the active render batch for rlgl (NULL for default internal)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetRenderBatchActive(ref RenderBatch batch);

        // Update and draw internal render batch
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawRenderBatchActive();

        // Check internal buffer overflow for a given number of vertex
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlCheckRenderBatchLimit(int vCount);

        // Set current texture for render batch and check buffers limits
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetTexture(uint id);


        // Vertex buffers management

        // Load vertex array (vao) if supported
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexArray();

        // Load a vertex buffer attribute
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexBuffer(IntPtr buffer, int size, bool dynamic);

        // Load a new attributes element buffer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexBufferElement(IntPtr buffer, int size, bool dynamic);

        // Update GPU buffer with new data
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

        // Set vertex attribute default value
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

        // Load texture in GPU
        // data refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTexture(IntPtr data, int width, int height, PixelFormat format, int mipmapCount);

        // Load depth texture/renderbuffer (to be attached to fbo)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTextureDepth(int width, int height, bool useRenderBuffer);

        // Load texture cubemap
        // data refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTextureCubemap(IntPtr data, int size, PixelFormat format);

        // Update GPU texture with new data
        // data refers to a const void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateTexture(uint id, int width, int height, PixelFormat format, IntPtr data);

        // Get OpenGL internal formats
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlGetGlTextureFormats(PixelFormat format, ref uint glInternalFormat, ref uint glFormat, ref uint glType);

        // Unload texture from GPU memory
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadTexture(uint id);

        // Generate mipmap data for selected texture
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlGenerateMipmaps(ref Texture2D texture);

        // Read texture pixel data
        // IntPtr refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rlReadTexturePixels(Texture2D texture);

        // Read screen pixel data (color buffer)
        // IntPtr refers to a unsigned char *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rlReadScreenPixels(int width, int height);


        // Framebuffer management (fbo)

        // Load an empty framebuffer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadFramebuffer(int width, int height);

        // Attach texture/renderbuffer to a framebuffer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlFramebufferAttach(uint fboId, uint texId, FramebufferAttachType attachType, FramebufferAttachTextureType texType, int mipLevel);

        // Verify framebuffer is complete
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlFramebufferComplete(uint id);

        // Delete framebuffer from GPU
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlUnloadFramebuffer(uint id);


        // Shaders management

        // Load shader from code strings
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadShaderCode(string vsCode, string fsCode);

        // Compile custom shader and return shader id (type: GL_VERTEX_SHADER, GL_FRAGMENT_SHADER)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlCompileShader(string shaderCode, int type);

        // Load custom shader program
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadShaderProgram(uint vShaderId, uint fShaderId);

        // Unload shader program
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadShaderProgram(uint id);

        // Get shader location uniform
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetLocationUniform(uint shaderId, string uniformName);

        // Get shader location attribute
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetLocationAttrib(uint shaderId, string attribName);

        // Set shader value uniform
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniform(int locIndex, IntPtr value, int uniformType, int count);

        // Set shader value matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniformMatrix(int locIndex, Matrix4x4 mat);

        // Set shader value sampler
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniformSampler(int locIndex, uint textureId);

        // Set shader currently active
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetShader(Shader shader);


        // Matrix state management

        // Get internal modelview matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixModelView();

        // Get internal projection matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixProjection();

        // Get internal accumulated transform matrix
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixTramsform();

        // Get internal projection matrix for stereo render (selected eye)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixProjectionStereo(int eye);

        // Get internal view offset matrix for stereo render (selected eye)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixViewOffsetStereo(int eye);

        // Set a custom projection matrix (replaces internal projection matrix)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixProjection(Matrix4x4 view);

        // Set a custom modelview matrix (replaces internal modelview matrix)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixModelView(Matrix4x4 proj);

        // Set eyes projection matrices for stereo rendering
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixProjectionStereo(Matrix4x4 left, Matrix4x4 right);

        // Set eyes view offsets matrices for stereo rendering
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixViewOffsetStereo(Matrix4x4 left, Matrix4x4 right);


        // Quick and dirty cube/quad buffers load->draw->unload

        // Load and draw a cube
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadDrawCube();

        // Load and draw a quad
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadDrawQuad();
    }
}
