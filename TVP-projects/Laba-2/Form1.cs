using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2
{
    public partial class Form1 : Form
    {
        EV3 l1, l2;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            l1.Paint(g);
            l2.Paint(g);
        }

        public Form1()
        {
            InitializeComponent();
            l1 = new EV3(100, 100, 100, 100);
            l2 = new EV3(150, 100, 300, 150);
        }
    }
}
