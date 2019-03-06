using System;
using System.Collections.Generic;
using System.Threading;

namespace L19Threads
{
    class Program
    {
        private static readonly object locker = new object();
        
        static void Main(string[] args)
        {
            //            Задача 1
            //•Написать программу, которая создает второй поток, который печатает числа от 1 до 10, 
            //числа должны печататься раз в секунду
            //•При этом основной поток должен напечатать строку «Исполнение продолжено» после того, 
            //как завершится созданный поток
            //•Код для потока задайте через лямбду
            Console.WriteLine("Задача 1. Два потока.");

            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i + 1);
                    Thread.Sleep(1000);
                }
            });

            thread.Start();
            thread.Join();

            Console.WriteLine("«Исполнение продолжено»");
            Console.WriteLine();

            //            Задача 2
            //•Объявить список чисел, вначале он пустой.Создать два потока
            //•Потоки берут текущую длину списка и вставляют по этому индексу новый элемент. 
            //Каждый поток должен вставить 100 элементов от 1 до 100.
            //•Сделать версию без синхронизации. Убедиться что иногда потоки конфликтуют –
            //перезаписывают по одному и тому же индексу.Вывести длину списка.
            //•После этого добавить синхронизацию, убедиться, что проблема исчезла.

            Console.WriteLine("Задача 2. Оператор lock.");

            List<int> indexList = new List<int>();

            Action action = () =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    indexList.Insert(indexList.Count, i);
                    Thread.Sleep(1);
                }
            };

            Thread thread1 = new Thread(new ThreadStart(action));
            Thread thread2 = new Thread(new ThreadStart(action));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Количество элементов в списке: {0}", indexList.Count);

            foreach (int element in indexList)
            {
                Console.Write(element);
                Console.Write(" ");
            }

            ////•После этого добавить синхронизацию, убедиться, что проблема исчезла.

            List<int> indexList2 = new List<int>();

            Action action2 = () =>
            {
                lock (locker)
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        indexList2.Insert(indexList2.Count, i);
                        Thread.Sleep(1);
                    }
                }
            };

            Thread thread3 = new Thread(new ThreadStart(action2));
            Thread thread4 = new Thread(new ThreadStart(action2));

            thread3.Start();
            thread4.Start();

            thread3.Join();
            thread4.Join();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Количество элементов в списке: {0}", indexList2.Count);

            foreach (int element in indexList2)
            {
                Console.Write(element);
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}
