namespace CCSD
{
    class TreeNode<T>
    {
        public TreeNode<T> leftChild, rightChild, parent;
        public T value;
        public int partialCode ;

        public TreeNode(T data)
        {
            leftChild = rightChild = parent = null;
            value = data;
        }

        public bool IsLeaf()
        {
            return this.leftChild == null && this.rightChild == null;
        }

        public bool isTheOnlyNode()
        {
            return IsLeaf() && this.parent == null;
        }
    }
}
