namespace NoteTaken
{
    partial class frmPanel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.memoPanel = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.picBoxSetting = new System.Windows.Forms.PictureBox();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.memoPanel1 = new NoteTaken.Code.MemoPanel();
            this.transpRTextBox = new NoteTaken.TransparentRichTextBox();
            this.memoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // memoPanel
            // 
            this.memoPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.memoPanel.Controls.Add(this.labelX1);
            this.memoPanel.Controls.Add(this.transpRTextBox);
            this.memoPanel.Controls.Add(this.picBoxSetting);
            this.memoPanel.Controls.Add(this.picBoxClose);
            this.memoPanel.Location = new System.Drawing.Point(370, 34);
            this.memoPanel.Name = "memoPanel";
            this.memoPanel.Padding = new System.Windows.Forms.Padding(10);
            this.memoPanel.Size = new System.Drawing.Size(200, 116);
            this.memoPanel.TabIndex = 2;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(64, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(98, 16);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "2013年8点12分";
            // 
            // picBoxSetting
            // 
            this.picBoxSetting.BackgroundImage = global::NoteTaken.Properties.Resources.Memo_Seting;
            this.picBoxSetting.Location = new System.Drawing.Point(3, 0);
            this.picBoxSetting.Name = "picBoxSetting";
            this.picBoxSetting.Size = new System.Drawing.Size(16, 16);
            this.picBoxSetting.TabIndex = 4;
            this.picBoxSetting.TabStop = false;
            this.picBoxSetting.Click += new System.EventHandler(this.picBoxSetting_Click);
            // 
            // picBoxClose
            // 
            this.picBoxClose.BackgroundImage = global::NoteTaken.Properties.Resources.Memo_Close;
            this.picBoxClose.Location = new System.Drawing.Point(25, 0);
            this.picBoxClose.Name = "picBoxClose";
            this.picBoxClose.Size = new System.Drawing.Size(16, 16);
            this.picBoxClose.TabIndex = 5;
            this.picBoxClose.TabStop = false;
            this.picBoxClose.Click += new System.EventHandler(this.picBoxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // memoPanel1
            // 
            this.memoPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.memoPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.memoPanel1.Location = new System.Drawing.Point(123, 167);
            this.memoPanel1.memoEntity = null;
            this.memoPanel1.Name = "memoPanel1";
            this.memoPanel1.Padding = new System.Windows.Forms.Padding(5, 16, 5, 5);
            this.memoPanel1.Size = new System.Drawing.Size(200, 200);
            this.memoPanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.memoPanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.memoPanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.memoPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.memoPanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.memoPanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.memoPanel1.Style.GradientAngle = 90;
            this.memoPanel1.TabIndex = 2;
            this.memoPanel1.Text = "memoPanel1";
            // 
            // transpRTextBox
            // 
            this.transpRTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transpRTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transpRTextBox.Location = new System.Drawing.Point(10, 10);
            this.transpRTextBox.Name = "transpRTextBox";
            this.transpRTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.transpRTextBox.Size = new System.Drawing.Size(180, 96);
            this.transpRTextBox.TabIndex = 6;
            this.transpRTextBox.Text = "";
            this.transpRTextBox.MouseLeave += new System.EventHandler(this.transpRTextBox_MouseLeave);
            // 
            // frmPanel
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(606, 413);
            this.Controls.Add(this.memoPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memoPanel);
            this.Name = "frmPanel";
            this.Text = "0000000000  ";
            this.Load += new System.EventHandler(this.frmPanel_Load_1);
            this.DoubleClick += new System.EventHandler(this.frmPanel_DoubleClick);
            this.memoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel memoPanel;
        private System.Windows.Forms.PictureBox picBoxSetting;
        private System.Windows.Forms.PictureBox picBoxClose;
        private TransparentRichTextBox transpRTextBox;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Code.MemoPanel memoPanel1;














        //private Controls.UCMemo ucMemo1;










        //private Code.MemoPanel memoPanel1;


    }
}

