using System;
using Xunit;
using InterviewCake.Scratch;

namespace InterviewCake.Tests
{
    public class ScratchTests
    {
        ScratchOne sut;

        public ScratchTests()
        {
            sut = new ScratchOne();
        }

        [Theory]
        [InlineData(100, 2, true)]
        [InlineData(100, 49, true)]
        [InlineData(10, 4, true)]
        [InlineData(10, 5, true)]
        [InlineData(10, 6, true)]
        [InlineData(4, 6, false)]
        public void Test_BinarySearchIterative(int end, int value, bool expected)
        {
            int[] numbers = new int[end];
            for (int i = 0; i < end; i++)
            {
                numbers[i] = i;
            }
            Assert.Equal(expected, sut.BinarySearchIterative(numbers, value));
        }


        [Theory]
        [InlineData(100, 2, true)]
        [InlineData(100, 49, true)]
        [InlineData(10, 4, true)]
        [InlineData(10, 5, true)]
        [InlineData(10, 6, true)]
        [InlineData(4, 6, false)]
        public void Test_BinarySearchRecursive(int end, int value, bool expected)
        {
            int[] numbers = new int[end];
            for (int i = 0; i < end; i++)
            {
                numbers[i] = i;
            }
            Assert.Equal(expected, sut.BinarySearch(numbers, value));
        }


        [Theory]
        [InlineData(5, new int[] { 2, 3, 5, 7, 11 })]
        [InlineData(26, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 })]
        //

        public void Test_PrimeNumbers(int num, int[] expected)
        {
            var actual = sut.PrimeNumbers(num);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(3, 3)]
        public void Test_CreateNxMArray(int n, int m)
        {
            var actual = sut.CreateNxMArray(n, m);
            // Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 }, new int[] { 13, 14, 15, 16 })]

        public void Test_RotateMatrix(int[] row1, int[] row2, int[] row3, int[] row4)
        {
            int[][] matrix = new int[4][];
            matrix[0] = row1;
            matrix[1] = row2;
            matrix[2] = row3;
            matrix[3] = row4;
            sut.RotateMatrix(matrix);
            // Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 })]
        public void Test_RotateMatrix1(int[] row1, int[] row2, int[] row3)
        {
            int[][] matrix = new int[3][];
            matrix[0] = row1;
            matrix[1] = row2;
            matrix[2] = row3;
            sut.RotateMatrix(matrix);
        }

        [Fact]
        public void Test_ZeroMatrix()
        {
            var rowsNumber = 5;
            var matrix = new int[rowsNumber][];
            matrix[0] = new int[] { 0, 0, 0, 1 };
            matrix[1] = new int[] { 1, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 0 };
            matrix[3] = new int[] { 1, 0, 0, 0 };
            matrix[4] = new int[] { 0, 0, 0, 0 };

            sut.ZeroMatrix(matrix, 1);

        }

        [Fact]
        public void Test_ShortestDistance()
        {
            var rowsNumber = 5;
            var matrix = new int[rowsNumber][];
            matrix[0] = new int[] { 0, 0, 0, 1 };
            matrix[1] = new int[] { 1, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 0 };
            matrix[3] = new int[] { 1, 0, 0, 0 };
            matrix[4] = new int[] { 0, 0, 0, 0 };

            sut.ZeroMatrix(matrix, 1);

        }

        [Fact]
        public void Test_MinDistanceInMatrix()
        { 
            var rowsNumber = 4;
            var matrix = new char[rowsNumber][];
            matrix[0] = new char[] { '0', '*', '0', 's' };
            matrix[1] = new char[] { '*', '0', '*', '*' };
            matrix[2] = new char[] { '0', '*', '*', '*' };
            matrix[3] = new char[] { 'd', '*', '*', '*' };
            

            var actual = sut.MinDistanceInMatrix(matrix);
            Assert.Equal(6, actual);

        }
    }
}

