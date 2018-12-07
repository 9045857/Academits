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
        public Matrix(int m, int n)
        {
            //TODO: сделать ошибку на отрицальные или нулевые n и m
            //int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            vectors = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                vectors[i] = new Vector(n);
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
        public int GetRowCount(Matrix matrix) //эквивалентно количеству векторов
        {
            return matrix.vectors.Length;
        }

        public int GetColumnCount(Matrix matrix) //эквивалентно количеству координат в векторе
        {
            return matrix.vectors[0].GetSize();
        }

        //b.Получение и задание вектора-строки по индексу
                public Vector GetVector(int index)
        {
            return vectors[index];
        }

        public void SetVector(int index, Vector vector)
        {
            vectors[index] = new Vector(vector); //был бы метод копирования векторов, сделал бы через него. без него делаю через конструктор            
        }

        //d.Транспонирование матрицы

    }
}
