using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Utility functions for parts of the api that are not easy to interact with via pinvoke.
    /// </summary>
    public static unsafe partial class Raylib
    {
        public static void InitWindow(int width, int height, Utf8String title)
        {
            fixed (byte* p = title)
            {
                InitWindow(width, height, p);
            }
        }

        public static void SetWindowTitle(Utf8String title)
        {
            fixed (byte* p = title)
            {
                SetWindowTitle(p);
            }
        }

        /// <summary>Get the human-readable, UTF-8 encoded name of the primary monitor</summary>
        public static Utf8String GetMonitorName_(int monitor)
        {
            return Utf8String.FromPtr(GetMonitorName(monitor));
        }

        /// <summary>Get clipboard text content</summary>
        public static Utf8String GetClipboardText_()
        {
            return Utf8String.FromPtr(GetClipboardText());
        }

        public static void SetClipboardText(Utf8String text)
        {
            fixed (byte* p = text)
            {
                SetClipboardText(p);
            }
        }

        /// <summary>Set custom trace log</summary>
        public static void SetTraceLogCallback_(TraceLogCallback callback)
        {
            SetTraceLogCallback(callback);
            traceLogCallback = callback;
        }

        /// <summary>Return gamepad internal name id</summary>
        public static Utf8String GetGamepadName_(int gamepad)
        {
            return Utf8String.FromPtr(GetGamepadName(gamepad));
        }

        public static void ImageDrawText(ref Image dst, Utf8String text, int x, int y, int fontSize, Color color)
        {
            fixed (byte* p = text)
            {
                fixed (Image* i = &dst)
                {
                    ImageDrawText(i, p, x, y, fontSize, color);
                }
            }
        }

        public static void DrawText(Utf8String text, int posX, int posY, int fontSize, Color color)
        {
            fixed (byte* p = text)
            {
                DrawText(p, posX, posY, fontSize, color);
            }
        }

        public static void DrawTextEx(Font font, Utf8String text, Vector2 position, float fontSize, float spacing, Color tint)
        {
            fixed (byte* p = text)
            {
                DrawTextEx(font, p, position, fontSize, spacing, tint);
            }
        }

        public static void DrawTextPro(Font font, Utf8String text, Vector2 position, float fontSize, float spacing, Color tint)
        {
            fixed (byte* p = text)
            {
                DrawTextEx(font, p, position, fontSize, spacing, tint);
            }
        }

        public static int MeasureText(Utf8String text, int fontSize)
        {
            fixed (byte* p = text)
            {
                return MeasureText(p, fontSize);
            }
        }

        public static Vector2 MeasureTextEx(Font font, Utf8String text, float fontSize, float spacing)
        {
            fixed (byte* p = text)
            {
                return MeasureTextEx(font, p, fontSize, spacing);
            }
        }

        public static void TextAppend(Utf8String text, Utf8String append, int position)
        {
            fixed (byte* p1 = text)
            {
                fixed (byte* p2 = append)
                {
                    TextAppend(p1, p2, &position);
                }
            }
        }

        public static Utf8String TextToPascal(Utf8String text)
        {
            fixed (byte* p1 = text)
            {
                return Utf8String.FromPtr(TextToPascal(p1));
            }
        }

        public static int TextToInteger(Utf8String text)
        {
            fixed (byte* p1 = text)
            {
                return TextToInteger(p1);
            }
        }

        public static int[] LoadCodepoints(Utf8String text, ref int count)
        {
            fixed (byte* p1 = text)
            {
                fixed (int* c = &count)
                {
                    var pointsPtr = LoadCodepoints(p1, c);
                    var codepoints = new ReadOnlySpan<int>(pointsPtr, count).ToArray();
                    UnloadCodepoints(pointsPtr);
                    return codepoints;
                }
            }
        }

        public static int GetCodepointCount(Utf8String text)
        {
            fixed (byte* p1 = text)
            {
                return GetCodepointCount(p1);
            }
        }

        /// <summary>Returns next codepoint in a UTF8 encoded string; 0x3f('?') is returned on failure</summary>
        /// <returns>single codepoint / "char"</returns>
        public static int GetCodepoint(Utf8String text, ref int bytesProcessed)
        {
            fixed (byte* p1 = text)
            {
                // this probably wont work
                fixed (int* p = &bytesProcessed)
                {
                    return GetCodepoint(p1, p);
                }
            }
        }

        public static Utf8String CodepointToUTF8(int codepoint, ref int byteSize)
        {
            fixed (int* l1 = &byteSize)
            {
                var ptr = CodepointToUTF8(codepoint, l1);
                return Utf8String.FromPtr(ptr);
            }
        }

        public static Utf8String TextCodepointsToUTF8(int[] codepoints, int length)
        {
            fixed (int* c1 = codepoints)
            {
                var ptr = TextCodepointsToUTF8(c1, length);
                return Utf8String.FromPtr(ptr);
            }
        }

        public static ReadOnlySpan<ModelAnimation> LoadModelAnimations(Utf8String fileName, ref int animsCount)
        {
            fixed (byte* p1 = fileName)
            {
                fixed (int* p2 = &animsCount)
                {
                    var model = LoadModelAnimations(p1, p2);

                    if ((IntPtr)model == IntPtr.Zero)
                    {
                        throw new ApplicationException("Failed to load animation");
                    }

                    return new ReadOnlySpan<ModelAnimation>(model, animsCount);
                }
            }
        }

        public static string SubText(this string input, int position, int length)
        {
            return input.Substring(position, Math.Min(length, input.Length));
        }

        public static string[] GetDroppedFiles()
        {
            int count;
            var buffer = GetDroppedFiles(&count);
            var files = new string[count];

            for (var i = 0; i < count; i++)
            {
                files[i] = Marshal.PtrToStringUTF8((IntPtr)buffer[i]);
            }

            ClearDroppedFiles();

            return files;
        }

        public static Material GetMaterial(ref Model model, int materialIndex)
        {
            return model.materials[materialIndex];
        }

        public static Texture2D GetMaterialTexture(ref Model model, int materialIndex, MaterialMapIndex mapIndex)
        {
            return model.materials[materialIndex].maps[(int)mapIndex].texture;
        }

        public static void SetMaterialTexture(ref Model model, int materialIndex, MaterialMapIndex mapIndex, ref Texture2D texture)
        {
            SetMaterialTexture(&model.materials[materialIndex], (int)mapIndex, texture);
        }

        public static void SetMaterialShader(ref Model model, int materialIndex, ref Shader shader)
        {
            model.materials[materialIndex].shader = shader;
        }

        public static void SetShaderValueV<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType, int count)
        where T : unmanaged
        {
            SetShaderValueV(shader, uniformLoc, (Span<T>)values, uniformType, count);
        }

        public static void SetShaderValueV<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType, int count)
        where T : unmanaged
        {
            fixed (T* valuePtr = values)
            {
                SetShaderValueV(shader, uniformLoc, valuePtr, uniformType, count);
            }
        }

        public static void SetShaderValue<T>(Shader shader, int uniformLoc, T value, ShaderUniformDataType uniformType)
        where T : unmanaged
        {
            SetShaderValue(shader, uniformLoc, &value, uniformType);
        }

        public static void SetShaderValue<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType)
        where T : unmanaged
        {
            SetShaderValue(shader, uniformLoc, (Span<T>)values, uniformType);
        }

        public static void SetShaderValue<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType)
        where T : unmanaged
        {
            fixed (T* valuePtr = values)
            {
                SetShaderValue(shader, uniformLoc, valuePtr, uniformType);
            }
        }
    }
}
