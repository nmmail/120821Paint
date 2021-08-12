using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace проба
{
    public partial class Class_For_Visable
    {
        public Item currItem;
        public Pen pen = new Pen(Color.Black ,1);
        public bool draw = false;
        public int x, y;
        public enum Item
        {
            Rectangle , Ellipse, Line , Pencil, eraser, ColorPicker
        }

    }
}
