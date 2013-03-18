using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using NoteTaken.MemoDataSetTableAdapters;
using DevComponents.DotNetBar;

namespace NoteTaken.Code
{
    class MemoPanelSizableDragable : PanelEx
    {
        //在边界5像素周围是可以显示出箭头
        const int Band = 8;
        const int MinWidth = 80;
        const int MinHeight = 80;
        private EnumMousePointPosition m_MousePointPosition;
        private Point p, p1;
        public MemoEntity memoEntity { set; get; }      
        public MemoPanelSizableDragable(MemoEntity _memoEntity)
        {
            
            this.mta = new MemoTableAdapter();
            this.memoEntity = _memoEntity;
            InitPanel();
            this.Width = memoEntity.Width;
            this.Height = memoEntity.Height;
            this.Location = new Point(memoEntity.X, memoEntity.Y);
            this.transpCtrl1 = new TranspCtrl();
            this.richTextBox1 = new TransparentRichTextBox();
            CreateRichTextbox(memoEntity.Content);
            CreateTransCtl();
            this.Controls.Add(transpCtrl1);
            this.Controls.Add(richTextBox1);
        }
        private void InitPanel()
        {
            this.CanvasColor = System.Drawing.SystemColors.Control;
            this.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Style.Alignment = System.Drawing.StringAlignment.Center;
            Color light = Color.FromName(Enum.GetName(typeof(EnumMemoColor), memoEntity.BackColorID));
            int ColorInterval = 60;
            this.Style.BackColor1.Color = light;
            this.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(light.R)) - ColorInterval)), ((int)(((byte)(light.G)) - ColorInterval)), ((int)(((byte)(light.B)) - ColorInterval)));
            this.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Style.GradientAngle = 90;
            this.Padding = new  System.Windows.Forms.Padding(0, 16, 0, 0);
        }
        public Random rand;
        public Color CreateRandomColor()
        {
            rand = new Random();
            memoEntity.BackColorID = rand.Next(12);
            return Color.FromName(Enum.GetName(typeof(EnumMemoColor), memoEntity.BackColorID));
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
            if (IsMemoModified())
            {
                mta.UpdateOriginXYWH(this.Left, this.Top, this.Width, this.Height, memoEntity.ID);
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
                //IsXYWHModified = true;
            }
            else
            {
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e);   //'判断光标的位置状态  
                switch (m_MousePointPosition)   //'改变光标  
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        this.Cursor = Cursors.Arrow;        //'箭头  
                        break;
                    case EnumMousePointPosition.MouseDrag:
                        this.Cursor = Cursors.SizeAll;      //'四方向  
                        break;
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
        private void MyMouseEnter(object sender, EventArgs e)
        {

        }
        private TransparentRichTextBox richTextBox1;
        private void CreateRichTextbox(string memoContent)
        {
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = Color.FromName(Enum.GetName(typeof(EnumMemoColor), memoEntity.BackColorID));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            //this.richTextBox1.Size = new System.Drawing.Size(303, 277);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = memoContent;
            this.richTextBox1.MouseLeave += new System.EventHandler(this.richTextBox1_MouseLeave);
            this.richTextBox1.ContentsResized += new ContentsResizedEventHandler(richTextBox1_ContentsResized);
        }
        private TranspCtrl transpCtrl1;
        private void CreateTransCtl()
        {
            // 
            // transpCtrl1
            // 
            this.transpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.transpCtrl1.Location = new System.Drawing.Point(0, 3);
            this.transpCtrl1.Name = "transpCtrl1";
            this.transpCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transpCtrl1.Opacity = 100;
            this.transpCtrl1.Size = new System.Drawing.Size(303, 271);
            this.transpCtrl1.TabIndex = 1;
            this.transpCtrl1.Text = "transpCtrl1";
            this.transpCtrl1.Click += new System.EventHandler(this.transpCtrl1_Click);
            this.transpCtrl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.transpCtrl1_MouseDown);
            this.transpCtrl1.MouseLeave += new System.EventHandler(this.transpCtrl1_MouseLeave);
            this.transpCtrl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.transpCtrl1_MouseMove);
            //this.transpCtrl1.Enter += new EventHandler(this.transpCtrl1_Enter);
        }
        private void transpCtrl1_MouseDown(object sender, MouseEventArgs e)
        {
            Control btn = sender as Control;
            this.MyMouseDown(btn.Parent, e);
            this.BringToFront();
            //int levelIndex = this.Parent.Controls.GetChildIndex(this);
            //int levelIndex = this.Parent.Controls.IndexOf(this);
            List<int> li = new List<int>();
            for (int i = 0; i < this.Parent.Controls.Count; i++)
            {
                int level = this.Parent.Controls.GetChildIndex(this.Parent.Controls[i]);
                li.Add(level);
            }
            int leve111= this.Parent.Controls.IndexOf(this);
        }

        private void transpCtrl1_MouseLeave(object sender, EventArgs e)
        {
            Control ctl = sender as Control;           
            this.MyMouseLeave(ctl.Parent, e);
        }

        private void transpCtrl1_MouseMove(object sender, MouseEventArgs e)
        {
            Control btn = sender as Control;
            this.MyMouseMove(btn.Parent, e);
        }
        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            this.transpCtrl1.Show();
            PictureBox pb1 = this.transpCtrl1.Controls[0] as PictureBox;
            PictureBox pb2 = this.transpCtrl1.Controls[1] as PictureBox;
            pb1.Hide();
            pb2.Hide();
            int? count = mta.MemoExist(memoEntity.ID);
            if (count > 0)
            {
                mta.UpdateContent(this.richTextBox1.Text.ToString(), memoEntity.ID);
            }
            else
            {
                memoEntity.LevelIndex = this.Parent.Controls.GetChildIndex(this);
                memoEntity.Content = this.richTextBox1.Text.ToString();
                mta.InsertMemo(memoEntity.ID, 1, 13, memoEntity.Content, memoEntity.BackColorID, memoEntity.X, memoEntity.Y, 
                    memoEntity.Width, memoEntity.Height, memoEntity.LevelIndex, DateTime.Now);
            }
            
        }
        public  MemoTableAdapter mta;
        private void richTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            this.richTextBox1.Parent.Height = e.NewRectangle.Height + 10;

        }
        private void transpCtrl1_Click(object sender, EventArgs e)
        {
            //this.richTextBox1.BringToFront();
            //int levelIndex = this.Parent.Controls.GetChildIndex(this);
            //if (memoEntity.LevelIndex != levelIndex)
            //    mta.UpdateLevelIndex(levelIndex,memoEntity.ID);
            this.transpCtrl1.Hide();
        }      
    }
}
