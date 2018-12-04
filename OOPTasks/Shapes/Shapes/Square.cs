namespace L2Shapes.Shapes
{
    class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public string GetName()
        {
            return "квадрат";
        }

        public override int GetHashCode()
        {
            return SideLength.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            Square square = (Square)obj;
            return square.SideLength == SideLength;
        }

        public override string ToString()
        {
            return "квадрат со стороной " + SideLength;
        }
    }
}
