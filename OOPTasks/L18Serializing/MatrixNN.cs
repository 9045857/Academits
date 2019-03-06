using System;
using System.Runtime.Serialization;
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
    class MatrixNN : ISerializable
    {
        private double[,] matrix;

        public MatrixNN()
        {
        }

        public MatrixNN(double[,] matrix)
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

        protected MatrixNN(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException(nameof(info));
            }

            int matrixSize = (int)info.GetValue("matrixSize", typeof(int));

            matrix = new double[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                string key = i + "," + i;
                matrix[i, i] = (double)info.GetValue(key, typeof(double));
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    string key = i + "," + j;
                    matrix[i, j] = (double)info.GetValue(key, typeof(double));

                    matrix[j, i] = matrix[i, j];
                }
            }
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException(nameof(info));
            }

            int matrixSize = matrix.GetLength(0);

            info.AddValue("matrixSize", matrixSize);

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    string key = i + "," + j;
                    info.AddValue(key, matrix[i, j]);
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
