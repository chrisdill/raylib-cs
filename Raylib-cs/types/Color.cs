using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Color type, RGBA (32bit)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Color
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        // Example - Color.RED instead of RED
        // Custom raylib color palette for amazing visuals
        public static readonly Color LIGHTGRAY = new Color(200, 200, 200, 255);
        public static readonly Color GRAY = new Color(130, 130, 130, 255);
        public static readonly Color DARKGRAY = new Color(80, 80, 80, 255);
        public static readonly Color YELLOW = new Color(253, 249, 0, 255);
        public static readonly Color GOLD = new Color(255, 203, 0, 255);
        public static readonly Color ORANGE = new Color(255, 161, 0, 255);
        public static readonly Color PINK = new Color(255, 109, 194, 255);
        public static readonly Color RED = new Color(230, 41, 55, 255);
        public static readonly Color MAROON = new Color(190, 33, 55, 255);
        public static readonly Color GREEN = new Color(0, 228, 48, 255);
        public static readonly Color LIME = new Color(0, 158, 47, 255);
        public static readonly Color DARKGREEN = new Color(0, 117, 44, 255);
        public static readonly Color SKYBLUE = new Color(102, 191, 255, 255);
        public static readonly Color BLUE = new Color(0, 121, 241, 255);
        public static readonly Color DARKBLUE = new Color(0, 82, 172, 255);
        public static readonly Color PURPLE = new Color(200, 122, 255, 255);
        public static readonly Color VIOLET = new Color(135, 60, 190, 255);
        public static readonly Color DARKPURPLE = new Color(112, 31, 126, 255);
        public static readonly Color BEIGE = new Color(211, 176, 131, 255);
        public static readonly Color BROWN = new Color(127, 106, 79, 255);
        public static readonly Color DARKBROWN = new Color(76, 63, 47, 255);
        public static readonly Color WHITE = new Color(255, 255, 255, 255);
        public static readonly Color BLACK = new Color(0, 0, 0, 255);
        public static readonly Color BLANK = new Color(0, 0, 0, 0);
        public static readonly Color MAGENTA = new Color(255, 0, 255, 255);
        public static readonly Color RAYWHITE = new Color(245, 245, 245, 255);

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
            return $"{{R:{r} G:{g} B:{b} A:{a}}}";
        }
    }
}
