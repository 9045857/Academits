using System;

namespace L2Vector
{
    //  Vector(n) – размерность n, все компоненты равны 0
    //  Vector(Vector) – конструктор копирования
    //  Vector(double[]) – заполнение вектора значениями из массива
    //  Vector(n, double[]) – заполнение вектора значениями из массива.Если длина массива меньше n, то считать что в остальных компонентах 0
    class Vector
    {
        private double[] coordinates;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new IndexOutOfRangeException("Ошибка в конструкторе Vector(int n):  n <= 0 ");
            }

            coordinates = new double[n];
        }

        public Vector(Vector vector)
        {
            if (vector.coordinates.Length == 0)
            {
                throw new IndexOutOfRangeException("Ошибка в конструкторе Vector(Vector vector): размер массива координат не может быть равен 0 ");
            }

            coordinates = new double[vector.coordinates.Length];

            Array.Copy(vector.coordinates, coordinates, vector.coordinates.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new IndexOutOfRangeException("Ошибка в конструкторе Vector(double[] array): размер массива не может быть равен 0 ");
            }

            coordinates = new double[array.Length];

            Array.Copy(array, coordinates, array.Length);
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new IndexOutOfRangeException("Ошибка в конструкторе Vector(int n, double[] array): Размерность n <= 0 ");
            }

            coordinates = new double[n];

            int minArrayLength = Math.Min(n, array.Length);

            for (int i = 0; i < minArrayLength; i++)
            {
                coordinates[i] = array[i];
            }
        }

        public int GetSize()
        {
            return coordinates.Length;
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", coordinates) + "}";
        }

        //4. Реализовать нестатические методы:
        //a.Прибавление к вектору другого вектора     

        public Vector AddVector(Vector vector)//TODO: передалать ретюрн. Разобраться со сложением
        {
            int maxVectorsLength = Math.Max(coordinates.Length, vector.coordinates.Length);
            int minVectorsLength = Math.Min(coordinates.Length, vector.coordinates.Length);

            for (int i = 0; i < minVectorsLength; i++)
            {
                coordinates[i] += vector.coordinates[i];
            }

            if (maxVectorsLength == minVectorsLength || coordinates.Length == maxVectorsLength)
            {
                return new Vector(coordinates);
            }

            for (int i = minVectorsLength; i < maxVectorsLength; i++)
            {
                coordinates[i] = vector.coordinates[i];
            }

            return this;
        }

        //b.Вычитание из вектора другого вектора    

        public Vector SubtractVector(Vector vector)
        {
            int maxVectorsLength = Math.Max(coordinates.Length, vector.coordinates.Length);
            int minVectorsLength = Math.Min(coordinates.Length, vector.coordinates.Length);

            for (int i = 0; i < minVectorsLength; i++)
            {
                coordinates[i] -= vector.coordinates[i];
            }

            if (maxVectorsLength == minVectorsLength || coordinates.Length == maxVectorsLength)
            {
                return this;
            }

            for (int i = minVectorsLength; i < maxVectorsLength; i++)
            {
                coordinates[i] = -vector.coordinates[i];
            }

            return this;
        }

        //c.Умножение вектора на скаляр        
        public Vector MultiplyBy(double number)
        {
            return MultiplyByNumber(number);
        }

        private Vector MultiplyByNumber(double number)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] *= number;
            }

            return this;
        }

        //d.Разворот вектора (умножение всех компонент на -1)
        public Vector Reverse()
        {
            return MultiplyByNumber(-1);
        }

        //e.Получение длины вектора
        public double GetLength()
        {
            double tmpLength = 0;

            foreach (double element in coordinates)
            {
                tmpLength += element * element;
            }

            return Math.Sqrt(tmpLength);
        }

        //f.Получение и установка компоненты вектора по индексу
        public double GetCoordinate(int index)
        {
            if (index < 0 || index >= coordinates.Length)
            {
                throw new ArgumentException("Ошибка в GetCoordinate(int index): привышение в запросе размерности вектора");
            }

            return coordinates[index];
        }

        public void SetCoordinate(int index, double value)
        {
            if (index < 0 || index >= coordinates.Length)
            {
                throw new ArgumentException("Ошибка в SetCoordinate(int index,double value): привышение размерности вектора при задании координаты");
            }

            coordinates[index] = value;
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

            if (coordinates.Length != vector.coordinates.Length)
            {
                return false;
            }

            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i] != vector.coordinates[i])
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

            foreach (double element in coordinates)
            {
                hash = prime * hash + element.GetHashCode();
            }

            return hash;
        }

        //5. Реализовать статические методы – должны создаваться новые векторы:
        //a.Сложение двух векторов
        public static Vector GetAddition(Vector vector1, Vector vector2)
        {
            int maxVectorsLength = Math.Max(vector1.coordinates.Length, vector2.coordinates.Length);
            int minVectorsLength = Math.Min(vector1.coordinates.Length, vector2.coordinates.Length);

            Vector resultVector = new Vector(maxVectorsLength);

            for (int i = 0; i < minVectorsLength; i++)
            {
                resultVector.coordinates[i] = vector1.coordinates[i] + vector2.coordinates[i];
            }

            if (maxVectorsLength == minVectorsLength)
            {
                return resultVector;
            }

            if (vector1.coordinates.Length == maxVectorsLength)
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    resultVector.coordinates[i] = vector1.coordinates[i];
                }
            }
            else
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    resultVector.coordinates[i] = vector2.coordinates[i];
                }
            }

            return resultVector;
        }

        //b.Вычитание векторов
        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            int maxVectorsLength = Math.Max(vector1.coordinates.Length, vector2.coordinates.Length);
            int minVectorsLength = Math.Min(vector1.coordinates.Length, vector2.coordinates.Length);

            Vector resultVector = new Vector(maxVectorsLength);

            for (int i = 0; i < minVectorsLength; i++)
            {
                resultVector.coordinates[i] = vector1.coordinates[i] - vector2.coordinates[i];
            }

            if (maxVectorsLength == minVectorsLength)
            {
                return resultVector;
            }

            if (vector1.coordinates.Length == maxVectorsLength)
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    resultVector.coordinates[i] = vector1.coordinates[i];
                }
            }
            else
            {
                for (int i = minVectorsLength; i < maxVectorsLength; i++)
                {
                    resultVector.coordinates[i] = -vector2.coordinates[i];
                }
            }

            return resultVector;
        }

        //c.	Скалярное произведение векторов
        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int minVectorsLength = Math.Min(vector1.coordinates.Length, vector2.coordinates.Length);

            double result = 0;

            for (int i = 0; i < minVectorsLength; i++)
            {
                result += vector1.coordinates[i] * vector2.coordinates[i];
            }

            return result;
        }
    }
}
