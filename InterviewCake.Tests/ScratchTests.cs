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
        [InlineData(5,new int[] { 2,3,5,7,11})]
        [InlineData(26, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 })]
        //

        public void Test_PrimeNumbers(int num, int[] expected)
        {
            var actual = sut.PrimeNumbers(num);
            Assert.Equal(expected, actual);
        }
    }
}
