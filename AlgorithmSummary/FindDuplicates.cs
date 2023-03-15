using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给你一个长度为 n 的整数数组 nums ，其中 nums 的所有整数都在范围 [1, n] 内，且每个整数出现 一次 或 两次 。
    /// 请你找出所有出现 两次 的整数，并以数组形式返回。
    /// 你必须设计并实现一个时间复杂度为 O(n) 且仅使用常量额外空间的算法解决此问题。
    /// </summary>
    public class FindDuplicates
    {
        /// <summary>
        /// 遍历数组，若 nums[i] - 1 下标的数字为正数，加上负号，若为负数，则为第二次出现。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> Find_Duplicates(int[] nums)
        {
            List<int> ans = new List<int>();
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                //元素可能已经被加-号，需要取绝对值
                int value = Math.Abs(nums[i]);
                if (nums[value - 1] < 0)
                {
                    ans.Add(value);
                }
                else
                {
                    nums[value - 1] = -nums[value - 1];
                }
            }

            return ans;
        }
    }
}
