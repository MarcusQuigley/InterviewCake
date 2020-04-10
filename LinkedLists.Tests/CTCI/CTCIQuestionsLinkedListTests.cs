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

        [Theory]
        [InlineData(new int[] { 1, 2, 1,5,4,2,6 },3,4)]
         public void Test_ReturnKthToLast(int[] values, int k, int expected)
        {
            var head = new LLNode<int>(values[0]);
            var current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.Next = new LLNode<int>(values[i]);
                 current = current.Next;
            }
            var actual = sut.ReturnKthToLast(head, k);
            Assert.Equal(expected,actual.Value);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 1, 5, 4, 2, 6 }, 3, 4)]
        public void Test_ReturnKthToLastBetter(int[] values, int k, int expected)
        {
            var head = new LLNode<int>(values[0]);
            var current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.Next = new LLNode<int>(values[i]);
                current = current.Next;
            }
            var actual = sut.ReturnKthToLastBetter(head, k);
            Assert.Equal(expected, actual.Value);
        }
    }
}
