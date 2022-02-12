using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Transform, vectex transformation data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Transform
    {
        /// <summary>
        /// Translation
        /// </summary>
        public Vector3 translation;

        /// <summary>
        /// Rotation
        /// </summary>
        public Vector4 rotation;

        /// <summary>
        /// Scale
        /// </summary>
        public Vector3 scale;
    }
}
