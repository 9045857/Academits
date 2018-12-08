using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] array = new double[4][];
            array[0] =new double[3]{ 1, 2, 3 };
            array[1] = new double[3] { 2, 2, 2 };
            array[2] = new double[3] { 5, 5, 5 };
            array[3] = new double[3] { 1, 5, 7 };

            Matrix matrix = new Matrix(array);


            Console.WriteLine(matrix);
        }
    }
}
