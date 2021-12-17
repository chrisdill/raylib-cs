using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    public static unsafe partial class Raylib
    {
        /// <summary>Initialize window and OpenGL context</summary>
        public static void InitWindow(int width, int height, string title)
        {
            fixed (byte* b = title.GetUTF8Bytes())
            {
                InitWindow(width, height, b);
            }
        }

        /// <summary>Set title for window (only PLATFORM_DESKTOP)</summary>
        public static void SetWindowTitle(string title)
        {
            fixed (byte* b = title.GetUTF8Bytes())
            {
                SetWindowTitle(b);
            }
        }

        /// <summary>Get the human-readable, UTF-8 encoded name of the primary monitor</summary>
        public static string GetMonitorName_(int monitor)
        {
            return Utf8StringUtils.GetUTF8String(GetMonitorName(monitor));
        }

        /// <summary>Get clipboard text content</summary>
        public static string GetClipboardText_()
        {
            return Utf8StringUtils.GetUTF8String(GetClipboardText());
        }

        /// <summary>Set clipboard text content</summary>
        public static void SetClipboardText(string text)
        {
            fixed (byte* p = text.GetUTF8Bytes())
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

        /// <summary>Get dropped files names (memory should be freed)</summary>
        public static string[] GetDroppedFiles()
        {
            int count;
            var buffer = GetDroppedFiles(&count);
            var files = new string[count];

            for (var i = 0; i < count; i++)
            {
                files[i] = Marshal.PtrToStringUTF8((IntPtr)buffer[i]);
            }

            return files;
        }

        /// <summary>Return gamepad internal name id</summary>
        public static string GetGamepadName_(int gamepad)
        {
            return Utf8StringUtils.GetUTF8String(GetGamepadName(gamepad));
        }

        /// <inheritdoc cref="UpdateCamera(Camera3D*)"/>
        public static void UpdateCamera(ref Camera3D camera)
        {
            fixed (Camera3D* c = &camera)
            {
                UpdateCamera(c);
            }
        }

        /// <summary>Create an image from text (default font)</summary>
        public static Image ImageText(string text, int fontSize, Color color)
        {
            fixed (byte* p = text.GetUTF8Bytes())
            {
                return ImageText(p, fontSize, color);
            }
        }

        /// <summary>Create an image from text (custom sprite font)</summary>
        public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
        {
            fixed (byte* p = text.GetUTF8Bytes())
            {
                return ImageTextEx(font, p, fontSize, spacing, tint);
            }
        }

        public static void ImageToPOT(ref Image image, Color fill)
        {
            fixed (Image* p = &image)
            {
                ImageToPOT(p, fill);
            }
        }

        public static void ImageFormat(ref Image image, PixelFormat newFormat)
        {
            fixed (Image* p = &image)
            {
                ImageFormat(p, newFormat);
            }
        }

        public static void ImageAlphaMask(ref Image image, Image alphaMask)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaMask(p, alphaMask);
            }
        }

        public static void ImageAlphaClear(ref Image image, Color color, float threshold)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaClear(p, color, threshold);
            }
        }

        public static void ImageAlphaCrop(ref Image image, float threshold)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaCrop(p, threshold);
            }
        }

        public static void ImageAlphaPremultiply(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaPremultiply(p);
            }
        }

        public static void ImageCrop(ref Image image, Rectangle crop)
        {
            fixed (Image* p = &image)
            {
                ImageCrop(p, crop);
            }
        }

        public static void ImageResize(ref Image image, int newWidth, int newHeight)
        {
            fixed (Image* p = &image)
            {
                ImageResize(p, newWidth, newHeight);
            }
        }

        public static void ImageResizeNN(ref Image image, int newWidth, int newHeight)
        {
            fixed (Image* p = &image)
            {
                ImageResizeNN(p, newWidth, newHeight);
            }
        }

        public static void ImageResizeCanvas(ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color color)
        {
            fixed (Image* p = &image)
            {
                ImageResizeCanvas(p, newWidth, newHeight, offsetX, offsetY, color);
            }
        }

        public static void ImageMipmaps(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageMipmaps(p);
            }
        }

        public static void ImageDither(ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
        {
            fixed (Image* p = &image)
            {
                ImageDither(p, rBpp, gBpp, bBpp, aBpp);
            }
        }

        public static void ImageFlipVertical(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageFlipVertical(p);
            }
        }

        public static void ImageFlipHorizontal(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageFlipHorizontal(p);
            }
        }

        public static void ImageRotateCW(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageRotateCW(p);
            }
        }

        public static void ImageRotateCCW(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageRotateCCW(p);
            }
        }

        public static void ImageColorTint(ref Image image, Color color)
        {
            fixed (Image* p = &image)
            {
                ImageColorTint(p, color);
            }
        }

        public static void ImageColorInvert(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageColorInvert(p);
            }
        }

        public static void ImageColorGrayscale(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageColorGrayscale(p);
            }
        }

        public static void ImageColorContrast(ref Image image, float contrast)
        {
            fixed (Image* p = &image)
            {
                ImageColorContrast(p, contrast);
            }
        }

        public static void ImageColorBrightness(ref Image image, int brightness)
        {
            fixed (Image* p = &image)
            {
                ImageColorBrightness(p, brightness);
            }
        }

        public static void ImageColorReplace(ref Image image, Color color, Color replace)
        {
            fixed (Image* p = &image)
            {
                ImageColorReplace(p, color, replace);
            }
        }

        /// <inheritdoc cref="ImageDrawPixel(Image*, int, int, Color)"/>
        public static void ImageDrawPixel(ref Image dst, int posX, int posY, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawPixel(p, posX, posY, color);
            }
        }

        /// <inheritdoc cref="ImageDrawPixelV(Image*, Vector2, Color)"/>
        public static void ImageDrawPixelV(ref Image dst, Vector2 position, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawPixelV(p, position, color);
            }
        }

        /// <inheritdoc cref="ImageDrawText(Image*, byte*, int, int, int, Color)"/>
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

        public static void ImageDrawTextEx(ref Image dst, Font font, Utf8String text, Vector2 position, int fontSize, float spacing, Color color)
        {
            fixed (byte* p = text)
            {
                fixed (Image* i = &dst)
                {
                    ImageDrawTextEx(i, font, p, position, fontSize, spacing, color);
                }
            }
        }

        public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
        {
            fixed (byte* p = text.GetUTF8Bytes())
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

        public static string TextToPascal(Utf8String text)
        {
            fixed (byte* p1 = text)
            {
                return Utf8StringUtils.GetUTF8String(TextToPascal(p1));
            }
        }

        public static int TextToInteger(Utf8String text)
        {
            fixed (byte* p1 = text)
            {
                return TextToInteger(p1);
            }
        }

        public static int[] LoadCodepoints(string text, ref int count)
        {
            fixed (byte* p1 = text.GetUTF8Bytes())
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
        public static int GetCodepoint(string text, ref int bytesProcessed)
        {
            fixed (byte* p1 = text.GetUTF8Bytes())
            {
                // this probably wont work
                fixed (int* p = &bytesProcessed)
                {
                    return GetCodepoint(p1, p);
                }
            }
        }

        public static string CodepointToUTF8(int codepoint, ref int byteSize)
        {
            fixed (int* l1 = &byteSize)
            {
                var ptr = CodepointToUTF8(codepoint, l1);
                return Utf8StringUtils.GetUTF8String(ptr);
            }
        }

        public static string TextCodepointsToUTF8(int[] codepoints, int length)
        {
            fixed (int* c1 = codepoints)
            {
                var ptr = TextCodepointsToUTF8(c1, length);
                return Utf8StringUtils.GetUTF8String(ptr);
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
