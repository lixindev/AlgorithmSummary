using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class MyPow
    {
        /// <summary>
        /// 快速幂法求x的n次方
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double My_Pow(double x, int n)
        {
            long num = n;
            return num >= 0 ? QuickMul_Candidates(x, num) : 1.0 / QuickMul_Candidates(x, -num);
        }

        //倒推法
        private double QuickMul(double x, long n)
        {
            double ans = 1.0;          
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    ans *= x;
                }
                x *= x;
                n /= 2;
            }

            return ans;
        }

        /// <summary>
        /// 使用记录实现快速幂算法，更具有参考价值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private double QuickMul_Candidates(double x, long n)
        {
            double[] candidates = new double[35];
            int index = 0;
            candidates[index] = x;
            double ans = 1.0;
            //candidates数组记录累积乘积的值
            while ((n >> index + 1) >= 1)
            {
                candidates[index + 1] = candidates[index] * candidates[index];              
                ++index;
            }

            for (int j = index; j >= 0; j--)
            {
                if (n >= (1 << j))
                {
                    ans *= candidates[j];
                    n -= (1 << j);
                }
            }

            return ans;
        }
    }
}
