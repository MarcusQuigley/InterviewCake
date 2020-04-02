using LeetCode.Arrays;
using System;
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
        public void Test_HappyNumber(int  number, bool expected)
        {
            var actual = sut.HappyNumber(number);
            Assert.Equal(expected, actual);
        }

        
    }
}
