using System.Runtime.InteropServices;

namespace Examples.Android;

public abstract class RaylibActivity : NativeActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        RaylibSetAndroidCallback(OnReady);
        base.OnCreate(savedInstanceState);
    }

    protected abstract void OnReady();

    [DllImport(Raylib.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void RaylibSetAndroidCallback(Action callback);
}
