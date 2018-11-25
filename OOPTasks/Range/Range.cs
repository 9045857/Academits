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
        public double From { get; set; }
        public double To { get; set; }

        private const double epsilon = 1.0e-10;

        public Range(double from, double to) // from >= to. Пропишем корректное заполнение.
        {
            From = Math.Min(from, to);
            To = Math.Max(from, to);
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number) // крайние точки входят в интервал
        {
            return ((number - From) >= -epsilon) && ((To - number) >= -epsilon);
        }

        private bool IsRangeOverlap(Range range) // нет наложения крайними точками интервалов 
        {
            bool isRangeLeftFromThis = (From - range.To) >= -epsilon;
            bool isRangeRightFromThis = (range.From - To) >= -epsilon;

            bool IsNotRangeOverlap = isRangeLeftFromThis || isRangeRightFromThis;

            return !IsNotRangeOverlap;
        }

        private bool IsRangeOverlapWithEdges(Range range) // есть наложение крайними точками интервалов
        {
            bool isRangeLeftFromThis = (From - range.To) > epsilon;
            bool isRangeRightFromThis = (range.From - To) > epsilon;

            bool IsNotRangeOverlap = isRangeLeftFromThis || isRangeRightFromThis;

            return !IsNotRangeOverlap;
        }

        // •Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null. 
        //  Если есть, то выдать новый диапазон с соответствующими концами

        public Range GetRangesIntersection(Range range)
        {
            if (IsRangeOverlap(range))
            {
                double from = Math.Max(From, range.From);
                double to = Math.Min(To, range.To);

                Range tmpRange = new Range(from, to);

                return tmpRange;
            }
            else
            {
                return null;
            }
        }

        //Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска

        public Range[] GetRangesUnion(Range range)
        {
            if (IsRangeOverlapWithEdges(range))
            {
                double from = Math.Min(From, range.From);
                double to = Math.Max(To, range.To);

                return new Range[] { new Range(from, to) };
            }
            else
            {
                double from1 = Math.Min(From, range.From);
                double to1 = Math.Min(To, range.To);

                double from2 = Math.Max(From, range.From);
                double to2 = Math.Max(To, range.To);

                return new Range[] { new Range(from1, to1), new Range(from2, to2) };
            }
        }

        //•Получение разности двух интервалов. Может получиться 1 или 2 отдельных куска

        public Range[] GetRangesDifference(Range range)
        {
            if (!IsRangeOverlap(range))
            {
                return new Range[] { new Range(From, To) };
            }

            if (((range.From - From) > epsilon) && ((range.To - To) > epsilon))
            {
                return new Range[] { new Range(From, range.From) };
            }
            else if (((range.From - From) > epsilon) && ((To - range.To) > epsilon))
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }
            else if (((From - range.From) > epsilon) && ((To - range.To) > epsilon))
            {
                return new Range[] { new Range(range.To, To) };
            }
            else
            {
                return new Range[] { };
            }
        }
    }
}
