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
            testHashTable.Remove("в");

            Console.WriteLine("удалим \"в\"");
            Console.WriteLine(testHashTable);
            Console.WriteLine();

            testHashTable.Remove("о");

            Console.WriteLine("удалим \"о\"");
            Console.WriteLine(testHashTable);
            Console.WriteLine();

            //тестируем очистку

            testHashTable.Clear();

            Console.WriteLine("очистка");
            Console.WriteLine(testHashTable);
            Console.WriteLine();
        }
    }
}
