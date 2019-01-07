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
    public partial class MyForm : Form
    { 
        ShapeFactory shapeFactory = new ShapeFactory();
        Pen MyPen = new Pen(Color.Black);
        Graphics graphics;
        bool PenStatus = true;
        int X = 0;
        int Y = 0;


        private ArrayList shapes = new ArrayList();
        

        public MyForm()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();

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

            /*
             * Pen statements need finishing
             */

            if (PenStatus == true)
            {

                if (input.Contains("Circle"))
                {
                    try
                    {
                        string[] moveCircle = input.Split();
                        string radius = moveCircle[1];

                        int Rad = int.Parse(radius);

                        graphics.DrawEllipse(MyPen, X, Y, Rad, Rad);
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

                        var W = int.Parse(width);
                        var H = int.Parse(height);

                        graphics.DrawRectangle(MyPen, X, Y, W, H);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error! The input should look like this Rectangle 0 0");
                    }
                }

                if (input.Contains("Polygon"))
                {

                        // Create pen.
                        Pen blackPen = new Pen(Color.Black, 3);

                        // Create points that define polygon.
                        PointF point1 = new PointF(50.0F, 50.0F);
                        PointF point2 = new PointF(100.0F, 25.0F);
                        PointF point3 = new PointF(200.0F, 5.0F);
                        PointF point4 = new PointF(250.0F, 50.0F);
                        PointF point5 = new PointF(300.0F, 100.0F);
                        PointF point6 = new PointF(350.0F, 200.0F);
                        PointF point7 = new PointF(250.0F, 250.0F);
                        PointF[] curvePoints =
                                 {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

                        // Draw polygon curve to screen.
                        graphics.DrawPolygon(blackPen, curvePoints);
                    
                }


                if (input.Contains("Move"))
                {
                    string[] movement = input.Split();
                    string x = movement[1];
                    string y = movement[2];

                    int x2 = int.Parse(x);
                    int y2 = int.Parse(y);

                    graphics.DrawLine(MyPen, X, Y, x2, y2);
                    Y = x2;
                    X = y2;
                }
            }
            else if (PenStatus == false)
            {
                if (input.Contains("Move"))
                {
                    string[] movement = input.Split();
                    string x = movement[1];
                    string y = movement[2];

                    int x2 = int.Parse(x);
                    int y2 = int.Parse(y);

                    Y = x2;
                    X = y2;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PenStatus = true;
            MessageBox.Show("PEN IS DOWN");
        }


        private void button5_Click(object sender, EventArgs e)
        {
            PenStatus = false;
            MessageBox.Show("PEN IS UP");
        }
        

       

        private void Save_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
    }
}
