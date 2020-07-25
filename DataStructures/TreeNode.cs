using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            this.val = value;
        }

        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
