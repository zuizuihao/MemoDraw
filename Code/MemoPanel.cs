using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Drawing;
using System.Windows.Forms;

namespace NoteTaken.Code
{
    class MemoPanel:PanelEx
    {
        private System.Windows.Forms.Button picBoxSetting;
        private System.Windows.Forms.Button picBoxClose;
        private TransparentRichTextBox transpRTextBox;
        private System.Windows.Forms.Label lblTitle;
        private TranspCtrl transpMask;
        //在边界5像素周围是可以显示出箭头
        const int Band = 5;
        const int MinWidth = 80;
        const int MinHeight = 80;
        private EnumMousePointPosition m_MousePointPosition;
        private Point p, p1;
        public MemoEntity memoEntity { set; get; }      
        public MemoPanel()
        {
            InitAllControls();
        }
        public Random rand;
        public Color CreateRandomColor()
        {
            rand = new Random();
            memoEntity.BackColorID = rand.Next(12);
            return Color.FromName(Enum.GetName(typeof(EnumMemoColor), memoEntity.BackColorID));
        }
        //初始化Panel中所有的控件
        private void InitAllControls()
        {
            this.picBoxSetting = new System.Windows.Forms.Button();
            this.picBoxClose = new System.Windows.Forms.Button();

            this.lblTitle = new System.Windows.Forms.Label();
            this.transpMask = new TranspCtrl();
            this.transpRTextBox = new NoteTaken.TransparentRichTextBox();
            // 
            // memoPanel
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.transpMask);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.transpRTextBox);
            this.Controls.Add(this.picBoxSetting);
            this.Controls.Add(this.picBoxClose);
            this.Name = "memoPanel";
            this.Padding = new System.Windows.Forms.Padding(5, 20, 5, 5);
            this.TabIndex = 2;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.MouseLeave += new System.EventHandler(this.MyMouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // picBoxSetting
            // 
            this.picBoxSetting.BackgroundImage = global::NoteTaken.Properties.Resources.Memo_Seting;
            this.picBoxSetting.Location = new System.Drawing.Point(3, 0);
            this.picBoxSetting.Name = "picBoxSetting";
            this.picBoxSetting.Size = new System.Drawing.Size(16, 16);
            this.picBoxSetting.TabIndex = 4;
            this.picBoxSetting.TabStop = false;
            this.picBoxSetting.Visible = false;
            this.picBoxSetting.Click += new System.EventHandler(this.picBoxSetting_Click);
            // 
            // picBoxClose
            // 
            this.picBoxClose.BackgroundImage = global::NoteTaken.Properties.Resources.Memo_Close;
            this.picBoxClose.Location = new System.Drawing.Point(25, 1);
            this.picBoxClose.Name = "picBoxClose";
            this.picBoxClose.Size = new System.Drawing.Size(16, 16);
            this.picBoxClose.TabIndex = 5;
            this.picBoxClose.TabStop = false;
            this.picBoxClose.Visible = false;
            this.picBoxClose.Click += new System.EventHandler(this.picBoxClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(47, 4);
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 12);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "2013年8点12分";
            // 
            // transpMask
            // 
            this.transpMask.BackColor = System.Drawing.Color.Transparent;
            this.transpMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transpMask.Location = new System.Drawing.Point(0, 16);
            this.transpMask.Name = "transpMask";
            this.transpMask.Opacity = 100;
            this.transpMask.Size = new System.Drawing.Size(200, 100);
            this.transpMask.TabIndex = 8;
            this.transpMask.Text = "transpCtrl1";
            this.transpMask.Click += new System.EventHandler(this.transpMask_Click);
            this.transpMask.MouseDown += new System.Windows.Forms.MouseEventHandler(this.transpMask_MouseDown);
            this.transpMask.MouseUp += new System.Windows.Forms.MouseEventHandler(this.transpMask_MouseUp);
            this.transpMask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.transpMask_MouseMove);
            // 
            // transpRTextBox
            // 
            this.transpRTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transpRTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transpRTextBox.Location = new System.Drawing.Point(0, 16);
            this.transpRTextBox.Name = "transpRTextBox";
            this.transpRTextBox.Size = new System.Drawing.Size(200, 100);
            this.transpRTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.transpRTextBox.TabIndex = 6;
            this.transpRTextBox.Text = "";
            this.transpRTextBox.MouseLeave += new System.EventHandler(this.transpRTextBox_MouseLeave);
            this.transpRTextBox.ContentsResized += new ContentsResizedEventHandler(transpRTextBox_ContentsResized);
        }

        public void MyMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int i = 0;
            if (i >= 0) { }
            //记录鼠标的位置
            p.X = e.X;
            p.Y = e.Y;
            p1.X = e.X;
            p1.Y = e.Y;
        }
        public void MyMouseLeave(object sender, System.EventArgs e)
        {
            m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            this.Cursor = Cursors.Arrow;
            //if (IsMemoModified())
            {
                //mta.UpdateOriginXYWH(this.Left, this.Top, this.Width, this.Height, memoEntity.ID);
            }
        }
        //判断Memo是否发生了改变
        private bool IsMemoModified()
        {
            if (memoEntity.X != this.Left || memoEntity.Y != this.Top ||
                memoEntity.Width != this.Width || memoEntity.Height != this.Height)
                return true;
            else
                return false;
        }
        //size当前控件的宽高，判断现在鼠标所指方向。
        private EnumMousePointPosition MousePointPosition(Size size, System.Windows.Forms.MouseEventArgs e)
        {

            if ((e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
            {
                if (e.X < Band)
                {
                    if (e.Y < Band) { return EnumMousePointPosition.MouseSizeTopLeft; }
                    else
                    {
                        if (e.Y > -1 * Band + size.Height)
                        { return EnumMousePointPosition.MouseSizeBottomLeft; }
                        else
                        { return EnumMousePointPosition.MouseSizeLeft; }
                    }
                }
                else
                {
                    if (e.X > -1 * Band + size.Width)
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTopRight; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottomRight; }
                            else
                            { return EnumMousePointPosition.MouseSizeRight; }
                        }
                    }
                    else
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTop; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottom; }
                            else
                            { return EnumMousePointPosition.MouseDrag; }
                        }
                    }
                }
            }
            else
            { return EnumMousePointPosition.MouseSizeNone; }
        }
        public void MyMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control lCtrl = sender as Control;

            if (e.Button == MouseButtons.Left)
            {
                switch (m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseDrag:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + e.Y - p.Y;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        //       lCtrl.Height = lCtrl.Height + e.Y - p1.Y;  
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width + (e.X - p1.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    default:
                        break;
                }
                if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
                if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;
            }
            else
            {
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e);   //'判断光标的位置状态  
                switch (m_MousePointPosition)   //'改变光标  
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        this.Cursor = Cursors.Arrow;        //'箭头  
                        break;
                    //case EnumMousePointPosition.MouseDrag:
                    //    this.Cursor = Cursors.SizeAll;      //'四方向  
                    //    break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        this.Cursor = Cursors.SizeNS;       //'南北  
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        this.Cursor = Cursors.SizeNS;       //'南北  
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        this.Cursor = Cursors.SizeWE;       //'东西  
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        this.Cursor = Cursors.SizeWE;       //'东西  
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西  
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北  
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北  
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西  
                        break;
                    default:
                        break;
                }
            }

        }
        
        private void transpMask_Click(object sender, EventArgs e)
        {
            this.transpMask.Hide();            
        }

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
            }
        }

        private void picBoxSetting_Click(object sender, EventArgs e)
        {

        }

         private bool isMouseDown = false;
        private Point mouseOffset; //记录鼠标指针的坐标
        private void transpMask_MouseDown(object sender, MouseEventArgs e)
        {
            //Control crl = sender as Control;
            //this.MyMouseDown(crl.Parent, e);
            //this.BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset.X = e.X;
                mouseOffset.Y = e.Y;
                isMouseDown = true;
            }
        }

        private void transpMask_MouseUp(object sender, MouseEventArgs e)
        {
            //Control ctl = sender as Control;
            //this.MyMouseLeave(ctl.Parent, e);
            //this.picBoxClose.Hide();
            //this.picBoxSetting.Hide();
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void transpMask_MouseMove(object sender, MouseEventArgs e)
        {
            //Control ctl = sender as Control;
            //this.MyMouseMove(ctl.Parent, e);
            this.Cursor = Cursors.SizeAll;    
            if (isMouseDown)
            {
                int left = this.Left + e.X - mouseOffset.X;
                int top = this.Top + e.Y - mouseOffset.Y;
                this.Location = new Point(left, top);
            }
        }
        private void transpRTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.transpMask.Show();
            this.picBoxClose.Hide();
            this.picBoxSetting.Hide();           
        }
        private void transpRTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            if (this.transpRTextBox.Parent.Height <(e.NewRectangle.Height+10))
            this.transpRTextBox.Parent.Height = e.NewRectangle.Height + 10;
            this.transpRTextBox.Parent.Height = 200;
        }        
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.picBoxClose.Show();
            this.picBoxSetting.Show();
        }       
    }
}
