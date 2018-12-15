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

        private Vector[] vectorsRows;

        //a.Matrix(m, n) – матрица нулей размера mxn
        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new Exception(string.Format(MatrixWarningStrings.MatrixRowsCountAndColumnsCountСonstructorErrorMessage, rowsCount, columnsCount));
            }

            vectorsRows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                vectorsRows[i] = new Vector(columnsCount);
            }
        }

        //b.Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            string methodName = "Matrix(matrix)";
            CheckMatrixNullErrors(methodName, matrix);

            vectorsRows = new Vector[matrix.vectorsRows.Length];

            for (int i = 0; i < matrix.vectorsRows.Length; i++)
            {
                vectorsRows[i] = new Vector(matrix.vectorsRows[i]);
            }
        }

        private static string GetErrorDescription(string methodName, string errorString)
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
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
            if (matrix.GetColumnsCount() == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixMatrixColunmsCount0СonstructorErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
            if (matrix.GetRowsCount() == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixMatrixRowsCount0СonstructorErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
        }

        //Конструктор вне задания Matrix(double[,])
        public Matrix(double[,] array)
        {
            string methodName = "Конструктор Matrix(double[,] array)";
            Check2DArrayNullOrRowsOrColumnsCount0Errors(methodName, array);

            int rowsCount = array.GetLength(0);
            int columnsCount = array.GetLength(1);

            vectorsRows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                vectorsRows[i] = new Vector(columnsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    vectorsRows[i].SetCoordinate(j, array[i, j]);
                }
            }
        }

        private static void Check2DArrayNullOrRowsOrColumnsCount0Errors(string methodName, double[,] array)
        {
            if (array == null)
            {
                string errorString = string.Format(MatrixWarningStrings.Array2DimentionNullErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
            if (array.GetLength(0) == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.Array2DimentionRowsCount0ErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
            if (array.GetLength(1) == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.Array2DimentionColumnsCount0ErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
        }

        // c.Matrix(double[][]) – из двумерного массива
        public Matrix(double[][] arraysArray)
        {
            string methodName = "Конструктор Matrix(double[][] array)";
            CheckNullOrArrays0ArraysArrayErrors(methodName, arraysArray);

            int rowsCount = arraysArray.Length;
            int columnsCount = GetMaxArraysArrayLength(arraysArray);

            vectorsRows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                Array.Resize(ref arraysArray[i], columnsCount);
                vectorsRows[i] = new Vector(arraysArray[i]);
            }
        }

        private static int GetMaxArraysArrayLength(double[][] arraysArray)
        {
            int maxArrayLength = 0;

            foreach (double[] array in arraysArray)
            {
                if (array.Length > maxArrayLength)
                {
                    maxArrayLength = array.Length;
                }
            }

            return maxArrayLength;
        }

        private static void CheckNullOrArrays0ArraysArrayErrors(string methodName, double[][] array)
        {
            if (array == null)
            {
                string errorString = string.Format(MatrixWarningStrings.ArraysArrayNullErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
            if (array.Length == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.ArraysArrayCount0ErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
        }

        //d.Matrix(Vector[]) – из массива векторов-строк
        public Matrix(Vector[] vectorsArray)
        {
            string methodName = "Matrix(Vector[] vectorsArray)";
            CheckVectorsArrayNullErrors(methodName, vectorsArray);

            int rowsCount = vectorsArray.Length;
            int columnsCount = GetMaxVectorsArrayLength(vectorsArray);

            vectorsRows = new Vector[vectorsArray.Length];

            for (int i = 0; i < rowsCount; i++)
            {
                vectorsArray[i].Resize(columnsCount);
                vectorsRows[i] = new Vector(vectorsArray[i]);
            }
        }

        private static int GetMaxVectorsArrayLength(Vector[] vectorsArray)
        {
            int maxVectorLength = 0;

            foreach (Vector vector in vectorsArray)
            {
                int vectorSize = vector.GetSize();

                if (vectorSize > maxVectorLength)
                {
                    maxVectorLength = vectorSize;
                }
            }

            return maxVectorLength;
        }

        private static void CheckVectorsArrayNullErrors(string methodName, Vector[] vectorsArray)
        {
            if (vectorsArray == null)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArrayNullСonstructorErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
            if (vectorsArray.Length == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArray0ConstructorErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
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
            return vectorsRows.Length;
        }

        public int GetColumnsCount() //эквивалентно количеству координат в векторе
        {
            return vectorsRows[0].GetSize();
        }

        //b.Получение и задание вектора-строки по индексу
        public Vector GetRowVector(int index)
        {
            string methodName = "GetRowVector(int index)";
            CheckIndexInRangeErrors(methodName, GetRowsCount(), index);

            Vector vector = new Vector(vectorsRows[index]);

            return vector;
        }

        private static void CheckIndexInRangeErrors(string methodName, int maxRangeValue, int index)
        {
            if (index < 0 || index >= maxRangeValue)
            {
                string errorString = string.Format(MatrixWarningStrings.IndexInRangeErrorsMessage, index, maxRangeValue);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
        }

        public void SetRowVector(int index, Vector vector)
        {
            string methodName = "SetRowVector(int index, Vector vector)";
            CheckIndexInRangeErrors(methodName, GetRowsCount(), index);
            CheckVectorsNullErrors(methodName, vector);

            Vector.Copy(vector, vectorsRows[index]);
        }

        private static void CheckVectorsNullErrors(string methodName, Vector vector)
        {
            if (vector == null)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArrayNullСonstructorErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }

            if (vector.GetLength() == 0)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixVectorsArray0ConstructorErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
        }

        //c.Получение вектора-столбца по индексу
        public Vector GetColumnVector(int index)
        {
            string methodName = "GetColumnVector(int index)";
            CheckIndexInRangeErrors(methodName, GetColumnsCount(), index);

            int vectorCoordinatesCount = GetRowsCount();

            Vector vector = new Vector(vectorCoordinatesCount);

            for (int i = 0; i < vectorCoordinatesCount; i++)
            {
                vector.SetCoordinate(i, vectorsRows[i].GetCoordinate(index));
            }

            return vector;
        }

        //d.Транспонирование матрицы
        public Matrix Transpose()
        {
            int columnsCount = GetColumnsCount();
            int rowsCount = GetRowsCount();

            Vector[] tmpVectorsArray = new Vector[columnsCount];

            for (int i = 0; i < columnsCount; i++)
            {
                tmpVectorsArray[i] = new Vector(GetColumnVector(i));
            }

            Array.Resize(ref vectorsRows, columnsCount);

            int minNumberForCycle = columnsCount <= rowsCount ? columnsCount : rowsCount;
            int maxNumberForCycle = columnsCount;

            for (int i = 0; i < minNumberForCycle; i++)
            {
                Vector.Copy(tmpVectorsArray[i], vectorsRows[i]);
            }

            for (int i = minNumberForCycle; i < maxNumberForCycle; i++)
            {
                vectorsRows[i] = new Vector(rowsCount);
                Vector.Copy(tmpVectorsArray[i], vectorsRows[i]);
            }

            return this;
        }

        //e.Умножение на скаляр
        public Matrix MultiplyByScalar(double multiplier)
        {
            int rowsCount = GetRowsCount();

            for (int i = 0; i < rowsCount; i++)
            {
                vectorsRows[i].MultiplyBy(multiplier);
            }

            return this;
        }

        //f.Вычисление определителя матрицы
        public double GetDeterminant()
        {
            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            string methodName = "GetDeterminant()";
            CheckMatrixNotSquareErrors(methodName, rowsCount, columnsCount);

            double[,] array = new double[rowsCount, columnsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    array[i, j] = vectorsRows[i].GetCoordinate(j);
                }
            }

            return Determinant.GetDeterminant(array);
        }

        private static void CheckMatrixNotSquareErrors(string methodName, int rowsCount, int columnsCount)
        {
            if (rowsCount != columnsCount)
            {
                string errorString = string.Format(MatrixWarningStrings.MatrixNotSquareErrorMessage, rowsCount, columnsCount);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
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
                    matrixStringBilder.Append(vectorsRows[i].GetCoordinate(j));
                    matrixStringBilder.Append(", ");
                }
                matrixStringBilder.Append(vectorsRows[i].GetCoordinate(columnsCount - lastIndex));
                matrixStringBilder.Append("}, ");
            }

            matrixStringBilder.Append("{");
            for (int j = 0; j < columnsCount - lastIndex; j++)
            {
                matrixStringBilder.Append(vectorsRows[rowsCount - lastIndex].GetCoordinate(j));
                matrixStringBilder.Append(", ");
            }
            matrixStringBilder.Append(vectorsRows[rowsCount - lastIndex].GetCoordinate(columnsCount - lastIndex));
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
                throw new Exception(GetErrorDescription(methodName, errorString));
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
                    double newCoordinate = vectorsRows[i].GetCoordinate(j) + addedMatrix.vectorsRows[i].GetCoordinate(j);
                    vectorsRows[i].SetCoordinate(j, newCoordinate);
                }
            }

            return this;
        }

        private static void CheckMatricesEqualSizesErrors(string methodName, Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount() || matrix1.GetRowsCount() != matrix2.GetRowsCount())
            {
                string errorString = string.Format(MatrixWarningStrings.MatricesDifferentSizesErrorMessage);
                throw new Exception(GetErrorDescription(methodName, errorString));
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
                    double newCoordinate = vectorsRows[i].GetCoordinate(j) - subtrahendMatrix.vectorsRows[i].GetCoordinate(j);
                    vectorsRows[i].SetCoordinate(j, newCoordinate);
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

            Matrix sumMatrix = new Matrix(matrix1);

            return sumMatrix.AddMatrix(matrix2);
        }

        //b.Вычитание матриц
        public static Matrix GetSubtraction(Matrix minuendMatrix, Matrix subtrahendMatrix)
        {
            string methodName = "GetSubtraction(Matrix minuendMatrix, Matrix subtrahendMatrix)";
            CheckMatrixNullErrors(methodName, minuendMatrix);
            CheckMatrixNullErrors(methodName, subtrahendMatrix);
            CheckMatricesEqualSizesErrors(methodName, minuendMatrix, subtrahendMatrix);

            Matrix differenceMatrix = new Matrix(minuendMatrix);

            return differenceMatrix.SubtractMatrix(subtrahendMatrix);
        }

        //c.Умножение матриц
        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            string methodName = "GetMultiplication(Matrix matrix1, Matrix matrix2)";
            CheckMatrixNullErrors(methodName, matrix1);
            CheckMatrixNullErrors(methodName, matrix2);
            CheckMatricesSizesForMultiplyErrors(methodName, matrix1, matrix2);

            int rowsCount = matrix1.GetRowsCount();
            int columnsCount = matrix2.GetColumnsCount();

            Matrix productMatrix = new Matrix(rowsCount, columnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    double newCoordinate = Vector.GetScalarProduct(matrix1.vectorsRows[i], matrix2.GetColumnVector(j));
                    productMatrix.vectorsRows[i].SetCoordinate(j, newCoordinate);
                }
            }

            return productMatrix;
        }

        private static void CheckMatricesSizesForMultiplyErrors(string methodName, Matrix matrix1, Matrix matrix2)
        {
            int commonDimention1 = matrix1.GetColumnsCount();
            int commonDimention2 = matrix2.GetRowsCount();

            if (commonDimention1 != commonDimention2)
            {
                string errorString = string.Format(MatrixWarningStrings.MatricesSizesForMultiplyErrorMessage, commonDimention1, commonDimention2);
                throw new Exception(GetErrorDescription(methodName, errorString));
            }
        }
    }
}
