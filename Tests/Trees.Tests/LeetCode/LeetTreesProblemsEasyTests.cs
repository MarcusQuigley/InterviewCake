using System;
using System.Collections.Generic;
using System.Linq;
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
        [InlineData(new int[] { 5, 3, 6, 2, 4, -666, 8, 1, -666, -666, -666, -666, -666, 7, 9 }, new int[] { 1, -666, 2, -666, 3, -666, 4, -666, 5, -666, 6, -666, 7, -666, 8, -666, 9 })]
        public void Test_IncreasingBST(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.IncreasingBST(root);
            var exp = base.ArrayFromTree(actual);
            Assert.Equal(expected, exp);
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 1, 0, 1, 0, 1 }, 22)]

        [InlineData(new int[] { 1, 0, 1, 0, 1, -666, 1 }, 16)]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 1 }, 3)]
        [InlineData(new int[]{1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, -666, 1, 0, -666, 1, 1, 1, 1, -666, 0, -666, -666, -666, -666, -666, -666, 1, -666, 0, -666, -666, -666, -666, -666, 0, 1, 1, 0,
        0, 0, 0, -666, -666, -666, 0, -666, -666, -666, 0, -666, 0, -666, -666, -666, -666, 1, -666, -666, 0, 0, 0, -666, -666, -666, 1, -666, -666, -666, 0, 0, -666, -666, -666, -666,
            -666, 0, -666, -666, -666, -666, 1, -666, -666, -666, 0, 1, -666, 0 }, 643)]
        public void Test_SumRootToLeaf(int[] values, int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.SumRootToLeaf(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, true)]
        [InlineData(new int[] { 2, 2, 2, 5, 2 }, false)]
        public void Test_IsUnivalTree(int[] values, bool expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.IsUnivalTree(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, true)]
        [InlineData(new int[] { 2, 2, 2, 5, 2 }, false)]
        public void Test_IsUnivalTreeIter(int[] values, bool expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.IsUnivalTreeIter(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 9, 20, -666, -666, 15, 7 }, 3)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 2, 2, 3 }, 3)]
        [InlineData(new int[] { }, 0)]
        [InlineData(new int[] { 4, 9, 20, 6, -666, -666, 15, 7, -666, -666, -666, -666, -666, -666, 15 }, 4)]
        [InlineData(new int[] { 3, 9, 20, 6, -666, -666, 15, 7 }, 4)]
        public void Test_MaxDepth(int[] nums, int expected)
        {
            var treeNode = base.CreatTreeNodesNonGeneric(nums);
            var actual = sut.MaxDepth(treeNode);
            Assert.Equal(expected, actual);
        }







        [Theory]
        [InlineData(new int[] { 3, 9, 20, -666, -666, 15, 7 }, 3)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 2, 2, 3 }, 3)]
        [InlineData(new int[] { }, 0)]
        [InlineData(new int[] { 3, 9, 20, 6, -666, -666, 15, 7, -666, -666, -666, -666, -666, -666, 15 }, 4)]
        [InlineData(new int[] { 4, 9, 20, 6, -666, -666, 15, 7 }, 4)]
        [InlineData(new int[] { 3, 9, 20, 6 }, 3)]
        public void Test_MaxDepthIter(int[] nums, int expected)
        {
            var treeNode = base.CreatTreeNodesNonGeneric(nums);
            var actual = sut.MaxDepthIter(treeNode);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3, 6, 9 }, new int[] { 4, 7, 2, 9, 6, 3, 1 })]
        //[InlineData(new int[] { 4, 2, 7, -666, -666, 4 }, 2, new int[] { 2 })]
        //[InlineData(new int[] { 4, 2, 7, 1, 3 }, 6, new int[] { })]
        public void Test_InvertTree(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.InvertTree(root);
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3, 6, 9 }, new int[] { 4, 7, 2, 9, 6, 3, 1 })]
        //[InlineData(new int[] { 4, 2, 7, -666, -666, 4 }, 2, new int[] { 2 })]
        //[InlineData(new int[] { 4, 2, 7, 1, 3 }, 6, new int[] { })]
        public void Test_InvertTreeIter(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.InvertTreeIter(root);
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 7, }, new int[] { 34, 7, 2 }, false)]
        [InlineData(new int[] { 4, 2, 7, }, new int[] { 34, 2, 7 }, true)]
        [InlineData(new int[] { 1, 2 }, new int[] {2,2 }, true)]

        //[InlineData(new int[] { 4, 2, 7, 1, 3 }, 6, new int[] { })]
        public void Test_LeafSimilar(int[] values1, int[] values2, bool expected)
        {
            var root1 = base.CreatTreeNodesNonGeneric(values1);
            var root2 = base.CreatTreeNodesNonGeneric(values2);
            var actual = sut.LeafSimilar(root1,root2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3,9,20,-666,-666,15,7 }, new double[] { 3,14.5,11 })]
         //[InlineData(new int[] { 4, 2, 7, 1, 3 }, 6, new int[] { })]
        public void Test_AverageOfLevels(int[] values, double[]   expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.AverageOfLevels(root);
            Assert.Equal(expected, actual.ToArray());
        }

        [Theory]
        [InlineData(new int[] {1,0,2 },1,2, new int[] { 1,-666,2 })]
       // [InlineData(new int[] {3,0,4,-666,2,-666,-666,1}, 1,3, new int[] {3,2,-666,1 })]
        [InlineData(new int[] { 1, -666, 2 }, 1, 3, new int[] { 1, -666, 2 })]
        [InlineData(new int[] { 1, -666, 2 }, 2, 4, new int[] { 2 })]
        public void Test_TrimBST(int[] values,int low, int high, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.TrimBST(root, low, high);
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 6, 2, 4, -666, 7 },22,  false)]
        [InlineData(new int[] {5,3,6,2,4,-666,7 }, 9,true)]
         public void Test_FindTarget(int[] values, int k,bool expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            
            var actual = sut.FindTarget(root,k);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 5,2,13 } , new int[] {18,20,13 })]
        [InlineData(new int[] {  }, new int[] { })]
        [InlineData(new int[] { 10,5,13,2,7,12,15} , new int[] {  50,62,28,64,57,40,15 })]
        public void Test_ConvertBST(int[] values,  int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);
            var actual = sut.ConvertBST(root );
            Assert.Equal(expected, base.ArrayFromTree(actual));
        }

        [Theory]
        [InlineData(new int[] {2,1,3 },1)]
        [InlineData(new int[] {1,-666,2 },1)]
        [InlineData(new int[] { 1, -666,3, -666, -666, 2 }, 1)]
        public void Test_GetMinimumDifference(int[] values, int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.GetMinimumDifference(root);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 2, 1, 3 }, 1)]
        [InlineData(new int[] { 1, -666, 2 }, 1)]
        [InlineData(new int[] { 1, -666, 3, -666, -666, 2 }, 1)]
        public void Test_GetMinimumDifferenceIter(int[] values, int expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.GetMinimumDifferenceIter(root);
            Assert.Equal(expected, actual);
        }

    }
}
