using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    [SuppressUnmanagedCodeSecurity]
    public static unsafe partial class Rlgl
    {
        /// <summary>
        /// Used by DllImport to load the native library
        /// </summary>
        public const string NativeLibName = "raylib";

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
        public const int RL_TEXTURE_MIPMAP_BIAS_RATIO = 0x4000;

        public const int RL_TEXTURE_WRAP_REPEAT = 0x2901;
        public const int RL_TEXTURE_WRAP_CLAMP = 0x812F;
        public const int RL_TEXTURE_WRAP_MIRROR_REPEAT = 0x8370;
        public const int RL_TEXTURE_WRAP_MIRROR_CLAMP = 0x8742;

        // GL equivalent data types
        public const int RL_UNSIGNED_BYTE = 0x1401;
        public const int RL_FLOAT = 0x1406;

        // Buffer usage hint
        public const int RL_STREAM_DRAW = 0x88E0;
        public const int RL_STREAM_READ = 0x88E1;
        public const int RL_STREAM_COPY = 0x88E2;
        public const int RL_STATIC_DRAW = 0x88E4;
        public const int RL_STATIC_READ = 0x88E5;
        public const int RL_STATIC_COPY = 0x88E6;
        public const int RL_DYNAMIC_DRAW = 0x88E8;
        public const int RL_DYNAMIC_READ = 0x88E9;
        public const int RL_DYNAMIC_COPY = 0x88EA;

        // GL blending factors
        public const int RL_ZERO = 0;
        public const int RL_ONE = 1;
        public const int RL_SRC_COLOR = 0x0300;
        public const int RL_ONE_MINUS_SRC_COLOR = 0x0301;
        public const int RL_SRC_ALPHA = 0x0302;
        public const int RL_ONE_MINUS_SRC_ALPHA = 0x0303;
        public const int RL_DST_ALPHA = 0x0304;
        public const int RL_ONE_MINUS_DST_ALPHA = 0x0305;
        public const int RL_DST_COLOR = 0x0306;
        public const int RL_ONE_MINUS_DST_COLOR = 0x0307;
        public const int RL_SRC_ALPHA_SATURATE = 0x0308;
        public const int RL_CONSTANT_COLOR = 0x8001;
        public const int RL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
        public const int RL_CONSTANT_ALPHA = 0x8003;
        public const int RL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;

        // GL blending functions/equations
        public const int RL_FUNC_ADD = 0x8006;
        public const int RL_MIN = 0x8007;
        public const int RL_MAX = 0x8008;
        public const int RL_FUNC_SUBTRACT = 0x800A;
        public const int RL_FUNC_REVERSE_SUBTRACT = 0x800B;
        public const int RL_BLEND_EQUATION = 0x8009;
        public const int RL_BLEND_EQUATION_RGB = 0x8009;
        public const int RL_BLEND_EQUATION_ALPHA = 0x883D;
        public const int RL_BLEND_DST_RGB = 0x80C8;
        public const int RL_BLEND_SRC_RGB = 0x80C9;
        public const int RL_BLEND_DST_ALPHA = 0x80CA;
        public const int RL_BLEND_SRC_ALPHA = 0x80CB;
        public const int RL_BLEND_COLOR = 0x8005;

        // ------------------------------------------------------------------------------------
        // Functions Declaration - Matrix operations
        // ------------------------------------------------------------------------------------

        /// <summary>Choose the current matrix to be transformed</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlMatrixMode(int mode);

        /// <inheritdoc cref="RlMatrixMode(int)"/>
        public static void RlMatrixMode(MatrixMode mode)
        {
            RlMatrixMode((int)mode);
        }

        /// <summary>Push the current matrix to stack</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlPushMatrix();

        /// <summary>Pop lattest inserted matrix from stack</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlPopMatrix();

        /// <summary>Reset current matrix to identity matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlLoadIdentity();

        /// <summary>Multiply the current matrix by a translation matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlTranslatef(float x, float y, float z);

        /// <summary>Multiply the current matrix by a rotation matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlRotatef(float angle, float x, float y, float z);

        /// <summary>Multiply the current matrix by a scaling matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlScalef(float x, float y, float z);

        /// <summary>
        /// Multiply the current matrix by another matrix<br/>
        /// Current Matrix can be set via <see cref="RlMatrixMode(int)"/>
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlMultMatrixf(float* matf);

        /// <inheritdoc cref="RlMultMatrixf"/>
        public static void RlMultMatrixf(Matrix4x4 matf)
        {
            Float16 f = Raymath.MatrixToFloatV(matf);
            RlMultMatrixf(f.v);
        }

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlFrustum(
            double left,
            double right,
            double bottom,
            double top,
            double znear,
            double zfar
        );

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlOrtho(
            double left,
            double right,
            double bottom,
            double top,
            double znear,
            double zfar
        );

        /// <summary>Set the viewport area</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlViewport(int x, int y, int width, int height);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - Vertex level operations
        // ------------------------------------------------------------------------------------

        /// <summary>Initialize drawing mode (how to organize vertex)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlBegin(int mode);

        public static void RlBegin(DrawMode mode)
        {
            RlBegin((int)mode);
        }

        /// <summary>Finish vertex providing</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnd();

        /// <summary>Define one vertex (position) - 2 int</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlVertex2i(int x, int y);

        /// <summary>Define one vertex (position) - 2 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlVertex2f(float x, float y);

        /// <summary>Define one vertex (position) - 3 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlVertex3f(float x, float y, float z);

        /// <summary>Define one vertex (texture coordinate) - 2 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlTexCoord2f(float x, float y);

        /// <summary>Define one vertex (normal) - 3 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlNormal3f(float x, float y, float z);

        /// <summary>Define one vertex (color) - 4 byte</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlColor4ub(byte r, byte g, byte b, byte a);

        /// <summary>Define one vertex (color) - 3 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlColor3f(float x, float y, float z);

        /// <summary>Define one vertex (color) - 4 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlColor4f(float x, float y, float z, float w);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - OpenGL equivalent functions (common to 1.1, 3.3+, ES2)
        // NOTE: This functions are used to completely abstract raylib code from OpenGL layer
        // ------------------------------------------------------------------------------------

        /// <summary>Vertex buffers state</summary>

        /// <summary>Enable vertex array (VAO, if supported)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool RlEnableVertexArray(uint vaoId);

        /// <summary>Disable vertex array (VAO, if supported)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableVertexArray();

        /// <summary>Enable vertex buffer (VBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableVertexBuffer(uint id);

        /// <summary>Disable vertex buffer (VBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableVertexBuffer();

        /// <summary>Enable vertex buffer element (VBO element)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableVertexBufferElement(uint id);

        /// <summary>Disable vertex buffer element (VBO element)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableVertexBufferElement();

        /// <summary>Enable vertex attribute index</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableVertexAttribute(uint index);

        /// <summary>Disable vertex attribute index</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableVertexAttribute(uint index);

        /// <summary>Enable attribute state pointer<br/>
        /// NOTE: Only available for GRAPHICS_API_OPENGL_11</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableStatePointer(int vertexAttribType, void* buffer);

        /// <summary>Disable attribute state pointer<br/>
        /// NOTE: Only available for GRAPHICS_API_OPENGL_11</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableStatePointer(int vertexAttribType);


        // Textures state

        /// <summary>Select and active a texture slot</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlActiveTextureSlot(int slot);

        /// <summary>Enable texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableTexture(uint id);

        /// <summary>Disable texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableTexture();

        /// <summary>Enable texture cubemap</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableTextureCubemap(uint id);

        /// <summary>Disable texture cubemap</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableTextureCubemap();

        /// <summary>Set texture parameters (filter, wrap)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlTextureParameters(uint id, int param, int value);

        /// <summary>Set cubemap parameters (filter, wrap)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlCubemapParameters(uint id, int param, int value);


        // Shader state

        /// <summary>Enable shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableShader(uint id);

        /// <summary>Disable shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableShader();


        // Framebuffer state

        /// <summary>Enable render texture (fbo)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableFramebuffer(uint id);

        /// <summary>Disable render texture (fbo), return to default framebuffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableFramebuffer();

        /// <summary>Activate multiple draw color buffers</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlActiveDrawBuffers(int count);


        // General render state

        /// <summary>Enable color blending</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableColorBlend();

        /// <summary>Disable color blending</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableColorBlend();

        /// <summary>Enable depth test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableDepthTest();

        /// <summary>Disable depth test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableDepthTest();

        /// <summary>Enable depth write</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableDepthMask();

        /// <summary>Disable depth write</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableDepthMask();

        /// <summary>Enable backface culling</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableBackfaceCulling();

        /// <summary>Disable backface culling</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableBackfaceCulling();

        /// <summary>Set face culling mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetCullFace(int mode);

        /// <summary>Enable scissor test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableScissorTest();

        /// <summary>Disable scissor test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableScissorTest();

        /// <summary>Scissor test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlScissor(int x, int y, int width, int height);

        /// <summary>Enable wire mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableWireMode();

        /// <summary>Disable wire mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableWireMode();

        /// <summary>Set the line drawing width</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetLineWidth(float width);

        /// <summary>Get the line drawing width</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float RlGetLineWidth();

        /// <summary>Enable line aliasing</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableSmoothLines();

        /// <summary>Disable line aliasing</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableSmoothLines();

        /// <summary>Enable stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlEnableStereoRender();

        /// <summary>Disable stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDisableStereoRender();

        /// <summary>Check if stereo render is enabled</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool RlIsStereoRenderEnabled();

        /// <summary>Clear color buffer with color</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlClearColor(byte r, byte g, byte b, byte a);

        /// <summary>Clear used screen buffers (color and depth)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlClearScreenBuffers();

        /// <summary>Check and log OpenGL error codes</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlCheckErrors();

        /// <summary>Set blending mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetBlendMode(BlendMode mode);

        /// <summary>Set blending mode factor and equation (using OpenGL factors)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation);

        /// <summary>Set blending mode factors and equations separately (using OpenGL factors)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetBlendFactorsSeparate(
            int glSrcRGB,
            int glDstRGB,
            int glSrcAlpha,
            int glDstAlpha,
            int glEqRGB,
            int glEqAlpha
        );


        // ------------------------------------------------------------------------------------
        // Functions Declaration - rlgl functionality
        // ------------------------------------------------------------------------------------

        /// <summary>Initialize rlgl (buffers, shaders, textures, states)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlGlInit(int width, int height);

        /// <summary>De-inititialize rlgl (buffers, shaders, textures)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlGlClose();

        /// <summary>Load OpenGL extensions</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlLoadExtensions(void* loader);

        /// <summary>Get current OpenGL version</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlVersion RlGetVersion();

        /// <summary>Get default framebuffer width</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RlGetFramebufferWidth();

        /// <summary>Get default framebuffer height</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RlGetFramebufferHeight();

        /// <summary>Get default texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlGetTextureIdDefault();

        /// <summary>Get default shader</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlGetShaderIdDefault();

        /// <summary>Get default shader locations</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int* RlGetShaderLocsDefault();

        // Render batch management

        /// <summary>Load a render batch system<br/>
        /// NOTE: rlgl provides a default render batch to behave like OpenGL 1.1 immediate mode<br/>
        /// but this render batch API is exposed in case custom batches are required</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderBatch RlLoadRenderBatch(int numBuffers, int bufferElements);

        /// <summary>Unload render batch system</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUnloadRenderBatch(RenderBatch batch);

        /// <summary>Draw render batch data (Update->Draw->Reset)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDrawRenderBatch(RenderBatch* batch);

        /// <summary>Set the active render batch for rlgl (NULL for default internal)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetRenderBatchActive(RenderBatch* batch);

        /// <summary>Update and draw internal render batch</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDrawRenderBatchActive();

        /// <summary>Check internal buffer overflow for a given number of vertex</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool RlCheckRenderBatchLimit(int vCount);

        /// <summary>Set current texture for render batch and check buffers limits</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetTexture(uint id);


        // Vertex buffers management

        /// <summary>Load vertex array (vao) if supported</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadVertexArray();

        /// <summary>Load a vertex buffer attribute</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadVertexBuffer(void* buffer, int size, CBool dynamic);

        /// <summary>Load a new attributes element buffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadVertexBufferElement(void* buffer, int size, CBool dynamic);

        /// <summary>Update GPU buffer with new data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUpdateVertexBuffer(uint bufferId, void* data, int dataSize, int offset);

        /// <summary>Update vertex buffer elements with new data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUpdateVertexBufferElements(uint id, void* data, int dataSize, int offset);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUnloadVertexArray(uint vaoId);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUnloadVertexBuffer(uint vboId);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetVertexAttribute(
            uint index,
            int compSize,
            int type,
            CBool normalized,
            int stride,
            void* pointer
        );

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetVertexAttributeDivisor(uint index, int divisor);

        /// <summary>Set vertex attribute default value</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetVertexAttributeDefault(int locIndex, void* value, int attribType, int count);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDrawVertexArray(int offset, int count);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDrawVertexArrayElements(int offset, int count, void* buffer);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDrawVertexArrayInstanced(int offset, int count, int instances);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlDrawVertexArrayElementsInstanced(
            int offset,
            int count,
            void* buffer,
            int instances
        );


        // Textures data management

        /// <summary>Load texture in GPU</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadTexture(void* data, int width, int height, PixelFormat format, int mipmapCount);

        /// <summary>Load depth texture/renderbuffer (to be attached to fbo)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadTextureDepth(int width, int height, CBool useRenderBuffer);

        /// <summary>Load texture cubemap</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadTextureCubemap(void* data, int size, PixelFormat format);

        /// <summary>Update GPU texture with new data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUpdateTexture(
            uint id,
            int offsetX,
            int offsetY,
            int width,
            int height,
            PixelFormat format,
            void* data
        );

        /// <summary>Get OpenGL internal formats</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlGetGlTextureFormats(
            PixelFormat format,
            int* glInternalFormat,
            int* glFormat,
            int* glType
        );

        /// <summary>Get OpenGL internal formats</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* RlGetPixelFormatName(PixelFormat format);

        /// <summary>Unload texture from GPU memory</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUnloadTexture(uint id);

        /// <summary>Generate mipmap data for selected texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlGenTextureMipmaps(uint id, int width, int height, PixelFormat format, int* mipmaps);

        /// <summary>Read texture pixel data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* RlReadTexturePixels(uint id, int width, int height, PixelFormat format);

        /// <summary>Read screen pixel data (color buffer)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* RlReadScreenPixels(int width, int height);


        // Framebuffer management (fbo)

        /// <summary>Load an empty framebuffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadFramebuffer(int width, int height);

        /// <summary>Attach texture/renderbuffer to a framebuffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlFramebufferAttach(
            uint fboId,
            uint texId,
            FramebufferAttachType attachType,
            FramebufferAttachTextureType texType,
            int mipLevel
        );

        /// <summary>Verify framebuffer is complete</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool RlFramebufferComplete(uint id);

        /// <summary>Delete framebuffer from GPU</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUnloadFramebuffer(uint id);


        // Shaders management

        /// <summary>Load shader from code strings</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadShaderCode(sbyte* vsCode, sbyte* fsCode);

        /// <summary>Compile custom shader and return shader id<br/>
        /// (type: RL_VERTEX_SHADER, RL_FRAGMENT_SHADER, RL_COMPUTE_SHADER)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlCompileShader(sbyte* shaderCode, int type);

        /// <summary>Load custom shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadShaderProgram(uint vShaderId, uint fShaderId);

        /// <summary>Unload shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUnloadShaderProgram(uint id);

        /// <summary>Get shader location uniform</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RlGetLocationUniform(uint shaderId, sbyte* uniformName);

        /// <summary>Get shader location attribute</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RlGetLocationAttrib(uint shaderId, sbyte* attribName);

        /// <summary>Set shader value uniform</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetUniform(int locIndex, void* value, int uniformType, int count);

        /// <summary>Set shader value matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetUniformMatrix(int locIndex, Matrix4x4 mat);

        /// <summary>Set shader value sampler</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetUniformSampler(int locIndex, uint textureId);

        /// <summary>Set shader currently active (id and locations)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetShader(uint id, int* locs);


        // Compute shader management

        /// <summary>Load compute shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadComputeShaderProgram(uint shaderId);

        /// <summary>Dispatch compute shader (equivalent to *draw* for graphics pilepine)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlComputeShaderDispatch(uint groupX, uint groupY, uint groupZ);


        // Shader buffer storage object management (ssbo)

        /// <summary>Load shader storage buffer object (SSBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlLoadShaderBuffer(uint size, void* data, int usageHint);

        /// <summary>Unload shader storage buffer object (SSBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUnloadShaderBuffer(uint ssboId);

        /// <summary>Update SSBO buffer data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlUpdateShaderBuffer(uint id, void* data, uint dataSize, uint offset);

        /// <summary>Bind SSBO buffer data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlBindShaderBuffer(uint id, uint index);

        /// <summary>Read SSBO buffer data (GPU->CPU)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlReadShaderBuffer(uint id, void* dest, uint count, uint offset);

        /// <summary>Copy SSBO data between buffers</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlCopyShaderBuffer(
            uint destId,
            uint srcId,
            uint destOffset,
            uint srcOffset,
            uint count
        );

        /// <summary>Get SSBO buffer size</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RlGetShaderBufferSize(uint id);


        // Buffer management

        /// <summary>Bind image texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlBindImageTexture(uint id, uint index, int format, CBool readOnly);


        // Matrix state management

        /// <summary>Get internal modelview matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 RlGetMatrixModelView();

        /// <summary>Get internal projection matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 RlGetMatrixProjection();

        /// <summary>Get internal accumulated transform matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 RlGetMatrixTransform();

        /// <summary>Get internal projection matrix for stereo render (selected eye)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 RlGetMatrixProjectionStereo(int eye);

        /// <summary>Get internal view offset matrix for stereo render (selected eye)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 RlGetMatrixViewOffsetStereo(int eye);

        /// <summary>Set a custom projection matrix (replaces internal projection matrix)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetMatrixProjection(Matrix4x4 view);

        /// <summary>Set a custom modelview matrix (replaces internal modelview matrix)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetMatrixModelView(Matrix4x4 proj);

        /// <summary>Set eyes projection matrices for stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetMatrixProjectionStereo(Matrix4x4 left, Matrix4x4 right);

        /// <summary>Set eyes view offsets matrices for stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlSetMatrixViewOffsetStereo(Matrix4x4 left, Matrix4x4 right);


        // Quick and dirty cube/quad buffers load->draw->unload

        /// <summary>Load and draw a cube</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlLoadDrawCube();

        /// <summary>Load and draw a quad</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RlLoadDrawQuad();
    }
}
