using System;
using System.Collections.Generic;

namespace LeetStudy
{
    public class LeetStudyArrays
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            int count = 0;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    count++;
                else
                {
                    max = Math.Max(max, count);
                    count = 0;
                }
            }
            if (nums[nums.Length - 1] == 1)
                max = Math.Max(max, count);

            return max;
        }

        public int FindNumbers(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int numDivs = 0;
                int number = nums[i];
                while (number > 0)
                {
                    number /= 10;
                    numDivs++;
                }
                if (numDivs % 2 == 0)
                    count++;
            }
            return count;
        }

        public int[] SortedSquares(int[] A)
        {
            if (A == null || A.Length == 0) return new int[] { };
            var begin = 0;
            var end = A.Length - 1;
            var index = end;
            var results = new int[A.Length];
            while (begin <= end)
            {
                if (Math.Abs(A[begin]) > Math.Abs(A[end]))
                {
                    results[index] = (A[begin] * A[begin]);
                    begin++;
                }
                else
                {
                    results[index] = (A[end] * A[end]);
                    end--;
                }
                index--;
            }
            return results;
        }

        public void DuplicateZeros(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length < 2)
                return;
            var n = arr.Length - 1;

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
            var j = n;
            var i = j - numzeroes;
            while (numzeroes > 0)
            {
                if (arr[i] != 0)
                    arr[j--] = arr[i--];
                else
                {
                    arr[j--] = 0;
                    arr[j--] = arr[i--];
                    numzeroes--;
                }
            }

        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums2 == null || nums2.Length == 0)
                return;
            int j = nums1.Length - 1;
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[j--] = nums1[m - 1];
                    m--;
                }
                else
                {
                    nums1[j--] = nums2[n - 1];
                    n--;
                }
            }

            while (j >= 0 && n > 0)
            {
                nums1[j--] = nums2[--n];
            }
        }

        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++) {
                if (nums[j] != nums[i]) {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public int RemoveDuplicatesBad(int[] nums)
        {
            int size = nums.Length;
            int j = 1;
            for (int i = 0; i < size-1; i++) {
                if (nums[i] != nums[i + 1]) {
                    nums[j++] = nums[i + 1];
                }
            }
            return j;
        }


        public bool CheckIfExist(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return false;

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                //if (map.ContainsKey(arr[i] * 2) || (arr[i] % 2 == 0 && map.ContainsKey(arr[i] / 2)))
                //    return true;
                //map.Add(arr[i], arr[i]);
                if (set.Contains(arr[i] * 2) || (arr[i] % 2 == 0 && set.Contains(arr[i] / 2)))
                    return true;
                set.Add(arr[i]);
            }

            return false;
        }
        public bool ValidMountainArray(int[] arr)
        {
            if (arr == null || arr.Length < 3)
                return false;
            int n = arr.Length;
            bool peaked = false;
            return peaked;
        }
        public int[] ReplaceElements(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return arr;
            int n = arr.Length - 1;
            int max = arr[n];
            arr[n] = -1;
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[i];
                arr[i] = max;// Math.Max(max, arr[i + 1]);
                max = Math.Max(max, temp);
            }
            return arr;
        }


    }
}
