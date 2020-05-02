using System;
using System.Collections.Generic;
using System.Text;
using Trees.LeetCode;
using Xunit;
namespace Trees.Tests.LeetCode
{
    public class LeetHardTreesTests : BaseTreeTests
    {
        LeetHardTrees sut;

        public LeetHardTreesTests()
        {
            sut = new LeetHardTrees();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 6)]
        [InlineData(new int[] { -10, 9, 20, -666, -666, 15, 7 }, 42)]
        public void Test_MaxPathSum(int[] values , int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.MaxPathSum(root);
            Assert.Equal(expected, actual);

        }
    }
}
