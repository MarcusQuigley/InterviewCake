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
    }
}
