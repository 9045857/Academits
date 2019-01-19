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
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void Main(string[] args)
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.AddFirst(i*12);
            }

            PrintList(list);

            list[3] = 100;

            Console.WriteLine();
            PrintList(list);

            list.InsertTo(3,500);

            Console.WriteLine();
            PrintList(list);

            list.InsertTo(0, 5000);

            Console.WriteLine();
            Console.WriteLine("Количество: "+list.Count);
            PrintList(list);

            Console.WriteLine();
            list.Remove(5000);
            list.Remove(500);
            Console.WriteLine("Количество: " + list.Count);
            PrintList(list);


        }
    }
}
