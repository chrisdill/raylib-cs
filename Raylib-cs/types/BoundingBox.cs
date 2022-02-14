using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>Bounding box type</summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct BoundingBox
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
}
