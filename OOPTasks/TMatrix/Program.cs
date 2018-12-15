using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Прогрмма тестов:

                //a.Matrix(n, m) – матрица нулей размера nxm
                //  Matrix(double[,]) – из двумерного массива
                //c.Matrix(double[][]) – из двумерного массива
                //b.Matrix(Matrix) – конструктор копирования
                //d.Matrix(Vector[]) – из массива векторов - строк

                Console.WriteLine("Проверка конструкторов Matrix");

                Matrix matrix1 = new Matrix(3, 2);
                Console.Write("Matrix(n, m):         ");
                Console.WriteLine(matrix1);

                double[,] array2D = new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
                Matrix matrix2 = new Matrix(array2D);
                Console.Write("Matrix(array[,]):     ");
                Console.WriteLine(matrix2);

                double[][] arraysArray = new double[2][];
                arraysArray[0] = new double[] { 3, 3, 3, 3 };
                arraysArray[1] = new double[] { 5, 5, 5, 5 };
                Matrix matrix3 = new Matrix(arraysArray);
                Console.Write("Matrix(array[][]):    ");
                Console.WriteLine(matrix3);

                double[][] array = new double[4][];
                array[0] = new double[3] { 1, 2, 3 };
                array[1] = new double[2] { 2, 2 };
                array[2] = new double[3] { 5, 5, 5 };
                array[3] = new double[1] { 1 };

                Matrix matrix3_1 = new Matrix(array);

                Console.Write("Matrix(array[][]) с разными массивами:    ");
                Console.WriteLine(matrix3_1);


                Matrix matrix4 = new Matrix(matrix3);
                Console.Write("Matrix(matrix):       ");
                Console.WriteLine(matrix3);

                L2Vector.Vector[] vectorsArray = new L2Vector.Vector[]
                {
                    new L2Vector.Vector(3),
                    new L2Vector.Vector(new double[]{9,8,7 })
                };
                Matrix matrix5 = new Matrix(vectorsArray);
                Console.Write("Matrix(vectorsArray): ");
                Console.WriteLine(matrix5);
                Console.WriteLine();

                // 2. Проверка нестатических Методов:
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

                Console.WriteLine("Проверка нестатических методов");
                //b.Получение и задание вектора-строки по индексу

                Console.Write("Матрице: {0}", matrix5);

                int index0 = 0;
                L2Vector.Vector vector0 = new L2Vector.Vector(new double[] { 9, 9, 9 });
                matrix5.SetRowVector(index0, vector0);

                Console.WriteLine(" передаем строку-вектор {0} с индексом {1}", index0, vector0);

                Console.WriteLine("Для получившейся матрицы: {0}", matrix5);

                int index1 = 0;
                Console.WriteLine("Получение {0} строки-вектора: {1}", index1, matrix5.GetRowVector(index1));

                //c.Получение вектора-столбца по индексу
                int index2 = 0;
                Console.WriteLine("Получение {0} столбца-вектора: {1}", index2, matrix5.GetColumnVector(index2));

                //a.Получение размеров матрицы
                Console.WriteLine("Количество столбцов: {0}", matrix5.GetColumnsCount());
                Console.WriteLine("Количество строк:    {0}", matrix5.GetRowsCount());

                //d.Транспонирование матрицы
                Console.WriteLine("Результат транспонирования:   {0}", matrix5.Transpose());
                Console.WriteLine("Результат транспонирования:   {0}", matrix5.Transpose());

                //e.Умножение на скаляр
                double scalar = 10.2;
                Console.WriteLine("Умножение на скаляр ({0}):   {1}", scalar, matrix5.MultiplyByScalar(scalar));

                //f.Вычисление определителя матрицы

                double[,] array2D2 = new double[,] { { 1, 2 }, { 3, 4 } };
                Matrix matrix6 = new Matrix(array2D2);

                Console.WriteLine("Определитель матрицы {0}:   {1}", matrix6, matrix6.GetDeterminant());

                //h.умножение матрицы на вектор
                L2Vector.Vector vector = new L2Vector.Vector(new double[] { 4, 4, 4, 4 });

                Console.WriteLine("Умножениме матрицы на вектор:");
                Console.WriteLine(" {0} x {1} = {2}", matrix3, vector, matrix3.MultiplyByVector(vector));

                //i.Сложение матриц
                Console.WriteLine("Сложение матриц:");
                Console.Write(" {0} + ", matrix3);
                Console.WriteLine("{0} = {1}", matrix4, matrix3.AddMatrix(matrix4));

                //j.Вычитание матриц
                Console.WriteLine("Вычитание матриц:");
                Console.Write(" {0} - ", matrix3);
                Console.WriteLine("{0} = {1}", matrix4, matrix3.SubtractMatrix(matrix4));

                //3.Статические методы:
                Console.WriteLine();
                Console.WriteLine("Статические методы");

                //a.Сложение матриц
                Console.WriteLine("Сложение матриц:");
                Console.WriteLine(" {0} + {1} = {2}", matrix3, matrix4, Matrix.GetAddition(matrix3, matrix4));

                //b.Вычитание матриц
                Console.WriteLine("Вычитание матриц:");
                Console.WriteLine(" {0} - {1} = {2}", matrix3, matrix4, Matrix.GetSubtraction(matrix3, matrix4));

                //c.Умножение матриц
                Console.WriteLine("Умножение матриц:");
                matrix4.Transpose();

                Console.WriteLine(" {0} * {1} = {2}", matrix3, matrix4, Matrix.GetMultiplication (matrix3, matrix4));

                // Тестирование исключений
                Console.WriteLine();
                Console.WriteLine("Тестирование исключений");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }
    }
}
