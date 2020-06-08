using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Sorting.Algorithms
{
 public   class QuickSortImpl
    {
        public void QuickSort(int[] array) {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            QuickSort(array, 0, array.Length - 1);
        }

        void QuickSort(int[] array, int start, int end) {
            var index = Partition(array, start, end);
            if (start < index - 1)
                QuickSort(array, start, index-1);
            if (index < end)
                QuickSort(array, index, end);
        }

        int Partition(int[] array, int start, int end)
        {
            var pivot = array[(start+end)/2];
            while(start <= end)
            {
                while (array[start] < pivot)
                    start++;
                while (array[end] > pivot)
                    end--;
                if (start <= end)
                {
                    var temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;
                    start++;
                    end--;
                }
            }
            return start;
        }
    }
}
