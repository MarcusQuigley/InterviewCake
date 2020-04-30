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

        //[Theory]
        //[InlineData("abcde", "ace", 3)]
        //[InlineData("ace", "ace", 3)]
        //[InlineData("abc", "def", 0)]
        [Fact]
        public void Test_MaximalSquare()//string text1, string text2, int expected)
        {
            var matrix = new char[4][];
            matrix[0] = new char[] { '1', '0', '1', '0', '0' };
            matrix[1] = new char[] { '1', '0', '1', '1', '1' };
            matrix[2] = new char[] { '1', '1', '1', '1', '1' };
            matrix[3] = new char[] { '1', '0', '0', '1', '0' };
            var actual = sut.MaximalSquare(matrix);
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Test_MaximalSquare2()//string text1, string text2, int expected)
        {
            var matrix = new char[3][];
            matrix[0] = new char[] { '0', '0', '1' };
            matrix[1] = new char[] { '0', '1', '1' };
            matrix[2] = new char[] { '1', '1', '1' };
             var actual = sut.MaximalSquare(matrix);
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Test_MaximalSquare3()//string text1, string text2, int expected)
        {
            var matrix = new char[1][];
            matrix[0] = new char[] {   '1' };
           
            var actual = sut.MaximalSquare(matrix);
            Assert.Equal(1, actual);
        }

    }
}
