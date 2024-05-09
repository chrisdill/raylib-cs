using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raylib_cs;
using Serilog;

namespace Examples.Logging;

public static class CustomSerilogLogging
{
    private static readonly ILogger Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    private static unsafe delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void> GetPointer() => &LogCallback;

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void LogCallback(int msgType, sbyte* text, sbyte* args) {
        // Retrieve the log message from Raylib
        string message = Raylib_cs.Logging.GetLogMessage(new IntPtr(text), new IntPtr(args));

        // Handle the message through Serilog
        Logger.Information(message);
    }

    public static int Main()
    {
        Logger.Information("Using Serilog");

        // Attach Logger to callback
        //--------------------------------------------------------------------------------------
        unsafe {
            Raylib.SetTraceLogCallback(GetPointer());
        }

        Logger.Information("Logger has been set to Raylib-cs TraceLogCallback");

        // raylib Window Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        Raylib.InitWindow(screenWidth, screenHeight, "raylib custom Logger example - basic window");

        // Main game loop
        while (!Raylib.WindowShouldClose())
        {
            // Draw
            //----------------------------------------------------------------------------------
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            Raylib.DrawText("Hello World!", 190, 200, 20, Color.Black);

            Raylib.EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        Raylib.CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}

