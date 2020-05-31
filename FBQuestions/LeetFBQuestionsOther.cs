using DataStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        //
        public int[][] KClosestWithPriorityQueue(int[][] points, int K)
        {
            PriorityQueue<MyPoint> priorityQueue = new PriorityQueue<MyPoint>();

            for (int i = 0; i < points.Length; i++)
            {
                priorityQueue.Enqueue(new MyPoint(points[i][0], points[i][1]));
                if (i == K)
                    priorityQueue.Dequeue();
            }
            int[][] results = new int[K][];
            for (int j = 0; j < K; j++)
            {
                var item = priorityQueue.Dequeue();
                results[j] = new int[2];
                results[j][0] = item.X;
                results[j][1] = item.Y;
            }
            return results;
        }

        class MyPoint : IComparable<MyPoint>
        {
           readonly int x;
            readonly int y;

            public MyPoint( int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X => x;

            public int Y => y;
            public int CompareTo(  MyPoint other)
            {
                return (X * X + Y * Y) - (other.X * other.X + other.Y * other.Y);
            }
        }

    }
}
