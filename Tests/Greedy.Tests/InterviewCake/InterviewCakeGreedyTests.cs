using Greedy.InterviewCake;
using System;
using Xunit;

namespace Greedy.Tests.InterviewCake
{
   public class InterviewCakeGreedyTests
    {
      readonly  InterviewCakeGreedy sut = null;
        public InterviewCakeGreedyTests()
        {
            sut = new InterviewCakeGreedy();
        }

        [Theory]
        [InlineData(new int[] { 10, 7, 5, 8, 11, 9 }, 6)]
        [InlineData(new int[] { 13, 7, 5, 8, 4, 9 }, 5)]
        [InlineData(new int[] { 10, 7, 5, 3,2 }, -1)]
        public void Test_GetMaxProfit(int[] stockPrices, int expected) {
            var actual = sut.GetMaxProfit(stockPrices);
            Assert.Equal(expected, actual);
        }
    }
}
