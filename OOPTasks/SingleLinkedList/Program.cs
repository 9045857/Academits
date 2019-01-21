using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    class Program
    {
        internal static void PrintList(SingleLinkedList<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.AddFirst(i * 12);
            }

            PrintList(list);

            list[3] = 100;

            Console.WriteLine();
            PrintList(list);

            list.InsertTo(3, 500);

            Console.WriteLine();
            PrintList(list);

            list.InsertTo(0, 5000);

            Console.WriteLine();
            Console.WriteLine("Количество: " + list.Count);
            PrintList(list);

            Console.WriteLine();
            list.Remove(5000);
            list.Remove(500);
            Console.WriteLine("Количество: " + list.Count);
            PrintList(list);

            Console.WriteLine();
            Console.WriteLine("разворот списка");

            list.Reverse();
            PrintList(list);

            Console.WriteLine();
            Console.WriteLine("копирование списка");

            SingleLinkedList<int> listForCopy = new SingleLinkedList<int>();

            SingleLinkedList<int>.Copy(list, listForCopy);

            PrintList(listForCopy);


            //• Тестирование Изменение значения по индексу пусть выдает старое значение.
            Console.WriteLine();

            int indexForReplace = 3;
            int newValue = 333;

            Console.WriteLine("заменим {0} - {1} элемент списка на {2}", listForCopy.Replace(indexForReplace, newValue), indexForReplace, newValue);

            PrintList(listForCopy);

            //•	Тестирование удаление элемента по индексу, пусть выдает значение элемента
            Console.WriteLine();

            int indexForRemove = 3;

            Console.WriteLine("удалим {0} - {1} элемент списка", listForCopy.RemoveAt(indexForRemove), indexForRemove);

            PrintList(listForCopy);

            Console.WriteLine("Количество {0}", listForCopy.Count);

        }
    }
}
