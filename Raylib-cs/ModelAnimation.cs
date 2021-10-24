using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>Model animation</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ModelAnimation
    {
        /// <summary>
        /// Number of bones
        /// </summary>
        public int boneCount;

        /// <summary>
        /// Number of animation frames
        /// </summary>
        public int frameCount;

        /// <summary>
        /// Bones information (skeleton, BoneInfo *)
        /// </summary>
        public IntPtr bones;

        /// <summary>
        /// Poses array by frame (Transform **)
        /// </summary>
        public IntPtr framePoses;
    }
}