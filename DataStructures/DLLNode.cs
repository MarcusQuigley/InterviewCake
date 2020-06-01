using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
   public class DLLNode<T>
    {
        public DLLNode() { }

        public DLLNode(T value) {
            Value = value;
        }

        public DLLNode<T> Previous { get; set; }
        public DLLNode<T> Next { get; set; }
        public T Value { get; }
    }
}
