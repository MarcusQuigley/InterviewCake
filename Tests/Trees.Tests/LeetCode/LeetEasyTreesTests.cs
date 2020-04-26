using System;
using System.Collections.Generic;
using System.Text;
using Trees.LeetCode;
using Xunit;

namespace Trees.Tests.LeetCode
{
    public class LeetEasyTreesTests
    {
        readonly LeetEasyTrees<int> sut = null;
        public LeetEasyTreesTests()
        {
            sut = new LeetEasyTrees<int>();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        //[InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        public void TestMiddleNode(int[] values, int expected)
        {
             var head = CreatTreeNodes(values);
            var actual = sut.DiameterOfBinaryTree(head);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(new int[] { 2, 7, 4, 1, 8, 1 }, 1)]
        public void TestLastStoneWeight(int[] values, int expected)
        {
            var actual = sut.LastStoneWeight(values);
            Assert.Equal(expected, actual);
        }



        private TreeNode<int> CreatTreeNodes(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            TreeNode<int> root = new TreeNode<int>(values[0]);
            root= InOrder(values, root, 0);
            return root;
        }

        TreeNode<int> InOrder(int[] arr,
                            TreeNode<int> root, int i)
        {
            // Base case for recursion 
            if (i < arr.Length)
            {
                TreeNode<int> temp = new TreeNode<int>(arr[i]);
                root = temp;

                // insert left child 
                root.Left = InOrder(arr,
                                root.Left, 2 * i + 1);

                // insert right child 
                root.Right = InOrder(arr,
                                root.Right, 2 * i + 2);
            }
            return root;
        }

        TreeNode<int> OutOrder(int[] arr)
        {
            TreeNode<int> root = new TreeNode<int>(arr[0]); 
            int i = 1;
            while (i < arr.Length)
            {
                var node = new TreeNode<int>(arr[i++]);
                node.Left = new TreeNode<int>(arr[i++]);
                node.Right = new TreeNode<int>(arr[i++]);
            }
            return root;
        }
    }
}
