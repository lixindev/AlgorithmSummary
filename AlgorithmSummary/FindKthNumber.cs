using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 字典序的第K小数字
    /// </summary>
    public class FindKthNumber
    {
        private int[] array;
        /// <summary>
        /// 方法一: 使用快排思维找第K小O(nlog n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKth_Number_1(int n, int k)
        {
            if (n == 1) return 1;
            array = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                array[i] = i;
            }
            int swap;
            int key = array[n], low = 1, high = n;
            while (low < high)
            {
                //由于数组有序，优化取key值的方法
                swap = array[(low + high) / 2];
                array[(low + high) / 2] = array[high];
                array[high] = swap;
                key = array[high];
                int pos = Partition(key, low, high);
                if (pos == k)
                {
                    return key;
                }
                if (pos > k)
                {
                    key = array[pos - 1];
                    high = pos - 1;
                }
                else
                {
                    key = array[high];
                    low = pos + 1;
                }
            }

            return key;
        }

        public int Partition(int key, int low, int high)
        {
            int j = 0;
            int swap;
            for (int i = low; i < high; i++)
            {
                if (array[i].ToString().CompareTo(key.ToString()) < 0)
                {
                    swap = array[i];
                    array[i] = array[low + j];
                    array[low + j] = swap;
                    j++;
                }
            }
            swap = array[low + j];
            array[low + j] = key;
            array[high] = swap;
            return low + j;
        }

        /// <summary>
        /// 使用字典树找第K小O(log n * log n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKth_Number_2(int n, int k)
        {
            int curr = 1;
            k--;
            while (k > 0)
            {
                int steps = GetSteps(curr, n);
                if (steps <= k)
                {
                    //当前节点不满足条件，继续找相邻节点
                    k -= steps;
                    curr++;
                }
                else
                {
                    //已子节点为根继续找
                    curr = curr * 10;
                    k--;
                }
            }
            return curr;
        }

        /// <summary>
        /// 获取根节点满足条件的子节点数量
        /// </summary>
        /// <param name="curr">根节点</param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetSteps(int curr, int n)
        {
            long steps = 0;
            long first = curr;
            long last = curr;
            while (first <= n)
            {
                steps += Math.Min(last, n) - first + 1;
                first = first * 10;
                last = last * 10 + 9;
            }
            return (int)steps;
        }
    }
}
