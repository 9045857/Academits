using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[10];
            foreach (int element in a)
            {
                Console.WriteLine(element);
            }

            Vector v = new Vector(a);



        }
    }
}
