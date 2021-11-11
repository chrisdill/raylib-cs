using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Wave type, defines audio wave data
    /// </summary>
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

    /// <summary>
    /// Audio stream type<br/>
    /// NOTE: Useful to create custom audio streams not bound to a specific file
    /// </summary>
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

    /// <summary>
    /// Sound source type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Sound
    {
        /// <summary>
        /// Audio stream
        /// </summary>
        public AudioStream stream;

        /// <summary>
        /// Total number of frames (considering channels)
        /// </summary>
        public uint frameCount;
    }

    /// <summary>
    /// Music stream type (audio file streaming from memory)<br/>
    /// NOTE: Anything longer than ~10 seconds should be streamed
    /// </summary>
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
