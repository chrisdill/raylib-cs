/* Raygui.cs
*
* Copyright 2020 Chris Dill
*
* Release under zLib License.
* See LICENSE for details.
*/

using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Raylib_cs;

namespace Raygui_cs
{
    // Style property
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct GuiStyleProp
    {
        ushort controlId;
        ushort propertyId;
        int propertyValue;
    }

    // Gui global state enum
    public enum GuiControlState
    {
        GUI_STATE_NORMAL = 0,
        GUI_STATE_FOCUSED,
        GUI_STATE_PRESSED,
        GUI_STATE_DISABLED,
    }

    // Gui global text alignment
    public enum GuiTextAlignment
    {
        GUI_TEXT_ALIGN_LEFT = 0,
        GUI_TEXT_ALIGN_CENTER,
        GUI_TEXT_ALIGN_RIGHT,
    }

    // Gui standard controls
    public enum GuiControlStandard
    {
        DEFAULT = 0,
        LABEL,          // LABELBUTTON
        BUTTON,         // IMAGEBUTTON
        TOGGLE,         // TOGGLEGROUP
        SLIDER,         // SLIDERBAR
        PROGRESSBAR,
        CHECKBOX,
        COMBOBOX,
        DROPDOWNBOX,
        TEXTBOX,        // TEXTBOXMULTI
        VALUEBOX,
        SPINNER,
        LISTVIEW,
        COLORPICKER,
        SCROLLBAR,
        STATUSBAR
    }

    // Gui default properties for every control
    public enum GuiControlProperty
    {
        BORDER_COLOR_NORMAL = 0,
        BASE_COLOR_NORMAL,
        TEXT_COLOR_NORMAL,
        BORDER_COLOR_FOCUSED,
        BASE_COLOR_FOCUSED,
        TEXT_COLOR_FOCUSED,
        BORDER_COLOR_PRESSED,
        BASE_COLOR_PRESSED,
        TEXT_COLOR_PRESSED,
        BORDER_COLOR_DISABLED,
        BASE_COLOR_DISABLED,
        TEXT_COLOR_DISABLED,
        BORDER_WIDTH,
        TEXT_PADDING,
        TEXT_ALIGNMENT,
        RESERVED
    }

    // Gui extended properties depending on control type
    // NOTE: We reserve a fixed size of additional properties per control

    // Default properties
    public enum GuiDefaultProperty
    {
        TEXT_SIZE = 16,
        TEXT_SPACING,
        LINE_COLOR,
        BACKGROUND_COLOR,
    }

    // Toggle / ToggleGroup
    public enum GuiToggleProperty
    {
        GROUP_PADDING = 16,
    }

    // Slider / SliderBar
    public enum GuiSliderProperty
    {
        SLIDER_WIDTH = 16,
        TEXT_PADDING
    }

    // ProgressBar
    public enum GuiProgressBarProperty
    {
        PROGRESS_PADDING = 16,
    }

    // CheckBox
    public enum GuiCheckBoxProperty
    {
        CHECK_PADDING = 16
    }

    // ComboBox
    public enum GuiComboBoxProperty
    {
        SELECTOR_WIDTH = 16,
        SELECTOR_PADDING
    }

    // DropdownBox
    public enum GuiDropdownBoxProperty
    {
        ARROW_PADDING = 16,
        DROPDOWN_ITEMS_PADDING
    }

    // TextBox / TextBoxMulti / ValueBox / Spinner
    public enum GuiTextBoxProperty
    {
        TEXT_INNER_PADDING = 16,
        TEXT_LINES_PADDING,
        COLOR_SELECTED_FG,
        COLOR_SELECTED_BG
    }

    // Spinner
    public enum GuiSpinnerProperty
    {
        SPIN_BUTTON_WIDTH = 16,
        SPIN_BUTTON_PADDING,
    }

    // ScrollBar
    public enum GuiScrollBarProperty
    {
        ARROWS_SIZE = 16,
        ARROWS_VISIBLE,
        SCROLL_SLIDER_PADDING,
        SCROLL_SLIDER_SIZE,
        SCROLL_PADDING,
        SCROLL_SPEED,
    }

    // ScrollBar side
    public enum GuiScrollBarSide
    {
        SCROLLBAR_LEFT_SIDE = 0,
        SCROLLBAR_RIGHT_SIDE
    }

    // ListView
    public enum GuiListViewProperty
    {
        LIST_ITEMS_HEIGHT = 16,
        LIST_ITEMS_PADDING,
        SCROLLBAR_WIDTH,
        SCROLLBAR_SIDE,
    }

    // ColorPicker
    public enum GuiColorPickerProperty
    {
        COLOR_SELECTOR_SIZE = 16,
        HUEBAR_WIDTH,                  // Right hue bar width
        HUEBAR_PADDING,                // Right hue bar separation from panel
        HUEBAR_SELECTOR_HEIGHT,        // Right hue bar selector height
        HUEBAR_SELECTOR_OVERFLOW       // Right hue bar selector overflow
    }

    [SuppressUnmanagedCodeSecurity]
    public static class Raygui
    {
        // Used by DllImport to load the native library.
        public const string nativeLibName = "raygui";

        public const string RAYGUI_VERSION = "2.6-dev";

        public const int NUM_CONTROLS = 16;                      // Number of standard controls
        public const int NUM_PROPS_DEFAULT = 16;                 // Number of standard properties
        public const int NUM_PROPS_EXTENDED = 8;                 // Number of extended properties

        public const int TEXTEDIT_CURSOR_BLINK_FRAMES = 20;      // Text edit controls cursor blink timming

        // Global gui modification functions

        // Enable gui controls (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiEnable();

        // Disable gui controls (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiDisable();

        // Lock gui controls (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiLock();

        // Unlock gui controls (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiUnlock();

        // Set gui controls alpha (global state), alpha goes from 0.0f to 1.0f
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiFade(float alpha);

        // Set gui state (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetState(int state);

        // Get gui state (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiGetState();

        // Get gui custom font (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetFont(Font font);

        // Set gui custom font (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font GuiGetFont();


        // Style set/get functions

        // Set one style property
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetStyle(GuiControlStandard control, GuiControlProperty property, int value);

        // Get one style property
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiGetStyle(GuiControlStandard control, GuiControlProperty property);


        // Tooltips set functions

        // Enable gui tooltips
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiEnableTooltip();

        // Disable gui tooltips
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiDisableTooltip();

        // Set current tooltip for display
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetTooltip(string tooltip);

        // Clear any tooltip registered
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiClearTooltip();


        // Container/separator controls, useful for controls organization

        // Window Box control, shows a window that can be closed
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiWindowBox(Rectangle bounds, string text);

        // Group Box control with title name
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiGroupBox(Rectangle bounds, string text);

        // Line separator control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiLine(Rectangle bounds, string text);

        // Panel control, useful to group controls
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiPanel(Rectangle bounds);

        // Scroll Panel control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Rectangle GuiScrollPanel(Rectangle bounds, Rectangle content, ref Vector2 scroll);


        // Basic controls set

        // Label control, shows text
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiLabel(Rectangle bounds, string text);

        // Button control, returns true when clicked
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiButton(Rectangle bounds, string text);

        // Label button control, show true when clicked
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiLabelButton(Rectangle bounds, string text);

        // Image button control, returns true when clicked
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiImageButton(Rectangle bounds, Texture2D texture);

        // Image button extended control, returns true when clicked
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiImageButtonEx(Rectangle bounds, Texture2D texture, Rectangle texSource, string text);

        // Toggle Button control, returns true when active
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiToggle(Rectangle bounds, string text, bool active);

        // Toggle Group control, returns active toggle index
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiToggleGroup(Rectangle bounds, string text, int active);

        // Check Box control, returns true when active
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiCheckBox(Rectangle bounds, bool isChecked);

        // Combo Box control, returns selected item index
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiComboBox(Rectangle bounds, string text, int active);

        // Dropdown Box control, returns selected item
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiDropdownBox(Rectangle bounds, string[] text, ref int active, bool edit);

        // Spinner control, returns selected value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiSpinner(Rectangle bounds, ref int value, int maxValue, int btnWidth);

        // Value Box control, updates input text with numbers
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiValueBox(Rectangle bounds, int value, int maxValue);

        // Text Box control, updates input text
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiTextBox(Rectangle bounds, StringBuilder text, int textSize, bool freeEdit);

        // Text Box control with multiple lines
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiTextBoxMulti(Rectangle bounds, StringBuilder text, int textSize, bool editMode);

        // Slider control, returns selected value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiSlider(Rectangle bounds, float value, float minValue, float maxValue, bool showValue);

        // Slider Bar control, returns selected value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiSliderBar(Rectangle bounds, float value, float minValue, float maxValue, bool showValue);

        // Progress Bar control, shows current progress value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiProgressBar(Rectangle bounds, float value, float minValue, float maxValue, bool showValue);

        // Status Bar control, shows info text
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiStatusBar(Rectangle bounds, string text);

        // Dummy control for placeholders
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiDummyRec(Rectangle bounds, string text);

        // Scroll Bar control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiScrollBar(Rectangle bounds, int value, int minValue, int maxValue);

        // Grid
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiGrid(Rectangle bounds, float spacing, int subdivs);


        // Advance controls set

        // List View control, returns selected list element index
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiListView(Rectangle bounds, string text, ref int active, ref int scrollIndex, bool editMode);

        // List View with extended parameters
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiListViewEx(Rectangle bounds, string text, int count, ref int enabled, ref int active, ref int focus, ref int scrollIndex, bool editMode);

        // Message Box control, displays a message
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiMessageBox(Rectangle bounds, string windowTitle, string message);

        // Text Input Box control, ask for text
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiTextInputBox(Rectangle bounds, string windowTitle, string message, string buttons);

        // Color Picker control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GuiColorPicker(Rectangle bounds, Color color);

        // Color Panel control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GuiColorPanel(Rectangle bounds, Color color);

        // Color Bar Alpha control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern  float GuiColorBarAlpha(Rectangle bounds, float alpha);

        // Color Bar Hue control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern  float GuiColorBarHue(Rectangle bounds, float value);


        // Styles loading functions

        // Load style file (.rgs)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiLoadStyle(string fileName);

        // Load style default over global style
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiLoadStyleDefault();

        // Get text with icon id prepended
        // Get the human-readable, UTF-8 encoded name of the primary monitor
        [DllImport(nativeLibName, EntryPoint = "GetMonitorName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GuiIconText(int iconId, string text);
        public static string GuiIconText(int iconId, string text)
        {
            return Marshal.PtrToStringAnsi(INTERNAL_GuiIconText(iconId, text));
        }


        // Gui icons functionality

        // Get full icons data pointer
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint[] GuiGetIcons();

        // Get icon bit data
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint[] GuiGetIconData(int iconId, string text);

        // Set icon bit data
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetIconData(int iconId, uint[] data);

        // Set icon pixel value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetIconPixel(int iconId, int x, int y);

        // Clear icon pixel value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiClearIconPixel(int iconId, int x, int y);

        // Check icon pixel value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiCheckIconPixel(int iconId, int x, int y);
    }
}
