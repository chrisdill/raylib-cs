using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Shader type (generic)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Shader
    {
        /// <summary>
        /// Shader program id
        /// </summary>
        public uint id;

        /// <summary>
        /// Shader locations array (MAX_SHADER_LOCATIONS,  int *)
        /// </summary>
        public IntPtr locs;
    }
}