using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetTreesProblemsEasyV2
    {
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return 0;
            var sum = (root.val >= L && root.val <= R) ? root.val : 0;
            var left = (root.val >= L) ? RangeSumBST(root.left, L, R) : 0;
            var right = (root.val <= R) ? RangeSumBST(root.right, L, R) : 0;

            return left + right + sum;
        }

        public int RangeSumBSTIter(TreeNode root, int L, int R)
        {
            if (root == null) return 0;
            var sum = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node.val >= L && node.val <= R)
                    sum += node.val;
                if (node.val >= L && node.left != null ) stack.Push(node.left);
                if (node.val <= R && node.right != null) stack.Push(node.right);
            }
            return sum;
        }
    }
}
