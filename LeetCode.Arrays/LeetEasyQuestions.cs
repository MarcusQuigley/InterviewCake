using System;

namespace LeetCode.Arrays
{
    public class LeetEasyQuestions
    {
        // 26. https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        public int RemoveDuplicates(int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException("numbers");
            if (numbers.Length == 0) return 0;

            var currentUniqueValue = numbers[0];
            var currentUniqueIndex = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > currentUniqueValue)
                {
                    if (i != currentUniqueIndex + 1)
                    {
                        currentUniqueIndex += 1;
                        var temp = numbers[i];
                        numbers[i] = numbers[currentUniqueIndex];
                        numbers[currentUniqueIndex] = temp;
                        currentUniqueValue = numbers[currentUniqueIndex];
                    }
                }
            }
            return numbers.Length - currentUniqueIndex;
        }

        public int RemoveDuplicates2(int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException("numbers");
            if (numbers.Length < 2) return numbers.Length;

            int cur = 0;
            foreach (var item in numbers)
            {
                if (item > numbers[cur])
                    numbers[++cur] = item;

            }
            return cur + 1;
        }
    }
}
