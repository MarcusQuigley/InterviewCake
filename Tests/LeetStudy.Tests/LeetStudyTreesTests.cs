using System;
using Trees.Tests.LeetCode;
using Xunit;

namespace LeetStudy.Tests
{
    public class LeetStudyTreesTests : BaseTreeTests
    {
        LeetStudyTrees sut;
        public LeetStudyTreesTests()
        {
            sut = new LeetStudyTrees();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1,  2, 3 })]
        [InlineData(new int[] { 8, 5, 1, 7, 10, 12 }, new int[] { 8, 5, 1, 7, 10, 12 })]
        [InlineData(new int[] { }, new int[] {  })]
        public void Test_PreorderTraversal(int[] nums, int[] expected)
        {
            var treeNode = base.BSTreeFromPreOrder(nums);
            var actual = sut.PreorderTraversal(treeNode);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 8, 5, 1, 7, 10, 12 }, new int[] { 8, 5, 1, 7, 10, 12 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_PreorderTraversalRecursive(int[] nums, int[] expected)
        {
            var treeNode = base.BSTreeFromPreOrder(nums);
            var actual = sut.PreorderTraversalRecursive(treeNode);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 8, 5, 1, 7, 10, 12 }, new int[] { 1,5, 7,8, 10, 12 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_InorderTraversal(int[] nums, int[] expected)
        {
            var treeNode = base.BSTreeFromPreOrder(nums);
            var actual = sut.InorderTraversal(treeNode);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] {  3,2,1 })]
        [InlineData(new int[] { 8, 5, 1, 7, 10, 12 }, new int[] { 1,  7, 5, 12, 10, 8 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_PostorderTraversal(int[] nums, int[] expected)
        {
            var treeNode = base.BSTreeFromPreOrder(nums);
            var actual = sut.PostorderTraversal(treeNode);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 9, 20, -666, -666, 15, 7 }, new int[] {3 }, new int[] { 9,20 }, new int[] { 15,7 })]
        [InlineData(new int[] {1 }, new int[] {1  })]
        //[InlineData(new int[] {   }, new int[] {  })]
        public void Test_LevelOrder(int[] nums, params int[][] expected)
        {
            var treeNode = base.CreatTreeNodesNonGeneric(nums);
            var actual = sut.LevelOrder(treeNode);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 9, 20, -666, -666, 15, 7 }, 3)]
        [InlineData(new int[] { 1 },1)]
        [InlineData(new int[] {   }, 0)]
        public void Test_MaxDepthIter(int[] nums,   int  expected)
        {
            var treeNode = base.CreatTreeNodesNonGeneric(nums);
            var actual = sut.MaxDepthIter(treeNode);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 9, 20, -666, -666, 15, 7 }, 3)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { }, 0)]
        public void Test_MaxDepth(int[] nums, int expected)
        {
            var treeNode = base.CreatTreeNodesNonGeneric(nums);
            var actual = sut.MaxDepth(treeNode);
            Assert.Equal(expected, actual);
        }
       
        
    }
}
