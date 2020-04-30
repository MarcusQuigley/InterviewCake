﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetMediumTrees
    {
        //Leet 1008 https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/
        //bst
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder == null)
                throw new ArgumentNullException(nameof(preorder));
            var n = preorder.Length ;
            TreeNode root = new TreeNode(preorder[0]);
            for (int i = 1; i < n; i++)
            {
                var val = preorder[i];
                TreeNode parent = null;
                var node = root;
                while (node != null)
                {
                    parent = node;
                    if (val < node.val)
                        node = node.left;
                    else
                        node = node.right;
                }
                if (val < parent.val)
                    parent.left = new TreeNode(val);
                else
                    parent.right = new TreeNode(val);
            }

            return root;
        }

        //https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/532/week-5/3315/
        //DFS
        public bool IsValidSequence(TreeNode<int> root, int[] arr)
        {
            if (root == null || arr == null)
                throw new ArgumentNullException("Somethings null");
            Queue<int> q = new Queue<int>();
            var currindex = 0;
            q.Enqueue(root.val)
            if (arr[currindex] == root.val)
            {
                var current = root;
                while (current != null)
                {
                    if (arr[currindex] == current.val)
                    {
                        currindex += 1;
                        if (currindex == arr.Length)// && (current.left != null || (current.right != null)))                        
                            return true;
                        if (current.left != null && current.left.val == arr[currindex])
                            current = current.left;
                        else if (current.right != null && current.right.val == arr[currindex])
                            current = current.right;
                        else
                            break;
                    }
                  
                }
            }
            //return DFSValidSequence(root, arr, currindex);
           return false;
        }

        bool DFSValidSequence(TreeNode<int> current, int[] arr, int currindex)
        {
            if (current != null)
            {
                if (arr[currindex++] == current.val)
                {
                    if (currindex == arr.Length)
                        return true;
                    DFSValidSequence(current.left, arr, currindex);
                    DFSValidSequence(current.right, arr, currindex);
                }
            }
            return false;
        }
    }
}
