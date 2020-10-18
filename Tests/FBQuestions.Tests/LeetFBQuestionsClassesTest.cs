using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FBQuestions.Tests
{
    public class LeetFBQuestionsClassesTest
    {
        readonly LeetFBQuestionsClasses sut = null;
        public LeetFBQuestionsClassesTest()
        {
              sut = new LeetFBQuestionsClasses();
        }

        [Theory]
        [InlineData("abc", 4,3)]
        [InlineData("abcde", 5,5)]
        [InlineData("abcdABCD1234", 12,12)]

        public void Test_Read(string  words, int n, int expected)
        {
              char[] buf = new char[n];
            var actual = sut.Read(buf,n,words);
            Assert.Equal(expected, actual);
        }
    }
}
