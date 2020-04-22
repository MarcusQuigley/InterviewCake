using LeetCode.Arrays;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode.Tests
{
    public class LeetArraysMediumTests
    {
        LeetMediumQuestions sut;
        public LeetArraysMediumTests()
        {
            sut = new LeetMediumQuestions();
        }
        [Theory]
        [InlineData(new string[] { "cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc" }, 10)]
        [InlineData(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" }, 3)]
        [InlineData(new string[] { "duh", "ill" },2)]
        public void Test_GroupAnagrams(string[] strs, int expected)
        {
            var actual = sut.GroupAnagrams(strs);
            Assert.Equal(expected, actual.Count);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2)]
        [InlineData(new int[] { 1, 1, 3, 3, 5, 5, 7, 7 }, 0)]
        [InlineData(new int[] { 1, 3, 2, 3, 5, 0 }, 3)]
        [InlineData(new int[] { 1, 1, 2, 2 }, 2)]
        [InlineData(new int[] { 1, 1, 2,  }, 2)]
        public void Test_CountElements(int[] elements, int expected)
        {
            var actual = sut.CountElements(elements);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 0, 0 }, 0)]
        [InlineData(new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 0, 1, 0 }, 2)]
        [InlineData(new int[] { 0, 1, 1 }, 2)]
        [InlineData(new int[] { 0, 1, 0, 1, 1, 1, 0, 0, 0 }, 8)]
        [InlineData(new int[] { 0, 1, 1, 1, 1, 1, 0, 0, 0 }, 6)]
        public void Test_FindMaxLength(int[] nums, int expected)
        {
            var actual = sut.FindMaxLength(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 0, 0 }, 0)]
        [InlineData(new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 0, 1, 0 }, 2)]
        [InlineData(new int[] { 0, 1, 1 }, 2)]
        [InlineData(new int[] { 0, 1, 0, 1, 1, 1, 0, 0, 0 }, 8)]
        [InlineData(new int[] { 0, 1, 1, 1, 1, 1, 0, 0, 0 }, 6)]
        public void Test_FindMaxLengthBetter(int[] nums, int expected)
        {
            var actual = sut.FindMaxLengthBetter(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
        public void Test_ProductExceptSelf(int[] numbers, int[] expected)
        {
            var actual = sut.ProductExceptSelf(numbers);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("(*)", true)]
        [InlineData("(*))", true)]
        [InlineData("(*()", true)]
        [InlineData("(((******))", true)]
        [InlineData("(())((())()()(*)(*()(())())())()()((()())((()))(*", false)]

        public void Test_CheckValidString(string s, bool expected)
        {
            var actual = sut.CheckValidString(s);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_NumIslands( )
        {
            var matrix = new char[4][];
            matrix[0] = new char[] { '1', '1', '1', '1', '0' };
            matrix[1] = new char[] { '1', '1', '0', '1', '0' };
            matrix[2] = new char[] { '1', '1', '0', '0', '0' };
            matrix[3] = new char[] { '0', '0', '0', '0', '0' };
            var actual = sut.NumIslands(matrix);
            Assert.Equal(1, actual);
        }
       
        [Fact]
        public void Test_NumIslands2()
        {
            var matrix = new char[4][];
            matrix[0] = new char[] { '1', '1', '0', '0', '0' };
            matrix[1] = new char[] { '1', '1', '0', '0', '0' };
            matrix[2] = new char[] { '0', '0', '1', '0', '0' };
            matrix[3] = new char[] { '0', '0', '0', '1', '1' };
            var actual = sut.NumIslands(matrix);
            Assert.Equal(3, actual);
        }
        [Fact]
        public void Test_NumIslands3()
        {
            var matrix = new char[3][];
            matrix[0] = new char[] { '1', '1', '1' };
            matrix[1] = new char[] { '0', '1', '0'};
            matrix[2] = new char[] { '1', '1', '1' };
             var actual = sut.NumIslands(matrix);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void Test_MinPathSum()
        {
            var matrix = new int[3][];
            matrix[0] = new int[] { 1, 3, 1 };
            matrix[1] = new int[] { 1, 5, 1 };
            matrix[2] = new int[] { 4, 2,1 };
            var actual = sut.MinPathSum(matrix);
            Assert.Equal(7, actual);
        }

        [Fact]
        public void Test_MinPathSum2()
        {
            var matrix = new int[2][];
            matrix[0] = new int[] { 1, 2 };
            matrix[1] = new int[] { 1, 1 };
            
            var actual = sut.MinPathSum(matrix);
            Assert.Equal(3, actual);
        }

        [Fact]
        public void Test_MinPathSum3()
        {
            var matrix = new int[2][];
            matrix[0] = new int[] { 1, 2, 5 };
            matrix[1] = new int[] { 3,2, 1 };

            var actual = sut.MinPathSum(matrix);
            Assert.Equal(6, actual);
        }

        [Fact]
        public void Test_MinPathSum4()
        {
            var matrix = new int[1][];
            matrix[0] = new int[] { 9, 1, 4, 8 };

            var actual = sut.MinPathSum(matrix);
            Assert.Equal(22, actual);
        }

        [Fact]
        public void Test_MinPathSum5()
        {
            var matrix = new int[3][];
            matrix[0] = new int[] { 9};
            matrix[1] = new int[] { 2 };
            matrix[2] = new int[] { 4 };

            var actual = sut.MinPathSum(matrix);
            Assert.Equal(15, actual);
        }


    }
}
