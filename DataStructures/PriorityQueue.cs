using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
   public class PriorityQueue<T> where T : IComparable<T>
    {
        readonly MaxHeap<T> heap = new MaxHeap<T>();
        public void Enqueue(T value)
        {
            heap.Add(value);
        }
        public void Dequeue( )
        {
            heap.RemoveMax();
        }

        public void Clear()
        {
            heap.Clear();
        }

        public int Count => heap.Count;
    }
}
