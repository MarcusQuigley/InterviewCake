using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays.LeetCode
{
    public class LeetEasyArrays
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
            var n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != 0)
                    nums[zeroIndex++] = nums[i];
            }
            for (int i = zeroIndex; i < n; i++)
            {
                nums[i] = 0;
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
        //167 https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        //array is   sorted.
        public int[] TwoSum2(int[] numbers, int target)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            int[] result = new int[2];
            int begin = 0;
            int end = numbers.Length - 1;

            while (begin <= end)
            {
                var sum = numbers[begin] + numbers[end];
                if (sum == target)
                {
                    result[0] = begin + 1;
                    result[1] = end + 1;
                    break;
                }
                if (sum > target)
                    end--;
                else if (sum < target)
                    begin++;

            }
            return result;
        }

        //844 https://leetcode.com/problems/backspace-string-compare/
        // //This uses O(n) space
        public bool BackspaceCompareStack(string S, string T)
        {
            if (S == null || T == null) throw new ArgumentNullException("something is null");

            var sCharArray = S.ToCharArray();
            var tCharArray = T.ToCharArray();

            var sStack = CleanArrayWithStack(sCharArray);
            var tStack = CleanArrayWithStack(tCharArray);
            if (sStack.Count != tStack.Count)
                return false;

            for (int i = 0; i < sStack.Count; i++)
            {
                if (sStack.Peek() != tStack.Peek())
                    return false;
            }
            return true;
        }

        //844 https://leetcode.com/problems/backspace-string-compare/
        //This uses O(1) space
        public bool BackspaceCompare(string S, string T)
        {
            if (S == null || T == null) throw new ArgumentNullException("something is null");

            var sCharArray = S.ToCharArray();
            var tCharArray = T.ToCharArray();

            var sIndex = CleanArray(sCharArray);
            var tIndex = CleanArray(tCharArray);
            var sLength = sCharArray.Length - sIndex;
            var tLength = tCharArray.Length - tIndex;
            if (sLength != tLength)
                return false;

            for (int i = 0; i < sLength; i++)
            {
                if (sCharArray[sIndex++] != tCharArray[tIndex++])
                    return false;
            }
            return true;
        }

        //283. https://leetcode.com/problems/move-zeroes/
        public void MoveZeroes(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));

            var n = nums.Length;
            var zeroPtr = 0;
            var nonzeroPtr = 0;

            while (nonzeroPtr < n)
            {
                while (nums[zeroPtr] != 0)// && zeroPtr < n)
                    zeroPtr += 1;
                while (nums[nonzeroPtr] == 0)// && nonzeroPtr < n)
                    nonzeroPtr += 1;
                var temp = nums[zeroPtr];
                nums[zeroPtr] = nums[nonzeroPtr];
                nums[nonzeroPtr] = temp;
            }
        }

        //387. https://leetcode.com/problems/first-unique-character-in-a-string/
        public int FirstUniqueChar(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (s.Length == 0)
                return -1;
            int[] arr = new int[26];
            var chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                arr[chars[i] - 'a'] += 1;
            }
            for (int j = 0; j < chars.Length; j++)
            {
                if (arr[chars[j] - 'a'] == 1)
                    return j;
            }
            return -1;
        }

        //771 https://leetcode.com/problems/jewels-and-stones/
        public int NumJewelsInStones(string J, string S)
        {
            if (string.IsNullOrEmpty(J) || string.IsNullOrEmpty(S))
                return 0;
            var result = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (J.Contains(S[i]))
                {
                    result++;
                }

            }

            return result;
            //int[] arrmap = new int[128];

            //foreach (char c in S)
            //    arrmap[c - 'A'] += 1;

            //foreach (char c in J)
            //    result += arrmap[c - 'A'];
            //return result;
        }

        //338 https://leetcode.com/problems/ransom-note/
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote == null || magazine == null)
                throw new ArgumentNullException("somethings null");

            int[] map = new int[26];
            foreach (char c in magazine)
            {
                map[c - 'a'] += 1;
            }
            foreach (char b in ransomNote)
            {
                var val = b - 'a';
                map[val] -= 1;
                if (map[val] < 0)
                    return false;
            }
            return true;
        }

        //169 https://leetcode.com/problems/majority-element/
        public int MajorityElement(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));

            //Array.Sort(nums);
            //return nums[nums.Length / 2];
            var half = (nums.Length / 2) + 1;
            var result = -1;
            var map = new Dictionary<int, int>(half + 1);
            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];
                if (map.ContainsKey(value))
                    map[value] += 1;
                else
                    map.Add(value, 1);
                if (map[value] == half)
                {
                    result = value;
                    break;
                }

            }
            return result;
        }

        //665 https://leetcode.com/problems/non-decreasing-array/
        public bool CheckPossibility(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            bool changed = false;
            var n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (changed) return false;
                    changed = true;
                    if (i == 0)
                        nums[i] = nums[i + 1];
                    else
                    {
                        if (nums[i - 1] > nums[i + 1])
                            nums[i + 1] = nums[i];
                        else
                            nums[i] = nums[i + 1];

                    }
                }
            }
            return true;
        }
        //https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3323/
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates == null)
                throw new ArgumentNullException(nameof(coordinates));
            var n = coordinates.Length;
            if (n == 1) return true;
            double slope = 0.0;
            for (int i = 0; i < n - 1; i++)
            {
                var currentslope = CalculateSlope(coordinates[i], coordinates[i + 1]);
                if (i != 0)
                {
                    if (currentslope != slope)
                        return false;
                }
                else
                {
                    slope = currentslope;
                }
            }
            return true;
        }

        //485 https://leetcode.com/problems/max-consecutive-ones/
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            var onesCount = 0;
            var maxOnesCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    onesCount += 1;
                else
                {
                    maxOnesCount = Math.Max(maxOnesCount, onesCount);
                    onesCount = 0;
                }
            }
            maxOnesCount = Math.Max(maxOnesCount, onesCount);
            return maxOnesCount;
        }

        //977 https://leetcode.com/problems/squares-of-a-sorted-array/
        //This should be a Medium
        public int[] SortedSquares(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            int leftptr = -1;
            var n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] < 0)
                    leftptr += 1;
                else
                    break;
            }

            while (leftptr > -1)
            {
                var tempLeft = leftptr;
                nums[tempLeft] = Math.Abs(nums[tempLeft]);

                while (tempLeft + 1 < n && nums[tempLeft] > nums[tempLeft + 1])
                {
                    var temp = nums[tempLeft];
                    nums[tempLeft] = nums[tempLeft + 1];
                    nums[tempLeft + 1] = temp;
                    tempLeft += 1;
                }
                leftptr -= 1;
            }
            for (int i = 0; i < n; i++)
            {
                nums[i] = nums[i] * nums[i];
            }
            return nums;
        }
        //1089 https://leetcode.com/problems/duplicate-zeros/
        public void DuplicateZeros(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            var numZeros = 0;
            var n = arr.Length - 1;
            for (int i = 0; i <= n - numZeros; i++)
            {
                if (arr[i] == 0)
                {
                    // Edge case: This zero can't be duplicated. We have no more space,
                    // as left is pointing to the last element which could be included  
                    if (i == (n - numZeros))
                    {
                        // For this zero we just copy it without duplication.
                        arr[n] = 0;
                        n -= 1;
                        break;
                    }
                    numZeros += 1;
                }
            }
            if (numZeros == 0) return;
            var right = n - numZeros;
            for (int i = right; i >= 0; i--)
            {
                if (arr[i] == 0)
                {
                    arr[i + numZeros] = 0;
                    numZeros -= 1;
                    arr[i + numZeros] = 0;
                }
                else
                    arr[i + numZeros] = arr[i];
                if (numZeros == 0)
                    break;
            }
        }

        //88 https://leetcode.com/problems/merge-sorted-array/
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1 == null || nums2 == null)
                throw new ArgumentNullException("one of them");

            var firstpointer = m - 1;
            var secondpointer = n - 1;
            int val = 0;
            int index = nums1.Length - 1;
            while (secondpointer >= 0 && firstpointer >= 0)
            {
                val = (nums1[firstpointer] > nums2[secondpointer]) ? nums1[firstpointer--] : nums2[secondpointer--];
                nums1[index--] = val;
            }
            while (secondpointer >= 0)
                nums1[index--] = nums2[secondpointer--];
        }

        //643 https://leetcode.com/problems/maximum-average-subarray-i/
        public double FindMaxAverage(int[] nums, int k)
        {
            if (nums == null) throw new ArgumentNullException(nameof(nums));
            if (nums.Length == 0) return 0d;

            int n = nums.Length;
            double sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            double max = sum;

            for (int j = k; j < n; j++)
            {
                sum -= nums[j - k];
                sum += nums[j];
                max = Math.Max(max, sum);
            }
            return (max / k / 1.0);
        }


        //1 https://leetcode.com/problems/two-sum/
        //array is not sorted.
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null) throw new ArgumentNullException(nameof(nums));
            int[] result = new int[2];
            Dictionary<int, int> hash = new Dictionary<int, int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                var val = nums[i];
                var newTarget = target - val;
                if (hash.ContainsKey(newTarget))
                {
                    result[0] = hash[newTarget];
                    result[1] = i;
                    break;
                }
                if (!hash.ContainsKey(val))
                    hash.Add(nums[i], i);
            }
            return result;
        }

        //1099. https://leetcode.com/problems/two-sum-less-than-k/
        public int TwoSumLessThanK(int[] A, int K)
        {
            if (A == null) throw new ArgumentNullException(nameof(A));

            Array.Sort(A);
            var max = -1;
            var start = 0;
            var end = A.Length - 1;
            while (start < end)
            {
                var sum = A[start] + A[end];
                if (sum > K)
                    end--;
                else
                {
                    if (sum < K)
                        max = Math.Max(max, sum);
                    start++;
                }
            }

            return max;

        }

        //118 https://leetcode.com/problems/pascals-triangle/
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> matrix = new List<IList<int>>(numRows);

            for (int i = 0; i <= numRows; i++)
            {
                var cells = i + 1;
                int[] list = new int[cells];

                for (int j = 0; j < cells; j++)
                {
                    list[j] = (j > 0 && j < cells - 1) ? matrix[i - 1][j - 1] + matrix[i - 1][j] : 1;
                }
                matrix.Add(list);
            }
            return matrix;
        }
        //https://leetcode.com/problems/pascals-triangle-ii/
        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0) return new int[] { 1 }.ToList();
            int[][] matrix = new int[rowIndex + 1][];
            matrix[0] = new int[] { 0 };
            PascalsTheorem2(rowIndex, 1, matrix);
            return matrix[rowIndex].ToList(); ;
        }
        void PascalsTheorem2(int rowIndex, int currentIndex, int[][] matrix)
        {
            matrix[currentIndex] = new int[currentIndex + 1];
            matrix[currentIndex][0] = 1;
            matrix[currentIndex][currentIndex] = 1;
            for (int i = 1; i < (currentIndex); i++)
            {
                matrix[currentIndex][i] = matrix[currentIndex - 1][i - 1] + matrix[currentIndex - 1][i];
            }
            if (currentIndex < rowIndex)
                PascalsTheorem2(rowIndex, currentIndex + 1, matrix);

        }

        #region Helpers
        double CalculateSlope(int[] p1, int[] p2)
        {
            double x = p1[0] - p2[0];
            double y = p1[1] - p2[1];
            return y / x;
        }

        private int CleanArray(char[] charArray)
        {
            var backspaceCounter = 0;
            var i = charArray.Length - 1;
            var index = i;
            while (i >= 0)
            {
                var item = charArray[i--];
                if (item == '#')
                    backspaceCounter += 1;
                else if (backspaceCounter > 0)
                    backspaceCounter -= 1;
                else
                    charArray[index--] = item;
            }
            return index + 1;

            //if index has been decremented i need to increment it by 1.
            //if it hasnt been decremented then it there should be nothing to show
        }

        private Stack<char> CleanArrayWithStack(char[] charArray)
        {
            var ctr = charArray.Length - 1;
            var stack = new Stack<char>();
            var backspaceCounter = 0;
            while (ctr >= 0)
            {
                var item = charArray[ctr];
                if (item == '#')
                    backspaceCounter += 1;
                else if (backspaceCounter > 0)
                    backspaceCounter -= 1;
                else
                    stack.Push(item);
                ctr -= 1;
            }
            return stack;
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

        public void ReverseString(char[] s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (s.Length == 1)
                return;
            var n = s.Length;
            var begin = 0;
            var end = n - 1;
            while (begin < end)
            {
                if (s[begin] != s[end])
                {
                    var temp = s[begin];
                    s[begin] = s[end];
                    s[end] = temp;
                }
                begin++;
                end--;
            }
        }
        #endregion

        Dictionary<int, int> map = new Dictionary<int, int>();
        //https://leetcode.com/problems/fibonacci-number/
        public int Fibonacci(int N)
        {
            if (N == 0 || N == 1)
                return N;
            if (!map.ContainsKey(N))
                map.Add(N, Fibonacci(N - 1) + Fibonacci(N - 2));
            return map[N];
        }

        //https://leetcode.com/problems/climbing-stairs/
        public int ClimbStairs(int n)
        {
            if (n == 0) return n;
            return Climb(n, 0);
        }
        Dictionary<int, int> mapStairs = new Dictionary<int, int>();
        int Climb(int n, int total)
        {
            if (total == n)
                return 1;
            else if (total > n)
                return 0;
            if (map.ContainsKey(total))
                return map[total];

            map[total] = (Climb(n, total + 1) + Climb(n, total + 2));
            return map[total];
        }
        //https://leetcode.com/problems/add-strings/submissions/
        public string AddStrings(string num1, string num2)
        {
            if (num1 == null || num2 == null)
            {
                throw new ArgumentNullException("Either or both are null");
            }
            var l1 = num1.Length - 1;
            var l2 = num2.Length - 1;
            var carry = 0;
            var sb = new StringBuilder();
            while (l1 >= 0 || l2 >= 0)
            {

                var n1 = (l1 >= 0) ? num1[l1--] - '0' : 0;
                var n2 = (l2 >= 0) ? num2[l2--] - '0' : 0;
                var sum = (n1 + n2 + carry);
                carry = sum / 10;
                sb.Append(sum % 10);
            }
            if (carry > 0)
            {
                sb.Append(carry);
            }
            var resultLength = sb.Length - 1;
            var index = 0;
            while (index < resultLength)
            {
                var temp = sb[resultLength];
                sb[resultLength] = sb[index];
                sb[index] = temp;
                index++;
                resultLength--;
            }
            return sb.ToString();
        }

        //https://leetcode.com/problems/intersection-of-two-arrays/
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
            {
                throw new ArgumentNullException("Either or both are null");
            }
            List<int> result = new List<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var item in nums1)
            {
                if (!map.ContainsKey(item))
                    map.Add(item, 1);
            }
            foreach (var item in nums2)
            {
                if (map.ContainsKey(item))
                {
                    map[item] += 1;
                    if (map[item] == 2)
                        result.Add(item);
                }
            }
            return result.ToArray();
        }

        //duplicates, negative values, single value lists, 0's, and empty list arguments.
        public int[] IntersectionSorted(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                throw new ArgumentNullException("Either or both are null");
            Array.Sort(nums1);
            Array.Sort(nums2);
            HashSet<int> results = new HashSet<int>();
            var nums1Length = nums1.Length - 1;
            var nums2Length = nums2.Length - 1;
            var index1 = 0;
            var index2 = 0;
            while (index1 <= nums1Length && index2 <= nums2Length)
            {
 
                while (index1 < nums1Length && (  nums1[index1] < nums2[index2] || nums1[index1] == nums1[index1 + 1]))
                    index1 += 1;
                while (index2 < nums2Length && (nums2[index2] < nums1[index1] || nums2[index2] == nums2[index2 + 1]))
                    index2 += 1;
                if (nums1[index1] == nums2[index2])
                {
                    results.Add(nums1[index1]);
                    index1 += 1;
                    index2 += 1;
                }
                else if (nums1[index1] < nums2[index2])
                    index1 += 1;
                else
                    index2 += 1;
            }
            return results.ToArray();
        }

        //https://leetcode.com/problems/intersection-of-two-arrays-ii/
        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                throw new ArgumentNullException("Either or both are null");
            Array.Sort(nums1);
            Array.Sort(nums2);
            List<int> results = new List<int>();
            var nums1Length = nums1.Length - 1;
            var nums2Length = nums2.Length - 1;
            var index1 = 0;
            var index2 = 0;
            while(index1 <=nums1Length && index2 <= nums2Length)
            {
                if (nums1[index1] == nums2[index2])
                {
                    results.Add(nums1[index1]);
                    index1++;
                    index2++;
                }
                else
                {
                    while (index1 <= nums1Length && nums1[index1] < nums2[index2])
                         index1++;

                    if (index1 > nums1Length)
                        break;
                    while (index2 <= nums2Length && nums2[index2] < nums1[index1])
                        index2++;
                }
            }


            return results.ToArray();
        }
        //https://leetcode.com/problems/merge-sorted-array/
        public int[] MergeRepeat(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1 == null || nums2 == null)
                throw new ArgumentNullException("one or both arrays null");
            int mIndex = m - 1;
            int nIndex = n - 1;
            int currentIndex = nums1.Length - 1;
            while (mIndex >= 0 && nIndex >= 0)
            {
                nums1[currentIndex] = (nums2[nIndex] >= nums1[mIndex]) ? nums1[currentIndex] = nums2[nIndex--] : nums1[currentIndex] = nums1[mIndex--];
                currentIndex--;
            }
            while (nIndex >= 0)
            {
                nums1[currentIndex--] = nums2[nIndex--];
            }

            return nums1;
        }
        //https://leetcode.com/problems/monotonic-array/
        public bool IsMonotonic(int[] A)
        {
            if (A == null)
                throw new ArgumentNullException(nameof(A));
            bool isIncreasing = false;
            bool isDecreasing = false;

            for (int i = 0; i < A.Length-1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    if (isIncreasing)
                        return false;
                    if (!isDecreasing)
                        isDecreasing = true;
                }
                else if (A[i] < A[i + 1])
                {
                    if (isDecreasing)
                        return false;
                    if (!isIncreasing)
                        isIncreasing = true;
                }
            }
 
            return true;
        }
    }
}
