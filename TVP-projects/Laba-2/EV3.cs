using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    internal class EV3
    {
        int x, y;
        int w, h;

        public EV3(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        internal void Paint(Graphics g)
        {
            g.DrawRectangle(Pens.Black, x, y, w, h);
        }
    }
}
