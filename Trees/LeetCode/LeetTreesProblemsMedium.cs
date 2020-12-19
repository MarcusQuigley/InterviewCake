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
        //https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/

        private TreeNode firstTTDL = null;
        private TreeNode lastTTDL = null;
        public TreeNode TreeToDoubleList(TreeNode root)
        {
            TreeToDoubleListWorker(root);
            lastTTDL.right = firstTTDL;
            firstTTDL.left = lastTTDL;
            return firstTTDL;
        }
        private void TreeToDoubleListWorker(TreeNode root)
        {
            if (root == null) {
                return;
            }
            TreeToDoubleListWorker(root.left);
            if (firstTTDL == null) {
                firstTTDL = root;

            }
            else {
                lastTTDL.right = root;
                root.left = lastTTDL;

            }
            lastTTDL = root;
            TreeToDoubleListWorker(root.right);
        }
        public TreeNode TreeToDoubleListIter(TreeNode root)
        {
            if (root == null)
                return root;
            TreeNode result = null;
            TreeNode prev = null;
            TreeNode current = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || current != null) {
                while (current != null) {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                if (result == null)
                    result = current;
                else {
                    prev.right = current;
                    current.left = prev;
                }
                prev = current;
                current = current.right;

            }
            result.left = prev;
            prev.right = result;
            return result;
        }
        //https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/
        public TreeNode BstFromPreorderIter(int[] preorder)
        {
            if (preorder == null || preorder.Length == 0)
                return null;

            TreeNode root = new TreeNode(preorder[0]);

            for (int i = 1; i < preorder.Length; i++) {
                TreeNode parent = null;
                TreeNode current = root;
                while (current != null) {
                    parent = current;
                    if (current.val < preorder[i])
                        current = current.right;
                    else
                        current = current.left;
                }
                current = new TreeNode(preorder[i]);

            }

            for (int i = 0; i < 3; i++) {

            }
            return root;
        }



        //private TreeNode BstFromPreorderIterWorker(int[] preorder, int start, int end)
        //{
        //    if (preorder == null || preorder.Length == 0)
        //        return null;
        //    TreeNode node = new TreeNode(preorder[start]);
        //}
    }
}
