using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 输入、删除字符串，对其计数，获取计数最大和最小的字符串
    /// 使用哈希表+双向链表的数据结构
    /// 双向链表按正序保存 计数 + 字符串列表 信息
    /// 哈希表保存 字符串(key) + 链表节点 信息
    /// </summary>
    public class AllOne
    {
        public struct MyListNode
        {
            public int count;
            public HashSet<string> set;
        }

        private Dictionary<string, LinkedListNode<MyListNode>> dict;
        private LinkedList<MyListNode> myListNodes;

        public AllOne()
        {
            dict = new Dictionary<string, LinkedListNode<MyListNode>>();
            myListNodes = new LinkedList<MyListNode>();
        }

        public void Inc(string key)
        {
            if (dict.ContainsKey(key))
            {
                LinkedListNode<MyListNode> cur = dict[key];
                if (cur.Next == null || cur.Next.Value.count > cur.Value.count + 1)
                {
                    MyListNode node = new MyListNode
                    {
                        count = cur.Value.count + 1,
                        set = new HashSet<string> { key }
                    };
                    myListNodes.AddAfter(cur, node);
                }
                else
                {
                    cur.Next.Value.set.Add(key);
                }
                LinkedListNode<MyListNode> next = cur.Next;
                cur.Value.set.Remove(key);
                if (cur.Value.set.Count == 0)
                {
                    myListNodes.Remove(cur);
                }
                dict[key] = next;
            }
            else
            {
                LinkedListNode<MyListNode> first = myListNodes.First;
                if (first == null || first.Value.count > 1)
                {
                    MyListNode node = new MyListNode
                    {
                        count = 1,
                        set = new HashSet<string> { key }
                    };
                    myListNodes.AddFirst(node);
                }
                else
                {
                    first.Value.set.Add(key);
                }
                dict.Add(key, myListNodes.First);
            }
        }

        public void Dec(string key)
        {
            LinkedListNode<MyListNode> cur = dict[key];

            if (cur.Value.count == 1)
            {
                dict.Remove(key);
            }
            else if (cur.Previous == null || cur.Previous.Value.count < cur.Value.count - 1)
            {
                MyListNode node = new MyListNode
                {
                    count = cur.Value.count - 1,
                    set = new HashSet<string> { key }
                };
                myListNodes.AddBefore(cur, node);
                dict[key] = cur.Previous;
            }
            else
            {
                cur.Previous.Value.set.Add(key);
                dict[key] = cur.Previous;
            }
            cur.Value.set.Remove(key);
            if (cur.Value.set.Count == 0)
            {
                myListNodes.Remove(cur);
            }
        }

        public string GetMaxKey()
        {
            if (myListNodes.Count == 0)
            {
                return "";
            }
            return myListNodes.Last.Value.set.First();
        }

        public string GetMinKey()
        {
            if (myListNodes.Count == 0)
            {
                return "";
            }
            return myListNodes.First.Value.set.First();
        }
    }
}
