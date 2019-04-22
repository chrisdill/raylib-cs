using System;
using System.IO;
using System.Collections.Generic;
using System.Security;
using System.Runtime.InteropServices;

namespace Raylib
{
    [SuppressUnmanagedCodeSecurity]
    public static partial class Raylib
    {
        public const string nativeLibName = "raylib";
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitWindow(int width, int height, IntPtr title);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WindowShouldClose();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseWindow();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsWindowReady();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsWindowMinimized();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsWindowResized();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsWindowHidden();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ToggleFullscreen();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnhideWindow();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideWindow();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowIcon(Image image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowTitle(IntPtr title);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowPosition(int x, int y);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMonitor(int monitor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMinSize(int width, int height);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowSize(int width, int height);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWindowHandle();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenWidth();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenHeight();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorCount();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorWidth(int monitor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorHeight(int monitor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorPhysicalWidth(int monitor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMonitorPhysicalHeight(int monitor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetMonitorName(int monitor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetClipboardText();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetClipboardText(IntPtr text);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowCursor();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideCursor();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsCursorHidden();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableCursor();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableCursor();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearBackground(Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginDrawing();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndDrawing();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginMode2D(Camera2D camera);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndMode2D();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginMode3D(Camera3D camera);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndMode3D();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginTextureMode(RenderTexture2D target);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndTextureMode();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Ray GetMouseRay(Vector2 mousePosition, Camera3D camera);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetWorldToScreen(Vector3 position, Camera3D camera);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix GetCameraMatrix(Camera3D camera);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTargetFPS(int fps);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFPS();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetFrameTime();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetTime();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ColorToInt(Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector4 ColorNormalize(Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector3 ColorToHSV(Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color ColorFromHSV(Vector3 hsv);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GetColor(int hexValue);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color Fade(Color color, float alpha);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetConfigFlags(byte flags);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLogLevel(int logType);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLogExit(int logType);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTraceLogCallback(TraceLogCallback callback);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TraceLog(int logType, IntPtr text, params object[] args);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TakeScreenshot(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRandomValue(int min, int max);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FileExists(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsFileExtension(IntPtr fileName, IntPtr ext);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetExtension(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetFileName(IntPtr filePath);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetFileNameWithoutExt(IntPtr filePath);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDirectoryPath(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWorkingDirectory();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDirectoryFiles(IntPtr dirPath, IntPtr count);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearDirectoryFiles();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ChangeDirectory(IntPtr dir);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsFileDropped();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDroppedFiles(IntPtr count);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearDroppedFiles();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetFileModTime(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StorageSaveValue(int position, int value);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StorageLoadValue(int position);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenURL(IntPtr url);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyPressed(int key);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyDown(int key);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyReleased(int key);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsKeyUp(int key);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetKeyPressed();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetExitKey(int key);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadAvailable(int gamepad);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadName(int gamepad, IntPtr name);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetGamepadName(int gamepad);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonPressed(int gamepad, int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonDown(int gamepad, int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonReleased(int gamepad, int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGamepadButtonUp(int gamepad, int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadButtonPressed();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGamepadAxisCount(int gamepad);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGamepadAxisMovement(int gamepad, int axis);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonPressed(int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonDown(int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonReleased(int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMouseButtonUp(int button);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseX();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseY();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetMousePosition();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMousePosition(int x, int y);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMouseOffset(int offsetX, int offsetY);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMouseScale(float scaleX, float scaleY);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMouseWheelMove();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchX();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchY();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetTouchPosition(int index);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGesturesEnabled(uint gestureFlags);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsGestureDetected(int gesture);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGestureDetected();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTouchPointsCount();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureHoldDuration();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGestureDragVector();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGestureDragAngle();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GetGesturePinchVector();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetGesturePinchAngle();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMode(Camera3D camera, int mode);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateCamera(IntPtr camera);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraPanControl(int panKey);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraAltControl(int altKey);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraSmoothZoomControl(int szKey);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCameraMoveControls(int frontKey, int backKey, int rightKey, int leftKey, int upKey, int downKey);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixel(int posX, int posY, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPixelV(Vector2 position, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineV(Vector2 startPos, Vector2 endPos, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircle(int centerX, int centerY, float radius, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleSector(Vector2 center, float radius, int startAngle, int endAngle, int segments, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleSectorLines(Vector2 center, float radius, int startAngle, int endAngle, int segments, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleV(Vector2 center, float radius, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircleLines(int centerX, int centerY, float radius, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRing(Vector2 center, float innerRadius, float outerRadius, int startAngle, int endAngle, int segments, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRingLines(Vector2 center, float innerRadius, float outerRadius, int startAngle, int endAngle, int segments, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangle(int posX, int posY, int width, int height, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleV(Vector2 position, Vector2 size, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRec(Rectangle rec, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleLines(int posX, int posY, int width, int height, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleLinesEx(Rectangle rec, int lineThick, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, int lineThick, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPolyEx(IntPtr points, int numPoints, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPolyExLines(IntPtr points, int numPoints, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShapesTexture(Texture2D texture, Rectangle source);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRecs(Rectangle rec1, Rectangle rec2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionPointRec(Vector2 point, Rectangle rec);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImage(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageEx(IntPtr pixels, int width, int height);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImagePro(IntPtr data, int width, int height, int format);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image LoadImageRaw(IntPtr fileName, int width, int height, int format, int headerSize);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportImage(Image image, IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportImageAsCode(Image image, IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTexture(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTextureFromImage(Image image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D LoadTextureCubemap(Image image, int layoutType);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderTexture2D LoadRenderTexture(int width, int height);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadImage(Image image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadTexture(Texture2D texture);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadRenderTexture(RenderTexture2D target);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetImageData(Image image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetImageDataNormalized(Image image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPixelDataSize(int width, int height, int format);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GetTextureData(Texture2D texture);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GetScreenData();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateTexture(Texture2D texture, IntPtr pixels);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageCopy(Image image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageToPOT(IntPtr image, Color fillColor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFormat(IntPtr image, int newFormat);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaMask(IntPtr image, Image alphaMask);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaClear(IntPtr image, Color color, float threshold);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaCrop(IntPtr image, float threshold);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageAlphaPremultiply(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageCrop(IntPtr image, Rectangle crop);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResize(IntPtr image, int newWidth, int newHeight);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeNN(IntPtr image, int newWidth, int newHeight);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageResizeCanvas(IntPtr image, int newWidth, int newHeight, int offsetX, int offsetY, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageMipmaps(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDither(IntPtr image, int rBpp, int gBpp, int bBpp, int aBpp);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ImageExtractPalette(Image image, int maxPaletteSize, IntPtr extractCount);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageText(IntPtr text, int fontSize, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image ImageTextEx(Font font, IntPtr text, float fontSize, float spacing, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDraw(IntPtr dst, Image src, Rectangle srcRec, Rectangle dstRec);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangle(IntPtr dst, Rectangle rec, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawRectangleLines(IntPtr dst, Rectangle rec, int thick, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawText(IntPtr dst, Vector2 position, IntPtr text, int fontSize, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageDrawTextEx(IntPtr dst, Vector2 position, Font font, IntPtr text, float fontSize, float spacing, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipVertical(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageFlipHorizontal(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCW(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageRotateCCW(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorTint(IntPtr image, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorInvert(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorGrayscale(IntPtr image);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorContrast(IntPtr image, float contrast);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorBrightness(IntPtr image, int brightness);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImageColorReplace(IntPtr image, Color color, Color replace);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageColor(int width, int height, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientV(int width, int height, Color top, Color bottom);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientH(int width, int height, Color left, Color right);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageWhiteNoise(int width, int height, float factor);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImagePerlinNoise(int width, int height, int offsetX, int offsetY, float scale);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageCellular(int width, int height, int tileSize);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenTextureMipmaps(IntPtr texture);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextureFilter(Texture2D texture, int filterMode);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextureWrap(Texture2D texture, int wrapMode);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexture(Texture2D texture, int posX, int posY, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureV(Texture2D texture, Vector2 position, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureRec(Texture2D texture, Rectangle sourceRec, Vector2 position, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureQuad(Texture2D texture, Vector2 tiling, Vector2 offset, Rectangle quad, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTexturePro(Texture2D texture, Rectangle sourceRec, Rectangle destRec, Vector2 origin, float rotation, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextureNPatch(Texture2D texture, NPatchInfo nPatchInfo, Rectangle destRec, Vector2 origin, float rotation, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font GetFontDefault();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFont(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontEx(IntPtr fileName, int fontSize, IntPtr fontChars, int charsCount);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font LoadFontFromImage(Image image, Color key, int firstChar);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadFontData(IntPtr fileName, int fontSize, IntPtr fontChars, int charsCount, int type);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Image GenImageFontAtlas(IntPtr chars, int charsCount, int fontSize, int padding, int packMethod);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadFont(Font font);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawFPS(int posX, int posY);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawText(IntPtr text, int posX, int posY, int fontSize, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextEx(Font font, IntPtr text, Vector2 position, float fontSize, float spacing, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextRec(Font font, IntPtr text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawTextRecEx(Font font, IntPtr text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectText, Color selectBack);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MeasureText(IntPtr text, int fontSize);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 MeasureTextEx(Font font, IntPtr text, float fontSize, float spacing);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGlyphIndex(Font font, int character);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool TextIsEqual(IntPtr text1, IntPtr text2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsigned int  TextLength(IntPtr text);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextFormat(IntPtr text, params object[] args);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextSubtext(IntPtr text, int position, int length);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextReplace(IntPtr text, IntPtr replace, IntPtr by);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextInsert(IntPtr text, IntPtr insert, int position);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextJoin(IntPtr textList, int count, IntPtr delimiter);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextSplit(IntPtr text, char delimiter, IntPtr count);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TextAppend(IntPtr text, IntPtr append, IntPtr position);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextFindIndex(IntPtr text, IntPtr find);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextToUpper(IntPtr text);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextToLower(IntPtr text);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TextToPascal(IntPtr text);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextToInteger(IntPtr text);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCube(Vector3 position, float width, float height, float length, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeV(Vector3 position, Vector3 size, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeWires(Vector3 position, float width, float height, float length, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeWiresV(Vector3 position, Vector3 size, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCubeTexture(Texture2D texture, Vector3 position, float width, float height, float length, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphere(Vector3 centerPos, float radius, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawPlane(Vector3 centerPos, Vector2 size, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRay(Ray ray, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawGrid(int slices, float spacing);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawGizmo(Vector3 position);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModel(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Model LoadModelFromMesh(Mesh mesh);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModel(Model model);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadMeshes(IntPtr fileName, IntPtr meshCount);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportMesh(Mesh mesh, IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMesh(IntPtr mesh);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadMaterials(IntPtr fileName, IntPtr materialCount);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Material LoadMaterialDefault();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMaterial(Material material);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMaterialTexture(IntPtr material, int mapType, Texture2D texture);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModelMeshMaterial(IntPtr model, int meshId, int materialId);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadModelAnimations(IntPtr fileName, IntPtr animsCount);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateModelAnimation(Model model, ModelAnimation anim, int frame);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadModelAnimation(ModelAnimation anim);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsModelAnimationValid(Model model, ModelAnimation anim);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshPoly(int sides, float radius);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshPlane(float width, float length, int resX, int resZ);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCube(float width, float height, float length);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshSphere(float radius, int rings, int slices);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshHemiSphere(float radius, int rings, int slices);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCylinder(float radius, float height, int slices);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshTorus(float radius, float size, int radSeg, int sides);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshKnot(float radius, float size, int radSeg, int sides);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshHeightmap(Image heightmap, Vector3 size);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern BoundingBox MeshBoundingBox(Mesh mesh);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MeshTangents(IntPtr mesh);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MeshBinormals(IntPtr mesh);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModel(Model model, Vector3 position, float scale, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelWires(Model model, Vector3 position, float scale, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBoundingBox(BoundingBox box, Color color);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboard(Camera3D camera, Texture2D texture, Vector3 center, float size, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawBillboardRec(Camera3D camera, Texture2D texture, Rectangle sourceRec, Vector3 center, float size, Color tint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionSpheres(Vector3 centerA, float radiusA, Vector3 centerB, float radiusB);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionBoxSphere(BoundingBox box, Vector3 centerSphere, float radiusSphere);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRaySphere(Ray ray, Vector3 spherePosition, float sphereRadius);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRaySphereEx(Ray ray, Vector3 spherePosition, float sphereRadius, IntPtr collisionPoint);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckCollisionRayBox(Ray ray, BoundingBox box);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayModel(Ray ray, IntPtr model);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RayHitInfo GetCollisionRayGround(Ray ray, float groundHeight);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadText(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader LoadShader(IntPtr vsFileName, IntPtr fsFileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader LoadShaderCode(IntPtr vsCode, IntPtr fsCode);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadShader(Shader shader);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Shader GetShaderDefault();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GetTextureDefault();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetShaderLocation(Shader shader, IntPtr uniformName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValue(Shader shader, int uniformLoc, IntPtr value, int uniformType);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueV(Shader shader, int uniformLoc, IntPtr value, int uniformType, int count);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueMatrix(Shader shader, int uniformLoc, Matrix mat);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetShaderValueTexture(Shader shader, int uniformLoc, Texture2D texture);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMatrixProjection(Matrix proj);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMatrixModelview(Matrix view);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix GetMatrixModelview();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTextureCubemap(Shader shader, Texture2D skyHDR, int size);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTextureIrradiance(Shader shader, Texture2D cubemap, int size);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTexturePrefilter(Shader shader, Texture2D cubemap, int size);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture2D GenTextureBRDF(Shader shader, int size);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginShaderMode(Shader shader);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndShaderMode();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginBlendMode(int mode);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndBlendMode();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginScissorMode(int x, int y, int width, int height);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndScissorMode();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitVrSimulator();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseVrSimulator();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateVrTracking(IntPtr camera);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVrConfiguration(VrDeviceInfo info, Shader distortion);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsVrSimulatorReady();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ToggleVrMode();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginVrDrawing();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndVrDrawing();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitAudioDevice();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioDevice();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsAudioDeviceReady();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMasterVolume(float volume);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWave(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave LoadWaveEx(IntPtr data, int sampleCount, int sampleRate, int sampleSize, int channels);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSound(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Sound LoadSoundFromWave(Wave wave);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateSound(Sound sound, IntPtr data, int samplesCount);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadWave(Wave wave);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadSound(Sound sound);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportWave(Wave wave, IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ExportWaveAsCode(Wave wave, IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlaySound(Sound sound);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseSound(Sound sound);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeSound(Sound sound);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopSound(Sound sound);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsSoundPlaying(Sound sound);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundVolume(Sound sound, float volume);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSoundPitch(Sound sound, float pitch);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveFormat(IntPtr wave, int sampleRate, int sampleSize, int channels);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Wave WaveCopy(Wave wave);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveCrop(IntPtr wave, int initSample, int finalSample);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaveData(Wave wave);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Music LoadMusicStream(IntPtr fileName);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnloadMusicStream(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayMusicStream(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateMusicStream(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopMusicStream(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseMusicStream(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeMusicStream(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMusicPlaying(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicVolume(Music music, float volume);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicPitch(Music music, float pitch);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMusicLoopCount(Music music, int count);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimeLength(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetMusicTimePlayed(Music music);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern AudioStream InitAudioStream(uint sampleRate, uint sampleSize, uint channels);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdateAudioStream(AudioStream stream, IntPtr data, int samplesCount);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseAudioStream(AudioStream stream);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsAudioBufferProcessed(AudioStream stream);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayAudioStream(AudioStream stream);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseAudioStream(AudioStream stream);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeAudioStream(AudioStream stream);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsAudioStreamPlaying(AudioStream stream);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopAudioStream(AudioStream stream);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamVolume(AudioStream stream, float volume);
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAudioStreamPitch(AudioStream stream, float pitch);
    }
}