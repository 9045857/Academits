using System;
using System.IO;
using System.Collections.Generic;

namespace TArrayListHome
{
    class Program
    {
        static void Main()
        {
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

            Console.WriteLine();
            Console.WriteLine("-----=== 2.  Создание списка целых чисел и удаление из него четных  ===-----");
            Console.WriteLine();




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
