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

        //53. https://leetcode.com/problems/maximum-subarray/
        public int MaxSubArrayBad(int[] nums)
        {
            if (nums == null) throw new ArgumentNullException(nameof(nums));
            if (nums.Length == 0) throw new Exception("Need an entry");
            if (nums.Length == 1) return nums[0];

            var maxsum = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var currentsum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    currentsum += nums[j];
                    //var currentsum = 0;
                    //for(var k = i; k <= j; k++)
                    //{
                    //    currentsum += nums[k];
                    //}
                    maxsum = Math.Max(maxsum, currentsum);
                }
            }
            return maxsum;
        }

        //53. https://leetcode.com/problems/maximum-subarray/
        public int MaxSubArrayDP(int[] nums)
        {
            if (nums == null) throw new ArgumentNullException(nameof(nums));
            if (nums.Length == 0) throw new Exception("Need an entry");
            if (nums.Length == 1) return nums[0];

            var n = nums.Length;

            int[] storage = new int[n];
            var maxvalue = nums[0];
            var result = maxvalue;
            storage[0] = maxvalue;

            for (int i = 1; i < n; i++)
            {
                var current = nums[i];
                maxvalue = Math.Max(current, maxvalue + current);
                result = Math.Max(result, maxvalue);
                storage[i] = maxvalue;
            }
            return result;
        }

        //283. https://leetcode.com/problems/move-zeroes/
        public void MoveZeros(int[] nums)
        {
            if (nums == null) throw new ArgumentNullException(nameof(nums));
            if (nums.Length < 2) return;

            var n = nums.Length;
            var zeroCounter = 0;

            for (var index = 0; index < n; index++)
            {
                var item = nums[index];
                if (item == 0)
                    zeroCounter += 1;
                else
                {
                    nums[index - zeroCounter] = item;
                }
            }

            for (int i = (n - zeroCounter); i < n; i++)
            {
                nums[i] = 0;
            }
        }

        //283.https://leetcode.com/problems/move-zeroes/
        public void MoveZerosWithPointers(int[] nums)
        {
            if (nums == null) throw new ArgumentNullException(nameof(nums));
            if (nums.Length < 2) return;
            var zeroPtr = 0;
            var nonZeroPtr = 0;
            var n = nums.Length;

            while (nonZeroPtr < n && zeroPtr < n)
            {
                while (nums[zeroPtr] != 0)
                {
                    zeroPtr += 1;
                    if (zeroPtr == n)
                        return;
                }
                while (nums[nonZeroPtr] == 0)
                {
                    nonZeroPtr += 1;
                    if (nonZeroPtr == n)
                        return;
                }

                var temp = nums[zeroPtr];
                nums[zeroPtr] = nums[nonZeroPtr];
                nums[nonZeroPtr] = temp;

            }
        }

        //283.https://leetcode.com/problems/move-zeroes/
        public void MoveZerosShort(int[] nums)
        {
            var zeroIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    var temp = nums[i];
                    nums[i] = nums[zeroIndex];
                    nums[zeroIndex] = temp;
                    zeroIndex++;
                }

            }
        }

        //Leet 121 https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public int BuyAndSellStock(int[] prices)
        {
            if (prices == null) throw new ArgumentNullException(nameof(prices));
            if (prices.Length == 1) return 0;

            var minimum = int.MaxValue;
            var maxprofit = 0;
            var storage = new int[prices.Length];

            for (int i = 0; i < prices.Length; i++)
            {
                var price = prices[i];
                maxprofit = Math.Max(maxprofit, price - minimum);
                minimum = Math.Min(minimum, price);
                storage[i] = maxprofit;
            }
            return maxprofit;
        }

        //Leet 122 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
        public int BuyAndSellStockTwo(int[] prices)
        {
            if (prices == null) throw new ArgumentNullException(nameof(prices));
            if (prices.Length < 2) return 0;

            var profit = 0;
            var firstPrice = prices[0];
            var minValue = firstPrice;
            var maxValue = firstPrice;
            var previousPrice = firstPrice;

            for (int i = 1; i < prices.Length; i++)
            {
                var price = prices[i];
                if (price < previousPrice)
                {
                    profit += (maxValue - minValue);
                    maxValue = price;
                    minValue = price;
                }
                else if (price > previousPrice)
                {
                    maxValue = price;
                }
                previousPrice = price;
            }
            profit += (maxValue - minValue);
            return profit;
        }

        //Leet 242 https://leetcode.com/problems/valid-anagram/
        public bool IsAnagram(string s, string t)
        {
            if (s == null || t == null) throw new ArgumentNullException("One or both params was null");
            if (s.Length != t.Length)
                return false;
 
            int[] hash = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                hash[s[i] - 'a'] += 1;
                hash[t[i] - 'a'] -= 1;
            }
            for (int j = 0; j < hash.Length; j++)
            {
                if (hash[j] != 0)
                    return false;
            }
            return true;
        }

    }
}
