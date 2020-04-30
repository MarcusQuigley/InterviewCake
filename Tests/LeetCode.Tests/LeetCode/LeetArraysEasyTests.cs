using Arrays.LeetCode;
using Xunit;

namespace Arrays.Tests.LeetCode
{
    public class LeetArraysEasyTests
    {
 
       readonly LeetEasyArrays sut = null;
        public LeetArraysEasyTests()
        {
            sut = new LeetEasyArrays();
        }

        [Theory]
        [InlineData(new int[] { 12, 345, 2, 6, 7896 }, 2)]
        [InlineData(new int[] { 555, 901, 482, 1771 }, 1)]
        public void Test_FindNumbers(int[] numbers, int expected)
        {
            Assert.Equal(expected, sut.FindNumbers(numbers));
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 2, 3 }, 4)]
        [InlineData(new int[] { 1, 1, 2 }, 2)]
        [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        [InlineData(new int[] { }, 0)]
        [InlineData(new int[] { 1, 2 }, 2)]
        public void Test_RemoveDuplicates(int[] numbers, int expected)
        {
            var sut = new LeetEasyArrays();
            var actual = sut.RemoveDuplicates(numbers);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(19, true)]
        [InlineData(5, false)]
        public void Test_HappyNumber(int number, bool expected)
        {
            var actual = sut.HappyNumber(number);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(19, true)]
        [InlineData(5, false)]
        public void Test_HappyNumberWithFloydCycle(int number, bool expected)
        {
            var actual = sut.HappyNumberWithFloydCycle(number);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 10, 20, 35, 50, 75, 80 }, 70, true)]
        [InlineData(new int[] { 1, 2, 7, 9 }, 7, false)]
        public void Test_TwoPointers(int[] array, int number, bool expected)
        {
            var actual = sut.TwoPointers(array, number);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [InlineData(new int[] { 1, 2, 7, 9 }, 19)]
        [InlineData(new int[] { 1, 2, -7, 9 }, 9)]
        public void Test_MaxSubArray(int[] array, int expected)
        {
            var actual = sut.MaxSubArrayBad(array);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [InlineData(new int[] { 1, 2, 7, 9 }, 19)]
        [InlineData(new int[] { 1, 2, -7, 9 }, 9)]
        [InlineData(new int[] { -2, 1 }, 1)]
        public void Test_MaxSubArrayDP(int[] array, int expected)
        {
            var actual = sut.MaxSubArrayDP(array);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
        [InlineData(new int[] { 2, 1, 10, 0, 12 }, new int[] { 2, 1, 10, 12, 0 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 0 }, new int[] { 1, 0, 0 })]
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 })]
        public void Test_MoveZeros(int[] array, int[] expected)
        {
            sut.MoveZeros(array);
            Assert.Equal(expected, array);
        }

        

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
        [InlineData(new int[] { 2, 1, 10, 0, 12 }, new int[] { 2, 1, 10, 12, 0 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 0 }, new int[] { 1, 0, 0 })]
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 1, 0, 1 }, new int[] { 1, 1, 0 })]
        public void Test_MoveZerosShort(int[] array, int[] expected)
        {
            sut.MoveZerosShort(array);
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void Test_BuyAndSellStock(int[] prices, int expected)
        {
            var actual = sut.BuyAndSellStock(prices);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4)]
        public void Test_BuyAndSellStockTwo(int[] prices, int expected)
        {
            var actual = sut.BuyAndSellStockTwo(prices);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        [InlineData("", "", true)]
        [InlineData("rat", "tar", true)]
        [InlineData("ac", "bb", false)]
        [InlineData("vbnxkji", "wqdtegp", false)]
        public void Test_IsAnagram(string s, string t, bool expected)
        {
            var actual = sut.IsAnagram(s, t);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
        [InlineData(new int[] { 12, 13, 23, 28, 43, 44, 59, 60, 61, 68, 70, 86, 88, 92, 124, 125, 136, 168, 173, 173, 180, 199, 212, 221, 227, 230, 277, 282, 306, 314, 316, 321, 325, 328, 336, 337, 363, 365, 368, 370, 370, 371, 375, 384, 387, 394, 400, 404, 414, 422, 422, 427, 430, 435, 457, 493, 506, 527, 531, 538, 541, 546, 568, 583, 585, 587, 650, 652, 677, 691, 730, 737, 740, 751, 755, 764, 778, 783, 785, 789, 794, 803, 809, 815, 847, 858, 863, 863, 874, 887, 896, 916, 920, 926, 927, 930, 933, 957, 981, 997 },
                                542, new int[] { 24, 32 })]

        public void Test_TwoSum(int[] numbers, int target, int[] expected)
        {
            var actual = sut.TwoSum(numbers, target);
            Assert.Equal(expected, actual);
        }



        [Theory]
        [InlineData("aba#c#", "ab", true)]
        [InlineData("ab#c", "ad#c", true)]
        [InlineData("ab##", "c#d#", true)]
        [InlineData("a##c", "#a#c", true)]
        [InlineData("a##c", "c", true)]
        [InlineData("cca##", "c", true)]
        [InlineData("a#c", "a", false)]
        public void Test_BackspaceCompareStack(string s, string t, bool expected)
        {
            var actual = sut.BackspaceCompareStack(s, t);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("aba#c#", "ab", true)]
        [InlineData("ab#c", "ad#c", true)]
        [InlineData("ab##", "c#d#", true)]
        [InlineData("a##c", "#a#c", true)]
        [InlineData("a##c", "c", true)]
        [InlineData("cca##", "c", true)]
        [InlineData("a#c", "a", false)]
        public void Test_BackspaceCompare(string s, string t, bool expected)
        {
            var actual = sut.BackspaceCompare(s, t);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("leetcode",  0)]
        [InlineData("loveleetcode", 2)]
        [InlineData("ababab", -1)]
        [InlineData("abcdefghiklmn", 0)]
        [InlineData("a", 0)]
        [InlineData("", -1)]
        
        public void Test_FirstUniqueChar(string s ,int expected)
        {
            var actual = sut.FirstUniqueChar(s);
            Assert.Equal(expected, actual);
        }
        

    }
}
