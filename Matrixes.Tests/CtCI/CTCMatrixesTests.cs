using Matrixes.CTCI;
using Xunit;

namespace Matrixes.Tests.CtCI
{
    public  class CTCMatrixesTests
    {
         CTCIMatrixes sut = null;
        public CTCMatrixesTests()
        {
            sut = new CTCIMatrixes();
        }
        [Fact]
        public void TestRotateMatrix()
        {
            var grid = new int[4][];
            grid[0] = new int[] { 1, 2, 3, 4 };
            grid[1] = new int[] { 5, 6, 7, 8 };
            grid[2] = new int[] { 9, 10, 11, 12 };
            grid[3] = new int[] { 13, 14, 15, 16 };
            sut.RotateMatrix(grid);
            Assert.Equal("", "Need to fix this RotateMatrix");
        }
    }
}
