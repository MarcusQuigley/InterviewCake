using System;
using System.Collections.Generic;
using System.Text;

namespace Scratch
{
    public class ScratchSlidingWindows
    {
        //https://medium.com/leetcode-patterns/leetcode-pattern-2-sliding-windows-for-strings-e19af105316b
        //scratch for
        public int MaxSum(int[] arr, int k)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            var n = arr.Length;
            var max = int.MinValue;
            var sum = 0;
            
            for (int i = 0; i < n-k+1; i++)
            {
                sum = 0;
                for (int j = 0; j < k; j++)
                    sum += arr[i + j];
                max = Math.Max(max, sum);
            }
            return max;
        }
    }
}
