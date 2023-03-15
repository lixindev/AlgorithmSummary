using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给你一个整数数组 nums 和一个整数 k ，请你返回子数组内所有元素的乘积严格小于 k 的连续子数组的数目。
    /// </summary>
    public class NumSubarrayProductLessThanK
    {
        /// <summary>
        /// 滑动窗口法求解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Num_Subarray_Product_Less_Than_K(int[] nums, int k)
        {
            int ans = 0;
            int r = 1;
            int n = nums.Length;
            int left = 0, right = 0;
            while (right < n)
            {
                //窗口右移，符合条件
                while (right < n && r * nums[right] < k)
                {
                    r *= nums[right];
                    ans += right - left + 1;
                    right++;
                }
                if (right == n) break;
                r *= nums[right];
                //不符合条件窗口左移
                while (r >= k && left <= right)
                {
                    r /= nums[left];
                    left++;
                }
                ans += right - left + 1;
                right++;
            }

            return ans;
        }
    }
}
