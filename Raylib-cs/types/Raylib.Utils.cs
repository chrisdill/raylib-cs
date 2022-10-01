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
            using var str1 = title.ToUTF8Buffer();
            InitWindow(width, height, str1.AsPointer());
        }

        /// <summary>Set title for window (only PLATFORM_DESKTOP)</summary>
        public static void SetWindowTitle(string title)
        {
            using var str1 = title.ToUTF8Buffer();
            SetWindowTitle(str1.AsPointer());
        }

        /// <summary>Get the human-readable, UTF-8 encoded name of the specified monitor</summary>
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
            using var str1 = text.ToUTF8Buffer();
            SetClipboardText(str1.AsPointer());
        }

        /// <summary>Load shader from files and bind default locations</summary>
        public static Shader LoadShader(string vsFileName, string fsFileName)
        {
            using var str1 = vsFileName.ToUTF8Buffer();
            using var str2 = fsFileName.ToUTF8Buffer();
            return LoadShader(str1.AsPointer(), str2.AsPointer());
        }

        /// <summary>Load shader from code string and bind default locations</summary>
        public static Shader LoadShaderFromMemory(string vsCode, string fsCode)
        {
            using var str1 = vsCode.ToUTF8Buffer();
            using var str2 = fsCode.ToUTF8Buffer();
            return LoadShaderFromMemory(str1.AsPointer(), str2.AsPointer());
        }

        /// <summary>Get shader uniform location</summary>
        public static int GetShaderLocation(Shader shader, string uniformName)
        {
            using var str1 = uniformName.ToUTF8Buffer();
            return GetShaderLocation(shader, str1.AsPointer());
        }

        /// <summary>Get shader attribute location</summary>
        public static int GetShaderLocationAttrib(Shader shader, string attribName)
        {
            using var str1 = attribName.ToUTF8Buffer();
            return GetShaderLocationAttrib(shader, str1.AsPointer());
        }

        /// <summary>Takes a screenshot of current screen (saved a .png)</summary>
        public static void TakeScreenshot(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            TakeScreenshot(str1.AsPointer());
        }

        /// <summary>Check file extension</summary>
        public static CBool IsFileExtension(string fileName, string ext)
        {
            using var str1 = fileName.ToUTF8Buffer();
            using var str2 = ext.ToUTF8Buffer();
            return IsFileExtension(str1.AsPointer(), str2.AsPointer());
        }

        /// <summary>Get file modification time (last write time)</summary>
        public static long GetFileModTime(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return GetFileModTime(str1.AsPointer());
        }

        /// <summary>Load image from file into CPU memory (RAM)</summary>
        public static Image LoadImage(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadImage(str1.AsPointer());
        }

        /// <summary>Load image from RAW file data</summary>
        public static Image LoadImageRaw(string fileName, int width, int height, PixelFormat format, int headerSize)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadImageRaw(str1.AsPointer(), width, height, format, headerSize);
        }

        /// <summary>Load image sequence from file (frames appended to image.data)</summary>
        public static Image LoadImageAnim(string fileName, out int frames)
        {
            using var str1 = fileName.ToUTF8Buffer();
            fixed (int* p = &frames)
            {
                return LoadImageAnim(str1.AsPointer(), p);
            }
        }

        /// <summary>Export image data to file</summary>
        public static CBool ExportImage(Image image, string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return ExportImage(image, str1.AsPointer());
        }

        /// <summary>Export image as code file defining an array of bytes</summary>
        public static CBool ExportImageAsCode(Image image, string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return ExportImageAsCode(image, str1.AsPointer());
        }

        /// <summary>Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR)</summary>
        public static void TraceLog(TraceLogLevel logLevel, string text)
        {
            using var str1 = text.ToUTF8Buffer();
            TraceLog(logLevel, str1.AsPointer());
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

        /// <summary>Load file data as byte array (read)</summary>
        public static byte* LoadFileData(string fileName, ref uint bytesRead)
        {
            using var str1 = fileName.ToUTF8Buffer();
            fixed (uint* p = &bytesRead)
            {
                return LoadFileData(str1.AsPointer(), p);
            }
        }

        /// <summary>Get dropped files names (memory should be freed)</summary>
        public static string[] GetDroppedFiles()
        {
            var filePathList = LoadDroppedFiles();
            var files = new string[filePathList.count];

            for (var i = 0; i < filePathList.count; i++)
            {
                files[i] = Marshal.PtrToStringUTF8((IntPtr)filePathList.paths[i]);
            }
            UnloadDroppedFiles(filePathList);

            return files;
        }

        /// <summary>Get gamepad internal name id</summary>
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
            using var str1 = text.ToUTF8Buffer();
            return ImageText(str1.AsPointer(), fontSize, color);
        }

        /// <summary>Create an image from text (custom sprite font)</summary>
        public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
        {
            using var str1 = text.ToUTF8Buffer();
            return ImageTextEx(font, str1.AsPointer(), fontSize, spacing, tint);
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
        public static void ImageDrawText(ref Image dst, string text, int x, int y, int fontSize, Color color)
        {
            using var str1 = text.ToUTF8Buffer();
            fixed (Image* p = &dst)
            {
                ImageDrawText(p, str1.AsPointer(), x, y, fontSize, color);
            }
        }

        /// <summary>Draw text (custom sprite font) within an image (destination)</summary>
        public static void ImageDrawTextEx(ref Image dst, Font font, string text, Vector2 position, int fontSize, float spacing, Color color)
        {
            using var str1 = text.ToUTF8Buffer();
            fixed (Image* p = &dst)
            {
                ImageDrawTextEx(p, font, str1.AsPointer(), position, fontSize, spacing, color);
            }
        }

        /// <summary>Load texture from file into GPU memory (VRAM)</summary>
        public static Texture2D LoadTexture(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadTexture(str1.AsPointer());
        }

        /// <summary>Generate GPU mipmaps for a texture</summary>
        public static void GenTextureMipmaps(ref Texture2D texture)
        {
            fixed (Texture2D* p = &texture)
            {
                GenTextureMipmaps(p);
            }
        }

        /// <summary>Load font from file into GPU memory (VRAM)</summary>
        public static Font LoadFont(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadFont(str1.AsPointer());
        }

        /// <summary>Load font from file with extended parameters</summary>
        public static Font LoadFontEx(string fileName, int fontSize, int[] fontChars, int glyphCount)
        {
            using var str1 = fileName.ToUTF8Buffer();
            fixed (int* p = fontChars)
            {
                return LoadFontEx(str1.AsPointer(), fontSize, p, glyphCount);
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
        public static ReadOnlySpan<ModelAnimation> LoadModelAnimations(string fileName, ref uint animsCount)
        {
            using var str1 = fileName.ToUTF8Buffer();
            fixed (uint* p = &animsCount)
            {
                var model = LoadModelAnimations(str1.AsPointer(), p);

                if ((IntPtr)model == IntPtr.Zero)
                {
                    throw new ApplicationException("Failed to load animation");
                }

                return new ReadOnlySpan<ModelAnimation>(model, (int)animsCount);
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

        /// <summary>Draw lines sequence</summary>
        public static void DrawLineStrip(Vector2[] points, int numPoints, Color color)
        {
            fixed (Vector2* p = points)
            {
                DrawLineStrip(p, numPoints, color);
            }
        }

        /// <summary>Draw a triangle fan defined by points (first vertex is the center)</summary>
        public static void DrawTriangleFan(Vector2[] points, int numPoints, Color color)
        {
            fixed (Vector2* p = points)
            {
                DrawTriangleFan(p, numPoints, color);
            }
        }

        /// <summary>Draw a triangle strip defined by points</summary>
        public static void DrawTriangleStrip(Vector2[] points, int pointsCount, Color color)
        {
            fixed (Vector2* p = points)
            {
                DrawTriangleStrip(p, pointsCount, color);
            }
        }

        /// <summary>Draw a textured polygon</summary>
        public static void DrawTexturePoly(Texture2D texture, Vector2 center, Vector2[] points, Vector2[] texcoords, int pointsCount, Color tint)
        {
            fixed (Vector2* p = points)
            {
                fixed (Vector2* p1 = texcoords)
                {
                    DrawTexturePoly(texture, center, p, p1, pointsCount, tint);
                }
            }
        }

        /// <summary>Draw text (using default font)</summary>
        public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
        {
            using var str1 = text.ToUTF8Buffer();
            DrawText(str1.AsPointer(), posX, posY, fontSize, color);
        }

        /// <summary>Draw text using font and additional parameters</summary>
        public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
        {
            using var str1 = text.ToUTF8Buffer();
            DrawTextEx(font, str1.AsPointer(), position, fontSize, spacing, tint);
        }

        /// <summary>Draw text using Font and pro parameters (rotation)</summary>
        public static void DrawTextPro(Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
        {
            using var str1 = text.ToUTF8Buffer();
            DrawTextPro(font, str1.AsPointer(), position, origin, rotation, fontSize, spacing, tint);
        }

        /// <summary>Measure string width for default font</summary>
        public static int MeasureText(string text, int fontSize)
        {
            using var str1 = text.ToUTF8Buffer();
            return MeasureText(str1.AsPointer(), fontSize);
        }

        /// <summary>Measure string size for Font</summary>
        public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
        {
            using var str1 = text.ToUTF8Buffer();
            return MeasureTextEx(font, str1.AsPointer(), fontSize, spacing);
        }

        /// <summary>Append text at specific position and move cursor!</summary>
        public static void TextAppend(string text, string append, int position)
        {
            using var str1 = text.ToUTF8Buffer();
            using var str2 = append.ToUTF8Buffer();
            TextAppend(str1.AsPointer(), str2.AsPointer(), &position);
        }

        /// <summary>Get Pascal case notation version of provided string</summary>
        public static string TextToPascal(string text)
        {
            using var str1 = text.ToUTF8Buffer();
            return Utf8StringUtils.GetUTF8String(TextToPascal(str1.AsPointer()));
        }

        /// <summary>Get integer value from text (negative values not supported)</summary>
        public static int TextToInteger(string text)
        {
            using var str1 = text.ToUTF8Buffer();
            return TextToInteger(str1.AsPointer());
        }

        /// <summary>Get all codepoints in a string, codepoints count returned by parameters</summary>
        public static int[] LoadCodepoints(string text, ref int count)
        {
            using var str1 = text.ToUTF8Buffer();
            fixed (int* c = &count)
            {
                var pointsPtr = LoadCodepoints(str1.AsPointer(), c);
                var codepoints = new ReadOnlySpan<int>(pointsPtr, count).ToArray();
                UnloadCodepoints(pointsPtr);
                return codepoints;
            }
        }

        /// <summary>Get total number of characters (codepoints) in a UTF8 encoded string</summary>
        public static int GetCodepointCount(string text)
        {
            using var str1 = text.ToUTF8Buffer();
            return GetCodepointCount(str1.AsPointer());
        }

        /// <summary>Get next codepoint in a UTF8 encoded string; 0x3f('?') is returned on failure</summary>
        /// <returns>single codepoint / "char"</returns>
        public static int GetCodepoint(string text, ref int bytesProcessed)
        {
            using var str1 = text.ToUTF8Buffer();
            fixed (int* p = &bytesProcessed)
            {
                return GetCodepoint(str1.AsPointer(), p);
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

        /// <summary>Draw a model (with texture if set)</summary>
        public static Model LoadModel(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadModel(str1.AsPointer());
        }

        /// <summary>Export mesh data to file, returns true on success</summary>
        public static CBool ExportMesh(Mesh mesh, string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return ExportMesh(mesh, str1.AsPointer());
        }

        /// <summary>Draw a triangle strip defined by points</summary>
        public static void DrawTriangleStrip3D(Vector3[] points, int pointsCount, Color color)
        {
            fixed (Vector3* p = points)
            {
                DrawTriangleStrip3D(p, pointsCount, color);
            }
        }

        /// <summary>Draw multiple mesh instances with material and different transforms</summary>
        public static void DrawMeshInstanced(Mesh mesh, Material material, Matrix4x4[] transforms, int instances)
        {
            fixed (Matrix4x4* p = transforms)
            {
                DrawMeshInstanced(mesh, material, p, instances);
            }
        }

        /// <summary>Load wave data from file</summary>
        public static Wave LoadWave(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadWave(str1.AsPointer());
        }

        /// <summary>Load sound from file</summary>
        public static Sound LoadSound(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadSound(str1.AsPointer());
        }

        /// <summary>Export wave data to file</summary>
        public static CBool ExportWave(Wave wave, string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return ExportWave(wave, str1.AsPointer());
        }

        /// <summary>Export wave sample data to code (.h)</summary>
        public static CBool ExportWaveAsCode(Wave wave, string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return ExportWaveAsCode(wave, str1.AsPointer());
        }

        /// <summary>Load music stream from file</summary>
        public static Music LoadMusicStream(string fileName)
        {
            using var str1 = fileName.ToUTF8Buffer();
            return LoadMusicStream(str1.AsPointer());
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
