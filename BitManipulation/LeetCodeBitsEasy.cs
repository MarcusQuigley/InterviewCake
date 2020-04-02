using System;

namespace BitManipulation
{
    public class LeetCodeBitsEasy
    {

        public int SingleNumber(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            var result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }
            return result;
        }
    }
}
