using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>Wave type, defines audio wave data</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Wave
    {
        /// <summary>
        /// Number of samples
        /// </summary>
        public uint sampleCount;

        /// <summary>
        /// Frequency (samples per second)
        /// </summary>
        public uint sampleRate;

        /// <summary>
        /// Bit depth (bits per sample): 8, 16, 32 (24 not supported)
        /// </summary>
        public uint sampleSize;

        /// <summary>
        /// Number of channels (1-mono, 2-stereo)
        /// </summary>
        public uint channels;

        /// <summary>
        /// Buffer data pointer (void *)
        /// </summary>
        public IntPtr data;
    }
}