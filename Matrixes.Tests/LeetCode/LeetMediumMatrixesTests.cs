using Matrixes.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Matrixes.Tests.LeetCode
{
    public class LeetMediumMatrixesTests
    {
        LeetMediumMatrixes sut = null;
        public LeetMediumMatrixesTests()
        {
            sut = new LeetMediumMatrixes();
        }
        [Fact]
        public void Test_NumIslands()
        {
            var grid = new char[4][];
            grid[0] = new char[] { '1', '1', '1','1', '0' };
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

    }
}
