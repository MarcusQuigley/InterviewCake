using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Trees.Tests
{
    public class MaxHeapTests
    {
        MaxHeap<int> sut = null;
        public MaxHeapTests()
        {
            sut = new MaxHeap<int>();
        }

        [Theory]
        [InlineData(new int[] { 3,5,1,6,8,4,2}, 7)]
        public void TestCount(int[] values, int expected)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Add(values[i]);
            }
            var actual = sut.Count;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 5, 1, 6, 8, 4, 2 }, 7)]
        public void TestCtrWithCount(int[] values, int expected)
        {
            sut = new MaxHeap<int>(values);
            var actual = sut.Count;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 5, 1, 6, 8, 4, 2 }, 55)]
        public void TestAdd(int[] values, int expected)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Add(values[i]);
            }
            sut.Add(expected);
            var actual = sut.Peek();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 5, 1, 6, 8, 4, 2 }, 8)]
        public void TestRemove(int[] values, int expected)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Add(values[i]);
            }
            
            var actual = sut.RemoveMax();
            Assert.Equal(expected, actual);
        }
    }
}
