using Matrixes.CTCI;
using Xunit;

namespace Matrixes.Tests.CtCI
{
    public  class CTCIMatrixesTests
    {
         CTCIMatrixes sut = null;
        public CTCIMatrixesTests()
        {
            sut = new CTCIMatrixes();
        }
        [Fact]
        public void Tes_tRotateMatrix()
        {
            var grid = new int[4][];
            grid[0] = new int[] { 1, 2, 3, 4 };
            grid[1] = new int[] { 5, 6, 7, 8 };
            grid[2] = new int[] { 9, 10, 11, 12 };
            grid[3] = new int[] { 13, 14, 15, 16 };
            sut.RotateMatrix(grid);
            Assert.True(grid[3][1] == 12);
        }

        [Fact]
        public void Test_MinDistance()
        {
            var grid = new char[4][];
            grid[0] = new char[] { '0', '*', '0', 's' };
            grid[1] = new char[] { '*', '0', '*', '*' };
            grid[2] = new char[] { '0', '*',  '*', '*' };
            grid[3] = new char[] { 'd', '*', '*', '*' };
            var actual = sut.MinDistance(grid);
            Assert.Equal(6,actual);
        }
    }
}
