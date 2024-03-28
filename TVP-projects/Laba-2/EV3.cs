using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2
{
    internal class EV3
    {
        int x, y;
        int w, h;
        ComboBox ComboBox1;

        public EV3(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            ComboBox1 = new ComboBox();
            ComboBox1.Left = x;
            ComboBox1.Top = y;
            ComboBox1.Width = w / 10;
        }
        Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\Sourse\\github\\TVP-Work\\TVP-projects\\Laba-2\\Image\\001.png");
        internal void Paint(Graphics g)
        {
            if (h == 70)
            {
                g.DrawImage(bitmap, x, y, w, h);
            }
            if(h == 35)
            {
                g.FillRectangle(Brushes.DarkOrange, x, y, w, h);
            }
            g.DrawRectangle(Pens.Black, x, y, w, h);
        }
    }
}
