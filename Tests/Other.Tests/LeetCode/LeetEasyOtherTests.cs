using Other.LeetCode;
using System;
using Xunit;

namespace Other.Tests
{
    public class LeetEasyOtherTests
    {
        readonly LeetEasyOther sut = null;
        public LeetEasyOtherTests()
        {
            sut = new LeetEasyOther();
        }

        [Theory]
        [InlineData("88",true)]
        [InlineData("1", true)]
        [InlineData("69", true)]
        [InlineData("962", false)]
        [InlineData("5", false)]
        [InlineData("888", true)]
        [InlineData("2", false)]
        public void Test_IsStrobogrammatic(string num, bool expected)
        {
            var actual = sut.IsStrobogrammatic(num);
            Assert.Equal(expected, actual);
        }
    }
}
