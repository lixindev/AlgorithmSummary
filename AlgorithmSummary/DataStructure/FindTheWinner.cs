using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 共有 n 名小伙伴一起做游戏。小伙伴们围成一圈，按 顺时针顺序 从 1 到 n 编号。
    /// 确切地说，从第 i 名小伙伴顺时针移动一位会到达第 (i+1) 名小伙伴的位置，其中 1 <= i < n ，从第 n 名小伙伴顺时针移动一位会回到第 1 名小伙伴的位置。
    /// 游戏遵循如下规则：
    /// 从第 1 名小伙伴所在位置 开始 。
    /// 沿着顺时针方向数 k 名小伙伴，计数时需要 包含 起始时的那位小伙伴。逐个绕圈进行计数，一些小伙伴可能会被数过不止一次。
    /// 你数到的最后一名小伙伴需要离开圈子，并视作输掉游戏。
    /// 如果圈子中仍然有不止一名小伙伴，从刚刚输掉的小伙伴的 顺时针下一位 小伙伴 开始，回到步骤 2 继续执行。
    /// 否则，圈子中最后一名小伙伴赢得游戏。
    /// </summary>
    public class FindTheWinner
    {
        /// <summary>
        /// 使用链表结构存储信息
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Find_The_Winner(int n, int k)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                linkedList.AddLast(i);
            }

            LinkedListNode<int> start = linkedList.First;
            while (n > 1)
            {
                int count = k % n - 1;
                LinkedListNode<int> cur = start;
                while (count > 0)
                {
                    if (cur.Next != null)
                    {
                        cur = cur.Next;
                    }
                    else
                    {
                        cur = linkedList.First;
                    }
                    count--;
                }
                if (count < 0)
                {
                    if (cur.Previous != null)
                    {
                        cur = cur.Previous;
                    }
                    else
                    {
                        cur = linkedList.Last;
                    }
                }
                if (cur.Next != null)
                {
                    start = cur.Next;
                }
                else
                {
                    start = linkedList.First;
                }

                linkedList.Remove(cur);
                n--;
            }

            return linkedList.First.Value;
        }
    }
}
