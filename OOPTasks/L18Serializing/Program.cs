using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace L18Serializing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача 1
            //Создать свой класс Rectangle с полями ширина, высота и площадь
            //•Должен быть конструктор, который принимает ширину и высоту, сохраняет их в поля.Затем, вычисляет площадь 
            //и сохраняет в поле
            //•Пометить поле площадь как NonSerialized
            //•Попробовать сериализовать объект класса Rectangle в файл, а затем десериализовать его из файла. И чтобы площадь при этом заполнилась
            //•Используйте методы с атрибутами OnSerializing, OnDeserialized

            Console.WriteLine("Задача 1. Сериализация/десериализация объекта");
            SolveTask1();
            Console.WriteLine();

            // Задача 2
            //•Создать класс симметричной двумерной матрицы целых чисел размера NxN – чтобы имел поле - двумерный массив
            //•Написать метод, который заполняет матрицу одного такого объекта
            //•Сделать данный класс сериализуемым, записать результат файл
            //•Затем, воспользоваться фактом, что матрица симметричная, и переопределить механизм сериализации, 
            //чтобы в поток записывалась только половина матрицы
            //•Сериализовать и десериализовать объект в файл, используя эти методы
            //•Сравнить размер файла

            Console.WriteLine("Задача 2. Пользовательская Сериализация/десериализация объекта");
            SolveTask2();
            Console.WriteLine();
        }

        static void SolveTask2()
        {
            double[,] matrix =
            {
                {1, 2, 3 },
                {2, 4, 5 },
                {3, 5, 6 }
            };

            MatrixNN matrixNN = new MatrixNN(matrix);

            Console.WriteLine("Исходная матрица:");
            Console.WriteLine(matrixNN);

            BinaryFormatter formatter = new BinaryFormatter();

            // пользовательская сериализация
            string userFileName = "task2user";
            using (Stream stream = new FileStream(userFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, matrixNN);
            }

            MatrixNN matrixNN2 = new MatrixNN();
            using (Stream stream = new FileStream(userFileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                matrixNN2 = (MatrixNN)formatter.Deserialize(stream);
            }

            Console.WriteLine("Результат пользовательской сериализации. Размер файла: {0} байт ", new FileInfo(userFileName).Length);
            Console.WriteLine(matrixNN2);

            // стандартная сериализация
            MatrixNN2 matrixNN3 = new MatrixNN2(matrix);

            string standartFileName = "task2standart";
            using (Stream stream = new FileStream(standartFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, matrixNN3);
            }

            MatrixNN2 matrixNN4 = new MatrixNN2();
            using (Stream stream = new FileStream(standartFileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                matrixNN4 = (MatrixNN2)formatter.Deserialize(stream);
            }

            Console.WriteLine("Результат стандартной сериализации. Размер файла: {0} байт", new FileInfo(standartFileName).Length);
            Console.WriteLine(matrixNN4);
        }

        static void SolveTask1()
        {
            string fileName = "serialize";

            double height = 10;
            double width = 5;
            Rectangle rectangle = new Rectangle(height, width);

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, rectangle);
            }

            Console.WriteLine(rectangle);

            Rectangle rectangle2;

            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                rectangle2 = (Rectangle)formatter.Deserialize(stream);
            }

            Console.WriteLine(rectangle2);
        }
    }
}
