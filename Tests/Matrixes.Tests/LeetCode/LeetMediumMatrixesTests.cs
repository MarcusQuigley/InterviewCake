using Matrixes.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Matrixes.Tests.LeetCode
{
    public class LeetMediumMatrixesTests
    {
        readonly LeetMediumMatrixes sut = null;
        public LeetMediumMatrixesTests()
        {
            sut = new LeetMediumMatrixes();
        }
        [Fact]
        public void Test_NumIslands()
        {
            var grid = new char[4][];
            grid[0] = new char[] { '1', '1', '1', '1', '0' };
            grid[1] = new char[] { '1', '1', '0', '1', '0' };
            grid[2] = new char[] { '1', '1', '0', '0', '0' };
            grid[3] = new char[] { '0', '0', '0', '0', '0' };
            var actual = sut.NumIslands(grid);
            Assert.Equal(1, actual);
        }
        [Fact]
        public void Test_NumIslands2()
        {
            var grid = new char[4][];
            grid[0] = new char[] { '1', '1', '0', '0', '0' };
            grid[1] = new char[] { '1', '1', '0', '0', '0' };
            grid[2] = new char[] { '0', '0', '1', '0', '0' };
            grid[3] = new char[] { '0', '0', '0', '1', '1' };
            var actual = sut.NumIslands(grid);
            Assert.Equal(3, actual);
        }

        [Fact]
        public void Test_MinPathSums()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 1, 3, 1 };
            grid[1] = new int[] { 1, 5, 1 };
            grid[2] = new int[] { 4, 2, 1 };
            var actual = sut.MinPathSum(grid);
            Assert.Equal(7, actual);
        }

        [Fact]
        public void Test_MinPathSums2()
        {
            var grid = new int[1][];
            grid[0] = new int[] {9, 1, 4, 8 };
            var actual = sut.MinPathSum(grid);
            Assert.Equal(22, actual);
        }

        [Fact]
        public void Test_MinPathSums3()
        {
            var grid = new int[2][];
            grid[0] = new int[] { 1, 2, 5 };
            grid[1] = new int[] { 3, 2, 1 };
            var actual = sut.MinPathSum(grid);
            Assert.Equal(6, actual);
        }

        [Fact]
        public void Test_ShortestPathBinaryMatrix()
        {
            var grid = new int[2][];
            grid[0] = new int[] { 0,1};
            grid[1] = new int[] { 1,0 };
            var actual = sut.ShortestPathBinaryMatrix(grid);
            Assert.Equal(2, actual);
        }

        [Fact]
        public void Test_ShortestPathBinaryMatrix2()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 0, 0,0 };
            grid[1] = new int[] { 1,1, 0 };
            grid[2] = new int[] { 1, 1, 0 };
            var actual = sut.ShortestPathBinaryMatrix(grid);
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Test_ShortestPathBinaryMatrix3()
        {
            var grid = new int[5][];
            grid[0] = new int[] { 0, 0, 0, 0,1 };
            grid[1] = new int[] { 1, 0, 0, 0, 0 };
            grid[2] = new int[] { 0,1,0, 1, 0 };
            grid[3] = new int[] { 0, 0, 0, 1, 1 };
            grid[4] = new int[] { 0, 0, 0, 1, 0 };
            var actual = sut.ShortestPathBinaryMatrix(grid);
            Assert.Equal(-1, actual);
        }

        [Fact]
        public void Test_ShortestPathBinaryMatrix4()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 0, 0, 0 };
            grid[1] = new int[] { 0, 1, 0 };
            grid[2] = new int[] { 0, 0, 0 };
            var actual = sut.ShortestPathBinaryMatrix(grid);
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Test_CountSquares()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 0, 1, 1, 1 };
            grid[1] = new int[] { 1, 1, 1, 1 };
            grid[2] = new int[] { 0, 1, 1, 1 };
            var actual = sut.CountSquares(grid);
            Assert.Equal(15, actual);
        }

        [Fact]
        public void Test_CountSquares2()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 1, 0, 1 };
            grid[1] = new int[] { 1, 1, 0 };
            grid[2] = new int[] { 1, 1, 0 };
            var actual = sut.CountSquares(grid);
            Assert.Equal(7, actual);
        }
    }
}
