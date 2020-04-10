using System;

namespace Stacks
{
    public interface IMinStack
    {
        void Push(int value);
        int Pop();
        int Top();
        int GetMin();
    } 
}
