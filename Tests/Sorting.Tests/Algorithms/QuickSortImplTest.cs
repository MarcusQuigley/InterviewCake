using Sorting.Algorithms;
using System;
using Xunit;

namespace Sorting.Tests.Algorithms
{
    public class QuickSortImplTest
    {
        QuickSortImpl sut = null;

        public QuickSortImplTest()
        {
            sut = new QuickSortImpl();
        }

        [Theory]
        [InlineData(new int[] { 3,2,5,4,1,8,16,6}, new int[] { 1,2,3,4,5,6,8,16})]
        public void Test_QuickSort(int[] array, int[] expected)
        {
            sut.QuickSort(array);
            Assert.Equal(array, expected);
        }
    }
}
