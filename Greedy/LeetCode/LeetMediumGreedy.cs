using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.LeetCode
{
    public class LeetMediumGreedy
    {

        // 402 https://leetcode.com/problems/remove-k-digits/
        public string RemoveKdigits2(string num, int k)
        {
            if (num == null)
                throw new ArgumentNullException(nameof(num));
            var n = num.Length;
            
            if (n <= k)
                return num;
            Stack<int> stack = new Stack<int>();
            for (int i = 1; i < n-1; i++)
            {
                if (num[i] < num[i - 1])
                    stack.Push(i - 1);
                 
                if (stack.Count == k)
                    break;
            }
            var sb = new StringBuilder(num.Length - k);
            for (int i = n - 1; i < n-1; i++)
            {
                if (stack.Peek() != i)
                    sb.Append(num[i]);
                else
                {
                    stack.Pop();
                }

            }

            return sb.ToString();
        }

        // 402 https://leetcode.com/problems/remove-k-digits/
        public string RemoveKdigits(string num, int k)
        {
            if (num == null)
                throw new ArgumentNullException(nameof(num));
 
            LinkedList<char> stack = new LinkedList<char>();
            foreach (char digit in num.ToCharArray())
            {
                while (stack.Count > 0 && k > 0 && stack.Last.Value > digit)
                {
                    stack.RemoveLast();
                    k--;
                }
                stack.AddLast(digit);
            }
            for (int i = 0; i < k; i++)
            {
                stack.RemoveLast();
            }

            var current = stack.First;
            while (current != null && current.Value == '0' && stack.Count > 1)
            {
                current = current.Next;
                stack.RemoveFirst();
            }

            var sb = new StringBuilder(stack.Count);
            current = stack.First;
            while (current != null)
            {
                sb.Append(current.Value);
                current = current.Next;
            }

            return (sb.Length>0)? sb.ToString():"0";
        }     
    }
}
