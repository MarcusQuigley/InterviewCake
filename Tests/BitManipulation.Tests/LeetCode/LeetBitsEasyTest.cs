using System;
using Xunit;

namespace BitManipulation.Tests.LeetCode
{
    public class LeetBitsEasyTest
    {
        readonly LeetEasyBits sut;
        public LeetBitsEasyTest()
        {
            sut = new LeetEasyBits();
        }
        [Theory]
        [InlineData(new int[] { 1,3,3 }, 1)]
        [InlineData(new int[] { 4,1,2,1,2 }, 4)]
        public void Test_SingleNumber(int[] numbers, int expected)
        {
            var actual = sut.SingleNumber(numbers);
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(new int[] { 2, 0 }, 1)]
        //[InlineData(new int[] { 1, 3, 0 }, 2)]
        //[InlineData(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
        public void Test_MissingNumber(int[] numbers, int expected)
        {
            var actual = sut.MissingNumber(numbers);
            Assert.Equal(expected, actual);

        }
    }
}
