using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Tests.LeetCode
{
    public abstract  class BaseTreeTests
    {
        public TreeNode<int> CreatTreeNodes(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            TreeNode<int> root = new TreeNode<int>(values[0]);
            root = InOrder(values, root, 0);
            return root;
        }

        TreeNode<int> InOrder(int[] arr,
                            TreeNode<int> root, int i)
        {
            // Base case for recursion 
            if (i < arr.Length)
            {
                if (arr[i] != -666){
                    TreeNode<int> temp = new TreeNode<int>(arr[i]);
                    root = temp;

                    // insert left child 
                    root.left = InOrder(arr,
                                    root.left, 2 * i + 1);

                    // insert right child 
                    root.right = InOrder(arr,
                                    root.right, 2 * i + 2);
                }
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
                node.left = new TreeNode<int>(arr[i++]);
                node.right = new TreeNode<int>(arr[i++]);
            }
            return root;
        }
    }
}
