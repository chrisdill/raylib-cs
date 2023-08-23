using System.Runtime.InteropServices;

namespace Raylib_cs;

public abstract class RaylibActivity : NativeActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        RaylibSetAndroidCallback(OnReady);
    }

    protected abstract void OnReady();

    [DllImport(Raylib.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void RaylibSetAndroidCallback(Action callback);
}
