using System;
using System.Collections.Generic;

namespace Graph
{
    class Graph
    {
        private int[,] graphs;

        public Graph(int[,] graphs)
        {
            Count = graphs.GetLength(0);
            this.graphs = Get2DIntArrayCopy(graphs);
        }

        public virtual int Count { get; private set; }

        private int[,] Get2DIntArrayCopy(int[,] sourceArray)
        {
            int[,] destinationArray = new int[sourceArray.GetLength(0), sourceArray.GetLength(1)];

            for (int i = 0; i < destinationArray.GetLength(0); i++)
                for (int j = 0; j < destinationArray.GetLength(1); j++)
                {
                    destinationArray[i, j] = sourceArray[i, j];
                }

            return destinationArray;
        }

        public virtual void DepthFirstSearch(int startIndex, Action<int> action)
        {
            if (startIndex < 0 || startIndex >= Count)
            {
                throw new IndexOutOfRangeException("ОШИБКА: стартовый индекс ОБХОДА В ГЛУБИНУ вне диапазона индексов графа");
            }

            bool[] isVisites = new bool[Count];

            Stack<int> stackSearch = new Stack<int>();
            stackSearch.Push(startIndex);

            isVisites[startIndex] = true;

            while (stackSearch.Count != 0)
            {
                int currentIndex = stackSearch.Pop();
                action(currentIndex);

                for (int j = 0; j < Count; j++)
                {
                    if (graphs[currentIndex, j] != 0 && !isVisites[j])
                    {
                        stackSearch.Push(j);
                        isVisites[j] = true;
                    }
                }

                if (stackSearch.Count == 0)
                {
                    for (int k = 0; k < Count; k++)
                    {
                        if (!isVisites[k])
                        {
                            stackSearch.Push(k);
                            isVisites[k] = true;

                            break;
                        }
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

            while (queueSearch.Count != 0)
            {
                int currentIndex = queueSearch.Dequeue();
                action(currentIndex);

                for (int j = 0; j < Count; j++)
                {
                    if (graphs[currentIndex, j] != 0 && !isVisites[j])
                    {
                        queueSearch.Enqueue(j);
                        isVisites[j] = true;
                    }
                }

                if (queueSearch.Count == 0)
                {
                    for (int k = 0; k < Count; k++)
                    {
                        if (!isVisites[k])
                        {
                            queueSearch.Enqueue(k);
                            isVisites[k] = true;

                            break;
                        }
                    }
                }
            }
        }
    }
}
