using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Graph graph = new Graph(graphArray);

            Action<int> action = Console.WriteLine;

            Console.WriteLine("Обход в ширину");
            graph.BreadthFirstSearch(2, action);

            Console.WriteLine("Обход в глубину");
            graph.DepthFirstSearch(2, action);

            Console.WriteLine("Обход в глубину с Рекурсией");
            graph.DepthFirstSearchRecursion(2, action);
        }
    }
}
