using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class ReverseNumber
    {
        public int Reverse(int x)
        {
            int ant = 0;
            while(x != 0){
                int rest = x % 10;
                x /= 10;
                if (ant > int.MaxValue / 10 || (ant == int.MaxValue / 10 && rest > 7))
                {
                    return 0;
                } 
                else if (ant < int.MinValue || (ant == int.MinValue && rest < -8))
                {
                    return 0;
                }
                else
                {
                    ant += ant * 10 + rest;
                }
            }

            return ant;
        }
    }
}
