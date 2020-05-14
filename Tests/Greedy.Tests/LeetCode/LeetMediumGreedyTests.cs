using Greedy.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Greedy.Tests.LeetCode
{
    public class LeetMediumGreedyTests
    {
        LeetMediumGreedy sut = null;
        public LeetMediumGreedyTests()
        {
            sut = new LeetMediumGreedy();
        }

        [Theory]
         [InlineData("1432219",3,"1219")]
        [InlineData("1234567", 3, "1234")]
        [InlineData("10200", 1, "200")]
        [InlineData("10", 1, "0")]
        [InlineData("10", 2, "0")]
        [InlineData("11", 2, "0")]
        public void Test_RemoveKdigits(string num, int k, string expected)
        {
            var actual = sut.RemoveKdigits(num, k);
             Assert.Equal(expected, actual);
        }
    }
}
