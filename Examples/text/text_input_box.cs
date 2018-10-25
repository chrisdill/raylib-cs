using Raylib;
using System.Text;
using static Raylib.Raylib;

public partial class text_input_box
{
    /*******************************************************************************************
    *
    *   raylib [text] example - Input Box
    *
    *   This example has been created using raylib 1.7 (www.raylib.com)
    *   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
    *
    *   Copyright (c) 2017 Ramon Santamaria (@raysan5)
    *
    ********************************************************************************************/


    public const int MAX_INPUT_CHARS = 9;

    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        int screenWidth = 800;
        int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - input box");

        StringBuilder name = new StringBuilder(' ', MAX_INPUT_CHARS + 1);      // NOTE: One extra space required for line ending char '\0'
        int letterCount = 0;

        Rectangle textBox = new Rectangle( screenWidth/2 - 100, 180, 225, 50 );
        bool mouseOnText = false;

        int framesCounter = 0;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (CheckCollisionPointRec(GetMousePosition(), textBox)) mouseOnText = true;
            else mouseOnText = false;

            if (mouseOnText)
            {
                int key = GetKeyPressed();

                // NOTE: Only allow keys in range [32..125]
                if ((key >= 32) && (key <= 125) && (letterCount < MAX_INPUT_CHARS))
                {
                    name[letterCount] = (char)key;
                    letterCount++;
                }

                if (IsKeyPressed(KEY_BACKSPACE))
                {
                    letterCount--;
                    name[letterCount] = '\0';

                    if (letterCount < 0) letterCount = 0;
                }
            }

            if (mouseOnText) framesCounter++;
            else framesCounter = 0;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

                ClearBackground(RAYWHITE);

                DrawText("PLACE MOUSE OVER INPUT BOX!", 240, 140, 20, GRAY);

                DrawRectangleRec(textBox, LIGHTGRAY);
                if (mouseOnText) DrawRectangleLines((int)textBox.x, (int)textBox.y, (int)textBox.width, (int)textBox.height, RED);
                else DrawRectangleLines((int)textBox.x, (int)textBox.y, (int)textBox.width, (int)textBox.height, DARKGRAY);

                DrawText(name.ToString(), (int)textBox.x + 5, (int)textBox.y + 8, 40, MAROON);

                DrawText(string.Format("INPUT CHARS: {0}/{1}", letterCount, MAX_INPUT_CHARS), 315, 250, 20, DARKGRAY);

                if (mouseOnText)
                {
                    if (letterCount < MAX_INPUT_CHARS)
                    {
                        // Draw blinking underscore char
                        if (((framesCounter/20)%2) == 0) DrawText("_", (int)textBox.x + 8 + MeasureText(name.ToString(), 40), (int)textBox.y + 12, 40, MAROON);
                    }
                    else DrawText("Press BACKSPACE to delete chars...", 230, 300, 20, GRAY);
                }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();        // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

        return 0;
    }

    // Check if any key is pressed
    // NOTE: We limit keys check to keys between 32 (KEY_SPACE) and 126
    bool IsAnyKeyPressed()
    {
        bool keyPressed = false;
        int key = GetKeyPressed();

        if ((key >= 32) && (key <= 126)) keyPressed = true;

        return keyPressed;
    }
}
