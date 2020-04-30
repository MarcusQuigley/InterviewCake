using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.LeetCode
{
    public class LeetMediumDP
    {

        //1143 https://leetcode.com/problems/longest-common-subsequence/
        public int LongestCommonSubsequence(string text1, string text2)
        {
            if (text1 == null || text2 == null)
                throw new ArgumentNullException("one param at least is null");

            var rows = text1.Length + 1;
            var cols = text2.Length + 1;
        
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
                matrix[i] = new int[cols];
 

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    if (text1[r-1] == text2[c-1])
                        matrix[r][c] = matrix[r-1 ][c - 1] + 1;
                    else
                        matrix[r][c] = Math.Max(matrix[r- 1][c], matrix[r][c-1]);
                }
            }
            return matrix[rows-1][cols-1];
        }
    }
}
