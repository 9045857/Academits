using System;
using System.Collections;

namespace ConsoleApplication1
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
            //Console.Write("������� ���� �������? ");
            //int i = int.Parse(Console.ReadLine());

            //Letter lt = new Letter(i);
            //Console.WriteLine("\n���������: \n");

            //foreach (char c in lt)
            //    Console.Write(c + " ");

            //Console.Write("\n������� �������\n\nMin: ");
            //int j = int.Parse(Console.ReadLine());
            //Console.Write("Max: ");
            //int y = int.Parse(Console.ReadLine());
            //Console.WriteLine("\n���������: \n");

            //foreach (char c in lt.MyItr(j, y))
            //    Console.Write(c + " ");



            //Console.WriteLine();

            //Console.WriteLine();

            //char qw = 'G';
            //char iq =(char) (qw + 1);

            //Console.WriteLine(iq);


            string[] starray1 = new string[3] { "������ �����", "������ �������", "�������" };

            string[] starray2 = new string[3];

            Array.Copy(starray1, starray2, starray1.Length);

            PrintArray(starray1);
            Console.WriteLine();
            PrintArray(starray2);

            starray1[1]="kkkk";

            Console.WriteLine();

            PrintArray(starray1);
            Console.WriteLine();
            PrintArray(starray2);

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