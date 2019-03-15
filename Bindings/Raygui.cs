using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Raylib
{
    // Gui global state enum
    enum GuiControlState
    {
        GUI_STATE_NORMAL = 0,
        GUI_STATE_FOCUSED,
        GUI_STATE_PRESSED,
        GUI_STATE_DISABLED,
    }

    // Gui standard controls
    enum GuiControlStandard
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
        TEXTBOX,        // VALUEBOX, SPINNER
        LISTVIEW,
        COLORPICKER
    }

    // Gui default properties for every control
    enum GuiControlProperty
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
        RESERVED01,
        RESERVED02
    }

    // Gui extended properties depending on control type
    // NOTE: We reserve a fixed size of additional properties per control (8)

    // Default properties
    enum GuiDefaultProperty
    {
        TEXT_SIZE = 16,
        TEXT_SPACING,
        LINES_COLOR,
        BACKGROUND_COLOR,
    }

    // Toggle / ToggleGroup
    enum GuiToggleProperty
    {
        GROUP_PADDING = 16,
    }

    // Slider / SliderBar
    enum GuiSliderProperty
    {
        SLIDER_WIDTH = 16,
        EX_TEXT_PADDING
    }

    // TextBox / ValueBox / Spinner
    enum GuiTextBoxProperty
    {
        MULTILINE_PADDING = 16,
        SPINNER_BUTTON_WIDTH,
        SPINNER_BUTTON_PADDING,
        SPINNER_BUTTON_BORDER_WIDTH
    }

    // CheckBox
    enum GuiCheckBoxProperty
    {
        CHECK_TEXT_PADDING = 16
    }
    
    // ComboBox
    enum GuiComboBoxProperty
    {
        SELECTOR_WIDTH = 16,
        SELECTOR_PADDING
    }

    // DropdownBox
    enum GuiDropdownBoxProperty
    {
        ARROW_RIGHT_PADDING = 16,
    }
    
    // ColorPicker
    enum GuiColorPickerProperty
    {
        COLOR_SELECTOR_SIZE = 16,
        BAR_WIDTH,                  // Lateral bar width
        BAR_PADDING,                // Lateral bar separation from panel
        BAR_SELECTOR_HEIGHT,        // Lateral bar selector height
        BAR_SELECTOR_PADDING        // Lateral bar selector outer padding
    }

    // ListView
    enum GuiListViewProperty
    {
        ELEMENTS_HEIGHT = 16,
        ELEMENTS_PADDING,
        SCROLLBAR_WIDTH,
    }

    public static partial class Raylib
    {
        // Global gui modification functions
        // Enable gui controls (global state)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiEnable();                                         
        
        // Disable gui controls (global state)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiFade(float alpha);                                    
          
        // Style set/get functions
        // Set one style property
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetStyle(int control, int property, int value);         
        
        // Get one style property
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiGetStyle(int control, int property);                     
             
        // Container/separator controls, useful for controls organization
        // Window Box control, shows a window that can be closed
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiWindowBox(Rectangle bounds, string text);                                        
        
        // Group Box control with title name
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiGroupBox(Rectangle bounds, string text);                                         
        
        // Line separator control
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiLine(Rectangle bounds, int thick);                                                    
        
        // Panel control, useful to group controls
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiPanel(Rectangle bounds);                                                              
        
        // Scroll Panel control
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Vector2 GuiScrollPanel(Rectangle bounds, Rectangle content, Vector2 viewScroll);                   
        
        // Basic controls set
        // Label control, shows text
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiLabel(Rectangle bounds, string text);                                            
        
        // Button control, returns true when clicked
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiButton(Rectangle bounds, string text);                                           
        
        // Label button control, show true when clicked
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiLabelButton(Rectangle bounds, string text);                                      
        
        // Image button control, returns true when clicked
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiImageButton(Rectangle bounds, Texture2D texture);                                     
        
        // Image button extended control, returns true when clicked
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiImageButtonEx(Rectangle bounds, Texture2D texture, Rectangle texSource, string text); 
        
        // Toggle Button control, returns true when active
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiToggleButton(Rectangle bounds, string text, bool toggle);                        
        
        // Toggle Group control, returns toggled button index
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiToggleGroup(Rectangle bounds, string text, int count, int active);               
        
        // Check Box control, returns true when active
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiCheckBox(Rectangle bounds, bool isChecked);                                             
        
        // Check Box control with text, returns true when active
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiCheckBoxEx(Rectangle bounds, bool isChecked, string text);                         
        
        // Combo Box control, returns selected item index
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiComboBox(Rectangle bounds, string text, int count, int active);                  
        
        // Dropdown Box control, returns selected item
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiDropdownBox(Rectangle bounds, string[] text, int count, int active);               
        
        // Spinner control, returns selected value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiSpinner(Rectangle bounds, int value, int maxValue, int btnWidth);                      
        
        // Value Box control, updates input text with numbers
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiValueBox(Rectangle bounds, int value, int maxValue);                                   
        
        // Text Box control, updates input text
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiTextBox(Rectangle bounds, StringBuilder text, int textSize, bool freeEdit);                   
                
        // Text Box control with multiple lines
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiTextBoxMulti(Rectangle bounds, StringBuilder text, int textSize, bool editMode);         
        
        // Slider control, returns selected value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiSlider(Rectangle bounds, float value, float minValue, float maxValue);               
        
        // Slider control, returns selected value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiSliderEx(Rectangle bounds, float value, float minValue, float maxValue, string text, bool showValue); 
        
        // Slider Bar control, returns selected value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiSliderBar(Rectangle bounds, float value, float minValue, float maxValue);            
        
        // Slider Bar control, returns selected value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiSliderBarEx(Rectangle bounds, float value, float minValue, float maxValue, string text, bool showValue); 
        
        // Progress Bar control, shows current progress value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiProgressBar(Rectangle bounds, float value, float minValue, float maxValue);          
        
        // Progress Bar control, shows current progress value
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern float GuiProgressBarEx(Rectangle bounds, float value, float minValue, float maxValue, bool showValue); 
        
        // Status Bar control, shows info text
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiStatusBar(Rectangle bounds, string text, int offsetX);                           
        
        // Dummy control for placeholders
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiDummyRec(Rectangle bounds, string text);                                              
        
        // Advance controls set
        // List View control, returns selected list element index
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiListView(Rectangle bounds, string text, int count, int active);                  
        
        // Color Picker control
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern Color GuiColorPicker(Rectangle bounds, Color color);                                          
        
        // Message Box control, displays a message
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiMessageBox(Rectangle bounds, string windowTitle, string message);    
    }
}
