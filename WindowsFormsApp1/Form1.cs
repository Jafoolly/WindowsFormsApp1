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
              
                    string[] moveCircle = input.Split();
                    string radius = moveCircle[1];

                    int rad = int.Parse(radius);

                    Console.WriteLine(radius);

                    g.DrawEllipse(pen, 0, 0, rad, rad);
                
                
            }
            if (input.Contains("move"))
            {
                string[] movement = input.Split();
                string x = movement[1];
                string y = movement[2];

                int numX = int.Parse(x);
                int numY = int.Parse(y);

                Console.WriteLine(x);
                Console.WriteLine(y);
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
