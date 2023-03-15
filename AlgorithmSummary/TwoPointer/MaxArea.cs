using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 盛最多水的容器
    /// </summary>
    public class MaxArea
    {
        public int Max_Area(int[] height)
        {
            int maxArea = 0;
            int i = 0, j = height.Length - 1;
            while(i < j)
            {
                //将较短的边向中间移动
                int cur;
                if (height[i] < height[j])
                {
                    maxArea = Math.Max(maxArea, height[i] * (j - i));
                    //跳过比当前边短的元素
                    cur = i;
                    while (i < j && height[cur] >= height[i + 1])
                    {
                        i++;
                    }
                    i++;
                }
                else
                {
                    maxArea = Math.Max(maxArea, height[j] * (j - i));
                    cur = j;
                    while (i < j && height[cur] >= height[j - 1])
                    {
                        j--;
                    }
                    j--;
                }
            }

            return maxArea;
        }
    }
}
