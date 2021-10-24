using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// N-Patch layout info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NPatchInfo
    {
        /// <summary>
        /// Texture source rectangle
        /// </summary>
        public Rectangle source;

        /// <summary>
        /// Left border offset
        /// </summary>
        public int left;

        /// <summary>
        /// Top border offset
        /// </summary>
        public int top;

        /// <summary>
        /// Right border offset
        /// </summary>
        public int right;

        /// <summary>
        /// Bottom border offset
        /// </summary>
        public int bottom;

        /// <summary>
        /// Layout of the n-patch: 3x3, 1x3 or 3x1
        /// </summary>
        public NPatchLayout layout;
    }
}