using System;
using System.IO;
using System.Collections.Generic;

namespace TArrayListHome
{
    class Program
    {
        static void Main()
        {
            try
            {
                //1.Прочитать в список все строки из файла

                Console.WriteLine("-= 1. Построчное заполнение списка на массиве из файла =-");
                Console.WriteLine();
                Console.WriteLine("-------с помощью get-/set-ера-----------");

                using (StreamReader reader = new StreamReader("poem.txt", System.Text.Encoding.Default))
                {
                    MyListOnArray<string> textLines = new MyListOnArray<string>();

                    string currentTextLine;
                    int i = 0;
                    while ((currentTextLine = reader.ReadLine()) != null)
                    {
                        textLines[i] = currentTextLine;
                        i++;
                    }

                    for (int j = 0; j < i; j++)
                    {
                        Console.WriteLine(textLines[j]);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("-----------с помощью методов Add / get--------------");
                Console.WriteLine();

                using (StreamReader reader = new StreamReader("poem.txt", System.Text.Encoding.Default))
                {
                    MyListOnArray<string> textLines = new MyListOnArray<string>();

                    string currentTextLine;
                    while ((currentTextLine = reader.ReadLine()) != null)
                    {
                        textLines.Add(currentTextLine);
                    }

                    for (int i = 0; i < textLines.Count; i++)
                    {
                        Console.WriteLine(textLines[i]);
                    }
                }

                //2.Есть список из целых чисел. Удалить из него все четные числа. В этой задаче новый список создавать нельзя

                Console.WriteLine();
                Console.WriteLine("----------- Использование стандартного списка на массиве  --------------");
                Console.WriteLine();

                using (StreamReader reader = new StreamReader("poem.txt", System.Text.Encoding.Default))
                {
                    List<string> textLines2 = new List<string>();// TODO вопрос: данный список будет виден только в пределах фигурных скобок?

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

                Console.WriteLine();
                Console.WriteLine("-----=== 2.  Создание списка целых чисел и удаление из него четных  ===-----");
                Console.WriteLine();

                List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                PrintIntList(intList);
                Console.WriteLine();

                foreach (int element in intList.ToArray())
                {
                    if (element % 2 == 0)
                    {
                        intList.Remove(element);
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

                List<int> intList2 = new List<int>() { 1, 5, 2, 1, 3, 5 };

                Console.Write("Исходный список: ");
                PrintIntList(intList2);
                Console.WriteLine();

                List<int> intList3 = new List<int>();

                foreach (int element in intList2)
                {
                    if (!intList3.Contains(element)) 
                    {
                        intList3.Add(element);
                    }
                }

                Console.Write("Скопированный массив: ");
                PrintIntList(intList3);
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        private static void PrintIntList(List<int> list)
        {
            foreach (int element in list)
            {
                Console.Write(element);
                Console.Write("  ");
            }
        }

    }
}
