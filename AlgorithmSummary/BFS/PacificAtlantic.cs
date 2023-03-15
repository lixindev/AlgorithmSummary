using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 有一个 m × n 的矩形岛屿，与 太平洋 和 大西洋 相邻。 “太平洋” 处于大陆的左边界和上边界，而 “大西洋” 处于大陆的右边界和下边界。
    /// 这个岛被分割成一个由若干方形单元格组成的网格。给定一个 m x n 的整数矩阵 heights， heights[r][c] 表示坐标(r, c) 上单元格 高于海平面的高度 。
    /// 岛上雨水较多，如果相邻单元格的高度 小于或等于 当前单元格的高度，雨水可以直接向北、南、东、西流向相邻单元格。水可以从海洋附近的任何单元格流入海洋。
    /// 返回网格坐标 result的 2D 列表 ，其中 result[i] = [ri, ci]表示雨水从单元格(ri, ci) 流动 既可流向太平洋也可流向大西洋 。
    /// </summary>
    public class PacificAtlantic
    {
        /// <summary>
        /// 多源广度优先遍历，反向遍历矩阵
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public IList<IList<int>> Pacific_Atlantic(int[][] heights)
        {
            List<IList<int>> ans = new List<IList<int>>();
            int m = heights.Length;
            int n = heights[0].Length;
            if (m == 1 && n == 1)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        ans.Add(new List<int> { i, j });
                    }
                }

                return ans;
            }
            //状态压缩
            int pacific = 1;
            int atlantic = 1 << 1;
            int[][] directions = new int[4][];
            directions[0] = new int[] { 0, 1 };
            directions[1] = new int[] { 0, -1 };
            directions[2] = new int[] { 1, 0 };
            directions[3] = new int[] { -1, 0 };
            int[] visited = new int[200201];

            Queue<int[]> queue = new Queue<int[]>();
            //上边、左边元素入队，遍历流入太平洋的元素
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(new int[] { 0, i });
                visited[i] = visited[i] | pacific;
            }
            for (int i = 1; i < m; i++)
            {
                queue.Enqueue(new int[] { i, 0 });
                visited[i * 1000] = visited[i * 1000] | pacific;
            }

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                foreach (int[] direction in directions)
                {
                    int y = cur[0] + direction[0];
                    int x = cur[1] + direction[1];
                    if (x >= 0 && x < n && y >= 0 && y < m && heights[y][x] >= heights[cur[0]][cur[1]] && visited[y * 1000 + x] != pacific)
                    {
                        queue.Enqueue(new int[] { y, x });
                        visited[y * 1000 + x] = visited[y * 1000 + x] | pacific;
                    }
                }
            }

            ////下边、右边元素入队，遍历流入大西洋的元素
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(new int[] { m - 1, i });
                visited[(m - 1) * 1000 + i] = visited[(m - 1) * 1000 + i] | atlantic;
                if (visited[(m - 1) * 1000 + i] == (pacific | atlantic))
                {
                    ans.Add(new List<int> { m - 1, i });
                }
            }
            for (int i = 0; i < m - 1; i++)
            {
                queue.Enqueue(new int[] { i, n - 1 });
                visited[i * 1000 + n - 1] = visited[i * 1000 + n - 1] | atlantic;
                if (visited[i * 1000 + n - 1] == (pacific | atlantic))
                {
                    ans.Add(new List<int> { i, n - 1 });
                }
            }

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                foreach (int[] direction in directions)
                {
                    int y = cur[0] + direction[0];
                    int x = cur[1] + direction[1];
                    if (x >= 0 && x < n && y >= 0 && y < m && heights[y][x] >= heights[cur[0]][cur[1]] && (visited[y * 1000 + x] & atlantic) != atlantic)
                    {
                        queue.Enqueue(new int[] { y, x });
                        visited[y * 1000 + x] = visited[y * 1000 + x] | atlantic;
                        if (visited[y * 1000 + x] == (pacific | atlantic))
                        {
                            ans.Add(new List<int> { y, x });
                        }
                    }
                }
            }

            return ans;
        }
    }
}
