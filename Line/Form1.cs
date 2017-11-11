using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Line
{
    public partial class Form1 : Form
    {
        Pen p = new Pen(Color.Green);
        Graphics g = null;

        static int start_x, start_y;
        static int end_x, end_y;
        
        static int my_length = 0;
        static int my_increment = 0;
        static int my_angle = 0;
        static int no_lines = 0;

        public Form1()
        {
            InitializeComponent();
            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;
        }
        
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            no_lines = Int32.Parse(number_of_lines.Text);
            p.Width = 3;
            my_length = Int32.Parse(length.Text);
            g = canvas.CreateGraphics();
            for(int i = 0; i < no_lines; i++)
            {
                drawLine();
            }

        }
        
        private void drawLine() {
            Random randomGen = new Random();
            p.Color = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));

            my_angle += Int32.Parse(angle.Text);
            my_length += Int32.Parse(increment.Text);

            end_x = (int)(start_x + Math.Cos(my_angle * 0.017453292519) * my_length);
            end_y = (int)(start_y + Math.Sin(my_angle * 0.017453292519) * my_length);

            Point[] points = {
                new Point(start_x , start_y),
                new Point(end_x , end_y)
            };
            g.DrawLines(p, points);
                                    
            start_x = end_x;
            start_y = end_y;

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            my_length = Int32.Parse(length.Text);
            my_increment = Int32.Parse(increment.Text);
            my_angle = Int32.Parse(angle.Text);
            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;
            no_lines = Int32.Parse(number_of_lines.Text);
            canvas.Refresh();
        }
    }
}
