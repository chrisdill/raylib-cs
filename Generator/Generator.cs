using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Raylibcs
{
    static class Generator
    {
        static string template = @"
using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    public static partial class rl
    {
        #region Raylib-cs Variables

        // Used by DllImport to load the native library.
        private const string nativeLibName = 'raylib.dll';

        #endregion

        #region Raylib-cs Functions 

{{ CONTENT }}
    }
}
";

        static string exampleTemplate = @"
using Raylib;
using static Raylib.rl;

public partial class Examples
{
{{ CONTENT }}
}";

        public static string InstallDirectory = "C:\\raylib\\raylib\\src\\";
        public static string ExamplesDirectory = "C:\\raylib\\raylib\\examples\\";

        // string extensions
        private static string CapitalizeFirstCharacter(string format)
        {
            if (string.IsNullOrEmpty(format))
                return string.Empty;
            else
                return char.ToUpper(format[0]) + format.ToLower().Substring(1);
        }

        public static string Indent(this string value, int size)
        {
            var strArray = value.Split('\n');
            var sb = new StringBuilder();
            foreach (var s in strArray)
                sb.Append(new string(' ', size)).Append(s);
            return sb.ToString();
        }

        public static string ReplaceEx(this string input, string pattern, string replacement)
        {
            input = input.Replace("\r", "\r\n");
            foreach (Match match in Regex.Matches(input, pattern))
            {
                Console.WriteLine(match.Value);
            }
            //return input;
 
            //var match = Regex.IsMatch(input, pattern);
            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// Proocess raylib file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="api"></param>
        public static void Process(string filePath, string api)
        {
            var lines = File.ReadAllLines(InstallDirectory + filePath);
            var output = "";

            // convert functions to c#
            foreach (string line in lines)
            {
                if (line.StartsWith(api))
                {
                    output += "\t\t[DllImport(nativeLibName)]\n";
                    string newLine = line.Clone().ToString();
                    newLine = newLine.Replace(api, "public static extern");

                    // add converted function
                    output += "\t\t" + newLine + "\n\n";
                }
            }
            output += "\t\t#endregion\n";

            // convert syntax to c#
            output = template.Replace("{{ CONTENT }}", output);

            output = output.Replace("(void)", "()");
            output = output.Replace("const char *", "string ");
            output = output.Replace("const char * ", "string");
            output = output.Replace("const char*", "string");
            output = output.Replace("unsigned int", "uint");
            output = output.Replace("unsigned char", "byte");
            output = output.Replace("const void *", "byte[] ");
            output = output.Replace("const float *", "float[] ");
            output = output.Replace("const int *", "int[] ");
            output = output.Replace("...", "params object[] args");
            output = output.Replace("Music ", "IntPtr ");

            Console.WriteLine(output);
   
            filePath = Path.GetFileNameWithoutExtension(filePath);
            filePath = CapitalizeFirstCharacter(filePath);

            Directory.CreateDirectory("Raylib-cs");
            File.WriteAllText("Raylib-cs/ " + filePath + ".cs", output);
        }

        /// <summary>
        /// Process raylib examples
        /// </summary>
        public static void ProcessExamples()
        {
            // create directory in output folder with same layout as raylib examples

            Directory.CreateDirectory("Examples");

            var dirs = Directory.GetDirectories(ExamplesDirectory);
            foreach (var dir in dirs)
            {
                var dirName = new DirectoryInfo(dir).Name;
                var files = Directory.GetFiles(dir);
                Directory.CreateDirectory("Examples\\" + dirName);

                foreach (var file in files)
                {
                    if (Path.GetExtension(file) != ".c")
                        continue;

                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var text = File.ReadAllText(file);

                    // indent since example will be in Examples namespace
                    text = text.Indent(4);
           
                    // add template and fill in content
                    var output = exampleTemplate;
                    output = output.Replace("{{ CONTENT }}", text);
                    output = output.Replace("int main()", "public static int " + fileName + "()");
                    output = output.Replace("#include \"raylib.h\"", "");

                    // REGEX WHYYYYYYY!!!
                    //if (fileName == "core_2d_camera")
                    {
                        // remove #include lines

                        // #define x y -> private const int x = y;
                        output = output.ReplaceEx(@"#define (\w+).*?(\d+)", "private const int $1 = $2;");
                        
                        // (Type){...} -> new Type(...);
                        // output = output.ReplaceEx(@"(\((\w+)\).*?{.*})", @"");
                        // output = output.ReplaceEx(@"\((\w +)\).*{ (.*)}", @"new $1($2)");
                    }

                    //output = output.ReplaceEx(@"#define (\w+) (\w+)", @"struct 1 public 2 public 3 public 4");

                    var path = "Examples\\" + dirName + "\\" + fileName + ".cs";
                    File.WriteAllText(path, output);
                }
            }
        }
    }
}
