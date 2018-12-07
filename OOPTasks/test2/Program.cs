using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        public static void Main()
        {

            int[] a = new int[3] {3,4,5 };
            Console.WriteLine(String.Join(", ",a));

            int[] b = new int[2] {1,1 };
            Console.WriteLine(String.Join(", ", a));


            Array.Copy(a,b,3);
            Console.WriteLine(String.Join(", ", b));



            //    // Creates and initializes two new Arrays.
            //    Array mySourceArray = Array.CreateInstance(typeof(String), 6);
            //    mySourceArray.SetValue("three", 0);
            //    mySourceArray.SetValue("napping", 1);
            //    mySourceArray.SetValue("cats", 2);
            //    mySourceArray.SetValue("in", 3);
            //    mySourceArray.SetValue("the", 4);
            //    mySourceArray.SetValue("barn", 5);
            //    Array myTargetArray = Array.CreateInstance(typeof(String), 15);
            //    myTargetArray.SetValue("The", 0);
            //    myTargetArray.SetValue("quick", 1);
            //    myTargetArray.SetValue("brown", 2);
            //    myTargetArray.SetValue("fox", 3);
            //    myTargetArray.SetValue("jumps", 4);
            //    myTargetArray.SetValue("over", 5);
            //    myTargetArray.SetValue("the", 6);
            //    myTargetArray.SetValue("lazy", 7);
            //    myTargetArray.SetValue("dog", 8);

            //    // Displays the values of the Array.
            //    Console.WriteLine("The target Array contains the following (before and after copying):");
            //    PrintValues(myTargetArray, ' ');

            //    // Copies the source Array to the target Array, starting at index 6.
            //    mySourceArray.CopyTo(myTargetArray, 6);

            //    // Displays the values of the Array.
            //    PrintValues(myTargetArray, ' ');
            //}


            //public static void PrintValues(Array myArr, char mySeparator)
            //{
            //    System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
            //    int i = 0;
            //    int cols = myArr.GetLength(myArr.Rank - 1);
            //    while (myEnumerator.MoveNext())
            //    {
            //        if (i < cols)
            //        {
            //            i++;
            //        }
            //        else
            //        {
            //            Console.WriteLine();
            //            i = 1;
            //        }
            //        Console.Write("{0}{1}", mySeparator, myEnumerator.Current);
            //    }
            //    Console.WriteLine();
        }
    }
}
