/* Extensions.cs
*
* Copyright 2019 Chris Dill
*
* Release under zLib License.
* See LICENSE for details.
*/

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Raylib
{
    // Extra functions over exsiting bindings
    // Feel free to modifiy this to fit your project.
    public partial class Raylib
    {
        public static PhysicsBodyData CreatePhysicsBodyCircleEx(Vector2 pos, float radius, float density)
        {
            var body = CreatePhysicsBodyCircle(pos, radius, density);
            var data = (PhysicsBodyData)Marshal.PtrToStructure(body, typeof(PhysicsBodyData));
            return data;
        }

        public static PhysicsBodyData CreatePhysicsBodyRectangleEx(Vector2 pos, float width, float height, float density)
        {
            var body = CreatePhysicsBodyRectangle(pos, width, height, density);
            var data = (PhysicsBodyData)Marshal.PtrToStructure(body, typeof(PhysicsBodyData));
            return data;
        }

        public static PhysicsBodyData GetPhysicsBodyEx(int index)
        {
            var body = GetPhysicsBodyImport(index);
            var data = (PhysicsBodyData)Marshal.PtrToStructure(body, typeof(PhysicsBodyData));
            return data;
        }

        public static PhysicsBodyData CreatePhysicsBodyPolygonEx(Vector2 pos, float radius, int sides, float density)
        {
            var body = CreatePhysicsBodyPolygon(pos, radius, sides, density);
            var data = (PhysicsBodyData)Marshal.PtrToStructure(body, typeof(PhysicsBodyData));
            return data;
        }

        public static void DrawRenderTexture(RenderTexture2D target)
        {
            int screenWidth = GetScreenWidth();
            int screenHeight = GetScreenHeight();

            // NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
            DrawTexturePro(target.texture, new Rectangle(0, 0, target.texture.width, -target.texture.height), new Rectangle(0, 0, screenWidth, screenHeight), new Vector2(0, 0), 0, Color.WHITE);
        }

        // extension providing SubText
        public static string SubText(this string input, int position, int length)
        {
            return input.Substring(position, Math.Min(length, input.Length));
        }

        // Here (in the public method) we hide some low level details
        // memory allocation, string manipulations etc.
        public static bool CoreGuiTextBox(Rectangle bounds, ref string text, int textSize, bool freeEdit)
        {
            if (null == text)
            {
                return false; // or throw exception; or assign "" to text
            }

            StringBuilder sb = new StringBuilder(text);

            // If we allow editing we should allocate enough size (Length) within StringBuilder
            if (textSize > sb.Length)
            {
                sb.Length = textSize;
            }

            bool result = GuiTextBox(bounds, sb, sb.Length, freeEdit);

            // Back to string (StringBuilder can have been edited)
            // You may want to add some logic here; e.g. trim trailing '\0'  
            text = sb.ToString();

            return result;
        }

        // Text Box control with multiple lines
        public static bool CoreTextBoxMulti(Rectangle bounds, ref string text, int textSize, bool freeEdit)
        {
            if (null == text)
            {
                return false; // or throw exception; or assign "" to text
            }

            StringBuilder sb = new StringBuilder(text);

            // If we allow editing we should allocate enough size (Length) within StringBuilder
            if (textSize > sb.Length)
            {
                sb.Length = textSize;
            }

            bool result = GuiTextBoxMulti(bounds, sb, sb.Length, freeEdit);

            // Back to string (StringBuilder can have been edited)
            // You may want to add some logic here; e.g. trim trailing '\0'  
            text = sb.ToString();

            return result;
        }
    }

    public partial struct Color
    {
        // Example - Color.RED instead of RED
        // Custom raylib color palette for amazing visuals
        public static Color LIGHTGRAY = new Color(200, 200, 200, 255);
        public static Color GRAY = new Color(130, 130, 130, 255);
        public static Color DARKGRAY = new Color(80, 80, 80, 255);
        public static Color YELLOW = new Color(253, 249, 0, 255);
        public static Color GOLD = new Color(255, 203, 0, 255);
        public static Color ORANGE = new Color(255, 161, 0, 255);
        public static Color PINK = new Color(255, 109, 194, 255);
        public static Color RED = new Color(230, 41, 55, 255);
        public static Color MAROON = new Color(190, 33, 55, 255);
        public static Color GREEN = new Color(0, 228, 48, 255);
        public static Color LIME = new Color(0, 158, 47, 255);
        public static Color DARKGREEN = new Color(0, 117, 44, 255);
        public static Color SKYBLUE = new Color(102, 191, 255, 255);
        public static Color BLUE = new Color(0, 121, 241, 255);
        public static Color DARKBLUE = new Color(0, 82, 172, 255);
        public static Color PURPLE = new Color(200, 122, 255, 255);
        public static Color VIOLET = new Color(135, 60, 190, 255);
        public static Color DARKPURPLE = new Color(112, 31, 126, 255);
        public static Color BEIGE = new Color(211, 176, 131, 255);
        public static Color BROWN = new Color(127, 106, 79, 255);
        public static Color DARKBROWN = new Color(76, 63, 47, 255);
        public static Color WHITE = new Color(255, 255, 255, 255);
        public static Color BLACK = new Color(0, 0, 0, 255);
        public static Color BLANK = new Color(0, 0, 0, 0);
        public static Color MAGENTA = new Color(255, 0, 255, 255);
        public static Color RAYWHITE = new Color(245, 245, 245, 255);

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

        public override string ToString()
        {
            return string.Concat(r.ToString(), " ", g.ToString(), " ", b.ToString(), " ", a.ToString());
        }
    }

    public partial struct Rectangle
    {
        public Rectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

    public partial struct Camera3D
    {
        public Camera3D(Vector3 position, Vector3 target, Vector3 up, float fovy = 90, CameraType type = CameraType.CAMERA_PERSPECTIVE)
        {
            this.position = position;
            this.target = target;
            this.up = up;
            this.fovy = fovy;
            this.type = type;
        }
    }

    public partial struct Ray
    {
        public Ray(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }

    // Utlity for accessing math functions through struct
    public partial struct Vector2
    {
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

        public override bool Equals(object obj)
        {
            return (obj is Vector2) && Equals((Vector2)obj);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode();
        }

        public float Length()
        {
            return Raylib.Vector2Length(this);
        }

        public float LengthSquared()
        {
            return (x * x) + (y * y);
        }

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
        public static bool operator ==(Vector2 v1, Vector2 v2) 
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }
        
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }

        public static bool operator >(Vector2 v1, Vector2 v2)
        {
            return v1.x > v2.x && v1.y > v2.y;
        }

        public static bool operator <(Vector2 v1, Vector2 v2)
        {
            return v1.x < v2.x && v1.y < v2.y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return Raylib.Vector2Add(v1, v2);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return Raylib.Vector2Subtract(v1, v2);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return Raylib.Vector2MultiplyV(v1, v2);
        }

        public static Vector2 operator *(Vector2 v, float scale)
        {
            return Raylib.Vector2Scale(v, scale);
        }

        public static Vector2 operator *(float scale, Vector2 v)
        {
            return Raylib.Vector2Scale(v, scale);
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return Raylib.Vector2DivideV(v1, v2);
        }

        public static Vector2 operator /(Vector2 v1, float div)
        {
            return Raylib.Vector2Divide(v1, div);
        }

        public static Vector2 operator -(Vector2 v1)
        {
            return Raylib.Vector2Negate(v1);
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
            float a = v1.x - v2.x, b = v1.y - v2.y;
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
                v1.x > v2.x ? v1.x : v2.x,
                v1.y > v2.y ? v1.y : v2.y);
        }

        // Creates a new <see cref="Vector2"/> that contains a minimal values from the two vectors.
        public static Vector2 Min(Vector2 v1, Vector2 v2)
        {
            return new Vector2(
                v1.x < v2.x ? v1.x : v2.x,
                v1.y < v2.y ? v1.y : v2.y);
        }

        // Clamps the specified value within a range.
        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            return new Vector2(
                Raylib.Clamp(value1.x, min.x, max.x),
                Raylib.Clamp(value1.y, min.y, max.y));
        }
    }

    // Vector3 type
    public partial struct Vector3
    {
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
        public override bool Equals(object obj)
        {
            return (obj is Vector3) && Equals((Vector3)obj);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode() + z.GetHashCode();
        }

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
        public static bool operator ==(Vector3 v1, Vector3 v2) 
        { return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);}

        public static bool operator !=(Vector3 v1, Vector3 v2) 
        {
            return !(v1 == v2);
            }

        public static bool operator >(Vector3 v1, Vector3 v2) 
        { 
            return v1.x > v2.x && v1.y > v2.y && v1.z > v2.z;
            }

        public static bool operator <(Vector3 v1, Vector3 v2) 
        {
            return  v1.x < v2.x && v1.y < v2.y && v1.z < v2.z;
            }

        public static Vector3 operator +(Vector3 v1, Vector3 v2) 
        { 
            return Raylib.Vector3Add(v1, v2);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2) 
        { 
            return Raylib.Vector3Subtract(v1, v2);
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2) 
        { 
            return Raylib.Vector3MultiplyV(v1, v2);
        }

        public static Vector3 operator *(Vector3 v, float scale) 
        { 
            return Raylib.Vector3Scale(v, scale);
        }

        public static Vector3 operator *(float scale, Vector3 v) 
        { 
            return Raylib.Vector3Scale(v, scale);
        }

        public static Vector3 operator /(Vector3 v1, Vector3 v2) 
        { 
            return Raylib.Vector3DivideV(v1, v2);
        }

        public static Vector3 operator /(Vector3 v1, float div) 
        { 
            return Raylib.Vector3Divide(v1, div);
        }

        public static Vector3 operator -(Vector3 v1) 
        { 
            return Raylib.Vector3Negate(v1);
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
            x = value;
            y = value;
            z = value;
            w = value;
        }

        public override bool Equals(object obj)
        {
            return (obj is Vector4) && Equals((Vector4)obj);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode() + z.GetHashCode() + w.GetHashCode();
        }

        public override string ToString()
        {
            return "Vector4(" + x + " " + y + " " + z + " " + w + ")";
        }

        // convienient operators
        public static bool operator ==(Vector4 v1, Vector4 v2) 
        { 
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z && v1.w == v2.w);
        }

        public static bool operator !=(Vector4 v1, Vector4 v2) 
        { 
            return !(v1 == v2);
        }

        public static bool operator >(Vector4 v1, Vector4 v2) 
        {
            return v1.x > v2.x && v1.y > v2.y && v1.z > v2.z && v1.w > v2.w;
        }

        public static bool operator <(Vector4 v1, Vector4 v2)
        {
            return v1.x < v2.x && v1.y < v2.y && v1.z < v2.z && v1.w < v2.w;
        }
    }
}
