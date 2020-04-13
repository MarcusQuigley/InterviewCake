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
        [InlineData(new string[] { "cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc" }, 10)]
        [InlineData(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" }, 3)]
        [InlineData(new string[] { "duh", "ill" },2)]
        public void Test_GroupAnagrams(string[] strs, int expected)
        {
            var actual = sut.GroupAnagrams(strs);
            Assert.Equal(expected, actual.Count);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2)]
        [InlineData(new int[] { 1, 1, 3, 3, 5, 5, 7, 7 }, 0)]
        [InlineData(new int[] { 1, 3, 2, 3, 5, 0 }, 3)]
        [InlineData(new int[] { 1, 1, 2, 2 }, 2)]
        [InlineData(new int[] { 1, 1, 2,  }, 2)]
        public void Test_CountElements(int[] elements, int expected)
        {
            var actual = sut.CountElements(elements);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 0, 0 }, 0)]
        [InlineData(new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 0, 1, 0 }, 2)]
        [InlineData(new int[] { 0, 1, 1 }, 2)]
        [InlineData(new int[] { 0, 1, 0, 1, 1, 1, 0, 0, 0 }, 8)]
        [InlineData(new int[] { 0, 1, 1, 1, 1, 1, 0, 0, 0 }, 6)]
        public void Test_FindMaxLength(int[] nums, int expected)
        {
            var actual = sut.FindMaxLength(nums);
            Assert.Equal(expected, actual);
        }

    }
}
