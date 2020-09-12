using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Raylib_cs
{
    public static class Platform
    {
        public static readonly IReadOnlyDictionary<string, ( PlatformID, bool)> SupportedPlatforms =
            new Dictionary<string, (PlatformID PlatformID, bool x64)>()
            {
                {"osx-x64", (PlatformID.MacOSX, true)},
                {"win-x64", (PlatformID.Win32NT, true)},
                {"win-x86", (PlatformID.Win32NT, false)},
                {"linux-x64", (PlatformID.Unix, true)},
                {"linux-x86", (PlatformID.Unix, false)},
            };

        public static readonly List<(PlatformID, bool)> HasSupportedPlatformNativeLibrary =
            new List<(PlatformID, bool)>();

        public static string NativeLibrarySubfolder { get; set; } = "native";
        public static string RuntimeLibraryFolder { get; set; } = "runtimes";

        private static void DiscoverNativeLibraries()
        {
            var localFolders = Directory.GetDirectories(Directory.GetCurrentDirectory());
            if (!localFolders.Any(d =>
                string.Equals(d, RuntimeLibraryFolder, StringComparison.InvariantCultureIgnoreCase))) return;

            // for each supported platform, see if the native library exists in the RuntimeLibraryFolder (for now this is any file that doesnt start with ".")
            foreach (var platform in SupportedPlatforms)
            {
                var localPlatformFolder = localFolders.FirstOrDefault(f =>
                    string.Equals(f, platform.Key, StringComparison.InvariantCultureIgnoreCase));

                if (localPlatformFolder == default) continue;

                var localNativeLibraryFolder = Path.Combine(localPlatformFolder, NativeLibrarySubfolder);

                if (!Directory.Exists(localNativeLibraryFolder))
                    continue;

                // if all the files in the NativeLibrarySubfolder start with "." then we have not found any native libraries
                if (Directory.GetFiles(localNativeLibraryFolder).All(f => f[0] == '.')) continue;

                if (!HasSupportedPlatformNativeLibrary.Contains(platform.Value))
                    HasSupportedPlatformNativeLibrary.Add(platform.Value);
            }
        }

        private static string DetectSystem()
        {
            Debug.WriteLine(
                $"System info: {Environment.NewLine}" +
                $"OS:{Environment.OSVersion.Platform:G}{Environment.NewLine}" +
                $"ServicePack:{Environment.OSVersion.ServicePack}{Environment.NewLine}" +
                $"Version:{Environment.OSVersion.Version}{Environment.NewLine}" +
                $"64OS?:{Environment.Is64BitOperatingSystem}{Environment.NewLine}" +
                $"64Proc?:{Environment.Is64BitProcess}");

            var x = Environment.Is64BitProcess && Environment.Is64BitOperatingSystem ? "-x64" : "-x86";

            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    return "linux" + x;
                case PlatformID.Win32NT:
                    return "win" + x;
                case PlatformID.MacOSX:
                    return "osx" + x;
            }

            return null;
        }

        public static void ResolveNativeLibraries()
        {
            DiscoverNativeLibraries();
            CopyNativeLibraryFilesToRoot(DetectSystem());
        }

        private static void CopyNativeLibraryFilesToRoot(string platformString)
        {
            // native
            foreach (var file in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), RuntimeLibraryFolder,
                platformString, NativeLibrarySubfolder)))
            {
                File.Copy(file, AppDomain.CurrentDomain.BaseDirectory + $"{Path.GetFileName(file)}", true);
            }
        }
    }
}