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

            while(head!=null && runner!=null && runner.next != null)
            {
                if (head == runner)
                    return true;
                head = head.next;
                runner = runner.next.next;
            }
            return false;
        }

       
    }
}
