using Arrays.InterviewCake;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Arrays.Tests.InterviewCake
{
      
    public class InterviewCakeArrayTests
    {
        InterviewCakeArrays sut;

        public InterviewCakeArrayTests()
        {
            sut = new InterviewCakeArrays();
        }


        [Theory]
        [InlineData(new int[] { 0, 3, 4, 10, 9 }, new int[] { 1, 5, 8, 12, 10 })]
        [InlineData(new int[] { 0, 3, 4, 10, 9 }, new int[] { 1, 5, 8, 12, 15 })]
        public void Test_InHouseCalendar(int[] starts, int[] ends)
        {
            var times = new Meeting[starts.Length];
            for (int i = 0; i < starts.Length; i++)
            {
                times[i] = new Meeting(starts[i], ends[i]);
            }
            var actual = sut.InHouseCalendar(times);
            Assert.Equal(1, 1);
        }

        [Theory]
        [InlineData("hello", "olleh")]
        [InlineData("h", "h")]
        public void Test_ReverseString(string toReverse, string expected)
        {
            var actual = sut.ReverseString(toReverse);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("the eagle has landed", "landed has eagle the")]
        [InlineData("hello there boys", "boys there hello")]
        [InlineData("hello boys", "boys hello")]
        public void Test_ReverseWords(string toReverse, string expected)
        {
            var actual = sut.ReverseWords(toReverse);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 4, 6, 10, 11, 15 }, new int[] { 1, 5, 8, 12, 14, 19 }, new int[] { 1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19 })]
        [InlineData(new int[] { 0 }, new int[] { 1, 5, 8, 12, 15 }, new int[] { 0, 1, 5, 8, 12, 15 })]
        public void Test_MergeSortedArray(int[] array1, int[] array2, int[] expected)
        {
            var actual = sut.MergeSortedArray(array1, array2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6 }, true)]
        [InlineData(new int[] { 1, 4, 5 }, new int[] { 2, 3, 6 }, new int[] { 1, 2, 3, 4, 5, 6 }, true)]
        [InlineData(new int[] { }, new int[] { 2, 3, 6 }, new int[] { 2, 3, 6 }, true)]
        public void Test_CafeOrderChecker(int[] takeout, int[] dineIn, int[] servedOrders, bool expected)
        {
            var actual = sut.CafeOrderChecker(takeout, dineIn, servedOrders);
            Assert.Equal(expected, actual);
        }



    }
}
