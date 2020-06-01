using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
  public  class LinkedList<T> : ICollection<T>
    {
        int _count = 0;
        LLNode<T> _head;
        LLNode<T> _tail;
        public LinkedList() { }

        public LinkedList(T value) {
            Add(value);
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsReadOnly =>   false;

        public bool Contains(T value)
        {
            var node = _head;
            while (node != null)
            {
                if (node.Value.Equals(value))
                    return true;
                node = node.Next;
            }
            return false;
        }

        public void Add(T value)
        {
            AddTail(value);
        }

        public void AddHead(T value)
        {
            var node = new LLNode<T>(value);
            if (_head != null)
            {
                node.Next = _head;
                _head = node ;
            }
            else
            {
                _head = node;
                _tail = _head;
            }
            _count += 1;
        }

        public void AddTail(T value)
        {
            var node = new LLNode<T>(value);
            if (_head == null)
            {
                _head = node;
                _tail = _head;
            }
            else
            {
                _tail.Next = node;
                _tail= node ;
            }
            _count += 1;
        }

        public bool Remove(T value)
        {
            var node = _head;
            LLNode<T> prevNode = null;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    if (prevNode == null) // its head
                    {

                        _head =  _head.Next;
                        if (_head == null)
                            _tail = null;
                    }
                    else
                    {
                        prevNode.Next = node.Next;
                        if (prevNode.Next == null)//its the tail
                            _tail = prevNode;
                    }
                    _count -= 1;
                    return true;
                }
                prevNode = node;
                node = node.Next;
            }
            return false;

        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = _head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current!=null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
