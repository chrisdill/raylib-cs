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

    [DllImport("raylib")]
    private static extern void RaylibSetAndroidCallback(Action callback);
}
