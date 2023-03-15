using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 你将得到一个整数数组 matchsticks ，其中 matchsticks[i] 是第 i 个火柴棒的长度。你要用 所有的火柴棍 拼成一个正方形。
    /// 你不能折断 任何一根火柴棒，但你可以把它们连在一起，而且每根火柴棒必须使用一次 。
    /// 如果你能使这个正方形，则返回 true ，否则返回 false 。
    /// </summary>
    public class Makesquare
    {
        /// <summary>
        /// 状态压缩+动态规划
        /// </summary>
        /// <param name="matchsticks"></param>
        /// <returns></returns>
        public bool Make_Square(int[] matchsticks)
        {
            int totalLen = matchsticks.Sum();
            if (totalLen % 4 != 0)
            {
                return false;
            }
            int len = totalLen / 4, n = matchsticks.Length;
            int[] dp = new int[1 << n];
            for (int i = 0; i < 1 << n; i++)
            {
                dp[i] = -1;
            }
            dp[0] = 0;
            //使用s存储火柴的使用状态，s的二进制第k位为1表示第k根火柴已被使用
            //初始状态为准备放入第一根火柴
            for (int s = 1; s < (1 << n); s++)
            {
                for (int k = 0; k < n; k++)
                {
                    //第k根火柴未被使用
                    if ((s & (1 << k)) == 0)
                    {
                        continue;
                    }
                    //s1表示未放入k之前的状态
                    int s1 = s ^ (1 << k);
                    if (dp[s1] >= 0 && dp[s1] + matchsticks[k] <= len)
                    {
                        //放入k
                        dp[s] = (dp[s1] + matchsticks[k]) % len;
                        break;
                    }
                }
            }
            return dp[(1 << n) - 1] == 0;
        }
    }
}
