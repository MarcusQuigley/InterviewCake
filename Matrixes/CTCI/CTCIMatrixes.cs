using System;
using System.Collections.Generic;
using System.Text;

namespace Matrixes.CTCI
{
    public class CTCIMatrixes
    {

        public void RotateMatrix(int[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            var n = matrix.Length;
            if (n < 2) 
                return;

            for (int i = 0; i < n/2; i++)
            {
                var first = i;
                var last = n - 1 - first;
                for (int j = first; j < last; j++)
                {
                    var offset = j - first;
                    var temp = matrix[first][j];
                    matrix[first][j] = matrix[last-offset][first];
                    matrix[last - offset][first] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[j][last];
                    matrix[j][last] = temp;
                }
            }
        }

        //https://www.geeksforgeeks.org/shortest-distance-two-cells-matrix-grid/
        //This is not a CTCI question but what the heck.
        //Can only think of 1 way.
        //For loops
        public int MinDistance(char[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0) return -1;
            var result = -1;
            QItem source = null;
            var n = matrix.Length;
            var m = matrix[0].Length;
            var visited = new bool[n, m];
            for (int i = 0; i < matrix.Length; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    var cell = matrix[i][j];
                    if (cell == 's' || cell == '0')
                    {
                        visited[i, j] = true;
                        if (cell == 's')
                            source = new QItem(i, j, 0);
                    }
                }
            }
            if (source != null)
            {
                var allowedMoves = new int[4][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

                Queue<QItem> q = new Queue<QItem>(new QItem[] { source});
                var min = int.MaxValue;

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    if (matrix[current.Row][current.Col] == 'd')
                        min = Math.Min(min, current.Total);
                    else
                    {
                        foreach (var move in allowedMoves)
                        {
                            var newMove = new int[] { current.Row + move[0], current.Col + move[1] };
                            if ((newMove[0] > -1 && newMove[0] < n)
                                && (newMove[1] > -1 && newMove[1] < m)
                                && (visited[newMove[0], newMove[1]] == false))
                                //&& (matrix[newMove[0]][newMove[1]] == '*' || matrix[newMove[0]][newMove[1]] == 'd'))
                            {
                                q.Enqueue(new QItem(newMove[0], newMove[1], current.Total + 1));
                                visited[newMove[0], newMove[1]] = true;
                            }
                        }
                    }
                }
                if (min != int.MaxValue)
                    result = min;
            }
            return result;
        }
    }
}
