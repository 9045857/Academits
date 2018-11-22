using System;

namespace L1Range
{
    /*
    •Вычисление длины интервала
    •Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null. 
     Если есть, то выдать новый диапазон с соответствующими концами
    •Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска
    •Получение разности двух интервалов. Может получиться 1 или 2 отдельных куска
    */

    class Range
    {
        public int From { get; set; }
        public int To { get; set; }

        public Range()
        {
        }

        public Range(int from, int to)
        {
            From = from;
            To = to;
        }

        public int IntervalLength()
        {
            return To - From;
        }

        public bool IsInside(int number)
        {
            return (From <= number) && (number <= To);
        }

        private static bool IsRangeOverlap(Range range1, Range range2) // вспомогательная функция все задания
        {
            return (range1.From <= range2.To) && (range1.To >= range2.From);
        }

        // •Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null. 
        //  Если есть, то выдать новый диапазон с соответствующими концами
        public static Range GetRangesIntersection(Range range1, Range range2)
        {
            if (IsRangeOverlap(range1, range2))
            {
                Range range = new Range
                {
                    From = (range1.From >= range2.From) ? range1.From : range2.From,
                    To = (range1.To <= range2.To) ? range1.To : range2.To
                };

                return range;
            }
            else
            {
                return null;
            }
        }

        //Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска
        public static Range[] GetRangesUnion(Range range1, Range range2)
        {
            if (IsRangeOverlap(range1, range2))
            {
                Range[] tmpRange = new Range[1];
                tmpRange[0] = new Range();

                tmpRange[0].From = (range1.From <= range2.From) ? range1.From : range2.From;
                tmpRange[0].To = (range1.To >= range2.To) ? range1.To : range2.To;

                return tmpRange;
            }
            else
            {
                Range[] tmpRange = new Range[2];
                tmpRange[0] = new Range();
                tmpRange[1] = new Range();

                tmpRange[0].From = (range1.From < range2.From) ? range1.From : range2.From;
                tmpRange[0].To = (range1.To < range2.To) ? range1.To : range2.To;

                tmpRange[1].From = (range1.From > range2.From) ? range1.From : range2.From;
                tmpRange[1].To = (range1.To > range2.To) ? range1.To : range2.To;

                return tmpRange;
            }
        }

        //•Получение разности двух интервалов. Может получиться 1 или 2 отдельных куска
        public static Range[] GetRangesDifference(Range range1, Range range2)
        {
            if (IsRangeOverlap(range1, range2))
            {
                if ((range1.From < range2.From) && (range1.To <= range2.To))
                {
                    Range[] tmpRange = new Range[1];
                    tmpRange[0] = new Range();

                    tmpRange[0].From = range1.From;
                    tmpRange[0].To = range2.From - 1;

                    return tmpRange;
                }
                else if ((range1.From < range2.From) && (range1.To > range2.To))
                {
                    Range[] tmpRange = new Range[2];
                    tmpRange[0] = new Range();
                    tmpRange[1] = new Range();

                    tmpRange[0].From = range1.From;
                    tmpRange[0].To = range2.From - 1;
                    tmpRange[1].From = range2.To + 1;
                    tmpRange[1].To = range1.To;

                    return tmpRange;
                }
                else if ((range1.From >= range2.From) && (range1.To > range2.To))
                {
                    Range[] tmpRange = new Range[1];
                    tmpRange[0] = new Range();

                    tmpRange[0].From = range2.To + 1;
                    tmpRange[0].To = range1.To;

                    return tmpRange;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Range[] tmpRange = new Range[1];
                tmpRange[0] = new Range();

                tmpRange[0] = range1;

                return tmpRange;
            }
        }
    }

    class L1TRange
    {
        static void Main(string[] args)
        {
            // задание: •После этого написать небольшую программу с использованием этого класса

            Console.WriteLine("Простая программа использующая класс Range");

            Range range = new Range(10, 31);
            int number1 = 9;

            Console.WriteLine("Диапазон [{0}, {1}]", range.From, range.To);

            if (range.IsInside(number1))
            {
                Console.WriteLine("Число {0} принадлежит [{1}, {2}]", number1, range.From, range.To);
            }
            else
            {
                Console.WriteLine("Число {0} не принадлежит [{1}, {2}]", number1, range.From, range.To);
            }

            Console.WriteLine("Длина диапазона [{0}, {1}] равна {2}", range.From, range.To, range.IntervalLength());
            Console.WriteLine();

            // задание:Получение интервала-пересечения двух интервалов. 
            // Если пересечения нет, выдать null. 
            // Если есть, то выдать новый диапазон с соответствующими концами

            Console.WriteLine("Метод рассчитывающий интервал-пересечение двух интервалов.");

            Range range1 = new Range(1, 12);
            Range range2 = new Range(11, 20);

            Range range3 = Range.GetRangesIntersection(range1, range2);

            Console.Write(" [{0}, {1}] П [{2}, {3}]  =  ", range1.From, range1.To, range2.From, range2.To);

            if (range3 == null)
            {
                Console.WriteLine("пустое множество");
            }
            else
            {
                Console.WriteLine("[{0}, {1}]", range3.From, range3.To);
            }
            Console.WriteLine();

            // задание: Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска

            Console.WriteLine("Метод рассчитывающий объединения двух интервалов.");

            range1 = new Range(1, 10);
            range2 = new Range(10, 20);

            Range[] rangeUnion = Range.GetRangesUnion(range1, range2);

            Console.Write(" [{0}, {1}] U [{2}, {3}]  = ", range1.From, range1.To, range2.From, range2.To);
            for (int i = 0; i < rangeUnion.Length; i++)
            {
                Console.Write(" [{0}, {1}]", rangeUnion[i].From, rangeUnion[i].To);
            }

            Console.WriteLine();
            Console.WriteLine();

            //задание: •Получение разности двух интервалов. Может получиться 1 или 2 отдельных куска

            Console.WriteLine("Метод рассчитывающий разность двух интервалов.");

            range1 = new Range(1, 30);
            range2 = new Range(11, 20);

            Range[] rangeDifference = Range.GetRangesDifference(range1, range2);

            Console.Write(" [{0}, {1}] / [{2}, {3}]  = ", range1.From, range1.To, range2.From, range2.To);
            if (rangeDifference != null)
            {
                for (int i = 0; i < rangeDifference.Length; i++)
                {
                    Console.Write(" [{0}, {1}]", rangeDifference[i].From, rangeDifference[i].To);
                }
            }
            else
            {
                Console.Write(" пустое множество ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
