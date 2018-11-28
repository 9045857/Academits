using System;

namespace L1Range
{
    class DoubleComparison
    {
        private const double epsilon = 1.0e-10;

        public static bool IsAMoreB(double number1, double number2)
        {
            return (number1 - number2) > epsilon;
        }

        public static bool IsAMoreOrEqualB(double number1, double number2)
        {
            return (number1 - number2) >= -epsilon;
        }
    }
}
