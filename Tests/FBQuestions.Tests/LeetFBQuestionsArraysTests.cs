
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FBQuestions.Tests
{
    public class LeetFBQuestionsArraysTests
    {
        readonly LeetFBQuestionsArrays sut = null;
        public LeetFBQuestionsArraysTests()
        {
            sut = new LeetFBQuestionsArrays();
        }

        [Theory]
        [InlineData(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz",true)]
        [InlineData(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
        [InlineData(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
        public void Test_IsAlienSorted(string[] words, string order, bool expected)
        {
            var actual = sut.IsAlienSorted(words, order);
            Assert.Equal(expected, actual);
        }
    }
}
