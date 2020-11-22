using System;
using Xunit;

namespace LeetStudy.Tests
{
    public class LeetStudyArraysTests
    {
        LeetStudyArrays sut;
        public LeetStudyArraysTests()
        {
            sut = new LeetStudyArrays();
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 1 }, 1)]
        public void Test_FindMaxConsecutiveOnes(int[] nums, int expected)
        {
            var actual = sut.FindMaxConsecutiveOnes(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 12 }, 1)]
        [InlineData(new int[] { 12, 345, 2, 6, 7896 }, 2)]
        [InlineData(new int[] { 555, 901, 482, 1771 }, 1)]
        public void Test_FindNumbers(int[] numbers, int expected)
        {
            Assert.Equal(expected, sut.FindNumbers(numbers));
        }

        [Theory]
        [InlineData(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
        [InlineData(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
        [InlineData(new int[] { -14, -11, 0, 1, 3, 11 }, new int[] { 0, 1, 9, 121, 121, 196 })]
        public void Test_SortedSquares(int[] nums, int[] expected)
        {
            var actual = sut.SortedSquares(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 2, 3, 0, 4, 5, 0 }, new int[] { 1, 0, 0, 2, 3, 0, 0, 4 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 2, 0, 3, 0, 7, 9, 8 }, new int[] { 1, 2, 0, 0, 3, 0, 0, 7 })]
        [InlineData(new int[] { 0 }, new int[] { 0 })]
 
        [InlineData(new int[] { 1, 1, 0, 0 }, new int[] { 1, 1, 0, 0 })]
        [InlineData(new int[] { 8, 4, 5, 0, 0, 0, 0, 7 }, new int[] { 8, 4, 5, 0, 0, 0, 0, 0 })]
        //[InlineData(new int[] { 9, 9, 9, 4, 8, 0, 0, 3, 7, 2, 0, 0, 0, 0, 9, 1, 0, 0, 1, 1, 0, 5, 6, 3, 1, 6, 0, 0, 2, 3, 4, 7, 0, 3, 9, 3, 6, 5, 8, 9, 1, 1, 3, 2, 0, 0, 7, 3, 3, 0, 5, 7, 0, 8, 1, 9, 6, 3, 0, 8, 8, 8, 8, 0, 0, 5, 0, 0, 0, 3, 7, 7, 7, 7, 5, 1, 0, 0, 8, 0, 0 },
        //    new int[] { 9, 9, 9, 4, 8, 0, 0, 0, 0, 3, 7, 2, 0, 0, 0, 0, 0, 0, 0, 0, 9, 1, 0, 0, 0, 0, 1, 1, 0, 0, 5, 6, 3, 1, 6, 0, 0, 0, 0, 2, 3, 4, 7, 0, 0, 3, 9, 3, 6, 5, 8, 9, 1, 1, 3, 2, 0, 0, 0, 0, 7, 3, 3, 0, 0, 5, 7, 0, 0, 8, 1, 9, 6, 3, 0, 0, 8, 8, 8, 8, 0 })]

        public void Test_DuplicateZeros(int[] nums, int[] expected)
        {
            sut.DuplicateZeros(nums);
            Assert.Equal(expected, nums);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
        [InlineData(new int[] { 1, 0 }, 1, new int[] { 1 }, 1, new int[] { 1, 1 })]
        [InlineData(new int[] { 0 }, 0, new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3, 0 }, 3, new int[] { 1 }, 1, new int[] { 1, 1, 2, 3 })]
        [InlineData(new int[] { 2, 0 }, 1, new int[] { 1 }, 1, new int[] { 1, 2 })]
        public void Test_Merge(int[] nums, int m, int[] nums2, int n, int[] expected)
        {
            sut.Merge(nums, m, nums2, n);
            Assert.Equal(expected, nums);
        }

        [Theory]
        //[InlineData(new int[] { 4, 4, 0, 1, 0, 2 }, 0, 4)]
        [InlineData(new int[] {3,2,2,3 }, 3,2)]
        public void Test_RemoveElement(int[] nums, int v,   int expected)
        {
          var actual=  sut.RemoveElement(nums,v);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(new int[] { 10,2,5,3},true)]
        [InlineData(new int[] { 7, 1, 14, 11 }, true)]
        [InlineData(new int[] { 3, 1, 7, 11 }, false)]
        public void Test_CheckIfExist(int[] nums, bool expected)
        {
            var actual = sut.CheckIfExist(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 2,1 ,4}, false)]
        [InlineData(new int[] { 3,5,5 }, false)]
        [InlineData(new int[] { 3, 5, 6 }, false)]
        [InlineData(new int[] { 0, 3, 2, 1 }, true)]
        [InlineData(new int[] {1,2,1,4 }, false)]
        [InlineData(new int[] { 1 }, false)]
        [InlineData(new int[] { 0, 2,3,4,5,2,1,0 }, true)]
        [InlineData(new int[] { 0, 2, 3, 3, 5, 2, 1, 0 }, false)]
        public void Test_ValidMountainArray(int[] nums, bool expected)
        {
            var actual = sut.ValidMountainArray(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 17, 18, 5, 4, 6, 1 }, new int[] { 18, 6, 6, 6, 1, -1 })]
        public void Test_ReplaceElements(int[] nums, int[] expected)
        {
            var actual = sut.ReplaceElements(nums);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(new int[] {1,1,2 }, new int[] { 1,2,2 })]
        public void Test_RemoveDuplicates(int[] nums, int[] expected)
        {
            var actual = sut.RemoveDuplicates(nums);
            Assert.Equal(expected, nums);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, new int[] { 1, 2, 2 })]
        public void Test_RemoveDuplicatesBad(int[] nums, int[] expected)
        {
            var actual = sut.RemoveDuplicatesBad(nums);
            Assert.Equal(expected, nums);
        }
    }
}
