using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.LeetCode
{
    public class LeetHardDP
    {

        //72 https://leetcode.com/problems/edit-distance/
        public int MinDistance(string word1, string word2)
        {
            if (word1 == null || word2 == null)
                throw new ArgumentNullException("one param at least is null");

            var rows = word1.Length + 1;
            var cols = word2.Length + 1;
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                matrix[i][0] = i;
            }
            for (int j = 0; j < cols; j++)
            {
                matrix[0][j] = j;
            }
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (word1[i - 1] != word2[j - 1])
                    {
                        matrix[i][j] = ThreeMin(matrix[i - 1][j], matrix[i][j - 1], matrix[i - 1][j - 1]) + 1;
                    }
                    else
                        matrix[i][j] = matrix[i - 1][j - 1];
                }
            }
            return matrix[rows - 1][cols - 1];
        }
        int ThreeMin(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
