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
                var last = n - 1 - i;
                for (int j = first; j < last; j++)
                {
                    var offset = j - first;
                    var temp = matrix[offset][j];
                //    matrix[offset][j] = matrix[last - offset][j];
                //    matrix[end - 1 - offset][j] = matrix[end - 1 - offset][end - 1 - offset];
                //    matrix[end - 1 - offset][end - 1 - offset] = matrix[offset][end - 1 - offset] ;
                //    matrix[offset][end - 1 - offset] = temp;
                 }
            }
        }
    }
}
