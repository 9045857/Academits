namespace Tree
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
        public TreeNode<T> Parent { get; set; }
               
        public TreeNode(T data)
        {
            Data = data;
        }

        public TreeNode(T data, TreeNode<T> parent)
        {
            Data = data;
            Parent = parent;
        }

        public TreeNode(T data, TreeNode<T> leftChild, TreeNode<T> rightChild)
        {
            Data = data;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public TreeNode(T data, TreeNode<T> leftChild, TreeNode<T> rightChild, TreeNode<T> parent)
        {
            Data = data;
            LeftChild = leftChild;
            RightChild = rightChild;
            Parent = parent;
        }
    }
}
