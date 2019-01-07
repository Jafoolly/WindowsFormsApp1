using System;

namespace WindowsFormsApp1
{
    class ShapeFactory
    {
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToUpper().Trim();

            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }

            else if (shapeType.Equals("RECTANGLE"))
                {
                return new Rectangle();
                }

           // else if (shapeType.Equals("TRIANGLE "))
          //  {
                //return new Triangle();
            //}
            else
            {
                System.ArgumentException argsEx = new System.ArgumentException("Error; " + shapeType + " does not exist");
                throw argsEx;
            }
        }





    }
}
