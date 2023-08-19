using System;
using System.Numerics;

namespace Raylib_cs;

public class Window : IDisposable
{
    private static Window _instance;
    
    private Window(int width, int height, string title)
    {
        Raylib.InitWindow(width, height, title);
        _instance = this;
    }
    
    /// <summary>
    /// Initializes the object if it is not ready.
    /// </summary>
    public static Window Instance(int width, int height, string title) {
        return _instance ?? new Window(width, height, title);
    }
    
    /// <summary> See <see cref="Raylib.WindowShouldClose"/> </summary>
    public bool ShouldClose() => Raylib.WindowShouldClose();
    
    /// <summary> See <see cref="Raylib.CloseWindow"/> </summary>
    public void Close() => Raylib.CloseWindow();
    
    /// <summary> See <see cref="Raylib.TakeScreenshot(string)"/> </summary>
    public void TakeScreenshot(string path) => Raylib.TakeScreenshot(path);
    
    
    /// <summary> See <see cref="Raylib.IsWindowReady"/> </summary>
    public bool IsReady() => Raylib.IsWindowReady();
    
    /// <summary> See <see cref="Raylib.IsWindowFullscreen"/> </summary>
    public bool IsFullscreen() => Raylib.IsWindowFullscreen();
    
    /// <summary> See <see cref="Raylib.IsWindowHidden"/> </summary>
    public bool IsHidden() => Raylib.IsWindowHidden();
    
    /// <summary> See <see cref="Raylib.IsWindowMinimized"/> </summary>
    public bool IsMinimized() => Raylib.IsWindowMinimized();
    
    /// <summary> See <see cref="Raylib.IsWindowMaximized"/> </summary>
    public bool IsMaximized() => Raylib.IsWindowMaximized();
    
    /// <summary> See <see cref="Raylib.IsWindowFocused"/> </summary>
    public bool IsFocused() => Raylib.IsWindowFocused();
    
    /// <summary> See <see cref="Raylib.IsWindowResized"/> </summary>
    public bool IsResized() => Raylib.IsWindowResized();
    
    /// <summary> See <see cref="Raylib.IsWindowState"/> </summary>
    public bool IsState(ConfigFlags state) => Raylib.IsWindowState(state);
    
    
    /// <summary> See <see cref="Raylib.SetWindowState"/> </summary>
    public bool SetState(ConfigFlags state) => Raylib.SetWindowState(state);
    
    /// <summary> See <see cref="Raylib.SetConfigFlags"/> </summary>
    public void SetConfigFlag(ConfigFlags state) => Raylib.SetConfigFlags(state);
    
    /// <summary> See <see cref="Raylib.ClearWindowState"/> </summary>
    public void ClearState(ConfigFlags state) => Raylib.ClearWindowState(state);
    
    /// <summary> See <see cref="Raylib.ToggleFullscreen"/> </summary>
    public void ToggleFullscreen() => Raylib.ToggleFullscreen();
    
    /// <summary> See <see cref="Raylib.MaximizeWindow"/> </summary>
    public void Maximize() => Raylib.MaximizeWindow();
    
    /// <summary> See <see cref="Raylib.MinimizeWindow"/> </summary>
    public void Minimize() => Raylib.MinimizeWindow();
    
    /// <summary> See <see cref="Raylib.RestoreWindow"/> </summary>
    public void Restore() => Raylib.RestoreWindow();
    
    /// <summary> See <see cref="Raylib.SetWindowIcon"/> </summary>
    public void SetIcon(Image image) => Raylib.SetWindowIcon(image);
    
    /// <summary> See <see cref="Raylib.SetWindowIcons"/> </summary>
    public unsafe void SetIcons(Image* images, int count) => Raylib.SetWindowIcons(images, count);
    
    /// <summary> See <see cref="Raylib.SetWindowTitle(string)"/> </summary>
    public void SetTitle(string title) => Raylib.SetWindowTitle(title);
    
    /// <summary> See <see cref="Raylib.SetClipboardText(string)"/> </summary>
    public void SetClipboardText(string path) => Raylib.SetClipboardText(path);
    
    /// <summary> See <see cref="Raylib.SetWindowPosition"/> </summary>
    public void SetPosition(int x, int y) => Raylib.SetWindowPosition(x, y);
    
    /// <summary> See <see cref="Raylib.SetWindowMonitor"/> </summary>
    public void SetMonitor(int monitor) => Raylib.SetWindowMonitor(monitor);
    
    /// <summary> See <see cref="Raylib.SetWindowMinSize"/> </summary>
    public void SetMinSize(int width, int height) => Raylib.SetWindowMinSize(width, height);
    
    /// <summary> See <see cref="Raylib.SetWindowSize"/> </summary>
    public void SetSize(int width, int height) => Raylib.SetWindowSize(width, height);
    
    /// <summary> See <see cref="Raylib.SetWindowOpacity"/> </summary>
    public void SetOpacity(float opacity) => Raylib.SetWindowOpacity(opacity);
    
    /// <summary> See <see cref="Raylib.EnableEventWaiting"/> </summary>
    public void EnableEventWaiting() => Raylib.EnableEventWaiting();
    
    /// <summary> See <see cref="Raylib.DisableEventWaiting"/> </summary>
    public void DisableEventWaiting() => Raylib.DisableEventWaiting();
    
    
    /// <summary> See <see cref="Raylib.GetScreenWidth"/> </summary>
    public int GetScreenWidth() => Raylib.GetScreenWidth();
    
    /// <summary> See <see cref="Raylib.GetScreenHeight"/> </summary>
    public int GetScreenHeight() => Raylib.GetScreenHeight();
    
    /// <summary> See <see cref="Raylib.GetRenderWidth"/> </summary>
    public int GetRenderWidth() => Raylib.GetRenderWidth();
    
    /// <summary> See <see cref="Raylib.GetRenderHeight"/> </summary>
    public int GetRenderHeight() => Raylib.GetRenderHeight();
    
    /// <summary> See <see cref="Raylib.GetMonitorCount"/> </summary>
    public int GetMonitorCount() => Raylib.GetMonitorCount();
    
    /// <summary> See <see cref="Raylib.GetCurrentMonitor"/> </summary>
    public int GetCurrentMonitor() => Raylib.GetCurrentMonitor();
    
    /// <summary> See <see cref="Raylib.GetMonitorPosition"/> </summary>
    public Vector2 GetMonitorPosition(int monitor) => Raylib.GetMonitorPosition(monitor);
    
    /// <summary> See <see cref="Raylib.GetMonitorWidth"/> </summary>
    public int GetMonitorWidth(int monitor) => Raylib.GetMonitorWidth(monitor);
    
    /// <summary> See <see cref="Raylib.GetMonitorHeight"/> </summary>
    public int GetMonitorHeight(int monitor) => Raylib.GetMonitorHeight(monitor);
    
    /// <summary> See <see cref="Raylib.GetMonitorPhysicalWidth"/> </summary>
    public int GetMonitorPhysicalWidth(int monitor) => Raylib.GetMonitorPhysicalWidth(monitor);
    
    /// <summary> See <see cref="Raylib.GetMonitorPhysicalHeight"/> </summary>
    public int GetMonitorPhysicalHeight(int monitor) => Raylib.GetMonitorPhysicalHeight(monitor);
    
    /// <summary> See <see cref="Raylib.GetMonitorRefreshRate"/> </summary>
    public int GetMonitorRefreshRate(int monitor) => Raylib.GetMonitorRefreshRate(monitor);
    
    /// <summary> See <see cref="Raylib.GetWindowPosition"/> </summary>
    public Vector2 GetPosition() => Raylib.GetWindowPosition();
    
    /// <summary> See <see cref="Raylib.GetWindowScaleDPI"/> </summary>
    public Vector2 GetScaleDpi() => Raylib.GetWindowScaleDPI();
    
    /// <summary> See <see cref="Raylib.GetMonitorName_"/> </summary>
    public string GetMonitorName(int monitor) => Raylib.GetMonitorName_(monitor);

    public void Dispose()
    {
        if (!IsReady()) return;
        this.Close();
    }
}