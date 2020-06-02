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
        //public void Test_GetIntersectionNode(int[] values, int[] values2, int expected)
        //{
        //    ListNode nodeA = LinkedListHelper.CreateLinkedList(values);
        //    ListNode nodeB = LinkedListHelper.CreateLinkedList(values2);
        //    nodeB.next.next.next = nodeA.next.next;

        //    var actual = sut.GetIntersectionNode(nodeA, nodeB);
        //    Assert.Equal(expected, actual.val);
        //}
    }
}
