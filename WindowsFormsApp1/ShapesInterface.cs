using System.Drawing;

namespace WindowsFormsApp1
{
    interface Shapes
    {
        void set(Colour c, params int[] list);
        void draw(Graphics g);
        double calcArea();
        double calcPerimeter();

    }
}
