using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = new int [4]{2,3,4,5 };
            a = new int[7];
            Console.WriteLine(string.Join(", ",a));
        }
    }
}
