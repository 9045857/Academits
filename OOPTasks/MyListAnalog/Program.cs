using System;
using System.IO;

namespace MyListAnalog
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Прочитать в список все строки из файла
            Console.WriteLine();
            Console.WriteLine("----------- Использование стандартного списка на массиве  --------------");
            Console.WriteLine();
            try
            {
                string fileName = "poem.txt";

                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.Default))
                    {
                        MyListOnArray<string> textLines2 = new MyListOnArray<string>();

                        string currentTextLine;
                        while ((currentTextLine = reader.ReadLine()) != null)
                        {
                            textLines2.Add(currentTextLine);
                        }

                        foreach (string line in textLines2)
                        {
                            Console.WriteLine(line);
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: файл {0} отсутствует", fileName);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //2.Есть список из целых чисел. Удалить из него все четные числа. В этой задаче новый список создавать нельзя
            Console.WriteLine();
            Console.WriteLine("-----=== 2.  Создание списка целых чисел и удаление из него четных  ===-----");
            Console.WriteLine();

            MyListOnArray<int> intList = new MyListOnArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            PrintIntList(intList);
            Console.WriteLine();

            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i] % 2 == 0)
                {
                    intList.Remove(intList[i]);
                    i--;
                }
            }

            PrintIntList(intList);
            Console.WriteLine();

            //3.Есть список из целых чисел, в нём некоторые числа могут повторяться.
            //Надо создать новый список, в котором будут элементы первого списка в таком же порядке, 
            //но без повторений Например, был список[1, 5, 2, 1, 3, 5], должен получиться новый список[1, 5, 2, 3]

            Console.WriteLine();
            Console.WriteLine("-----=== 3. Копирование списка без повторений  ===-----");
            Console.WriteLine();

            MyListOnArray<int> intList2 = new MyListOnArray<int> { 1, 5, 2, 1, 3, 5 };

            Console.Write("Исходный список: ");
            PrintIntList(intList2);
            Console.WriteLine();

            MyListOnArray<int> intList3 = new MyListOnArray<int>();

            foreach (int element in intList2)
            {
                if (!intList3.Contains(element))
                {
                    intList3.Add(element);
                }
            }

            Console.Write("Скопированный список: ");
            PrintIntList(intList3);
            Console.WriteLine();
            Console.WriteLine();

            // проверка копирования в массив

            int[] intArray = new int[10];

            try
            {
                intList3.CopyTo(intArray,2);// изменяя индекс начала можно проверить на работу исключений

                // изменяя индекс начала можно проверить на работу исключений:
                //intList3.CopyTo(intArray, -1);
                //intList3.CopyTo(intArray, 20);
                //intList3.CopyTo(intArray, 9);

                PrintIntArray(intArray);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                // тест работы исключения в случае изменения списка во время foreach

                foreach (int element in intList2)
                {
                    if (element == 2)
                    {
                        intList2.Remove(element);
                    }

                    Console.Write(element);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintIntArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element);
                Console.Write("  ");
            }
        }

        private static void PrintIntList(MyListOnArray<int> list)
        {
            foreach (int element in list)
            {
                Console.Write(element);
                Console.Write("  ");
            }
        }
    }
}
