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
        [InlineData(new int[] { 7, 1, 4, 6, -666, 5, 3, -666, -666, -666, -666, -666, -666, -666, 2 }, new int[] { 6,2 })]
        [InlineData(new int[] { 11, 99, 88, 77, -666, -666, 66, 55, -666, -666, -666, -666, -666, -666, 44  }, new int[] { 77, 55,  66, 44   })]
        [InlineData(new int[] { 11, 99, 88, 77, -666, -666, 66, 55, -666, -666, -666, -666, -666, -666, 44, 33, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666, -666,-666,-666, 22 }, new int[] { 77, 55, 33, 66, 44, 22 })]
        public void Test_GetLonelyNodes(int[] values , int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.GetLonelyNodes(root);
            Assert.Equal(expected, actual);
         }

        [Theory]
        [InlineData(new int[] { 5,1,7,-666, -666, -666, 8 }, 3, 5, 5)]
        //[InlineData(new int[] { 1, 5, 7, 8 }, 3, 7, 12)]
        //[InlineData(new int[] { 1, 5, 7, 8 }, 3, 9,20)]
        [InlineData(new int[] { 10, 5, 15, 3, 7, -666, 18 },7,15,32)]
        [InlineData(new int[] { 10, 5, 15, 3, 7, 13, 18,1,-666,6 }, 6,10,23)]
        public void Test_RangeSumBST(int[] values,int left, int right,  int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.RangeSumBST(root, left,right);
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
        

    }
}
