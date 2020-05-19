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
    }
}
