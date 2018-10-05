using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Raylib.Raylib;

namespace Raylib
{
    class RayForm : Form
    {
        private Panel panel;

        #region WinAPI Entry Points

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowPos(IntPtr handle, IntPtr handleAfter, int x, int y, int cx, int cy, uint flags);
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr child, IntPtr newParent);
        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr handle, int command);

        #endregion

        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RayForm());
        }

        public RayForm()
        {
            panel = new Panel();
            panel.Size = new Size(640, 480);
            panel.Location = new Point(80, 10);
            panel.BackColor = System.Drawing.Color.Red;
            Controls.Add(panel);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawControl
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "DrawControl";
            this.Load += new System.EventHandler(this.DrawControl_Load);
            this.ResumeLayout(false);

        }

        private void DrawControl_Load(object sender, EventArgs e)
        {

        }
    }
}
