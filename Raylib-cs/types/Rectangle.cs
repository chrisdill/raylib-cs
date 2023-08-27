using System.Runtime.InteropServices;

namespace Raylib_cs;

/// <summary>
/// Rectangle type
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct Rectangle
{
    public float X;
    public float Y;
    public float Width;
    public float Height;

    public Rectangle(float x, float y, float width, float height)
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public override string ToString()
    {
        return $"{{X:{X} Y:{Y} Width:{Width} Height:{Height}}}";
    }
}
