using System.Drawing;

namespace WindowsFormsApp1
{
    interface ShapesInterface
    {
        // setting rules for classes to call from.
        void set(Color c, params int[] list);
        void draw(Graphics g);
        double calcArea();
        double calcPerimeter();

    }
}
