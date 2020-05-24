using System;
using System.Collections.Generic;
using System.Text;

namespace FBQuestions
{
    public class LeetFBQuestionsArrays
    {
        //953 https://leetcode.com/problems/verifying-an-alien-dictionary/
        //Easy
        public bool IsAlienSorted(string[] words, string order)
        {
            if (words == null || string.IsNullOrEmpty(order))
                return false;
            Dictionary<char, int> map = new Dictionary<char, int>();
             for (int i = 0; i < order.Length; i++)
                map.Add(order[i], i);

            var endIndex = 0;
            var col = 0;
            var index = 0;
            while (endIndex < words.Length)
            {
                 var rowsChecked =0;
                var tempIndex = index;
                for (int row = 0; row < words.Length; row++)
                {
                     if (words[row].Length-1 >= col)
                    {
                        var @char = words[row][col];
                        var orderIndex = map[@char];
                        if (orderIndex < index)
                            return false;
                        index = orderIndex;
                        if (words[row].Length-1 == col)
                            endIndex++;
                        rowsChecked++;
                    }
                    //else
                    //{
                    //    if (row != endIndex)
                    //        return false;
                    //    //if (endIndex++ == words.Length)
                    //    //    return true;
                    //}
                }
                //need to check here for something..
                if (rowsChecked == (index - tempIndex))
                    return true;
                col++;
            }
            return true;
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
