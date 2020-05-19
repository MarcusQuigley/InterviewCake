using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrixes.LeetCode
{
  public  class LeetCompetitionMatrixes
    {
        //https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3306/
        public int LeftMostColumnWithOne(IBinaryMatrix binaryMatrix)
        {
            var dimensions = binaryMatrix.Dimensions();
            var min = int.MaxValue;
            for(int row = 0;row < dimensions[0]; row++)
            {
                var low = 0;
                var high = dimensions[1]-1;
                while (low <= high)
                {
                    var mid = (low + high) / 2;
                    if (binaryMatrix.Get(row, mid) == 1)
                    {
                        if (mid == 0)
                            return 0; // we're done completely. Cant get lower than zero.
                        else if (binaryMatrix.Get(row, mid - 1) == 0)
                        {
                            min = Math.Min(min, mid);
                            break; //move to next row
                        }    
                        else
                        {
                            high = mid - 1;
                        }
                    }
                    else
                    {
                        low = mid+1;
                    }
                }
            }

            return (min < int.MaxValue) ? min : -1;
        }
              
    }
    public interface IBinaryMatrix
    {
        IList<int> Dimensions();
        int Get(int row, int col);
    }

    public class BinaryMatrix : IBinaryMatrix
    {
        readonly int[][] _matrix = null;
        int _count = 0;
        public BinaryMatrix(int[][] matrix)
        {
            _matrix = matrix;
        }

        public IList<int> Dimensions()
        {
            return new int[] { _matrix.Length, _matrix[0].Length }.ToArray();
        }

        public int Get(int row, int col)
        {
            _count += 1;
            if (_count > 999)
                throw new InvalidOperationException("Too many calls were made to Get");
            if (row > _matrix.Length - 1)
                throw new InvalidOperationException("Matrix does not contain that number of rows");
            if (col > _matrix[0].Length - 1)
                throw new InvalidOperationException("Matrix does not contain that number of cols");

            return _matrix[row][col];
        }
    }
}
