using System;
using System.Collections.Generic;
using System.Text;
using Trees.LeetCode;
using Xunit;

namespace Trees.Tests.LeetCode
{
    public class LeetEasyTreesTests : BaseTreeTests
    {
        readonly LeetEasyTrees<int> sut = null;
        public LeetEasyTreesTests()
        {
            sut = new LeetEasyTrees<int>();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        //[InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        public void TestMiddleNode(int[] values, int expected)
        {
             var head = CreatTreeNodes(values);
            var actual = sut.DiameterOfBinaryTree(head);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 2, 7, 4, 1, 8, 1 }, 1)]
        public void TestLastStoneWeight(int[] values, int expected)
        {
            var actual = sut.LastStoneWeight(values);
            Assert.Equal(expected, actual);
        }



       
    }
}
