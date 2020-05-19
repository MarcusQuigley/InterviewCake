using LinkedLists.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    //https://leetcode.com/explore/learn/card/linked-list/209/singly-linked-list/1290/
    public class MyLinkedList
    {
        ListNode head = null;
        ListNode tail = null;
        int count = 0;
 
        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index < count)
            {
                var node = head;
                int counter = 0;
                while (node != null)
                {
                    if (index == counter)
                        return node.val;
                    node = node.next;
                    counter += 1;
                }
            }
            return -1;
        }

         public void AddAtHead(int val)
        {
            var node = new ListNode(val);
            node.next = head;
            if (head == null)
                tail = node;
            head = node;
            count += 1;
        }

         public void AddAtTail(int val)
        {
            var node = new ListNode(val);
            if (tail != null)
                tail.next = node;
            else
                head = node;
            tail = node;
            count += 1;
        }

        /** Add a node of value val before the index-th node in the linked list. 
         * If index equals to the length of linked list, the node will be appended to the end of linked list. 
         * If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > count)
                return;
            else if (index == 0)
                AddAtHead(val);
            else if (index == count)
                AddAtTail(val);
            else
            {
                var node = new ListNode(val);
                var current = head;
                var ctr = 0;
                while (current != null)
                {
                    if (index - ctr == 1)
                    {
                        node.next = current.next;
                        current.next = node;
                        count += 1;
                        return;
                    }
                    else
                    {
                        current = current.next;
                        ctr += 1;
                    }
                }
            }
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index == count)
                return;
            else if (index==0)
                head = head.next;
             else
            {
                ListNode prev = null;
                ListNode current = head;
                int ctr = 0;
                while(ctr < index)
                {
                    prev = current;
                    current = current.next;
                    ctr += 1;
                }
                prev.next = current.next;
                if (index + 1 == count)
                    tail = prev;
            }
            count -= 1;
        }
    }
}
