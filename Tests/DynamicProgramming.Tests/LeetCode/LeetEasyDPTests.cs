using DynamicProgramming.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DynamicProgramming.Tests.LeetCode
{
    public class LeetEasyDPTests
    {
        LeetEasyDP sut = null;
        public LeetEasyDPTests()
        {
            sut = new LeetEasyDP();
        }

        [Theory]
        [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
        [InlineData(new int[] {  1,2 }, 1)]
        public void Test_BuyAndSellStockDp(int[] prices, int expected)
        {
            var actual = sut.MaxProfit(prices);
            Assert.Equal(expected, actual);
        }

    }
}
