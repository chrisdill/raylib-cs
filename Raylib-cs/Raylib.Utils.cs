using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Utility functions for parts of the api that are not easy to interact with via pinvoke.
    /// </summary>
    public static unsafe partial class Raylib
    {
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
            SetMaterialTexture(ref model.materials[materialIndex], (int)mapIndex, texture);
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
