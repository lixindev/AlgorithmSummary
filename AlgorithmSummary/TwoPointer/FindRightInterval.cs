using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.TwoPointer
{
    /// <summary>
    /// 给你一个区间数组 intervals ，其中 intervals[i] = [starti, endi] ，且每个 starti 都 不同。
    /// 区间 i 的 右侧区间 可以记作区间 j ，并满足 startj >= endi ，且 startj 最小化 。
    /// 返回一个由每个区间 i 的 右侧区间 在 intervals 中对应下标组成的数组。如果某个区间 i 不存在对应的 右侧区间 ，则下标 i 处的值设为 -1 。
    /// </summary>
    public class FindRightInterval
    {      
        public int[] Find_Right_Interval(int[][] intervals)
        {
            int n = intervals.Length;
            int[][] startIntervals = new int[n][];
            int[][] endIntervals = new int[n][];
            for (int i = 0; i < n; i++)
            {
                startIntervals[i] = new int[2];
                startIntervals[i][0] = intervals[i][0];
                startIntervals[i][1] = i;
                endIntervals[i] = new int[2];
                endIntervals[i][0] = intervals[i][1];
                endIntervals[i][1] = i;
            }
            Array.Sort(startIntervals, (o1, o2) => o1[0] - o2[0]);
            Array.Sort(endIntervals, (o1, o2) => o1[0] - o2[0]);

            int[] ans = new int[n];
            //使用双指针得到结果
            for (int i = 0, j = 0; i < n; i++)
            {
                while (j < n && endIntervals[i][0] > startIntervals[j][0])
                {
                    j++;
                }
                if (j < n)
                {
                    ans[endIntervals[i][1]] = startIntervals[j][1];
                }
                else
                {
                    ans[endIntervals[i][1]] = -1;
                }
            }
            return ans;
        }
    }
}
