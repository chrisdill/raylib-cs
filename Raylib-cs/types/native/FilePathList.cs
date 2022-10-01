using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// File path list
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FilePathList
    {
        /// <summary>
        /// Filepaths max entries
        /// </summary>
        public uint capacity;

        /// <summary>
        /// Filepaths entries count
        /// </summary>
        public uint count;

        /// <summary>
        /// Filepaths entries
        /// </summary>
        public byte** paths;
    }
}
