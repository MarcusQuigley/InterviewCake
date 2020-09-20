using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
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
    }
}
