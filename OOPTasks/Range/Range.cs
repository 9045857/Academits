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
            return DoubleComparison.IsAMoreOrEqualB(number, From) && DoubleComparison.IsAMoreOrEqualB(To, number);
        }

        private bool IsRangeOverlap(Range range) // нет наложения крайними точками интервалов 
        {
            return !DoubleComparison.IsAMoreOrEqualB(From, range.To) && !DoubleComparison.IsAMoreOrEqualB(range.From, To);
        }

        private bool IsRangeOverlapWithEdges(Range range) // есть наложение крайними точками интервалов
        {
            return !DoubleComparison.IsAMoreB(From, range.To) && !DoubleComparison.IsAMoreB(range.From, To);
        }

        // •Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null. 
        //  Если есть, то выдать новый диапазон с соответствующими концами

        public Range GetRangesIntersection(Range range)
        {
            if (!IsRangeOverlap(range))
            {
                return null;
            }

            double from = Math.Max(From, range.From);
            double to = Math.Min(To, range.To);

            return new Range(from, to);
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

            double from1 = Math.Min(From, range.From);
            double to1 = Math.Min(To, range.To);

            double from2 = Math.Max(From, range.From);
            double to2 = Math.Max(To, range.To);

            return new Range[] { new Range(from1, to1), new Range(from2, to2) };
        }

        //•Получение разности двух интервалов. Может получиться 1 или 2 отдельных куска

        public Range[] GetRangesDifference(Range range)
        {
            if (!IsRangeOverlap(range))
            {
                return new Range[] { new Range(From, To) };
            }

            if (DoubleComparison.IsAMoreB(range.From, From) && DoubleComparison.IsAMoreOrEqualB(range.To, To))
            {
                return new Range[] { new Range(From, range.From) };
            }
            else if (DoubleComparison.IsAMoreB(range.From, From) && DoubleComparison.IsAMoreB(To, range.To))
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }
            else if (DoubleComparison.IsAMoreOrEqualB(From, range.From) && DoubleComparison.IsAMoreB(To, range.To))
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
