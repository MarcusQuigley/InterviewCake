using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trees.LeetCode;
using Xunit;
namespace Trees.Tests.LeetCode
{
    public class LeetTreesProblemsEasyV2Tests : BaseTreeTests
    {
        LeetTreesProblemsEasyV2 sut;

        public LeetTreesProblemsEasyV2Tests()
        {
            sut = new LeetTreesProblemsEasyV2();
        }
 
        [Theory]
        [InlineData(new int[] { 5, 1, 7, -666, -666, -666, 8 }, 3, 5, 5)]
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
         [InlineData(new int[] { 10, 5, 15, 3, 7, -666, 18 }, 7, 15, 32)]
        [InlineData(new int[] { 10, 5, 15, 3, 7, 13, 18, 1, -666, 6 }, 6, 10, 23)]
        public void Test_RangeSumBSTIter(int[] values, int left, int right, int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.RangeSumBSTIter(root, left, right);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, -666, 4 }, new int[] { 4 })]
        [InlineData(new int[] { 7, 1, 4, 6, -666, 5, 3, -666, -666, -666, -666, -666, -666, -666, 2 }, new int[] { 6, 2 })]
        [InlineData(new int[] { 11, 99, 88, 77, -666, -666, 66, 55, -666, -666, -666, -666, -666, -666, 44 }, new int[] { 77, 55, 66, 44 })]
        [InlineData(new int[] { 11, 99, 88, 77, -666, -666, 66, 55, -666, -666, -666, -666, -666, -666, 44, 33, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, 22 }, new int[] { 77, 55, 33, 66, 44, 22 })]
        public void Test_GetLonelyNodesIter(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.GetLonelyNodesIter(root);
            Assert.Equal(expected, actual);
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

    }
}
