using System;
using Xunit;

namespace LinkedLists.Tests
{
    public class DoubleLinkedListTests
    {
        readonly DoubleLinkedList<int> sut = null;
        public DoubleLinkedListTests()
        {
            sut = new DoubleLinkedList<int>();
        }
        [Fact]
        public void CanAdd()
        {
            sut.Add(1);
            sut.Add(2);
            Assert.True(sut.Count == 2);
        }

        [Fact]
        public void CanAddToHead()
        {
            sut.AddFirst(1);
            sut.AddFirst(23);
            sut.AddFirst(2);
            var enumerator =  sut.GetEnumerator();
            enumerator.MoveNext();
            Assert.True(enumerator.Current == 2);
            enumerator.MoveNext();
            Assert.True(enumerator.Current == 23);
        }

        [Fact]
        public void CanAddToTail()
        {
            sut.Add(1);
            sut.Add(23);
            sut.Add(2);
            var enumerator = sut.GetEnumerator();
            var current = enumerator.Current;
            while (enumerator.MoveNext())
            {
                current = enumerator.Current;
            }
  

            Assert.True(enumerator.Current == 2);
            
        }


        [Fact]
        public void ContainWorks()
        {
            sut.Add(1);
            sut.Add(2);
            var actual = sut.Contains(2);
            Assert.True(actual);
        }

        [Fact]
        public void ClearWorks()
        {
            sut.Add(1);
            sut.Add(2);
            sut.Clear();
            Assert.True(sut.Count == 0);
        }

        [Fact]
        public void CanRemoveExistingElement()
        {
            sut.Add(1);
            sut.Add(2);
            var actual = sut.Remove(2);
            Assert.True(actual);
        }

        [Fact]
        public void CannotRemoveNonExistingElement()
        {
            sut.Add(1);
            sut.Add(2);
            var actual = sut.Remove(24);
            Assert.False(actual);
        }
    }
}
