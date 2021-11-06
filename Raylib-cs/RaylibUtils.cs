using System;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace Raylib_cs
{
    /// <summary>
    /// Utility functions for parts of the api that are not easy to interact with via pinvoke.
    /// </summary>
    public static class Utils
    {
        public static string SubText(this string input, int position, int length)
        {
            return input.Substring(position, Math.Min(length, input.Length));
        }

        public static unsafe string[] GetDroppedFiles()
        {
            int count;
            var buffer = Raylib.GetDroppedFiles(&count);
            var files = new string[count];

            for (int i = 0; i < count; i++)
            {
                files[i] = Marshal.PtrToStringUTF8((IntPtr)buffer[i]);
            }

            Raylib.ClearDroppedFiles();

            return files;
        }

        public unsafe static Material GetMaterial(ref Model model, int materialIndex)
        {
            Material* materials = (Material*)model.materials.ToPointer();
            return *materials;
        }

        public unsafe static Texture2D GetMaterialTexture(ref Model model, int materialIndex, MaterialMapIndex mapIndex)
        {
            Material* materials = (Material*)model.materials.ToPointer();
            MaterialMap* maps = (MaterialMap*)materials[0].maps.ToPointer();
            return maps[(int)mapIndex].texture;
        }

        public unsafe static void SetMaterialTexture(ref Model model, int materialIndex, MaterialMapIndex mapIndex, ref Texture2D texture)
        {
            Material* materials = (Material*)model.materials.ToPointer();
            Raylib.SetMaterialTexture(ref materials[materialIndex], (int)mapIndex, texture);
        }

        public unsafe static void SetMaterialShader(ref Model model, int materialIndex, ref Shader shader)
        {
            Material* materials = (Material*)model.materials.ToPointer();
            materials[materialIndex].shader = shader;
        }

        public static unsafe void SetShaderValueV<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType, int count) where T : unmanaged
        {
            SetShaderValueV(shader, uniformLoc, (Span<T>)values, uniformType, count);
        }

        public static unsafe void SetShaderValueV<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType, int count) where T : unmanaged
        {
            fixed (T* valuePtr = values)
            {
                Raylib.SetShaderValueV(shader, uniformLoc, (IntPtr)valuePtr, uniformType, count);
            }
        }

        public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, ref T value, ShaderUniformDataType uniformType, int count = 0) where T : unmanaged
        {
            fixed (T* valuePtr = &value)
            {
                Raylib.SetShaderValue(shader, uniformLoc, (IntPtr)valuePtr, uniformType);
            }
        }

        public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, T value, ShaderUniformDataType uniformType) where T : unmanaged
        {
            Raylib.SetShaderValue(shader, uniformLoc, (IntPtr)(&value), uniformType);
        }

        public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType) where T : unmanaged
        {
            SetShaderValue(shader, uniformLoc, (Span<T>)values, uniformType);
        }

        public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType) where T : unmanaged
        {
            fixed (T* valuePtr = values)
            {
                Raylib.SetShaderValue(shader, uniformLoc, (IntPtr)valuePtr, uniformType);
            }
        }
    }
}
