using System;

namespace Recursion.LeetCode
{
    public class RecursionOne
    {
        //https://leetcode.com/explore/featured/card/recursion-i/250/principle-of-recursion/1440/

        public void ReverseString(char[] s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            RecursiveReverseString(s, 0, s.Length-1);
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
            if (s.Length >1 )
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
            if (node == null)// || node.next == null)
                return null;// node;

            var firstNode = node;
            var secondNode = node.next;

            firstNode.next = SwapPairs(secondNode.next);
            secondNode.next = firstNode;

            return secondNode;
 
        }         
      
    }
}
