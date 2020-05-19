using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Scratch.Tests.HackerRank
{
  public  class ScratchOneTests
    {
        readonly ScratchOne sut;

        public ScratchOneTests()
        {
            sut = new ScratchOne();
        }

        [Theory]
        [InlineData(13, 45, 3, 33)]
        [InlineData(20, 23, 6, 2)]
        public void Test_BeautifulDays(int rangeStart, int rangeEnd, int divisor, int expected)
        {
            var actual = sut.BeautifulDays(rangeStart, rangeEnd, divisor);
            Assert.Equal(expected, actual);
        }

    }
}
