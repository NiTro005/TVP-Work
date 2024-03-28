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
        public System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
        public System.Windows.Forms.Button but1 = new System.Windows.Forms.Button();

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
            l1 = new EV3(150, 100, 300, 35, this);
            l3 = new EV3(150, 135, 300, 70, this);
            l2 = new EV3(150, 100, 300, 150, this);

            comboBox.Items.Add("1");
            comboBox.Items.Add("2");
            comboBox.Items.Add("3");
            comboBox.Items.Add("4");
            but1.Text = "Режимы";
            comboBox.SelectedIndex = 0;
            Controls.Add(comboBox);
            Controls.Add(but1);

        }
    }
    
}
