using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class SortArrayByParity
    {
        /// <summary>
        /// 给你一个整数数组 nums，将 nums 中的的所有偶数元素移动到数组的前面，后跟所有奇数元素。
        /// 双指针 + 原址排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] Sort_Array_By_Parity(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                while (left < right && nums[left] % 2 == 0)
                {
                    left++;
                }

                while (left < right && nums[right] % 2 == 1)
                {
                    right--;
                }

                if (left < right)
                {
                    int swap = nums[left];
                    nums[left] = nums[right];
                    nums[right] = swap;
                    left++;
                    right--;
                }
            }

            return nums;
        }
    }
}
