using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给你一个可能含有 重复元素 的整数数组 nums ，请你随机输出给定的目标数字 target 的索引。你可以假设给定的数字一定存在于数组中。
    /// </summary>
    public class RandomIndex
    {
        private int[] nums;
        private Random r;
        public RandomIndex(int[] nums)
        {
            this.nums = nums;
            r = new Random();
        }

        /// <summary>
        /// 水塘抽样法
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Pick(int target)
        {
            int ans = 0;
            int n = nums.Length;
            
            for (int i = 0, count = 0; i < n; i++)
            {
                if (nums[i] == target)
                {
                    count++;
                    if (r.Next(count) == 0)
                    {
                        ans = i;
                    }                  
                }
            }
            return ans;
        }
    }
}
