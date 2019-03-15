using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    public struct Tween
    {
        public delegate float Callback(float t, float b, float c, float d);
        public Callback easer;
        public float start;
        public float end;
        public float currentTime;
        public float duration;
        public bool completed;

        public Tween(Callback easer, float start, float end, float duration)
        {
            this.easer = easer;
            this.start = start;
            this.end = end;
            this.currentTime = 0f;
            this.duration = duration;
            this.completed = false;
        }

        public void Reset()
        {
            currentTime = 0f;
            completed = false;
        }

        public float Apply(float dt)
        {
            currentTime += dt;
            if (currentTime > duration)
            {
                currentTime = duration;
                completed = true;
            }
            return easer(currentTime, start, end - start, duration);
        }
    }

    public partial struct Color
    {   
        public Color(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(int r, int g, int b, int a)
        {
            this.r = Convert.ToByte(r);
            this.g = Convert.ToByte(g);
            this.b = Convert.ToByte(b);
            this.a = Convert.ToByte(a);
        }

        internal string DebugDisplayString
		{
			get
			{
				return string.Concat(
					r.ToString(), " ",
					g.ToString(), " ",
					b.ToString(), " ",
					a.ToString()
				);
			}
		}

        /// <summary>
		/// Performs linear interpolation of <see cref="Color"/>.
		/// </summary>
		/// <param name="value1">Source <see cref="Color"/>.</param>
		/// <param name="value2">Destination <see cref="Color"/>.</param>
		/// <param name="amount">Interpolation factor.</param>
		/// <returns>Interpolated <see cref="Color"/>.</returns>
		public static Color Lerp(Color value1, Color value2, float amount)
		{
			amount = Raylib.Clamp(amount, 0.0f, 1.0f);
			return new Color(
				(int) Raylib.Lerp(value1.r, value2.r, amount),
				(int) Raylib.Lerp(value1.g, value2.g, amount),
				(int) Raylib.Lerp(value1.b, value2.b, amount),
				(int) Raylib.Lerp(value1.a, value2.a, amount)
			);
		}
    }

    // Utlity for accessing math functions through struct
    public partial struct Vector2
    {
        public float X {get{return x;} set {x = value;}}
        public float Y {get{return y;} set {y = value;}}

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(float value)
        {
            this.x = value;
            this.y = value;
        }

        public override bool Equals(object obj) => (obj is Vector2) && Equals((Vector2)obj);
        public override int GetHashCode() => x.GetHashCode() + y.GetHashCode();

        public float Length() => Raylib.Vector2Length(this);
        public float LengthSquared() => (x * x) + (y * y);

        public override string ToString()
        {
            return "Vector2(" + x + " " + y + ")";
        }

        // common values
        public static Vector2 Zero { get { return Raylib.Vector2Zero(); } }
        public static Vector2 One { get { return Raylib.Vector2One(); } }
        public static Vector2 UnitX { get { return new Vector2(1, 0); } }
        public static Vector2 UnitY { get { return new Vector2(0, 1); } }

        // convienient operators
        public static bool operator ==(Vector2 v1, Vector2 v2) => (v1.x == v2.x && v1.y == v2.y);
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1 == v2);
        public static bool operator >(Vector2 v1, Vector2 v2) => v1.x > v2.x && v1.y > v2.y;
        public static bool operator <(Vector2 v1, Vector2 v2) => v1.x < v2.x && v1.y < v2.y;
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => Raylib.Vector2Add(v1, v2);
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => Raylib.Vector2Subtract(v1, v2);
        public static Vector2 operator *(Vector2 v1, Vector2 v2) => Raylib.Vector2Multiplyv(v1, v2);
        public static Vector2 operator *(Vector2 v, float scale) => Raylib.Vector2Scale(v, scale);
        public static Vector2 operator *(float scale, Vector2 v) => Raylib.Vector2Scale(v, scale);
        public static Vector2 operator /(Vector2 v1, Vector2 v2) => Raylib.Vector2DivideV(v1, v2);
        public static Vector2 operator /(Vector2 v1, float div) => Raylib.Vector2Divide(v1, div);
        public static Vector2 operator -(Vector2 v1) => Raylib.Vector2Negate(v1);

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            return new Vector2(
                Raylib.Lerp(value1.X, value2.X, amount),
                Raylib.Lerp(value1.Y, value2.Y, amount)
            );
        }

        public static float Length(Vector2 v) 
        {
            return Raylib.Vector2Length(v);
        }

        public static float Dot(Vector2 v1, Vector2 v2) 
        {
            return Raylib.Vector2DotProduct(v1, v2);
        }

        public static void Dot(ref Vector2 v1, ref Vector2 v2, out float result) 
        {
            result = Raylib.Vector2DotProduct(v1, v2);
        }

        public static float DotProduct(Vector2 v1, Vector2 v2)
        {
            return Raylib.Vector2DotProduct(v1, v2);
        }

        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return Raylib.Vector2Distance(v1, v2);
        }

        public static float DistanceSquared(Vector2 v1, Vector2 v2)
        {
            float a = v1.X - v2.X, b = v1.Y - v2.Y;
            return (a * a) + (b * b);
        }

        public static float Angle(Vector2 v1, Vector2 v2)
        {
            return Raylib.Vector2Angle(v1, v2);
        }

        public static Vector2 Scale(Vector2 v, float scale)
        {
            return Raylib.Vector2Scale(v, scale);
        }

        public static Vector2 Negate(Vector2 v)
        {
            return Raylib.Vector2Negate(v);
        }

        public static Vector2 Divide(Vector2 v, float div)
        {
            return Raylib.Vector2Divide(v, div);
        }

        public static void Normalize(ref Vector2 v)
        {
            v = Raylib.Vector2Normalize(v);
        }

        public static Vector2 Normalize(Vector2 v)
        {
            return Raylib.Vector2Normalize(v);
        }

		// Creates a new <see cref="Vector2"/> that contains a maximal values from the two vectors.
        public static Vector2 Max(Vector2 v1, Vector2 v2)
        {
            return new Vector2(
				v1.X > v2.X ? v1.X : v2.X,
				v1.Y > v2.Y ? v1.Y : v2.Y
            );
        }

        // Creates a new <see cref="Vector2"/> that contains a minimal values from the two vectors.
        public static Vector2 Min(Vector2 v1, Vector2 v2)
        {
            return new Vector2(
				v1.X < v2.X ? v1.X : v2.X,
                v1.Y < v2.Y ? v1.Y : v2.Y
            );
        }

		// Clamps the specified value within a range.
		public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
		{
			return new Vector2(
				Raylib.Clamp(value1.X, min.X, max.X),
				Raylib.Clamp(value1.Y, min.Y, max.Y)
			);
        }
    }
    

    // Vector3 type
    public partial struct Vector3
    {
        // captial option for xna/fna/monogame compatability
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; } 
        public float Z { get => z; set => z = value; } 

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float value)
        {
            this.x = value;
            this.y = value;
            this.z = value;
        }

        // extensions
        public override bool Equals(object obj) => (obj is Vector3) && Equals((Vector3)obj);
        public override int GetHashCode() => x.GetHashCode() + y.GetHashCode() + z.GetHashCode();

        public override string ToString()
        {
            return "Vector3(" + x + " " + y + " " + z + ")";
        }

        // common values
        public static Vector3 Zero { get { return Raylib.Vector3Zero(); } }
        public static Vector3 One { get { return Raylib.Vector3One(); } }
        public static Vector3 UnitX { get { return new Vector3(1, 0, 0); } }
        public static Vector3 UnitY { get { return new Vector3(0, 1, 0); } }
        public static Vector3 UnitZ { get { return new Vector3(0, 0, 1); } }

        // convienient operators
        public static bool operator ==(Vector3 v1, Vector3 v2) => (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1 == v2);
        public static bool operator >(Vector3 v1, Vector3 v2) => v1.x > v2.x && v1.y > v2.y && v1.z > v2.z;
        public static bool operator <(Vector3 v1, Vector3 v2) => v1.x < v2.x && v1.y < v2.y && v1.z < v2.z;
        public static Vector3 operator +(Vector3 v1, Vector3 v2) => Raylib.Vector3Add(v1, v2);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => Raylib.Vector3Subtract(v1, v2);
        public static Vector3 operator *(Vector3 v1, Vector3 v2) => Raylib.Vector3MultiplyV(v1, v2);
        public static Vector3 operator *(Vector3 v, float scale) => Raylib.Vector3Scale(v, scale);
        public static Vector3 operator *(float scale, Vector3 v) => Raylib.Vector3Scale(v, scale);
        public static Vector3 operator /(Vector3 v1, Vector3 v2) => Raylib.Vector3DivideV(v1, v2);
        public static Vector3 operator /(Vector3 v1, float div) => Raylib.Vector3Divide(v1, div);
        public static Vector3 operator -(Vector3 v1) => Raylib.Vector3Negate(v1);  

        public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
		{
			return new Vector3(
				Raylib.Lerp(value1.X, value2.X, amount),
				Raylib.Lerp(value1.Y, value2.Y, amount),
				Raylib.Lerp(value1.Z, value2.Z, amount)
			);
        }
    }

    // Vector4 type
    public partial struct Vector4 
    {
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(float value)
        {
            this.x = value;
            this.y = value;
            this.z = value;
            this.w = value;
        }

        public override bool Equals(object obj) => (obj is Vector4) && Equals((Vector4)obj);
        public override int GetHashCode() => x.GetHashCode() + y.GetHashCode() + z.GetHashCode() + w.GetHashCode();

        public override string ToString()
        {
            return "Vector4(" + x + " " + y + " " + z + " " + w + ")";
        }

        // convienient operators
        public static bool operator ==(Vector4 v1, Vector4 v2) => (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z && v1.w == v2.w);
        public static bool operator !=(Vector4 v1, Vector4 v2) => !(v1 == v2);
        public static bool operator >(Vector4 v1, Vector4 v2) => v1.x > v2.x && v1.y > v2.y && v1.z > v2.z && v2.w > v2.w;
        public static bool operator <(Vector4 v1, Vector4 v2) => v1.x < v2.x && v1.y < v2.y && v1.z < v2.z && v1.w < v2.w;
    }
}
