using DataStructures;
using System;
using Scr = Scratch;

namespace ScratchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
             //  TestScratch();
            //  TestScratchSwapPairs();
            // TestSwap();
            //TestLinkedLists();
           // TestScratchSearchBst(new int[] { 4, 2, 7, 1, 3 },2);
            TestScratchSearchBstRecursion(new int[] { 4, 2, 7, 1, 3 }, 5);
        }

          static void TestLinkedLists()
        {
            Scr.Scratch s = new Scr.Scratch();
            var head = CreateListNode(3);
            var ans = s.ReverseListRecursion(head);
           // var ans = s.ReverseList(head);
            
        }

        static void TestScratch()
        {
            Scr.Scratch s = new Scr.Scratch();
            var chars = "12345".ToCharArray();
               s.ReverseString(chars);
           // s.printReverse("abcde".ToCharArray());
        }

        static void TestSwap()
        {
            Scr.Scratch s = new Scr.Scratch();
            var head = CreateListNode();
           // var result = s.Swap(head);
            var result = s.SwapRecursion(head);
            
        }

        static void TestScratchSwapPairs()
        {
            Scr.Scratch s = new Scr.Scratch();
            var head = CreateListNode();
            s.SwapPairs(head);
        }

        static void TestScratchSearchBst(int[] values, int k)
        {
            Scr.Scratch s = new Scr.Scratch();
            var root = CreatTreeNodesNonGeneric(values);// new int[] { 4, 2, 7, 1, 3 });
             
         var result =  s.SearchBst(root,k);
        }

        static void TestScratchSearchBstRecursion(int[] values, int k)
        {
            Scr.Scratch s = new Scr.Scratch();
            var root = CreatTreeNodesNonGeneric(values); 

            var result = s.SearchBstRecursion(root, k);
        }
        
        static ListNode CreateListNode(int limit = 5)
        {
            ListNode head = new ListNode(1);
            ListNode temp = null;
            ListNode temp2 = null;
            var node = head;
            for (int i = 2; i < limit; i++)
            {
                node.next = new ListNode(i);
                node = node.next;
                temp = new ListNode(i);
                temp2 = node;
            }

            return head;
        }

        static   TreeNode CreatTreeNodesNonGeneric(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            TreeNode root = new TreeNode(values[0]);
            root = InOrderNonGeneric(values, root, 0);
            return root;
        }

        static TreeNode InOrderNonGeneric(int[] arr,
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
    }
}
