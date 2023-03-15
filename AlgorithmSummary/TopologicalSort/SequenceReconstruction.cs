using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 给定一个长度为 n 的整数数组 nums ，其中 nums 是范围为 [1，n] 的整数的排列。还提供了一个 2D 整数数组 sequences ，其中 sequences[i] 是 nums 的子序列。
/// 检查 nums 是否是唯一的最短 超序列 。最短 超序列 是 长度最短 的序列，并且所有序列 sequences[i] 都是它的子序列。
/// 对于给定的数组 sequences ，可能存在多个有效的超序列。
/// 如果 nums 是序列的唯一最短 超序列 ，则返回 true ，否则返回 false 。
/// </summary>
namespace AlgorithmSummary
{
    /// <summary>
    /// 拓扑排序
    /// </summary>
    public class SequenceReconstruction
    {
        //将问题转化为使用sequences数组，通过拓扑排序构造最短超序列
        public bool Sequence_Reconstruction(int[] nums, int[][] sequences)
        {
            int n = nums.Length;
            //记录每个节点的入度
            int[] indegrees = new int[n + 1];
            //表示图，记录每个节点的后续节点集合
            ISet<int>[] graph = new ISet<int>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new HashSet<int>();
            }
            foreach (int[] sequence in sequences)
            {
                int size = sequence.Length;
                for (int i = 1; i < size; i++)
                {
                    int prev = sequence[i - 1], next = sequence[i];
                    if (graph[prev].Add(next))
                    {
                        indegrees[next]++;
                    }
                }
            }
            Queue<int> queue = new Queue<int>();
            //从入度为0的节点开始遍历
            for (int i = 1; i <= n; i++)
            {
                if (indegrees[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }
            while (queue.Count > 0)
            {
                //拓扑排序存在多个结果，返回false
                if (queue.Count > 1)
                {
                    return false;
                }
                //节点出队，后续节点入度减1
                int num = queue.Dequeue();
                ISet<int> set = graph[num];
                foreach (int next in set)
                {
                    indegrees[next]--;
                    //若入度为0，直接入队
                    if (indegrees[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }
            return true;
        }
    }
}
