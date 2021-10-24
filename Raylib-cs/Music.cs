using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>Music stream type (audio file streaming from memory)
    /// NOTE: Anything longer than ~10 seconds should be streamed</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Music
    {
        /// <summary>
        /// Audio stream
        /// </summary>
        public AudioStream stream;

        /// <summary>
        /// Total number of samples
        /// </summary>
        public uint frameCount;

        /// <summary>
        /// Music looping enable
        /// </summary>
        public byte looping;

        /// <summary>
        /// Type of music context (audio filetype)
        /// </summary>
        public int ctxType;

        /// <summary>
        /// Audio context data, depends on type (void *)
        /// </summary>
        public IntPtr ctxData;
    }
}