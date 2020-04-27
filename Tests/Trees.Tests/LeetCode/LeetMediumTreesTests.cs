using System;
using System.Collections.Generic;
using System.Text;
using Trees.LeetCode;
using Xunit;

namespace Trees.Tests.LeetCode
{
    public class LeetMediumTreesTests
    {
        readonly LeetMediumTrees sut = null;
        public LeetMediumTreesTests()
        {
            sut = new LeetMediumTrees();
        }

        [Theory]
        [InlineData(new int[] { 8, 5, 1, 7, 10, 12 }, new int[] { 8, 5, 10, 1, 7, -123, 12 })]
        //[InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        public void TestBstFromPreorder(int[] values, int[] expected)
        {
             
            var actual = sut.BstFromPreorder(values);
          //  Assert.Equal(expected, actual);
        }
        
    }
}
