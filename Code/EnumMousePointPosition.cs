using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoteTaken.Code
{
    public enum EnumMousePointPosition
    {
        MouseSizeNone = 0, //'无  
        MouseSizeRight = 1, //'拉伸右边框  
        MouseSizeLeft = 2, //'拉伸左边框  
        MouseSizeBottom = 3, //'拉伸下边框  
        MouseSizeTop = 4, //'拉伸上边框  
        MouseSizeTopLeft = 5, //'拉伸左上角  
        MouseSizeTopRight = 6, //'拉伸右上角  
        MouseSizeBottomLeft = 7, //'拉伸左下角  
        MouseSizeBottomRight = 8, //'拉伸右下角  
        MouseDrag = 9   // '鼠标拖动  
    } 
}
