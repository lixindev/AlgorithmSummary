using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class Divide
    {
        /// <summary>
        /// 快速乘
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Two_Divide(int dividend, int divisor)
        {
            // 考虑被除数为最小值的情况
            if (dividend == int.MinValue)
            {
                if (divisor == 1)
                {
                    return int.MinValue;
                }
                if (divisor == -1)
                {
                    return int.MaxValue;
                }
            }
            // 考虑除数为最小值的情况
            if (divisor == int.MinValue)
            {
                return dividend == int.MinValue ? 1 : 0;
            }
            // 考虑被除数为 0 的情况
            if (dividend == 0)
            {
                return 0;
            }

            // 一般情况，使用类二分查找
            // 将所有的正数取相反数，这样就只需要考虑一种情况
            bool rev = false;
            if (dividend > 0)
            {
                dividend = -dividend;
                rev = !rev;
            }
            if (divisor > 0)
            {
                divisor = -divisor;
                rev = !rev;
            }

            int[] candidates = new int[33];            
            int index = 0;
            candidates[index] = divisor;
            //candidates数组记录累积加和的值，使用dividend - candidates[index]防止越界
            while (candidates[index] >= dividend - candidates[index])
            {
                candidates[index + 1] = candidates[index] + candidates[index];              
                ++index;
            }
            int ans = 0;
            for (int i = index; i >= 0; --i)
            {
                if (candidates[i] >= dividend)
                {
                    ans += 1 << i;
                    dividend -= candidates[i];
                }
            }

            return rev ? -ans : ans;
        }
    }
}
