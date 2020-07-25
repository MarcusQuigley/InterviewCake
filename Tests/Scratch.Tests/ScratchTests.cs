using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scratch.Tests
{
    public class ScratchTests
    {
        readonly Scratch sut = null;
        public ScratchTests()
        {
            sut = new Scratch();
        }

        [Theory]
        [InlineData("pw", false)]
        [InlineData("pww", true)]
        [InlineData("pws", false)]
        public void Test_HasDuplicateUsingBits(string s, bool expected)
        {
            var actual = sut.HasDuplicateUsingBits(s);
            Assert.Equal(expected, actual);
        }
    }
}
