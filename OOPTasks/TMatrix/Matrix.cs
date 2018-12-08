using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using L2Vector;

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
            //TODO: сделать ошибку на отрицальные или нулевые n и m
            //int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            vectors = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                vectors[i] = new Vector(columnsCount);
            }
        }

        //b.Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            vectors = new Vector[matrix.vectors.Length];

            for (int i = 0; i < matrix.vectors.Length; i++)
            {
                vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        //c.Matrix(double[][]) – из двумерного массива
        public Matrix(double[][] array)
        {
            //TODO: нужна проверка, что все массивы не null
            //TODO: нужна проверка, что все массивы в массиве одного размера

            vectors = new Vector[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                vectors[i] = new Vector(array[i]);
            }
        }

        //d.Matrix(Vector[]) – из массива векторов-строк
        public Matrix(Vector[] vectorsArray)
        {
            vectors = new Vector[vectorsArray.Length];

            for (int i = 0; i < vectorsArray.Length; i++)
            {
                vectors[i] = new Vector(vectorsArray[i]);
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
            return vectors[index];
        }

        public void SetRowVector(int index, Vector vector)
        {
            vectors[index] = new Vector(vector); //был бы метод копирования векторов, сделал бы через него. без него делаю через конструктор, можно ли так?           
        }

        //c.Получение вектора-столбца по индексу
        public Vector GetColumnVector(int index)//TODO: исключение на индекс вне массива
        {
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
            matrixStringBilder.Append("{");

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
            matrixStringBilder.Append("}}");

            return matrixStringBilder.ToString();
        }

        //h.умножение матрицы на вектор

        public Vector MultiplyByVector(Vector vector)
        {



            return null;
        }

        //i.Сложение матриц
        //j.Вычитание матриц



    }
}
