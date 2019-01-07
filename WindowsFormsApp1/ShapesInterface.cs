using System.Drawing;

namespace WindowsFormsApp1
{
    interface ShapesInterface
    {
        void set(Color c, params int[] list);
        void draw(Graphics g);
        double calcArea();
        double calcPerimeter();

    }
}
