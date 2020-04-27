using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}
