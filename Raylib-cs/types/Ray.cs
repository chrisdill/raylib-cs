using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Ray, ray for raycasting
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Ray
    {
        /// <summary>
        /// Ray position (origin)
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// Ray direction
        /// </summary>
        public Vector3 direction;

        public Ray(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }

    /// <summary>
    /// Raycast hit information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct RayCollision
    {
        /// <summary>
        /// Did the ray hit something?
        /// </summary>
        public CBool hit;

        /// <summary>
        /// Distance to nearest hit
        /// </summary>
        public float distance;

        /// <summary>
        /// Position of nearest hit
        /// </summary>
        public Vector3 point;

        /// <summary>
        /// Surface normal of hit
        /// </summary>
        public Vector3 normal;
    }
}
