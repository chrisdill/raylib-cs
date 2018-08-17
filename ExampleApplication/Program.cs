using Raylib;
using static Raylib.rl;

namespace ExampleApplication
{
    static class Program
    {
        static void Main(string[] args)
        {
            var a = new Vector2(100, 30);
            var b = new Vector2(100, 30);
            var c = Vector2Add(a, b);
            Examples.core_basic_window();
        }
    }
}