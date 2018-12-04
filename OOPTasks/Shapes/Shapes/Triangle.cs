using System;

namespace L2Shapes.Shapes
{
    class Triangle : IShape
    {
        //Должен иметь конструктор, принимающий x1, y1, x2, y2, x3, y3 – шесть координат.
        //В качестве ширины возвращать max(x1, x2, x3) – min(x1, x2, x3)
        //В качестве высоты возвращать max(y1, y2, y3) – min(y1, y2, y3)

        public double X1 { get; set; }
        public double Y1 { get; set; }

        public double X2 { get; set; }
        public double Y2 { get; set; }

        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;

            X2 = x2;
            Y2 = y2;

            X3 = x3;
            Y3 = y3;
        }

        private static double GetRangeLength(double number1, double number2, double number3)
        {
            return Math.Max(Math.Max(number1, number2), number3) - Math.Min(Math.Min(number1, number2), number3);
        }

        private static double GetTwoNumbersSquaredDifference(double number1, double number2)
        {
            return Math.Pow(number1 - number2, 2);
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(GetTwoNumbersSquaredDifference(x1, x2) + GetTwoNumbersSquaredDifference(y1, y2));
        }

        public double GetArea()
        {
            return Math.Abs((X1 - X3) * (Y2 - Y3) - (Y1 - Y3) * (X2 - X3)) / 2;
        }

        public double GetHeight()
        {
            return GetRangeLength(Y1, Y2, Y3);
        }

        public double GetPerimeter()
        {
            return GetSideLength(X1, Y1, X2, Y2) + GetSideLength(X2, Y2, X3, Y3) + GetSideLength(X1, Y1, X3, Y3);
        }

        public double GetWidth()
        {
            return GetRangeLength(X1, X2, X3);
        }

        public string GetName()
        {
            return "треугольник";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            double[] coordinates = new double[] { X1, Y1, X2, Y2, X3, Y3 };

            foreach (double coordinate in coordinates)
            {
                hash = prime * hash + coordinate.GetHashCode();
            }

            return hash;
        }

        private bool IsObjCoordinatesLikeThis(Triangle triangle)
        {
            return triangle.X1 == X1 && triangle.X2 == X2 && triangle.X3 == X3 && triangle.Y1 == Y1 && triangle.Y2 == Y2 && triangle.Y3 == Y3;
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

            return IsObjCoordinatesLikeThis((Triangle)obj);
        }

        public override string ToString()
        {
            return "треугольник [(" + X1 + ", " + Y1 + "), (" + X2 + ", " + Y2 + "), (" + X3 + ", " + Y3 + ")]";
        }
    }
}
