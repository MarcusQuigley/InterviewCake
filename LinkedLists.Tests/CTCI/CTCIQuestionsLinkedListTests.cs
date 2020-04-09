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
        [InlineData(new int[] { 1, 2, 1 }, 2)]
        
        public void TestRemoveDuplicates(int[] values, int expected)
        {
            var head = new LLNode<int>(values[0]);
            var current = head;
            for (int i = 1; i < values.Length; i++)
            {
                //  while(current.next !=null)
                current.Next = new LLNode<int>(values[i]);
                current = current.Next;
            }
            sut.RemoveDuplicates(head);
            Assert.Equal(1,1);
        }
    }
}
