using Arrays.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Arrays.Tests.LeetCode
{
    public class LeetArraysHardTests
    {
       readonly LeetHardArrays  sut;
        public LeetArraysHardTests()
        {
            sut = new LeetHardArrays();
        }
        [Theory]
        [InlineData(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3,new int[]{ 3, 3, 5, 5, 6, 7 })]
        public void Test_MaxSlidingWindow(int[] nums, int k, int[] expected)
        {
            var actual = sut.MaxSlidingWindow(nums,k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ADOBECODEBANC", "ABC", "BANC")]
        [InlineData("OBEADOE", "OE", "OE")]
        public void Test_MinWindow(string s, string t , string expected)
        {
            var actual = sut.MinWindow(s,t);
            Assert.Equal(expected, actual);
        }
        
    }
}
