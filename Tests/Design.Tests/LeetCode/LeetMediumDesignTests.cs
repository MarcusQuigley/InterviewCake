using Design.LeetCode.Medium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Design.Tests.LeetCode
{
    public class LeetMediumDesignTests
    {
        public LeetMediumDesignTests()
        {

        }
 
        [Fact]
        public void Test_LRUCache()
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(1, 1);
            cache.Put(2, 3);
            cache.Put(4, 1);
            Assert.Equal(-1, cache.Get(1));       // returns 1
            Assert.Equal(3, cache.Get(2));    // returns -1
        }

        [Fact]
        public void Test_LRUCache1()
        {
            LRUCache cache = new LRUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.Equal(1, cache.Get(1));
            cache.Put(3, 3);
            Assert.Equal(-1, cache.Get(2));
            cache.Put(4, 4);
            Assert.Equal(-1, cache.Get(1));
            Assert.Equal(3, cache.Get(3));
            Assert.Equal(4, cache.Get(4));
        }

        [Fact]
        public void Test_ShowFirstUnique()
        {
            FirstUnique sut = new FirstUnique(new int[] { 2, 3, 5 });
            Assert.Equal(2, sut.ShowFirstUnique());
            sut.Add(5);
            Assert.Equal(2, sut.ShowFirstUnique());
            sut.Add(2);
            Assert.Equal(3, sut.ShowFirstUnique());
            sut.Add(3);
            Assert.Equal(-1, sut.ShowFirstUnique());
        }

        [Fact]
        public void Test_ShowFirstUnique2()
        {
            FirstUnique sut = new FirstUnique(new int[] { 7, 7, 7, 7, 7, 7 });
            Assert.Equal(-1, sut.ShowFirstUnique());
            sut.Add(7);
            sut.Add(3);
            sut.Add(3);
            sut.Add(7);
            sut.Add(17);
            Assert.Equal(17, sut.ShowFirstUnique());
        }

        [Fact]
        public void Test_ShowFirstUnique3()
        {
            FirstUnique sut = new FirstUnique(new int[] {809});
            Assert.Equal(809, sut.ShowFirstUnique());
            sut.Add(809);
            Assert.Equal(-1, sut.ShowFirstUnique());
        }

        [Theory]
        [InlineData(new int[] { 100, 80, 60, 70, 60, 75, 85 }, new int[] { 1, 1, 1, 2, 1, 4, 6 })]
        [InlineData(new int[] { 31, 41, 48, 59, 79 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 28, 14, 28, 35, 46, 53, 66, 80, 87, 88 }, new int[] { 1, 1, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData(new int[] { 90, 21, 21, 68, 94, 13, 1, 37, 3, 61, 86, 19, 12, 35, 96 }, new int[] { 1, 1, 2, 3, 5, 1, 1, 3, 1, 5, 6, 1, 1, 3, 15 })]
        public void Test_StockSpanner(int[] stockPrices, int[] spans)
        {
            StockSpanner spanner = new StockSpanner();
            for (int i = 0; i < stockPrices.Length; i++)
            {
                Assert.True(spanner.Next(stockPrices[i]) == spans[i]);
            }
        }
    }
}
