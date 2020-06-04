using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetStudy
{
    public class LeetStudyLinkedLists
    {
        //https://leetcode.com/explore/learn/card/linked-list/214/two-pointer-technique/1212/
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head));
            var runner = head.next;

            while (head != null && runner != null && runner.next != null)
            {
                if (head == runner)
                    return true;
                head = head.next;
                runner = runner.next.next;
            }
            return false;
        }

        //https://leetcode.com/explore/learn/card/linked-list/214/two-pointer-technique/1215/
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                throw new ArgumentNullException("params null");
            var tempA = headA;
            var tempB = headB;
            var countA = NodeCount(ref tempA);
            var countB = NodeCount(ref tempB);
            if (tempA != tempB)
                return null;
            if (countA > countB)
            {
                while (countA > countB)
                {
                    headA = headA.next;
                    countA -= 1;
                }
            }
            else
            {
                while (countB > countA)
                {
                    headB = headB.next;
                    countB -= 1;
                }
            }
            while (headA != headB)
            {
                headA = headA.next;
                headB = headB.next;
            }
            return headA;

        }

        int NodeCount(ref ListNode node)
        {
            int count = 0;
            while (node != null)
            {
                count += 1;
                node = node.next;
            }
            return count;
        }
        //https://leetcode.com/explore/learn/card/linked-list/219/classic-problems/1205/
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head));

            var current = head;

            while (current.next != null)
            {
                var p = current.next;
                current.next = p.next;
                p.next = head;
                current = p;
            }
            return head;
        }

        //https://leetcode.com/explore/learn/card/linked-list/219/classic-problems/1207/
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head != null)
            {
                while (head.val == val)
                {
                    if (head.next == null)
                        return null;
                    head = head.next;
                }
                ListNode prev = null;
                var current = head;
                while (current != null)
                {
                    if (current.val == val)
                        prev.next = current.next;
                    else
                        prev = current;
                    current = current.next;
                }
            }
            return head;
        }
        //https://leetcode.com/explore/learn/card/linked-list/219/classic-problems/1208/
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head));
            var odd = head;
            var even = head.next;
            var evenhead = even;
            while (odd.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenhead;
            return head;
        }
        //https://leetcode.com/explore/learn/card/linked-list/219/classic-problems/1209/
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;
            if (head.next == null) return true;

            var fast = head.next;
            var slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            slow = slow.next;
            //reverse rest of slow;
            var currentSlow = slow;
            while (slow.next != null)
            {
                var p = slow.next;
                slow.next = p.next;
                p.next = currentSlow;
                currentSlow = p;
            }
            while (currentSlow != null)
            {
                if (currentSlow.val != head.val)
                    return false;
                currentSlow = currentSlow.next;
                head = head.next;
            }
            return true;
        }
    }
}
