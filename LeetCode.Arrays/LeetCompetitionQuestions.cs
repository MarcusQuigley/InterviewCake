using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    public class LeetCompetitionQuestions
    {

        //https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3299/
        public string StringShift(string s, int[][] shift)
        {
            if (s.Length < 2)
                return s;

            int left_shift = 0;
            int right_shift = 0;
            foreach (var items in shift)
            {
                if (items[0] == 0)
                    left_shift += items[1];
                else
                    right_shift += items[1];
            }
            string result = string.Empty;
            if (left_shift > right_shift)
            {
                left_shift -= right_shift;
                left_shift %= s.Length;
                result += s.Substring(left_shift, (s.Length - left_shift));
                result += s.Substring(0, left_shift);
            }
            else
            {
                right_shift -= left_shift;
                right_shift %= s.Length;
                result += s.Substring(s.Length - right_shift, right_shift);
                result += s.Substring(0, s.Length- right_shift);

            }
            return result;
        }
    }
}
