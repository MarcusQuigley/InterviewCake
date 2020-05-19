using Matrixes.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Matrixes.Tests.LeetCode
{
    public class LeetEasyMatrixesTests
    {
        readonly LeetEasyMatrixes sut = null;
        public LeetEasyMatrixesTests()
        {
            sut = new LeetEasyMatrixes();
        }

        [Fact]
        public void Test_FloodFills()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 1, 1, 1 };
            grid[1] = new int[] { 1, 1, 0 };
            grid[2] = new int[] { 1, 0, 1 };

            var actual = sut.FloodFill(grid, 1, 1, 2);
            var expected = new int[3][];
            expected[0] = new int[] { 2, 2, 2 };
            expected[1] = new int[] { 2, 2, 0 };
            expected[2] = new int[] { 2, 0, 1 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_FloodFill2()
        {
            var grid = new int[2][];
            grid[0] = new int[] { 0, 0, 0 };
            grid[1] = new int[] { 0, 1, 1 };
            var actual = sut.FloodFill(grid, 1, 1, 1);
            var expected = new int[2][];
            expected[0] = new int[] { 0, 0, 0 };
            expected[1] = new int[] { 0, 1, 1 };

            Assert.Equal(expected, actual);
        }
    }
}
