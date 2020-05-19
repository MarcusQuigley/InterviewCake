using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.LeetCode
{
    public class LeetHardArrays
    {
        //TODO this is probably incorrect ie not using sliding windows properly
        //239 https://leetcode.com/problems/sliding-window-maximum/
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int lastIndex = 0;
            var max = int.MinValue;
            int capacity = (nums.Length - k) + 1;
            int[] results = new int[capacity];
            while (lastIndex < capacity)
            {
                for (var i = lastIndex; i < (lastIndex + k); i++)
                {
                    max = Math.Max(max, nums[i]);
                }
                results[lastIndex++] = max;
                max = int.MinValue;
            }
            return results;
        }

        //https://leetcode.com/problems/minimum-window-substring/
        public string MinWindow(string s, string t)
        {
            if (s == null || t == null) throw new ArgumentNullException("param is null");
            Dictionary<char, int> map = new Dictionary<char, int>();
            int begin = 0;
            int end = 0;
            var min = int.MaxValue;
            var result = string.Empty;
            foreach (char c in t.ToCharArray())
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 0);
                map[c]++;
            }
            var counter = map.Count;

            while (end < s.Length)
            {
                var ch = s[end];
                if (map.ContainsKey(ch))
                {
                    map[ch]--;
                    if (map[ch] == 0)
                        counter--;
                }
                end++;
                while (counter == 0)
                {
                    var len = end - begin;
                    min = Math.Min(min, len);
                    if (min == len)
                        result = s.Substring(begin, end-begin);

                    var chb = s[begin];
                    if (map.ContainsKey(chb))
                    {
                        map[chb]++;
                        if (map[chb] > 0)
                            counter++;
                    }

                    begin++;
                }
            }
            return result;
        }
    }
}
