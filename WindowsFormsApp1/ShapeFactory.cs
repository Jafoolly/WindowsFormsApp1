using System;

namespace WindowsFormsApp1
{
    class ShapeFactory// design pattern class that is called by othe clases
    {
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToUpper().Trim(); 
            //you could argue that you want a specific word string to create an object but I'm allowing any case combination

            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }

            else if (shapeType.Equals("RECTANGLE"))
                {
                return new Rectangle();
                }

            else
            {
                ////if we get here then what has been passed in is kown so throw an appropriate exception
                System.ArgumentException argsEx = new System.ArgumentException("Error; " + shapeType + " does not exist");
                throw argsEx;
            }
        }


    }
}
