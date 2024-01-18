using System.Numerics;
using static Raylib_cs.Raylib;

namespace Examples.Text;

public class RectangleBounds
{
    public static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - draw text inside a rectangle");

        string text = "";
        text += "Text cannot escape this container ...word wrap also works when active so here's a long text for testing.";
        text += "\n\nLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor ";
        text += "incididunt ut labore et dolore magna aliqua. Nec ullamcorper sit amet risus nullam eget felis eget.";

        bool resizing = false;
        bool wordWrap = true;

        Rectangle container = new(25, 25, screenWidth - 50, screenHeight - 250);
        Rectangle resizer = new(
            container.X + container.Width - 17,
            container.Y + container.Height - 17,
            14,
            14
        );

        // Minimum width and heigh for the container rectangle
        const int minWidth = 60;
        const int minHeight = 60;
        const int maxWidth = screenWidth - 50;
        const int maxHeight = screenHeight - 160;

        Vector2 lastMouse = new(0.0f, 0.0f);
        Color borderColor = Color.Maroon;
        Font font = GetFontDefault();

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.Space))
            {
                wordWrap = !wordWrap;
            }

            Vector2 mouse = GetMousePosition();

            // Check if the mouse is inside the container and toggle border color
            if (CheckCollisionPointRec(mouse, container))
            {
                borderColor = ColorAlpha(Color.Maroon, 0.4f);
            }
            else if (!resizing)
            {
                borderColor = Color.Maroon;
            }

            // Container resizing logic
            if (resizing)
            {
                if (IsMouseButtonReleased(MouseButton.Left))
                {
                    resizing = false;
                }

                int width = (int)(container.Width + (mouse.X - lastMouse.X));
                container.Width = (width > minWidth) ? ((width < maxWidth) ? width : maxWidth) : minWidth;

                int height = (int)(container.Height + (mouse.Y - lastMouse.Y));
                container.Height = (height > minHeight) ? ((height < maxHeight) ? height : maxHeight) : minHeight;
            }
            else
            {
                // Check if we're resizing
                if (IsMouseButtonDown(MouseButton.Left) && CheckCollisionPointRec(mouse, resizer))
                {
                    resizing = true;
                }
            }

            // Move resizer rectangle properly
            resizer.X = container.X + container.Width - 17;
            resizer.Y = container.Y + container.Height - 17;

            lastMouse = mouse; // Update mouse
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            // Draw container border
            DrawRectangleLinesEx(container, 3, borderColor);

            // Draw text in container (add some padding)
            DrawTextBoxed(
                font,
                text,
                new Rectangle(container.X + 4, container.Y + 4, container.Width - 4, container.Height - 4),
                20.0f,
                2.0f,
                wordWrap,
                Color.Gray
            );

            DrawRectangleRec(resizer, borderColor);

            // Draw bottom info
            DrawRectangle(0, screenHeight - 54, screenWidth, 54, Color.Gray);
            DrawRectangleRec(new Rectangle(382, screenHeight - 34, 12, 12), Color.Maroon);

            DrawText("Word Wrap: ", 313, screenHeight - 115, 20, Color.Black);

            if (wordWrap)
            {
                DrawText("ON", 447, screenHeight - 115, 20, Color.Red);
            }
            else
            {
                DrawText("OFF", 447, screenHeight - 115, 20, Color.Black);
            }

            DrawText("Press [SPACE] to toggle word wrap", 218, screenHeight - 86, 20, Color.Gray);
            DrawText("Click hold & drag the    to resize the container", 155, screenHeight - 38, 20, Color.RayWhite);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }

    // Draw text using font inside rectangle limits
    static void DrawTextBoxed(
        Font font,
        string text,
        Rectangle rec,
        float fontSize,
        float spacing,
        bool wordWrap,
        Color tint
    )
    {
        DrawTextBoxedSelectable(font, text, rec, fontSize, spacing, wordWrap, tint, 0, 0, Color.White, Color.White);
    }

    // Draw text using font inside rectangle limits with support for text selection
    static unsafe void DrawTextBoxedSelectable(
        Font font,
        string text,
        Rectangle rec,
        float fontSize,
        float spacing,
        bool wordWrap,
        Color tint,
        int selectStart,
        int selectLength,
        Color selectTint,
        Color selectBackTint
    )
    {
        int length = text.Length;

        // Offset between lines (on line break '\n')
        float textOffsetY = 0;

        // Offset X to next character to draw
        float textOffsetX = 0.0f;

        // Character rectangle scaling factor
        float scaleFactor = fontSize / (float)font.BaseSize;

        // Word/character wrapping mechanism variables
        bool shouldMeasure = wordWrap;

        // Index where to begin drawing (where a line begins)
        int startLine = -1;

        // Index where to stop drawing (where a line ends)
        int endLine = -1;

        // Holds last value of the character position
        int lastk = -1;

        using var textNative = new Utf8Buffer(text);

        for (int i = 0, k = 0; i < length; i++, k++)
        {
            // Get next codepoint from byte string and glyph index in font
            int codepointByteCount = 0;
            int codepoint = GetCodepoint(&textNative.AsPointer()[i], &codepointByteCount);
            int index = GetGlyphIndex(font, codepoint);

            // NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
            // but we need to draw all of the bad bytes using the '?' symbol moving one byte
            if (codepoint == 0x3f)
            {
                codepointByteCount = 1;
            }

            i += (codepointByteCount - 1);

            float glyphWidth = 0;
            if (codepoint != '\n')
            {
                glyphWidth = (font.Glyphs[index].AdvanceX == 0) ?
                    font.Recs[index].Width * scaleFactor :
                    font.Glyphs[index].AdvanceX * scaleFactor;

                if (i + 1 < length)
                {
                    glyphWidth = glyphWidth + spacing;
                }
            }

            // NOTE: When wordWrap is ON we first measure how much of the text we can draw before going outside of
            // the rec container. We store this info in startLine and endLine, then we change states, draw the text
            // between those two variables and change states again and again recursively until the end of the text
            // (or until we get outside of the container). When wordWrap is OFF we don't need the measure state so
            // we go to the drawing state immediately and begin drawing on the next line before we can get outside
            // the container.
            if (shouldMeasure)
            {
                // TODO: There are multiple types of spaces in UNICODE, maybe it's a good idea to add support for
                // more. Ref: http://jkorpela.fi/chars/spaces.html
                if ((codepoint == ' ') || (codepoint == '\t') || (codepoint == '\n'))
                {
                    endLine = i;
                }

                if ((textOffsetX + glyphWidth) > rec.Width)
                {
                    endLine = (endLine < 1) ? i : endLine;
                    if (i == endLine)
                    {
                        endLine -= codepointByteCount;
                    }
                    if ((startLine + codepointByteCount) == endLine)
                    {
                        endLine = (i - codepointByteCount);
                    }

                    shouldMeasure = !shouldMeasure;
                }
                else if ((i + 1) == length)
                {
                    endLine = i;
                    shouldMeasure = !shouldMeasure;
                }
                else if (codepoint == '\n')
                {
                    shouldMeasure = !shouldMeasure;
                }

                if (!shouldMeasure)
                {
                    textOffsetX = 0;
                    i = startLine;
                    glyphWidth = 0;

                    // Save character position when we switch states
                    int tmp = lastk;
                    lastk = k - 1;
                    k = tmp;
                }
            }
            else
            {
                if (codepoint == '\n')
                {
                    if (!wordWrap)
                    {
                        textOffsetY += (font.BaseSize + font.BaseSize / 2) * scaleFactor;
                        textOffsetX = 0;
                    }
                }
                else
                {
                    if (!wordWrap && ((textOffsetX + glyphWidth) > rec.Width))
                    {
                        textOffsetY += (font.BaseSize + font.BaseSize / 2) * scaleFactor;
                        textOffsetX = 0;
                    }

                    // When text overflows rectangle height limit, just stop drawing
                    if ((textOffsetY + font.BaseSize * scaleFactor) > rec.Height)
                    {
                        break;
                    }

                    // Draw selection background
                    bool isGlyphSelected = false;
                    if ((selectStart >= 0) && (k >= selectStart) && (k < (selectStart + selectLength)))
                    {
                        DrawRectangleRec(
                            new Rectangle(
                                rec.X + textOffsetX - 1,
                                rec.Y + textOffsetY,
                                glyphWidth,
                                (float)font.BaseSize * scaleFactor
                            ),
                            selectBackTint
                        );
                        isGlyphSelected = true;
                    }

                    // Draw current character glyph
                    if ((codepoint != ' ') && (codepoint != '\t'))
                    {
                        DrawTextCodepoint(
                            font,
                            codepoint,
                            new Vector2(rec.X + textOffsetX, rec.Y + textOffsetY),
                            fontSize,
                            isGlyphSelected ? selectTint : tint
                        );
                    }
                }

                if (wordWrap && (i == endLine))
                {
                    textOffsetY += (font.BaseSize + font.BaseSize / 2) * scaleFactor;
                    textOffsetX = 0;
                    startLine = endLine;
                    endLine = -1;
                    glyphWidth = 0;
                    selectStart += lastk - k;
                    k = lastk;

                    shouldMeasure = !shouldMeasure;
                }
            }

            if ((textOffsetX != 0) || (codepoint != ' '))
            {
                // avoid leading spaces
                textOffsetX += glyphWidth;
            }
        }
    }
}
