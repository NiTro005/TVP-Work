using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Laba_3_Forms_
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            CreateRectangles(15);

            Timer timer = new Timer();
            timer.Interval = 2000; // 2 seconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CreateRectangles(2);
        }

        private void CreateRectangles(int nRect)
        {
            for (int i = 0; i < nRect; i++)
            {
                Panel rect = new Panel();
                if (i % 2 == 0)
                {
                    rect.Width = 250;
                    rect.Height = 50;
                }
                else
                {
                    rect.Width = 50;
                    rect.Height = 250;
                }

                int x = random.Next((int)(this.ClientSize.Width - rect.Width));
                int y = random.Next((int)(this.ClientSize.Height - rect.Height));
                rect.Location = new Point(x, y);
                rect.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                rect.MouseDown += Rect_MouseDown;
                Controls.Add(rect);
            }
        }

        private void Rect_MouseDown(object sender, MouseEventArgs e)
        {
            Panel rect = (Panel)sender;
            Rectangle r = new Rectangle(rect.Location, rect.Size);
            int index = Controls.IndexOf(rect);

            for (int i = index - 1; i >= 0; i--)
            {
                Panel otherRect = (Panel)Controls[i];
                Rectangle otherRectBounds = new Rectangle(otherRect.Location, otherRect.Size);

                if (otherRectBounds.IntersectsWith(r))
                {
                    return;
                }
            }
            Controls.Remove(rect);
        }
    }
}