using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class TrieNode
    {
        readonly TrieNode[] links;
        readonly int final = 26;

        public TrieNode()
        {
            links = new TrieNode[final];
        }
        public bool IsEnded { get; set; }

        public bool Contains(char ch)
        {
            return links[ch - 'a'] != null;
        }

        public TrieNode Get(char ch)
        {
            return links[ch - 'a'];
        }

        public void Put(char ch, TrieNode node)
        {
            links[ch - 'a'] = node;
        }
    }
}
