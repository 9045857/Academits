
using L2Shapes;
using L2Shapes.Shapes;
using L2Shapes.ShapesComparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {

            //Square s = new Square(10.0d);

            //TreeNode<IShape> r = new TreeNode<IShape>(s);
            //ShapesAreaComparer comparer = new ShapesAreaComparer();

            //Tree<IShape> tree = new Tree<IShape>(r, comparer);

            //Circle s1 = new Circle(9.0d);

            //tree.AddNode(s1);


            int[] arrayInt = {3,4,1,3,2,0,7 };

            Tree<int> tree = new Tree<int>(5);

            foreach (int element in arrayInt)
            {
                tree.AddNode(element);
            }

            Console.WriteLine(tree.Contains(0));
            Console.WriteLine(tree.Contains(6));

            Action<int> action = Console.WriteLine;

            Console.WriteLine("Обход в ширину без рекурсии");
            tree.BreadthFirstSearch(action);

            Console.WriteLine("Обход в глубину без рекурсии");
            tree.DepthFirstSearch(action);

            Console.WriteLine("Обход в глубину с рекурсией");
            tree.DepthFirstSearchRecursion(action);

            Console.WriteLine("Удалим 2 и обойдем в ширину");
            tree.Remove(2);
            tree.BreadthFirstSearch(action);
        }
    }
}
