using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 合并K个升序链表
    /// </summary>
    public class MergeKLists
    {
        public ListNode Merge_K_Lists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            //去除为null的链表
            lists = lists.Where(l => l != null).ToArray();
            ListNode head = new ListNode();
            ListNode cur = head;
            int size = lists.Length;
            Build_Heap(lists);
            while (size > 1)
            {
                cur.next = lists[0];
                cur = lists[0];
                if (lists[0].next != null)
                {
                    lists[0] = lists[0].next;
                }
                else
                {
                    lists[0] = lists[--size];
                }
                Heapify(lists, 0, size);
            }
            //剩最后一个数组，直接拼上去
            cur.next = lists[0];

            return head.next;
        }

        /// <summary>
        /// 维护根节点下标为i的最小堆
        /// </summary>
        /// <param name="s">数组</param>
        /// <param name="i">开始下标</param>
        /// <param name="n">堆的大小</param>
        private void Heapify(ListNode[] lists, int i, int n)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int minimum = i;
            if (left < n && lists[left].val < lists[minimum].val)
            {
                minimum = left;
            }
            if (right < n && lists[right].val < lists[minimum].val)
            {
                minimum = right;
            }

            if (i != minimum)
            {
                ListNode swap = lists[i];
                lists[i] = lists[minimum];
                lists[minimum] = swap;
                Heapify(lists, minimum, n);
            }
        }

        /// <summary>
        /// 自底向上维护堆
        /// </summary>
        /// <param name="s"></param>
        private void Build_Heap(ListNode[] lists)
        {
            for (int i = lists.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(lists, i, lists.Length);
            }
        }
    }
}
