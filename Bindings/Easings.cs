// Easings - https://github.com/raysan5/raylib/blob/master/src/easings.h

using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    public static partial class Raylib
    {
        #region Raylib-cs Functions

        // Linear Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseLinearNone(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseLinearIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseLinearOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseLinearInOut(float t, float b, float c, float d);

        // Sine Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseSineIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseSineOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseSineInOut(float t, float b, float c, float d);

        // Circular Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseCircIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseCircOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseCircInOut(float t, float b, float c, float d);

        // Cubic Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseCubicIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseCubicOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseCubicInOut(float t, float b, float c, float d);

        // Quadratic Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseQuadIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseQuadOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseQuadInOut(float t, float b, float c, float d);

        // Exponential Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseExpoIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseExpoOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseExpoInOut(float t, float b, float c, float d);

        // Back Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseBackIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseBackOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseBackInOut(float t, float b, float c, float d);

        // Bounce Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseBounceOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseBounceIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseBounceInOut(float t, float b, float c, float d); 

        // Elastic Easing functions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseElasticIn(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseElasticOut(float t, float b, float c, float d);

        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float EaseElasticInOut(float t, float b, float c, float d);

        #endregion
    }
}
