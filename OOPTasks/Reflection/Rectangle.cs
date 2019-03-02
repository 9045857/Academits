using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Rectangle
    {
        private double side1Length;
        private double side2Length;

        public Rectangle(double length, double width)
        {
            side1Length = length;
            side2Length = width;
        }

        public double Length
        {
            get
            {
                return side1Length;
            }
            set
            {
                side1Length = value;
            }
        }

        public double Width
        {
            get
            {
                return side2Length;
            }
            set
            {
                side2Length = value;
            }
        }

        public double GetPerimeter()
        {
            return 2 * (side1Length + side2Length);
        }

        public double GetArea()
        {
            return side1Length * side2Length;
        }

        public string GetName()
        {
            return "прямоугольник";
        }

        public override string ToString()
        {
            return "прямоугольник " + side1Length + " х " + side2Length;
        }
    }
}
