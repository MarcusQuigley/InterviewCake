using DynamicProgramming.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DynamicProgramming.Tests.LeetCode
{
    public class LeetMediumDPTests
    {
        LeetMediumDP sut = null;
        public LeetMediumDPTests()
        {
            sut = new LeetMediumDP();
        }

        [Theory]
        [InlineData("abcde", "ace",3)]
        [InlineData("ace", "ace", 3)]
        [InlineData("abc", "def", 0)]
        public void Test_LongestCommonSubsequence(string text1, string text2, int expected)
        {
            var actual = sut.LongestCommonSubsequence(text1, text2);
            Assert.Equal(expected, actual);
        }
    }
}
