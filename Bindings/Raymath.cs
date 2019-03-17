/* Raylib-cs
 * Raymath.cs - Core bindings to raymth
 * Copyright 2019 Chris Dill
 *
 * Release under zLib License.
 * See LICENSE for details.
 */

using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    // Vector2 type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public partial struct Vector2
    {
        public float x;
        public float y;
    }

    // Vector3 type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public partial struct Vector3
    {
        public float x;
        public float y;
        public float z;
    }

    // Vector4 type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public partial struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    // Matrix type (OpenGL style 4x4 - right handed, column major)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Matrix
    {
        public float m0, m4, m8, m12;
        public float m1, m5, m9, m13;
        public float m2, m6, m10, m14;
        public float m3, m7, m11, m15;

        public override string ToString()
        {
            return $"Matrix({m0}, {m4}, {m8}, {m12}\n       {m1}, {m5}, {m9}, {m13}\n      {m2}, {m6}, {m10}, {m14}\n      {m3}, {m7}, {m11}, {m15})";
        }
    }

    // Quaternion type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public override string ToString()
        {
            return "Quaternion(" + x + " " + y + " " + z + " " + w + ")";
        }
    }

    public static partial class Raylib
    {
        // Clamp float value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Clamp(float value, float min, float max);

        /// <summary>
        /// Linearly interpolates between two values.
        /// </summary>
        /// <param name="value1">Source value.</param>
        /// <param name="value2">Source value.</param>
        /// <param name="amount">
        /// Value between 0 and 1 indicating the weight of value2.
        /// </param>
        /// <returns>Interpolated value.</returns>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <c>value1 + (value2 - value1) * amount</c>
        /// Passing amount a value of 0 will cause value1 to be returned, a value of 1 will
        /// cause value2 to be returned.
        /// </remarks>
        public static float Lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        // Vector with components value 0.0f
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Zero();

        // Vector with components value 1.0f
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2One();

        // Add two vectors (v1 + v2)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Add(Vector2 v1, Vector2 v2);

        // Subtract two vectors (v1 - v2)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Subtract(Vector2 v1, Vector2 v2);

        // Calculate vector length
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Vector2Length(Vector2 v);

        // Calculate two vectors dot product
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Vector2DotProduct(Vector2 v1, Vector2 v2);

        // Calculate distance between two vectors
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Vector2Distance(Vector2 v1, Vector2 v2);

        // Calculate angle from two vectors in X-axis
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Vector2Angle(Vector2 v1, Vector2 v2);

        // Scale vector (multiply by value)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Scale(Vector2 v, float scale);

        // Multiply vector by a vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Multiplyv(Vector2 v1, Vector2 v2);

        // Negate vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Negate(Vector2 v);

        // Divide vector by a float value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Divide(Vector2 v, float div);

        // Divide vector by a vector
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2DivideV(Vector2 v1, Vector2 v2);

        // Normalize provided vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 Vector2Normalize(Vector2 v);

        // Vector with components value 0.0f
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Zero();

        // Vector with components value 1.0f
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3One();

        // Add two vectors
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Add(Vector3 v1, Vector3 v2);

        // Substract two vectors
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Subtract(Vector3 v1, Vector3 v2);

        // Multiply vector by scalar
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Multiply(Vector3 v, float scalar);

        // Multiply vector by vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3MultiplyV(Vector3 v1, Vector3 v2);

        // Calculate two vectors cross product
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3CrossProduct(Vector3 v1, Vector3 v2);

        // Calculate one vector perpendicular vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Perpendicular(Vector3 v);

        // Calculate vector length
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Vector3Length(Vector3 v);

        // Calculate two vectors dot product
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Vector3DotProduct(Vector3 v1, Vector3 v2);

        // Calculate distance between two vectors
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float Vector3Distance(Vector3 v1, Vector3 v2);

        // Scale provided vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Scale(Vector3 v, float scale);

        // Negate provided vector (invert direction)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Negate(Vector3 v);

        // Divide vector by a float value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Divide(Vector3 v, float div);

        // Divide vector by a vector
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3DivideV(Vector3 v1, Vector3 v2);

        // Normalize provided vector
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Normalize(Vector3 v);

        // Orthonormalize provided vectors
        // Makes vectors normalized and orthogonal to each other
        // Gram-Schmidt function implementation
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vector3OrthoNormalize(out Vector3 v1, out Vector3 v2);

        // Transforms a Vector3 by a given Matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Transform(Vector3 v, Matrix mat);

        // Transform a vector by quaternion rotation
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3RotateByQuaternion(Vector3 v, Quaternion q);
        
        // Calculate linear interpolation between two vectors
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Lerp(Vector3 v1, Vector3 v2, float amount);
        
        // Calculate reflected vector to normal
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Reflect(Vector3 v, Vector3 normal);
        
        // Return min value for each pair of components
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Min(Vector3 v1, Vector3 v2);
        
        // Return max value for each pair of components
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Max(Vector3 v1, Vector3 v2);
        
        // Compute barycenter coordinates (u, v, w) for point p with respect to triangle (a, b, c)
        // NOTE: Assumes P is on the plane of the triangle
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 Vector3Barycenter(Vector3 p, Vector3 a, Vector3 b, Vector3 c);
        
        // Returns Vector3 as float array
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float[] Vector3ToFloatV(Vector3 v);

        // Compute matrix determinant
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float MatrixDeterminant(Matrix mat);

        // Returns the trace of the matrix (sum of the values along the diagonal)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float MatrixTrace(Matrix mat);

        // Transposes provided matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixTranspose(Matrix mat);

        // Invert provided matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixInvert(Matrix mat);
        
        // Normalize provided matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixNormalize(Matrix mat);
        
        // Returns identity matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixIdentity();

        // Add two matrices
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixAdd(Matrix left, Matrix right);
        
        // Substract two matrices (left - right)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixSubstract(Matrix left, Matrix right);
        
        // Create rotation matrix from axis and angle
        // NOTE: Angle should be provided in radians
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixTranslate(float x, float y, float z);
       
        // Returns x-rotation matrix (angle in radians)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixRotate(Vector3 axis, float angle);

        // Returns x-rotation matrix (angle in radians)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixRotateX(float angle);

        // Returns y-rotation matrix (angle in radians)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixRotateY(float angle);

        // Returns z-rotation matrix (angle in radians)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixRotateZ(float angle);

        // Returns scaling matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixScale(float x, float y, float z);
        
        // Returns two matrix multiplication
        // NOTE: When multiplying matrices... the order matters!
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixMultiply(Matrix left, Matrix right);
        
        // Returns perspective projection matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixFrustum(double left, double right, double bottom, double top, double near, double far);

        // Returns perspective projection matrix
        // NOTE: Angle should be provided in radians
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixPerspective(double fovy, double aspect, double near, double far);
        
        // Returns orthographic projection matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixOrtho(double left, double right, double bottom, double top, double near, double far);
        
        // Returns camera look-at matrix (view matrix)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix MatrixLookAt(Vector3 eye, Vector3 target, Vector3 up);
        
        // Returns float array of matrix data
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float[] MatrixToFloatV(Matrix mat);
            
        // Returns identity quaternion
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionIdentity();
        
        // Computes the length of a quaternion
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float QuaternionLength(Quaternion q);
        
        // Normalize provided quaternion
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionNormalize(Quaternion q);
        
        // Invert provided quaternion
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionInvert(Quaternion q);
        
        // Calculate two quaternion multiplication
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionMultiply(Quaternion q1, Quaternion q2);
        
        // Calculate linear interpolation between two quaternions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionLerp(Quaternion q1, Quaternion q2, float amount);

        // Calculate slerp-optimized interpolation between two quaternions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionNlerp(Quaternion q1, Quaternion q2, float amount);
       
        // Calculates spherical linear interpolation between two quaternions
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionSlerp(Quaternion q1, Quaternion q2, float amount);
        
        // Calculate quaternion based on the rotation from one vector to another
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionFromVector3ToVector3(Vector3 from, Vector3 to);
        
        // Returns a quaternion for a given rotation matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionFromMatrix(Matrix mat);
       
        // Returns a matrix for a given quaternion
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix QuaternionToMatrix(Quaternion q);

        // Returns rotation quaternion for an angle and axis
        // NOTE: angle must be provided in radians
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionFromAxisAngle(Vector3 axis, float angle);
       
        // Returns the rotation angle and axis for a given quaternion
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void QuaternionToAxisAngle(Quaternion q, out Vector3 outAxis, float[] outAngle);
        
        // Returns he quaternion equivalent to Euler angles
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionFromEuler(float roll, float pitch, float yaw);

        // Return the Euler angles equivalent to quaternion (roll, pitch, yaw)
        // NOTE: Angles are returned in a Vector3 struct in degrees
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 QuaternionToEuler(Quaternion q);
       
        // Transform a quaternion given a transformation matrix
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Quaternion QuaternionTransform(Quaternion q, Matrix mat);  
    }
}
