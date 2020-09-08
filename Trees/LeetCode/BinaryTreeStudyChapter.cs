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
            while (stack.Count>0)
            {
                TreeNode current = stack.Pop();
                results.Add(current.val);
                if (current.right != null) stack.Push(current.right);
                if (current.left != null) stack.Push(current.left);
               
            }

            return results;
        }
        ////https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/929/
        //public IList<int> InorderTraversal(TreeNode root)
        //{
        //    List<int> results = new List<int>();
        //    if (root == null)
        //        return results;

        //    TreeNode current = root;
        //    Stack<TreeNode> stack = new Stack<TreeNode>();
        //    while(stack.Count>0 || current!=null)
        //    {
        //        while(current!= null  )
        //        {
                 
        //            stack.Push(current);
        //            current = current.left;
        //        }
        //        current = stack.Pop();
        //        results.Add(current.val);
        //        current = current.right;
        //    }
            
        //    return results;

        //}
        ////https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/929/
        //public IList<int> InorderTraversalRecursion(TreeNode root)
        //{
        //    List<int> result = new List<int>();
        //    InorderWork(root, result);
        //    return result;
        //}
        //void InorderWork(TreeNode root, List<int> results)
        //{
        //    if (root == null)
        //        return;
        //    InorderWork(root.left, results);
        //    results.Add(root.val);
        //    InorderWork(root.right, results);
        //}
    }
}
