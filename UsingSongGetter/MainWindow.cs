using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsingSongGetter
{
    public partial class MainWindow : Form
    {

        private bool _titleBarClicked = false;
        private Point _lastCursorPosition;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            _titleBarClicked = true;
            _lastCursorPosition = e.Location;
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            _titleBarClicked = false;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if(_titleBarClicked)
            {
                this.Location = new Point((this.Location.X - _lastCursorPosition.X) + e.X, (this.Location.Y - _lastCursorPosition.Y) + e.Y);
                this.Update();
            }
        }

        private void titleBar_Close_MouseEnter(object sender, EventArgs e)
        {
            titleBar_Close.BackColor = (Color)new ColorConverter().ConvertFromString("#c0392b");
        }

        private void titleBar_Close_MouseLeave(object sender, EventArgs e)
        {
            titleBar_Close.BackColor = (Color)new ColorConverter().ConvertFromString("#e74c3c");
        }

        private void titleBar_Close_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void titleBar_Minimize_MouseEnter(object sender, EventArgs e)
        {
            titleBar_Minimize.BackColor = (Color)new ColorConverter().ConvertFromString("#2980b9");
        }

        private void titleBar_Minimize_MouseLeave(object sender, EventArgs e)
        {
            titleBar_Minimize.BackColor = (Color)new ColorConverter().ConvertFromString("#3498db");
        }

        private void titleBar_Minimize_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
