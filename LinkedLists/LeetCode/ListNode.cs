﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.LeetCode
{
public    class ListNode
    {
        public ListNode(int value)
        {
            val = value;
        }

        public int val { get; }
        public ListNode next { get; set; }

    }
}
