using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    internal readonly struct Native
    {
        internal const string Msvcrt = "msvcrt";
        internal const string Libc = "libc";
        internal const string LibSystem = "libSystem";

        [DllImport(LibSystem, EntryPoint = "vasprintf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vasprintf_apple(ref IntPtr buffer, IntPtr format, IntPtr args);

        [DllImport(Libc, EntryPoint = "vsprintf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vsprintf_linux(IntPtr buffer, IntPtr format, IntPtr args);

        [DllImport(Msvcrt, EntryPoint = "vsprintf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vsprintf_windows(IntPtr buffer, IntPtr format, IntPtr args);

        [DllImport(Libc, EntryPoint = "vsnprintf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vsnprintf_linux(IntPtr buffer, UIntPtr size, IntPtr format, IntPtr args);

        [DllImport(Msvcrt, EntryPoint = "vsnprintf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vsnprintf_windows(IntPtr buffer, UIntPtr size, IntPtr format, IntPtr args);
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    struct VaListLinuxX64
    {
        uint gpOffset;
        uint fpOffset;
        IntPtr overflowArgArea;
        IntPtr regSaveArea;
    }

    /// <summary>
    /// Logging workaround for formatting strings from native code
    /// </summary>
    public static unsafe class Logging
    {
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static unsafe void LogConsole(int msgType, sbyte* text, sbyte* args)
        {
            var message = GetLogMessage(new IntPtr(text), new IntPtr(args));
            Console.WriteLine(message);
        }

        public static string GetLogMessage(IntPtr format, IntPtr args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return AppleLogCallback(format, args);
            }

            // Special marshalling is needed on Linux desktop 64 bits.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && IntPtr.Size == 8)
            {
                return LinuxX64LogCallback(format, args);
            }

            var byteLength = vsnprintf(IntPtr.Zero, UIntPtr.Zero, format, args) + 1;
            if (byteLength <= 1)
            {
                return string.Empty;
            }

            var buffer = Marshal.AllocHGlobal(byteLength);
            vsprintf(buffer, format, args);

            string result = Marshal.PtrToStringUTF8(buffer);
            Marshal.FreeHGlobal(buffer);

            return result;
        }

        static string AppleLogCallback(IntPtr format, IntPtr args)
        {
            IntPtr buffer = IntPtr.Zero;
            try
            {
                var count = Native.vasprintf_apple(ref buffer, format, args);
                if (count == -1)
                {
                    return string.Empty;
                }
                return Marshal.PtrToStringUTF8(buffer) ?? string.Empty;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        static string LinuxX64LogCallback(IntPtr format, IntPtr args)
        {
            // The args pointer cannot be reused between two calls. We need to make a copy of the underlying structure.
            var listStructure = Marshal.PtrToStructure<VaListLinuxX64>(args);
            IntPtr listPointer = IntPtr.Zero;
            int byteLength = 0;
            string result = "";

            // Get length of args
            listPointer = Marshal.AllocHGlobal(Marshal.SizeOf(listStructure));
            Marshal.StructureToPtr(listStructure, listPointer, false);
            byteLength = Native.vsnprintf_linux(IntPtr.Zero, UIntPtr.Zero, format, listPointer) + 1;

            // Allocate buffer for result
            Marshal.StructureToPtr(listStructure, listPointer, false);

            IntPtr utf8Buffer = IntPtr.Zero;
            utf8Buffer = Marshal.AllocHGlobal(byteLength);

            // Print result into buffer
            Native.vsprintf_linux(utf8Buffer, format, listPointer);
            result = Marshal.PtrToStringUTF8(utf8Buffer);

            Marshal.FreeHGlobal(listPointer);
            Marshal.FreeHGlobal(utf8Buffer);

            return result;
        }

        // https://github.com/dotnet/runtime/issues/51052
        static int vsnprintf(IntPtr buffer, UIntPtr size, IntPtr format, IntPtr args)
        {
            var os = Environment.OSVersion;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Native.vsnprintf_windows(buffer, size, format, args);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Native.vsnprintf_linux(buffer, size, format, args);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID")))
            {
                return Native.vsprintf_linux(buffer, format, args);
            }
            return -1;
        }

        // https://github.com/dotnet/runtime/issues/51052
        static int vsprintf(IntPtr buffer, IntPtr format, IntPtr args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Native.vsprintf_windows(buffer, format, args);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Native.vsprintf_linux(buffer, format, args);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID")))
            {
                return Native.vsprintf_linux(buffer, format, args);
            }
            return -1;
        }
    }
}
