using System;
using System.Numerics;

namespace Raylib_cs;

public sealed class Window : IDisposable
{
    private static Window _instance;
    
    private Window(ConfigFlags flags, int width, int height, string title)
    {
        Raylib.SetConfigFlags(flags);
        Raylib.InitWindow(width, height, title);
        _instance = this;
    }
    
    /// <summary>
    /// Gets an instance of the Window or creates a new one if it doesn't exist.
    /// </summary>
    /// <param name="flags">The configuration flags for the window.</param>
    /// <param name="width">The width of the window.</param>
    /// <param name="height">The height of the window.</param>
    /// <param name="title">The title of the window.</param>
    /// <returns>An instance of the Window.</returns>
    public static Window Instance(ConfigFlags flags, int width, int height, string title)
    {
        return _instance ?? new Window(flags, width, height, title);
    }
    
    /// <inheritdoc cref="Raylib.WindowShouldClose"/>
    public bool ShouldClose() => Raylib.WindowShouldClose();
    
    /// <inheritdoc cref="Raylib.CloseWindow"/>
    public void Close() => Raylib.CloseWindow();
    
    /// <inheritdoc cref="Raylib.TakeScreenshot(string)"/>
    public void TakeScreenshot(string path) => Raylib.TakeScreenshot(path);
    
    
    /// <inheritdoc cref="Raylib.IsWindowReady"/>
    public bool IsReady() => Raylib.IsWindowReady();
    
    /// <inheritdoc cref="Raylib.IsWindowFullscreen"/>
    public bool IsFullscreen() => Raylib.IsWindowFullscreen();
    
    /// <inheritdoc cref="Raylib.IsWindowHidden"/>
    public bool IsHidden() => Raylib.IsWindowHidden();
    
    /// <inheritdoc cref="Raylib.IsWindowMinimized"/>
    public bool IsMinimized() => Raylib.IsWindowMinimized();
    
    /// <inheritdoc cref="Raylib.IsWindowMaximized"/>
    public bool IsMaximized() => Raylib.IsWindowMaximized();
    
    /// <inheritdoc cref="Raylib.IsWindowFocused"/>
    public bool IsFocused() => Raylib.IsWindowFocused();
    
    /// <inheritdoc cref="Raylib.IsWindowResized"/>
    public bool IsResized() => Raylib.IsWindowResized();
    
    /// <inheritdoc cref="Raylib.IsWindowState"/>
    public bool IsState(ConfigFlags state) => Raylib.IsWindowState(state);
    
    
    /// <inheritdoc cref="Raylib.SetWindowState"/>
    public bool SetState(ConfigFlags state) => Raylib.SetWindowState(state);
    
    /// <inheritdoc cref="Raylib.ClearWindowState"/>
    public void ClearState(ConfigFlags state) => Raylib.ClearWindowState(state);
    
    /// <inheritdoc cref="Raylib.ToggleFullscreen"/>
    public void ToggleFullscreen() => Raylib.ToggleFullscreen();
    
    /// <inheritdoc cref="Raylib.MaximizeWindow"/>
    public void Maximize() => Raylib.MaximizeWindow();
    
    /// <inheritdoc cref="Raylib.MinimizeWindow"/>
    public void Minimize() => Raylib.MinimizeWindow();
    
    /// <inheritdoc cref="Raylib.RestoreWindow"/>
    public void Restore() => Raylib.RestoreWindow();
    
    /// <inheritdoc cref="Raylib.SetWindowIcon"/>
    public void SetIcon(Image image) => Raylib.SetWindowIcon(image);
    
    /// <inheritdoc cref="Raylib.SetWindowIcons"/>
    public unsafe void SetIcons(Image* images, int count) => Raylib.SetWindowIcons(images, count);
    
    /// <inheritdoc cref="Raylib.SetWindowTitle(string)"/>
    public void SetTitle(string title) => Raylib.SetWindowTitle(title);
    
    /// <inheritdoc cref="Raylib.SetClipboardText(string)"/>
    public void SetClipboardText(string path) => Raylib.SetClipboardText(path);
    
    /// <inheritdoc cref="Raylib.SetWindowPosition"/>
    public void SetPosition(int x, int y) => Raylib.SetWindowPosition(x, y);
    
    /// <inheritdoc cref="Raylib.SetWindowMonitor"/>
    public void SetMonitor(int monitor) => Raylib.SetWindowMonitor(monitor);
    
    /// <inheritdoc cref="Raylib.SetWindowMinSize"/>
    public void SetMinSize(int width, int height) => Raylib.SetWindowMinSize(width, height);
    
    /// <inheritdoc cref="Raylib.SetWindowSize"/>
    public void SetSize(int width, int height) => Raylib.SetWindowSize(width, height);
    
    /// <inheritdoc cref="Raylib.SetWindowOpacity"/>
    public void SetOpacity(float opacity) => Raylib.SetWindowOpacity(opacity);
    
    /// <inheritdoc cref="Raylib.EnableEventWaiting"/>
    public void EnableEventWaiting() => Raylib.EnableEventWaiting();
    
    /// <inheritdoc cref="Raylib.DisableEventWaiting"/>
    public void DisableEventWaiting() => Raylib.DisableEventWaiting();
    
    
    /// <inheritdoc cref="Raylib.GetScreenWidth"/>
    public int GetScreenWidth() => Raylib.GetScreenWidth();
    
    /// <inheritdoc cref="Raylib.GetScreenHeight"/>
    public int GetScreenHeight() => Raylib.GetScreenHeight();
    
    /// <inheritdoc cref="Raylib.GetRenderWidth"/>
    public int GetRenderWidth() => Raylib.GetRenderWidth();
    
    /// <inheritdoc cref="Raylib.GetRenderHeight"/>
    public int GetRenderHeight() => Raylib.GetRenderHeight();
    
    /// <inheritdoc cref="Raylib.GetMonitorCount"/>
    public int GetMonitorCount() => Raylib.GetMonitorCount();
    
    /// <inheritdoc cref="Raylib.GetCurrentMonitor"/>
    public int GetCurrentMonitor() => Raylib.GetCurrentMonitor();
    
    /// <inheritdoc cref="Raylib.GetMonitorPosition"/>
    public Vector2 GetMonitorPosition(int monitor) => Raylib.GetMonitorPosition(monitor);
    
    /// <inheritdoc cref="Raylib.GetMonitorWidth"/>
    public int GetMonitorWidth(int monitor) => Raylib.GetMonitorWidth(monitor);
    
    /// <inheritdoc cref="Raylib.GetMonitorHeight"/>
    public int GetMonitorHeight(int monitor) => Raylib.GetMonitorHeight(monitor);
    
    /// <inheritdoc cref="Raylib.GetMonitorPhysicalWidth"/>
    public int GetMonitorPhysicalWidth(int monitor) => Raylib.GetMonitorPhysicalWidth(monitor);
    
    /// <inheritdoc cref="Raylib.GetMonitorPhysicalHeight"/>
    public int GetMonitorPhysicalHeight(int monitor) => Raylib.GetMonitorPhysicalHeight(monitor);
    
    /// <inheritdoc cref="Raylib.GetMonitorRefreshRate"/>
    public int GetMonitorRefreshRate(int monitor) => Raylib.GetMonitorRefreshRate(monitor);
    
    /// <inheritdoc cref="Raylib.GetWindowPosition"/>
    public Vector2 GetPosition() => Raylib.GetWindowPosition();
    
    /// <inheritdoc cref="Raylib.GetWindowScaleDPI"/>
    public Vector2 GetScaleDpi() => Raylib.GetWindowScaleDPI();
    
    /// <inheritdoc cref="Raylib.GetMonitorName_"/>
    public string GetMonitorName(int monitor) => Raylib.GetMonitorName_(monitor);
    
    /// <inheritdoc cref="Raylib.GetClipboardText_"/>
    public string GetClipboardText() => Raylib.GetClipboardText_();
    
    public void Dispose()
    {
        if (!IsReady()) return;
        this.Close();
        _instance = null;
    }
}