using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Rectangle type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        public float x;
        public float y;
        public float width;
        public float height;

        public Rectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

    /// <summary>Bounding box type</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox
    {
        /// <summary>
        /// Minimum vertex box-corner
        /// </summary>
        public Vector3 min;

        /// <summary>
        /// Maximum vertex box-corner
        /// </summary>
        public Vector3 max;

        public BoundingBox(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }
    }

    /// <summary>Ray, ray for raycasting</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Ray
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

    /// <summary>Raycast hit information</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RayCollision
    {
        /// <summary>
        /// Did the ray hit something?
        /// </summary>
        public byte hit;

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
