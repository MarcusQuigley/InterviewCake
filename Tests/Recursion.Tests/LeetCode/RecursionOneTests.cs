using Recursion.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Recursion.Tests.LeetCode
{
  public  class RecursionOneTests
    {
        RecursionOne sut;

        public RecursionOneTests()
        {
            sut = new RecursionOne();
        }

        [Theory]
        [InlineData("abc","cba")]
        [InlineData("ab", "ba")]
        [InlineData("hello", "olleh")]
        public void Test_ReverseString(string s1, string expected)
        {
            var s1chararray = s1.ToCharArray();
             sut.ReverseString(s1chararray);
            var actual = new string(s1chararray);
            Assert.Equal(expected, actual);
        }
    }
}
