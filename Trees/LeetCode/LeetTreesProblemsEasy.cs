using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetTreesProblemsEasy
    {

        //https://leetcode.com/problems/find-all-the-lonely-nodes/
        public IList<int> GetLonelyNodes(TreeNode root)
        {
            if (root == null)
                return new int[] { };
            IList<int> results = new List<int>();
            GetLonelyNodesWorker(root, results);
            return results;
        }

        void GetLonelyNodesWorker(TreeNode root, IList<int> results)
        {
            if (root == null)
                return;

            if (root.left == null && root.right != null)
                results.Add(root.right.val);
            if (root.right == null && root.left != null)
                results.Add(root.left.val);
            GetLonelyNodesWorker(root.left, results);
            GetLonelyNodesWorker(root.right, results);

        }

        public IList<int> GetLonelyNodesIter(TreeNode root)
        {
            if (root == null)
                return new int[] { };
            IList<int> results = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node.left == null && node.right != null)
                {
                    results.Add(node.right.val);
                }
                if (node.right == null && node.left != null)
                {
                    results.Add(node.left.val);
                }
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
            return results;
        } 
    }
}
