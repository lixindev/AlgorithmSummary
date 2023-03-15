using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 有 A 和 B 两种类型 的汤。一开始每种类型的汤有 n 毫升。有四种分配操作：
    /// 提供 100ml 的 汤A 和 0ml 的 汤B 。
    /// 提供 75ml 的 汤A 和 25ml 的 汤B 。
    /// 提供 50ml 的 汤A 和 50ml 的 汤B 。
    /// 提供 25ml 的 汤A 和 75ml 的 汤B 。
    /// 当我们把汤分配给某人之后，汤就没有了。每个回合，我们将从四种概率同为 0.25 的操作中进行分配选择。
    /// 如果汤的剩余量不足以完成某次操作，我们将尽可能分配。当两种类型的汤都分配完时，停止操作。
    /// 需要返回的值： 汤A 先分配完的概率 +  汤A和汤B 同时分配完的概率 / 2。返回值在正确答案 10-5 的范围内将被认为是正确的。
    /// </summary>
    public class SoupServings
    {
        //动态规划
        public double Soup_Servings(int n)
        {
            n = (int)Math.Ceiling((double)n / 25);
            //n >= 179 时，概率大于0.99999
            if (n >= 179)
            {
                return 1.0;
            }
            //设 dp(i,j) 表示汤 A 和汤 B 分别剩下 i 和 j 份时所求的概率值，即汤 A 先分配完的概率 + 汤 A 和汤 B 同时分配完的概率除以 2 。
            //状态转移方程为：dp(i,j)= 1 / 4 × (dp(i−4, y) + dp(i−3, y−1) + dp(i−2, y−2) + dp(i−1, y−3))            
            double[][] dp = new double[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new double[n + 1];
            }
            //i = 0 且 j = 0 时 AB同时分配完，为0.5
            dp[0][0] = 0.5;
            for (int i = 1; i <= n; i++)
            {
                //i = 0 且 j > 0 时， A先分配完，为1
                dp[0][i] = 1.0;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i][j] = (dp[Math.Max(0, i - 4)][j] + dp[Math.Max(0, i - 3)][Math.Max(0, j - 1)] + dp[Math.Max(0, i - 2)][Math.Max(0, j - 2)] + dp[Math.Max(0, i - 1)][Math.Max(0, j - 3)]) / 4.0;
                }
            }
            return dp[n][n];
        }
    }
}
