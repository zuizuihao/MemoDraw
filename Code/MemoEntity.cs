using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoteTaken.Code
{
    public class MemoEntity 
    {
        internal const string DB_TableName = "Memo";

        #region Properties

        #region public Guid ID
        /// <summary>
        /// ID数据字段名
        /// </summary>
        public const string DF_ID = "Memo_ID";
        private Guid _ID = Guid.Empty;
        /// <summary>
        /// 备忘ID    
        /// </summary>
        public Guid ID
        {
            get
            {
                return _ID;
            }
            set { _ID = value; }
        }
        #endregion

        #region public int TypeID
        /// <summary>
        /// TypeID数据字段名
        /// </summary>
        public const string DF_TypeID = "Memo_TypeID";
        private int _TypeID = 0;
        /// <summary>
        /// 备忘类型(1,文本2图片3CheckList)    
        /// </summary>
        public int TypeID
        {
            get
            {
                return _TypeID;
            }
            set { _TypeID = value; }
        }
        #endregion

        #region public int SysUserID
        /// <summary>
        /// SysUserID数据字段名
        /// </summary>
        public const string DF_SysUserID = "Memo_SysUserID";
        private int _SysUserID = 0;
        /// <summary>
        /// 用户ID    
        /// </summary>
        public int SysUserID
        {
            get
            {
                return _SysUserID;
            }
            set { _SysUserID = value; }
        }
        #endregion

        #region public string Content
        /// <summary>
        /// Content数据字段名
        /// </summary>
        public const string DF_Content = "Memo_Content";
        private string _Content = string.Empty;
        /// <summary>
        /// 内容    
        /// </summary>
        public string Content
        {
            get
            {
                return _Content;
            }
            set { _Content = value; }
        }
        #endregion

        #region public int BackColorID
        /// <summary>
        /// BackColorID数据字段名
        /// </summary>
        public const string DF_BackColorID = "Memo_BackColorID";
        private int _BackColorID = 0;
        /// <summary>
        /// 背景色    
        /// </summary>
        public int BackColorID
        {
            get
            {
                return _BackColorID;
            }
            set { _BackColorID = value; }
        }
        #endregion

        #region public int X
        /// <summary>
        /// X数据字段名
        /// </summary>
        public const string DF_X = "Memo_X";
        private int _X = 100;
        /// <summary>
        /// X坐标    
        /// </summary>
        public int X
        {
            get
            {
                return _X;
            }
            set { _X = value; }
        }
        #endregion

        #region public int Y
        /// <summary>
        /// Y数据字段名
        /// </summary>
        public const string DF_Y = "Memo_Y";
        private int _Y = 100;
        /// <summary>
        /// Y坐标    
        /// </summary>
        public int Y
        {
            get
            {
                return _Y;
            }
            set { _Y = value; }
        }
        #endregion

        #region public int Width
        /// <summary>
        /// Width数据字段名
        /// </summary>
        public const string DF_Width = "Memo_Width";
        private int _Width = 100;
        /// <summary>
        /// 宽度    
        /// </summary>
        public int Width
        {
            get
            {
                return _Width;
            }
            set { _Width = value; }
        }
        #endregion

        #region public int Height
        /// <summary>
        /// Height数据字段名
        /// </summary>
        public const string DF_Height = "Memo_Height";
        private int _Height = 100;
        /// <summary>
        /// 高度    
        /// </summary>
        public int Height
        {
            get
            {
                return _Height;
            }
            set { _Height = value; }
        }
        #endregion

        #region public int LevelIndex
        /// <summary>
        /// LevelIndex数据字段名
        /// </summary>
        public const string DF_LevelIndex = "Memo_LevelIndex";
        private int _LevelIndex = 0;
        /// <summary>
        /// 层级Index    
        /// </summary>
        public int LevelIndex
        {
            get
            {
                return _LevelIndex;
            }
            set { _LevelIndex = value; }
        }
        #endregion

        #region public DateTime CreateTime
        /// <summary>
        /// CreateTime数据字段名
        /// </summary>
        public const string DF_CreateTime = "Memo_CreateTime";
        private DateTime _CreateTime = Convert.ToDateTime("1900/01/01");
        /// <summary>
        /// 建立时间    
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set { _CreateTime = value; }
        }
        #endregion

        #endregion


        #region Clone

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public MemoEntity Clone()
        {
            MemoEntity entity = new MemoEntity();
            Clone(entity);
            return entity;
        }

        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(MemoEntity entity)
        {
            entity.ID = this.ID;
            entity.TypeID = this.TypeID;
            entity.SysUserID = this.SysUserID;
            entity.Content = this.Content;
            entity.BackColorID = this.BackColorID;
            entity.X = this.X;
            entity.Y = this.Y;
            entity.Width = this.Width;
            entity.Height = this.Height;
            entity.LevelIndex = this.LevelIndex;
            entity.CreateTime = this.CreateTime;
        }
        #endregion
    }
}
