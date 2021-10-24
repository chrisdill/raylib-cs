using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Model type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Model
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
        public IntPtr meshes;

        /// <summary>
        /// Materials array (Material *)
        /// </summary>
        public IntPtr materials;

        /// <summary>
        /// Mesh material number (int *)
        /// </summary>
        public IntPtr meshMaterial;

        /// <summary>
        /// Number of bones
        /// </summary>
        public int boneCount;

        /// <summary>
        /// Bones information (skeleton, BoneInfo *)
        /// </summary>
        public IntPtr bones;

        /// <summary>
        /// Bones base transformation (pose, Transform *)
        /// </summary>
        public IntPtr bindPose;
    }
}