
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FBQuestions.Tests
{
    public class LeetFBQuestionsArraysTests
    {
        readonly LeetFBQuestionsArrays sut = null;
        public LeetFBQuestionsArraysTests()
        {
            sut = new LeetFBQuestionsArrays();
        }

        [Theory]
        [InlineData(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz",true)]
        [InlineData(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
        [InlineData(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
        public void Test_IsAlienSorted(string[] words, string order, bool expected)
        {
            var actual = sut.IsAlienSorted(words, order);
            Assert.Equal(expected, actual);
        }


        [Fact]
        //[InlineData(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz", true)]
        public void Test_IntervalIntersection()//int[][] A, int[][] B, int[][] expected)
        {
            var A = new int[4][];
            A[0] = new int[] { 0, 2 };
            A[1] = new int[] { 5,10 };
            A[2] = new int[] { 13,23 };
            A[3] = new int[] { 24,25 };

            var B = new int[4][];
            B[0] = new int[] { 1,5 };
            B[1] = new int[] { 8, 12 };
            B[2] = new int[] { 15, 24 };
            B[3] = new int[] { 25,26 };

            var expected = new int[6][];
            expected[0] = new int[] { 1, 2 };
            expected[1] = new int[] { 5,5};
            expected[2] = new int[] { 8,10 };
            expected[3] = new int[] { 15,23 };
            expected[4] = new int[] { 24,24 };
            expected[5] = new int[] { 25, 25 };

            var actual = sut.IntervalIntersection(A, B);
            Assert.Equal(expected, actual);
        }
    }
}
