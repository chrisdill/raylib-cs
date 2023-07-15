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
        public uint SampleCount;

        /// <summary>
        /// Frequency (samples per second)
        /// </summary>
        public uint SampleRate;

        /// <summary>
        /// Bit depth (bits per sample): 8, 16, 32 (24 not supported)
        /// </summary>
        public uint SampleSize;

        /// <summary>
        /// Number of channels (1-mono, 2-stereo)
        /// </summary>
        public uint Channels;

        //TODO: SPAN<byte>  ?
        /// <summary>
        /// Buffer data pointer
        /// </summary>
        public void* Data;
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
        public IntPtr Buffer;

        /// <summary>
        /// Pointer to internal data processor, useful for audio effects
        /// </summary>
        public IntPtr Processor;

        /// <summary>
        /// Frequency (samples per second)
        /// </summary>
        public uint SampleRate;

        /// <summary>
        /// Bit depth (bits per sample): 8, 16, 32 (24 not supported)
        /// </summary>
        public uint SampleSize;

        /// <summary>
        /// Number of channels (1-mono, 2-stereo)
        /// </summary>
        public uint Channels;
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
        public AudioStream Stream;

        /// <summary>
        /// Total number of frames (considering channels)
        /// </summary>
        public uint FrameCount;
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
        public AudioStream Stream;

        /// <summary>
        /// Total number of samples
        /// </summary>
        public uint FrameCount;

        /// <summary>
        /// Music looping enable
        /// </summary>
        public CBool Looping;

        /// <summary>
        /// Type of music context (audio filetype)
        /// </summary>
        public int CtxType;

        //TODO span
        /// <summary>
        /// Audio context data, depends on type
        /// </summary>
        public void* CtxData;
    }
}
