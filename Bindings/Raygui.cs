// Raygui - https://github.com/raysan5/raygui/blob/master/src/raygui.h

using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    #region Raylib-cs Enums

    // Gui properties enumeration
    enum GuiProperty
    {
        //--------------------------------------------
        // NOTE: This first set of properties is for general style,
        // following control-specific properties overwritte those styles
        DEFAULT_BACKGROUND_COLOR = 0,
        DEFAULT_LINES_COLOR,
        DEFAULT_TEXT_FONT,
        DEFAULT_TEXT_SIZE,
        DEFAULT_BORDER_WIDTH,
        DEFAULT_BORDER_COLOR_NORMAL,
        DEFAULT_BASE_COLOR_NORMAL,
        DEFAULT_TEXT_COLOR_NORMAL,
        DEFAULT_BORDER_COLOR_FOCUSED,
        DEFAULT_BASE_COLOR_FOCUSED,
        DEFAULT_TEXT_COLOR_FOCUSED,
        DEFAULT_BORDER_COLOR_PRESSED,
        DEFAULT_BASE_COLOR_PRESSED,
        DEFAULT_TEXT_COLOR_PRESSED,
        DEFAULT_BORDER_COLOR_DISABLED,
        DEFAULT_BASE_COLOR_DISABLED,
        DEFAULT_TEXT_COLOR_DISABLED,
        //--------------------------------------------
        // Label
        LABEL_TEXT_COLOR_NORMAL,
        LABEL_TEXT_COLOR_FOCUSED,
        LABEL_TEXT_COLOR_PRESSED,
        LABEL_TEXT_COLOR_DISABLED,
        // Button
        BUTTON_BORDER_WIDTH,
        BUTTON_BORDER_COLOR_NORMAL,
        BUTTON_BASE_COLOR_NORMAL,
        BUTTON_TEXT_COLOR_NORMAL,
        BUTTON_BORDER_COLOR_FOCUSED,
        BUTTON_BASE_COLOR_FOCUSED,
        BUTTON_TEXT_COLOR_FOCUSED,
        BUTTON_BORDER_COLOR_PRESSED,
        BUTTON_BASE_COLOR_PRESSED,
        BUTTON_TEXT_COLOR_PRESSED,
        BUTTON_BORDER_COLOR_DISABLED,
        BUTTON_BASE_COLOR_DISABLED,
        BUTTON_TEXT_COLOR_DISABLED,
        // Toggle
        TOGGLE_BORDER_WIDTH,
        TOGGLE_BORDER_COLOR_NORMAL,
        TOGGLE_BASE_COLOR_NORMAL,
        TOGGLE_TEXT_COLOR_NORMAL,
        TOGGLE_BORDER_COLOR_FOCUSED,
        TOGGLE_BASE_COLOR_FOCUSED,
        TOGGLE_TEXT_COLOR_FOCUSED,
        TOGGLE_BORDER_COLOR_PRESSED,
        TOGGLE_BASE_COLOR_PRESSED,
        TOGGLE_TEXT_COLOR_PRESSED,
        TOGGLE_BORDER_COLOR_DISABLED,
        TOGGLE_BASE_COLOR_DISABLED,
        TOGGLE_TEXT_COLOR_DISABLED,
        TOGGLEGROUP_PADDING,
        // Slider
        SLIDER_BORDER_WIDTH,
        SLIDER_SLIDER_WIDTH,
        SLIDER_BORDER_COLOR_NORMAL,
        SLIDER_BASE_COLOR_NORMAL,
        SLIDER_BORDER_COLOR_FOCUSED,
        SLIDER_BASE_COLOR_FOCUSED,
        SLIDER_BORDER_COLOR_PRESSED,
        SLIDER_BASE_COLOR_PRESSED,
        SLIDER_BORDER_COLOR_DISABLED,
        SLIDER_BASE_COLOR_DISABLED,
        // SliderBar
        SLIDERBAR_INNER_PADDING,
        SLIDERBAR_BORDER_WIDTH,
        SLIDERBAR_BORDER_COLOR_NORMAL,
        SLIDERBAR_BASE_COLOR_NORMAL,
        SLIDERBAR_BORDER_COLOR_FOCUSED,
        SLIDERBAR_BASE_COLOR_FOCUSED,
        SLIDERBAR_BORDER_COLOR_PRESSED,
        SLIDERBAR_BASE_COLOR_PRESSED,
        SLIDERBAR_BORDER_COLOR_DISABLED,
        SLIDERBAR_BASE_COLOR_DISABLED,
        // ProgressBar
        PROGRESSBAR_INNER_PADDING,
        PROGRESSBAR_BORDER_WIDTH,
        PROGRESSBAR_BORDER_COLOR_NORMAL,
        PROGRESSBAR_BASE_COLOR_NORMAL,
        PROGRESSBAR_BORDER_COLOR_FOCUSED,
        PROGRESSBAR_BASE_COLOR_FOCUSED,
        PROGRESSBAR_BORDER_COLOR_PRESSED,
        PROGRESSBAR_BASE_COLOR_PRESSED,
        PROGRESSBAR_BORDER_COLOR_DISABLED,
        PROGRESSBAR_BASE_COLOR_DISABLED,
        // ValueBox
        VALUEBOX_BUTTON_PADDING,
        VALUEBOX_BUTTONS_WIDTH,
        VALUEBOX_BORDER_COLOR_NORMAL,
        VALUEBOX_BASE_COLOR_NORMAL,
        VALUEBOX_TEXT_COLOR_NORMAL,
        VALUEBOX_BORDER_COLOR_FOCUSED,
        VALUEBOX_BASE_COLOR_FOCUSED,
        VALUEBOX_TEXT_COLOR_FOCUSED,
        VALUEBOX_BORDER_COLOR_PRESSED,
        VALUEBOX_BASE_COLOR_PRESSED,
        VALUEBOX_TEXT_COLOR_PRESSED,
        VALUEBOX_BORDER_COLOR_DISABLED,
        VALUEBOX_BASE_COLOR_DISABLED,
        VALUEBOX_TEXT_COLOR_DISABLED,
        // ComboBox
        COMBOBOX_BORDER_WIDTH,
        COMBOBOX_BUTTON_PADDING,
        COMBOBOX_SELECTOR_WIDTH,
        COMBOBOX_BORDER_COLOR_NORMAL,
        COMBOBOX_BASE_COLOR_NORMAL,
        COMBOBOX_TEXT_COLOR_NORMAL,
        COMBOBOX_BORDER_COLOR_FOCUSED,
        COMBOBOX_BASE_COLOR_FOCUSED,
        COMBOBOX_TEXT_COLOR_FOCUSED,
        COMBOBOX_BORDER_COLOR_PRESSED,
        COMBOBOX_BASE_COLOR_PRESSED,
        COMBOBOX_TEXT_COLOR_PRESSED,
        COMBOBOX_BORDER_COLOR_DISABLED,
        COMBOBOX_BASE_COLOR_DISABLED,
        COMBOBOX_TEXT_COLOR_DISABLED,
        // CheckBox
        CHECKBOX_BORDER_WIDTH,
        CHECKBOX_INNER_PADDING,
        CHECKBOX_BORDER_COLOR_NORMAL,
        CHECKBOX_BASE_COLOR_NORMAL,
        CHECKBOX_BORDER_COLOR_FOCUSED,
        CHECKBOX_BASE_COLOR_FOCUSED,
        CHECKBOX_BORDER_COLOR_PRESSED,
        CHECKBOX_BASE_COLOR_PRESSED,
        CHECKBOX_BORDER_COLOR_DISABLED,
        CHECKBOX_BASE_COLOR_DISABLED,
        // TextBox
        TEXTBOX_BORDER_WIDTH,
        TEXTBOX_BORDER_COLOR_NORMAL,
        TEXTBOX_BASE_COLOR_NORMAL,
        TEXTBOX_TEXT_COLOR_NORMAL,
        TEXTBOX_BORDER_COLOR_FOCUSED,
        TEXTBOX_BASE_COLOR_FOCUSED,
        TEXTBOX_TEXT_COLOR_FOCUSED,
        TEXTBOX_BORDER_COLOR_PRESSED,
        TEXTBOX_BASE_COLOR_PRESSED,
        TEXTBOX_TEXT_COLOR_PRESSED,
        TEXTBOX_BORDER_COLOR_DISABLED,
        TEXTBOX_BASE_COLOR_DISABLED,
        TEXTBOX_TEXT_COLOR_DISABLED,
        // ColorPicker
        COLORPICKER_BARS_THICK,
        COLORPICKER_BARS_PADDING,
        COLORPICKER_BORDER_COLOR_NORMAL,
        COLORPICKER_BASE_COLOR_NORMAL,
        COLORPICKER_BORDER_COLOR_FOCUSED,
        COLORPICKER_BASE_COLOR_FOCUSED,
        COLORPICKER_BORDER_COLOR_PRESSED,
        COLORPICKER_BASE_COLOR_PRESSED,
        COLORPICKER_BORDER_COLOR_DISABLED,
        COLORPICKER_BASE_COLOR_DISABLED,
        // ListView
        LISTVIEW_ELEMENTS_HEIGHT,
        LISTVIEW_ELEMENTS_PADDING,
        LISTVIEW_BAR_WIDTH,
        LISTVIEW_BORDER_COLOR_NORMAL,
        LISTVIEW_BASE_COLOR_NORMAL,
        LISTVIEW_TEXT_COLOR_NORMAL,
        LISTVIEW_BORDER_COLOR_FOCUSED,
        LISTVIEW_BASE_COLOR_FOCUSED,
        LISTVIEW_TEXT_COLOR_FOCUSED,
        LISTVIEW_BORDER_COLOR_PRESSED,
        LISTVIEW_BASE_COLOR_PRESSED,
        LISTVIEW_TEXT_COLOR_PRESSED,
        LISTVIEW_BORDER_COLOR_DISABLED,
        LISTVIEW_BASE_COLOR_DISABLED,
        LISTVIEW_TEXT_COLOR_DISABLED
    }

    // GUI controls state
    public enum GuiControlState 
    { 
        DISABLED = 0, 
        NORMAL, 
        FOCUSED, 
        PRESSED 
    }

    #endregion

    public static partial class Raylib
    {
        #region Raylib-cs Variables

        #endregion

        #region Raylib-cs Functions

        // Global gui modification functions
        // Enable gui controls (global state)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiEnable();                                         
        
        // Disable gui controls (global state)
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiDisable();                                        
        
        // Set gui controls alpha (global state), alpha goes from 0.0f to 1.0f
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiFade(float alpha);                                    
          
        // Style set/get functions
        // Set one style property
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern void GuiSetStyleProperty(int guiProperty, int value);         
        
        // Get one style property
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern int GuiGetStyleProperty(int guiProperty);                     
             
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
        public static extern bool GuiTextBox(Rectangle bounds, char text, int textSize, bool freeEdit);                   
        
        // Text Box control with multiple lines
        [DllImport(nativeLibName,CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GuiTextBoxMulti(Rectangle bounds, string text, int textSize, bool editMode);          
        
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

        #endregion      
    }
}
