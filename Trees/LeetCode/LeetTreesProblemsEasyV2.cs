using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetTreesProblemsEasyV2
    {
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return 0;
            var sum = (root.val >= L && root.val <= R) ? root.val : 0;
            var left = (root.val >= L) ? RangeSumBST(root.left, L, R) : 0;
            var right = (root.val <= R) ? RangeSumBST(root.right, L, R) : 0;

            return left + right + sum;
        }

        public int RangeSumBSTIter(TreeNode root, int L, int R)
        {
            if (root == null) return 0;
            var sum = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node.val >= L && node.val <= R)
                    sum += node.val;
                if (node.val >= L && node.left != null) stack.Push(node.left);
                if (node.val <= R && node.right != null) stack.Push(node.right);
            }
            return sum;
        }

        public IList<int> GetLonelyNodes(TreeNode root)
        {
            var results = new List<int>();
            GetLonelyNodesWorkerCleaner(root, false, results);
            return results;
        }

        void GetLonelyNodesWorkerCleaner(TreeNode node, bool isLonely, IList<int> list)
        {
            if (node == null)
                return;
            if (isLonely)
                list.Add(node.val);
            GetLonelyNodesWorkerCleaner(node.left, node.right == null, list);
            GetLonelyNodesWorkerCleaner(node.right, node.left == null, list);
        }

        void GetLonelyNodesWorker(TreeNode node, IList<int> list)
        {
            if (node == null)
                return;
            if (node.left == null && node.right == null)
                return;
            if (node.left == null && node.right != null)
            {
                list.Add(node.right.val);
                GetLonelyNodesWorker(node.right, list);
            }
            else if (node.right == null && node.left != null)
            {
                list.Add(node.left.val);
                GetLonelyNodesWorker(node.left, list);
            }
            else
            {
                GetLonelyNodesWorker(node.left, list);
                GetLonelyNodesWorker(node.right, list);
            }
        }

        public IList<int> GetLonelyNodesIter(TreeNode root)
        {
            var results = new List<int>();
            if (root != null)
            {
                var stack = new Stack<TreeNode>();
                stack.Push(root);
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    if (node.left == null)
                    {
                        if (node.right != null)
                        {
                            results.Add(node.right.val);
                            stack.Push(node.right);
                        }
                    }
                    else if (node.right == null)
                    {
                        if (node.left != null)
                        {
                            results.Add(node.left.val);
                            stack.Push(node.left);
                        }
                    }
                    else
                    {
                        stack.Push(node.right);
                        stack.Push(node.left);
                    }

                }
            }
            return results;
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            t1.val += t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);
            return t1;
        }

        public TreeNode MergeTreesIter(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;

            Stack<TreeNode[]> stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { t1, t2 });
            while (stack.Count > 0)
            {
                var nodes = stack.Pop();
                if (nodes[0] == null || nodes[1] == null)
                    continue;
                nodes[0].val += nodes[1].val;
                if (nodes[0].left == null)
                    nodes[0].left = nodes[1].left;
                else
                    stack.Push(new TreeNode[] { nodes[0].left, nodes[1].left });
                if (nodes[0].right == null)
                    nodes[0].right = nodes[1].right;
                else
                    stack.Push(new TreeNode[] { nodes[0].right, nodes[1].right });
            }
            return t1;
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
                return root;
            return (val > root.val) ? SearchBST(root.right, val) : SearchBST(root.left, val);
        }

        public TreeNode SearchBSTIter(TreeNode root, int val)
        {
            if (root == null)
                return null;
            while (root != null)
            {
                if (root.val == val)
                    return root;
                root = (val > root.val) ? root.right : root.left;
            }
            return root;
        }

        public IList<int> NaryPostorder(NaryNode root)
        {
            var results = new List<int>();
            NaryPostorderWorker(root, results);
            return results;
        }

        void NaryPostorderWorker(NaryNode node, IList<int> results)
        {
            if (node == null)
                return;
            var children = node.children;
            for (int i = 0; i < children.Count; i++)
                NaryPostorderWorker(children[i], results);
            results.Add(node.val);
            return;
        }

        public IList<int> NaryPostorderIter(NaryNode root)
        {
            var results = new List<int>();
            if (root == null)
                return results;
            Stack<NaryNode> stackLeft = new Stack<NaryNode>();
            Stack<int> stackRight = new Stack<int>();
            stackLeft.Push(root);
            while (stackLeft.Count > 0)
            {
                var current = stackLeft.Pop();
                foreach (var item in current.children)
                {
                    stackLeft.Push(item);
                }
                stackRight.Push(current.val);
            }
            while (stackRight.Count > 0)
                results.Add(stackRight.Pop());
            return results;
        }

        public IList<int> NaryPreorder(NaryNode root)
        {
            var results = new List<int>();
            NaryPreorderWorker(root, results);
            return results;
        }

        void NaryPreorderWorker(NaryNode node, IList<int> results)
        {
            if (node == null)
                return;
            results.Add(node.val);
            foreach (var item in node.children)
                NaryPreorderWorker(item, results);
            return;
        }

        public IList<int> NaryPreorderIter(NaryNode root)
        {
            var results = new List<int>();
            if (root == null)
                return results;
            Stack<NaryNode> stack = new Stack<NaryNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                results.Add(node.val);
                if (node.children == null)
                    continue;
                for (int i = node.children.Count - 1; i >= 0; i--)
                    stack.Push(node.children[i]);
            }
            return results;
        }


        public TreeNode IncreasingBST(TreeNode root)
        {
            List<int> list = new List<int>();
            IncreasingBSTWorker(root, list);
            TreeNode result = null;
            TreeNode temp = null;
            if (list.Count > 0)
            {
                temp = new TreeNode(0);
                result = temp;
                for (int i = 0; i < list.Count; i++)
                {
                    temp.right = new TreeNode(list[i]);
                    temp = temp.right;
                }
            }
            return result.right;
        }

        void IncreasingBSTWorker(TreeNode root, List<int> list)
        {
            if (root == null)
                return;
            IncreasingBSTWorker(root.left, list);
            list.Add(root.val);
            IncreasingBSTWorker(root.right, list);
            return;
        }

        public TreeNode IncreasingBSTIter(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode result = new TreeNode(-1);
            TreeNode temp = result;
            var current = root;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();

                temp.right = new TreeNode(current.val);
                temp = temp.right;
                current = current.right;
            }
            return result.right;
        }

        public TreeNode IncreasingBSTIterBetter(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode result = new TreeNode(-1);
            TreeNode temp = result;
            var current = root;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                current.left = null;
                temp.right = current;
                temp = temp.right;
                current = current.right;
            }
            return result.right;
        }

        public int SumRootToLeafIter(TreeNode root)
        {
            int sum = 0;
            Stack<ItemSumRootToLeaf> stack = new Stack<ItemSumRootToLeaf>();
            stack.Push(new ItemSumRootToLeaf(root, 0));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                var node = current.Node;
                var value = current.Value;

                if (node != null)
                {
                    value = (value << 1) | node.val;
                    if (node.left == null && node.right == null)
                    {
                        sum += value;
                    }
                    else
                    {
                        stack.Push(new ItemSumRootToLeaf(node.right, value));
                        stack.Push(new ItemSumRootToLeaf(node.left, value));
                    }
                }
            }

            return sum;
        }
        private class ItemSumRootToLeaf
        {
            public TreeNode Node { get; }
            public int Value { get; set; }

            public ItemSumRootToLeaf(TreeNode node)
            {
                Node = node;
            }
            public ItemSumRootToLeaf(TreeNode node, int val) : this(node)
            {
                Value = val;
            }
        }

        int ItemSumRootToLeafsum = 0;
        public int SumRootToLeaf(TreeNode root)
        {
            if (root != null)
                SumRootToLeafWorker(root);
            return ItemSumRootToLeafsum;
        }

        void SumRootToLeafWorker(TreeNode root)
        {
            if (root.left == null && root.right == null)
                ItemSumRootToLeafsum += root.val;
            else
            {
                if (root.left != null)
                {
                    root.left.val += root.val << 1;
                    //root.left.val += root.val * 2; 
                    SumRootToLeafWorker(root.left);
                }
                if (root.right != null)
                {
                    root.right.val += root.val << 1;
                    //root.right.val += root.val * 2; 
                    SumRootToLeafWorker(root.right);
                }
            }
        }

        public int SumRootToLeafMorris(TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            int sum = 0;
            int currNumber = 0;
            int steps;
            TreeNode current = root;
            while (current != null)
            {
                if (current.left == null)
                {
                    currNumber = currNumber << 1 | current.val;
                    if (current.right == null)
                        sum += currNumber;
                    //action on c
                    current = current.right;
                }
                else
                {
                    var prev = current.left;
                    steps = 1;
                    while (prev.right != null && prev.right != current)
                    {
                        prev = prev.right;
                        steps += 1;
                    }
                    if (prev.right == null)
                    {
                        currNumber = currNumber << 1 | current.val;
                        prev.right = current;
                        current = current.left;
                    }
                    else
                    {
                        if (prev.left == null)
                        {
                            sum += currNumber;
                        }
                        for (int i = 0; i < steps; i++)
                        {
                            currNumber >>= 1;
                        }
                        prev.right = null;
                        //action c
                        current = current.right;
                    }

                }
            }
            return sum;
        }

        public int MaxDepthNaryIter(NaryNode root)
        {
            var level = 0;
            if (root != null)
            {
                Queue<NaryNode> q = new Queue<NaryNode>();
                q.Enqueue(root);
                while (q.Count > 0)
                {
                    level += 1;
                    var count = q.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var node = q.Dequeue();
                        foreach (NaryNode item in node.children)
                            q.Enqueue(item);
                    }
                }
            }
            return level;
        }
        int MaxDepthNaryLevel = 0;
        public int MaxDepthNary(NaryNode root)
        {
            MaxDepthNaryWorker(root);
            return MaxDepthNaryLevel;
        }
        void MaxDepthNaryWorker(NaryNode root)
        {
            if (root == null)
                return;
            MaxDepthNaryLevel += 1;
            for (int i = 0; i < root.children.Count; i++)
            {
                MaxDepthNary(root.children[i]);
            }
        }

        public int MaxDepthNary2(NaryNode root)
        {
            if (root == null)
                return 0;
            int max = 0;
            for(int i = 0; i < root.children.Count; i++)
                 max = Math.Max(max, MaxDepthNary2(root.children[i]));
             return max + 1;
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return root;
            var left = InvertTree(root.left); //go all the way left till root
            var right = InvertTree(root.right); //go right..
            root.left = right;
            root.right = left;
            return root;
        }

        public TreeNode InvertTreeIter(TreeNode root)
        {
            if (root == null)
                return root;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                var temp = node.left;
                node.left = node.right;
                node.right = temp;
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
            return root;
        }
    }
}

