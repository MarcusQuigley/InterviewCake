using System;
using System.Collections.Generic;
using System.Text;
using Trees.LeetCode;
using Xunit;
namespace Trees.Tests.LeetCode
{
    public class BinaryTreeStudyChapterTests : BaseTreeTests
    {
        BinaryTreeStudyChapter sut;

        public BinaryTreeStudyChapterTests()
        {
            sut = new BinaryTreeStudyChapter();
        }

        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 1, 4, 2, 3 })]
        [InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_PreorderTraversalRecursive(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.PreorderTraversalRecursive(root);
            Assert.Equal(expected, actual);
         }

        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 1, 4, 2, 3 })]
        [InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_PreorderTraversal(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.PreorderTraversal(root);
            Assert.Equal(expected, actual);
         }

        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 2,4,1,3 })]
        [InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 1, 3, 2 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_InorderTraversal(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.InorderTraversal(root);
            Assert.Equal(expected, actual);
         }

        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 2, 4, 1, 3 })]
        [InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 1, 3, 2 })]
        [InlineData(new int[] { }, new int[] { })]
        public void Test_InorderTraversalRecursion(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.InorderTraversalRecursion(root);
            Assert.Equal(expected, actual);
         }

        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 2, 4, 3, 1 })]
        [InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] {   3, 2,1 })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 1,2}, new int[] { 2,1})]
        [InlineData(new int[] { 1,-666, 2 }, new int[] { 2, 1 })]
        public void Test_PostorderTraversal(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.PostorderTraversal(root);
            Assert.Equal(expected, actual);
         }
 
        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 2, 4, 3, 1 })]
        [InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 3, 2, 1 })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [InlineData(new int[] { 1, -666, 2 }, new int[] { 2, 1 })]
        public void Test_postorderTraversal2Tushar(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.postorderTraversal2Tushar(root);
            Assert.Equal(expected, actual);
         }

        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 1 }, new int[] { 4,3 }, new int[] { 2 })]
        [InlineData(new int[] {3,9,20,-666,-666,15,7 }, new int[] { 3 }, new int[] {9,20 }, new int[] { 15,7 })]
    //    [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 1, 2 }, new int[] { 1  },new int[] {  2 })]
        [InlineData(new int[] { 1, -666, 2 }, new int[] {   1 }, new int[] { 2 })]
        public void Test_LevelOrderTraversal(int[] values, params int[][] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.LevelOrderTraversal(root);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 3, 9, 20, -666, -666, 15, 7 }, 3)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { }, 0)]
        public void Test_MaxDepthBFS(int[] nums, int expected)
        {
            var treeNode = base.CreatTreeNodesNonGeneric(nums);
            var actual = sut.MaxDepthBFS(treeNode);
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

        [Theory]
        [InlineData(new int[] { 5, 4, 8, 11, -666, 13, 4, 7, 2, -666, -666, -666, 1 }, 22, true)]
        [InlineData(new int[] { 3, 9, 20, }, 23, true)]
        [InlineData(new int[] { 3, 9, 20, 8, 11 }, 18, false)]
        public void Test_HasPathSum(int[] nums, int sum, bool expected)
        {
            var treeNode = base.CreatTreeNodesNonGeneric(nums);
            var actual = sut.HasPathSum(treeNode, sum);
            Assert.Equal(expected, actual);
        }
    }
}
