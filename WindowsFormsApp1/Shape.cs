using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class Shape : ShapesInterface
    {
        protected Color colour;
        protected int x, y;
        public Shape()
        {
            x = y = 100;
        }

        public Shape( int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }
    public abstract void draw(Graphics g);
    public abstract double calcArea();
    public abstract double calcPerimeter();

    public virtual void set(Color colour, params int[] list)
    {
        this.colour = colour;
        this.x = list[0];
        this.y = list[1];
    }

    public override string ToString()
    {
        return base.ToString() + "   " + this.x + "," + this.y + ":";
    }
    }
}
