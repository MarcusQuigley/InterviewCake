using System;
using Xunit;

namespace DataStructures.Tests
{
    public class TrieTests
    {
        Trie  sut = null;
        public TrieTests()
        {
            sut = new Trie();
        }

        [Fact]
        public void Test_Trie()
        {
             sut.Insert("apple");
            Assert.True(sut.Search("apple"));
            Assert.False(sut.Search("app"));
            Assert.True(sut.StartsWith("app"));
            sut.Insert("app");
            Assert.True(sut.Search("app"));
        }
    }
}
