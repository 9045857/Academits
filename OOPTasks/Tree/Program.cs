using System;

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


            int[] arrayInt = { 3, 4, 1, 3, 2, 0, 7 };

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

            Console.WriteLine("Удалим 2 и обойдем в глубину");
            tree.Remove(2);
            tree.DepthFirstSearch(action);

            Console.WriteLine("Удалим корень 5 и обойдем в глубину");
            tree.Remove(5);
            tree.DepthFirstSearch(action);

            Console.WriteLine("Дерево с одним элементом");
            Tree<int> tree2 = new Tree<int>(111);
            tree2.DepthFirstSearch(action);

            Console.WriteLine("удалим корень");
            tree2.Remove(111);
            tree2.DepthFirstSearch(action);

            Console.WriteLine("Конец");

            Console.WriteLine("Дерево только с правой веткой");
            Tree<int> tree3 = new Tree<int>(0);

            tree3.AddNode(1);
            tree3.AddNode(2);
            tree3.AddNode(3);
            tree3.AddNode(4);
            tree3.AddNode(5);

            tree3.DepthFirstSearch(action);

            Console.WriteLine("удалим 3");
            tree3.Remove(3);

            tree3.DepthFirstSearch(action);
            tree3.BreadthFirstSearch(action);

            Console.WriteLine("Дерево только с левой веткой");
            tree2.AddNode(10);
            tree2.AddNode(9);
            tree2.AddNode(8);
            tree2.AddNode(7);
            tree2.AddNode(6);
            tree2.AddNode(5);

            tree2.BreadthFirstSearch(action);

            Console.WriteLine("Удалим корень");
            tree2.Remove(10);

            tree2.BreadthFirstSearch(action);

            Console.ReadLine();
        }
    }
}
