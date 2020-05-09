using LinkedLists.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedLists.Tests.LeetCode
{
public class LeetEasyQuestionsLinkedListTests
    {
        readonly LeetEasyLinkedList sut = null;
        public LeetEasyQuestionsLinkedListTests()
        {
            sut = new LeetEasyLinkedList();
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 1 },5)]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 }, 18880)]
        [InlineData(new int[] { 0, 0 }, 0)]
        public void TestGetDecimalValue(int[] values, int expected)
        {
           var head = LinkedListHelper.CreateLinkedList(values);
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
            var head = LinkedListHelper.CreateLinkedList(values);
            var actual = sut.MiddleNode(head);
            Assert.Equal(expected, actual.val);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, true)]
        public void Test_HasCycle(int[] values, bool expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);
            var node1 = node.next.next;
            var node2 = node.next.next.next.next;
            node2.next = node1;
            node.next = node;
            var actual = sut.HasCycle(node);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, false)]
        public void Test_HasCycle2(int[] values, bool expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);
          
            var actual = sut.HasCycle(node);
            Assert.Equal(expected, actual);
        }

    }
}
