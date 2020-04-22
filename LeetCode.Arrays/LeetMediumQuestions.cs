using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    public class LeetMediumQuestions
    {
        //https://leetcode.com/problems/group-anagrams/
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null) throw new ArgumentNullException(nameof(strs));
            Dictionary<string, List<string>> storage = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                var value = strs[i];

                var asciiTotal = IdentifyValue(value);
                if (storage.ContainsKey(asciiTotal))
                    storage[asciiTotal].Add(value);
                else
                    storage.Add(asciiTotal, new List<string>() { value });
            }
            IList<IList<string>> results = new List<IList<string>>();
            foreach (var kvp in storage)
            {
                results.Add(kvp.Value);
            }
            return results;
        }

        string IdentifyValue(string value)
        {
            var valueAsChars = value.ToCharArray();
            char[] keyArr = new char[26];
            for (int i = 0; i < valueAsChars.Length; i++)
                keyArr[valueAsChars[i] - 'a']++;
            String key = new String(keyArr);
            return key;
        }

        //https://leetcode.com/explore/other/card/30-day-leetcoding-challenge/528/week-1/3289/
        public int CountElements(int[] arr)
        {
            Dictionary<int, int> storage = new Dictionary<int, int>(arr.Length);
            var total = 0;
            var lowestKey = 0;
            var highestKey = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                var key = arr[i];
                if (storage.ContainsKey(key))
                    storage[key] += 1;
                else
                    storage.Add(key, 1);
                lowestKey = Math.Min(lowestKey, key);
                highestKey = Math.Max(highestKey, key);
            }

            for (int j = lowestKey; j < highestKey; j++)
            {
                if (storage.ContainsKey(j) && storage.ContainsKey(j + 1))
                {
                    //total += (storage[j] == storage[j + 1]) ? storage[j] : Math.Abs(storage[j] - storage[j + 1]);
                    total += storage[j];
                }
            }
            return total;
        }

        //525 https://leetcode.com/problems/contiguous-array/
        public int FindMaxLength(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            int[] values = new int[nums.Length];
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                values[i] = 0;
                var ones = 0;
                var zeroes = 0;
                for (int j = i; j >= 0; j--)
                {
                    _ = (nums[j] == 0) ? zeroes += 1 : ones += 1;
                    if ((i - j) % 2 != 0 && ones == zeroes)
                    {
                        values[j] = Math.Max(ones * 2, values[j]);
                        result = Math.Max(result, values[j]);
                    }
                }
            }
            return result;
        }
        //525 https://leetcode.com/problems/contiguous-array/
        public int FindMaxLengthBetter(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            int max = 0;
            int currsum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, -1);
            for (int i = 0; i < nums.Length; i++)
            {
                currsum += (nums[i] == 0) ? -1 : 1;

                if (map.ContainsKey(currsum))
                    max = Math.Max(max, i - map[currsum]);
                else
                    map.Add(currsum, i);
            }
            return max;
        }

        //238 https://leetcode.com/problems/product-of-array-except-self/
        //FAILED
        public int[] ProductExceptSelf(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            int n = nums.Length;
            int[] result = new int[n];
            int[] rights = new int[n];
            result[0] = 1;
            for (var i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            rights[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                rights[i] = rights[i + 1] * nums[i + 1];
                result[i] *= rights[i];
            }

            return result;
        }

        //678 https://leetcode.com/problems/valid-parenthesis-string/
        //FAILED
        public bool CheckValidString(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (s.Length == 0)
                return true;
            int low = 0;
            int hi = 0;
            foreach (char c in s.ToCharArray())
            {
                if (c == '(')
                {
                    low += 1;
                    hi += 1;
                }
                else if (c==')')
                {
                    low -= 1;
                    hi -= 1;
                }
                else //* means it could be either (, ) or ""
                {
                    low -= 1; 
                    hi += 1;
                }
                if (hi < 0)
                    return false;
                low = Math.Max(low, 0);  //low could be negative.
            }
            return low==0;
        }

        public bool CheckValidStringBad(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (s.Length == 0)
                return true;
            int left = 0;
            int wildcard = 0;
            var chars = s.ToCharArray();
            foreach (char c in chars)
            {
                if (c == '(')
                    left += 1;
                else if (c == '*')
                    wildcard += 1;
                else
                {
                    if (left == 0 && wildcard == 0)
                        return false;
                    else if (left == 0)
                        wildcard -= 1;
                    else
                        left -= 1;
                }
            }
            if (left > 0)
                if (left > wildcard)
                    return false;
            return true;
        }

        //200 https://leetcode.com/problems/number-of-islands/
        public int NumIslands(char[][] grid)
        {
            var n = grid.Length;
            var result = 0;

            for (int row = 0; row < n; row++)
            {
                var m = grid[row].Length;
                for (int col = 0; col < m; col++)
                {
                   if (grid[row][col] == '1')
                    {
                        NumIslandsBFS(grid, row, col);
                        result += 1;
                    }
                }
            }
            return result;
        }
           
        void NumIslandsBFS(char[][] grid, int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length || grid[r][c] == '0')
                return;
            grid[r][c] = '0';
            NumIslandsBFS(grid, r + 1, c);//down
            NumIslandsBFS(grid, r - 1, c);//up
            NumIslandsBFS(grid, r, c - 1);//left
            NumIslandsBFS(grid, r, c + 1);//right

        }
    }

}
