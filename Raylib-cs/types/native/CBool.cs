using System;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CBool
    {
        private readonly byte value;

        private CBool(bool value)
        {
            this.value = Convert.ToByte(value);
        }

        public static implicit operator CBool(bool value)
        {
            return new CBool(value);
        }

        public static implicit operator bool(CBool x)
        {
            return Convert.ToBoolean(x.value);
        }

        public override string ToString()
        {
            return Convert.ToBoolean(value).ToString();
        }
    }
}
