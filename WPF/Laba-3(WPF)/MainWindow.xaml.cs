using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Laba_3_WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            CreateRectangles(15);
            
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            CreateRectangles(2);
        }

        private void CreateRectangles(int nRect)
        {
            for(int i = 0; i < nRect; i++)
            {
                Rectangle rect = new Rectangle();
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
                rect.HorizontalAlignment = HorizontalAlignment.Left;
                rect.VerticalAlignment = VerticalAlignment.Top;

                int x = random.Next((int)(this.Width - rect.Width)), y = random.Next((int)(this.Height - rect.Height));
                rect.Margin = new Thickness(x, y, 0, 0);
                rect.Stroke = Brushes.Black;
                byte r = (byte)random.Next(255);
                byte g = (byte)random.Next(255);
                byte b = (byte)random.Next(255);
                rect.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));

                rect.MouseDown += Rect_MouseDown;
                grid.Children.Add(rect);
            }
        }

        private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            Rect r = new Rect(rect.Margin.Left, rect.Margin.Top, rect.Width, rect.Height);
            int index = grid.Children.IndexOf(rect);

            for (int i = index + 1; i < grid.Children.Count; i++)
            {
                Rectangle otherRect = (Rectangle)grid.Children[i];
                Rect otherRectBounds = new Rect(otherRect.Margin.Left, otherRect.Margin.Top, otherRect.Width, otherRect.Height);

                if (otherRectBounds.IntersectsWith(r))
                {
                    return;
                }
            }
            grid.Children.Remove(rect);
        }
    }
    
}