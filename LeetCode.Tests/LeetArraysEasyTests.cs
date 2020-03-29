using LeetCode.Arrays;
using System;
using Xunit;

namespace LeetCode.Tests
{
    public class LeetArraysEasyTests
    {
       
        [Theory]
        //[InlineData(new int[] { 1,2,2}, 2)]
        //[InlineData(new int[] { 1, 1, 2 }, 2)]
        [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        //[InlineData(new int[] { },0)]
        //[InlineData(new int[] { 1, 2 }, 2)]
        public void Test_RemoveDuplicates(int[] numbers, int expected)
        {
            var sut = new LeetEasyQuestions();
            var actual = sut.RemoveDuplicates2(numbers);
            Assert.Equal(expected, actual);
         } 
    }
}
