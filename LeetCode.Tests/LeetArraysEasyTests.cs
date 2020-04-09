using LeetCode.Arrays;
using Xunit;

namespace LeetCode.Tests
{
    public class LeetArraysEasyTests
    {
        LeetEasyQuestions sut = null;
        public LeetArraysEasyTests()
        {
            sut = new LeetEasyQuestions();
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
            var sut = new LeetEasyQuestions();
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
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 0 }, new int[] { 1, 0, 0 })]
        public void Test_MoveZerosWithPointers(int[] array, int[] expected)
        {
            sut.MoveZerosWithPointers(array);
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
        [InlineData(new int[] { 2, 1, 10, 0, 12 }, new int[] { 2, 1, 10, 12, 0 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 0 }, new int[] { 1, 0, 0 })]
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 })]
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
            var actual = sut.IsAnagram(s,t);
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
    }
}
