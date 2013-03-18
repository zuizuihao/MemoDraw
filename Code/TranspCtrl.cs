using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using NoteTaken.Code;
using DevComponents.DotNetBar;

public class TranspCtrl : Control
{
    public bool drag = false;
    public bool enab = false;
    private int m_opacity = 100;
    //private System.Windows.Forms.PictureBox pictureBox2;
    //private System.Windows.Forms.PictureBox pictureBox1;
    private int alpha;
    public TranspCtrl()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.Opaque, true);
        this.BackColor = Color.Transparent;

        //CreateButton();
        //this.Controls.Add(pictureBox1);
        //this.Controls.Add(pictureBox2);
       
    }
    //private void CreateButton()
    //{
    //    this.pictureBox1 = new PictureBox();
    //    this.pictureBox2 = new PictureBox();
    //    // 
    //    // pictureBox1
    //    // 
    //    this.pictureBox1.BackgroundImage = global::NoteTaken.Properties.Resources.Memo_Seting;
    //    this.pictureBox1.Location = new System.Drawing.Point(0, 0);
    //    this.pictureBox1.Name = "pictureBox1";
    //    this.pictureBox1.Size = new System.Drawing.Size(17, 17);
    //    this.pictureBox1.TabIndex = 0;
    //    this.pictureBox1.Visible = false;
    //    this.pictureBox1.TabStop = false;
    //    // 
    //    // pictureBox2
    //    // 
    //    this.pictureBox2.BackgroundImage = global::NoteTaken.Properties.Resources.Memo_Close;
    //    this.pictureBox2.Location = new System.Drawing.Point(25, 0);
    //    this.pictureBox2.Name = "pictureBox2";
    //    this.pictureBox2.Size = new System.Drawing.Size(17, 17);
    //    this.pictureBox2.TabIndex = 1;
    //    this.pictureBox2.Visible = false;
    //    this.pictureBox2.TabStop = false;
       
    //     this.pictureBox1.Click += new EventHandler(pictureBox1_Click);
    //    this.pictureBox2.Click += new EventHandler(pictureBox2_Click);
    //}
    public int Opacity
    {
        get
        {
            if (m_opacity > 100)
            {
                m_opacity = 100;
            }
            else if (m_opacity < 1)
            {
                m_opacity = 1;
            }
            return this.m_opacity;
        }
        set
        {
            this.m_opacity = value;
            if (this.Parent != null)
            {
                Parent.Invalidate(this.Bounds, true);
            }
        }
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle = cp.ExStyle | 0x20;
            return cp;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

        Color frmColor = this.Parent.BackColor;
        Brush bckColor = default(Brush);

        alpha = (m_opacity * 255) / 100;

        if (drag)
        {
            Color dragBckColor = default(Color);

            if (BackColor != Color.Transparent)
            {
                int Rb = BackColor.R * alpha / 255 + frmColor.R * (255 - alpha) / 255;
                int Gb = BackColor.G * alpha / 255 + frmColor.G * (255 - alpha) / 255;
                int Bb = BackColor.B * alpha / 255 + frmColor.B * (255 - alpha) / 255;
                dragBckColor = Color.FromArgb(Rb, Gb, Bb);
            }
            else
            {
                dragBckColor = frmColor;
            }

            alpha = 255;
            bckColor = new SolidBrush(Color.FromArgb(alpha, dragBckColor));
        }
        else
        {
            bckColor = new SolidBrush(Color.FromArgb(alpha, this.BackColor));
        }

        if (this.BackColor != Color.Transparent | drag)
        {
            g.FillRectangle(bckColor, bounds);
        }

        bckColor.Dispose();
        g.Dispose();
        base.OnPaint(e);
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
        if (this.Parent != null)
        {
            Parent.Invalidate(this.Bounds, true);
        }
        base.OnBackColorChanged(e);
    }

    protected override void OnParentBackColorChanged(EventArgs e)
    {
        this.Invalidate();
        base.OnParentBackColorChanged(e);
    }
    ////消息框中需要显示哪些按钮，此处显示“确定”和“取消”

    //MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
    //private void pictureBox1_Click(object sender, EventArgs e)
    //{
    //    Random rand = new Random();
    //    MemoPanelSizableDragable parent = this.Parent as MemoPanelSizableDragable;
    //    PanelEx panel = parent as PanelEx;
    //    parent.memoEntity.BackColorID = rand.Next(12);
    //    parent.mta.UpdateMemoBgColor(parent.memoEntity.BackColorID,parent.memoEntity.ID);
    //    Color light = Color.FromName(Enum.GetName(typeof(EnumMemoColor), parent.memoEntity.BackColorID));
    //    int ColorInterval = 60;
    //    panel.Style.BackColor1.Color = light;
    //    panel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(light.R)) - ColorInterval)), ((int)(((byte)(light.G)) - ColorInterval)), ((int)(((byte)(light.B)) - ColorInterval)));
    //    //panel.SendToBack();
    //    parent.SendToBack();
    //    //this.SendToBack();
    //    //this.Parent.Invalidate();
    //}
    //private void pictureBox2_Click(object sender, EventArgs e)
    //{
    //    MemoPanelSizableDragable mpsd = this.Parent as MemoPanelSizableDragable;
    //    if (mpsd != null && MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
    //    {
    //        mpsd.mta.DeleteMemo(mpsd.memoEntity.ID);
    //        this.Parent.Parent.Controls.Remove(mpsd);
    //    }
    //}
    //protected override void OnMouseHover(EventArgs e)
    //{
    //    base.OnMouseHover(e);
    //    this.pictureBox1.Show();
    //    this.pictureBox2.Show();
    //}   
}