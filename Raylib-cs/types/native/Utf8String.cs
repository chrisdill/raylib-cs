using System;
using System.Text;

namespace Raylib_cs;

#region LICENSE

// ** -- TAKEN FROM SQLitePCL.raw -- ** \\
/* https://github.com/ericsink/SQLitePCL.raw */
/*
   Copyright 2014-2021 SourceGear, LLC
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
       http://www.apache.org/licenses/LICENSE-2.0
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

// CHANGES:
// - Update Method Names
// - Implicit Conversion From string

#endregion

/// <summary>
/// A raw string representation suitable for passing into many core SQLite apis. These will normally be pointers to
/// utf8 encoded bytes, with a trailing <c>\0</c> terminator.  <see langword="null"/> strings can be represented as
/// well as empty strings.
/// </summary>
public readonly ref struct Utf8String
{
    // this span will contain a zero terminator byte
    // if sp.Length is 0, it represents a null string
    // if sp.Length is 1, the only byte must be zero, and it is an empty string
    readonly ReadOnlySpan<byte> sp;

    public ref readonly byte GetPinnableReference()
    {
        return ref sp.GetPinnableReference();
    }

    private Utf8String(ReadOnlySpan<byte> a)
    {
        // no check here.  anything that calls this
        // constructor must make assurances about the
        // zero terminator.
        sp = a;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Utf8String"/> which directly points at the memory pointed to by <paramref
    /// name="span"/>. The span must contain a valid <see cref="Encoding.UTF8"/> encoded block of memory that
    /// terminates with a <c>\0</c> byte.  The span passed in must include the <c>\0</c> terminator.
    /// <para/>
    /// Both <see langword="null"/> and empty strings can be created here.  To create a <see langword="null"/> string,
    /// pass in an empty <see cref="ReadOnlySpan{T}"/>.  To create an empty string, pass in a span with length 1, that
    /// only contains a <c>\0</c>
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if <c>span.Length > 0</c> and <c>span[^1]</c> is not <c>\0</c>.
    /// </exception>
    public static Utf8String FromSpan(ReadOnlySpan<byte> span)
    {
        if (
            span.Length > 0
            && span[^1] != 0
        )
        {
            throw new ArgumentException("zero terminator required");
        }

        return new Utf8String(span);
    }

    public static Utf8String FromString(string s)
    {
        if (s == null)
        {
            return new Utf8String(ReadOnlySpan<byte>.Empty);
        }

        return new Utf8String(s.ToUtf8String());
    }

    static unsafe long GetLength(byte* p)
    {
        var q = p;
        while (*q != 0)
        {
            q++;
        }

        return q - p;
    }

    static unsafe ReadOnlySpan<byte> FindZeroTerminator(byte* p)
    {
        var len = (int)GetLength(p);
        return new ReadOnlySpan<byte>(p, len + 1);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Utf8String"/> which directly points at the memory pointed to by <paramref
    /// name="p"/>. The pointer must either be <see langword="null"/> or point to a valid <see
    /// cref="Encoding.UTF8"/> encoded block of memory that terminates with a <c>\0</c> byte.
    /// </summary>
    public static unsafe Utf8String FromPtr(byte* p)
    {
        return p == null ? new Utf8String(ReadOnlySpan<byte>.Empty) : new Utf8String(FindZeroTerminator(p));
    }

    // TODO maybe remove this and just use FromSpan?

    /// <summary>
    /// Creates a new instance of <see cref="Utf8String"/> which directly points at the memory pointed to by <paramref
    /// name="p"/> with length <paramref name="len"/>. The pointer must be to a valid <see cref="Encoding.UTF8"/>
    /// encoded block of memory that terminates with a <c>\0</c> byte.  The <paramref name="len"/> value refers to
    /// the number of bytes in the utf8 encoded value <em>not</em> including the <c>\0</c> byte terminator.
    /// <para/>
    /// <paramref name="p"/> can be <see langword="null"/>, in which case <paramref name="len"/> is ignored
    /// and a new <see cref="Utf8String"/> instance is created that represents <see langword="null"/>.  Note that this
    /// different from a pointer to a single <c>\0</c> byte and a length of one.  That would represent an empty <see
    /// cref="Utf8String"/> string.
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="p"/> is not <see langword="null"/> and <c>p[len]</c> is not <c>\0</c>.
    /// </exception>
    public static unsafe Utf8String FromPtrLen(byte* p, int len)
    {
        if (p == null)
        {
            return new Utf8String(ReadOnlySpan<byte>.Empty);
        }

        // the given len does NOT include the zero terminator
        var sp = new ReadOnlySpan<byte>(p, len + 1);
        return FromSpan(sp);
    }

    public static unsafe Utf8String FromIntPtr(IntPtr p)
    {
        return p == IntPtr.Zero ? new Utf8String(ReadOnlySpan<byte>.Empty) : new Utf8String(FindZeroTerminator((byte*)p.ToPointer()));
    }

    /// <summary>
    /// UTF16 String representation
    /// Returns "NUL" on Null native type 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (sp.Length == 0)
        {
            // object.ToString() should never thrown
            // throw new NullReferenceException();
            return "NUL";
        }

        unsafe
        {
            fixed (byte* q = sp)
            {
                return Encoding.UTF8.GetString(q, sp.Length - 1);
            }
        }
    }

    /// <summary>
    /// Gets the <see cref="Encoding.UTF8"/> encoded bytes for the provided <paramref name="value"/>.  The array
    /// will include a trailing <c>\0</c> character.  The length of the array will <see cref="Encoding.UTF8"/>'s
    /// <see cref="Encoding.GetByteCount(string)"/><c>+1</c> (for the trailing <c>\0</c> byte).  These bytes are
    /// suitable to use with <see cref="FromSpan"/> using the extension <see
    /// cref="MemoryExtensions.AsSpan{T}(T[])"/> or <see cref="FromPtr(byte*)"/> or <see cref="FromPtrLen(byte*,
    /// int)"/>.  Note that for <see cref="FromPtrLen(byte*, int)"/> the length provided should not include the
    /// trailing <c>\0</c> terminator.
    /// </summary>
    public static byte[] GetZeroTerminatedUTF8Bytes(string value)
    {
        return value.ToUtf8String();
    }

    public static implicit operator Utf8String(string s)
    {
        return FromString(s);
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
}