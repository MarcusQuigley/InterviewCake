using Recursion.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Recursion.Tests.LeetCode
{
    public class RecursionOneTests
    {
        RecursionOne sut;

        public RecursionOneTests()
        {
            sut = new RecursionOne();
        }

        [Theory]
        [InlineData("abc", "cba")]
        [InlineData("ab", "ba")]
        [InlineData("hello", "olleh")]
        public void Test_ReverseString(string s1, string expected)
        {
            var s1chararray = s1.ToCharArray();
            sut.ReverseString(s1chararray);
            var actual = new string(s1chararray);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3, 4}, new int[] {2,1,4,3 })]
        
        public void Test_SwapPairs(int[] startArray, int[] expected)
        {
            ListNode head = CreateLinkedListFromArray(startArray);
           var temp =  sut.SwapPairs(head);
            var actual = CreateArrayFromLinkedList(temp);
            Assert.Equal(expected, actual);
        }

        ListNode CreateLinkedListFromArray(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0)
                return null;
            ListNode head = null;

            for (int i = 0; i < arr.Length; i++)
            {
                head = Insert(head, arr[i]);
             }
            return head;
        }
        ListNode Insert(ListNode head, int item) {
            ListNode temp = new ListNode(item);
            temp.next = null;

            if (head == null)
                head = temp;
            else
            {
                ListNode ptr= head;
                while(ptr.next != null)
                {
                    ptr = ptr.next;
                }
                ptr.next = temp;
            }
            return head;
        }

        int[] CreateArrayFromLinkedList(ListNode node) {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            List<int> list = new List<int>();
            while (node != null)
            {
                list.Add(node.val);
                node = node.next;
            }

            return list.ToArray();
        }

    }
}
