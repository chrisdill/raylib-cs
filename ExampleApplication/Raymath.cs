
using System.Runtime.InteropServices;

namespace Raylib
{
    #region Raylib-cs Types

    // Vector2 type
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return (obj is Vector2) && Equals((Vector2)obj);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode();
        }

        // utility for c functions Vector2Zero -> Zero etc
        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Zero")]
        public static extern Vector2 Zero();

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2One")]
        public static extern Vector2 One();

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Add")]
        public static extern Vector2 operator +(Vector2 v1, Vector2 v2);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Subtract")]
        public static extern Vector2 operator -(Vector2 v1, Vector2 v2);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Length")]
        public static extern float Length(Vector2 v);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2DotProduct")]
        public static extern float DotProduct(Vector2 v1, Vector2 v2);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Distance")]
        public static extern float Distance(Vector2 v1, Vector2 v2);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Angle")]
        public static extern float Angle(Vector2 v1, Vector2 v2);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Scale")]
        public static extern Vector2 Scale(Vector2 v, float scale);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Negate")]
        public static extern Vector2 Negate(Vector2 v);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Divide")]
        public static extern Vector2 Divide(Vector2 v, float div);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector2Normalize")]
        public static extern Vector2 Normalize(Vector2 v);

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }
    }

    // Vector3 type
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            return (obj is Vector3) && Equals((Vector3)obj);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode() + z.GetHashCode();
        }

        // utility for c functions Vector3Zero -> Zero etc
        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Zero")]
        public static extern Vector3 Zero();

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3One")]
        public static extern Vector3 One();

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Add")]
        public static extern Vector3 operator +(Vector3 v1, Vector3 v3);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Subtract")]
        public static extern Vector3 operator -(Vector3 v1, Vector3 v3);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Length")]
        public static extern float Length(Vector3 v);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3DotProduct")]
        public static extern float DotProduct(Vector3 v1, Vector3 v3);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Distance")]
        public static extern float Distance(Vector3 v1, Vector3 v3);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Angle")]
        public static extern float Angle(Vector3 v1, Vector3 v3);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Scale")]
        public static extern Vector3 Scale(Vector3 v, float scale);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Negate")]
        public static extern Vector3 Negate(Vector3 v);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Divide")]
        public static extern Vector3 Divide(Vector3 v, float div);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Normalize")]
        public static extern Vector3 Normalize(Vector3 v);

        // operators
        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Scale")]
        public static extern Vector3 operator *(Vector3 v1, Vector3 v3);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Divide")]
        public static extern Vector3 operator /(Vector3 v1, Vector3 v3);

        [DllImport(rl.nativeLibName, EntryPoint = "Vector3Negate")]
        public static extern Vector3 operator -(Vector3 v1);

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }
    }

    // Vector4 type
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    // Matrix type (OpenGL style 4x4 - right handed, column major)
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Matrix
    {
        public float m0, m4, m8, m12;
        public float m1, m5, m9, m13;
        public float m2, m6, m10, m14;
        public float m3, m7, m11, m15;
    }

    // Quaternion type
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    #endregion

    public static partial class rl
    {
        #region Raylib-cs Functions 

        // Clamp float value
        [DllImport(nativeLibName)]
        public static extern float Clamp(float value, float min, float max);

        // Vector with components value 0.0f
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2Zero();

        // Vector with components value 1.0f
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2One();

        // Add two vectors (v1 + v2)
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2Add(Vector2 v1, Vector2 v2);

        // Subtract two vectors (v1 - v2)
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2Subtract(Vector2 v1, Vector2 v2);

        // Calculate vector length
        [DllImport(nativeLibName)]
        public static extern float Vector2Length(Vector2 v);

        // Calculate two vectors dot product
        [DllImport(nativeLibName)]
        public static extern float Vector2DotProduct(Vector2 v1, Vector2 v2);

        // Calculate distance between two vectors
        [DllImport(nativeLibName)]
        public static extern float Vector2Distance(Vector2 v1, Vector2 v2);

        // Calculate angle from two vectors in X-axis
        [DllImport(nativeLibName)]
        public static extern float Vector2Angle(Vector2 v1, Vector2 v2);

        // Scale vector (multiply by value)
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2Scale(Vector2 v, float scale);

        // Negate vector
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2Negate(Vector2 v);

        // Divide vector by a float value
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2Divide(Vector2 v, float div);

        // Normalize provided vector
        [DllImport(nativeLibName)]
        public static extern Vector2 Vector2Normalize(Vector2 v);


        // Vector with components value 0.0f
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Zero();

        // Vector with components value 1.0f
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3One();

        // Add two vectors
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Add(Vector3 v1, Vector3 v2);

        // Substract two vectors
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Subtract(Vector3 v1, Vector3 v2);

        // Multiply vector by scalar
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Multiply(Vector3 v, float scalar);

        // Multiply vector by vector
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3MultiplyV(Vector3 v1, Vector3 v2);

        // Calculate two vectors cross product
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3CrossProduct(Vector3 v1, Vector3 v2);

        // Calculate one vector perpendicular vector
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Perpendicular(Vector3 v);

        // Calculate vector length
        [DllImport(nativeLibName)]
		public static extern float Vector3Length(Vector3 v);

        // Calculate two vectors dot product
        [DllImport(nativeLibName)]
        public static extern float Vector3DotProduct(Vector3 v1, Vector3 v2);

        // Calculate distance between two vectors
        [DllImport(nativeLibName)]
        public static extern float Vector3Distance(Vector3 v1, Vector3 v2);

        // Scale provided vector
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Scale(Vector3 v, float scale);

        // Negate provided vector (invert direction)
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Negate(Vector3 v);

        // Normalize provided vector
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Normalize(Vector3 v);

        // Orthonormalize provided vectors
        // Makes vectors normalized and orthogonal to each other
        // Gram-Schmidt function implementation
        [DllImport(nativeLibName)]
        public static extern void Vector3OrthoNormalize(out Vector3 v1, out Vector3 v2);

        // Transforms a Vector3 by a given Matrix
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Transform(Vector3 v, Matrix mat);

        // Transform a vector by quaternion rotation
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3RotateByQuaternion(Vector3 v, Quaternion q);
        
        // Calculate linear interpolation between two vectors
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Lerp(Vector3 v1, Vector3 v2, float amount);
        
        // Calculate reflected vector to normal
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Reflect(Vector3 v, Vector3 normal);
        
        // Return min value for each pair of components
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Min(Vector3 v1, Vector3 v2);
        
        // Return max value for each pair of components
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Max(Vector3 v1, Vector3 v2);
        
        // Compute barycenter coordinates (u, v, w) for point p with respect to triangle (a, b, c)
        // NOTE: Assumes P is on the plane of the triangle
        [DllImport(nativeLibName)]
        public static extern Vector3 Vector3Barycenter(Vector3 p, Vector3 a, Vector3 b, Vector3 c);
        
        // Returns Vector3 as float array
        [DllImport(nativeLibName)]
        public static extern float[] Vector3ToFloatV(Vector3 v);

        [DllImport(nativeLibName)]
        public static extern float MatrixDeterminant(Matrix mat);

        [DllImport(nativeLibName)]
        public static extern float MatrixTrace(Matrix mat);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixTranspose(Matrix mat);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixInvert(Matrix mat);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixNormalize(Matrix mat);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixIdentity();

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixAdd(Matrix left, Matrix right);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixSubstract(Matrix left, Matrix right);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixTranslate(float x, float y, float z);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixRotate(Vector3 axis, float angle);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixRotateX(float angle);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixRotateY(float angle);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixRotateZ(float angle);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixScale(float x, float y, float z);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixMultiply(Matrix left, Matrix right);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixFrustum(double left, double right, double bottom, double top, double near, double far);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixPerspective(double fovy, double aspect, double near, double far);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixOrtho(double left, double right, double bottom, double top, double near, double far);

        [DllImport(nativeLibName)]
        public static extern Matrix MatrixLookAt(Vector3 eye, Vector3 target, Vector3 up);

        [DllImport(nativeLibName)]
        public static extern float[] MatrixToFloatV(Matrix mat);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionIdentity();

        [DllImport(nativeLibName)]
        public static extern float QuaternionLength(Quaternion q);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionNormalize(Quaternion q);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionInvert(Quaternion q);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionMultiply(Quaternion q1, Quaternion q2);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionLerp(Quaternion q1, Quaternion q2, float amount);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionNlerp(Quaternion q1, Quaternion q2, float amount);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionSlerp(Quaternion q1, Quaternion q2, float amount);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionFromVector3ToVector3(Vector3 from, Vector3 to);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionFromMatrix(Matrix mat);

        [DllImport(nativeLibName)]
        public static extern Matrix QuaternionToMatrix(Quaternion q);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionFromAxisAngle(Vector3 axis, float angle);

        [DllImport(nativeLibName)]
        public static extern void QuaternionToAxisAngle(Quaternion q, out Vector3 outAxis, float[] outAngle);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionFromEuler(float roll, float pitch, float yaw);

        [DllImport(nativeLibName)]
        public static extern Vector3 QuaternionToEuler(Quaternion q);

        [DllImport(nativeLibName)]
        public static extern Quaternion QuaternionTransform(Quaternion q, Matrix mat);

		#endregion

    }
}
