using System;
using System.Collections.Generic;
using System.Text;
using Trees.LeetCode;
using Xunit;
namespace Trees.Tests.LeetCode
{
    public class LeetTreesProblemsEasyTests : BaseTreeTests
    {
        LeetTreesProblemsEasy sut;

        public LeetTreesProblemsEasyTests()
        {
            sut = new LeetTreesProblemsEasy();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, -666, 4 }, new int[] { 4 })]
        [InlineData(new int[] { 7, 1, 4, 6, -666, 5, 3, -666, -666, -666, -666, -666, -666, -666, 2 }, new int[] { 6, 2 })]
        [InlineData(new int[] { 11, 99, 88, 77, -666, -666, 66, 55, -666, -666, -666, -666, -666, -666, 44 }, new int[] { 77, 55, 66, 44 })]
        [InlineData(new int[] { 11, 99, 88, 77, -666, -666, 66, 55, -666, -666, -666, -666, -666, -666, 44, 33, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, 22 }, new int[] { 77, 55, 33, 66, 44, 22 })]
        public void Test_GetLonelyNodes(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.GetLonelyNodes(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 5, 1, 7, -666, -666, -666, 8 }, 3, 5, 5)]
        //[InlineData(new int[] { 1, 5, 7, 8 }, 3, 7, 12)]
        //[InlineData(new int[] { 1, 5, 7, 8 }, 3, 9,20)]
        [InlineData(new int[] { 10, 5, 15, 3, 7, -666, 18 }, 7, 15, 32)]
        [InlineData(new int[] { 10, 5, 15, 3, 7, 13, 18, 1, -666, 6 }, 6, 10, 23)]
        public void Test_RangeSumBST(int[] values, int left, int right, int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.RangeSumBST(root, left, right);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 5, 1, 7, -666, -666, -666, 8 }, 3, 5, 5)]
        //[InlineData(new int[] { 1, 5, 7, 8 }, 3, 7, 12)]
        //[InlineData(new int[] { 1, 5, 7, 8 }, 3, 9,20)]
        [InlineData(new int[] { 10, 5, 15, 3, 7, -666, 18 }, 7, 15, 32)]
        [InlineData(new int[] { 10, 5, 15, 3, 7, 13, 18, 1, -666, 6 }, 6, 10, 23)]
        public void Test_RangeSumBSTIter(int[] values, int left, int right, int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.RangeSumBSTIter(root, left, right);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, new int[] { 2, 2, 2 }, new int[] { 3, 4, 2 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 2, 2, 2 }, new int[] { 3, 4, 5 })]
        [InlineData(new int[] { 1, 3, 2, 5 }, new int[] { 2, 1, 3, -666, 4, -666, 7 }, new int[] { 3, 4, 5, 5, 4, -666, 7 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 2, 2, 2, 2, 2, 2, 2 }, new int[] { 3, 3, 3, 3, 3, 3, 3 })]
        public void Test_MergeTrees(int[] n1, int[] n2, int[] expected)
        {
            var t1 = base.CreatTreeNodesNonGeneric(n1);
            var t2 = base.CreatTreeNodesNonGeneric(n2);
            var actual = sut.MergeTrees(t1, t2);
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, new int[] { 2, 2, 2 }, new int[] { 3, 4, 2 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 2, 2, 2 }, new int[] { 3, 4, 5 })]
        [InlineData(new int[] { 1, 3, 2, 5 }, new int[] { 2, 1, 3, -666, 4, -666, 7 }, new int[] { 3, 4, 5, 5, 4, -666, 7 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 2, 2, 2, 2, 2, 2, 2 }, new int[] { 3, 3, 3, 3, 3, 3, 3 })]
        public void Test_MergeTreesIter(int[] n1, int[] n2, int[] expected)
        {
            var t1 = base.CreatTreeNodesNonGeneric(n1);
            var t2 = base.CreatTreeNodesNonGeneric(n2);
            var actual = sut.MergeTreesIter(t1, t2);
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 2, new int[] { 2, 1, 3 })]
        [InlineData(new int[] { 4, 2, 7, -666, -666, 4 }, 2, new int[] { 2 })]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 6, new int[] { })]
        // [InlineData(new int[] { 63, 20, -666, 2, 40, -666, -666, -666, -666, -666, -666, -666, -666, 52 }, 63, new int[] {63,20 })]
        //
        public void Test_SearchBSTIter(int[] values, int val, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.SearchBSTIter(root, val);
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 2, new int[] { 2, 1, 3 })]
        [InlineData(new int[] { 4, 2, 7, -666, -666, 4 }, 2, new int[] { 2 })]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 6, new int[] { })]
        // [InlineData(new int[] { 63, 20, -666, 2, 40, -666, -666, -666, -666, -666, -666, -666, -666, 52 }, 63, new int[] {63,20 })]
        //
        public void Test_SearchBST(int[] values, int val, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.SearchBST(root, val);
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 6 }, new int[] { 3, -666, 5, -666, 6 })]
        [InlineData(new int[] { 5, 3, 6, 2, 4, -666, 8, 1, -666, -666, -666, -666, -666, 7, 9 }, new int[] { 1, -666, 2, -666,3,-666, 4, -666, 5, -666, 6, -666, 7, -666, 8, -666, 9 })]
        public void Test_IncreasingBST(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.IncreasingBST(root);
            var exp = base.ArrayFromTree(actual);
            Assert.Equal(expected, exp);
        }
    }
}
