using LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stacks.LeetCode
{
    public class MinStack : IMinStack
    {
        Node _head = null;
       // Node _previousTail = null;
        Node _tail = null;
        int _min = int.MaxValue;
        int _count = 0;

        public int Count { get => _count;}

        public void Push(int value)
        {
            var node = new Node(value);
            if (_head == null)
            {
                _head = node;
             }
            else
            {
                 _tail.Previous = _tail;
            }
            _tail = node;

            _count += 1;
            _min = Math.Min(_min, node.Value);
        }

        public int Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("No items");
            var result = _tail.Value;
           
            if (_tail.Previous!=null)
            {
                _tail.Previous.Next = null;
            }
            _tail = _tail.Previous;
            _count -= 1;

            if (_min == result)
                FindMin();

            return result;
         }

        public int Top()
        {
            if (_count == 0)
                throw new InvalidOperationException("No items");
            return _head.Value;
        }

        public int GetMin()
        {
            if (_count == 0)
                throw new InvalidOperationException("No items");
            return _min;
        }

        void FindMin()
        {
            _min = int.MaxValue;
            var current = _head;
            while (current != null) {
                _min = Math.Min(_min, current.Value);
                current = current.Next;
            }
        }
    }
}
