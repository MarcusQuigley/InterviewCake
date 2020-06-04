using DataStructures;
using System;
using System.Collections.Generic;
using System.Data;

namespace LeetStudy
{
    public class LeetStudyTrees
    {

        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/928/
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
                return new int[0];
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current.val);
                if (current.right != null)
                    stack.Push(current.right);
                if (current.left != null)
                    stack.Push(current.left);
            }


            return result.ToArray();
        }

        public IList<int> PreorderTraversalRecursive(TreeNode root)
        {
            var results = new List<int>();
            preorderTraversalRecursive(root, ref results);
            return results;
        }

        void preorderTraversalRecursive(TreeNode node, ref List<int> list)
        {
            if (node != null)
            {
                list.Add(node.val);
                preorderTraversalRecursive(node.left, ref list);
                preorderTraversalRecursive(node.right, ref list);
            }
        }

        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/929/
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;

            var current = root;
            var stack = new Stack<TreeNode>();
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                result.Add(current.val);
                current = current.right;
            }
            return result;
        }

        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/930/
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            Stack<TreeNode> leftStack = new Stack<TreeNode>();
            Stack<TreeNode> rightStack = new Stack<TreeNode>();
            leftStack.Push(root);
            while (leftStack.Count > 0)
            {
                var current = leftStack.Pop();

                if (current.left != null)
                    leftStack.Push(current.left);
                if (current.right != null)
                    leftStack.Push(current.right);
                rightStack.Push(current);
            }

            while (rightStack.Count > 0)
            {
                result.Add(rightStack.Pop().val);
            }

            return result;
        }

        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/931/
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var results = new List<IList<int>>();
            var q = new Queue<TreeNode>();
            if (root != null)
                q.Enqueue(root);
            while (q.Count > 0)
            {
                var len = q.Count;
                var result = new List<int>();
                for (int i = 0; i < len; i++)
                {
                    var node = q.Dequeue();
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    result.Add(node.val);
                }
                results.Add(result);
            }
            return results;
        }


        #region Recursion with Trees
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var l = MaxDepth(root.left) + 1;
            var r = MaxDepth(root.right) + 1;
            return Math.Max(l, r);
        }


        #endregion

        public int MaxDepthIter(TreeNode root)
        {
            if (root == null)
                return 0;
            var count = 0;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var len = q.Count;
                for (int i = 0; i < len; i++)
                {
                    var current = q.Dequeue();
                    if (current.left != null) q.Enqueue(current.left);
                    if (current.right != null) q.Enqueue(current.right);
                }
                count += 1;
            }
            return count;
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return false;
            return IsMirror(root, root);
        }
        bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true;
            if (t1 == null || t2 == null)
                return false;
            return (t1.val == t2.val) &&
            IsMirror(t1.left, t2.right) &&
            IsMirror(t1.right, t2.left);
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return sum- root.val  == 0;
            return (HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val));


        }
    }
}
