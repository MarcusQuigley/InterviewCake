using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace Trees.LeetCode
{
   public class LeetEasyTrees<T>
    {
        int max; //TODO replace this with a ref param in Depth()
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
        //226 https://leetcode.com/problems/invert-binary-tree/
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            root.left = right;
            root.right = left;

            return root;
        }

        //700 https://leetcode.com/problems/search-in-a-binary-search-tree/
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val) return root;
            return (root.val > val) ? SearchBST(root.left, val) : SearchBST(root.right, val);
        }

        public TreeNode SearchBSTIter(TreeNode root, int val)
        {
            if (root == null || root.val == val) return root;
            while (root != null && root.val != val)
            {
                root = (root.val > val) ? root.left : root.right;
            }
            return root;// (root.val > val) ? SearchBST(root.left, val) : SearchBST(root.right, val);
        }

        //https://leetcode.com/problems/binary-tree-paths/
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> results = new List<string>();
            if (root == null)
                return results;
             
            string currentString = root.val.ToString();
            if (root.left == null && root.right == null)
                results.Add(currentString);
            else
            {
                if (root.left != null)
                    dfsPaths(root.left, currentString, results);
                if (root.right != null)
                    dfsPaths(root.right, currentString, results);
            }
 
            return results;
        }

        void dfsPaths(TreeNode node, string currentString, List<string> results)
        {
            currentString += "->" + node.val;
            if (node.left == null && node.right == null) { 
                results.Add(currentString);
                return;
            }
            else
            {
                if (node.left != null)
                    dfsPaths(node.left, currentString, results);
                if (node.right != null)
                    dfsPaths(node.right, currentString, results);
            }
        }
    }
}
