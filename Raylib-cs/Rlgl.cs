using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    // ----------------------------------------------------------------------------------
    // Types and Structures Definition
    // ----------------------------------------------------------------------------------
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

    public enum FramebufferTexType
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
        public const int RL_TEXTURE_WRAP_S = 0x2802;
        public const int RL_TEXTURE_WRAP_T = 0x2803;
        public const int RL_TEXTURE_MAG_FILTER = 0x2800;
        public const int RL_TEXTURE_MIN_FILTER = 0x2801;
        public const int RL_TEXTURE_ANISOTROPIC_FILTER = 0x3000;
        public const int RL_FILTER_NEAREST = 0x2600;
        public const int RL_FILTER_LINEAR = 0x2601;
        public const int RL_FILTER_MIP_NEAREST = 0x2700;
        public const int RL_FILTER_NEAREST_MIP_LINEAR = 0x2702;
        public const int RL_FILTER_LINEAR_MIP_NEAREST = 0x2701;
        public const int RL_FILTER_MIP_LINEAR = 0x2703;
        public const int RL_WRAP_REPEAT = 0x2901;
        public const int RL_WRAP_CLAMP = 0x812F;
        public const int RL_WRAP_MIRROR_REPEAT = 0x8370;
        public const int RL_WRAP_MIRROR_CLAMP = 0x8742;
        public const int RL_MODELVIEW = 0x1700;
        public const int RL_PROJECTION = 0x1701;
        public const int RL_TEXTURE = 0x1702;
        public const int RL_LINES = 0x0001;
        public const int RL_TRIANGLES = 0x0004;
        public const int RL_QUADS = 0x0007;

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

        // Enable texture usage
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableTexture(uint id);

        // Disable texture usage
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableTexture();

        // Set texture parameters (filter, wrap)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTextureParameters(uint id, int param, int value);

        // Enable render texture (fbo)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableFramebuffer(uint id);

        // Disable render texture (fbo), return to default framebuffer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableFramebuffer();

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

        // Clear color buffer with color
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearColor(byte r, byte g, byte b, byte a);

        // Clear used screen buffers (color and depth)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearScreenBuffers();

        // Update GPU buffer with new data
        // data refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateBuffer(int bufferId, IntPtr data, int dataSize);

        // Load a new attributes buffer
        // buffer refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadAttribBuffer(uint vaoId, int shaderLoc, IntPtr buffer, int size, bool dynamic);

        // ------------------------------------------------------------------------------------
        // Functions Declaration - rlgl functionality
        // ------------------------------------------------------------------------------------

        // Initialize rlgl (buffers, shaders, textures, states)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglInit(int width, int height);

        // De-inititialize rlgl (buffers, shaders, textures)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglClose();

        // Update and draw default internal buffers
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglDraw();

        // Check and log OpenGL error codes
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlCheckErrors();

        // Returns current OpenGL version
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlVersion rlGetVersion();

        // Check internal buffer overflow for a given number of vertex
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlCheckBufferLimit(int vCount);

        // Set debug marker for analysis
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetDebugMarker(string text);

        // Set blending mode factor and equation (using OpenGL factors)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendMode(int glSrcFactor, int glDstFactor, int glEquation);

        // Load OpenGL extensions
        // loader refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadExtensions(IntPtr loader);


        // Textures data management

        // Load texture in GPU
        // data refers to a void *
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTexture(IntPtr data, int width, int height, PixelFormat format, int mipmapCount);

        // Load depth texture/renderbuffer (to be attached to fbo)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTextureDepth(int width, int height, int bits, bool useRenderBuffer);

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
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte[] rlReadScreenPixels(int width, int height);


        // Framebuffer management (fbo)

        // Load an empty framebuffer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadFramebuffer(int width, int height);

        // Attach texture/renderbuffer to a framebuffer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlFramebufferAttach(uint fboId, uint texId, FramebufferAttachType attachType, FramebufferTexType texType);

        // Verify framebuffer is complete
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlFramebufferComplete(uint id);

        // Delete framebuffer from GPU
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool rlUnloadFramebuffer(uint id);

        // Vertex data management
        // Upload vertex data into GPU and provided VAO/VBO ids
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadMesh(ref Mesh mesh, bool dynamic);

        // Update vertex or index data on GPU (upload new data to one buffer)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateMesh(Mesh mesh, int buffer, int num);

        // Update vertex or index data on GPU, at index
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateMeshAt(Mesh mesh, int buffer, int num, int index);

        // Draw a 3d mesh with material and transform
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawMesh(Mesh mesh, Material material, Matrix4x4 transform);

        // Draw a 3d mesh with material and transform
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawMeshInstanced(Mesh mesh, Material material, Matrix4x4[] transforms, int count);

        // Unload mesh data from CPU and GPU
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadMesh(Mesh mesh);
    }
}
