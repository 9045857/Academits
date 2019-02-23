using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareAndFibonacci
{
    class Program
    {
        public static IEnumerable<int> GetSquares()
        {
            int i = 0;
            while (true)
            {
                yield return i * i;
                ++i;
            }
        }

        public static IEnumerable<int> GetFibonacci()
        {
            int fN2 = 0;
            int fN1 = 1;

            yield return fN2;
            yield return fN1;

            int fN = fN2 + fN1;

            while (true)
            {
                yield return fN;

                fN2 = fN1;
                fN1 = fN;
                fN = fN2 + fN1;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа вычисляет квадратные корни целых чисел до введенного пользователем");
            Console.WriteLine();
            Console.Write("Введите целое число: ");

            int number = Convert.ToInt16(Console.ReadLine());

            foreach (int e in GetSquares().Take(number+1))
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine("Программа вычисляет числа Фибоначчи. Количество чисел вводит пользователь");
            Console.WriteLine();
            Console.Write("Введите число: ");

            int count = Convert.ToInt16(Console.ReadLine());

            foreach (int e in  GetFibonacci().Take(count))
            {
                Console.WriteLine(e);
            }
        }
    }
}
