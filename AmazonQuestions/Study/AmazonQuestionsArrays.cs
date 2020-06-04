using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonQuestions.Study
{
    public class AmazonQuestionsArrays
    {

        //Easy https://leetcode.com/problems/two-sum/
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            var result = new int[2];
            var n = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                var current = nums[i];
                var diff = target - current;

                if (map.ContainsKey(diff))
                {
                    result[0] = map[diff];
                    result[1] = i;
                    break;
                }
                if (!map.ContainsKey(current))
                    map.Add(current, i);

            }
            return result;
        }

        //Medium https://leetcode.com/problems/longest-substring-without-repeating-characters/
        public int LengthOfLongestSubstring(string s)
        {
            //pwwkew
            if (s == null)
                throw new ArgumentNullException();
            if (s.Length==0)
                return 0;

            var begin = 0;
            var end = 0;
            var n = s.Length;
            var max = 0;
            while (end < n)
            {
                var val = s[end];
                var i = begin;
                while (i < end)
                {
                    if (s[i] == val)
                    {
                        max = Math.Max(max, end - begin);
                        begin = i+1;
                        break;
                    }
                    i++;
                }
                end++;
            }
            max = Math.Max(max, end - begin );
            return max;
        }

    }
}
