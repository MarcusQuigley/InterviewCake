using Matrixes.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Matrixes.LeetCode.LeetCompetitionMatrixes;

namespace Matrixes.Tests.LeetCode
{
    public class LeetCompetitionMatrixesTests
    {
        readonly LeetCompetitionMatrixes sut = null;
        public LeetCompetitionMatrixesTests()
        {
            sut = new LeetCompetitionMatrixes();
        }

        [Theory]
        // [InlineData(new int[2][] {new int[2]{0,0}, new int[2] { 1, 1 })]
        [InlineData(0,new int []  { 0, 0 }, new int[] { 1, 1 })]
        [InlineData(1, new int[] { 0, 0 }, new int[] { 0, 1 })]
        [InlineData(-1, new int[] { 0, 0 }, new int[] { 0,0 })]
        [InlineData(1, new int[] { 0, 0, 0, 1 }, new int[] { 0, 0, 1, 1 }, new int[] { 0, 1, 1, 1 })]
        [InlineData(0, new int[] { 0 }, new int[] { 1 })]
        [InlineData(-1, new int[] { 0 }, new int[] { 0 })]
        [InlineData(0, new int[] { 1 }, new int[] { 1 })]
        public void Test_LeftMostColumnWithOne(int expected, params int[][] array)
        {
            IBinaryMatrix binaryMatrix = new BinaryMatrix(array);
            var actual = sut.LeftMostColumnWithOne(binaryMatrix);
            Assert.Equal(expected, actual);
        }

    }
}
