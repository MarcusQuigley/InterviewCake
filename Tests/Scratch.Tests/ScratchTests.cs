using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scratch.Tests
{
    public class ScratchTests
    {
        readonly Scratch sut = null;
        public ScratchTests()
        {
            sut = new Scratch();
        }

         [Theory]
        [InlineData(new int[] { 100, 80, 60, 70, 60, 75, 85 }, new int[] { 1, 1, 1, 2, 1, 4, 6 })]
        [InlineData(new int[] { 31,41,48,59,79 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1,2,3,4,5 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 28, 14, 28, 35, 46,53,66,80,87,88 }, new int[] { 1,1,  3, 4, 5,6,7,8,9, 10 })]
        [InlineData(new int[] { 90, 21, 21, 68, 94, 13, 1, 37, 3, 61, 86, 19, 12, 35, 96 }, new int[] { 1, 1, 2, 3, 5, 1, 1, 3, 1, 5, 6, 1, 1, 3, 15 })]
        public void Test_StockSpanner( int[] stockPrices, int[] spans )
        {
            StockSpanner spanner = new StockSpanner();
            for (int i = 0; i < stockPrices.Length; i++)
            {
                Assert.True(spanner.Next(stockPrices[i]) == spans[i]);
            }
         }
    }
}
