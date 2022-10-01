using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Wave type, defines audio wave data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct Wave
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

        //TODO: SPAN<byte>  ?
        /// <summary>
        /// Buffer data pointer
        /// </summary>
        public void* data;
    }

    /// <summary>
    /// Audio stream type<br/>
    /// NOTE: Useful to create custom audio streams not bound to a specific file
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct AudioStream
    {
        //TODO: convert
        /// <summary>
        /// Pointer to internal data(rAudioBuffer *) used by the audio system
        /// </summary>
        public IntPtr buffer;

        /// <summary>
        /// Pointer to internal data processor, useful for audio effects
        /// </summary>
        public IntPtr processor;

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
    public partial struct Sound
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
    public unsafe partial struct Music
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
        public CBool looping;

        /// <summary>
        /// Type of music context (audio filetype)
        /// </summary>
        public int ctxType;

        //TODO span
        /// <summary>
        /// Audio context data, depends on type
        /// </summary>
        public void* ctxData;
    }
}
