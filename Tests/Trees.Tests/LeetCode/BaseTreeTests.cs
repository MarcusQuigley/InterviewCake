using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Trees.Tests.LeetCode
{
    public abstract class BaseTreeTests
    {
        public TreeNode<int> CreatTreeNodes(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            TreeNode<int> root = new TreeNode<int>(values[0]);
            root = InOrder(values, root, 0);
            return root;
        }

        public TreeNode CreatTreeNodesNonGeneric(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            TreeNode root = new TreeNode(values[0]);
            root = InOrderNonGeneric(values, root, 0);
            return root;
        }

        TreeNode<int> InOrder(int[] arr,
                            TreeNode<int> root, int i)
        {
            if (i < arr.Length)
            {
                if (arr[i] != -666)
                {
                    TreeNode<int> temp = new TreeNode<int>(arr[i]);
                    root = temp;
                    root.left = InOrder(arr, root.left, 2 * i + 1);
                    root.right = InOrder(arr, root.right, 2 * i + 2);
                }
            }
            return root;
        }

        TreeNode InOrderNonGeneric(int[] arr,
                           TreeNode root, int i)
        {
            if (i < arr.Length)
            {
                if (arr[i] != -666)
                {
                    TreeNode temp = new TreeNode(arr[i]);
                    root = temp;
                    root.left = InOrderNonGeneric(arr, root.left, 2 * i + 1);
                    root.right = InOrderNonGeneric(arr, root.right, 2 * i + 2);
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

        public int[] ArrayFromTree(TreeNode node)
        {
            List<int> list = new List<int>();
            var q = new Queue<TreeNode>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current != null)
                {
                    list.Add(current.val);
                    //if (current.left != null) q.Enqueue(current.left);
                    // if (current.right != null) q.Enqueue(current.right);
                    q.Enqueue(current.left);
                    q.Enqueue(current.right);
                }
                else
                    list.Add(-666); //simple hack to define nulls in int[]
            }
            return list.Take(list.LastIndexOf(list.Last(n=>n!=-666))+1) //strips end elements that are -666
                       .ToArray();
        }
    }
}
