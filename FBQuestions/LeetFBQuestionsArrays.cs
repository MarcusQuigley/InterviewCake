using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FBQuestions
{
    public class LeetFBQuestionsArrays
    {
        //953 https://leetcode.com/problems/verifying-an-alien-dictionary/
        //Easy
        public bool IsAlienSorted(string[] words, string order)
        {
            if (words == null || words.Length == 0 || string.IsNullOrEmpty(order))
                return false;
            int[] map = new int[26];
            for (int i = 0; i < order.Length; i++)
                map[order[i] - 'a'] = i;

            for (int i = 1; i < words.Length; i++)
            {
                if (CompareWords(words[i - 1], words[i], map) > 0)
                    return false;
            }
            return true;
        }
        int CompareWords(string word1, string word2, int[] map)
        {
            int i = 0;
            int j = 0;
            int compareDiff = 0;
            while (i < word1.Length && j < word2.Length && compareDiff == 0)
            {
                compareDiff = map[word1[i] - 'a'] - map[word2[i] - 'a'];
                i++;
                j++;
            }
            if (compareDiff == 0)
                return word1.Length - word2.Length;
            return compareDiff;
        }

        //986 https://leetcode.com/problems/interval-list-intersections/
        //Medium
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            if (A == null || B == null)
                throw new ArgumentNullException("One or both params null");
            var results = new List<int[]>();
            var aIndex = 0;
            var bIndex = 0;
            while (aIndex < A.Length && bIndex < B.Length)
            {
                var maxStart = Math.Max(A[aIndex][0], B[bIndex][0]);
                var minEnd = Math.Min(A[aIndex][1], B[bIndex][1]);
                if (maxStart <= minEnd)
                    results.Add(new int[] { maxStart, minEnd });

                if (minEnd == A[aIndex][1])
                    aIndex++;
                else
                    bIndex++;
            }
            return results.ToArray();
        }

        CompareResult ComparePoints(int[] pointA, int[] pointB)
        {
            var result = new CompareResult();
            if (pointA[0] == pointB[0])
            {
                if (pointA[1] == pointB[1]) //both equal
                    return new CompareResult() { Intersects = true, Intersection = pointA, IncrementAIndex = true, IncrementBIndex = true };
                if (pointA[1] < pointB[1])
                    return new CompareResult() { Intersects = true, Intersection = pointA, IncrementAIndex = true, IncrementBIndex = false };
                else
                    return new CompareResult() { Intersects = true, Intersection = pointB, IncrementAIndex = false, IncrementBIndex = true };
            }
            else
            {
                var earlier = pointA[0] < pointB[0] ? pointA : pointB;
                var later = pointA[0] < pointB[0] ? pointB : pointA;
                //if(earlier[1]<later[0]) //earlier ends before later starts no intersection
            }
            return result;
        }

        private struct CompareResult
        {
            public bool Intersects { get; set; }
            public bool IncrementAIndex { get; set; }
            public bool IncrementBIndex { get; set; }
            public int[] Intersection { get; set; }
        }

        public bool ValidPalindromeOld(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException(nameof(s));
            //if (s.Length == 1)
            //    return false;
            var arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                var val = s[i] - 'a';
                arr[val] = arr[val] == 0 ? 1 : 0;
            }
            var begin = 0;
            var end = s.Length - 1;
            var matches = true;
            while (begin <= end)
            {
                arr[s[begin] - 'a'] += 1;
                if (begin != end)
                {
                    arr[s[end] - 'a'] += 1;
                }

                if (s[begin] - 'a' != s[end] - 'a')
                {
                    if (matches == false)
                        return false;
                    matches = false;
                }

                begin++;
                end--;
            }
            if (!matches)
            { //go thru arr and return false if more than 2 chars are >0
                var letterscount = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > 0)
                    {
                        letterscount += 1;
                        if (letterscount > 2)
                            return false;
                    }
                }

            }
            return true;
        }

        //125 https://leetcode.com/problems/valid-palindrome/
        public bool IsPalindrome(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (s.Trim() == "") return true;
            var n = s.Length - 1;
            var begin = 0;
            var end = n;
            while (begin < end)
            {
                while (!IsLegitChar(s[begin]) && begin < n)
                    begin++;
                while (!IsLegitChar(s[end]) && end > 0)
                    end--;
                if (begin >= end)
                    break;
                var charBegin = s[begin];
                var charEnd = s[end];
                if (charBegin < 97)
                    charBegin += ' ';
                if (charEnd < 97)
                    charEnd += ' ';
                if (charBegin != charEnd)
                    return false;
                begin++;
                end--;
            }
            return true;
        }

        bool IsLegitChar(char c)
        {
            if (c > 47 && c < 123)
            {
                if ((c > 47 && c < 58) || (c > 64 && c < 91) || (c > 96 && c < 123))
                    return true;
            }
            return false;
        }
        //https://leetcode.com/problems/valid-palindrome-ii/
        public bool ValidPalindrome(string s)
        {
            var start = 0;
            var end = s.Length - 1;
            while(start < end)
            {
                if (s[start]!= s[end])
                {
                    return (IsPal(s, start + 1, end) || IsPal(s, start, end - 1));
                }
                start++;
                end--;
            }
            return true;
        }

        private bool IsPal(string s, int i, int j)
        {
            while(i < j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }
    }
}
