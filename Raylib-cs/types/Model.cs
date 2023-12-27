using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs;

/// <summary>
/// Bone information
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BoneInfo
{
    /// <summary>
    /// Bone name (char[32])
    /// </summary>
    public fixed sbyte Name[32];

    /// <summary>
    /// Bone parent
    /// </summary>
    public int Parent;
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
    public Matrix4x4 Transform;

    /// <summary>
    /// Number of meshes
    /// </summary>
    public int MeshCount;

    /// <summary>
    /// Number of materials
    /// </summary>
    public int MaterialCount;

    /// <summary>
    /// Meshes array (Mesh *)
    /// </summary>
    public Mesh* Meshes;

    /// <summary>
    /// Materials array (Material *)
    /// </summary>
    public Material* Materials;

    /// <summary>
    /// Mesh material number (int *)
    /// </summary>
    public int* MeshMaterial;

    /// <summary>
    /// Number of bones
    /// </summary>
    public int BoneCount;

    //TODO: Span
    /// <summary>
    /// Bones information (skeleton, BoneInfo *)
    /// </summary>
    public BoneInfo* Bones;

    //TODO: Span
    /// <summary>
    /// Bones base transformation (pose, Transform *)
    /// </summary>
    public Transform* BindPose;
}

/// <summary>
/// Model animation
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ModelAnimation
{
    /// <summary>
    /// Number of bones
    /// </summary>
    public readonly int BoneCount;

    /// <summary>
    /// Number of animation frames
    /// </summary>
    public readonly int FrameCount;

    /// <summary>
    /// Bones information (skeleton, BoneInfo *)
    /// </summary>
    public readonly BoneInfo* Bones;

    /// <inheritdoc cref="Bones"/>
    public ReadOnlySpan<BoneInfo> BoneInfo => new(Bones, BoneCount);

    /// <summary>
    /// Poses array by frame (Transform **)
    /// </summary>
    public readonly Transform** FramePoses;

    /// <summary>
    /// Animation name (char[32])
    /// </summary>
    public fixed sbyte Name[32];

    /// <inheritdoc cref="FramePoses"/>
    public FramePosesCollection FramePosesColl => new(FramePoses, FrameCount, BoneCount);

    public struct FramePosesCollection
    {
        readonly Transform** _framePoses;

        readonly int _frameCount;

        readonly int _boneCount;

        public FramePoses this[int index] => new(_framePoses[index], _boneCount);

        public Transform this[int index1, int index2] => new FramePoses(_framePoses[index1], _boneCount)[index2];

        internal FramePosesCollection(Transform** framePoses, int frameCount, int boneCount)
        {
            this._framePoses = framePoses;
            this._frameCount = frameCount;
            this._boneCount = boneCount;
        }
    }
}

public unsafe struct FramePoses
{
    readonly Transform* _poses;

    readonly int _count;

    public ref Transform this[int index] => ref _poses[index];

    internal FramePoses(Transform* poses, int count)
    {
        this._poses = poses;
        this._count = count;
    }
}
