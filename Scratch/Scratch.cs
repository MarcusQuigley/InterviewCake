using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scratch
{
    public class Scratch
    {
        public bool HasDuplicateUsingBits(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("Need a string to test");
            int checker = 0;
            //            var sum = s[0]-'a';
            for (int i = 0; i < s.Length; i++)
            {
                int val = s[i] - 'a';
                if ((checker & (1 << val)) > 0)
                    return true;
                checker |= (1 << val);
            }
            return false;
        }

        public void ReverseString(char[] s)
        {
            Reverse(0, s);
        }

        void Reverse(int index, char[] s)
        {
            //if (s == null || index >= s.Length / 2)
            //    return;
            //var temp = s[index];
            //s[index] = s[s.Length - 1 - index];
            //s[s.Length - 1 - index] = temp;
            //Reverse(++index, s);
            if (index >= s.Length / 2)
                return;
            var temp = s[index];
            s[index] = s[s.Length - 1 - index];
            s[s.Length - 1 - index] = temp;
            Reverse(index + 1, s);
        }
        public void printReverse(char[] str)
        {
            helper(0, str);
        }

        private void helper(int index, char[] str)
        {
            if (str == null || index >= str.Length)
            {
                return;
            }
            helper(index + 1, str);
            Console.Write(str[index]);
        }
        public ListNode SwapPairs(ListNode head)
        {
            var temp = new ListNode(0);
            temp.next = head;
            Swap(head);
            return temp.next;
        }
        public ListNode Swap(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode newHead = head.next;
            ListNode firstNode = head;
            ListNode secondNode;
            ListNode tempNode;
            while (true)
            {
                secondNode = firstNode.next;
                tempNode = secondNode.next;
                secondNode.next = firstNode;
                if (tempNode == null || tempNode.next == null)
                {
                    firstNode.next = null;
                    break;
                }
                firstNode.next = tempNode.next;
                firstNode = tempNode;

            }

            return newHead;
        }

        public ListNode SwapRecursion(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var firstNode = head;
            var secondNode = head.next;
            firstNode.next = SwapRecursion(secondNode.next);
            secondNode.next = firstNode;


            return secondNode;
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var tempHead = head;

            ListNode current = head;
            ListNode prev = null;
            ListNode temp = null;
            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            return prev;
        }

        public ListNode ReverseListRecursion(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var prev = ReverseListRecursion(head.next);
            head.next.next = head;
            head.next = null;
            return prev;
        }

        public TreeNode SearchBst(TreeNode root, int val)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));
            TreeNode result = null;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.val == val)
                {
                    result = current;
                    break;
                }
                if (current.val > val)
                {
                    if (current.left != null)
                        q.Enqueue(current.left);
                }
                else
                {
                    if (current.right != null)
                        q.Enqueue(current.right);
                }
            }
            return result;
        }

        public TreeNode SearchBstRecursion(TreeNode root, int k)
        {
            if (root == null || root.val == k)
                return root;
            if (root.val > k)
                return SearchBstRecursion(root.left, k);
            else
                return SearchBstRecursion(root.right, k);
        }
    }
}