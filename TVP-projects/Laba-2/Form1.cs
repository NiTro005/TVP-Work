using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laba_2
{
    public partial class Form1 : Form
    {
        EV3 l1, l2, l3;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            l1.Paint(g);
            l2.Paint(g);
            l3.Paint(g);
        }

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            l1 = new EV3(150, 100, 300, 35, comboBox);
            l3 = new EV3(150, 135, 300, 70, comboBox);
            l2 = new EV3(150, 100, 300, 150, comboBox);

            comboBox.Items.Add("1");
            comboBox.Items.Add("2");
            comboBox.Items.Add("3");
            comboBox.Items.Add("4");
            Controls.Add(comboBox);

        }
    }
    
}
