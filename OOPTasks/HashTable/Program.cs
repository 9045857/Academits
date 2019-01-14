using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // начальные данные для теста
            string beginText = "Осенью имя рэпера часто упоминалось в отечественных СМИ СМИ";
            string[] beginArrayWords = beginText.Split(' ');

            //создание и заполнение хэш-таблицы
            HashTable<string> testHashTable = new HashTable<string>(beginArrayWords.Length);

            foreach (string word in beginArrayWords)
            {
                testHashTable.Add(word);
            }

            Console.WriteLine(testHashTable);
            Console.WriteLine();

            // тестируем количество элементов
            Console.Write("Количество элементов: ");
            Console.WriteLine(testHashTable.Count);
            Console.WriteLine();

            //тестируем удаление элемента
            Console.WriteLine("удалим \"в\"");

            testHashTable.Remove("в");

            Console.WriteLine(testHashTable);
            Console.WriteLine();

            Console.WriteLine("удалим отсутствующий элемент \"о\"");

            testHashTable.Remove("о");

            Console.WriteLine(testHashTable);
            Console.WriteLine();

            //тестируем итератор
            Console.WriteLine("-=тестируем итератор=-");
            try
            {
                foreach (string element in testHashTable)
                {
                    Console.WriteLine(element);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("-=тестируем исключение из итератора=-");
            try
            {
                foreach (string element in testHashTable)
                {
                    Console.WriteLine(element);
                    testHashTable.Remove(element);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            //тестируем копирование в массив
            Console.WriteLine("-=тестируем копирование в массив=-");

            string[] testArray = new string[testHashTable.Count];

            testHashTable.CopyTo(testArray, 0);

            foreach (string element in testArray)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
            // тестируем исключения копирования в массив
            Console.WriteLine("-=тестируем исключения при копировании в массив=-");

            try
            {
                testHashTable.CopyTo(testArray, -1);
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (ArgumentOutOfRangeException e2)
            {
                Console.WriteLine(e2.Message);
            }
            catch (ArgumentException e3)
            {
                Console.WriteLine(e3.Message);
            }

            Console.WriteLine();

            string[] testArray1 = new string[testHashTable.Count - 1];
            try
            {
                testHashTable.CopyTo(testArray1, 0);
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (ArgumentOutOfRangeException e2)
            {
                Console.WriteLine(e2.Message);
            }
            catch (ArgumentException e3)
            {
                Console.WriteLine(e3.Message);
            }

            Console.WriteLine();

            string[] testArray2 = null;
            try
            {
                testHashTable.CopyTo(testArray2, 0);
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (ArgumentOutOfRangeException e2)
            {
                Console.WriteLine(e2.Message);
            }
            catch (ArgumentException e3)
            {
                Console.WriteLine(e3.Message);
            }

            Console.WriteLine();

            //тестируем очистку            
            Console.WriteLine("очистка");

            testHashTable.Clear();

            Console.WriteLine(testHashTable);
            Console.WriteLine();

            //тестируем на работы с null            
            Console.WriteLine("-=тестируем на работы с null=-");

            Console.WriteLine();

            testHashTable.Add(null);
            testHashTable.Add(null);
            testHashTable.Add(null);

            Console.WriteLine(testHashTable);
            Console.WriteLine();

            testHashTable.Remove(null);

            Console.WriteLine(testHashTable);
            Console.WriteLine();
        }
    }
}
