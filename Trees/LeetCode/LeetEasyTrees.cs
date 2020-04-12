using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
   public class LeetEasyTrees<T>
    {
        int max;
        //543 https://leetcode.com/problems/diameter-of-binary-tree/
        public int DiameterOfBinaryTree(TreeNode<T> root)
        {
            Depth(root);
            return max;
        }
        int Depth(TreeNode<T> node)
        {
            if (node == null)
                return 0;
            int L = Depth(node.Left);
            int R = Depth(node.Right);
            max = Math.Max(max, L + R);
            return Math.Max(L, R) + 1;
        }
    }
}
