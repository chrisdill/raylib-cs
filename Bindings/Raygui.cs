/* Raygui.cs
*
* Copyright 2019 Chris Dill
*
* Release under zLib License.
* See LICENSE for details.
*/

using System.Runtime.InteropServices;
using System.Text;

namespace Raylib
{
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
        RESERVED
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
        INNER_PADDING,
        TEXT_ALIGNMENT,
        RESERVED02
    }

    // Gui extended properties depending on control type
    // NOTE: We reserve a fixed size of additional properties per control (8)

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

    // CheckBox
    public enum GuiCheckBoxProperty
    {
        CHECK_TEXT_PADDING = 16
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
        ARROW_RIGHT_PADDING = 16,
    }

    // TextBox / TextBoxMulti / ValueBox / Spinner
    public enum GuiTextBoxProperty
    {
        MULTILINE_PADDING = 16,
        COLOR_SELECTED_FG,
        COLOR_SELECTED_BG
    }

    public enum GuiSpinnerProperty
    {
        SELECT_BUTTON_WIDTH = 16,
        SELECT_BUTTON_PADDING,
        SELECT_BUTTON_BORDER_WIDTH
    }

    // ScrollBar
    public enum GuiScrollBarProperty
    {
        ARROWS_SIZE = 16,
        SLIDER_PADDING,
        SLIDER_SIZE,
        SCROLL_SPEED,
        SHOW_SPINNER_BUTTONS
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
        ELEMENTS_HEIGHT = 16,
        ELEMENTS_PADDING,
        SCROLLBAR_WIDTH,
        SCROLLBAR_SIDE,             // This property defines vertical scrollbar side (SCROLLBAR_LEFT_SIDE or SCROLLBAR_RIGHT_SIDE)
    }

    // ColorPicker
    public enum GuiColorPickerProperty
    {
        COLOR_SELECTOR_SIZE = 16,
        BAR_WIDTH,                  // Lateral bar width
        BAR_PADDING,                // Lateral bar separation from panel
        BAR_SELECTOR_HEIGHT,        // Lateral bar selector height
        BAR_SELECTOR_PADDING        // Lateral bar selector outer padding
    }

    public static partial class Raylib
    {
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

        // Set gui state (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiState(int state);

        // Set gui custom font (global state)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiFont(Font font);

        // Set gui controls alpha (global state), alpha goes from 0.0f to 1.0f
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiFade(float alpha);

        // Style set/get functions

        // Set one style property
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetStyle(GuiControlStandard control, GuiControlProperty property, int value);

        // Get one style property
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiGetStyle(GuiControlStandard control, GuiControlProperty property);

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

        // Progress Bar control, shows current progress value
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiProgressBarEx(Rectangle bounds, float value, float minValue, float maxValue, bool showValue);

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
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiMessageBox(Rectangle bounds, string windowTitle, string message);

        // Text Input Box control, ask for text
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiTextInputBox(Rectangle bounds, string windowTitle, string message, string buttons);

        // Color Picker control
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GuiColorPicker(Rectangle bounds, Color color);

        // Styles loading functions

        // Load style file (.rgs)
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiLoadStyle(string fileName);

        // Load style properties from array
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiLoadStyleProps(int[] props, int count);

        // Load style default over global style
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GuiLoadStyleDefault();

        // Updates full style properties set with default values
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GuiUpdateStyleComplete();

        // Get text with icon id prepended
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string GuiIconText(int iconId, string text);
    }
}
