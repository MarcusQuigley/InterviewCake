using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetMediumTrees
    {
        //Leet 1008 https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/
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
    }
}
