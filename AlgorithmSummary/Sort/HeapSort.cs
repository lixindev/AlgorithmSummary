using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.Sort
{
    public class HeapSort
    {
        public void ExecSort(int[] s)
        {
            Build_Max_Heap(s);
            int swap;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                swap = s[i];
                s[i] = s[0];
                s[0] = swap;
                Heapify(s, 0, i);
            }
        }

        /// <summary>
        /// 维护根节点下标为i的最大堆
        /// </summary>
        /// <param name="s">数组</param>
        /// <param name="i">开始下标</param>
        /// <param name="n">堆的大小</param>
        private void Heapify(int[] s, int i, int n)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            if (left < n && s[left] > s[largest])
            {
                largest = left;
            }
            if (right < n && s[right] > s[largest])
            {
                largest = right;
            }

            if (i != largest)
            {
                int swap = s[i];
                s[i] = s[largest];
                s[largest] = swap;
                Heapify(s, largest, n);
            }
        }

        /// <summary>
        /// 自底向上维护最大堆
        /// </summary>
        /// <param name="s"></param>
        private void Build_Max_Heap(int[] s)
        {
            for (int i = s.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(s, i, s.Length);
            }
        }
    }
}
