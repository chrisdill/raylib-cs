/*******************************************************************************************
*
*   raylib [core] example - Storage save/load values
*
*   This example has been created using raylib 1.4 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;

namespace Examples.Core;

public class StorageValues
{
    // NOTE: Storage positions must start with 0, directly related to file memory layout
    enum StorageData
    {
        Score,
        HiScore
    }

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;
        const string storageDataFile = "storage.data";

        InitWindow(screenWidth, screenHeight, "raylib [core] example - storage save/load values");

        int score = 0;
        int hiscore = 0;
        int framesCounter = 0;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.R))
            {
                score = GetRandomValue(1000, 2000);
                hiscore = GetRandomValue(2000, 4000);
            }

            if (IsKeyPressed(KeyboardKey.Enter))
            {
                SaveStorageValue(storageDataFile, (int)StorageData.Score, score);
                SaveStorageValue(storageDataFile, (int)StorageData.HiScore, hiscore);
            }
            else if (IsKeyPressed(KeyboardKey.Space))
            {
                // NOTE: If requested position could not be found, value 0 is returned
                score = LoadStorageValue(storageDataFile, (int)StorageData.Score);
                hiscore = LoadStorageValue(storageDataFile, (int)StorageData.HiScore);
            }

            framesCounter++;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            DrawText($"SCORE: {score}", 280, 130, 40, Color.Maroon);
            DrawText($"HI-SCORE: {hiscore}", 210, 200, 50, Color.Black);

            DrawText($"frames: {framesCounter}", 10, 10, 20, Color.Lime);

            DrawText("Press R to generate random numbers", 220, 40, 20, Color.LightGray);
            DrawText("Press ENTER to SAVE values", 250, 310, 20, Color.LightGray);
            DrawText("Press SPACE to LOAD values", 252, 350, 20, Color.LightGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }

    // Save integer value to storage file (to defined position)
    // NOTE: Storage positions is directly related to file memory layout (4 bytes each integer)
    private static unsafe bool SaveStorageValue(string fileName, uint position, int value)
    {
        using var fileNameBuffer = fileName.ToUtf8Buffer();

        bool success = false;
        uint dataSize = 0;
        uint newDataSize = 0;

        byte* fileData = LoadFileData(fileNameBuffer.AsPointer(), &dataSize);
        byte* newFileData = null;

        if (fileData != null)
        {
            if (dataSize <= (position * sizeof(int)))
            {
                // Increase data size up to position and store value
                newDataSize = (position + 1) * sizeof(int);
                newFileData = (byte*)MemRealloc(fileData, (int)newDataSize);

                if (newFileData != null)
                {
                    // RL_REALLOC succeded
                    int* dataPtr = (int*)newFileData;
                    dataPtr[position] = value;
                }
                else
                {
                    // RL_REALLOC failed
                    uint positionInBytes = position * sizeof(int);
                    TraceLog(
                        TraceLogLevel.Warning,
                        @$"FILEIO: [{fileName}] Failed to realloc data ({dataSize}),
                            position in bytes({positionInBytes}) bigger than actual file size"
                    );

                    // We store the old size of the file
                    newFileData = fileData;
                    newDataSize = dataSize;
                }
            }
            else
            {
                // Store the old size of the file
                newFileData = fileData;
                newDataSize = dataSize;

                // Replace value on selected position
                int* dataPtr = (int*)newFileData;
                dataPtr[position] = value;
            }

            success = SaveFileData(fileNameBuffer.AsPointer(), newFileData, newDataSize);
            MemFree(newFileData);

            TraceLog(TraceLogLevel.Info, $"FILEIO: [{fileName}] Saved storage value: {value}");
        }
        else
        {
            TraceLog(TraceLogLevel.Info, $"FILEIO: [{fileName}] File created successfully");

            dataSize = (position + 1) * sizeof(int);
            fileData = (byte*)MemAlloc((int)dataSize);
            int* dataPtr = (int*)fileData;
            dataPtr[position] = value;

            success = SaveFileData(fileNameBuffer.AsPointer(), fileData, dataSize);
            UnloadFileData(fileData);

            TraceLog(TraceLogLevel.Info, $"FILEIO: [{fileName}] Saved storage value: {value}");
        }

        return success;
    }

    // Load integer value from storage file (from defined position)
    // NOTE: If requested position could not be found, value 0 is returned
    private static unsafe int LoadStorageValue(string fileName, uint position)
    {
        using var fileNameBuffer = fileName.ToUtf8Buffer();

        int value = 0;
        uint dataSize = 0;
        byte* fileData = LoadFileData(fileNameBuffer.AsPointer(), &dataSize);

        if (fileData != null)
        {
            if (dataSize < (position * 4))
            {
                TraceLog(
                    TraceLogLevel.Warning,
                    $"FILEIO: [{fileName}] Failed to find storage position: {value}"
                );
            }
            else
            {
                int* dataPtr = (int*)fileData;
                value = dataPtr[position];
            }

            UnloadFileData(fileData);

            TraceLog(TraceLogLevel.Info, $"FILEIO: [{fileName}] Loaded storage value: {value}");
        }

        return value;
    }
}
