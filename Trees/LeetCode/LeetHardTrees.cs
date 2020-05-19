using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetHardTrees
    {
        //Leet 124 https://leetcode.com/problems/binary-tree-maximum-path-sum/
        //Recursion
        public int MaxPathSum(TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            int max = int.MinValue;
            MaxSinglePath(ref max, root);
            return max;
         }

        int MaxSinglePath(ref int max, TreeNode node)
        {
            if (node == null)
                return 0;
            int leftSum = Math.Max(MaxSinglePath(ref max, node.left), 0);
            int rightSum = Math.Max(MaxSinglePath(ref max, node.right), 0);
            max = Math.Max(max, leftSum + rightSum + node.val);
            return node.val + Math.Max(leftSum, rightSum);
        }
    }
}
