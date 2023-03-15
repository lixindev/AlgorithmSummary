using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.Sort
{
    public class InsertionSort
    {
        public void ExexSort(int[] s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                //在前i个已排序的元素中插入s[i]
                int key = s[i];
                int j = i - 1;
                while(j >= 0 && s[j] > key)
                {
                    s[j + 1] = s[j];
                    j--;
                }
                s[j + 1] = key;
            }
        }
    }
}
