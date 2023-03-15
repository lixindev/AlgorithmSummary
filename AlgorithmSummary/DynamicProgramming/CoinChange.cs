using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class CoinChange
    {
        /// <summary>
        /// 零钱兑换，类似完全背包问题。dp[j]表示凑出j金额需要的最少硬币个数，如果不能凑出值等于int.MaxValue
        /// dp[j] = Min(dp[j], dp[j - coins[i]] + 1)
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int Coin_Change(int[] coins, int amount)
        {
            long[] dp = new long[amount + 1];
            int n = coins.Length;
            for (int i = 0; i <= amount; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = coins[i]; j <= amount; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j - coins[i]] + 1);
                }
            }

            return (int)(dp[amount] == int.MaxValue ? -1 : dp[amount]);
        }
    }
}
