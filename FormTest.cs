using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoteTaken
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //创建一个Graphics对象
            Graphics grp = e.Graphics;
            //绘制线条 起始窗口坐标10,50 终止坐标20,350 红色，2px宽
            grp.DrawLine(new Pen(Color.Red, 2), new Point(10, 50), new Point(20, 350));
            //释放资源
            grp.Dispose();
        }
    }
}
