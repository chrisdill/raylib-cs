using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Bone information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct BoneInfo
    {
        /// <summary>
        /// Bone name (char[32])
        /// </summary>
        public fixed sbyte name[32];

        /// <summary>
        /// Bone parent
        /// </summary>
        public int parent;
    }

    /// <summary>
    /// Model type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct Model
    {
        /// <summary>
        /// Local transform matrix
        /// </summary>
        public Matrix4x4 transform;

        /// <summary>
        /// Number of meshes
        /// </summary>
        public int meshCount;

        /// <summary>
        /// Number of materials
        /// </summary>
        public int materialCount;

        /// <summary>
        /// Meshes array (Mesh *)
        /// </summary>
        public Mesh* meshes;

        /// <summary>
        /// Materials array (Material *)
        /// </summary>
        public Material* materials;

        /// <summary>
        /// Mesh material number (int *)
        /// </summary>
        public int* meshMaterial;

        /// <summary>
        /// Number of bones
        /// </summary>
        public int boneCount;

        //TODO: Span
        /// <summary>
        /// Bones information (skeleton, BoneInfo *)
        /// </summary>
        public BoneInfo* bones;

        //TODO: Span
        /// <summary>
        /// Bones base transformation (pose, Transform *)
        /// </summary>
        public Transform* bindPose;
    }

    /// <summary>
    /// Model animation
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe partial struct ModelAnimation
    {
        /// <summary>
        /// Number of bones
        /// </summary>
        public readonly int boneCount;

        /// <summary>
        /// Number of animation frames
        /// </summary>
        public readonly int frameCount;

        /// <summary>
        /// Bones information (skeleton, BoneInfo *)
        /// </summary>
        public readonly BoneInfo* bones;

        /// <inheritdoc cref="bones"/>
        public ReadOnlySpan<BoneInfo> BoneInfo => new(bones, boneCount);

        /// <summary>
        /// Poses array by frame (Transform **)
        /// </summary>
        public readonly Transform** framePoses;

        /// <inheritdoc cref="framePoses"/>
        public FramePosesCollection FramePoses => new(framePoses, frameCount, boneCount);

        public struct FramePosesCollection
        {
            readonly Transform** framePoses;

            readonly int frameCount;

            readonly int boneCount;

            public FramePoses this[int index] => new(framePoses[index], boneCount);

            public Transform this[int index1, int index2] => new FramePoses(framePoses[index1], boneCount)[index2];

            internal FramePosesCollection(Transform** framePoses, int frameCount, int boneCount)
            {
                this.framePoses = framePoses;
                this.frameCount = frameCount;
                this.boneCount = boneCount;
            }
        }
    }

    public unsafe struct FramePoses
    {
        readonly Transform* poses;

        readonly int count;

        public ref Transform this[int index]
        {
            get
            {
                return ref poses[index];
            }
        }

        internal FramePoses(Transform* poses, int count)
        {
            this.poses = poses;
            this.count = count;
        }
    }
}
