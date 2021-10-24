using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Material type (generic)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Material
    {
        /// <summary>
        /// Material shader
        /// </summary>
        public Shader shader;

        /// <summary>
        /// Material maps (MaterialMap *)
        /// </summary>
        public IntPtr maps;

        /// <summary>
        /// Material generic parameters (if required, float *)
        /// </summary>
        public IntPtr param;
    }
}