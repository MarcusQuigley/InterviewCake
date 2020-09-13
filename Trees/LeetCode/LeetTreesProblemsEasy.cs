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

        //https://leetcode.com/problems/range-sum-of-bst/
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return 0;
            if (root.val < L)
                return RangeSumBST(root.right, L, R);
            if (root.val > R)
                return RangeSumBST(root.left, L, R);
            return (root.val + RangeSumBST(root.right, L, R) + RangeSumBST(root.left, L, R));
        }

        public int RangeSumBSTIter(TreeNode root, int L, int R)
        {
            if (root == null)
                return 0;
            int result = 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.val >= L && current.val <= R)
                    result += current.val;
                if (current.val >= L && current.left != null) q.Enqueue(current.left);
                if (current.val <= R && current.right != null) q.Enqueue(current.right);
            }
            return result;
        }

        //https://leetcode.com/problems/merge-two-binary-trees/
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            t1.val += t2.val;
            t1.left = (t1.left == null) ? t2.left : MergeTrees(t1.left, t2.left);
            t1.right = (t1.right == null) ? t2.right : MergeTrees(t1.right, t2.right);
            return t1;
        }

        public TreeNode MergeTreesIter(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            Stack<TreeNode[]> stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { t1, t2 });
            while (stack.Count > 0)
            {
                TreeNode[] t = stack.Pop();
                if (t[0] == null || t[1] == null) continue;
                t[0].val += t[1].val;
                if (t[0].left == null)
                    t[0].left = t[1].left;
                else
                    stack.Push(new TreeNode[] { t[0].left, t[1].left });
                if (t[0].right == null)
                    t[0].right = t[1].right;
                else
                    stack.Push(new TreeNode[] { t[0].right, t[1].right });
            }
            return t1;
        }

        //https://leetcode.com/problems/search-in-a-binary-search-tree/
        TreeNode resultBst = null;
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;

            if (root.val == val)
            {
                resultBst = new TreeNode(val);
                resultBst.left = root.left;
                resultBst.right = root.right;
                //   return result;
            }
            SearchBST(root.left, val);
            SearchBST(root.right, val);
            return resultBst;
        }
        public TreeNode SearchBSTIter(TreeNode root, int val)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            var current = root;
            while (current != null && current.val != val)
            {
                  current = (current.val > val) ? current.left : current.right;
            }
            return current;
        }
        //https://leetcode.com/problems/n-ary-tree-postorder-traversal/
        public IList<int> NaryPostorder(NaryNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            IList<int> results = new List<int>();
            Stack<NaryNode> leftStack = new Stack<NaryNode>();
            Stack<NaryNode> rightStack = new Stack<NaryNode>();
            leftStack.Push(root);
            while (leftStack.Count > 0)
            {
                var current = leftStack.Pop();
                //for (int i = current.children.Count - 1; i >= 0; i--)
                for (int i =0;i <  current.children.Count; i++)
                    leftStack.Push(current.children[i]);

                rightStack.Push(current);
            }
            while (rightStack.Count > 0)
                results.Add(rightStack.Pop().val);

            return results;
        }

        //https://leetcode.com/problems/n-ary-tree-preorder-traversal/
        public IList<int> NaryPreorder(NaryNode root)
        {
            IList<int> results = new List<int>();
            if (root == null)
                return results;
            Stack<NaryNode> stack = new Stack<NaryNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                results.Add(current.val);
                for (int i = current.children.Count-1; i >=0; i--)
                {
                    stack.Push(current.children[i]);
                }
            }
            return results;
        }

        //https://leetcode.com/problems/increasing-order-search-tree/
        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode result = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var current = root;
            TreeNode temp = null;
            while(stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                if (result == null)
                {
                    result = new TreeNode(current.val);
                    temp = result;
                }
                else
                {
                    result.right = new TreeNode(current.val);
                    result = result.right;
                }
                current = current.right;
            }

                return temp;// result;
        }

        //https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
        public int SumRootToLeaf(TreeNode root)
        {
            Stack<KeyValuePair<TreeNode, int>> stack = new Stack<KeyValuePair<TreeNode, int>>();
            stack.Push(new KeyValuePair<TreeNode,int>(root,root.val));
             int sum = 0;
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                var currentNode = current.Key;
                if (currentNode.left == null && currentNode.right == null)
                {
                     sum += current.Value ;
                }
                 else
                {
                    if (currentNode.left != null) stack.Push(new KeyValuePair<TreeNode, int>(currentNode.left, (current.Value * 2) + currentNode.left.val));
                    if (currentNode.right != null) stack.Push(new KeyValuePair<TreeNode, int>(currentNode.right, (current.Value * 2) + currentNode.right.val));
                }
             }
            return sum;
        }

        //https://leetcode.com/problems/maximum-depth-of-n-ary-tree/
        public int MaxDepthNary(NaryNode root)
        {
            if (root == null)
                return 0;
            int level = 0;
            Queue<NaryNode> q = new Queue<NaryNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var count = q.Count;
                level += 1;
                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    for (int j = 0; j < node.children.Count; j++)
                        q.Enqueue(node.children[j]);
                }
            }
            return level;
        }
    }
}
