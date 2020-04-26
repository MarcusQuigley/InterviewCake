using LinkedLists.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedLists.Tests.LeetCode
{
public class LeetEasyQuestionsLinkedListTests
    {
        readonly LeetEasyQuestionsLinkedList sut = null;
        public LeetEasyQuestionsLinkedListTests()
        {
            sut = new LeetEasyQuestionsLinkedList();
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 1 },5)]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 }, 18880)]
        [InlineData(new int[] { 0, 0 }, 0)]
        public void TestGetDecimalValue(int[] values, int expected)
        {
           var head =  CreateLinkedList(values);
            var actual = sut.GetDecimalValue(head);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(new int[] { 1, 2,3,4,5 }, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 5,6 }, 4)]
        [InlineData(new int[] { 1, 2}, 2)]
        [InlineData(new int[] { 1}, 1)]
        public void TestMiddleNode(int[] values, int expected)
        {
            var head = CreateLinkedList(values);
            var actual = sut.MiddleNode(head);
            Assert.Equal(expected, actual.val);
        }

        private ListNode CreateLinkedList(int[] values)
        {
            var head = new ListNode(values[0]);
            var current = head;
            for (int i = 1; i < values.Length; i++)
            {
                //  while(current.next !=null)
                current.next = new ListNode(values[i]);
                current = current.next;
            }
            return head;
        }
    }
}
