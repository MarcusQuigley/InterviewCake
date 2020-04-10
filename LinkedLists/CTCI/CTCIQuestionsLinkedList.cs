using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.CTCI
{
  public class CTCIQuestionsLinkedList<T>
    {
        public void RemoveDuplicatesWithQueue(CTCI_LLNode<T> head)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));
            var _hash = new HashSet<T>();
            //var _stack = new Stack<T>();
            //var _queue = new Queue<T>();
            CTCI_LLNode<T> previous = null;
            while (head != null)
            {
                if (!_hash.Contains(head.Value))
                {
                    _hash.Add(head.Value);
                    previous = head;
                }
                else
                {
                    previous.Next = head.Next;
                }
                head = head.Next;
            }
             
        }

        public void RemoveDuplicates(CTCI_LLNode<T> head)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));
            var pointer1 = head;
            while (pointer1 != null)
            {
                var pointer2 = pointer1;
                while (pointer2.Next != null)
                {
                    if (pointer2.Next.Value.Equals(pointer1.Value))
                    {
                        pointer2.Next = pointer2.Next.Next;
                    }
                    else
                    {
                        //prev = pointer2;
                        pointer2 = pointer2.Next;
                    }
                }
                pointer1 = pointer1.Next;
            }
        }

        public LLNode<T> ReturnKthToLast(LLNode<T> node, int k)
        {
            var pointer2 = node;
            var counter = 0;
            while (node != null)
            {
                counter += 1;
                node = node.Next;
            }
            var kthFromLast = counter - k;
       
            while (kthFromLast > 0)
            {
                kthFromLast -= 1;
                pointer2 = pointer2.Next;
            }
            return pointer2;
        }

        public LLNode<T> ReturnKthToLastBetter(LLNode<T> node, int k)
        {
            var pointer2 = node;
            var counter = 0;
            while (counter < k)
            {
                if (node.Next == null)
                    throw new InvalidOperationException("Node was null");
                node = node.Next;
                counter += 1;
            }
            while (node != null)
            {
                node = node.Next;
                pointer2 = pointer2.Next;
            }
            return pointer2;
        }

    }
}
