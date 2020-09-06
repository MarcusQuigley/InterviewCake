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

        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 2, new int[] { 2, 1, 3 })]
         [InlineData(new int[] { 4,2,7,1,3 }, 5, new int[] { })]
        public void TestSearchBST(int[] values,int k, int[] expected)
        {
            var head = CreatTreeNodesNonGeneric(values);
            //var expectedNode = CreatTreeNodesNonGeneric(expected);
            var actual = sut.SearchBSTIter(head, k);
            Assert.Equal(expected, ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 1,2,3,-666,5} , new string[] { "1->2->5", "1->3" })]
        [InlineData(new int[] { 1, 2, 3, 5,6}, new string[] { "1->2->5", "1->2->6", "1->3" })]
        public void Test_BinaryTreePaths(int[] values,  string[] expected)
        {
            var head = CreatTreeNodesNonGeneric(values);
            //var expectedNode = CreatTreeNodesNonGeneric(expected);
            var actual = sut.BinaryTreePaths(head );
            Assert.Equal(expected,  actual);
        }
        
    }
}
