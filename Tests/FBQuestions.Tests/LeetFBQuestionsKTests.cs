
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FBQuestions.Tests
{
    public class LeetFBQuestionsKTests
    {
        readonly LeetFBQuestionsK sut = null;
        public LeetFBQuestionsKTests()
        {
            sut = new LeetFBQuestionsK();
        }

        [Fact]
        public void Test_KClosest()
        {
            var grid = new int[2][];
            grid[0] = new int[] { 1, 3 };
            grid[1] = new int[] { -2, 2 };

            var actual = sut.KClosest(grid, 1);
            var expected = new int[1][];
            expected[0] = new int[] { -2, 2 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_KClosest2()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 3, 3 };
            grid[1] = new int[] { 5, -1 };
            grid[2] = new int[] { -2, 4 };

            var actual = sut.KClosest(grid, 1);
            var expected = new int[1][];
            expected[0] = new int[] { 3, 3 };
         
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_KClosestPriorityQueue()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 3, 3 };
            grid[1] = new int[] { 5, -1 };
            grid[2] = new int[] { -2, 4 };

            var actual = sut.KClosestWithPriorityQueue(grid, 2);
            var expected = new int[2][];
            expected[0] = new int[] { -2, 4 };
            expected[1] = new int[] { 3, 3 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_KClosestQuickSelect()
        {
            var grid = new int[2][];
            grid[0] = new int[] { 1, 3 };
            grid[1] = new int[] { -2, 2 };

            var actual = sut.KClosestQuickSelect(grid, 1);
            var expected = new int[1][];
            expected[0] = new int[] { -2, 2 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_KClosestQuickSelect2()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 3, 3 };
            grid[1] = new int[] { 5, -1 };
            grid[2] = new int[] { -2, 4 };

            var actual = sut.KClosestQuickSelect(grid, 2);
            var expected = new int[2][];
            expected[0] = new int[] { 3, 3 };
            expected[1] = new int[] { -2, 4 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_KClosestQuickSelect3()
        {
            var grid = new int[3][];
            grid[0] = new int[] { 3, 3 };
            grid[1] = new int[] { 5, -1 };
            grid[2] = new int[] { -2, 4 };

            var actual = sut.KClosestQuickSelect(grid, 1);
            var expected = new int[1][];
            expected[0] = new int[] { 3, 3 };

            Assert.Equal(expected, actual);
        }
    }
}
