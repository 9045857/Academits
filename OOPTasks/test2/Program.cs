using System;
using System.Collections;
using System.Linq;


namespace test2
{
    class Letter
    {
        char ch = '�';
        int end;

        public Letter(int end)
        {
            this.end = end;
        }

        // ��������, ������������ end-����
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.end; i++)
            {
                if (i == 33) yield break; // ����� �� ���������, ���� ���������� �������
                yield return (char)(ch + i);
            }
        }

        // �������� ������������ ���������
        public IEnumerable MyItr(int begin, int end)
        {
            for (int i = begin; i <= end; i++)
            {
                yield return (char)(ch + i);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ////Console.Write("������� ���� �������? ");
            ////int i = int.Parse(Console.ReadLine());

            ////Letter lt = new Letter(i);
            ////Console.WriteLine("\n���������: \n");

            ////foreach (char c in lt)
            ////    Console.Write(c + " ");

            ////Console.Write("\n������� �������\n\nMin: ");
            ////int j = int.Parse(Console.ReadLine());
            ////Console.Write("Max: ");
            ////int y = int.Parse(Console.ReadLine());
            ////Console.WriteLine("\n���������: \n");

            ////foreach (char c in lt.MyItr(j, y))
            ////    Console.Write(c + " ");



            ////Console.WriteLine();

            ////Console.WriteLine();

            ////char qw = 'G';
            ////char iq =(char) (qw + 1);

            ////Console.WriteLine(iq);


            //string[] starray1 = new string[3] { "������ �����", "������ �������", "�������" };

            //string[] starray2 = new string[3];

            //Array.Copy(starray1, starray2, starray1.Length);

            //PrintArray(starray1);
            //Console.WriteLine();
            //PrintArray(starray2);

            //starray1[1] = "kkkk";

            //Console.WriteLine();

            //PrintArray(starray1);
            //Console.WriteLine();
            //PrintArray(starray2);
            //Console.WriteLine();


            //// ���������, ��� ����� ���� ����������� ������� generic-��

            //Person[] people1 = new Person[3];

            //people1[0] = new Person { Age = 10, Sex = true, Name = "A" };
            //people1[1] = new Person { Age = 20, Sex = false, Name = "B" };
            //people1[2] = new Person { Age = 30, Sex = true, Name = "C" };

            //Person[] people2 = new Person[3];

            //Array.Copy(people1, people2,people1.Length);

            //PrintPeople(people1);

            //Console.WriteLine();

            //PrintPeople(people2);

            //Console.WriteLine("������ ������� �������� � �������� 1 � ������ �������. �������, ��� ��������� �� ������");

            //people1[1].Age = 110;

            //PrintPeople(people2);

            var collection = new[] { "d2", "a2", "b1" }
            .Where(s => 
            {
                Console.WriteLine("filter: " + s);
                return true;
            });

            foreach (var s in collection)
            {
                Console.WriteLine("forEach: " + s);
            }

        }

        private static void PrintPeople(Person[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine("{0}: {1}, {2}, {3}", i, items[i].Age,items[i].Name,items[i].Sex);
            }
        }

        private static void PrintArray(string[] starray1)
        {
            foreach (string element in starray1)
            {
                Console.WriteLine(element);
            }
        }
    }
}