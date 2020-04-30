using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.val = value;
        }

        public T val { get; set; }
        public TreeNode<T> left { get; set; }
        public TreeNode<T> right { get; set; }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
