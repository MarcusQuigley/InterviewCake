using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public int[] TwoSumBrute(int[] nums, int target)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            var result = new int[2];
            var n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        break;
                    }
                }
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
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/discuss/1730/Shortest-O(n)-DP-solution-with-explanations
        public int LengthOfLongestSubstringUsingArray(string s)
        {//ingUsik
            int[] charIndexs = new int[128];
            for (int i = 0; i < charIndexs.Length; i++)
                charIndexs[i] = -1;
           
            int max = 0;
            int begin = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var _char = s[i];
                begin = Math.Max(charIndexs[_char] + 1, begin);
                charIndexs[_char] = i;
                max = Math.Max(max, i - begin + 1);
            }
            return max;
        }

        //Medium https://leetcode.com/problems/string-to-integer-atoi/
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            var trimmedStr = str.Trim();
            if (trimmedStr == "")
                return 0;
            var isNegative = false;
            var stringDigit = new StringBuilder(trimmedStr.Length);
            var firstChar = trimmedStr[0];

            if (IsDigit(firstChar))
                stringDigit.Append(firstChar);
            else if (firstChar == '-')
                isNegative = true;
            else if (firstChar == '+')
                isNegative = false;
            else
                return 0;

            int i = 1;
            for (i = 1; i < trimmedStr.Length; i++)
            {
                if (!IsDigit(trimmedStr[i]))
                    break;
            }
            stringDigit.Append(trimmedStr.Substring(1, i - 1));
            if (stringDigit.Length == 0)
                return 0;

            if (!long.TryParse(stringDigit.ToString(), out var number))
                number = 2147483648;
            if (number > int.MaxValue)
            {
                if (isNegative)
                    number = int.MinValue;
                else
                    number = int.MaxValue;
            }
            if (isNegative)
                number *= -1;
            return (int) number;
        }

        bool IsDigit(char c)
        {
            return c > 47 && c < 58;
        }

    }
}
