using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 把字符串 s 看作 "abcdefghijklmnopqrstuvwxyz" 的无限环绕字符串
    /// 现在给定另一个字符串 p 。返回 s 中 不同 的 p 的 非空子串 的数量 。 
    /// </summary>
    public class FindSubstringInWraproundString
    {
        //我们可以定义 dp[α] 表示 p 中以字符 α 结尾且在 s 中的子串的最长长度，知道了最长长度，也就知道了不同的子串的个数。

        public int Find_Substring_In_Wrapround_String(string p)
        {
            int[] dp = new int[26];
            int k = 0;
            for (int i = 0; i < p.Length; ++i)
            {
                if (i > 0 && (p[i] - p[i - 1] + 26) % 26 == 1)
                { // 字符之差为 1 或 -25
                    ++k;
                }
                else
                {
                    k = 1;
                }
                dp[p[i] - 'a'] = Math.Max(dp[p[i] - 'a'], k);
            }
            return dp.Sum();
        }
    }
}
