using Stacks.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stacks.Tests.LeetCode
{
   public class LeetEasyQuestionsStacksTests
    {
        MinStack sut = null;
        public LeetEasyQuestionsStacksTests()
        {
            sut = new MinStack();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 3)]
        [InlineData(new int[] { 1, 2, 3,5,66,2,3,77,888,1,4 }, 11)]
        [InlineData(new int[] {  }, 0)]
        [InlineData(new int[] { 11 }, 1)]
        [InlineData(new int[] { 1,1}, 2)]
        public void TestPush(int[] values, int expected)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Push(values[i]);
            }

            var count = sut.Count;
            Assert.Equal(expected, count);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 3 }, 3)]
        [InlineData(new int[] { 1, 2, 3, 5, 66, 2, 3, 77, 888, 1, 4 }, 4)]
         [InlineData(new int[] { 11 }, 11)]
        [InlineData(new int[] { 3, 1 }, 1)]
        public void TestTop(int[] values, int expected)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Push(values[i]);
            }

            var top = sut.Top();
            Assert.Equal(expected, top);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 3 },  2)]
        [InlineData(new int[] { 1, 2, 3, 5, 66, 2, 3, 77, 888, 666, 4 },  10)]
        [InlineData(new int[] { 11 },   0)]
        [InlineData(new int[] { 1, 1 }, 1)]
        public void TestPop(int[] values,   int expectedCount)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Push(values[i]);
            }
              sut.Pop();

            var top = sut.Count;
         
            Assert.Equal(expectedCount, top);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 3 }, 2)]
        [InlineData(new int[] { 15, 2, 3, 5, 66, 2, 3, 77, 888, 1, 4 }, 1)]
        [InlineData(new int[] { 11 }, 11)]
        [InlineData(new int[] { 2, 1 }, 1)]
        [InlineData(new int[] { 1, 1 }, 1)]
        public void TestMin(int[] values, int expected)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Push(values[i]);
            }

            var min = sut.GetMin();
            Assert.Equal(expected, min);
        }

        [Theory]
        [InlineData(new int[] { -2, 0, -3 }, -3, 0,-2)]
        public void TestIntegrated(int[] values, int expectedmin, int expectedtop, int expectedsecondmin)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sut.Push(values[i]);
            }
            var min1 = sut.GetMin();
            sut.Pop();
            var top = sut.Top();
            var min2 = sut.GetMin();
 
            Assert.Equal(expectedmin, min1);
            Assert.Equal(expectedtop, top);
            Assert.Equal(expectedsecondmin, min2);
        }


    }
}
