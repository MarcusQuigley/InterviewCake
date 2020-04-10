using LinkedLists.CTCI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedLists.Tests.CTCI
{
    public class CTCIQuestionsLinkedListTests
    {
        CTCIQuestionsLinkedList<int> sut = null;
        public CTCIQuestionsLinkedListTests()
        {
            sut = new CTCIQuestionsLinkedList<int>();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 1 })]
        
        public void TestRemoveDuplicatesWithQueue(int[] values)
        {
            var head = new CTCI_LLNode<int>(values[0]);
            var current = head;
            for (int i = 1; i < values.Length; i++)
            {
                 current.Next = new CTCI_LLNode<int>(values[i]);
                current.Next.Previous = current;
                current = current.Next;
            }
            sut.RemoveDuplicatesWithQueue(head);
            Assert.Equal(1, 1);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 1 })]

        public void TestRemoveDuplicates(int[] values)
        {
            var head = new CTCI_LLNode<int>(values[0]);
            var current = head;
            for (int i = 1; i < values.Length; i++)
            {
                 current.Next = new CTCI_LLNode<int>(values[i]);
                current.Next.Previous = current;
                current = current.Next;
            }
            sut.RemoveDuplicates(head);
            Assert.Equal(1, 1);
        }
    }
}
