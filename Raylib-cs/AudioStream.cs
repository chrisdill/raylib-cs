using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>Audio stream type
    /// NOTE: Useful to create custom audio streams not bound to a specific file</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioStream
    {
        /// <summary>
        /// Pointer to internal data(rAudioBuffer *) used by the audio system
        /// </summary>
        public IntPtr audioBuffer;

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
    }
}