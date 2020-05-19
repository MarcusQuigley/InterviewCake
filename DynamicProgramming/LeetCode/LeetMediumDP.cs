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

        //221 https://leetcode.com/problems/maximal-square/
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0 || matrix[0].Length==0)
                return 0;
            var rows = matrix.Length+1;
            var cols = matrix[0].Length+1;

            var resultMatrix = new int[rows][];
            for (int i = 0; i < rows; i++)
                resultMatrix[i] = new int[cols];
            var max = int.MinValue;

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    if (matrix[r - 1][c - 1] == '1')
                    {
                        var mintemp = Math.Min(resultMatrix[r][c - 1] , resultMatrix[r - 1][c - 1]);
                        var min = Math.Min(mintemp, resultMatrix[r - 1][c])+1;
                        resultMatrix[r][c] = min;
                        max = Math.Max(max, min);
                    }
                }
            }
            return max * max;
        }
    }
}
