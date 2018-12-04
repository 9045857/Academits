using System.Collections.Generic;

namespace L2Shapes.ShapesComparers
{
    class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}
