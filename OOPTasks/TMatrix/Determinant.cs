using System;

namespace TMatrix
{
    class Determinant
    {
        internal static double GetDeterminant(double[,] array)
        {
            if (array.GetLength(0) == 1)
            {
                return array[0, 0];
            }

            if (array.GetLength(0) == 2)
            {
                return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
            }

            double sum = 0;
            for (int j = 0; j < array.GetLength(0); j++)
            {
                double[,] arrayWithout1J = GetArrayWithout1J(array, j);
                sum += Math.Pow(-1, 2 + j) * array[0, j] * GetDeterminant(arrayWithout1J);
            }

            return sum;
        }

        private static double[,] GetArrayWithout1J(double[,] array, int indexColumn)
        {
            int arraySize = array.GetLength(0);
            double[,] resultArray = new double[arraySize - 1, arraySize - 1];

            for (int i = 1; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    if (j < indexColumn)
                    {
                        resultArray[i - 1, j] = array[i, j];
                    }
                    else if (j > indexColumn)
                    {
                        resultArray[i - 1, j - 1] = array[i, j];
                    }
                }
            }

            return resultArray;
        }
    }
}
