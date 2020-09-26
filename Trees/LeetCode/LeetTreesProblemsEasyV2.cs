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
                if (node.val >= L && node.left != null) stack.Push(node.left);
                if (node.val <= R && node.right != null) stack.Push(node.right);
            }
            return sum;
        }

        public IList<int> GetLonelyNodes(TreeNode root)
        {
            var results = new List<int>();
            GetLonelyNodesWorkerCleaner(root, false, results);
            return results;
        }

        void GetLonelyNodesWorkerCleaner(TreeNode node, bool isLonely, IList<int> list)
        {
            if (node == null)
                return;
            if (isLonely)
                list.Add(node.val);
            GetLonelyNodesWorkerCleaner(node.left, node.right == null, list);
            GetLonelyNodesWorkerCleaner(node.right, node.left == null, list);
        }

        void GetLonelyNodesWorker(TreeNode node, IList<int> list)
        {
            if (node == null)
                return;
            if (node.left == null && node.right == null)
                return;
            if (node.left == null && node.right != null)
            {
                list.Add(node.right.val);
                GetLonelyNodesWorker(node.right, list);
            }
            else if (node.right == null && node.left != null)
            {
                list.Add(node.left.val);
                GetLonelyNodesWorker(node.left, list);
            }
            else
            {
                GetLonelyNodesWorker(node.left, list);
                GetLonelyNodesWorker(node.right, list);
            }
        }

        public IList<int> GetLonelyNodesIter(TreeNode root)
        {
            var results = new List<int>();
            if (root != null)
            {
                var stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    if (node.left == null)
                    {
                        if (node.right != null)
                        {
                            results.Add(node.right.val);
                            stack.Push(node.right);
                        }
                    }
                    else if (node.right == null)
                    {
                        if (node.left != null)
                        {
                            results.Add(node.left.val);
                            stack.Push(node.left);
                        }
                    }
                    else
                    {
                        stack.Push(node.right);
                        stack.Push(node.left);
                    }

                }
            }
            return results;
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            t1.val += t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);
            return t1;
        }

        public TreeNode MergeTreesIter(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;

            Stack<TreeNode[]> stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { t1, t2 });
            while (stack.Count > 0)
            {
                var nodes = stack.Pop();
                if (nodes[0] == null || nodes[1] == null)
                    continue;
                nodes[0].val += nodes[1].val;
                if (nodes[0].left == null)
                    nodes[0].left = nodes[1].left;
                else
                    stack.Push(new TreeNode[] { nodes[0].left, nodes[1].left });
                if (nodes[0].right == null)
                    nodes[0].right = nodes[1].right;
                else
                    stack.Push(new TreeNode[] { nodes[0].right, nodes[1].right });
            }
            return t1;
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
                return root;
            return (val > root.val) ? SearchBST(root.right, val) : SearchBST(root.left, val);
        }

        public TreeNode SearchBSTIter(TreeNode root, int val)
        {
            if (root == null)
                return null;
            while (root != null)
            {
                if (root.val == val)
                    return root;
                root = (val > root.val) ? root.right : root.left;
            }
            return root;
        }
    }
}
