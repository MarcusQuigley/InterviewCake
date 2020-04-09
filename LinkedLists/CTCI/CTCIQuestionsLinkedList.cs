using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.CTCI
{
  public class CTCIQuestionsLinkedList<T>
    {
        public void RemoveDuplicates(LLNode<T> head)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));
            
            var pointer2 = head.Next;
            var prev = head;
            while (head != null)
            {
                while (pointer2 != null)
                {
                    if (pointer2.Value.Equals(head.Value))
                    {
                        prev.Next = pointer2.Next;
                    }
                    prev = pointer2;
                    pointer2 = pointer2.Next;
                }
                head = head.Next;
                prev = head;
                pointer2 = pointer2.Next;
            }
        }
    }
}
