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
    public class MagicDictionaryII
    {
        private Dictionary<int, List<string>> dict;
        public MagicDictionaryII()
        {
            dict = new Dictionary<int, List<string>>();
        }

        public void BuildDict(string[] dictionary)
        {
            foreach (var word in dictionary)
            {
                if (dict.ContainsKey(word.Length))
                {
                    dict[word.Length].Add(word);
                }
                else
                {
                    dict.Add(word.Length, new List<string> { word });
                }
            }
        }

        public bool Search(string searchWord)
        {
            //找相同长度的字符串比较
            if (dict.ContainsKey(searchWord.Length))
            {
                foreach (string word in dict[searchWord.Length])
                {
                    bool modified = false;
                    bool flag = true;
                    for (int i = 0; i < searchWord.Length; i++)
                    {
                        if (word[i] != searchWord[i])
                        {
                            if (modified)
                            {
                                flag = false;
                                break;
                            }
                            else
                            {
                                modified = true;
                            }
                        }
                    }
                    if (modified && flag)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
