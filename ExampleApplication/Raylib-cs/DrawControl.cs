using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Raylib
{
    class DrawControl : Form
    {
        private Panel panel;

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr child, IntPtr newParent);
        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr handle, int command);

        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DrawControl());
        }

        public DrawControl()
        {
            panel = new Panel();
            panel.Size = new Size(640, 480);
            panel.Location = new Point(80, 10);
            panel.BackColor = System.Drawing.Color.Red;
            Controls.Add(panel);

            // TODO: get raylib window handle?
            IntPtr winHandle = IntPtr.Zero;
            SetParent(winHandle, panel.Handle);
            ShowWindow(winHandle, 1);
        }
    }
}