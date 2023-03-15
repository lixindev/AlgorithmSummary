using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给定整数数组 nums 和整数 k，请返回数组中第 k 个最大的元素。
    /// </summary>
    public class FindKthLargest
    {
        Random random = new Random();
        public int Find_Kth_Largest(int[] nums, int k)
        {
            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }

        private int QuickSelect(int[] s, int low, int high, int index)
        {
            int q = RandomPartition(s, low, high);
            if (q == index)
            {
                return s[q];
            }
            else
            {
                return q < index ? QuickSelect(s, q + 1, high, index) : QuickSelect(s, low, q - 1, index);
            }
        }

        private int RandomPartition(int[] s, int low, int high)
        {
            int i = random.Next(high - low + 1) + low;
            int swap = s[i];
            s[i] = s[high];
            s[high] = swap;
            return Partition1(low, high, s);
        }

        //快排思路
        private int Partition1(int low, int high, int[] s)
        {
            int key = s[high];
            //记录有多少个元素小于key
            int j = 0;
            int swap;
            //把小于key的元素放在前j索引
            for (int i = low; i < high; i++)
            {
                if (s[i] <= key)
                {
                    swap = s[i];
                    s[i] = s[low + j];
                    s[low + j] = swap;
                    j++;
                }
            }
            //把key放在分界点
            s[high] = s[low + j];
            s[low + j] = key;
            return low + j;
        }
    }
}
