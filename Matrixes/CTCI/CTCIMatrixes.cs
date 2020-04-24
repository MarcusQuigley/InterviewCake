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
    }
}
