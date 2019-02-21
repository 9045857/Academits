using System;
using System.Collections.Generic;

namespace Graph
{
    class Graph
    {
        private int[,] graph;

        public Graph(int[,] graph)
        {
            if (graph.GetLength(0) != graph.GetLength(1))
            {
                throw new ArgumentException("ОШИБКА: конструктору графа передана не квадратная матрица связнности");
            }

            Count = graph.GetLength(0);
            this.graph = Get2DIntArrayCopy(graph);
        }

        public int Count { get; private set; }

        private int[,] Get2DIntArrayCopy(int[,] sourceArray)
        {
            int[,] destinationArray = new int[sourceArray.GetLength(0), sourceArray.GetLength(1)];

            for (int i = 0; i < destinationArray.GetLength(0); i++)
            {
                for (int j = 0; j < destinationArray.GetLength(1); j++)
                {
                    destinationArray[i, j] = sourceArray[i, j];
                }
            }

            return destinationArray;
        }

        public virtual void DepthFirstSearch(int startIndex, Action<int> action)
        {
            if (startIndex < 0 || startIndex >= Count)
            {
                throw new IndexOutOfRangeException("ОШИБКА: стартовый индекс ОБХОДА В ГЛУБИНУ вне диапазона индексов графа");
            }

            bool[] isVisited = new bool[Count];

            Stack<int> stackSearch = new Stack<int>();
            stackSearch.Push(startIndex);

            isVisited[startIndex] = true;

            int startVisitedIndexCheck = 0;
            while (stackSearch.Count != 0)
            {
                int currentIndex = stackSearch.Pop();
                action(currentIndex);

                for (int j = Count - 1; j >= 0; j--)
                {
                    if (graph[currentIndex, j] != 0 && !isVisited[j])
                    {
                        stackSearch.Push(j);
                        isVisited[j] = true;
                    }
                }

                if (stackSearch.Count == 0)
                {
                    for (int k = startVisitedIndexCheck; k < Count; k++)
                    {
                        if (!isVisited[k])
                        {
                            startVisitedIndexCheck = k + 1;

                            stackSearch.Push(k);
                            isVisited[k] = true;

                            break;
                        }
                    }
                }
            }
        }

        private void RecursiveVisit(int index, int[,] graph, bool[] isVisited, Action<int> action)
        {
            action(index);

            for (int i = 0; i < Count; i++)
            {
                if (graph[index, i] != 0 && !isVisited[i])
                {
                    isVisited[i] = true;
                    RecursiveVisit(i, graph, isVisited, action);
                }
            }
        }

        public virtual void DepthFirstSearchRecursion(int startIndex, Action<int> action)
        {
            if (startIndex < 0 || startIndex >= Count)
            {
                throw new IndexOutOfRangeException("ОШИБКА: стартовый индекс ОБХОДА В ГЛУБИНУ вне диапазона индексов графа");
            }

            bool[] isVisited = new bool[Count];

            int index = startIndex;
            isVisited[index] = true;

            int startVisitedIndexCheck = 0;
            bool isProcessDoing = true;

            while (isProcessDoing)
            {
                RecursiveVisit(index, graph, isVisited, action);

                isProcessDoing = false;

                for (int i = startVisitedIndexCheck; i < Count; i++)
                {
                    if (!isVisited[i])
                    {
                        startVisitedIndexCheck = i + 1;
                        index = i;

                        isVisited[i] = true;
                        isProcessDoing = true;

                        break;
                    }
                }
            }
        }

        public virtual void BreadthFirstSearch(int startIndex, Action<int> action)
        {
            if (startIndex < 0 || startIndex >= Count)
            {
                throw new IndexOutOfRangeException("ОШИБКА: стартовый индекс ОБХОДА В ШИРИНУ вне диапазона индексов графа");
            }

            bool[] isVisites = new bool[Count];

            Queue<int> queueSearch = new Queue<int>();
            queueSearch.Enqueue(startIndex);
            isVisites[startIndex] = true;

            int startVisitedIndexCheck = 0;
            while (queueSearch.Count != 0)
            {
                int currentIndex = queueSearch.Dequeue();
                action(currentIndex);

                for (int j = 0; j < Count; j++)
                {
                    if (graph[currentIndex, j] != 0 && !isVisites[j])
                    {
                        queueSearch.Enqueue(j);
                        isVisites[j] = true;
                    }
                }

                if (queueSearch.Count == 0)
                {
                    for (int k = startVisitedIndexCheck; k < Count; k++)
                    {
                        if (!isVisites[k])
                        {
                            queueSearch.Enqueue(k);
                            isVisites[k] = true;
                            startVisitedIndexCheck = k + 1;

                            break;
                        }
                    }
                }
            }
        }
    }
}
