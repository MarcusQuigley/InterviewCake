using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trees.LeetCode;
using Xunit;
namespace Trees.Tests.LeetCode
{
    public class LeetTreesProblemsMediumTests : BaseTreeTests
    {
        LeetTreesProblemsMedium sut;

        public LeetTreesProblemsMediumTests()
        {
            sut = new LeetTreesProblemsMedium();
        }

        [Theory]
        [InlineData(new int[] {1,-666,2, -666, -666, -666,3 }, new int[] { 3,2,1})]
        [InlineData(new int[] { 1,2 }, new int[] {  2, 1 })]
        [InlineData(new int[] { 4,2,9,3,5,-666,7 }, new int[] { 3,5,2,7,9,4 })]
        [InlineData(new int[] { 1,2,3,4,5,-666,7, -666, -666,6, -666, -666, -666, -666,8 }, new int[] {4,6,5,2,8,7,3,1})]
        public void Test_PostorderTraversal(int[] values, int[] expected)
        {
            var root = base.CreatTreeNodesNonGeneric(values);

            var actual = sut.PostorderTraversal(root);
            Assert.Equal(expected, actual);
        }
        
    }
}
