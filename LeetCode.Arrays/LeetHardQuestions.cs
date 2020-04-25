using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    public class LeetHardQuestions
    {
        //239 https://leetcode.com/problems/sliding-window-maximum/
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int lastIndex = 0;
            var max = int.MinValue;
            int capacity = (nums.Length - k) +1;
            int[] results = new int[capacity];
            while (lastIndex < capacity)
            {
                for(var i = lastIndex; i < (lastIndex + k); i++)
                {
                    max = Math.Max(max, nums[i]);
                }
                results[lastIndex++] = max;
                max = int.MinValue;
            }
            return results;
        }


    }
}
