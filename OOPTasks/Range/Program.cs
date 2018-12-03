using System;

namespace L1Range
{
    /// <summary>
    /// Done
    /// </summary>
    /*
    •Вычисление длины интервала
    •Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null. 
     Если есть, то выдать новый диапазон с соответствующими концами
    •Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска
    •Получение разности двух интервалов. Может получиться 1 или 2 отдельных куска
    */

    class Program
    {
        static void Main(string[] args)
        {
            // задание: •написать небольшую программу с использованием класса Range

            Console.WriteLine(" -= Простая программа использующая класс Range =-");

            Range range = new Range(10, 31);
            double number1 = 10;

            Console.WriteLine("Диапазон [{0}; {1}]", range.From, range.To);

            if (range.IsInside(number1))
            {
                Console.WriteLine("Число {0} принадлежит [{1}; {2}]", number1, range.From, range.To);
            }
            else
            {
                Console.WriteLine("Число {0} не принадлежит [{1}; {2}]", number1, range.From, range.To);
            }

            Console.WriteLine("Длина диапазона [{0}; {1}] равна {2}", range.From, range.To, range.GetLength());
            Console.WriteLine();

            // задание:Получение интервала-пересечения двух интервалов. 
            // Если пересечения нет, выдать null. 
            // Если есть, то выдать новый диапазон с соответствующими концами

            Console.WriteLine(" -= Метод рассчитывающий интервал-пересечение двух интервалов. =-");

            Range range1 = new Range(1, 12);
            Range range2 = new Range(12, 20);

            Range range3 = range1.GetRangesIntersection(range2);

            Console.Write(" [{0}; {1}] П [{2}; {3}]  =  ", range1.From, range1.To, range2.From, range2.To);

            if (range3 == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine("[{0}; {1}]", range3.From, range3.To);
            }
            Console.WriteLine();

            // задание: Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска

            Console.WriteLine(" -= Метод рассчитывающий объединения двух интервалов. =-");

            range1 = new Range(1, 10);
            range2 = new Range(10, 20);

            Range[] rangeUnion = range1.GetRangesUnion(range2);

            Console.Write(" [{0}; {1}] U [{2}; {3}]  = ", range1.From, range1.To, range2.From, range2.To);

            PrintRangesArray(rangeUnion);

            Console.WriteLine();
            Console.WriteLine();

            //задание: •Получение разности двух интервалов. Может получиться 1 или 2 отдельных куска

            Console.WriteLine(" -= Метод рассчитывающий разность двух интервалов. =-");

            range1 = new Range(12, 30);
            range2 = new Range(12, 29);

            Range[] rangeDifference = range1.GetRangesDifference(range2);

            Console.Write(" [{0}; {1}] / [{2}; {3}]  = ", range1.From, range1.To, range2.From, range2.To);

            PrintRangesArray(rangeDifference);

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void PrintRangesArray(Range[] range)
        {
            switch (range.Length)
            {
                case 0:
                    Console.Write(" null ");
                    break;
                case 1:
                    Console.Write(" [{0}; {1}]", range[0].From, range[0].To);
                    break;
                case 2:
                    Console.Write(" [{0}; {1}] ", range[0].From, range[0].To);
                    Console.Write("U");
                    Console.Write(" [{0}; {1}]", range[1].From, range[1].To);
                    break;
                default:
                    Console.Write(" не пойми что ");
                    break;
            }
        }
    }
}
