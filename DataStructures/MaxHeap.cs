using System;

namespace DataStructures
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        T[] values = null;
        int count = 0;
        public MaxHeap()
        {
            values = new T[100];
        }

        public MaxHeap(T[] items)
        {
            values = new T[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                Add(items[i]);
            }
        }

        public int Count => count;

        public int Parent(int index)
        {
            return (index - 1) / 2;
        }

        public void Add(T value)
        {
            if (count == values.Length)
                DoubleArray();
            values[count] = value;
            int index = count;
            while (index > 0 && values[index].CompareTo(values[Parent(index)]) > 0)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
            count += 1;
        }

        public T RemoveMax()
        {
            if (count == 0)
                throw new InvalidOperationException("No items exist to remove.");
            var result = values[0];
            values[0] = values[count - 1];
            count -= 1;
            int index = 0;
            while (index < count)
            {
                int left = (index * 2) + 1;
                int right = (index * 2) + 2;
                if (left >= count)
                    break;

                int maxChildIndex = MaxChildIndex(left, right);
                if (values[index].CompareTo(values[maxChildIndex]) > 0)
                {
                    break;
                }
                Swap(index, maxChildIndex);
                index = maxChildIndex;
            }
            return result;
        }

        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException();
            return values[0];
        }

        public void Clear()
        {
            count = 0;
            values = null;
        }

        int MaxChildIndex(int left, int right)
        {
            int maxChildIndex = -1;
            if (right >= count)
            { // No right child. 
                maxChildIndex = left;
            }
            else
            {
                if (values[left].CompareTo(values[right]) > 0)
                {
                    maxChildIndex = left;
                }
                else
                {
                    maxChildIndex = right;
                }
            }
            return maxChildIndex;
        }

        void Swap(int a, int b)
        {
            var temp = values[a];
            values[a] = values[b];
            values[b] = temp;
        }
        void DoubleArray()
        {
            T[] temp = new T[values.Length << 1];
            for (int i = 0; i < values.Length; i++)
            {
                temp[i] = values[i];
            }
            values = temp;
        }



    }
}
