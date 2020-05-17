using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.LeetCode
{
    public class LeetMediumLinkedList
    {


        //141 https://leetcode.com/problems/linked-list-cycle/
        public ListNode DetectCycleOld(ListNode head)
        {
            if (head != null)
            {
                var p1 = head;
                var p2 = head;
                while (p1 != null && p2 != null)
                {
                    if (p1 == p2)
                    {
                        p1 = head;
                        while (true)
                        {
                            if (p1 == p2)
                                return p1;
                            p1 = p1.next;
                            p2 = p2.next;
                        }
                    }
                    else
                    {
                        if (p2.next == null)
                            return null;
                        p1 = p1.next;
                        p2 = p2.next.next;
                    }
                }
            }
            return null;
        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;
            var intersect = GetIntersect(head);
            if (intersect == null) return null; //no cycle;


            while (head != intersect)
            {
                head = head.next;
                intersect = intersect.next;
            }
            return head;
        }

        ListNode GetIntersect(ListNode node)
        {
            var p1 = node;
            var p2 = node;
            while (p1 != null && p2.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
                if (p1 == p2)
                    return p1;
            }
            return null;
        }

        //19 https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var slow = head;
            var fast = head;
            for (int i = 0; i < n; i++)
                fast = fast.next;
            if (fast == null)
                return head.next;
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            return head;

        }
    }
}
