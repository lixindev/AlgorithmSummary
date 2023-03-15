using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class KnapsackProblem
    {
        /// <summary>
        /// 0/1背包问题，dp[i, j]表示遍历到第i个物品，物品总重量不超过j，背包能放下的最大价值。
        /// 当j >= w[i]时，背包能放下第i件物品，dp[i, j] = Max(dp[i - 1, j], dp[i - 1, j - w[i]] + v[i])
        /// 否则背包不能放下第i件物品，dp[i, j] = dp[i - 1, j]
        /// </summary>
        /// <param name="w">重量数组</param>
        /// <param name="v">价值数组</param>
        /// <param name="n">物品数量</param>
        /// <param name="cw">背包容量</param>
        /// <returns></returns>
        public int Knapsack_Problem1(int[] w, int[] v, int n, int cw)
        {          
            int[,] dp = new int[n + 1, cw + 1];          
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= cw; j++)
                {
                    dp[i, j] = dp[i - 1, j];

                    if (j >= w[i])
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - w[i]] + v[i]);
                    }
                }
            }

            return dp[n, cw];
        }

        /// <summary>
        /// 0/1背包问题一维数组优化，dp[j]表示物品总重量不超过j，背包能放下的最大价值。
        /// dp[j] = Max(dp[j], dp[j - w[i] + v[i]])
        /// 外层遍历物品数组
        /// 内层倒序遍历容量
        /// </summary>
        /// <param name="w"></param>
        /// <param name="v"></param>
        /// <param name="n"></param>
        /// <param name="cw"></param>
        /// <returns></returns>
        public int Knapsack_Problem2(int[] w, int[] v, int n, int cw)
        {
            int[] dp = new int[cw + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = cw; j >= w[i] ; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w[i]] + v[i]);
                }
            }

            return dp[cw];
        }

        /// <summary>
        /// 完全背包问题一维数组优化，dp[j]表示物品总重量不超过j，背包能放下的最大价值。
        /// dp[j] = Max(dp[j], dp[j - w[i] + v[i]])
        /// 外层遍历物品数组
        /// 内层正序遍历容量
        /// </summary>
        /// <param name="w"></param>
        /// <param name="v"></param>
        /// <param name="n"></param>
        /// <param name="cw"></param>
        /// <returns></returns>
        public int Knapsack_Problem3(int[] w, int[] v, int n, int cw)
        {
            int[] dp = new int[cw + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = w[i]; j <= cw; j++)
                {
                    dp[j] = Math.Max(dp[j], dp[j - w[i]] + v[i]);
                }
            }

            return dp[cw];
        }
    }
}
