using System;
using System.Collections.Generic;
using System.Text;
using Trees.LeetCode;
using Xunit;

namespace Trees.Tests.LeetCode
{
    public class LeetMediumTreesTests : BaseTreeTests
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
            //     Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 0, 1, 0, -666, -666, 1, 0, 0 }, new int[] { 0, 1, 0, 1 }, true)]
        [InlineData(new int[] { 0, 1, 0, 0, 1, 0, -666, -666, 1, 0, 0 }, new int[] { 0, 0, 1 }, false)]
        [InlineData(new int[] { 0, 1, 0, 0, 1, 0, -666, -666, 1, 0, 0 }, new int[] { 0, 1, 1 }, false)]
        [InlineData(new int[] { 0, 1, 0, 0, 1, 0, -666, -666, 1, 0, 0 }, new int[] { 0, 0, 0 }, true)]
        [InlineData(new int[] { 0, 1, 0 }, new int[] { 0, 0 }, true)]
        [InlineData(new int[] { 0, 0, 0, -666, 0, 0, 1 }, new int[] { 0, 0, 1 }, true)]
        public void Test_IsValidSequence(int[] values, int[] arr, bool expected)
        {
            var root = CreatTreeNodes(values);
            var actual = sut.IsValidSequence(root, arr);
            Assert.Equal(expected, actual);
        }

       

        [Theory]
        [InlineData(new int[] { 3, 1, 4, -666, 2 }, 1, 1)]
        [InlineData(new int[] { 5, 3, 6, 2, 4, -666, -666, 1 }, 1, 1)]
        public void Test_KthSmallest(int[] values, int k, int expected)
        {
            var root = CreatTreeNodesNonGeneric(values);
            var actual = sut.KthSmallestDFS(root, k);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 5, new int[] { 4, 2, 7, 1, 3, 5 })]
        [InlineData(new int[] { 40, 20, 60, 10, 30, 50, 70 }, 25, new int[] { 40, 20, 60, 10, 30, 50, 70 , -666, -666, 25})]
        public void Test_InsertIntoBST(int[] values, int k, int[] expected)
        {
            var root = CreatTreeNodesNonGeneric(values);
            var actual = sut.InsertIntoBST(root, k);
            Assert.Equal(expected, ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 5, new int[] { 4, 2, 7, 1, 3, 5 })]
        [InlineData(new int[] { 40, 20, 60, 10, 30, 50, 70 }, 25, new int[] { 40, 20, 60, 10, 30, 50, 70, -666, -666, 25 })]
        public void Test_InsertIntoBSTIterative(int[] values, int k, int[] expected)
        {
            var root = CreatTreeNodesNonGeneric(values);
            var actual = sut.InsertIntoBSTIterative(root, k);
            Assert.Equal(expected, ArrayFromTree(actual));
        }
        
    }
}
