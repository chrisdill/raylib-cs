using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
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