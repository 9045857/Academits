using L2Vector;
using System;
using System.Text;

namespace TMatrix
{
    class Matrix
    {
        //Реализовать класс матрицы Matrix с использованием класса Vector – хранить строки как массив векторов
        //1.Конструкторы:
        //a.Matrix(m, n) – матрица нулей размера mxn
        //b.Matrix(Matrix) – конструктор копирования
        //c.Matrix(double[][]) – из двумерного массива
        //d.Matrix(Vector[]) – из массива векторов-строк

        private Vector[] vectors;

        //a.Matrix(m, n) – матрица нулей размера mxn
        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new Exception(string.Format(MatrixWarningStrings.MatrixRowsCountAndColumnsCountСonstructorErrorMessage, rowsCount, columnsCount));
            }

            vectors = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                vectors[i] = new Vector(columnsCount);
            }
        }

        //b.Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            string methodName = "Matrix(matrix)";
            CheckMatrixNullErrors(methodName, matrix);

            vectors = new Vector[matrix.vectors.Length];

            for (int i = 0; i < matrix.vectors.Length; i++)
            {
                vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        private static string GetMatrixErrorsStringBuilder(string methodName, string errorString)
        {
            StringBuilder errorMessageStringBuilder = new StringBuilder();
            errorMessageStringBuilder.Append(methodName);
            errorMessageStringBuilder.Append(": ");
            errorMessageStringBuilder.Append(errorString);

            return errorMessageStringBuilder.ToString();
        }

        private static void CheckMatrixNullErrors(string methodName, Matrix matrix)
        {
            if (matrix == null)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixMatrixNullСonstructorErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
            if (matrix.GetColumnsCount() == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixMatrixColunmsCount0СonstructorErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
            if (matrix.GetRowsCount() == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixMatrixRowsCount0СonstructorErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        //Конструктор вне задания Matrix(double[,])
        public Matrix(double[,] array)
        {
            string methodName = "Конструктор Matrix(double[,] array)";
            Check2DArrayNullOrRowsOrColumnsCount0Errors(methodName, array);

            int rowsCount = array.GetLength(0);
            int columnsCount = array.GetLength(1);

            vectors = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                vectors[i] = new Vector(columnsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    vectors[i].SetCoordinate(j, array[i, j]);
                }
            }
        }

        private static void Check2DArrayNullOrRowsOrColumnsCount0Errors(string methodName, double[,] array)
        {
            if (array == null)
            {
                string errorString = string.Format(MatrixWarningStrings.Array2DimentionNullErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
            if (array.GetLength(0) == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.Array2DimentionRowsCount0ErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
            if (array.GetLength(1) == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.Array2DimentionColumnsCount0ErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        //c.Matrix(double[][]) – из двумерного массива
        public Matrix(double[][] array)
        {
            string methodName = "Конструктор Matrix(double[][] array)";
            CheckNullOrArrays0AraysArrayErrors(methodName, array);
            CheckArraysDifferentLengthsAraysArrayErrors(methodName, array);

            vectors = new Vector[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                vectors[i] = new Vector(array[i]);
            }
        }

        private static void CheckArraysDifferentLengthsAraysArrayErrors(string methodName, double[][] array)
        {
            if (array.Length >= 2)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i].Length != array[i - 1].Length)
                    {
                        string errorString = string.Format(MatrixWarningStrings.ArraysDifferentLengthsAraysArrayErrorsMessage);
                        throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
                    }
                }
            }
        }

        private static void CheckNullOrArrays0AraysArrayErrors(string methodName, double[][] array)
        {
            if (array == null)
            {
                string errorString = string.Format(MatrixWarningStrings.ArraysArrayNullErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
            if (array.Rank == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.ArraysArrayCount0ErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        //d.Matrix(Vector[]) – из массива векторов-строк
        public Matrix(Vector[] vectorsArray)
        {
            string methodName = "Matrix(Vector[] vectorsArray)";
            CheckVectorsArrayErrors(methodName, vectorsArray);

            vectors = new Vector[vectorsArray.Length];

            for (int i = 0; i < vectorsArray.Length; i++)
            {
                vectors[i] = new Vector(vectorsArray[i]);
            }
        }

        private static void CheckVectorsArrayErrors(string methodName, Vector[] vectorsArray)
        {
            if (vectorsArray == null)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArrayNullСonstructorErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
            if (vectorsArray.Length == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArray0ConstructorErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        //2.Методы:
        //a.Получение размеров матрицы
        //b.Получение и задание вектора-строки по индексу
        //c.Получение вектора-столбца по индексу
        //d.Транспонирование матрицы
        //e.Умножение на скаляр
        //f.Вычисление определителя матрицы
        //g.toString определить так, чтобы результат получался в таком виде: { { 1, 2 }, { 2, 3 } }
        //h.умножение матрицы на вектор
        //i.Сложение матриц
        //j.Вычитание матриц

        //a.Получение размеров матрицы
        public int GetRowsCount() //эквивалентно количеству векторов
        {
            return vectors.Length;
        }

        public int GetColumnsCount() //эквивалентно количеству координат в векторе
        {
            return vectors[0].GetSize();
        }

        //b.Получение и задание вектора-строки по индексу
        public Vector GetRowVector(int index)
        {
            string methodName = "GetRowVector(int index)";
            CheckNegativeOrNullIndexErrors(methodName, index);

            return vectors[index];
        }

        private static void CheckNegativeOrNullIndexErrors(string methodName, int index)
        {
            if (index <= 0)
            {
                string errorString = string.Format(MatrixWarningStrings.IndexNegativeOrNullErrorsMessage, index);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        public void SetRowVector(int index, Vector vector)
        {
            string methodName = "SetRowVector(int index, Vector vector)";
            CheckNegativeOrNullIndexErrors(methodName, index);
            CheckMatrixIndexMoreMaxRowsCountErrors(methodName, this, index);
            CheckVectorsNullErrors(methodName, vector);

            vectors[index] = new Vector(vector); //был бы метод копирования векторов, сделал бы через него. без него делаю через конструктор, можно ли так?           
        }

        private static void CheckMatrixIndexMoreMaxRowsCountErrors(string methodName, Matrix matrix, int index)
        {
            int rowsCount = matrix.GetRowsCount();

            if (index > rowsCount)
            {
                string errorString = string.Format(MatrixWarningStrings.IndexMoreMaxRowsCountErrorsMessage, index, rowsCount);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        private static void CheckIndexMoreMaxColumnsCountErrors(string methodName, Matrix matrix,int index)
        {
            int columnsCount = matrix.GetColumnsCount();

            if (index > columnsCount)
            {
                string errorString = string.Format(MatrixWarningStrings.IndexMoreMaxColumnsCountErrorsMessage, index, columnsCount);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        private static void CheckVectorsNullErrors(string methodName, Vector vector)
        {
            if (vector == null)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArrayNullСonstructorErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }

            if (vector.GetLength() == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArray0ConstructorErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        //c.Получение вектора-столбца по индексу
        public Vector GetColumnVector(int index)
        {
            string methodName = "GetColumnVector(int index)";
            CheckNegativeOrNullIndexErrors(methodName, index);

            int vectorCoordinatesCount = GetRowsCount();

            Vector vector = new Vector(vectorCoordinatesCount);

            for (int i = 0; i < vectorCoordinatesCount; i++)
            {
                vector.SetCoordinate(i, vectors[i].GetCoordinate(index));
            }

            return vector;
        }

        //d.Транспонирование матрицы
        public Matrix Transpose()
        {
            int columnsCount = GetColumnsCount();
            int rowsCount = GetRowsCount();

            Matrix transposedMatrix = new Matrix(columnsCount, rowsCount);

            for (int i = 0; i < columnsCount; i++)
            {
                transposedMatrix.SetRowVector(i, GetColumnVector(i));
            }

            return transposedMatrix;
        }

        //e.Умножение на скаляр
        public Matrix MultiplyOnScalar(double multiplier)
        {
            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    double multipliedCoordinate = multiplier * vectors[i].GetCoordinate(j);
                    vectors[i].SetCoordinate(j, multipliedCoordinate);
                }
            }

            return this;
        }

        //f.Вычисление определителя матрицы
        public double GetDeterminant()
        {
            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            double[,] matrix = new double[rowsCount, columnsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    matrix[i, j] = vectors[i].GetCoordinate(j);
                }
            }

            return Determinant.GetDeterminant(matrix);
        }

        //g.toString определить так, чтобы результат получался в таком виде: { { 1, 2 }, { 2, 3 } }
        public override string ToString()
        {
            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            StringBuilder matrixStringBilder = new StringBuilder();
            matrixStringBilder.Append("{ ");

            int lastIndex = 1;

            for (int i = 0; i < rowsCount - lastIndex; i++)
            {
                matrixStringBilder.Append("{");
                for (int j = 0; j < columnsCount - lastIndex; j++)
                {
                    matrixStringBilder.Append(vectors[i].GetCoordinate(j));
                    matrixStringBilder.Append(", ");
                }
                matrixStringBilder.Append(vectors[i].GetCoordinate(columnsCount - lastIndex));
                matrixStringBilder.Append("}, ");
            }

            matrixStringBilder.Append("{");
            for (int j = 0; j < columnsCount - lastIndex; j++)
            {
                matrixStringBilder.Append(vectors[rowsCount - lastIndex].GetCoordinate(j));
                matrixStringBilder.Append(", ");
            }
            matrixStringBilder.Append(vectors[rowsCount - lastIndex].GetCoordinate(columnsCount - lastIndex));
            matrixStringBilder.Append("} }");

            return matrixStringBilder.ToString();
        }

        //h.умножение матрицы на вектор        
        public Vector MultiplyByVector(Vector vector)
        {
            string methodName = "MultiplyByVector(Vector vector)";

            CheckVectorsNullErrors(methodName, vector);
            CheckVectorLengthForMultiplyByMatrixErrors(methodName, this, vector);

            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            Vector multiplicationResultVector = new Vector(rowsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                double tmpCoordinate = 0;
                for (int j = 0; j < columnsCount; j++)
                {
                    tmpCoordinate += GetMatrixElement(this, i, j) * vector.GetCoordinate(j);
                }

                multiplicationResultVector.SetCoordinate(i, tmpCoordinate);
            }

            return multiplicationResultVector;
        }

        private static void CheckVectorLengthForMultiplyByMatrixErrors(string methodName, Matrix matrix, Vector vector)
        {
            int matrixColumnsCount = matrix.GetColumnsCount();
            int vectorCoordinatesCount = vector.GetSize();

            if (matrixColumnsCount != vectorCoordinatesCount)
            {
                string errorString = string.Format(MatrixWarningStrings.VectorAndMatrixDifferentSizesWhenMultiplyErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        private static double GetMatrixElement(Matrix matrix, int rowIndex, int columnIndex)
        {
            return matrix.GetRowVector(rowIndex).GetCoordinate(columnIndex);
        }

        //i.Сложение матриц
        public Matrix AddMatrix(Matrix addedMatrix)
        {
                        string methodName = "AddMatrix(Matrix addedMatrix)";
            CheckMatrixNullErrors(methodName, addedMatrix);
            CheckMatricesEqualSizesErrors(methodName, this, addedMatrix);

            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    double newCoordinate = vectors[i].GetCoordinate(j) + addedMatrix.vectors[i].GetCoordinate(j);
                    vectors[i].SetCoordinate(j, newCoordinate);
                }
            }

            return this;
        }

        private static void CheckMatricesEqualSizesErrors(string methodName, Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount() || matrix1.GetRowsCount() != matrix2.GetRowsCount())
            {
                string errorString = string.Format(MatrixWarningStrings.MatricesDifferentSizesErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }

        //j.Вычитание матриц
        public Matrix SubtractMatrix(Matrix subtrahendMatrix)
        {
            string methodName = "SubtractMatrix(Matrix subtrahendMatrix)";
            CheckMatrixNullErrors(methodName, subtrahendMatrix);
            CheckMatricesEqualSizesErrors(methodName, this, subtrahendMatrix);

            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    double newCoordinate = vectors[i].GetCoordinate(j) - subtrahendMatrix.vectors[i].GetCoordinate(j);
                    vectors[i].SetCoordinate(j, newCoordinate);
                }
            }

            return this;
        }

        //3.Статические методы:
        //a.Сложение матриц
        //b.Вычитание матриц
        //c.Умножение матриц

        //a.Сложение матриц
        public static Matrix GetAddition(Matrix matrix1, Matrix matrix2)
        {
            string methodName = "GetAddition(Matrix matrix1, Matrix matrix2)";
            CheckMatrixNullErrors(methodName, matrix1);
            CheckMatrixNullErrors(methodName, matrix2);
            CheckMatricesEqualSizesErrors(methodName, matrix1, matrix2);

            int rowsCount = matrix1.GetRowsCount();
            int columnsCount = matrix1.GetColumnsCount();

            Matrix sumMatrix = new Matrix(rowsCount, columnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    double newCoordinate = matrix1.vectors[i].GetCoordinate(j) + matrix2.vectors[i].GetCoordinate(j);
                    sumMatrix.vectors[i].SetCoordinate(j, newCoordinate);
                }
            }

            return sumMatrix;
        }

        //b.Вычитание матриц
        public static Matrix GetSubtraction(Matrix minuendЬatrixMatrix, Matrix subtrahendMatrix)
        {
            string methodName = "GetSubtraction(Matrix minuendЬatrixMatrix, Matrix subtrahendMatrix)";
            CheckMatrixNullErrors(methodName, minuendЬatrixMatrix);
            CheckMatrixNullErrors(methodName, subtrahendMatrix);
            CheckMatricesEqualSizesErrors(methodName, minuendЬatrixMatrix, subtrahendMatrix);

            int rowsCount = minuendЬatrixMatrix.GetRowsCount();
            int columnsCount = minuendЬatrixMatrix.GetColumnsCount();

            Matrix differenceMatrix = new Matrix(rowsCount, columnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    double newCoordinate = minuendЬatrixMatrix.vectors[i].GetCoordinate(j) + subtrahendMatrix.vectors[i].GetCoordinate(j);
                    differenceMatrix.vectors[i].SetCoordinate(j, newCoordinate);
                }
            }

            return differenceMatrix;
        }

        //c.Умножение матриц
        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            string methodName = "GetMultiplication(Matrix matrix1, Matrix matrix2)";
            CheckMatrixNullErrors(methodName, matrix1);
            CheckMatrixNullErrors(methodName, matrix2);
            CheckMatricesSizesForMultiplyErrors(methodName, matrix1, matrix2);

            int rowsCount = matrix1.GetRowsCount();
            int columnsCount = matrix1.GetColumnsCount();

            Matrix productMatrix = new Matrix(rowsCount, columnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    double newCoordinate = Vector.GetScalarProduct(matrix1.vectors[i], matrix2.GetColumnVector(j));
                    productMatrix.vectors[i].SetCoordinate(j, newCoordinate);
                }
            }

            return productMatrix;
        }

         private static void CheckMatricesSizesForMultiplyErrors(string methodName, Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetRowsCount() || matrix1.GetRowsCount() != matrix2.GetColumnsCount())
            {
                string errorString = string.Format(MatrixWarningStrings.MatricesSizesForMultiplyErrorMessage);
                throw new Exception(GetMatrixErrorsStringBuilder(methodName, errorString));
            }
        }
    }
}
