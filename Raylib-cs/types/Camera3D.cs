using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Camera system modes
    /// </summary>
    public enum CameraMode
    {
        CAMERA_CUSTOM = 0,
        CAMERA_FREE,
        CAMERA_ORBITAL,
        CAMERA_FIRST_PERSON,
        CAMERA_THIRD_PERSON
    }

    /// <summary>
    /// Camera projection
    /// </summary>
    public enum CameraProjection
    {
        CAMERA_PERSPECTIVE = 0,
        CAMERA_ORTHOGRAPHIC
    }

    /// <summary>
    /// Camera3D, defines position/orientation in 3d space
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Camera3D
    {
        /// <summary>
        /// Camera position
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// Camera target it looks-at
        /// </summary>
        public Vector3 target;

        /// <summary>
        /// Camera up vector (rotation over its axis)
        /// </summary>
        public Vector3 up;

        /// <summary>
        /// Camera field-of-view apperture in Y (degrees) in perspective, used as near plane width in orthographic
        /// </summary>
        public float fovy;

        /// <summary>
        /// Camera type, defines projection type: CAMERA_PERSPECTIVE or CAMERA_ORTHOGRAPHIC
        /// </summary>
        public CameraProjection projection;

        public Camera3D(Vector3 position, Vector3 target, Vector3 up, float fovy, CameraProjection projection)
        {
            this.position = position;
            this.target = target;
            this.up = up;
            this.fovy = fovy;
            this.projection = projection;
        }
    }
}
