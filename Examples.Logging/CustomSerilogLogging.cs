using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Serilog;
using static Raylib_cs.Raylib;

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
            SetTraceLogCallback(GetPointer());
        }

        Logger.Information("Logger has been set to Raylib-cs TraceLogCallback");

        // raylib Window Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib custom Logger example - basic window");

        // Main game loop
        while (!WindowShouldClose())
        {
            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawText("Hello World!", 190, 200, 20, Color.Black);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}

