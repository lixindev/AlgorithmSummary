using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 一位老师正在出一场由 n 道判断题构成的考试，每道题的答案为 true （用 'T' 表示）或者 false （用 'F' 表示）。
    /// 老师想增加学生对自己做出答案的不确定性，方法是 最大化 有 连续相同 结果的题数。（也就是连续出现 true 或者连续出现 false）。
    /// 给你一个字符串 answerKey ，其中 answerKey[i] 是第 i 个问题的正确结果。除此以外，还给你一个整数 k ，表示你能进行以下操作的最多次数：
    /// 每次操作中，将问题的正确答案改为 'T' 或者 'F' （也就是将 answerKey[i] 改为 'T' 或者 'F' ）。
    /// 请你返回在不超过 k次操作的情况下，最大 连续 'T' 或者 'F' 的数目。
    /// 求最大连续问题，优先考虑滑动窗口法。
    /// 先移动右指针，当操作数大于k时，移动左指针，直至操作数等于k，重复操作直至遍历完整个数组。
    /// </summary>
    public class MaxConsecutiveAnswers
    {
        public int Max_Consecutive_Answers(string answerKey, int k)
        {
            return Math.Max(MaxConsecutiveChar(answerKey, k, 'T'), MaxConsecutiveChar(answerKey, k, 'F'));
        }

        /// <summary>
        /// 寻找数组中除指定字符外的其他字符数量
        /// </summary>
        /// <param name="answerKey"></param>
        /// <param name="k"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public int MaxConsecutiveChar(string answerKey, int k, char ch)
        {
            int n = answerKey.Length;
            int ans = 0;
            for (int left = 0, right = 0, sum = 0; right < n; right++)
            {
                sum += answerKey[right] != ch ? 1 : 0;
                while (sum > k)
                {
                    sum -= answerKey[left++] != ch ? 1 : 0;
                }
                ans = Math.Max(ans, right - left + 1);
            }
            return ans;
        }
    }
}
