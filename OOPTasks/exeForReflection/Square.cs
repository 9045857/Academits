namespace exeForReflection
{
    public class Square 
    {
        private double sideLength;

        public double SideLength
        {
            get
            {
                return sideLength;
            }
            set
            {
                sideLength = value;
            }
        }

        public Square(double sideLength)
        {
           this.sideLength = sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetPerimeter()
        {
            return 4 * sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public string GetName()
        {
            return "квадрат";
        }
                
        public override string ToString()
        {
            return "квадрат со стороной " + sideLength;
        }
    }
}
