using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给你一个字符串 s 和一个字符 c ，且 c 是 s 中出现过的字符。
    /// 返回一个整数数组 answer ，其中 answer.length == s.length 且 answer[i] 是 s 中从下标 i 到离它 最近 的字符 c 的 距离 。
    /// 两个下标 i 和 j 之间的 距离 为 abs(i - j) ，其中 abs 是绝对值函数
    /// </summary>
    public class ShortestToChar
    {
        /// <summary>
        /// 两次扫描
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[] Shortest_To_Char(string s, char c)
        {
            int n = s.Length;
            int[] ans = new int[n];

            for (int i = 0, idx = -n; i < n; ++i)
            {
                if (s[i] == c)
                {
                    idx = i;
                }
                ans[i] = i - idx;
            }

            for (int i = n - 1, idx = 2 * n; i >= 0; --i)
            {
                if (s[i] == c)
                {
                    idx = i;
                }
                ans[i] = Math.Min(ans[i], idx - i);
            }
            return ans;
        }
    }
}
