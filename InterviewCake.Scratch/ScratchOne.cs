using System;

namespace InterviewCake.Scratch
{
    public class ScratchOne
    {

        public bool BinarySearchIterative(int[] arr, int value)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = 0;

            while(low <= high)
            {
                mid = (high + low) / 2;
                var item = arr[mid];
                if (item == value) return true;
                if (item > value)
                {
                    high = mid - 1;

                }
                else
                    low = mid + 1;
            }
            return false;
        }

        public bool BinarySearch(int[] arr, int value)
        {
            if (arr == null || arr.Length == 0) return false;
            int low = 0;
            int high = arr.Length - 1;
            return BinarySearchRecursive(arr, low, high, value);

        }

          bool BinarySearchRecursive(int[] arr, int low, int high, int value)
        {
            if (high < low)
                return false;
            int mid = (high + low) / 2;
            int item = arr[mid];
            
            if (value > item)
                low = mid + 1;
            else if (value < item)
                high = mid - 1;
            else //val == item!
                return true;

            return BinarySearchRecursive(arr, low, high, value);
        }
    }
}
