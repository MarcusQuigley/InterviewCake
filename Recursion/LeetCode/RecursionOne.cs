using System;
using System.Collections.Generic;

namespace Recursion.LeetCode
{
    public class RecursionOne
    {
        //https://leetcode.com/explore/featured/card/recursion-i/250/principle-of-recursion/1440/

        public void ReverseString(char[] s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            RecursiveReverseString(s, 0, s.Length - 1);
        }

        void RecursiveReverseString(char[] s, int left, int right)
        {
            if (left >= right) return;

            var temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            RecursiveReverseString(s, left + 1, right - 1);
        }

        public char[] ReverseStringIter(char[] s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.Length > 1)
            {
                var left = 0;
                var right = s.Length - 1;
                while (left < right)
                {
                    var temp = s[right];
                    s[right] = s[left];
                    s[left] = temp;
                    left++;
                    right--;
                }
            }
            return s;
        }

        //24 https://leetcode.com/problems/swap-nodes-in-pairs/
        public ListNode SwapPairs(ListNode node)
        {
            if (node == null || node.next == null)
                return node;

            var firstNode = node;
            var secondNode = node.next;

            firstNode.next = SwapPairs(secondNode.next);
            secondNode.next = firstNode;

            return secondNode;

        }
        public string NewReverseString(string s)
        {
            return NewReverseString2(s, s.Length - 1);
        }

        string NewReverseString2(string s, int index)
        {
            if (index < 0)
                return "";
            return s.Substring(index, 1) + NewReverseString2(s, index - 1);
        }

        //https://leetcode.com/explore/featured/card/recursion-i/251/scenario-i-recurrence-relation/3233/
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                throw new ArgumentNullException();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node.val.Equals(val))
                    return node;
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            return null;
        }

        public TreeNode SearchBSTRecursively(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val)
                return root;
            if (root.val > val)
                return SearchBSTRecursively(root.left, val);
            else
                return SearchBSTRecursively(root.right, val);
        }

        //https://leetcode.com/problems/cousins-in-binary-tree/
        //use bst along with for loops for levels and nulls in q for sibling markers
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                bool isCousin = false;
                bool isSibling = false;
                var index = q.Count;
                for (int i = 0; i < index; i++)
                {
                    var node = q.Dequeue();
                    if (node == null)
                        isSibling = false;
                    else
                    {
                        if (node.val == x || node.val == y)
                        {
                            if (isCousin)
                                return (!isSibling);
                            isCousin = true;
                            isSibling = true;
                        }
                        if (node.left != null) q.Enqueue(node.left);
                        if (node.right != null) q.Enqueue(node.right);
                        q.Enqueue(null);
                    }
                }
            }
            return false;
        }
        public ListNode ReverseList(ListNode head)
        {
            ListNode previous = null;
            ListNode current = head;
            while (current != null)
            {
                var tmp = current.next;
                current.next = previous;
                previous = current;
                current = tmp;
            }
            return previous;
        }
    }
}

