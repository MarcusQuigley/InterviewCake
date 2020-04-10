using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.CTCI
{
    public class CTCI_LLNode<T>
    {
        public CTCI_LLNode(T value)
        {
            this.Value = value;
        }

        public CTCI_LLNode<T> Next { get; set; }
        public T Value { get; set; }

        public CTCI_LLNode<T> Previous { get; set; }
    }
}
