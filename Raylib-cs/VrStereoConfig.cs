using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>VR Stereo rendering configuration for simulator</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VrStereoConfig
    {
        /// <summary>
        /// VR projection matrices (per eye)
        /// </summary>
        public Matrix4x4 projection1;

        /// <summary>
        /// VR projection matrices (per eye)
        /// </summary>
        public Matrix4x4 projection2;

        /// <summary>
        /// VR view offset matrices (per eye)
        /// </summary>
        public Matrix4x4 viewOffset1;

        /// <summary>
        /// VR view offset matrices (per eye)
        /// </summary>
        public Matrix4x4 viewOffset2;

        /// <summary>
        /// VR left lens center
        /// </summary>
        public Vector2 leftLensCenter;

        /// <summary>
        /// VR right lens center
        /// </summary>
        public Vector2 rightLensCenter;

        /// <summary>
        /// VR left screen center
        /// </summary>
        public Vector2 leftScreenCenter;

        /// <summary>
        /// VR right screen center
        /// </summary>
        public Vector2 rightScreenCenter;

        /// <summary>
        /// VR distortion scale
        /// </summary>
        public Vector2 scale;

        /// <summary>
        /// VR distortion scale in
        /// </summary>
        public Vector2 scaleIn;
    }
}