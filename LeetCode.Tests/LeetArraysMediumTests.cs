using LeetCode.Arrays;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode.Tests
{
    public class LeetArraysMediumTests
    {
        LeetMediumQuestions sut;
        public LeetArraysMediumTests()
        {
            sut = new LeetMediumQuestions();
        }
        [Theory]
        //[InlineData(new string[] { "cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc" }, 10)]
        //[InlineData(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" }, 3)]
        [InlineData(new string[] { "duh", "ill" },2)]
        public void Test_GroupAnagrams(string[] strs, int expected)
        {
            var actual = sut.GroupAnagrams(strs);
            Assert.Equal(expected, actual.Count);
        }
    }
}
