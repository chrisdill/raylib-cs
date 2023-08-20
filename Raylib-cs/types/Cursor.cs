
namespace Raylib_cs
{
    public readonly struct Cursor
    {
        /// <summary>{ <see langword="set"/>; }
        /// <see langword="true"/> <inheritdoc cref="Raylib.EnableCursor"/>
        /// <see langword="false"/> <inheritdoc cref="Raylib.DisableCursor"/></summary>
        public bool Enabled
        {
            set
            {
                if (value) Raylib.EnableCursor();
                else Raylib.DisableCursor();
            }
        }

        /// <summary>{ <see langword="get"/>; }
        /// <inheritdoc cref="Raylib.IsCursorHidden"/>,
        /// { <see langword="set"/>; }
        /// <see langword="true"/> <inheritdoc cref="Raylib.HideCursor"/>
        /// <see langword="false"/> <inheritdoc cref="Raylib.ShowCursor"/></summary>
        public bool Hidden
        {
            get => Raylib.IsCursorHidden();
            set
            {
                if (value) Raylib.HideCursor();
                else Raylib.ShowCursor();
            }
        }

        /// <summary>{ <see langword="set"/>; }
        /// <inheritdoc cref="Raylib.SetMouseCursor"/></summary>
        private MouseCursor MouseCursor // Unsure whether this makes sense so leave it disabled for now
        {
            set => Raylib.SetMouseCursor(value);
        }

        /// <summary>{ <see langword="get"/>; }
        /// <inheritdoc cref="Raylib.IsCursorOnScreen"/></summary>
        public bool OnScreen => Raylib.IsCursorOnScreen();
    }
}
