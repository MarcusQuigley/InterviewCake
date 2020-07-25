using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonQuestions.Study
{
  public  class AmazonLinkedLists
    {
        //Medium 2 https://leetcode.com/problems/add-two-numbers/
        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            var counter = 0;
            var l1Number = ListToNumber(l1);
            var l2Number = ListToNumber(l2);
            
            var sum = l1Number + l2Number;
            var jj = sum % 10;
            ListNode result = new ListNode((int)(sum % 10));
            ListNode current = result;
            sum /= 10;
            while (sum > 0)
            {
                current.next = new ListNode((int)(sum % 10));
                current = current.next;
                sum /= 10;
            }
            return result;
        }

        private long ListToNumber(  ListNode root )
        {
            int counter = 0;
            long result = 0;
            while (root != null)
            {
                result += MyPow(10, counter) * root.val;
                counter += 1;
                root = root.next;
            }
            return result;
        }

        long MyPow(int number, int exponent)
        {
            var result = 1;
            for (int i = 1; i <= exponent; i++)
                 result *= number;
            return result;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
                throw new ArgumentNullException("one of the params");
            ListNode temp  = new ListNode(0);
            ListNode ans = temp;
            int carry = 0;

            while (l1 != null || l2 != null || carry > 0)
            {
                int res = ((l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry);
                ans.next = new ListNode(res % 10);
                carry = res / 10;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
                ans = ans.next; 
            }
             return temp.next;
        }
    }
}
