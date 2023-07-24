using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.PM;

namespace Raylib_cs.Android;

[
    Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation
            | ConfigChanges.KeyboardHidden
            | ConfigChanges.ScreenSize,
        ScreenOrientation = ScreenOrientation.Landscape,
        ClearTaskOnLaunch = true
    ),
    IntentFilter(new[] { Intent.ActionMain }),
    MetaData(NativeActivity.MetaDataLibName, Value = "raylib")
]
public class MainActivity : RaylibActivity
{
    protected override void OnReady()
    {
        Raylib.InitWindow(0, 0, "android_window");
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawFPS(10, 10);
            Raylib.DrawText("Hello Raylib-cs.Android", 20, 100, 100, Color.BLACK);
            Raylib.EndDrawing();
        }
    }
}
