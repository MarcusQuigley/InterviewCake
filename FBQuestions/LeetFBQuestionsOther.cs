using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FBQuestions
{
    public class LeetFBQuestionsOther
    {
        //973 https://leetcode.com/problems/k-closest-points-to-origin/
        //Medium
        public int[][] KClosest(int[][] points, int K)
        {
            int n = points.Length;
            int[] distances = new int[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = Distance(points[i]);
            }

            Array.Sort(distances);
            var kthItem = distances[K - 1];

            int[][] results = new int[K][];
            for (int i = 0; i < K; i++)
                results[i] = new int[2];

            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (Distance(points[i]) <= kthItem)
                    results[j++] = points[i];
            }

            return results;
        }

        int Distance(int[] point)
        {
            return point[0] * point[0] + point[1] * point[1];
        }
    }
}
