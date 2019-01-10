using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class MyForm : Form 
    { 
        ShapeFactory shapeFactory = new ShapeFactory(); // implents shapefactory class
        Pen MyPen = new Pen(Color.Black);
        Graphics graphics;
        bool PenStatus = true;// Setting varable for PenUp PenDown
        int X = 0; // Setting X value for move
        int Y = 0; // Setting Y value for move


        private ArrayList shapes = new ArrayList();
        

        public MyForm()

        {   //used to assign values to labels, textbox, Buttons etc
            InitializeComponent();//is a function for initializing the values of the form. 
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
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            var input = textBox1.Text;
            input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);// splits input into strings, then follow code...

            

            if (PenStatus == true)// if PenUP then run then allow this code...
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

               else if (input.Contains("Repeat circle"))
                {
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
                                s = shapeFactory.getShape("circle");
                                s.set(newColour, x, y, size);
                                shapes.Add(s); // new Circle(newColour, x, y, size));

                                graphics.DrawEllipse(MyPen, X, Y, size, size); //MyPen being pen colour black, x and y to draw circle from.

                                break;


                        }
                    }
                }

                else if (input.Contains("Rectangle"))// if input is rectangle then draw Rectangle
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
                    catch (Exception)//If input does not meet requirements then catch the string and display message box.
                    {
                        MessageBox.Show("Error! The input should look like this Rectangle 0 0");
                    }
                }
                else if (input.Contains("Repeat rectangle"))
                {
                    //add some random shapes
                    Random rand = new Random(77887);
                    for (int i = 0; i < 50; i++)
                    {
                        int x = rand.Next(Size.Width);
                        int y = rand.Next(Size.Height);
                        int size = rand.Next(200);//size of increase of rectangle

                        int red = rand.Next(255);
                        int green = rand.Next(255);
                        int blue = rand.Next(255);

                        Color newColour = Color.FromArgb(128, red, green, blue); //128 is semi transparent

                        int shape = rand.Next(2);
                        Shape s;
                        switch (shape)
                        {
                            case 0:
                                s = shapeFactory.getShape("rectangle");
                                s.set(newColour, x, y, size, size);
                                shapes.Add(s);
                                graphics.DrawRectangle(MyPen, X, Y, size, size/2);
                                break;


                        }
                    }
                }

                else if (input.Contains("Random"))// generates a set of random shapes
                {
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
                                s = shapeFactory.getShape("circle");
                                s.set(newColour, x, y, size);
                                shapes.Add(s);// new Circle(newColour, x, y, size));
                           
                                graphics.DrawEllipse(MyPen, X, Y, size,size);

                                break;
                            case 1:
                                s = shapeFactory.getShape("rectangle");
                                s.set(newColour, x, y, size, size);
                                shapes.Add(s);
                                graphics.DrawRectangle(MyPen, X, Y, size, size);
                                break;

                        }
                    }
                }

                else if (input.Contains("Polygon"))
                {

                        // Create pen.
                        Pen blackPen = new Pen(Color.Black, 3); //sets pen to draw black

                        // Create points that define polygon.
                        PointF point1 = new PointF(50.0F, 50.0F);
                        PointF point2 = new PointF(100.0F, 25.0F);
                        PointF point3 = new PointF(200.0F, 5.0F);
                        PointF point4 = new PointF(250.0F, 50.0F);
                        PointF point5 = new PointF(300.0F, 100.0F);
                        PointF point6 = new PointF(350.0F, 200.0F);
                        PointF point7 = new PointF(250.0F, 250.0F);
                        PointF[] polygonPoints =
                                 {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

                        // Draw a polygon to canvas.
                        graphics.DrawPolygon(blackPen, polygonPoints);
                    
                }

                else if (input.Contains("Triangle"))
                {

                    // Create pen.
                    Pen blackPen = new Pen(Color.Black, 3);

                    // Create points that define each point of the triangle.
                    PointF point1 = new PointF(50.0F, 50.0F);
                    PointF point2 = new PointF(100.0F, 25.0F);
                    PointF point3 = new PointF(200.0F, 50.0F);
                    PointF[] trianglePoints =
                             {
                 point1,
                 point2,
                 point3
             };

                    // Draw Triangle to canvas.
                    graphics.DrawPolygon(blackPen, trianglePoints);

                }

                else if (input.Contains("Move"))// allows pen to move when pen status is up/ declared at the start.
                {
                    string[] move = input.Split();// splits input command into a string
                    string x = move[1]; //registers input co
                    string y = move[2];

                    int x2 = int.Parse(x);
                    int y2 = int.Parse(y);

                    graphics.DrawLine(MyPen, X, Y, x2, y2);
                    Y = x2; // vaules for x and y
                    X = y2;
                }
            }
            else if (PenStatus == false)// if PenDown the runw code..
            {
                if (input.Contains("Move"))// Move command when Pen is down so can move with out drawing on canvas.
                {
                    string[] move = input.Split();
                    string x = move[1];
                    string y = move[2];

                    int x2 = int.Parse(x);
                    int y2 = int.Parse(y);

                    Y = x2;
                    X = y2;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)//Buuton to clear Canvas
        {
            graphics.Clear(Color.White);
        }

        private void button3_Click(object sender, EventArgs e) //Button to clear Terminal
        {
            textBox1.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e) // Button for PenDown
        {
            PenStatus = true;
            MessageBox.Show("PEN IS DOWN");
        }


        private void button5_Click(object sender, EventArgs e) // Button for PenUP
        {
            PenStatus = false;
            MessageBox.Show("PEN IS UP");
        }
        

       

        private void Save_Click(object sender, EventArgs e) //Label for Save 
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",//types of files it can be saved as
                FilterIndex = 2,
                RestoreDirectory = true
            };

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
            // Displays an OpenFileDialog so the user can select a file.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog

            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                Title = "Select a File"
            };

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                    System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show("File Loaded",sr.ReadToEnd());
                sr.Close();
            }
        }
    }
}
