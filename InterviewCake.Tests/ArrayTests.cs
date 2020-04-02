using System;
using Xunit;
using InterviewCake.Arrays;

namespace InterviewCake.Tests
{
    public class ArrayTests
    {
        ArrayQuestions sut;

        public ArrayTests()
        {
            sut = new ArrayQuestions();
        }

        [Theory]
        [InlineData(new int[]{12,345,2,6,7896},2)]
        [InlineData(new int[]{555,901,482,1771},1)]
        public void Test_FindNumbers(int[] numbers, int expected)
        {
             Assert.Equal(expected, sut.FindNumbers(numbers));
        }

        [Theory]
        [InlineData(new int[] {0,3,4,10,9 }, new int[] { 1,5,8,12,10})]
        [InlineData(new int[] { 0, 3, 4, 10, 9 }, new int[] { 1, 5, 8, 12, 15 })]

        public void Test_InHouseCalendar(int[] starts, int[] ends)
        {
            var times = new Meeting[starts.Length];
            for (int i = 0; i < starts.Length; i++)
            {
                times[i] = new Meeting(starts[i], ends[i]);
            }
            var actual = sut.InHouseCalendar(times);
            Assert.Equal(1,1 );
        }
    }
}
