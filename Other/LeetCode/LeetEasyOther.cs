using System;
using System.Collections.Generic;

namespace Other.LeetCode
{
    public class LeetEasyOther
    {
        //https://leetcode.com/problems/strobogrammatic-number/
        public bool IsStrobogrammatic(string num)
        {
            // Strob nums are 0 1 6 8 9 
            if (num == null)
                throw new ArgumentNullException(nameof(num));

            Dictionary<char, char> map = new Dictionary<char, char>(5)
            {
                { '0','0'},
                { '1','1'},
                { '6','9'},
                { '8','8'},
                { '9','6'}
             };
            int start = 0;
            int end = num.Length - 1;

            while(start <= end)
            {
                var startNum = num[start++];
                var endNum = num[end--];
                if (!map.ContainsKey(startNum) || !map.ContainsKey(endNum))
                    return false;
                if (map[startNum]  !=  endNum )
                    return false;
            }

            return true;
        }
    }
}
