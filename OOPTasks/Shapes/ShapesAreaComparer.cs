using System.Collections.Generic;

namespace L2Shapes
{
    class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetArea() < shape2.GetArea())
            {
                return 1;
            }
            else if (shape1.GetArea() > shape2.GetArea())
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
