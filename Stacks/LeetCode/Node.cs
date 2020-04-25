using System;
using System.Collections.Generic;
using System.Text;

namespace Stacks.LeetCode
{
  public  class Node
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
