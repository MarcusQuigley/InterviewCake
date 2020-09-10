using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
    public class BinaryTreeStudyChapter
    {
        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/928/
        List<int> resultsPreorderRecursive = new List<int>();
        public IList<int> PreorderTraversalRecursive(TreeNode root)
        {//Root,L,R
            if (root != null)
                PreorderTraversalRecursiveWork(root);
            return resultsPreorderRecursive;
        }

        void PreorderTraversalRecursiveWork(TreeNode node)
        {
            if (node == null)
                return;
            resultsPreorderRecursive.Add(node.val);
            PreorderTraversalRecursiveWork(node.left);
            PreorderTraversalRecursiveWork(node.right);

        }
        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/928/

        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> results = new List<int>();
            if (root == null)
                return results;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                results.Add(current.val);
                if (current.right != null) stack.Push(current.right);
                if (current.left != null) stack.Push(current.left);

            }

            return results;
        }
        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/929/
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> results = new List<int>();
            if (root == null)
                return results;

            TreeNode current = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {

                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                results.Add(current.val);
                current = current.right;
            }

            return results;

        }
        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/929/
        public IList<int> InorderTraversalRecursion(TreeNode root)
        {
            List<int> result = new List<int>();
            InorderWork(root, result);
            return result;
        }
        void InorderWork(TreeNode root, List<int> results)
        {
            if (root == null)
                return;
            InorderWork(root.left, results);
            results.Add(root.val);
            InorderWork(root.right, results);
        }

        //https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/930/
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> results = new List<int>();
            if (root == null)
                return results;
            Stack<TreeNode> leftStack = new Stack<TreeNode>();
            Stack<TreeNode> rightStack = new Stack<TreeNode>();
            leftStack.Push(root);
            while (leftStack.Count > 0)
            {
                var current = leftStack.Pop();
                rightStack.Push(current);
                if (current.left != null) leftStack.Push(current.left);
                if (current.right != null) leftStack.Push(current.right);
            }

            while (rightStack.Count > 0)
                results.Add(rightStack.Pop().val);
            return results;
        }



        public List<int> postorderTraversal2Tushar(TreeNode root)
        {
            TreeNode current = root;
            List<int> results = new List<int>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            while (current != null || stack2.Count > 0)
            {
                if (current != null)
                {
                    stack2.Push(current);
                    current = current.left;
                }
                else
                {
                    TreeNode temp = stack2.Peek().right;
                    if (temp == null)
                    {
                        temp = stack2.Pop();
                        results.Add(temp.val);
                        while (stack2.Count > 0 && temp == stack2.Peek().right)
                        {
                            temp = stack2.Pop();
                            results.Add(temp.val);
                        }
                    }
                    else
                    {
                        current = temp;
                    }
                }
            }
            return results;
        }

        public IList<IList<int>> LevelOrderTraversal(TreeNode root)
        {
            List<IList<int>> results = new List<IList<int>>();
            if (root == null) return results;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var count = q.Count;
                int[] list = new int[count];
                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    list[i] = node.val;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
                results.Add(list);
            }

            return results;
        }
        //Recursion
        //Top down
        //https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/535/
        private int answer;     // don't forget to initialize answer before call maximum_depth
        private void maximum_depth(TreeNode root, int depth)
        {
            if (root == null)
            {
                return;
            }
            if (root.left == null && root.right == null)
            {
                answer = Math.Max(answer, depth);
            }
            maximum_depth(root.left, depth + 1);
            maximum_depth(root.right, depth + 1);
        }

        //Bottom up
        public int maximum_depth(TreeNode root)
        {
            if (root == null)
            {
                return 0;                                   // return 0 for null node
            }
            int left_depth = maximum_depth(root.left);
            int right_depth = maximum_depth(root.right);
            return Math.Max(left_depth, right_depth) + 1;   // return depth of the subtree rooted at root
        }

        public int MaxDepthBFS(TreeNode root)
        {

            if (root == null) return 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            var result = 0;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                result += 1;
                var count = q.Count;
                //  int[] list = new int[count];
                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    //       list[i] = node.val;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
                //    results.Add(list);
            }

            return result;
        }

        public int MaxDepth(TreeNode root)
        {

            if (root == null) return 0;
            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);
            return Math.Max(left, right) + 1;
        }

        //https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/536/
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            return (IsSymmetricWork(root.left, root.right));
        }

        bool IsSymmetricWork(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;

            if (left == null || right == null)
                return false;
            if (left.val != right.val) return false;
            //if (left.val == right.val) return true;
            return (IsSymmetricWork(left.left, right.right) && IsSymmetricWork(left.right, right.left));
        }

        //https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/537/
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return (root.val - sum == 0);
            var left = HasPathSum(root.left, sum - root.val);
            var right = HasPathSum(root.right, sum - root.val);
            return left || right;
        }

        //        the question says "each subtree" ... the 5 at the root will not be considered a univalued subtree as its children are 1 and 5 ... 
        //for a sub tree to be considered univalued the node and its 2 children and the children of it's children need to be of the same value or null.

        //thus we have 4 univalued subtrees in this example.

        //the three leaf nodes, 5, 5 and 5 which are univalued subtrees in itself
        //and the right subtree of root

        //5 (right child of root)
        // \
        //  5 (leaf)

        ////https://leetcode.com/problems/count-univalue-subtrees/
        //int count = 0;
        //public int CountUnivalSubtrees(TreeNode root)
        //{
        //    if (root == null) return 0;

        //    //CountUnivalSubtreesWork(root);
        //    int numElements = 0;
        //    var total = CountUnivalSubtreesWork2(root, numElements);
        //    return (numElements == total) ? total + 1 : total;
        //}

        //void CountUnivalSubtreesWork(TreeNode root)
        //{
        //    if (root == null) return;
        //    if (root.left == null && root.right == null)
        //    {
        //        count += 1;
        //        return;
        //    }
        //    if (root.left == null || root.right == null)
        //        if ((root.left == null && root.val == root.right.val) ||
        //            (root.right == null && root.val == root.left.val))
        //            count += 1;

        //    if (root.left != null && root.right != null)
        //        if (root.val == root.left.val && root.val == root.right.val)
        //            count += 1;
        //    CountUnivalSubtreesWork(root.left);
        //    CountUnivalSubtreesWork(root.right);
        //}

        int CountUnivalSubtreesWork2(TreeNode root, int numElements)
        {
            if (root == null) return 0;
            numElements += 1;
            if (root.left == null && root.right == null)
            {
                 return 1;
            }
            var cnt = 0;
            if (root.left == null || root.right == null)
            {
                if ((root.left == null && root.val == root.right.val) ||
                    (root.right == null && root.val == root.left.val))
                    cnt += 1;
            }
            else
            {
                if (root.left != null && root.right != null)
                    if (root.val == root.left.val && root.val == root.right.val)
                        cnt += 1;
            }
           return ( CountUnivalSubtreesWork2(root.left, numElements) + CountUnivalSubtreesWork2(root.right, numElements) ) + cnt;
        }

        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null) return true;
 
            if (root.left != null && root.val != root.left.val)
                return false;
            if (root.right != null && root.val != root.right.val)
                return false;

            //if (root.left == null && root.right == null)
            //    return true;
            if (IsUnivalTree(root.left) && IsUnivalTree(root.right))
                return true;
            return false;
         }


    }
}
