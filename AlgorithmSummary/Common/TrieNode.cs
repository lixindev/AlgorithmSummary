using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class TrieNode
    {
        public TrieNode()
        {
            IsLeaf = false;
            Children = new Dictionary<char, TrieNode>();
        }
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool IsLeaf { get; set; }
    }
}
