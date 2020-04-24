using System;
using System.Collections.Generic;
using System.Text;

namespace Matrixes.LeetCode
{
    public class LeetMediumMatrixes
    {
        // Leet 200 https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3302/
        //BFS 
        public int NumIslands(char[][] grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));
            if (grid.Length == 0) return 0;
            var n = grid.Length;
            var m = grid[0].Length;
            var result = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        BFSIslands(grid, i, j);
                        result += 1;
                    }
                }
            }
            return result;
}
        void BFSIslands(char[][] grid, int row, int col)
        {
            var n = grid.Length;
            var m = grid[0].Length;
            if ((row > -1 && row < n) &&
                (col > -1 && col < m) &&
                grid[row][col] == '1')
            {
                grid[row][col] = '0';
            
            BFSIslands(grid, row, col - 1);
            BFSIslands(grid, row, col + 1);
            BFSIslands(grid, row - 1, col);
            BFSIslands(grid, row + 1, col);
            }
        }
    }
}
