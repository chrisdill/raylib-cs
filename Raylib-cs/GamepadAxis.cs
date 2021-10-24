namespace Raylib_cs
{
    /// <summary>Gamepad axis</summary>
    public enum GamepadAxis
    {
        /// <summary>
        /// Gamepad left stick X axis
        /// </summary>
        GAMEPAD_AXIS_LEFT_X = 0,

        /// <summary>
        /// Gamepad left stick Y axis
        /// </summary>
        GAMEPAD_AXIS_LEFT_Y = 1,

        /// <summary>
        /// Gamepad right stick X axis
        /// </summary>
        GAMEPAD_AXIS_RIGHT_X = 2,

        /// <summary>
        /// Gamepad right stick Y axis
        /// </summary>
        GAMEPAD_AXIS_RIGHT_Y = 3,

        /// <summary>
        /// Gamepad back trigger left, pressure level: [1..-1]
        /// </summary>
        GAMEPAD_AXIS_LEFT_TRIGGER = 4,

        /// <summary>
        /// Gamepad back trigger right, pressure level: [1..-1]
        /// </summary>
        GAMEPAD_AXIS_RIGHT_TRIGGER = 5
    }
}