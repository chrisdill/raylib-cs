using System.Numerics;
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
    IntentFilter(new[] { Intent.ActionMain, Intent.CategoryLauncher }),
    MetaData(NativeActivity.MetaDataLibName, Value = "raylib")
]
public class MainActivity : RaylibActivity
{
    private const int MAX_TOUCH_POINTS = 10;

    protected override void OnReady()
    {
        Raylib.InitWindow(0, 0, "raylib [core] example - input multitouch");
        var touchPositions = new Vector2[MAX_TOUCH_POINTS];

        while (!Raylib.WindowShouldClose())
        {
            int tCount = Raylib.GetTouchPointCount();
            if (tCount > MAX_TOUCH_POINTS)
                tCount = MAX_TOUCH_POINTS;
            for (int i = 0; i < tCount; ++i)
                touchPositions[i] = Raylib.GetTouchPosition(i);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            for (int i = 0; i < tCount; ++i)
            {
                if ((touchPositions[i].X > 0) && (touchPositions[i].Y > 0))
                {
                    // for some reason this only works on release mode
                    Raylib.DrawCircleV(touchPositions[i], 34, Color.ORANGE);
                    Raylib.DrawText(
                        i.ToString(),
                        (int)touchPositions[i].X - 10,
                        (int)touchPositions[i].Y - 70,
                        40,
                        Color.BLACK
                    );
                }
            }

            Raylib.DrawText(
                "touch the screen at multiple locations to get multiple balls",
                10,
                10,
                20,
                Color.DARKGRAY
            );

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
