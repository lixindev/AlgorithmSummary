using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 汽车从起点出发驶向目的地，该目的地位于出发位置东面 target 英里处。
    /// 沿途有加油站，每个 station[i] 代表一个加油站，它位于出发位置东面 station[i][0] 英里处，并且有 station[i][1] 升汽油。
    /// 假设汽车油箱的容量是无限的，其中最初有 startFuel 升燃料。它每行驶 1 英里就会用掉 1 升汽油。
    /// 当汽车到达加油站时，它可能停下来加油，将所有汽油从加油站转移到汽车中。
    /// 为了到达目的地，汽车所必要的最低加油次数是多少？如果无法到达目的地，则返回 -1 。
    /// 注意：如果汽车到达加油站时剩余燃料为 0，它仍然可以在那里加油。如果汽车到达目的地时剩余燃料为 0，仍然认为它已经到达目的地。
    /// </summary>
    public class MinRefuelStops
    {
        /// <summary>
        /// 贪心算法
        /// </summary>
        /// <param name="target"></param>
        /// <param name="startFuel"></param>
        /// <param name="stations"></param>
        /// <returns></returns>
        public int Min_Refuel_Stops1(int target, int startFuel, int[][] stations)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            int ans = 0, prev = 0, fuel = startFuel;
            int n = stations.Length;
            for (int i = 0; i <= n; i++)
            {
                int curr = i < n ? stations[i][0] : target;
                fuel -= curr - prev;
                //汽油不够则从队列中取最大的汽油站加油
                while (fuel < 0 && pq.Count > 0)
                {
                    fuel -= pq.Dequeue();
                    ans++;
                }
                //若station[i]不可达，则不可能到达目标
                if (fuel < 0)
                {
                    return -1;
                }
                //若station[i]可达，则将station[i]加入队列
                if (i < n)
                {
                    pq.Enqueue(-stations[i][1]);
                    prev = curr;
                }
            }
            return ans;
        }

        /// <summary>
        /// 动态规划
        /// dp[i]表示加油i次，最多可以走多远
        /// </summary>
        /// <param name="target"></param>
        /// <param name="startFuel"></param>
        /// <param name="stations"></param>
        /// <returns></returns>
        public int Min_Refuel_Stops2(int target, int startFuel, int[][] stations)
        {
            int n = stations.Length;
            long[] dp = new long[n + 1];
            dp[0] = startFuel;

            //外层遍历加油站
            for (int i = 0; i < n; i++)
            {
                //内层倒序遍历加油站油量
                for (int j = i; j >= 0; j--)
                {
                    //判断加油站i是否可达
                    if (dp[j] >= stations[i][0])
                    {
                        dp[j + 1] = Math.Max(dp[j + 1], dp[j] + stations[i][0]);
                    }
                }
            }

            for (int i = 0; i <= n; i++)
            {
                if (dp[i] >= target)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
