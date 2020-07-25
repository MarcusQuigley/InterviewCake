using AmazonQuestions.Study;
using System;
using Xunit;

namespace AmazonQuestions.Tests
{
    public class AmazonArrayTests
    {
        readonly AmazonQuestionsArrays sut;
        public AmazonArrayTests()
        {
            sut = new AmazonQuestionsArrays();
        }
        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[] { 4, 0, 2 }, 4, new int[] { 0, 1 })]
        [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        [InlineData(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]
        [InlineData(new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }
        , 542, new int[] { 28, 45 })]
        public void Test_TwoSum(int[] numbers, int target, int[] expected)
        {
            var actual = sut.TwoSum(numbers, target);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[] { 4, 0, 2 }, 4, new int[] { 0, 1 })]
        [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        [InlineData(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]
        [InlineData(new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }
    , 542, new int[] { 28, 45 })]
        public void Test_TwoSumBrute(int[] numbers, int target, int[] expected)
        {
            var actual = sut.TwoSumBrute(numbers, target);
            Assert.Equal(expected, actual);
        }
        

        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("", 0)]
        [InlineData("a", 1)]
        [InlineData("dvdf", 3)]
        public void Test_LengthOfLongestSubstring(string s, int expected)
        {
            var actual = sut.LengthOfLongestSubstring(s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("", 0)]
        [InlineData("a", 1)]
        [InlineData("dvdf", 3)]
        [InlineData("ingUsik",6)]
        public void Test_LengthOfLongestSubstringUsingArray(string s, int expected)
        {
            var actual = sut.LengthOfLongestSubstringUsingArray(s);
            Assert.Equal(expected, actual);
        }

        

        [Theory]
        [InlineData("42", 42)]
        [InlineData("-42", -42)]
        [InlineData("- 42", 0)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("+ 23", 0)]
        [InlineData(".1", 0)]
        [InlineData("-91283472332", -2147483648)]
        [InlineData(" ", 0)]
        [InlineData("2147483648", 2147483647)]
        [InlineData("20000000000000000000", 2147483647)]
        [InlineData("-2147483647", -2147483647)]
        public void Test_MyAtoi(string s, int expected)
        {
            var actual = sut.MyAtoi(s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 1, 5, 6, 4 }, 2,5)]
        [InlineData(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4,4)]
        [InlineData(new int[] { 1}, 1,1)]
        [InlineData(new int[] { 2,1 }, 2, 1)]
        public void Test_FindKthLargest(int[] nums, int k, int expected)
        {
            var actual = sut.FindKthLargest(nums,k);
            Assert.Equal(expected, actual);
        }
    }
}
