using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class ListNode
    {
        public ListNode(int value)
        {
            val = value;
        }

        public int val { get; }
        public ListNode next { get; set; }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
