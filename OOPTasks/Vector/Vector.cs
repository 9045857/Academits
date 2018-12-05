using System;

namespace L2Vector
{
    //  Vector(n) – размерность n, все компоненты равны 0
    //  Vector(Vector) – конструктор копирования
    //  Vector(double[]) – заполнение вектора значениями из массива
    //  Vector(n, double[]) – заполнение вектора значениями из массива.Если длина массива меньше n, то считать что в остальных компонентах 0
    class Vector
    {
        private double[] coordinate;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new IndexOutOfRangeException("Ошибка в конструкторе Vector(int n): Размерность n <= 0 ");
            }

            coordinate = new double[n];
        }

        public Vector(Vector vector)
        {
            coordinate = new double[vector.coordinate.Length];

            for (int i = 0; i < vector.coordinate.Length; i++)
            {
                coordinate[i] = vector.coordinate[i];
            }
        }

        public Vector(double[] array)
        {
            coordinate = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                coordinate[i] = array[i];
            }
        }


        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new IndexOutOfRangeException("Ошибка в конструкторе Vector(int n, double[] array): Размерность n <= 0 ");
            }

            coordinate = new double[n];

            int minArrayLength = Math.Min(n, array.Length);

            for (int i = 0; i < minArrayLength; i++)
            {
                coordinate[i] = array[i];
            }

            if (n > minArrayLength)
            {
                for (int i = minArrayLength; i < n; i++)
                {
                    coordinate[i] = 0;
                }
            }
        }

        public int GetSize()
        {
            return coordinate.Length;
        }

        public override string ToString()
        {
            return string.Join(", ", coordinate);
        }

        //        4.	Реализовать нестатические методы:
        //a.Прибавление к вектору другого вектора
        private Vector GetVectorsAdditionPrivatMethod(Vector vector1, Vector vector2)
        {
            int maxVectorsLength = Math.Max(vector1.coordinate.Length, vector2.coordinate.Length);
            int minVectorsLength = Math.Min(vector1.coordinate.Length, vector2.coordinate.Length);

            double[] tmpCoordinate = new double[maxVectorsLength];

            for (int i = 0; i < minVectorsLength; i++)
            {
                tmpCoordinate[i] = vector1.coordinate[i] + vector2.coordinate[i];
            }

            if (maxVectorsLength == minVectorsLength)
            {
                return new Vector(tmpCoordinate);
            }

            if (vector1.coordinate.Length == maxVectorsLength)
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    tmpCoordinate[i] = vector1.coordinate[i];
                }
            }
            else
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    tmpCoordinate[i] = vector2.coordinate[i];
                }
            }

            return new Vector(tmpCoordinate);
        }

        public Vector AddVector(Vector vector)
        {
            return GetVectorsAdditionPrivatMethod(this, vector);
        }

        //b.Вычитание из вектора другого вектора
        public Vector GetVectorsDifferencePrivateMethod(Vector vector1, Vector vector2)
        {
            int maxVectorsLength = Math.Max(vector1.coordinate.Length, vector2.coordinate.Length);
            int minVectorsLength = Math.Min(vector1.coordinate.Length, vector2.coordinate.Length);

            double[] tmpCoordinate = new double[maxVectorsLength];

            for (int i = 0; i < minVectorsLength; i++)
            {
                tmpCoordinate[i] = vector1.coordinate[i] - vector2.coordinate[i];
            }

            if (maxVectorsLength == minVectorsLength)
            {
                return new Vector(tmpCoordinate);
            }

            if (coordinate.Length == maxVectorsLength)
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    tmpCoordinate[i] = vector1.coordinate[i];
                }
            }
            else
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    tmpCoordinate[i] = -vector2.coordinate[i];
                }
            }

            return new Vector(tmpCoordinate);
        }

        public Vector SubtractVector(Vector vector)
        {
            return GetVectorsDifferencePrivateMethod(this, vector);
        }

        //c.Умножение вектора на скаляр        
        public Vector MultiplyBy(double number)
        {
            return MultiplyByNumber(number);
        }

        private Vector MultiplyByNumber(double number)
        {
            double[] tmpCoordinate = new double[coordinate.Length];

            for (int i = 0; i < coordinate.Length; i++)
            {
                tmpCoordinate[i] = number * coordinate[i];
            }

            return new Vector(tmpCoordinate);
        }

        //d.Разворот вектора (умножение всех компонент на -1)
        public Vector Revers()
        {
            return MultiplyByNumber(-1);
        }

        //e.Получение длины вектора
        public double GetLength()
        {
            double tmpLength = 0;

            for (int i = 0; i < coordinate.Length; i++)
            {
                tmpLength += coordinate[i] * coordinate[i];
            }

            return Math.Sqrt(tmpLength);
        }

        //f.Получение и установка компоненты вектора по индексу
        public double GetCoordinate(int index)
        {
            if (index < 0 || index >= coordinate.Length)
            {
                throw new IndexOutOfRangeException("Ошибка в GetCoordinate(int index): привышение в запросе размерности вектора");
            }

            return coordinate[index];
        }

        public void SetCoordinate(int index, double value)
        {
            if (index < 0 || index >= coordinate.Length)
            {
                throw new IndexOutOfRangeException("Ошибка в SetCoordinate(int index,double value): привышение размерности вектора при задании координаты");
            }

            coordinate[index] = value;
        }

        //g.Переопределить метод equals, чтобы был true  векторы имеют одинаковую размерность 
        // и соответствующие компоненты равны. 
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (coordinate.Length != vector.coordinate.Length)
            {
                return false;
            }

            for (int i = 0; i < coordinate.Length; i++)
            {
                if (coordinate[i] != vector.coordinate[i])
                {
                    return false;
                }
            }

            return true;
        }

        // Соответственно, переопределить hashCode
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double element in coordinate)
            {
                hash = prime * hash + element.GetHashCode();
            }

            return hash;
        }

        //5. Реализовать статические методы – должны создаваться новые векторы:
        //a.Сложение двух векторов
        public static Vector GetAddition(Vector vector1, Vector vector2)
        {
            return vector1.GetVectorsAdditionPrivatMethod(vector1, vector2);
        }

        //b.Вычитание векторов
        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            return vector1.GetVectorsDifferencePrivateMethod(vector1, vector2);
        }

        //c.	Скалярное произведение векторов
        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int minVectorsLength = Math.Min(vector1.coordinate.Length, vector2.coordinate.Length);

            double result = 0;

            for (int i = 0; i < minVectorsLength; i++)
            {
                result += vector1.coordinate[i] * vector2.coordinate[i];
            }

            return result;
        }
    }
}
