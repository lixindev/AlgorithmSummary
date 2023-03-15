using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.Sort
{
    public class QuickSort
    {
        public void ExexSort(int[] s)
        {
            Quick_Sort(0, s.Length, s);
        }

        private void Quick_Sort(int low, int high, int[] s)
        {
            if (low < high)
            {
                int key = Partition1(low, high, s);
                Quick_Sort(low, key - 1, s);
                Quick_Sort(high + 1, high, s);
            }
        }

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

        private int Partition2(int low, int high, int[] s)
        {
            int key = s[low];
            while(low < high)
            {
                while(s[high] >= key && low < high)
                {
                    high--;
                }
                s[low] = s[high];
                while(s[low] <= key && low < high)
                {
                    low++;
                }
                s[high] = s[low];
            }
            s[low] = key;
            return low;
        }
    }
}
