using System;
using Xunit;

namespace LeetStudy.Tests
{
    public class LeetStudyArraysTests
    {
        LeetStudyArrays sut;
        public LeetStudyArraysTests()
        {
            sut = new LeetStudyArrays();
        }

        [Theory]
        [InlineData(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
        [InlineData(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
        [InlineData(new int[] { -14, -11, 0, 1, 3, 11 }, new int[] { 0, 1, 9, 121, 121, 196 })]
        public void Test_SortedSquares(int[] nums, int[] expected)
        {
            var actual = sut.SortedSquares(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 2, 3, 0, 4, 5, 0 }, new int[] { 1, 0, 0, 2, 3, 0, 0, 4 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 2, 0, 3, 0, 7, 9, 8 }, new int[] { 1, 2, 0, 0, 3, 0, 0, 7 })]
        [InlineData(new int[] { 0 }, new int[] { 0 })]
 
        [InlineData(new int[] { 1, 1, 0, 0 }, new int[] { 1, 1, 0, 0 })]
        [InlineData(new int[] { 8, 4, 5, 0, 0, 0, 0, 7 }, new int[] { 8, 4, 5, 0, 0, 0, 0, 0 })]
        //[InlineData(new int[] { 9, 9, 9, 4, 8, 0, 0, 3, 7, 2, 0, 0, 0, 0, 9, 1, 0, 0, 1, 1, 0, 5, 6, 3, 1, 6, 0, 0, 2, 3, 4, 7, 0, 3, 9, 3, 6, 5, 8, 9, 1, 1, 3, 2, 0, 0, 7, 3, 3, 0, 5, 7, 0, 8, 1, 9, 6, 3, 0, 8, 8, 8, 8, 0, 0, 5, 0, 0, 0, 3, 7, 7, 7, 7, 5, 1, 0, 0, 8, 0, 0 },
        //    new int[] { 9, 9, 9, 4, 8, 0, 0, 0, 0, 3, 7, 2, 0, 0, 0, 0, 0, 0, 0, 0, 9, 1, 0, 0, 0, 0, 1, 1, 0, 0, 5, 6, 3, 1, 6, 0, 0, 0, 0, 2, 3, 4, 7, 0, 0, 3, 9, 3, 6, 5, 8, 9, 1, 1, 3, 2, 0, 0, 0, 0, 7, 3, 3, 0, 0, 5, 7, 0, 0, 8, 1, 9, 6, 3, 0, 0, 8, 8, 8, 8, 0 })]

        public void Test_DuplicateZeros(int[] nums, int[] expected)
        {
            sut.DuplicateZeros(nums);
            Assert.Equal(expected, nums);
        }
    }
}
