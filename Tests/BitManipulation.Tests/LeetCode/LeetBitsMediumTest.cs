using System;
using Xunit;

namespace BitManipulation.Tests.LeetCode
{
    public class LeetBitsMediumTest
    {
        readonly LeetMediumBits sut;
        public LeetBitsMediumTest()
        {
            sut = new LeetMediumBits();
        }
        [Theory]
        [InlineData(5, 7, 4)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2147483647, 0)]
        [InlineData(20000, 2147483647, 0)]        

        public void Test_RangeBitwiseAnd(int rangeStart, int rangeEnd, int expected)
        {
            var actual = sut.RangeBitwiseAnd(rangeStart, rangeEnd);
            Assert.Equal(expected, actual);
        }
    }
}
