using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Rectangle type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Rectangle
    {
        public float x;
        public float y;
        public float width;
        public float height;

        public Rectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override string ToString()
        {
            return $"{{X:{x} Y:{y} Width:{width} Height:{height}}}";
        }
    }
}
