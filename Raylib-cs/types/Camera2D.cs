using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Camera2D, defines position/orientation in 2d space
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Camera2D
    {
        /// <summary>
        /// Camera offset (displacement from target)
        /// </summary>
        public Vector2 offset;

        /// <summary>
        /// Camera target (rotation and zoom origin)
        /// </summary>
        public Vector2 target;

        /// <summary>
        ///  Camera rotation in degrees
        /// </summary>
        public float rotation;

        /// <summary>
        /// Camera zoom (scaling), should be 1.0f by default
        /// </summary>
        public float zoom;

        public Camera2D(Vector2 offset, Vector2 target, float rotation, float zoom)
        {
            this.offset = offset;
            this.target = target;
            this.rotation = rotation;
            this.zoom = zoom;
        }
    }
}
