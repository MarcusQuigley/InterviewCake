
using AmazonQuestions.Study;
using AmazonQuestions.Tests.Helpers;
using DataStructures;
using System;
using Xunit;

namespace AmazonQuestions.Tests
{
    public class AmazonLinkedListsTests
    {
        readonly AmazonLinkedLists sut;
        public AmazonLinkedListsTests()
        {
            sut = new AmazonLinkedLists();
        }
        [Theory]
        [InlineData(new int[] { 2, 4,3 }, new int[] { 5,6,4}, new int[] {7,0,8 })]
        [InlineData(new int[] {9 }, new int[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,1 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 })]
       
        public void Test_TwoSum(int[] l1, int[] l2, int[] expected)
        {
            var l1List = LinkedListHelper.CreateLinkedList(l1);
            var l2List = LinkedListHelper.CreateLinkedList(l2);
            var actual = sut.AddTwoNumbers(l1List, l2List);
            Assert.Equal(expected, LinkedListHelper.ListFromListNode(actual));
        }

         
    }
}
