using System;
using System.Collections.Generic;

namespace Tree
{
    class Tree<T>
    {
        private TreeNode<T> root;
        private readonly IComparer<T> comparer;

        public Tree(T data, IComparer<T> comparer)
        {
            this.comparer = comparer;
            root = new TreeNode<T>(data);
            Count = 1;
        }

        public Tree(T data)
        {
            root = new TreeNode<T>(data);
            comparer = Comparer<T>.Default;
            Count = 1;
        }

        /// <summary>
        /// Вставка 
        /// </summary>
        /// <param name="data"></param>
        public void AddNode(T data)
        {
            if (ReferenceEquals(root, null))
            {
                root = new TreeNode<T>(data);
                Count = 1;
                return;
            }

            Count++;
            TreeNode<T> currentNode = root;

            while (!ReferenceEquals(currentNode, null))
            {
                if (comparer.Compare(currentNode.Data, data) > 0)
                {
                    if (!ReferenceEquals(currentNode.LeftChild, null))
                    {
                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        currentNode.LeftChild = new TreeNode<T>(data);
                        return;
                    }
                }
                else
                {
                    if (!ReferenceEquals(currentNode.RightChild, null))
                    {
                        currentNode = currentNode.RightChild;
                    }
                    else
                    {
                        currentNode.RightChild = new TreeNode<T>(data);
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
            TreeNode<T> currentNode = root;

            while (!ReferenceEquals(currentNode, null))
            {
                int nodeCompare = comparer.Compare(currentNode.Data, data);

                if (nodeCompare == 0)
                {
                    return currentNode;
                }
                else if (nodeCompare > 0)
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
                else
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
        /// Получение первого узла по значению
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private TreeNode<T> NodeParentOf(T data)
        {
            if (comparer.Compare(root.Data, data) == 0)
            {
                return null;
            }

            TreeNode<T> currentParentNode = root;
            TreeNode<T> currentNode = root;

            while (!ReferenceEquals(currentNode, null))
            {
                int nodeCompare = comparer.Compare(currentNode.Data, data);

                if (nodeCompare == 0)
                {
                    return currentParentNode;
                }
                else if (nodeCompare > 0)
                {
                    if (!ReferenceEquals(currentNode.LeftChild, null))
                    {
                        currentParentNode = currentNode;
                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (!ReferenceEquals(currentNode.RightChild, null))
                    {
                        currentParentNode = currentNode;
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
        public bool Remove(T data)
        {
            //Определим узел и его родителя
            TreeNode<T> removedNodeParent = NodeParentOf(data);
            TreeNode<T> removedNode;

            bool isRemoveRoot=false;

            if (ReferenceEquals(removedNodeParent, null))
            {
                int comparer = this.comparer.Compare(root.Data, data);

                if (comparer == 0)
                {
                    removedNode = root;
                    removedNodeParent = new TreeNode<T>();//псевдородитель корня, нужен для работы алгоритма в стандарном виде
                    removedNodeParent.LeftChild = removedNode;
                    isRemoveRoot = true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (!ReferenceEquals(removedNodeParent.LeftChild, null) && comparer.Compare(removedNodeParent.LeftChild.Data, data) == 0)
                {
                    removedNode = removedNodeParent.LeftChild;
                }
                else
                {
                    removedNode = removedNodeParent.RightChild;
                }
            }

            Count--;

            //•Удаление листа – у родителя зануляем ссылку на удаляемый узел
            if (ReferenceEquals(removedNode.LeftChild, null) && ReferenceEquals(removedNode.RightChild, null))
            {
                if (isRemoveRoot)
                {
                    root = null;
                    return true;
                }

                if (ReferenceEquals(removedNodeParent.LeftChild, removedNode))
                {
                    removedNodeParent.LeftChild = null;
                }
                else
                {
                    removedNodeParent.RightChild = null;
                }
                return true;
            }

            //•Удаление узла с одним ребенком – у родителя подменяем ссылку с удаляемого узла на его ребенка
            if (ReferenceEquals(removedNode.LeftChild, null) && !ReferenceEquals(removedNode.RightChild, null))
            {
                if (isRemoveRoot)
                {
                    root = removedNode.RightChild;
                    return true;
                }

                if (ReferenceEquals(removedNodeParent.LeftChild, removedNode))
                {
                    removedNodeParent.LeftChild = removedNode.RightChild;
                }
                else
                {
                    removedNodeParent.RightChild = removedNode.RightChild;
                }               

                return true;
            }
            else if (!ReferenceEquals(removedNode.LeftChild, null) && ReferenceEquals(removedNode.RightChild, null))
            {
                if (isRemoveRoot)
                {
                    root = removedNode.LeftChild;
                    return true;
                }

                if (Equals(removedNodeParent.LeftChild, removedNode))
                {
                    removedNodeParent.LeftChild = removedNode.LeftChild;
                }
                else
                {
                    removedNodeParent.RightChild = removedNode.LeftChild;
                }
                return true;
            }

            //•Удаление узла с двумя детьми 
            TreeNode<T> leftmostNode = removedNode.RightChild;//первый шаг - уходим вправо, потом будем идти только влево.
            TreeNode<T> leftmostNodeParent = removedNode;

            while (!ReferenceEquals(leftmostNode.LeftChild, null))
            {
                leftmostNodeParent = leftmostNode;
                leftmostNode = leftmostNode.LeftChild;
            }

            if (!ReferenceEquals(leftmostNode.RightChild, null))
            {
                leftmostNodeParent.LeftChild = leftmostNode.RightChild;
            }           

            if (ReferenceEquals(removedNodeParent.RightChild, removedNode))
            {
                removedNodeParent.RightChild = leftmostNode;
            }
            else
            {
                removedNodeParent.LeftChild = leftmostNode;
            }

            leftmostNode.LeftChild = removedNode.LeftChild;// передача левого ребенка
           
            if (ReferenceEquals(leftmostNode, removedNode.RightChild))
            {
                leftmostNode.RightChild = null; //передача самого левого ребенка, в ситуации, когда он первый, т.е. правый.
            }
            else
            {
                leftmostNode.RightChild = removedNode.RightChild;
                leftmostNodeParent.LeftChild = null;
            }
                                 
            if (isRemoveRoot)
            {
                root = leftmostNode;
            }

            return true;
        }

        /// <summary>
        /// Получение числа элементов
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Обход в ширину (Breadth-First Search) с выполнним действия Action<T> action
        /// </summary>
        /// <param name="action"></param>
        public void BreadthFirstSearch(Action<T> action)
        {
            if (ReferenceEquals(root, null))
            {
                return;
            }

            Queue<TreeNode<T>> treeQueue = new Queue<TreeNode<T>>();
            TreeNode<T> currrentNode = root;
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
        public void DepthFirstSearch(Action<T> action)
        {
            if (ReferenceEquals(root, null))
            {
                return;
            }

            Stack<TreeNode<T>> treeStack = new Stack<TreeNode<T>>();
            TreeNode<T> currentNode = root;

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
        public void DepthFirstSearchRecursion(Action<T> action)
        {
            if (Equals(root, null))
            {
                return;
            }

            Visit(root, action);
        }
    }
}
