using System;
using Xunit;
using InterviewCake.Arrays;

namespace InterviewCake.Tests
{
    public class ArraysEasyTests
    {
        Easy sut;

        public ArraysEasyTests()
        {
            sut = new Easy();
        }

        [Theory]
        [InlineData(new int[]{12,345,2,6,7896},2)]
        [InlineData(new int[]{555,901,482,1771},1)]
        public void Test_FindNumbers(int[] numbers, int expected)
        {
             Assert.Equal(expected, sut.FindNumbers(numbers));
        }
    }
}
