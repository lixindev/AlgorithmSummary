using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    public class NetworkBecomesIdle
    {
        /// <summary>
        /// 使用二维数组表示图，如何做广度优先遍历
        /// </summary>
        /// <param name="edges">使用二维数组表示图的所有边</param>
        /// <param name="patience"></param>
        /// <returns></returns>
        public int Network_Becomes_Idle(int[][] edges, int[] patience)
        {
            int max = 0;
            //访问过的节点
            bool[] visited = new bool[patience.Length];
            List<int>[] array = new List<int> [patience.Length];          
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            visited[0] = true;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new List<int>();
            }

            for (int i = 0; i < edges.Length; i++)
            {
                array[edges[i][0]].Add(edges[i][1]);
                array[edges[i][1]].Add(edges[i][0]);
            }

            int distance = 1;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                while (count > 0)
                {
                    int top = queue.Dequeue();
                    foreach (int i in array[top])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            queue.Enqueue(i);
                            int cost;
                            if (patience[i] != 0 && patience[i] < distance * 2)
                            {
                                if ((distance * 2) % patience[i] == 0)
                                {
                                    cost = distance * 4 - patience[i];
                                }
                                else
                                {
                                    cost = distance * 4 - ((distance * 2) % patience[i]);
                                }
                            }
                            else
                            {
                                cost = distance * 2;
                            }
                            max = Math.Max(max, cost);
                        }
                    }
                    count--;
                }
                distance++;
            }

            return max + 1;
        }
    }
}
