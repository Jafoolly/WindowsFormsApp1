using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Graphics g;
       

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
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

        private void c(object sender, PaintEventArgs e)
        {

        }

        private void f(object sender, EventArgs e)
        {

        }
    }
}
