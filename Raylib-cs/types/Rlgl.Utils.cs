using System.Numerics;

namespace Raylib_cs;

public static unsafe partial class Rlgl
{
    /// <summary>Set shader value matrices</summary>
    public static void SetUniformMatrices(int locIndex, Matrix4x4[] mat)
    {
        fixed (Matrix4x4* p = mat)
        {
            SetUniformMatrices(locIndex, p, mat.Length);
        }
    }
}
