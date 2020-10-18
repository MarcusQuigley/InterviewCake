using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees.LeetCode
{
    public class LeetTreesProblemsEasy
    {

        //https://leetcode.com/problems/find-all-the-lonely-nodes/
        public IList<int> GetLonelyNodes(TreeNode root)
        {
            if (root == null)
                return new int[] { };
            IList<int> results = new List<int>();
            GetLonelyNodesWorker(root, results);
            return results;
        }

        void GetLonelyNodesWorker(TreeNode root, IList<int> results)
        {
            if (root == null)
                return;

            if (root.left == null && root.right != null)
                results.Add(root.right.val);
            if (root.right == null && root.left != null)
                results.Add(root.left.val);
            GetLonelyNodesWorker(root.left, results);
            GetLonelyNodesWorker(root.right, results);

        }

        public IList<int> GetLonelyNodesIter(TreeNode root)
        {
            if (root == null)
                return new int[] { };
            IList<int> results = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node.left == null && node.right != null)
                {
                    results.Add(node.right.val);
                }
                if (node.right == null && node.left != null)
                {
                    results.Add(node.left.val);
                }
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
            return results;
        }

        //https://leetcode.com/problems/range-sum-of-bst/
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return 0;
            if (root.val < L)
                return RangeSumBST(root.right, L, R);
            if (root.val > R)
                return RangeSumBST(root.left, L, R);
            return (root.val + RangeSumBST(root.right, L, R) + RangeSumBST(root.left, L, R));
        }

        public int RangeSumBSTIter(TreeNode root, int L, int R)
        {
            if (root == null)
                return 0;
            int result = 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.val >= L && current.val <= R)
                    result += current.val;
                if (current.val >= L && current.left != null) q.Enqueue(current.left);
                if (current.val <= R && current.right != null) q.Enqueue(current.right);
            }
            return result;
        }

        //https://leetcode.com/problems/merge-two-binary-trees/
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            t1.val += t2.val;
            t1.left = (t1.left == null) ? t2.left : MergeTrees(t1.left, t2.left);
            t1.right = (t1.right == null) ? t2.right : MergeTrees(t1.right, t2.right);
            return t1;
        }

        public TreeNode MergeTreesIter(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            Stack<TreeNode[]> stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { t1, t2 });
            while (stack.Count > 0)
            {
                TreeNode[] t = stack.Pop();
                if (t[0] == null || t[1] == null) continue;
                t[0].val += t[1].val;
                if (t[0].left == null)
                    t[0].left = t[1].left;
                else
                    stack.Push(new TreeNode[] { t[0].left, t[1].left });
                if (t[0].right == null)
                    t[0].right = t[1].right;
                else
                    stack.Push(new TreeNode[] { t[0].right, t[1].right });
            }
            return t1;
        }

        //https://leetcode.com/problems/search-in-a-binary-search-tree/
        TreeNode resultBst = null;
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;

            if (root.val == val)
            {
                resultBst = new TreeNode(val);
                resultBst.left = root.left;
                resultBst.right = root.right;
                //   return result;
            }
            SearchBST(root.left, val);
            SearchBST(root.right, val);
            return resultBst;
        }
        public TreeNode SearchBSTIter(TreeNode root, int val)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            var current = root;
            while (current != null && current.val != val)
            {
                current = (current.val > val) ? current.left : current.right;
            }
            return current;
        }
        //https://leetcode.com/problems/n-ary-tree-postorder-traversal/
        public IList<int> NaryPostorder(NaryNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            IList<int> results = new List<int>();
            Stack<NaryNode> leftStack = new Stack<NaryNode>();
            Stack<NaryNode> rightStack = new Stack<NaryNode>();
            leftStack.Push(root);
            while (leftStack.Count > 0)
            {
                var current = leftStack.Pop();
                for (int i = 0; i < current.children.Count; i++)
                    leftStack.Push(current.children[i]);

                rightStack.Push(current);
            }
            while (rightStack.Count > 0)
                results.Add(rightStack.Pop().val);

            return results;
        }

        //https://leetcode.com/problems/n-ary-tree-preorder-traversal/
        public IList<int> NaryPreorderIter(NaryNode root)
        {
            IList<int> results = new List<int>();
            if (root == null)
                return results;
            Stack<NaryNode> stack = new Stack<NaryNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                results.Add(current.val);
                for (int i = current.children.Count - 1; i >= 0; i--)
                {
                    stack.Push(current.children[i]);
                }
            }
            return results;
        }

        public IList<int> NaryPreorder(NaryNode root)
        {
            IList<int> results = new List<int>();
            if (root != null)
                NaryPreorderWorker(root, results);
            return results;
        }

        void NaryPreorderWorker(NaryNode node, IList<int> results)
        {
            if (node == null)
                return;
            results.Add(node.val);
            for (int i = 0; i < node.children.Count; i++)
            {
                NaryPreorderWorker(node.children[i], results);
            }
            return;
        }

        //https://leetcode.com/problems/increasing-order-search-tree/
        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode result = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var current = root;
            TreeNode temp = null;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                if (result == null)
                {
                    result = new TreeNode(current.val);
                    temp = result;
                }
                else
                {
                    result.right = new TreeNode(current.val);
                    result = result.right;
                }
                current = current.right;
            }

            return temp;// result;
        }

        //https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
        public int SumRootToLeaf(TreeNode root)
        {
            Stack<KeyValuePair<TreeNode, int>> stack = new Stack<KeyValuePair<TreeNode, int>>();
            stack.Push(new KeyValuePair<TreeNode, int>(root, root.val));
            int sum = 0;
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                var currentNode = current.Key;
                if (currentNode.left == null && currentNode.right == null)
                {
                    sum += current.Value;
                }
                else
                {
                    if (currentNode.left != null) stack.Push(new KeyValuePair<TreeNode, int>(currentNode.left, (current.Value * 2) + currentNode.left.val));
                    if (currentNode.right != null) stack.Push(new KeyValuePair<TreeNode, int>(currentNode.right, (current.Value * 2) + currentNode.right.val));
                }
            }
            return sum;
        }

        //https://leetcode.com/problems/maximum-depth-of-n-ary-tree/
        public int MaxDepthNary(NaryNode root)
        {
            if (root == null)
                return 0;
            int level = 0;
            Queue<NaryNode> q = new Queue<NaryNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var count = q.Count;
                level += 1;
                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    for (int j = 0; j < node.children.Count; j++)
                        q.Enqueue(node.children[j]);
                }
            }
            return level;
        }

        //https://leetcode.com/problems/univalued-binary-tree/
        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            return IsUnivalTreeWorker(root, root.val);
        }
        bool IsUnivalTreeWorker(TreeNode node, int value)
        {

            var leftResult = (node != null && node.val == value);
            if (node.left != null) leftResult &= IsUnivalTreeWorker(node.left, value);

            var rightResult = (node != null && node.val == value);
            if (node.right != null) rightResult &= IsUnivalTreeWorker(node.right, value);

            return leftResult && rightResult;
        }

        public bool IsUnivalTreeIter(TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int val = root.val;
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.val != val)
                    return false;
                if (current.left != null) stack.Push(current.left);
                if (current.right != null) stack.Push(current.right);
            }
            return true;
        }

        //  int maxdepthResult = 0;
        //https://leetcode.com/problems/maximum-depth-of-binary-tree/
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var left = MaxDepth(root.left) + 1;
            var right = MaxDepth(root.right) + 1;
            //maxdepthResult = Math.Max(maxdepthResult, Math.Max(left, right));
            return Math.Max(left, right);
        }

        public int MaxDepthIter(TreeNode root)
        {
            if (root == null)
                return 0;
            int level = 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {

                var count = q.Count;
                level += 1;
                for (int i = 0; i < count; i++)
                {
                    var c = q.Dequeue();
                    if (c.left != null) q.Enqueue(c.left);
                    if (c.right != null) q.Enqueue(c.right);
                }
            }
            return level;
        }

        //https://leetcode.com/problems/invert-binary-tree/
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode right = InvertTree(root.right);
            TreeNode left = InvertTree(root.left);
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

        //https://leetcode.com/problems/leaf-similar-trees/
        //no recursion
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            if (root1 == null || root2 == null)
                return false;
            var values1 = new List<int>();
            var values2 = new List<int>();
            LeafSimilarWorker(root1, values1);
            LeafSimilarWorker(root2, values2);

            if (values1.Count != values2.Count)
                return false;
            for (int i = 0; i < values1.Count; i++)
            {
                if (values1[i] != values2[i])
                    return false;
            }
            return true;
        }
        void LeafSimilarWorker(TreeNode node, List<int> values)
        {
            if (node.left == null && node.right == null)
            {
                values.Add(node.val);
                return;
            }
            else
            {
                if (node.left != null) LeafSimilarWorker(node.left, values);
                if (node.right != null) LeafSimilarWorker(node.right, values);
            }
            return;
        }

        //https://leetcode.com/problems/average-of-levels-in-binary-tree/
        //no recursion
        public IList<double> AverageOfLevels(TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            IList<double> result = new List<double>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var count = q.Count;
                double sum = 0d;
                for (int i = 0; i < count; i++)
                {
                    var current = q.Dequeue();
                    if (current.left != null) q.Enqueue(current.left);
                    if (current.right != null) q.Enqueue(current.right);
                    sum += current.val;
                }
                result.Add(sum / count);

            }
            return result;
        }

        //https://leetcode.com/problems/trim-a-binary-search-tree/
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return null;
            if (root.val > high) return TrimBST(root.left, low, high);
            if (root.val < low) return TrimBST(root.right, low, high);

            root.left = (TrimBST(root.left, low, high));
            root.right = (TrimBST(root.right, low, high));
            return root;
        }

        //https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null)
                return false;
            Dictionary<int, int> map = new Dictionary<int, int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!map.ContainsKey(current.val))
                {
                    map.Add(k - current.val, current.val);
                    if (current.left != null) stack.Push(current.left);
                    if (current.right != null) stack.Push(current.right);
                }
                else
                    return true;
            }
            return false;
        }

        //https://leetcode.com/problems/convert-bst-to-greater-tree/
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null)
                return root;
            TreeNode node = root;
            int max = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || node != null)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.right;
                }
                node = stack.Pop();
                max += node.val;
                node.val = max;
                node = node.left;
            }
            return root;
        }

        //https://leetcode.com/problems/minimum-absolute-difference-in-bst/
        public int GetMinimumDifferenceIter(TreeNode root)
        {
            List<int> array = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var current = root;
            int prev = int.MaxValue;
            int min = int.MaxValue;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();

                if (prev != int.MaxValue)
                    min = Math.Min(min, current.val - prev);
                prev = current.val;
                current = current.right;
            }
            return min;
        }

        int prevMinDiff = int.MaxValue;
        int minMinDiff = int.MaxValue;
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null)
                return minMinDiff;

            GetMinimumDifference(root.left);
            if (prevMinDiff != int.MaxValue)
            {
                minMinDiff = Math.Min(minMinDiff, root.val - prevMinDiff);
            }
            prevMinDiff = root.val;
            GetMinimumDifference(root.right);
            return minMinDiff;
        }
        //https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {

            if (root == null)
                return new List<IList<int>>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            Stack<IList<int>> tempResults = new Stack<IList<int>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var count = q.Count;
                int[] vals = new int[count];
                IList<TreeNode> list = new List<TreeNode>();
                for (int i = 0; i < count; i++)
                {
                    TreeNode c = q.Dequeue();
                    vals[i] = c.val;
                    if (c.left != null) q.Enqueue(c.left);
                    if (c.right != null) q.Enqueue(c.right);
                }
                tempResults.Push(vals);
            }
            return tempResults.ToList();
        }

        //https://leetcode.com/problems/same-tree/

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);

        }

        public bool IsSameTreeIter(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> p1 = new Queue<TreeNode>();
            Queue<TreeNode> q1 = new Queue<TreeNode>();
            q1.Enqueue(q);
            p1.Enqueue(p);

            while (q1.Count > 0 && p1.Count > 0)
            {
                var nodep = p1.Dequeue();
                var nodeq = q1.Dequeue();

                if (nodep == null && nodeq == null)
                    continue;
                if (nodep == null || nodeq == null) return false;
                if (nodep.val != nodeq.val) return false;

                if (nodep.left == null && nodeq.left != null) return false;
                if (nodep.left != null && nodeq.left == null) return false;
                if (nodep.right == null && nodeq.right != null) return false;
                if (nodep.right != null && nodeq.right == null) return false;
                if (nodep.left != null) p1.Enqueue(nodep.left);
                if (nodeq.left != null) q1.Enqueue(nodeq.left);
                if (nodep.right != null) p1.Enqueue(nodep.right);
                if (nodeq.right != null) q1.Enqueue(nodeq.right);
                // if (q1.Count != p1.Count) return false;
            }
            return true;
        }

        public int MinDiffInBSTIter(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int min = int.MaxValue;
            int prev = int.MaxValue;
            var current = root;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                if (prev != int.MaxValue)
                    min = Math.Min(min, current.val - prev);
                prev = current.val;

                current = current.right;
            }
            return min;
        }

        //https://leetcode.com/problems/minimum-distance-between-bst-nodes/
        int prevMinDiffInBST = int.MaxValue;
        int minMinDiffInBST = int.MaxValue;
        public int MinDiffInBST(TreeNode root)
        {
            if (root == null)
                return minMinDiffInBST;
            MinDiffInBST(root.left);
            if (prevMinDiffInBST != int.MaxValue)
                minMinDiffInBST = Math.Min(minMinDiffInBST, root.val - prevMinDiffInBST);
            prevMinDiffInBST = root.val;
            MinDiffInBST(root.right);
            return minMinDiffInBST;
        }

        //https://leetcode.com/problems/cousins-in-binary-tree/
        public bool IsCousins(TreeNode root, int x, int y)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int count = q.Count;
                bool isX = false;
                bool isY = false;
                bool diffParent = false;
                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    if (node != null)
                    {
                        // bool bothFalse = (isX == false && isY == false);
                        if (node.val == x) isX = true;
                        if (node.val == y) isY = true;
                        if (isX == true && isY == true)
                            return diffParent;

                        if (node.left != null) q.Enqueue(node.left);
                        if (node.right != null) q.Enqueue(node.right);
                        q.Enqueue(null);
                    }
                    else
                        diffParent = true;
                }
                if (isX != isY) //means one is true but since were at the end of the level we can return as teh answer will be false
                    break;
            }
            return false;
        }

        //https://leetcode.com/problems/sum-of-left-leaves/
        //  int leftLeafsSum = 0;
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return 0;
            return SumOfLeftLeavesWorker(root, false);
        }
        int SumOfLeftLeavesWorker(TreeNode root, bool isLeft)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null && isLeft)
                return root.val;
            return SumOfLeftLeavesWorker(root.left, true) + SumOfLeftLeavesWorker(root.right, false);
        }

        //https://leetcode.com/problems/binary-tree-paths/
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root == null)
                return new string[] { };
            IList<string> results = new List<string>();
            BinaryTreePathsWorker(root, "", results);
            return results;
         }

        void BinaryTreePathsWorker(TreeNode node, string str, IList<string> list)
        {
            if (node == null)
                return;
            str = str.Length>0  ? str + "->" + node.val: node.val.ToString() ;
            if (node.left == null && node.right == null)
                list.Add(str);
            BinaryTreePathsWorker(node.left, str, list);
            BinaryTreePathsWorker(node.right, str, list);
        }

            public IList<string> BinaryTreePathsIter(TreeNode root)
        {
            IList<string> results = new List<string>();
            if (root != null)
            {
                Stack<BtpObject> stack = new Stack<BtpObject>();
                stack.Push(new BtpObject(root, new StringBuilder()));
                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    current.Sb.Append(current.Sb.Length == 0 ? current.Node.val.ToString() : "->" + current.Node.val);
                    if (current.Node.left == null && current.Node.right == null)
                        results.Add(current.Sb.ToString());
                    else
                    {
                        if (current.Node.right != null) stack.Push(new BtpObject(current.Node.right, new StringBuilder(current.Sb.ToString())));
                        if (current.Node.left != null) stack.Push(new BtpObject(current.Node.left, new StringBuilder(current.Sb.ToString())));
                    }
                }
            }
            return results;
        }
        
        private class BtpObject
        {
            public TreeNode Node { get; set; }
            public StringBuilder Sb { get; set; }

            public BtpObject(TreeNode node, StringBuilder value)
            {
                Node = node;
                Sb = value;
            }
        }

        //https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor(root.left, p, q);
            else if (root.val < p.val && root.val < q.val)
                return LowestCommonAncestor(root.right, p, q);
            return root;

        }


        public TreeNode LowestCommonAncestorIter(TreeNode root, TreeNode p, TreeNode q)
        {
            int pVal = p.val;
            int qVal = q.val;
            TreeNode node = root;
            while (node != null)
            {
                int parentVal = node.val;
                if (pVal > parentVal && qVal > parentVal)
                    node = node.right;
                else if (pVal < parentVal && qVal < parentVal)
                    node = node.left;
                else
                    return node;
            }

            return null;
        }

        //https://leetcode.com/problems/closest-binary-search-tree-value/
        //Note NOT using binary tree properties so O(n) as opposed to O(logn). NEed to fix
        public int ClosestValue(TreeNode root, double target)
        {
            List<int> list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var current = root;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                list.Add(current.val);
                current = current.right;

            }
            var diff = Math.Abs(target - list[0]);
            var result = list[0];
            
            for (int i = 0; i < list.Count; i++)
            {
                if (Math.Abs(target - list[i]) <= diff)
                {
                    diff = Math.Abs(target - list[i]);
                    result = list[i];
                }
                    
            }
            return (int) result;
        }
 
        public int MaxHeightOfTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var left = MaxHeightOfTree(root.left);
            var right = MaxHeightOfTree(root.right);
            return Math.Max(left, right) + 1;
        }

    }
}
