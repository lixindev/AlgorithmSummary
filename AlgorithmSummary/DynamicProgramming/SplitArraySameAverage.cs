using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给定你一个整数数组 nums
    /// 我们要将 nums 数组中的每个元素移动到 A 数组 或者 B 数组中，使得 A 数组和 B 数组不为空，并且 average(A) == average(B) 。
    /// 如果可以完成则返回true ， 否则返回 false  。
    /// </summary>
    public class SplitArraySameAverage
    {
        /// <summary>
        /// 动态规划 
        /// 我们设 dp[i][x]表示当前已从数组 nums 取出 i 个元素构成的和为 x 的可能性：
        /// 如果 dp[i][x]=true，表示当前已经遍历过的元素中可以取出 i 个元素构成的和为 x；
        /// 如果 dp[i][x]=false，表示当前已经遍历过的元素中不存在取出 i 个元素的和等于 x；
        /// sum(A)/k = sum(nums)/n,可以变换为: sum(A)×n=sum(nums)×k
        /// 所以我们只需要找到一个元素个数为 k 的子集 A 满足上述条件即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool Split_Array_Same_Average(int[] nums)
        {
            if (nums.Length == 1)
            {
                return false;
            }
            int n = nums.Length, m = n / 2;
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }
            //剪枝，sum(A)×n=sum(nums)×k 可推导出 [sum(nums)×k] mod n = 0
            bool isPossible = false;
            for (int i = 1; i <= m; i++)
            {
                if (sum * i % n == 0)
                {
                    isPossible = true;
                    break;
                }
            }
            if (!isPossible)
            {
                return false;
            }
            ISet<int>[] dp = new ISet<int>[m + 1];
            for (int i = 0; i <= m; i++)
            {
                dp[i] = new HashSet<int>();
            }
            //长度为0的序列，和只能为0
            dp[0].Add(0);
            foreach (int num in nums)
            {
                //剪枝，由于两个数组必有一个数组长度小于等于n/2，所以只需要验证长度为n/2的序列即可，由后向前遍历
                for (int i = m; i >= 1; i--)
                {
                    foreach (int x in dp[i - 1])
                    {
                        int curr = x + num;
                        if (curr * n == sum * i)
                        {
                            return true;
                        }
                        dp[i].Add(curr);
                    }
                }
            }
            return false;
        }
    }
}
