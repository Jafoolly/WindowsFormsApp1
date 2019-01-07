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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private ArrayList shapes = new ArrayList();
        private static Pen activepen;

        bool penPosition = false;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();

            ShapeFactory factory = new ShapeFactory();
            try
            {
                shapes.add(factory.getShape("circle"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid shape: " + e);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
           // if user enters rectangle then
               // call rectangle class
            // draw a rectangle
           // if user doesnt call rectangle then move on to next line 
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.Red);
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

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
