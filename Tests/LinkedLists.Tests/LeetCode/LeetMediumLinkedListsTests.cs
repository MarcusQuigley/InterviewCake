using LinkedLists.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedLists.Tests.LeetCode
{
    public class LeetMediumLinkedListsTests
    {
        readonly LeetMediumLinkedList sut = null;
        public LeetMediumLinkedListsTests()
        {
            sut = new LeetMediumLinkedList();
        }

        [Fact]
        public void Test_DetectCycle()
        {
            ListNode node = new ListNode(1);
            node.next = node;
            var actual = sut.DetectCycle(node);
            Assert.Equal(node, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        public void Test_DetectCycle2(int[] values, int expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);
            var node1 = node.next.next;
            var node2 = node.next.next.next.next;
            node2.next = node1;
            var actual = sut.DetectCycle(node);
            Assert.Equal(expected, actual.val);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2)]
        public void Test_DetectCycle3(int[] values, int expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);
            var node1 = node.next;
            var node2 = node.next.next.next.next;
            node2.next = node1;
            var actual = sut.DetectCycle(node);
            Assert.Equal(expected, actual.val);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2)]
        public void Test_DetectCycle4(int[] values, int expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);
            var node1 = node.next;
            var node2 = node;
            while (node2.next != null)
                node2 = node2.next;
            node2.next = node1;
            var actual = sut.DetectCycle(node);
            Assert.Equal(expected, actual.val);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 5 })]
        [InlineData(new int[] { 1 }, 1, new int[] { })]
        [InlineData(new int[] { 1, 2 }, 2, new int[] { 2 })]
        [InlineData(new int[] { 1, 2, 3 }, 1, new int[] { 1, 2 })]

        public void Test_RemoveNthFromEnd(int[] values, int n, int[] expected)
        {
            ListNode node = LinkedListHelper.CreateLinkedList(values);

            var actual = sut.RemoveNthFromEnd(node, n);
            Assert.Equal(expected, LinkedListHelper.ListFromListNode(actual));
        }
    }
}
