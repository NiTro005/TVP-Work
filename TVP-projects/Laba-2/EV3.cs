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
        Button Button1;

        public EV3(int x, int y, int w, int h, Form1 form)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            ComboBox1 = form.comboBox;
            ComboBox1.Width = w / 5;
            ComboBox1.Height = h / 6;
            ComboBox1.Left = x + w - ComboBox1.Width - 5;
            ComboBox1.Top = y + 5;

            Button1 = form.but1;
            Button1.Width = w / 5;
            Button1.Height = h / 3;
            Button1.Left = x;
            Button1.Top = y + h - Button1.Height;

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
