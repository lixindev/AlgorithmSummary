using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 两数和
    /// </summary>
    public class TwoSum
    {
        public int[] Two_Sum(int[] nums, int target)
        {
            int[] ant = new int[2];
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    ant[0] = dict[nums[i]];
                    ant[1] = i;
                    break;
                }
                else if (!dict.ContainsKey(target - nums[i]))
                {
                    dict.Add(target - nums[i], i);
                }
            }

            return ant;
        }
    }
}
