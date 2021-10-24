namespace Raylib_cs
{
    /// <summary>Gamepad buttons</summary>
    public enum GamepadButton
    {
        /// <summary>
        /// This is here just for error checking
        /// </summary>
        GAMEPAD_BUTTON_UNKNOWN = 0,

        /// <summary>
        /// Gamepad left DPAD up button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_UP,

        /// <summary>
        /// Gamepad left DPAD right button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_RIGHT,

        /// <summary>
        /// Gamepad left DPAD down button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_DOWN,

        /// <summary>
        /// Gamepad left DPAD left button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_FACE_LEFT,

        /// <summary>
        /// Gamepad right button up (i.e. PS3: Triangle, Xbox: Y)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_UP,

        /// <summary>
        /// Gamepad right button right (i.e. PS3: Square, Xbox: X)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_RIGHT,

        /// <summary>
        /// Gamepad right button down (i.e. PS3: Cross, Xbox: A)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_DOWN,

        /// <summary>
        /// Gamepad right button left (i.e. PS3: Circle, Xbox: B)
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_FACE_LEFT,

        // Triggers
        GAMEPAD_BUTTON_LEFT_TRIGGER_1,
        GAMEPAD_BUTTON_LEFT_TRIGGER_2,
        GAMEPAD_BUTTON_RIGHT_TRIGGER_1,
        GAMEPAD_BUTTON_RIGHT_TRIGGER_2,

        // These are buttons in the center of the gamepad

        /// <summary>
        /// PS3 Select
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE_LEFT,

        /// <summary>
        /// PS Button/XBOX Button
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE,

        /// <summary>
        /// PS3 Start
        /// </summary>
        GAMEPAD_BUTTON_MIDDLE_RIGHT,

        /// <summary>
        /// Left joystick press button
        /// </summary>
        GAMEPAD_BUTTON_LEFT_THUMB,

        /// <summary>
        /// Right joystick press button
        /// </summary>
        GAMEPAD_BUTTON_RIGHT_THUMB
    }
}