using DataStructures;
using LinkedLists.Tests;
using System;
using Xunit;

namespace LeetStudy.Tests
{
    public class LeetStudyLinkedListTests
    {
        LeetStudyLinkedLists sut;
        public LeetStudyLinkedListTests()
        {
            sut = new LeetStudyLinkedLists();
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
        [InlineData(new int[] { 4, 1, 8, 4, 5 }, new int[] { 5, 0, 1 }, 8)]
        public void Test_GetIntersectionNode(int[] values, int[] values2, int expected)
        {
            ListNode nodeA = LinkedListHelper.CreateLinkedList(values);
            ListNode nodeB = LinkedListHelper.CreateLinkedList(values2);
            nodeB.next.next.next = nodeA.next.next;

            var actual = sut.GetIntersectionNode(nodeA, nodeB);
            Assert.Equal(expected, actual.val);
        }

        [Theory]
        [InlineData(new int[] { 1,2,6,3,4,5,6 }, 6, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 1 }, 1, new int[] {  })]
        [InlineData(new int[] { 1 ,2,2,1}, 2, new int[] {1,1 })]
        public void Test_RemoveElements(int[] values, int val, int[] expected)
        {
            ListNode nodeA = LinkedListHelper.CreateLinkedList(values);
             var actual = sut.RemoveElements(nodeA, val);
            Assert.Equal(expected, LinkedListHelper.ListFromListNode(actual));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 3, 5, 2, 4 })]
        //[InlineData(new int[] {  2,1,3,5,6,4,7}, new int[] { 2, 3,6,7,1, 5,4 })]
        //[InlineData(new int[] { 1 },  new int[] {1 })]
        //[InlineData(new int[] { 1, 2 }, new int[] { 1,2 })]
        public void Test_OddEvenList(int[] values, int[] expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);

            var actual = sut.OddEvenList(node);
            Assert.Equal(expected, LinkedListHelper.ListFromListNode(actual));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 2,1 }, true)]
        [InlineData(new int[] { 1, 2,   2, 1 }, true)]
        [InlineData(new int[] { 1, 2 }, false)]
        [InlineData(new int[] { 1}, true)]
     //   [InlineData(new int[] {  }, false)]
        public void Test_IsPalindrome(int[] values, bool expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);

            var actual = sut.IsPalindrome(node);
            Assert.Equal(expected, actual);
        }
        
    }
}
