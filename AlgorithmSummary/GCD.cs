using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// //辗转相除求最大公约数
    /// </summary>
    public class GCD
    {
        public int GetGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int rest = a % b;
            while (rest != 0)
            {              
                a = b;
                b = rest;
                rest = a % b;
            }
            return b;
        }
    }
}
