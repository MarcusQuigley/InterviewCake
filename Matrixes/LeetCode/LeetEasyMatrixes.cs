using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Matrixes.LeetCode
{
    public class LeetEasyMatrixes
    {
        // Leet 733 https://leetcode.com/problems/flood-fill/
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (image[sr][sc] == newColor)
                return image;
            int validColor = image[sr][sc];
            var validMoves = new int[4][] { new int[2] { -1, 0 }, new int[2] { 1, 0 }, new int[2] { 0, -1 }, new int[2] { 0, 1 } };

            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { sr, sc });
            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                image[cell[0]][cell[1]] = newColor;
                foreach (var move in validMoves)
                {
                    if (CellValid(image, cell[0] + move[0], cell[1] + move[1], validColor))
                        queue.Enqueue(new int[] { cell[0] + move[0], cell[1] + move[1] });
                }
            }
            return image;
        }

        bool CellValid(int[][] image, int row, int col, int validColor)
        {
            if (row > -1 && row < image.Length &&
              col > -1 && col < image[0].Length &&

              image[row][col] == validColor)
                return true;
            return false;
        }
    }
}
