using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{

    public class NaryNode
    {
        public NaryNode() { }
        public NaryNode(int value)
        {
            this.val = value;
        }
        public NaryNode(int value, IList<NaryNode> children)
        {
            this.val = value;
            this.children = children;
        }
        public IList<NaryNode> children { get; set; }
        public int val { get; }

    }
}
