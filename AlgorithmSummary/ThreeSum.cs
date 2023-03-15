using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class ThreeSum
    {
        /// <summary>
        /// 先完成正序排序，然后取一个数nums[i], i从0 -> nums.Length - 3
        /// 通过双指针 i+1 和 nums.Length - 1 得到结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Three_Sum(int[] nums)
        {
            nums = nums.OrderBy(n => n).ToArray();
            List<IList<int>> ant = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    int left = i + 1, right = nums.Length - 1;
                    int rest = 0 - nums[i];

                    while(left < right)
                    {
                        if (nums[left] + nums[right] == rest)
                        {
                            ant.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[left - 1]) right--;
                            left++;
                            right--;
                        }
                        else if (nums[left] + nums[right] < rest)
                        {
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            left++;
                        }
                        else
                        {
                            while (left < right && nums[right] == nums[left - 1]) right--;
                            right--;
                        }
                    }
                }
            }

            return ant;
        }
    }
}
