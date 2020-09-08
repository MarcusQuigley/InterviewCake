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

        //[Theory]
        //[InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 2,4,1,3 })]
        //[InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 1, 3, 2 })]
        //[InlineData(new int[] { }, new int[] { })]
        //public void Test_InorderTraversal(int[] values, int[] expected)
        //{
        //    var root = base.CreatTreeNodesNonGeneric(values);
        //    var actual = sut.InorderTraversal(root);
        //    Assert.Equal(expected, actual);

        //}

        //[Theory]
        //[InlineData(new int[] { 1, 4, 3, 2 }, new int[] { 2, 4, 1, 3 })]
        //[InlineData(new int[] { 1, -666, 2, -666, -666, 3 }, new int[] { 1, 3, 2 })]
        //[InlineData(new int[] { }, new int[] { })]
        //public void Test_InorderTraversalRecursion(int[] values, int[] expected)
        //{
        //    var root = base.CreatTreeNodesNonGeneric(values);
        //    var actual = sut.InorderTraversalRecursion(root);
        //    Assert.Equal(expected, actual);

        //}
    }
}
