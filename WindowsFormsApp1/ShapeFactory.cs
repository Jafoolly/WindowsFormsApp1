using System;

namespace WindowsFormsApp1
{
    class ShapeFactory
    {
        public ShapeFactory getShape(String shapeType)
        {
            shapeType = shapeType.ToUpper().Trim();

            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }
        }





    }
}
