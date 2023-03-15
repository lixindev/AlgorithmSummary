using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.GeometryAlgorithm
{
    /// <summary>
    /// 获得点集的凸包
    /// </summary>
    public class OuterTrees
    {
        public int[][] Outer_Trees(int[][] trees)
        {
            int n = trees.Length;
            if (n < 4)
            {
                return trees;
            }
            int start = 0;
            //找到 y 最小的点 bottom
            for (int i = 0; i < n; i++)
            {
                if (trees[i][1] < trees[start][1])
                {
                    start = i;
                }
            }
            Swap(trees, start, 0);
            Array.Sort(trees, (a, b) =>
            {
                int cross = Cross(trees[0], a, b);
                if (cross == 0)
                {
                    //共线的点按距离从小到大排列
                    return Distance(trees[0], a) - Distance(trees[0], b);
                }
                else
                {
                    return -cross;
                }
            });

            // 对于凸包最后且在同一条直线的元素按照距离从大到小进行排序
            int r = n - 1;
            while (r >= 0 && Cross(trees[0], trees[n - 1], trees[r]) == 0)
            {
                r--;
            }
            for (int l = r + 1, h = n - 1; l < h; l++, h--)
            {
                Swap(trees, l, h);
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 2; i < n; i++)
            {
                int top = stack.Pop();
                // 如果当前元素与栈顶的两个元素构成的向量顺时针旋转，则弹出栈顶元素 
                while (stack.Count > 0 && Cross(trees[stack.Peek()], trees[top], trees[i]) < 0)
                {
                    top = stack.Pop();
                }
                stack.Push(top);
                stack.Push(i);
            }

            int size = stack.Count;
            int[][] res = new int[size][];
            for (int i = 0; i < size; i++)
            {
                res[i] = trees[stack.Pop()];
            }
            return res;
        }

        /// <summary>
        /// 求叉积
        /// </summary>
        /// <param name="start">共同起点</param>
        /// <param name="p">向量p的终点</param>
        /// <param name="q">向量q的终点</param>
        /// <returns>若叉积大于0，p在q的顺时针方向；等于0则pq共线；小于0则p在q的逆时针方向</returns>
        public int Cross(int[] start, int[] p, int[] q)
        {
            return (p[0] - start[0]) * (q[1] - start[1]) - (q[0] - start[0]) * (p[1] - start[1]);
        }

        public int Distance(int[] p, int[] q)
        {
            return (p[0] - q[0]) * (p[0] - q[0]) + (p[1] - q[1]) * (p[1] - q[1]);
        }

        private void Swap(int[][] trees, int i, int j)
        {
            int temp0 = trees[i][0], temp1 = trees[i][1];
            trees[i][0] = trees[j][0];
            trees[i][1] = trees[j][1];
            trees[j][0] = temp0;
            trees[j][1] = temp1;
        } 
    }
}
