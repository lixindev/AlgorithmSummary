using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class GenerateParenthesis
    {
        private IList<string> ans = new List<string>();
        public IList<string> Generate_Parenthesis(int n)
        {
            Generator(0, 0, n, "");
            return ans;
        }

        private void Generator(int left, int right, int n, string str)
        {
            if (right == n)
            {
                ans.Add(str);
                return;
            }

            if (left > right)
            {               
                Generator(left, right + 1, n, str + ")");              
            }
            if (left < n)
            {               
                Generator(left + 1, right, n, str + "(");             
            }
        }
    }
}