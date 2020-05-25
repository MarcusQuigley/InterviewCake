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
            while(i<word1.Length &&  j < word2.Length && compareDiff == 0)
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
             while(aIndex<A.Length && bIndex < B.Length)
            {
                var maxStart = Math.Max(A[aIndex][0], B[bIndex][0]);
                var minEnd = Math.Min(A[aIndex][1], B[bIndex][1]);
                if(maxStart <= minEnd)
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
                if(pointA[1]<pointB[1])
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
    }
}
