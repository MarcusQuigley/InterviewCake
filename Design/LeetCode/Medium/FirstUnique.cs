using System;
using System.Collections.Generic;
using System.Text;

namespace Design.LeetCode.Medium
{
    //https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3313/
    public class FirstUnique
    {
        Dictionary<int, LinkedListNode<int>> map;
        LinkedList<int> llist;

        public FirstUnique(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));

            map = new Dictionary<int, LinkedListNode<int>>();
            llist = new LinkedList<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                Add(nums[i]);
            }
        }

        public void Add(int value)
        {
            if (map.ContainsKey(value))
            {
                map[value] = null;
                llist.Remove(value);
            }
            else
            {
                LinkedListNode<int> node = new LinkedListNode<int>(value);
                map.Add(value, node);
                llist.AddLast(node);
            }
        }

        public int ShowFirstUnique()
        {
            if (llist.Count == 0)
                return -1;
            return llist.First.Value;
        }
    }
}
