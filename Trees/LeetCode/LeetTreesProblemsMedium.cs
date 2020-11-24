using DataStructures;
using System.Collections.Generic;

namespace Trees.LeetCode
{
    public class LeetTreesProblemsMedium
    {
        //https://leetcode.com/problems/binary-tree-postorder-traversal/
        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> results = new List<int>();
            if (root == null)
                return results;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            while (stack.Count > 0 || current != null) {
                if (current != null) {
                    stack.Push(current);
                    current = current.left;
                }
                else {
                    var temp = stack.Peek().right;
                    if (temp == null) //its as leaf node
                    {
                        temp = stack.Pop();
                        results.Add(temp.val);
                        while (stack.Count > 0 && temp == stack.Peek().right) //whats on top of stack does not have a right child (as temp is a leaf)
                        {
                            temp = stack.Pop();
                            results.Add(temp.val);
                        }
                    }
                    else
                        current = temp;
                }
            }
            return results;
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root != null) {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0) {
                    var current = stack.Pop();
                    list.Add(current.val);
                    if (current.right != null) stack.Push(current.right);
                    if (current.left != null) stack.Push(current.left);
                }
            }
            return list;
        }

        public IList<int> PostOrderTraversalIntuitive(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null)
                return list;

            HashSet<TreeNode> set = new HashSet<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0) {
                var current = stack.Pop();
                if (set.Contains(current))
                    list.Add(current.val);
                else {
                    set.Add(current);
                    stack.Push(current);
                    if (current.right != null) stack.Push(current.right);
                    if (current.left != null) stack.Push(current.left);
                }
            }
            return list;
        }
    }
}
