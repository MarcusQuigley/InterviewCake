using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    class TrieNode
    {
        TrieNode[] links;
        int final = 26;
        bool isEnded;

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
