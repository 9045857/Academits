using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nodes = { 1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7 };

            int[,] graphArray = //несвзянный граф из лекции, добавлен путь A-С
            {
                {0, 1, 1, 0, 0, 0, 0 },
                {1, 0, 1, 0, 0, 0, 0 },
                {1, 1, 0, 1, 0, 0, 0 },
                {0, 0, 1, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 1 },
                {0, 0, 0, 0, 0, 1, 0 }
            };




        }
    }
}
