using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Raylib;
using static Raylib.Raylib;

namespace Test.NetFX
{
    public partial class RayForms : Form
    {
        private Panel gamePanel;
        private bool windowAttached = false;

        #region WinAPI Entry Points

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowPos(IntPtr handle, IntPtr handleAfter, int x, int y, int cx, int cy, uint flags);
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr child, IntPtr newParent);
        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr handle, int command);

        #endregion

        public RayForms()
        {
            Size = new Size(1024, 700);
            Text = "Rayforms";

            gamePanel = new Panel();
            gamePanel.Size = new Size(800, 500);
            gamePanel.Location = new Point(50, 50);

            Button button = new Button();
            button.Text = "Attach window";
            button.Size = new Size(150, 20);
            button.Location = new Point(
                (Size.Width / 2) - (button.Size.Width / 2),
                gamePanel.Location.Y + gamePanel.Size.Height + 10
            );
            button.Click += new EventHandler(ClickedButton);
            Controls.Add(button);
            Controls.Add(gamePanel);
        }

        private void ClickedButton(object sender, EventArgs e)
        {
            if (!windowAttached)
            {
                // new Thread(Test).Start();
                Test();
            }
        }

        private void Test()
        {
            SetConfigFlags(ConfigFlag.FLAG_WINDOW_UNDECORATED);
            InitWindow(800, 480, "Rayforms test");
            SetTargetFPS(60);

            IntPtr winHandle = GetWindowHandle();
            Invoke(new Action(() =>
            {
                SetWindowPos(winHandle, Handle, 0, 0, 0, 0, 0x0401 /*NOSIZE | SHOWWINDOW */);
                SetParent(winHandle, gamePanel.Handle);
                ShowWindow(winHandle, 1);
                windowAttached = true;
            }));

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(RAYWHITE);

                DrawText("Congrats! You created your first window!", 190, 200, 20, MAROON);

                DrawText(GetFrameTime().ToString(), 100, 10, 15, MAROON);

                DrawFPS(10, 10);

                EndDrawing();
                //----------------------------------------------------------------------------------
            }
            CloseWindow();
        }

        public static void Run()
        {
            Application.Run(new RayForms());
        }
    }
}
