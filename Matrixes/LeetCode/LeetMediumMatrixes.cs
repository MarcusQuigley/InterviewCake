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

        //Leet 64 https://leetcode.com/problems/minimum-path-sum/
        //Dynamic Programming 
        public int MinPathSum(int[][] grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));
            if (grid.Length == 0)
                return 0;

            var n = grid.Length;
            var m = grid[0].Length;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (row == 0)
                    {
                        if (col > 0)
                            grid[row][col] = grid[row][col] + grid[row][col - 1];
                    }
                    else if (col == 0)
                        grid[row][col] = grid[row][col] + grid[row - 1][col];
                    else
                    {
                        var min = Math.Min(grid[row][col - 1], grid[row - 1][col]);
                        grid[row][col] = grid[row][col] + min;
                    }
                }
            }
            return grid[n - 1][m - 1];
        }

        //Leet 1091 https://leetcode.com/problems/shortest-path-in-binary-matrix/
        //BFS
        //all moves array
        //set grid cell to visited after queuing it
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));
            int n = grid.Length;
            var result = -1;

            if (n == 0 || grid[0][0] != 0 || grid[n - 1][n - 1] != 0)
                return result;

            var source = new QItem(0, 0, 1);
            var moves = new int[8][] { new int[2] { 0, 1 }, new int[2] { 0, -1 }, new int[2] { 1, 0 }, new int[2] { -1, 0 },
            new int[2] { -1, -1 }, new int[2] { 1, -1 }, new int[2] { 1, 1 }, new int[2] { -1, 1 } };
            Func<int[], bool> ValidMove = current => current[0] > -1 && current[0] < n &&
                                                     current[1] > -1 && current[1] < n &&
                                                     grid[current[0]][current[1]] == 0;


            var q = new Queue<QItem>();
            q.Enqueue(source);
            var min = int.MaxValue;
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.Row == n - 1 && current.Col == n - 1)
                {
                    min = Math.Min(min, current.Total);
                }
                else
                {
                    foreach (var move in moves)
                    {
                        var newmove = new int[2] { current.Row + move[0], current.Col + move[1] };
                        if (ValidMove(newmove))
                        {
                            q.Enqueue(new QItem(newmove[0], newmove[1], current.Total + 1));
                            grid[newmove[0]][newmove[1]] = 1;
                        }
                    }
                }
            }
            if (min != int.MaxValue)
                result = min;
            return result;
        }

        //1277 https://leetcode.com/problems/count-square-submatrices-with-all-ones/
        //Dynamic programming
        public int CountSquares(int[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            int result = 0;
            for (int i = 0; i < matrix[0].Length; i++)
                result += matrix[0][i];
            for (int j = 1; j < matrix.Length; j++)
                result += matrix[j][0];
            for (int r = 1; r < matrix.Length; r++)
            {
                for (int c = 1; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] == 1)
                    {
                        matrix[r][c] =  1 + MinOfThree(matrix[r - 1][c - 1], matrix[r-1][c], matrix[r][c-1]);
                        result += matrix[r][c];
                    }
                }
            }
            return result;
        }

        int MinOfThree(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
