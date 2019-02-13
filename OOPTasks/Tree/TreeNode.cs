namespace Tree
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }

        public TreeNode(T data, TreeNode<T> leftChild, TreeNode<T> rightChild)
        {
            Data = data;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
