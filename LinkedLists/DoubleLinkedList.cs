using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    public class DoubleLinkedList<T> : ICollection<T>
    {
        int _count = 0;
        DLLNode<T> _head;
        DLLNode<T> _tail;
        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddLast(T item)
        {
            var node = new DLLNode<T>(item);
            if (_tail != null)
            {
                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }
            else
            {
                _head = node;
                _tail = node;
            }
            _count += 1;
        }

        public void AddFirst(T item)
        {
            var node = new DLLNode<T>(item);
            DLLNode<T> temp = _head;
            _head = node;

            if (_count > 0)
            {
                temp.Previous = node;
                node.Next = temp;
              
            }
            else
            {
                _head = node;
                _tail = node;
            }
            _count += 1;
        }

        public bool Remove(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Previous == null)//head
                    {
                       _head = current.Next;
                        current.Next.Previous = null;
                        current = null;
                    }
                    else if (current.Next == null) //tail
                    {
                         _tail = current.Previous;
                        current.Previous.Next = null;
                    }
                    else 
                    {
                        current.Previous.Next = current.Next;
                    }
                    _count -= 1;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            _count = 0;
            _head = null;
            _tail = null;
        }

        public bool Contains(T item)
        {
            var current = _head;// new DLLNode<T>(item);
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
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
            while (current != null)
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
