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

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
        [InlineData(new int[] { 1, 0 }, 1, new int[] { 1 }, 1, new int[] { 1, 1 })]
        [InlineData(new int[] { 0 }, 0, new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3, 0 }, 3, new int[] { 1 }, 1, new int[] { 1, 1, 2, 3 })]
        [InlineData(new int[] { 2, 0 }, 1, new int[] { 1 }, 1, new int[] { 1, 2 })]
        public void Test_Merge(int[] nums, int m, int[] nums2, int n, int[] expected)
        {
            sut.Merge(nums, m, nums2, n);
            Assert.Equal(expected, nums);
        }
    }
}
