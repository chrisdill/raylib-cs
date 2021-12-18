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

        /// <summary>Set shader uniform value vector</summary>
        public static void SetShaderValueV<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType, int count)
        where T : unmanaged
        {
            SetShaderValueV(shader, uniformLoc, (Span<T>)values, uniformType, count);
        }

        /// <summary>Set shader uniform value vector</summary>
        public static void SetShaderValueV<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType, int count)
        where T : unmanaged
        {
            fixed (T* valuePtr = values)
            {
                SetShaderValueV(shader, uniformLoc, valuePtr, uniformType, count);
            }
        }

        /// <summary>Set shader uniform value</summary>
        public static void SetShaderValue<T>(Shader shader, int uniformLoc, T value, ShaderUniformDataType uniformType)
        where T : unmanaged
        {
            SetShaderValue(shader, uniformLoc, &value, uniformType);
        }

        /// <summary>Set shader uniform value</summary>
        public static void SetShaderValue<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType)
        where T : unmanaged
        {
            SetShaderValue(shader, uniformLoc, (Span<T>)values, uniformType);
        }

        /// <summary>Set shader uniform value</summary>
        public static void SetShaderValue<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType)
        where T : unmanaged
        {
            fixed (T* valuePtr = values)
            {
                SetShaderValue(shader, uniformLoc, valuePtr, uniformType);
            }
        }

        [DllImport(nativeLibName, EntryPoint = "SetTraceLogCallback", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetTraceLogCallbackInternal(TraceLogCallback callback);

        /// <summary>Set custom trace log</summary>
        public static void SetTraceLogCallback(TraceLogCallback callback)
        {
            SetTraceLogCallbackInternal(callback);
            traceLogCallback = callback;
        }

        /// <summary>Load file data as byte array (read)</summary>
        public static byte* LoadFileData(string fileName, ref uint bytesRead)
        {
            fixed (uint* p = &bytesRead)
            {
                return LoadFileData(fileName, p);
            }
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

        /// <summary>Update camera position for selected mode</summary>
        public static void UpdateCamera(ref Camera3D camera)
        {
            fixed (Camera3D* c = &camera)
            {
                UpdateCamera(c);
            }
        }

        /// <summary>Check the collision between two lines defined by two points each, returns collision point by reference</summary>
        public static CBool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, ref Vector2 collisionPoint)
        {
            fixed (Vector2* p = &collisionPoint)
            {
                return CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, p);
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

        /// <summary>Convert image to POT (power-of-two)</summary>
        public static void ImageToPOT(ref Image image, Color fill)
        {
            fixed (Image* p = &image)
            {
                ImageToPOT(p, fill);
            }
        }

        /// <summary>Convert image data to desired format</summary>
        public static void ImageFormat(ref Image image, PixelFormat newFormat)
        {
            fixed (Image* p = &image)
            {
                ImageFormat(p, newFormat);
            }
        }

        /// <summary>Apply alpha mask to image</summary>
        public static void ImageAlphaMask(ref Image image, Image alphaMask)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaMask(p, alphaMask);
            }
        }

        /// <summary>Clear alpha channel to desired color</summary>
        public static void ImageAlphaClear(ref Image image, Color color, float threshold)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaClear(p, color, threshold);
            }
        }

        /// <summary>Crop image depending on alpha value</summary>
        public static void ImageAlphaCrop(ref Image image, float threshold)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaCrop(p, threshold);
            }
        }

        /// <summary>Premultiply alpha channel</summary>
        public static void ImageAlphaPremultiply(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageAlphaPremultiply(p);
            }
        }

        /// <summary>Crop an image to a defined rectangle</summary>
        public static void ImageCrop(ref Image image, Rectangle crop)
        {
            fixed (Image* p = &image)
            {
                ImageCrop(p, crop);
            }
        }

        /// <summary>Resize image (Bicubic scaling algorithm)</summary>
        public static void ImageResize(ref Image image, int newWidth, int newHeight)
        {
            fixed (Image* p = &image)
            {
                ImageResize(p, newWidth, newHeight);
            }
        }

        /// <summary>Resize image (Nearest-Neighbor scaling algorithm)</summary>
        public static void ImageResizeNN(ref Image image, int newWidth, int newHeight)
        {
            fixed (Image* p = &image)
            {
                ImageResizeNN(p, newWidth, newHeight);
            }
        }

        /// <summary>Resize canvas and fill with color</summary>
        public static void ImageResizeCanvas(ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color color)
        {
            fixed (Image* p = &image)
            {
                ImageResizeCanvas(p, newWidth, newHeight, offsetX, offsetY, color);
            }
        }

        /// <summary>Generate all mipmap levels for a provided image</summary>
        public static void ImageMipmaps(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageMipmaps(p);
            }
        }

        /// <summary>Dither image data to 16bpp or lower (Floyd-Steinberg dithering)</summary>
        public static void ImageDither(ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
        {
            fixed (Image* p = &image)
            {
                ImageDither(p, rBpp, gBpp, bBpp, aBpp);
            }
        }

        /// <summary>Flip image vertically</summary>
        public static void ImageFlipVertical(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageFlipVertical(p);
            }
        }

        /// <summary>Flip image horizontally</summary>
        public static void ImageFlipHorizontal(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageFlipHorizontal(p);
            }
        }

        /// <summary>Rotate image clockwise 90deg</summary>
        public static void ImageRotateCW(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageRotateCW(p);
            }
        }

        /// <summary>Rotate image counter-clockwise 90deg</summary>
        public static void ImageRotateCCW(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageRotateCCW(p);
            }
        }

        /// <summary>Modify image color: tint</summary>
        public static void ImageColorTint(ref Image image, Color color)
        {
            fixed (Image* p = &image)
            {
                ImageColorTint(p, color);
            }
        }

        /// <summary>Modify image color: invert</summary>
        public static void ImageColorInvert(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageColorInvert(p);
            }
        }

        /// <summary>Modify image color: grayscale</summary>
        public static void ImageColorGrayscale(ref Image image)
        {
            fixed (Image* p = &image)
            {
                ImageColorGrayscale(p);
            }
        }

        /// <summary>Modify image color: contrast (-100 to 100)</summary>
        public static void ImageColorContrast(ref Image image, float contrast)
        {
            fixed (Image* p = &image)
            {
                ImageColorContrast(p, contrast);
            }
        }

        /// <summary>Modify image color: brightness (-255 to 255)</summary>
        public static void ImageColorBrightness(ref Image image, int brightness)
        {
            fixed (Image* p = &image)
            {
                ImageColorBrightness(p, brightness);
            }
        }

        /// <summary>Modify image color: replace color</summary>
        public static void ImageColorReplace(ref Image image, Color color, Color replace)
        {
            fixed (Image* p = &image)
            {
                ImageColorReplace(p, color, replace);
            }
        }

        /// <summary>Clear image background with given color</summary>
        public static void ImageClearBackground(ref Image dst, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageClearBackground(p, color);
            }
        }

        /// <summary>Draw pixel within an image</summary>
        public static void ImageDrawPixel(ref Image dst, int posX, int posY, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawPixel(p, posX, posY, color);
            }
        }

        /// <summary>Draw pixel within an image (Vector version)</summary>
        public static void ImageDrawPixelV(ref Image dst, Vector2 position, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawPixelV(p, position, color);
            }
        }

        /// <summary>Draw line within an image</summary>
        public static void ImageDrawLine(ref Image dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawLine(p, startPosX, startPosY, endPosX, endPosY, color);
            }
        }

        /// <summary>Draw line within an image (Vector version)</summary>
        public static void ImageDrawLineV(ref Image dst, Vector2 start, Vector2 end, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawLineV(p, start, end, color);
            }
        }

        /// <summary>Draw circle within an image</summary>
        public static void ImageDrawCircle(ref Image dst, int centerX, int centerY, int radius, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawCircle(p, centerX, centerY, radius, color);
            }
        }

        /// <summary>Draw circle within an image (Vector version)</summary>
        public static void ImageDrawCircleV(ref Image dst, Vector2 center, int radius, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawCircleV(p, center, radius, color);
            }
        }

        /// <summary>Draw rectangle within an image</summary>
        public static void ImageDrawRectangle(ref Image dst, int posX, int posY, int width, int height, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawRectangle(p, posX, posY, width, height, color);
            }
        }

        /// <summary>Draw rectangle within an image (Vector version)</summary>
        public static void ImageDrawRectangleV(ref Image dst, Vector2 position, Vector2 size, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawRectangleV(p, position, size, color);
            }
        }

        /// <summary>Draw rectangle within an image</summary>
        public static void ImageDrawRectangleRec(ref Image dst, Rectangle rec, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawRectangleRec(p, rec, color);
            }
        }

        /// <summary>Draw rectangle lines within an image</summary>
        public static void ImageDrawRectangleLines(ref Image dst, Rectangle rec, int thick, Color color)
        {
            fixed (Image* p = &dst)
            {
                ImageDrawRectangleLines(p, rec, thick, color);
            }
        }

        /// <summary>Draw a source image within a destination image (tint applied to source)</summary>
        public static void ImageDraw(ref Image dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint)
        {
            fixed (Image* p = &dst)
            {
                ImageDraw(p, src, srcRec, dstRec, tint);
            }
        }

        /// <summary>Draw text (using default font) within an image (destination)</summary>
        public static void ImageDrawText(ref Image dst, Utf8String text, int x, int y, int fontSize, Color color)
        {
            fixed (Image* p = &dst)
            {
                fixed (byte* p1 = text)
                {
                    ImageDrawText(p, p1, x, y, fontSize, color);
                }
            }
        }

        /// <summary>Draw text (custom sprite font) within an image (destination)</summary>
        public static void ImageDrawTextEx(ref Image dst, Font font, Utf8String text, Vector2 position, int fontSize, float spacing, Color color)
        {
            fixed (Image* p = &dst)
            {
                fixed (byte* p1 = text)
                {
                    ImageDrawTextEx(p, font, p1, position, fontSize, spacing, color);
                }
            }
        }

        /// <summary>Generate GPU mipmaps for a texture</summary>
        public static void GenTextureMipmaps(ref Texture2D texture)
        {
            fixed (Texture2D* p = &texture)
            {
                GenTextureMipmaps(p);
            }
        }

        /// <summary>Upload vertex data into GPU and provided VAO/VBO ids</summary>
        public static void UploadMesh(ref Mesh mesh, CBool dynamic)
        {
            fixed (Mesh* p = &mesh)
            {
                UploadMesh(p, dynamic);
            }
        }

        /// <summary>Unload mesh from memory (RAM and/or VRAM)</summary>
        public static void UnloadMesh(ref Mesh mesh)
        {
            fixed (Mesh* p = &mesh)
            {
                UnloadMesh(p);
            }
        }

        /// <summary>Set texture for a material map type (MAP_DIFFUSE, MAP_SPECULAR...)</summary>
        public static void SetMaterialTexture(ref Material material, MaterialMapIndex mapType, Texture2D texture)
        {
            fixed (Material* p = &material)
            {
                SetMaterialTexture(p, mapType, texture);
            }
        }

        /// <summary>Set material for a mesh</summary>
        public static void SetModelMeshMaterial(ref Model model, int meshId, int materialId)
        {
            fixed (Model* p = &model)
            {
                SetModelMeshMaterial(p, meshId, materialId);
            }
        }

        /// <summary>Load model animations from file</summary>
        public static ReadOnlySpan<ModelAnimation> LoadModelAnimations(Utf8String fileName, ref uint animsCount)
        {
            fixed (byte* p1 = fileName)
            {
                fixed (uint* p2 = &animsCount)
                {
                    var model = LoadModelAnimations(p1, p2);

                    if ((IntPtr)model == IntPtr.Zero)
                    {
                        throw new ApplicationException("Failed to load animation");
                    }

                    return new ReadOnlySpan<ModelAnimation>(model, (int)animsCount);
                }
            }
        }

        /// <summary>Compute mesh tangents</summary>
        public static void GenMeshTangents(ref Mesh mesh)
        {
            fixed (Mesh* p = &mesh)
            {
                GenMeshTangents(p);
            }
        }

        /// <summary>Compute mesh binormals</summary>
        public static void GenMeshBinormals(ref Mesh mesh)
        {
            fixed (Mesh* p = &mesh)
            {
                GenMeshBinormals(p);
            }
        }

        /// <summary>Convert wave data to desired format</summary>
        public static void WaveFormat(ref Wave wave, int sampleRate, int sampleSize, int channels)
        {
            fixed (Wave* p = &wave)
            {
                WaveFormat(p, sampleRate, sampleSize, channels);
            }
        }

        /// <summary>Crop a wave to defined samples range</summary>
        public static void WaveCrop(ref Wave wave, int initSample, int finalSample)
        {
            fixed (Wave* p = &wave)
            {
                WaveCrop(p, initSample, finalSample);
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

        /// <summary>Encode codepoint into utf8 text (char array length returned as parameter)</summary>
        public static string CodepointToUTF8(int codepoint, ref int byteSize)
        {
            fixed (int* l1 = &byteSize)
            {
                var ptr = CodepointToUTF8(codepoint, l1);
                return Utf8StringUtils.GetUTF8String(ptr);
            }
        }

        /// <summary>Encode codepoint into utf8 text (char array length returned as parameter)</summary>
        public static string TextCodepointsToUTF8(int[] codepoints, int length)
        {
            fixed (int* c1 = codepoints)
            {
                var ptr = TextCodepointsToUTF8(c1, length);
                var text = Utf8StringUtils.GetUTF8String(ptr);
                MemFree(ptr);
                return text;
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
            SetMaterialTexture(&model.materials[materialIndex], mapIndex, texture);
        }

        public static void SetMaterialShader(ref Model model, int materialIndex, ref Shader shader)
        {
            model.materials[materialIndex].shader = shader;
        }
    }
}
