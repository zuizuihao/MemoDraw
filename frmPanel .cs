using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoteTaken.Code;
using NoteTaken.MemoDataSetTableAdapters;
using System.Collections;
//using DevComponents.DotNetBar;
//using DevComponents.DotNetBar.Controls;

namespace NoteTaken
{
    public partial class frmPanel : Form
    {
        
        public frmPanel()
        {
            InitializeComponent();
        }        


        private void frmPanel_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            MemoEntity memo = new MemoEntity();
            memo.ID = Guid.NewGuid();
            memo.X = me.X;
            memo.Y = me.Y;
            MemoPanelSizableDragable memoPanel = new MemoPanelSizableDragable(memo);
            memos.Add(memo.ID,memoPanel);
            this.Controls.Add(memoPanel);
            List<int> li = new List<int>();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                int level = this.Controls.GetChildIndex(this.Controls[i]);
                li.Add(level);
            }
        }
        // Fields
        
        private Hashtable memos = new Hashtable();
        private void frmPanel_Load_1(object sender, EventArgs e)
        {
            //int i = richTextBox1.Margin.Top;
            
            //richTextBox1.Margin.Top = 1;
            //MemoEntity meTemp;
            //MemoTableAdapter mta = new MemoTableAdapter();
            //DataTable MemoTable = mta.GetMemos();
            //for (int i = 0; i < MemoTable.Rows.Count; i++)
            //{
            //    meTemp = CreatMemo(MemoTable.Rows[i]);
            //    MemoPanelSizableDragable memoPanel = new MemoPanelSizableDragable(meTemp);
            //    memos.Add(meTemp.ID, memoPanel);
            //    this.Controls.Add(memoPanel);
            //    //this.Controls.SetChildIndex(memoPanel,meTemp.LevelIndex);
            //}           
        } 
        private MemoEntity CreatMemo(DataRow dr)
        {
            MemoEntity me = new MemoEntity();
            me.ID = (Guid)dr[0];
            me.TypeID = (int)dr[1];
            me.SysUserID = (int)dr[2];
            me.Content = (string)dr[3];
            me.BackColorID = (int)dr[4];
            me.X = (int)dr[5];
            me.Y = (int)dr[6];
            me.Width = (int)dr[7];
            me.Height = (int)dr[8];
            me.LevelIndex = (int)dr[9];
            me.CreateTime = (DateTime)dr[10];
            return me;
        }

        private void richTextBoxEx1_Resize(object sender, EventArgs e)
        {
            
        }

        private void richTextBoxEx1_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void transpMask_Click(object sender, EventArgs e)
        {

        }

        private void picBoxClose_Click(object sender, EventArgs e)
        {

        }

        private void picBoxSetting_Click(object sender, EventArgs e)
        {

        }

        private void transpMask_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void transpMask_MouseLeave(object sender, EventArgs e)
        {

        }

        private void transpMask_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void transpRTextBox_MouseLeave(object sender, EventArgs e)
        {

        }

        private void transpMask_MouseHover(object sender, EventArgs e)
        {

        }
              
    }
}