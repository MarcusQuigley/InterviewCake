using System;
using Xunit;

namespace BitManipulation.Tests
{
    public class LeetCodeBitsEasyTest
    {
        LeetCodeBitsEasy sut;
        public LeetCodeBitsEasyTest()
        {
            sut = new LeetCodeBitsEasy();
        }
        [Theory]
        [InlineData(new int[] { 1,3,3 }, 1)]
        [InlineData(new int[] { 4,1,2,1,2 }, 4)]
        public void Test_SingleNumber(int[] numbers, int expected)
        {
            var actual = sut.SingleNumber(numbers);
            Assert.Equal(expected, actual);

        }
    }
}
