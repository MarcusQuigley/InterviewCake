using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
   public class LeetEasyTrees<T>
    {
        int max;
        //543 https://leetcode.com/problems/diameter-of-binary-tree/
        //DFS
        public int DiameterOfBinaryTree(TreeNode<T> root)
        {
            Depth(root);
            return max;
        }
        int Depth(TreeNode<T> node)
        {
            if (node == null)
                return 0;
            int L = Depth(node.left);
            int R = Depth(node.right);
            max = Math.Max(max, L + R);
            return Math.Max(L, R) + 1;
        }

        //1046 https://leetcode.com/problems/last-stone-weight/
        public int LastStoneWeight(int[] stones)
        {
            var heap = new MaxHeap<int>(stones);
            while (heap.Count > 1)
            {
                var val1 = heap.RemoveMax();
                var val2 = heap.RemoveMax();
                if (val1 != val2)
                    heap.Add(val1 - val2);
            }

            return (heap.Count == 0) ? 0 : heap.Peek();
        }
    }
}
