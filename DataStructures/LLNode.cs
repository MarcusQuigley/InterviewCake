using System;

namespace DataStructures
{
    public class LLNode<T>
    {
        public LLNode(T value)
        {
            this.Value = value;
        }
        public LLNode<T> Next { get; set; }
        public T Value { get; }
    }
}
