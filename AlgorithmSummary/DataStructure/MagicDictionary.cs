using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 设计一个使用单词列表进行初始化的数据结构，单词列表中的单词 互不相同 。 
    /// 如果给出一个单词，请判定能否只将这个单词中一个字母换成另一个字母，使得所形成的新单词存在于你构建的字典中。
    /// </summary>
    public class MagicDictionary
    {
        //字典树的根
        private TrieNode root;
        public MagicDictionary()
        {
            root = new TrieNode();
        }

        /// <summary>
        /// 构造字典树
        /// </summary>
        /// <param name="dictionary"></param>
        public void BuildDict(string[] dictionary)
        {
            foreach (string word in dictionary)
            {
                TrieNode cur = root;
                foreach (char c in word)
                {
                    if (!cur.Children.ContainsKey(c))
                    {
                        cur.Children.Add(c, new TrieNode());
                    }

                    cur = cur.Children[c];
                }
                cur.IsLeaf = true;
            }
        }

        public bool Search(string searchWord)
        {
            return DFS(searchWord, root, 0, false);
        }

        private bool DFS(string searchWord, TrieNode node, int pos, bool modified)
        {
            if (searchWord.Length == pos)
            {
                //当遍历到最后一个字符，节点也到达叶子节点，且被修改过一次
                return modified && node.IsLeaf;
            }
            //当前节点的子节点包含pos位置的字符，继续深度优先遍历
            if (node.Children.ContainsKey(searchWord[pos]))
            {
                if (DFS(searchWord, node.Children[searchWord[pos]], pos + 1, modified))
                {
                    return true;
                }
            }

            //若当前没有修改过，将当前字符替换为子节点中的任意字符
            if (!modified)
            {
                foreach (var item in node.Children)
                {
                    if (item.Key != searchWord[pos])
                    {
                        if (DFS(searchWord, item.Value, pos + 1, true))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
