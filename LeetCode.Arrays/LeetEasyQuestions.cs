using System;
using System.Collections.Generic;

namespace LeetCode.Arrays
{
    public class LeetEasyQuestions
    {
        // 1295 https://leetcode.com/problems/find-numbers-with-even-number-of-digits/
        public int FindNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;
            var result = 0;

            //foreach (var number in numbers){
            for (int i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];
                var counter = 0;
                while (number > 0)
                {
                    number /= 10;
                    counter += 1;
                }
                if (counter % 2 == 0) result += 1;
            }

            return result;
        }
        // 26. https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        public int RemoveDuplicates(int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException("numbers");
            if (numbers.Length == 0) return 0;

            int count = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                    count++;
                else
                    numbers[i - count] = numbers[i];
            }
            return numbers.Length - count;
        }

        //https://leetcode.com/problems/happy-number/
        public bool HappyNumber(int number)
        {
            Dictionary<int, bool> storage = new Dictionary<int, bool>();
            while (number > 1)
            {
                var numToDiv = number;
                var newNum = 0;
                while (numToDiv > 0)
                {
                    var remainder = numToDiv % 10;
                    numToDiv /= 10;
                    newNum += remainder * remainder;
                }
                if (storage.ContainsKey(newNum))
                    return false;
                else
                    storage.Add(newNum, true);
                number = newNum;
            }
            return true;
        }

        //https://www.geeksforgeeks.org/two-pointers-technique/
        //not a question. Just some study
        //Array is sorted
        public bool TwoPointers(int[] array, int number)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 1) return false;
            if (array.Length == 2) return (array[0] + array[1] == number);

            var start = 0;
            var end = array.Length - 1;
            while (start < end)
            {
                var valStart = array[start];
                var valEnd = array[end];
                if (valStart + valEnd > number)
                    end--;
                else if (valStart + valEnd < number)
                    start++;
                else
                    return true;
            }
            return false;
        }

        //https://leetcode.com/problems/happy-number/
        //doesnt use O(n) space
        public bool HappyNumberWithFloydCycle(int number)
        {
            int slow = number;
            int fast = number;
            do
            {
                slow = digitSquareSum(slow);
                fast = digitSquareSum(fast);
                fast = digitSquareSum(fast);
                if (fast == 1) return true;
            } while (slow != fast);
            return false;
        }

        int digitSquareSum(int n)
        {
            var newNum = 0;
            while (n > 0)
            {
                var remainder = n % 10;
                n /= 10;
                newNum += remainder * remainder;
            }
            return newNum;
        }
    }
}
