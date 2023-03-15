using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.DataStructure
{
    /// <summary>
    /// 在英语中，我们有一个叫做 词根(root) 的概念，可以词根后面添加其他一些词组成另一个较长的单词——我们称这个词为 继承词(successor)。
    /// 例如，词根an，跟随着单词 other(其他)，可以形成新的单词 another(另一个)。
    /// 现在，给定一个由许多词根组成的词典 dictionary 和一个用空格分隔单词形成的句子 sentence。
    /// 你需要将句子中的所有继承词用词根替换掉。如果继承词有许多可以形成它的词根，则用最短的词根替换它。
    /// </summary>
    public class ReplaceWords
    {
        /// <summary>
        /// 构建字典树解决问题
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string Replace_Words(IList<string> dictionary, string sentence)
        {
            string[] words = sentence.Split(' ');
            List<string> repWords = new List<string>();
            TrieNode root = new TrieNode();
            foreach (string word in dictionary)
            {
                TrieNode cur = root;
                int n = word.Length;
                for (int i = 0; i < n; i++)
                {
                    if (cur.Children.ContainsKey(word[i]))
                    {
                        cur = cur.Children[word[i]];
                    }
                    else
                    {
                        TrieNode node = new TrieNode();
                        cur.Children.Add(word[i], node);
                        cur = node;
                    }
                    if (i == n - 1)
                    {
                        cur.IsLeaf = true;
                    }
                }
            }

            StringBuilder builder = new StringBuilder();
            foreach (string word in words)
            {
                TrieNode cur = root;
                builder.Clear();
                bool flag = false;
                foreach (char c in word)
                {
                    if (cur.Children.ContainsKey(c))
                    {
                        cur = cur.Children[c];
                        builder.Append(c);
                        if (cur.IsLeaf)
                        {
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (flag)
                {
                    repWords.Add(builder.ToString());
                }
                else
                {
                    repWords.Add(word);
                }
            }

            return string.Join(" ", repWords);
        }
    }
}
