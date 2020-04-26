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
        public void Test_GroupAnagrams(int[] nums, int k, int[] expected)
        {
            var actual = sut.MaxSlidingWindow(nums,k);
            Assert.Equal(expected, actual);
        }
 
    }
}
