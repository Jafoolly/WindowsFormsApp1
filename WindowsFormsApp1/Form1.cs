using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        private static Pen activePen;
        ShapeFactory shapeFactory = new ShapeFactory();
        Pen pen = new Pen(Color.Black);
        Graphics g;
        int X = 0;
        int Y = 0;


        private ArrayList shapes = new ArrayList();
        bool penPosition = false;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();

            ShapeFactory factory = new ShapeFactory();
            try
            {
                shapes.Add(factory.getShape("circle"));
                shapes.Add(factory.getShape("rectangle"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid shape: " + e);
            }
            //add some random shapes
            Random rand = new Random(77887);
            for (int i = 0; i < 150; i++)
            {
                int x = rand.Next(Size.Width);
                int y = rand.Next(Size.Height);
                int size = rand.Next(250);

                int red = rand.Next(255);
                int green = rand.Next(255);
                int blue = rand.Next(255);

                Color newColour = Color.FromArgb(128, red, green, blue); //128 is semi transparent

                int shape = rand.Next(2);
                Shape s;
                switch (shape)
                {
                    case 0:
                        s = factory.getShape("circle");
                        s.set(newColour, x, y, size);
                        shapes.Add(s);// new Circle(newColour, x, y, size));

                        break;
                    case 1:
                        s = factory.getShape("rectangle");
                        s.set(newColour, x, y, size, size);
                        shapes.Add(s);
                        break;

                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            var input = textBox1.Text;
            input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (input.Contains("PenUp"))
            {
                pen.Color = Color.White;
            }
            else if (input.Contains("PenDown"))
            {
                pen.Color = Color.Black;
            }

            if (input.Contains("Circle"))
            {
                try
                {
                    string[] moveCircle = input.Split();
                    string radius = moveCircle[1];

                    int rad = int.Parse(radius);

                    Console.WriteLine(radius);

                    g.DrawEllipse(pen, X, Y, rad, rad);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error! The input should look like this Circle 50");
                }
                
            }

            if (input.Contains("Rectangle"))
            {
                try
                {
                    var moveRect = input.Split();
                    var width = moveRect[1];
                    var height = moveRect[2];

                    var widf = int.Parse(width);
                    var heit = int.Parse(height);

                    Console.WriteLine(width );
                    Console.WriteLine(height);

                    g.DrawRectangle(pen, X, Y, widf, heit);
                }
                 catch (Exception)
                {
                    MessageBox.Show("Error! The input should look like this Rectangle 0 0");
                }
            }

            if (input.Contains("Move"))
            {
                string[] movement = input.Split();
                string x = movement[1];
                string y = movement[2];

                int numX = int.Parse(x);
                int numY = int.Parse(y);

                Console.WriteLine(x);
                Console.WriteLine(y);

                g.DrawLine(pen, X, Y, numX, numY);
                Y = numX;
                X = numY;
            }

            for (int i = 0; i < shapes.Count; i++)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void f(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (penPosition = false) ;
            {

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
