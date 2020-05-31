using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
   public class Trie
    {
       readonly TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = root;
            foreach (char ch in word.ToCharArray())
            {
                if (!node.Contains(ch))
                {
                    node.Put(ch, new TrieNode());
                }
                node = node.Get(ch);
            }
            node.IsEnded = true;
        }

        TrieNode SearchPrefix(string word)
        {
            var node = root;
            foreach(char ch in word)
            {
                if (!node.Contains(ch))
                    return null;
                node = node.Get(ch);
            }
            return node;
        }
        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode node = SearchPrefix(word);
            return node != null && node.IsEnded;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            TrieNode node = SearchPrefix(prefix);
            return node != null;
        }
    }
}
