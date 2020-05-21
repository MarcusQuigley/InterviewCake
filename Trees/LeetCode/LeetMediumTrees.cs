using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetMediumTrees
    {
        //Leet 1008 https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/
        //bst
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder == null)
                throw new ArgumentNullException(nameof(preorder));
            var n = preorder.Length;
            TreeNode root = new TreeNode(preorder[0]);
            for (int i = 1; i < n; i++)
            {
                var val = preorder[i];
                TreeNode parent = null;
                var node = root;
                while (node != null)
                {
                    parent = node;
                    if (val < node.val)
                        node = node.left;
                    else
                        node = node.right;
                }
                if (val < parent.val)
                    parent.left = new TreeNode(val);
                else
                    parent.right = new TreeNode(val);
            }

            return root;
        }

        //https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/532/week-5/3315/
        //DFS
        public bool IsValidSequence(TreeNode<int> root, int[] arr)
        {
            if (root == null || arr == null)
                throw new ArgumentNullException("Somethings null");

            return CheckPath(root, arr, 0);

            //Queue<TreeNode<int>> q = new Queue<TreeNode<int>>();
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            var currindex = 0;
            stack.Push(root);
            var enquedctr = 1;

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current != null)
                {
                    if (arr[currindex] == current.val)
                    {
                        if (currindex + 1 == arr.Length && (current.left == null && current.right == null))
                            return true;

                        if (current.left != null && current != null)
                        {
                            stack.Push(current.left);
                            enquedctr += 1;
                            stack.Push(current.right);
                            enquedctr += 1;

                            currindex += 1;
                        }
                        //else
                        //currindex -= 1;

                    }
                }
            }

            return false;
        }

        bool CheckPath(TreeNode<int> root, int[] arr, int index)
        {
            if (root == null || index == arr.Length)
                return false;

            if (root.left == null && root.right == null && root.val == arr[index] && index == arr.Length - 1)
                return true;

            return root.val == arr[index] && (CheckPath(root.left, arr, index + 1) || CheckPath(root.right, arr, index + 1));

        }

        bool DFSValidSequence(TreeNode<int> current, int[] arr, int currindex)
        {
            if (current != null)
            {
                if (arr[currindex++] == current.val)
                {
                    if (currindex == arr.Length)
                        return true;
                    DFSValidSequence(current.left, arr, currindex);
                    DFSValidSequence(current.right, arr, currindex);
                }
            }
            return false;
        }

        // 230. https://leetcode.com/problems/kth-smallest-element-in-a-bst/
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            List<int> list = KthSmallestDFS(root, new List<int>());
           
 
            return  list[k-1];
        }

        List<int> KthSmallestDFS(TreeNode node, List<int> list)
        {
            if (node != null)
            {
                KthSmallestDFS(node.left, list);
                list.Add(node.val);
                
                KthSmallestDFS(node.right, list);
                return list;
            }
            return list;
        }
    }
}
