using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class WiggleSort
    {
        public void Wiggle_SortI(int[] nums)
        {
            int n = nums.Length;
            int[] arr = new int[n];
            Array.Copy(nums, arr, n);
            Array.Sort(arr);
            int x = (n + 1) / 2;
            for (int i = 0, j = x - 1, k = n - 1; i < n; i += 2, j--, k--)
            {
                //先将0-x的元素反转
                nums[i] = arr[j];
                if (i + 1 < n)
                {
                    //插入后方较大的数
                    nums[i + 1] = arr[k];
                }
            }
        }

        /// <summary>
        /// 三向切分
        /// </summary>
        /// <param name="nums"></param>
        public void Wiggle_SortII(int[] nums)
        {
            Random random = new Random();

            int n = nums.Length;
            int[] arr = new int[n];
            Array.Copy(nums, arr, n);
            Array.Sort(arr);
            int x = (n + 1) / 2;
            int mid = x - 1;
            //找到第mid大的值
            int key = new FindKthLargest().Find_Kth_Largest(nums, mid);
            //重新排列数组
            for (int k = 0, i = 0, j = n - 1; k <= j; k++)
            {
                if (nums[k] > key)
                {
                    while (j > k && nums[j] > key)
                    {
                        j--;
                    }
                    int swap = nums[k];
                    nums[k] = nums[j];
                    nums[j] = swap;
                    j--;
                }
                if (nums[k] < key)
                {
                    int swap = nums[k];
                    nums[k] = nums[i];
                    nums[i] = swap;
                    i++;
                }
            }
            for (int i = 0, j = x - 1, k = n - 1; i < n; i += 2, j--, k--)
            {
                //先将0-x的元素反转
                nums[i] = arr[j];
                if (i + 1 < n)
                {
                    //插入后方较大的数
                    nums[i + 1] = arr[k];
                }
            }
        }
    }
}
