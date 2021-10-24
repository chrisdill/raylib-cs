using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>Head-Mounted-Display device parameters</summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VrDeviceInfo
    {
        /// <summary>
        /// HMD horizontal resolution in pixels
        /// </summary>
        public int hResolution;

        /// <summary>
        /// HMD vertical resolution in pixels
        /// </summary>
        public int vResolution;

        /// <summary>
        /// HMD horizontal size in meters
        /// </summary>
        public float hScreenSize;

        /// <summary>
        /// HMD vertical size in meters
        /// </summary>
        public float vScreenSize;

        /// <summary>
        /// HMD screen center in meters
        /// </summary>
        public float vScreenCenter;

        /// <summary>
        /// HMD distance between eye and display in meters
        /// </summary>
        public float eyeToScreenDistance;

        /// <summary>
        /// HMD lens separation distance in meters
        /// </summary>
        public float lensSeparationDistance;

        /// <summary>
        /// HMD IPD (distance between pupils) in meters
        /// </summary>
        public float interpupillaryDistance;

        /// <summary>
        /// HMD lens distortion constant parameters
        /// </summary>
        public fixed float lensDistortionValues[4];

        /// <summary>
        /// HMD chromatic aberration correction parameters
        /// </summary>
        public fixed float chromaAbCorrection[4];
    }
}