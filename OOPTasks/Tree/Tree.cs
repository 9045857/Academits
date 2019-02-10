using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tree<T>
    {
        public TreeNode<T> Root;
        private IComparer<T> nodeComparer;

        public Tree(TreeNode<T> root, IComparer<T> comparer)
        {
            nodeComparer = comparer;
            Root = root;
            Count = 1;
        }

        public Tree(TreeNode<T> root)
        {
            Root = root;
            nodeComparer = Comparer<T>.Default;
            Count = 1;
        }

        /// <summary>
        /// Вставка 
        /// </summary>
        /// <param name="data"></param>
        public void AddNode(T data)
        {
            Count++;

            TreeNode<T> currentNode = Root;

            Console.WriteLine("{0}:", data);

            while (!ReferenceEquals(currentNode, null))
            {
                if (nodeComparer.Compare(currentNode.Data, data) > 0)
                {
                    if (!ReferenceEquals(currentNode.LeftChild, null))
                    {
                        Console.WriteLine("{0} <- {1}", currentNode.LeftChild.Data, currentNode.Data);

                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        currentNode.LeftChild = new TreeNode<T>(data, currentNode);
                        Console.WriteLine("| {0} | <- {1}", data, currentNode.Data);
                        return;
                    }
                }
                else //if (nodeComparer.Compare(currentNode.Data, data) < 0)
                {
                    if (!ReferenceEquals(currentNode.RightChild, null))
                    {
                        Console.WriteLine("{1} -> {0}", currentNode.RightChild.Data, currentNode.Data);

                        currentNode = currentNode.RightChild;
                    }
                    else
                    {
                        currentNode.RightChild = new TreeNode<T>(data, currentNode);
                        Console.WriteLine("{1} -> | {0} |", data, currentNode.Data);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Получение первого узла по значению
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private TreeNode<T> NodeOf(T data)
        {
            TreeNode<T> currentNode = Root;

            while (!ReferenceEquals(currentNode, null))
            {
                if (nodeComparer.Compare(currentNode.Data, data) == 0)
                {
                    return currentNode;
                }
                else if (nodeComparer.Compare(currentNode.Data, data) > 0)
                {
                    if (!ReferenceEquals(currentNode.LeftChild, null))
                    {
                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        return null;
                    }
                }
                else //if (nodeComparer.Compare(currentNode.Data, data) < 0)
                {
                    if (!ReferenceEquals(currentNode.RightChild, null))
                    {
                        currentNode = currentNode.RightChild;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Поиск узла
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            return !ReferenceEquals(NodeOf(data), null);
        }

        /// <summary>
        /// Удаление первого вхождения узла по значению 
        /// </summary>
        /// <param name="data"></param>
        public void Remove(T data)
        {
            TreeNode<T> removedNode = NodeOf(data);

            if (ReferenceEquals(removedNode, null))
            {
                return;
            }

            Count--;

            //•Удаление листа – у родителя зануляем ссылку на удаляемый узел
            if (ReferenceEquals(removedNode.LeftChild, null) && ReferenceEquals(removedNode.RightChild, null))
            {
                if (Equals(removedNode.Parent.LeftChild, removedNode))
                {
                    removedNode.Parent.LeftChild = null;
                }
                else
                {
                    removedNode.Parent.RightChild = null;
                }
                return;
            }

            //•Удаление узла с одним ребенком – у родителя подменяем ссылку с удаляемого узла на его ребенка
            if (ReferenceEquals(removedNode.LeftChild, null) && !ReferenceEquals(removedNode.RightChild, null))
            {
                if (Equals(removedNode.Parent.LeftChild, removedNode))
                {
                    removedNode.Parent.LeftChild = removedNode.RightChild;
                }
                else
                {
                    removedNode.Parent.RightChild = removedNode.RightChild;
                }
                return;
            }
            else if (!ReferenceEquals(removedNode.LeftChild, null) && ReferenceEquals(removedNode.RightChild, null))
            {
                if (Equals(removedNode.Parent.LeftChild, removedNode))
                {
                    removedNode.Parent.LeftChild = removedNode.LeftChild;
                }
                else
                {
                    removedNode.Parent.RightChild = removedNode.LeftChild;
                }
                return;
            }

            //•Удаление узла с двумя детьми 
            TreeNode<T> leftmostNode = removedNode.LeftChild;

            while (!ReferenceEquals(leftmostNode.LeftChild, null))
            {
                leftmostNode = leftmostNode.LeftChild;
            }

            if (!ReferenceEquals(leftmostNode.RightChild, null))
            {
                leftmostNode.Parent.LeftChild = leftmostNode.RightChild;
            }

            if (Equals(removedNode.Parent.RightChild, removedNode))
            {
                removedNode.Parent.RightChild = leftmostNode;
                leftmostNode.LeftChild = removedNode.LeftChild;
                leftmostNode.RightChild = removedNode.RightChild;
            }
            else
            {
                removedNode.Parent.LeftChild = leftmostNode;
                leftmostNode.LeftChild = removedNode.LeftChild;
                leftmostNode.RightChild = removedNode.RightChild;
            }
        }

        /// <summary>
        /// Получение числа элементов
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Обход в ширину (Breadth-First Search) с выполнним действия Action<T> action
        /// </summary>
        /// <param name="action"></param>
        public void BFS(Action<T> action)
        {
            Queue<TreeNode<T>> treeQueue = new Queue<TreeNode<T>>();

            TreeNode<T> currrentNode = Root;
            treeQueue.Enqueue(currrentNode);

            while (treeQueue.Count != 0)
            {
                currrentNode = treeQueue.Dequeue();

                action(currrentNode.Data);

                if (!ReferenceEquals(currrentNode.LeftChild, null))
                {
                    treeQueue.Enqueue(currrentNode.LeftChild);
                }
                if (!ReferenceEquals(currrentNode.RightChild, null))
                {
                    treeQueue.Enqueue(currrentNode.RightChild);
                }
            }
        }

        /// <summary>
        /// Обход в глубину (Depth-First Search) без рекурсии
        /// </summary>
        /// <param name="action"></param>
        public void DFS(Action<T> action)
        {
            Stack<TreeNode<T>> treeStack = new Stack<TreeNode<T>>();
            TreeNode<T> currentNode = Root;

            treeStack.Push(currentNode);

            while (treeStack.Count != 0)
            {
                currentNode = treeStack.Pop();

                action(currentNode.Data);

                if (!ReferenceEquals(currentNode.RightChild, null))
                {
                    treeStack.Push(currentNode.RightChild);
                }
                if (!ReferenceEquals(currentNode.LeftChild, null))
                {
                    treeStack.Push(currentNode.LeftChild);
                }
            }
        }

        /// <summary>
        /// Рекурсия обхода в глубину с действием
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        private static void Visit(TreeNode<T> node, Action<T> action)
        {
            action(node.Data);

            if (!ReferenceEquals(node.LeftChild, null))
            {
                Visit(node.LeftChild, action);
            }
            if (!ReferenceEquals(node.RightChild, null))
            {
                Visit(node.RightChild, action);
            }
        }

        /// <summary>
        /// Обход в глубину с рекурсией
        /// </summary>
        /// <param name="action"></param>
        public void DFSRecursion(Action<T> action)
        {
            Visit(Root, action);
        }
    }
}
