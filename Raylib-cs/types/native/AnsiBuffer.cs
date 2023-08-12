using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Converts text to a Ansi buffer for passing to native code
    /// </summary>
    public readonly ref struct AnsiBuffer
    {
        private readonly IntPtr data;

        public AnsiBuffer(string text)
        {
            data = Marshal.StringToHGlobalAnsi(text);
        }

        public unsafe sbyte* AsPointer()
        {
            return (sbyte*)data.ToPointer();
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(data);
        }
    }

    public static class AnsiStringUtils
    {
        public static AnsiBuffer ToAnsiBuffer(this string text)
        {
            return new AnsiBuffer(text);
        }
    }
}
