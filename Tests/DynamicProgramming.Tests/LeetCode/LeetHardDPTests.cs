using DynamicProgramming.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DynamicProgramming.Tests.LeetCode
{
    public class LeetHardDPTests
    {
        LeetHardDP sut = null;
        public LeetHardDPTests()
        {
            sut = new LeetHardDP();
        }

        [Theory]
        [InlineData("horse", "ros",3)]
        [InlineData("ace", "ace", 0)]
        [InlineData("intention", "execution", 5)]

        public void Test_MinDistance(string text1, string text2, int expected)
        {
            var actual = sut.MinDistance(text1, text2);
            Assert.Equal(expected, actual);
        }

         
        
    }
}
