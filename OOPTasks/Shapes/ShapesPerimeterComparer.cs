using System.Collections.Generic;

namespace L2Shapes
{
    class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetPerimeter() < shape2.GetPerimeter())
            {
                return 1;
            }
            else if (shape1.GetPerimeter() > shape2.GetPerimeter())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
