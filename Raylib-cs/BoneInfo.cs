using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Bone information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BoneInfo
    {
        /// <summary>
        /// Bone name (char[32])
        /// </summary>
        public IntPtr name;

        /// <summary>
        /// Bone parent
        /// </summary>
        public int parent;
    }
}