using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给定两个字符串 text1 和 text2，返回这两个字符串的最长 公共子序列 的长度。如果不存在 公共子序列 ，返回 0 。
    /// 一个字符串的 子序列 是指这样一个新的字符串：它是由原字符串在不改变字符的相对顺序的情况下删除某些字符（也可以不删除任何字符）后组成的新字符串。
    /// </summary>
    public class LongestCommonSubsequence
    {
        /// <summary>
        /// 假设dp[i][j]表示text1[0 : i]和text2[0 : j]的最长公共子序列的长度
        /// 初始状态：dp[0][j] = 0 且 dp[i][0] = 0
        /// 当text1[i−1] = text2[j−1]时，dp[i][j] = dp[i - 1][j - 1] + 1;
        /// 当text1[i−1] != text2[j−1]时，dp[i][j] = Max(dp[i][j - 1], dp[i - 1][j]);
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int Longest_Common_Subsequence(string text1, string text2)
        {
            int m = text1.Length, n = text2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            return dp[m, n];
        }
    }
}
