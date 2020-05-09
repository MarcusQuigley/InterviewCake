using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.LeetCode
{
    public class LeetEasyLinkedList
    {
        //1290 https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/submissions/
        public int GetDecimalValue(ListNode head)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));

            StringBuilder sb = new StringBuilder();

            while (head != null)
            {
                sb.Append(head.val);
                head = head.next;
            }
            return Convert.ToInt32(sb.ToString(), 2);
        }

        //876. https://leetcode.com/problems/middle-of-the-linked-list/
        public ListNode MiddleNode(ListNode head)
        {
            var pointer2 = head;
            while (pointer2 != null && pointer2.next != null)
            {
                head = head.next;
                pointer2 = pointer2.next.next;
            }
            return head;
        }

        //141 https://leetcode.com/problems/linked-list-cycle/
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head));
            var p1 = head;
            var p2 = head.next;
            while (p1 != null && p2 != null)
            {
                if (p1 == p2) return true;
                if (p2.next == null) return false;
                p1 = p1.next;
                p2 = p2.next.next;
            }
            return false;
        }

        //160 https://leetcode.com/problems/intersection-of-two-linked-lists/
        public ListNode GetIntersectionNodeBrute(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;
            Dictionary<ListNode, int> map = new Dictionary<ListNode, int>();

            AddToMap(headA, map);
            var result = AddToMap(headB, map);

            return result;
        }

        ListNode AddToMap(ListNode node, Dictionary<ListNode, int> map)
        {
            while (node != null)
            {
                if (map.ContainsKey(node))
                    return node;
                map.Add(node, 1);
                node = node.next;
            }
            return null;
        }

        //160 https://leetcode.com/problems/intersection-of-two-linked-lists/
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var hATemp = headA;
            var hBTemp = headB;
            if (headA == null || headB == null)
                return null;
            var lengthA = GetLinkedListLength(ref hATemp);
            var lengthB = GetLinkedListLength(ref hBTemp);

            if (hATemp != hBTemp) return null;
            if (lengthA != lengthB)
            {
                var diff = 0;
                if (lengthA < lengthB)
                {
                    diff = lengthB - lengthA;
                    while (diff > 0)
                    {
                        headB = headB.next;
                        diff -= 1;
                    }
                }
                else
                {
                    diff = lengthA - lengthB;
                    while (diff > 0)
                    {
                        headA = headA.next;
                        diff -= 1;
                    }
                }
            }
            while (headA != headB)
            {
                headA = headA.next;
                headB = headB.next;
            }

            return headA;
        }

        int GetLinkedListLength(ref ListNode node)
        {
            var count = 0;
            while (node.next != null)
            {
                count += 1;
                node = node.next;
            }
            return count;
        }
    }
}
 