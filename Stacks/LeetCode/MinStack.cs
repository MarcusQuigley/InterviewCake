using System;

namespace Stacks.LeetCode
{
    //155. https://leetcode.com/problems/min-stack/
    public class MinStack
    {
        Node _head = null;
        int _min = int.MaxValue;
        int _count = 0;

        public MinStack()
        {
        }

        public int Count { get => _count; }

        public void Push(int value)
        {
            var node = new Node(value);
            if (_head != null)
            {
                node.Next = _head;
            }

            _head = node;

            _count += 1;
            _min = Math.Min(_min, node.Value);
        }

        public void Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("No items");
            var result = _head.Value;
            _head = _head.Next;

            _count -= 1;

            if (_min == result)
                FindMin();
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
            while (current != null)
            {
                _min = Math.Min(_min, current.Value);
                current = current.Next;
            }
        }

        class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
    }
}
