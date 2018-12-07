using System;

namespace L2Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* �������� ���������^
                 - ������ 4 ������� ����� ������������
                 - ������ ������ ��������� ����� GetCoordinate
                 - �������� ����� ToString
                 - ���������� 2 ���� �������� (������ � �� ������)
                 - �������������� �������� � ���������: ��������, ���������, ��������� � ��.
                 - ��������� ����������� ������ �������� � �.�.
                 - ��������� ����������                 
                  */

                //-������ 4 ������� ����� ������������
                //-�������� ����� ToString

                Vector vector1 = new Vector(6);
                Vector vector2 = new Vector(new double[] { 10, 1, 10, 0 });
                Vector vector3 = new Vector(vector2);
                Vector vector4 = new Vector(7, new double[] { 1, 3, 5, 7 });

                Console.WriteLine("������ �������");
                Console.WriteLine("Vector(int n)                  {0}", vector1);
                Console.WriteLine("Vector(double[] array)         {0}", vector2);
                Console.WriteLine("Vector(Vector vector)          {0}", vector3);
                Console.WriteLine("Vector(int n, Vector vector)   {0}", vector4);
                Console.WriteLine();

                //- ������ ������ ��������� ����� SetCoordinate
                Console.WriteLine("������������ ������ ������ ����� SetCoordinate() � ����������� ����� GetCoordinate()");

                int startNumber = 21;
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    vector1.SetCoordinate(i, startNumber + i);
                }

                for (int i = 0; i < vector1.GetSize() - 1; i++)
                {
                    Console.Write(vector1.GetCoordinate(i));
                    Console.Write(", ");
                }
                Console.Write(vector1.GetCoordinate(vector1.GetSize() - 1));
                Console.WriteLine();
                Console.WriteLine();

                //-���������� 2 ���� ��������(������ � �� ������)
                Console.WriteLine("��������� ��������");

                Console.WriteLine("{0} = {1}: {2}", vector1, vector4, vector1.Equals(vector4));
                Console.WriteLine("{0} = {1}: {2}", vector2, vector3, vector2.Equals(vector3));
                Console.WriteLine();

                //-�������������� �������� � ���������: ��������, ���������, ���������, ������.
                Console.WriteLine("�������������� �������� - ������������� ������");

                Console.Write("vector2.AddVector(vector1)      {0} + {1} = ", vector2, vector1);
                Console.WriteLine(vector2.AddVector(vector1));

                Console.Write("vector2.SubtractVector(vector3) {0} - {1} = ", vector2, vector3);
                Console.WriteLine(vector2.SubtractVector(vector3));

                Console.Write("vector3.MultiplyBy(number)      {0} * {1} = ", vector3, 3);
                Console.WriteLine(vector3.MultiplyBy(3));

                Console.Write("vector4.Reverse()               {0}  �������� -> ", vector4);
                Console.WriteLine(vector4.Reverse());

                Console.WriteLine();

                //-��������� ����������� ������ �������� � �.�.
                Console.WriteLine("�������������� �������� ����� ����������� ������");

                Console.WriteLine("GetAddition(vector1, vector2)        {0} + {1} = {2}", vector1, vector2, Vector.GetAddition(vector1, vector2));
                Console.WriteLine("GetDifference(vector2, vector3)      {0} - {1} = {2}", vector2, vector3, Vector.GetDifference(vector2, vector3));
                Console.WriteLine("GetScalarProduct(vector1, vector3)   {0} * {1} = {2}", vector1, vector3, Vector.GetScalarProduct(vector1, vector3));

                Console.WriteLine();

                //-��������� ����������

                //Vector vector5 = new Vector(-2); // ���������� �� ������������� ����������� �������
                // Vector vector6 = new Vector(-3, new double[] { 1, 3, 5, 7, 9 });// ���������� �� ������������� ����������� �������
                // Vector vector6 = new Vector(3, null);// ���������� ������ null
                Vector vector6 = new Vector(3, new double[0]);// ���������� �� ������ �������� 0

                // Console.Write(vector1.GetCoordinate(100)); //"������ � GetCoordinate(int index): ���������� � ������� ����������� �������"//IndexOutOfRangeException
                // vector1.SetCoordinate(-1, 12);  //"������ � SetCoordinate(int index,double value): ���������� ����������� ������� ��� ������� ����������"//IndexOutOfRangeException
                // vector1.SetCoordinate(100, 12);  //"������ � SetCoordinate(int index,double value): ���������� ����������� ������� ��� ������� ����������"//IndexOutOfRangeException

                //vector1 = new Vector(-2);// OverflowException
                // vector4 = new Vector(-4, new double[] { 1, 3, 5, 7, 9 });//System.OverflowException

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }
    }
}
