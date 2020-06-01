using System;

namespace LeetStudy
{
    public class LeetStudyArrays
    {
        public int[] SortedSquares(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            var n = nums.Length;
            var b = 0;
            var e = n - 1;
            var j = e;
            var results = new int[n];
            {
                while (b <= e)
                {
                    if (Math.Abs(nums[b]) > Math.Abs(nums[e]))
                    {
                        results[j] = Math.Abs(nums[b]) * Math.Abs(nums[b]);
                        b++;
                    }
                    else
                    {
                        results[j] = Math.Abs(nums[e]) * Math.Abs(nums[e]);
                        e--;
                    }
                    j--;
                }
            }
            return results;
        }
        //[1,0,2,3,0,4,5,0]
        //https://leetcode.com/explore/learn/card/fun-with-arrays/525/inserting-items-into-an-array/3245/
        public void DuplicateZeros(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length <2)
                return;
            var n = arr.Length-1;
            
            var numzeroes = 0;
            for (int k = 0; k < n - numzeroes; k++)
            {
                if (arr[k] == 0)
                {
                    if (k == n - numzeroes)
                    {
                        arr[n] = 0;
                        n -= 1;
                        break;
                    }
                    numzeroes += 1;
                }
            }
            if (numzeroes == 0)
                return;
            var j = n ;
            var i = j - numzeroes;
            while (numzeroes > 0)
            {
                if (arr[i] != 0)
                {
                    arr[j] = arr[i];
                    i--;
                    j--;
                }
                else
                {
                    arr[j] = 0;
                    j--;
                    arr[j] = arr[i];
                    i--;
                    j--;
                    numzeroes--;
                }
            }

        }
    }
}
