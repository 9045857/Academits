namespace L2Shapes.Shapes
{
    class Rectangle : IShape
    {
        //Должен иметь конструктор, принимающий длины двух сторон

        public double Side1Length { get; set; }
        public double Side2Length { get; set; }

        public Rectangle(double side1Length, double side2Length)
        {
            Side1Length = side1Length;
            Side2Length = side2Length;
        }

        public double GetArea()
        {
            return Side1Length * Side2Length;
        }

        public double GetHeight()
        {
            return Side2Length;
        }

        public double GetPerimeter()
        {
            return 2 * (Side1Length + Side2Length);
        }

        public double GetWidth()
        {
            return Side1Length;
        }

        public string GetName()
        {
            return "прямоугольник";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Side1Length.GetHashCode();
            hash = prime * hash + Side2Length.GetHashCode();

            return hash;
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

            Rectangle rectangle = (Rectangle)obj;

            return Side1Length == rectangle.Side1Length && Side2Length == rectangle.Side2Length;
        }

        public override string ToString()
        {
            return "прямоугольник " + Side1Length + " х " + Side2Length;
        }
    }
}
