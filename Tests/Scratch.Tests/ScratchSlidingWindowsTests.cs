using System;
using Xunit;

namespace Scratch.Tests
{
    
    public class ScratchSlidingWindowsTests
    {
      readonly  ScratchSlidingWindows sut;

        public ScratchSlidingWindowsTests()
        {
            sut = new ScratchSlidingWindows();
        }

        [Theory]
        [InlineData(new int[] {1,2,3,4 }, 2,7)]
        [InlineData(new int[] { 1, 2 }, 2, 3)]
        public void Test_MaxSum(int[] array, int k, int expected)
        {
            var actual = sut.MaxSum(array, k);
            Assert.Equal(expected, actual);
        }
    }
}
