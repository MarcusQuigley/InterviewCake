using System;

namespace BitManipulation
{
    public class LeetCodeBitsEasy
    {

        //https://leetcode.com/problems/single-number/
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

        //https://leetcode.com/problems/missing-number/
        //This is similar to the Single number problem above
        //We use the array index and array values to cancel each other out using XOR. 
        //then we need to subtract the result from the len of the array for the answer
        public int MissingNumber(int[] nums)
        {
            var answer = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                answer ^= nums[i] ^ i;
            }
            return nums.Length ^ answer;
        }
    }
}
