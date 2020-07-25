using DataStructures;
using LinkedLists.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Tests
{
   public static class LinkedListHelper
    {
        #region Helpers

        public static ListNode CreateLinkedList(int[] values)
        {
            var head = new ListNode(values[0]);
            var current = head;
            for (int i = 1; i < values.Length; i++)
            {
                //  while(current.next !=null)
                current.next = new ListNode(values[i]);
                current = current.next;
            }
            return head;
        }

        public static int[] ListFromListNode(ListNode node)
        {
            List<int> vals = new List<int>();
            if (node != null)
            {
                while (node != null)
                {
                    vals.Add(node.val);
                    node = node.next;
                }
            }
            return vals.ToArray();
        }
        #endregion
    }
}
