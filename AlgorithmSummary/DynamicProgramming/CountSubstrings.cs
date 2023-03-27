using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给你两个字符串 s 和 t ，请你找出 s 中的非空子串的数目，这些子串满足替换 一个不同字符 以后，
    /// 是 t 串的子串。换言之，请你找到 s 和 t 串中 恰好 只有一个字符不同的子字符串对的数目。
    /// 比方说， "computer" and "computation" 只有一个字符不同： 'e'/'a' ，所以这一对子字符串会给答案加 1 。
    /// </summary>
    public class CountSubstrings
    {
        /// <summary>
        /// 题目要求求出字符串 s 与字符串 t 的连续子串中只差一个字符的子串对的数目，此时我们可以枚举 s 与 t 中不相等的字符对 (s[i],t[j])，
        /// 并计算以 (s[i],t[j]) 构造的符合题意的子串数目即可。
        /// 在实际计算时，设以字符 s[i] 与字符 t[j] 为终点且左侧连续相等的最大长度为 dpl[i][j]
        /// 设以字符 s[i] 与字符 t[j] 为终点且右侧连续相等的最大长度为 dpr[i][j]
        /// 以字符对 (s[i], t[j])构造子串，子串数目为 dpl[i][j] + 1 * dpr[i][j] + 1
        /// 求dpl和dpr的思路可参考最长公共子序列（LongestCommonSubsequence）
        /// s[i] = t[j]时，dpl[i][j] = dpl[i - 1][j - 1] + 1, dpr[i][j] = dpr[i + 1][j + 1] + 1
        /// s[i] != t[j]时，dpl[i][j] = 0, dpr[i][j] = 0
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Count_Substrings(string s, string t)
        {
            int m = s.Length, n = t.Length;
            int[][] dpl = new int[m + 1][];
            int[][] dpr = new int[m + 1][];
            for (int i = 0; i <= m; i++)
            {
                dpl[i] = new int[n + 1];
                dpr[i] = new int[n + 1];
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dpl[i + 1][j + 1] = s[i] == t[j] ? (dpl[i][j] + 1) : 0;
                }
            }
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    dpr[i][j] = s[i] == t[j] ? (dpr[i + 1][j + 1] + 1) : 0;
                }
            }
            int ans = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (s[i] != t[j])
                    {
                        ans += (dpl[i][j] + 1) * (dpr[i + 1][j + 1] + 1);
                    }
                }
            }
            return ans;
        }
    }
}
