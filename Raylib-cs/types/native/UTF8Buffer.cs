using System;
using System.Buffers;
using System.Text;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Converts text to a UTF8 buffer for passing to native code.<br/>
    /// Uses ArrayPool to reduce memory allocation.
    /// </summary>
    public ref struct UTF8Buffer
    {
        public byte[] buffer;

        public UTF8Buffer(string text)
        {
            int length = (text.Length * 4) + 1;
            buffer = ArrayPool<byte>.Shared.Rent(length);
            int count = Encoding.UTF8.GetBytes(text.AsSpan(), buffer.AsSpan());
            buffer[count] = 0;
        }

        public void Dispose()
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static class Utf8StringUtils
    {
        public static byte[] ToUtf8String(this string sourceText)
        {
            if (sourceText == null)
            {
                return null;
            }

            var length = Encoding.UTF8.GetByteCount(sourceText);

            var byteArray = new byte[length + 1];
            var wrote = Encoding.UTF8.GetBytes(sourceText, 0, sourceText.Length, byteArray, 0);
            byteArray[wrote] = 0;

            return byteArray;
        }

        public static unsafe string GetUTF8String(byte* bytes)
        {
            return Marshal.PtrToStringUTF8((IntPtr)bytes);
        }

        public static byte[] GetUTF8Bytes(this string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
