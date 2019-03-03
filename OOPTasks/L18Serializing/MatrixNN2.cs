using System;
using System.Text;

namespace L18Serializing
{
    //•Создать класс симметричной двумерной матрицы целых чисел размера NxN – чтобы имел поле - двумерный массив
    //•Написать метод, который заполняет матрицу одного такого объекта
    //•Сделать данный класс сериализуемым, записать результат файл
    //•Затем, воспользоваться фактом, что матрица симметричная, и переопределить механизм сериализации, 
    //чтобы в поток записывалась только половина матрицы
    //•Сериализовать и десериализовать объект в файл, используя эти методы
    //•Сравнить размер файла

    [Serializable]
    class MatrixNN2
    {
        private double[,] matrix;

        public MatrixNN2()
        {
        }

        public MatrixNN2(double[,] matrix)
        {
            int matrixSize = matrix.GetLength(0);
            this.matrix = new double[matrixSize, matrixSize];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            int matrixSize = matrix.GetLength(0);

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result.Append(matrix[i, j]);
                    result.Append(" ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
