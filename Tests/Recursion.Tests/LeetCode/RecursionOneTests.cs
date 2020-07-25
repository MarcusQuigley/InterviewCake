using Recursion.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Recursion.Tests.LeetCode
{
    public class RecursionOneTests
    {
        readonly RecursionOne sut;

        public RecursionOneTests()
        {
            sut = new RecursionOne();
        }

        [Theory]
        [InlineData("a", "a")]
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
        [InlineData("a", "a")]
        [InlineData("abc", "cba")]
        [InlineData("ab", "ba")]
        [InlineData("hello", "olleh")]
        public void Test_ReverseStringNew(string s1, string expected)
        {
            var actual = sut.NewReverseString(s1);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 2, 1, 4, 3 })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]

        public void Test_SwapPairs(int[] startArray, int[] expected)
        {
            ListNode head = CreateLinkedListFromArray(startArray);
            var temp = sut.SwapPairs(head);
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
        ListNode Insert(ListNode head, int item)
        {
            ListNode temp = new ListNode(item);
            temp.next = null;

            if (head == null)
                head = temp;
            else
            {
                ListNode ptr = head;
                while (ptr.next != null)
                {
                    ptr = ptr.next;
                }
                ptr.next = temp;
            }
            return head;
        }

        int[] CreateArrayFromLinkedList(ListNode node)
        {
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



        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 2, new int[] { 2, 1, 3 })]
        //  [InlineData(new int[] { 1 }, 2, new int[] { 1 })]

        public void Test_SearchBST(int[] startArray, int val, int[] expected)
        {
            TreeNode head = CreateTree(startArray);
            var result = sut.SearchBST(head, val);
            var actual = CreateArrayFromTree(result, expected.Length);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 4, 2, 7, 1, 3 }, 2, new int[] { 2, 1, 3 })]
        public void Test_SearchBSTRecursively(int[] startArray, int val, int[] expected)
        {
            TreeNode head = CreateTree(startArray);
            var result = sut.SearchBSTRecursively(head, val);
            var actual = CreateArrayFromTree(result, expected.Length);
            Assert.Equal(expected, actual);
        }

        private TreeNode CreateTree(int[] startArray)
        {
            if (startArray == null) return null;

            return CreateTree(startArray, null, 0);
        }

        TreeNode CreateTree(int[] startArray, TreeNode node, int index)
        {
            if (index < startArray.Length)
            {
                node = new TreeNode(startArray[index]);
                node.left = CreateTree(startArray, node.left, (2 * index) + 1);
                node.right = CreateTree(startArray, node.right, (2 * index) + 2);
            }
            return node;
        }

        int[] CreateArrayFromTree(TreeNode head, int count)
        {
            int[] array = new int[count];
            int index = 0;
            var q = new Queue<TreeNode>();
            q.Enqueue(head);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node != null)
                {
                    array[index++] = node.val;
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }

            }
            return array;
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4, 3, false)]
        [InlineData(new int[] { 1, 2, 3, -666, 4, -666, 5 }, 4, 5, true)]
        [InlineData(new int[] { 1, 2, 3, -666, 4 }, 2, 3, false)]

        public void Test_IsCousins(int[] startArray, int x, int y, bool expected)
        {
            TreeNode head = CreateTree(startArray);
            var actual = sut.IsCousins(head, x, y);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]//2, 1, 4, 3 }
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 2, 1 })]

        public void Test_ReverseList(int[] startArray, int[] expected)
        {
            ListNode head = CreateLinkedListFromArray(startArray);
            var temp = sut.ReverseList(head);
            var actual = CreateArrayFromLinkedList(temp);
            Assert.Equal(expected, actual);
        }
    }
}
