using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph<T>
    {
        private T[] nodes;
        private int[,] graphs;

        public int Count { get; private set; }

        public Graph(T[] nodes, int[,] graphs)
        {
            Count = nodes.Length;
            Array.Copy(nodes, this.nodes, nodes.Length);
            graphs = Get2DIntArrayCopy(graphs);
        }

        public Graph(int[,] graphs)
        {
            Count = graphs.GetLength(0);
            graphs = Get2DIntArrayCopy(graphs);
        }

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

        public void BreadthFirstSearch()
        {
            bool[] visite=new bool[Count];

            Queue<int> queueSearch=new Queue<int>();

            for (int i = 0; i < Count; i++)
            {
                if (!visite[i])
                {
                    queueSearch.Enqueue(i);
                    visite[i] = true;
                }

                for (int j = 0; j < Count; j++)
                {
                    if (!visite[j])
                    {
                        queueSearch.Enqueue(graphs[i,j]);
                        visite[j] = true;
                    }

                }



            }

        }





    }
}
