using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DevComponents.DotNetBar;
using System.Drawing;
using System.Windows.Forms;

namespace NoteTaken.Code
{
    
    class MemoDragableAction:Panel
    { 
        private bool isMouseDown = false;
        private Point mouseOffset; //记录鼠标指针的坐标
        public MemoDragableAction() 
        {
            this.MouseDown += this.pan_Drop_MouseDown;
            this.MouseUp += this.pan_Drop_MouseUp;
            this.MouseMove += this.pan_Drop_MouseMove;
        }
        private void pan_Drop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset.X = e.X;
                mouseOffset.Y = e.Y;
                isMouseDown = true;
            }
        }

        private void pan_Drop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int left = this.Left + e.X - mouseOffset.X;
                int top = this.Top + e.Y - mouseOffset.Y;
                this.Location = new Point(left, top);
            }
        }

        private void pan_Drop_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
    }
}
