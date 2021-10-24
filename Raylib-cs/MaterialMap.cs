using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Material texture map
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MaterialMap
    {
        /// <summary>
        /// Material map texture
        /// </summary>
        public Texture2D texture;

        /// <summary>
        /// Material map color
        /// </summary>
        public Color color;

        /// <summary>
        /// Material map value
        /// </summary>
        public float value;
    }
}