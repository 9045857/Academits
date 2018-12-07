using System;

namespace L2Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* Тестовая программа^
                 - задаем 4 вектора через конструкторы
                 - пустой вектор заполняем через GetCoordinate
                 - печатаем через ToString
                 - сравниваем 2 пары векторов (равный и не равный)
                 - математические операции с векторами: сложение, вычитание, умножение и тд.
                 - проверяем статические методы сложения и т.п.
                 - проверяем исключения                 
                  */

                //-задаем 4 вектора через конструкторы
                //-печатаем через ToString

                Vector vector1 = new Vector(6);
                Vector vector2 = new Vector(new double[] { 10, 1, 10, 0 });
                Vector vector3 = new Vector(vector2);
                Vector vector4 = new Vector(7, new double[] { 1, 3, 5, 7 });

                Console.WriteLine("Задаем векторы");
                Console.WriteLine("Vector(int n)                  {0}", vector1);
                Console.WriteLine("Vector(double[] array)         {0}", vector2);
                Console.WriteLine("Vector(Vector vector)          {0}", vector3);
                Console.WriteLine("Vector(int n, Vector vector)   {0}", vector4);
                Console.WriteLine();

                //- пустой вектор заполняем через SetCoordinate
                Console.WriteLine("Перезаполним пустой вектор через SetCoordinate() и распечатаем через GetCoordinate()");

                int startNumber = 21;
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    vector1.SetCoordinate(i, startNumber + i);
                }

                for (int i = 0; i < vector1.GetSize() - 1; i++)
                {
                    Console.Write(vector1.GetCoordinate(i));
                    Console.Write(", ");
                }
                Console.Write(vector1.GetCoordinate(vector1.GetSize() - 1));
                Console.WriteLine();
                Console.WriteLine();

                //-сравниваем 2 пары векторов(равный и не равный)
                Console.WriteLine("Сравнение векторов");

                Console.WriteLine("{0} = {1}: {2}", vector1, vector4, vector1.Equals(vector4));
                Console.WriteLine("{0} = {1}: {2}", vector2, vector3, vector2.Equals(vector3));
                Console.WriteLine();

                //-математические операции с векторами: сложение, вычитание, умножение, реверс.
                Console.WriteLine("Математические операции - нестатические методы");

                Console.Write("vector2.AddVector(vector1)      {0} + {1} = ", vector2, vector1);
                Console.WriteLine(vector2.AddVector(vector1));

                Console.Write("vector2.SubtractVector(vector3) {0} - {1} = ", vector2, vector3);
                Console.WriteLine(vector2.SubtractVector(vector3));

                Console.Write("vector3.MultiplyBy(number)      {0} * {1} = ", vector3, 3);
                Console.WriteLine(vector3.MultiplyBy(3));

                Console.Write("vector4.Reverse()               {0}  вереверс -> ", vector4);
                Console.WriteLine(vector4.Reverse());

                Console.WriteLine();

                //-проверяем статические методы сложения и т.п.
                Console.WriteLine("Математические операции через статические методы");

                Console.WriteLine("GetAddition(vector1, vector2)        {0} + {1} = {2}", vector1, vector2, Vector.GetAddition(vector1, vector2));
                Console.WriteLine("GetDifference(vector2, vector3)      {0} - {1} = {2}", vector2, vector3, Vector.GetDifference(vector2, vector3));
                Console.WriteLine("GetScalarProduct(vector1, vector3)   {0} * {1} = {2}", vector1, vector3, Vector.GetScalarProduct(vector1, vector3));

                Console.WriteLine();

                //-проверяем исключения

                //Vector vector5 = new Vector(-2); // исключение на отрицательную размерность вектора
                // Vector vector6 = new Vector(-3, new double[] { 1, 3, 5, 7, 9 });// исключение на отрицательную размерность вектора
                // Vector vector6 = new Vector(3, null);// исключение массив null
                Vector vector6 = new Vector(3, new double[0]);// исключение на массив размером 0

                // Console.Write(vector1.GetCoordinate(100)); //"Ошибка в GetCoordinate(int index): привышение в запросе размерности вектора"//IndexOutOfRangeException
                // vector1.SetCoordinate(-1, 12);  //"Ошибка в SetCoordinate(int index,double value): привышение размерности вектора при задании координаты"//IndexOutOfRangeException
                // vector1.SetCoordinate(100, 12);  //"Ошибка в SetCoordinate(int index,double value): привышение размерности вектора при задании координаты"//IndexOutOfRangeException

                //vector1 = new Vector(-2);// OverflowException
                // vector4 = new Vector(-4, new double[] { 1, 3, 5, 7, 9 });//System.OverflowException

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }
    }
}
