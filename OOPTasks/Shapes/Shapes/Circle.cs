using System;

namespace L2Shapes.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        private double Diameter => 2 * Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetHeight()
        {
            return Diameter;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetWidth()
        {
            return Diameter;
        }

        public string GetName()
        {
            return "круг";
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
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

            Circle circle = (Circle)obj;

            return Radius == circle.Radius;
        }

        public override string ToString()
        {
            return "круг с радиусом " + Radius;
        }
    }
}
