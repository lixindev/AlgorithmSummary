using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.BFS
{
    /// <summary>
    /// 给定一个二维网格 grid ，其中：
    /// '.' 代表一个空房间
    /// '#' 代表一堵墙
    /// '@' 是起点
    /// 小写字母代表钥匙
    /// 大写字母代表锁
    /// 我们从起点开始出发，一次移动是指向四个基本方向之一行走一个单位空间。
    /// 我们不能在网格外面行走，也无法穿过一堵墙。如果途经一个钥匙，我们就把它捡起来。除非我们手里有对应的钥匙，否则无法通过锁。
    /// 假设 k 为 钥匙/锁 的个数，且满足 1 <= k <= 6，字母表中的前 k 个字母在网格中都有自己对应的一个小写和一个大写字母。
    /// 换言之，每个锁有唯一对应的钥匙，每个钥匙也有唯一对应的锁。另外，代表钥匙和锁的字母互为大小写并按字母顺序排列。
    /// 返回获取所有钥匙所需要的移动的最少次数。如果无法获取所有钥匙，返回 -1 。
    /// </summary>
    public class ShortestPathAllKeys
    {
        //定义移动的四个方向
        static int[][] dirs = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

        //在最短路径上也不可能存在如下的情况：我们经过了某个房间两次，并且这两次我们拥有钥匙的情况是完全一致的。
        public int Shortest_Path_All_Keys(string[] grid)
        {
            int m = grid.Length, n = grid[0].Length;          
            int sx = 0, sy = 0;
            IDictionary<char, int> keyToIndex = new Dictionary<char, int>();
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == '@')
                    {
                        //起点
                        sx = i;
                        sy = j;
                    }
                    else if (char.IsLower(grid[i][j]))
                    {
                        if (!keyToIndex.ContainsKey(grid[i][j]))
                        {
                            int idx = keyToIndex.Count;
                            keyToIndex.Add(grid[i][j], idx);
                        }
                    }
                }
            }

            //dist[i][j][k] i和j为坐标，k为二进制标志，代表所拥有的钥匙，如“0001”代表一共有4把钥匙，目前有1号钥匙。(状态压缩)
            //dist[i][j][k] 的值用于统计步数，初始值设为-1，表示没有到达过
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            int[][][] dist = new int[m][][];
            for (int i = 0; i < m; ++i)
            {
                dist[i] = new int[n][];
                for (int j = 0; j < n; ++j)
                {
                    int len = 1 << keyToIndex.Count;
                    dist[i][j] = new int[len];
                    for (int k = 0; k < len; k++)
                    {
                        dist[i][j][k] = -1;
                    }
                }
            }
            queue.Enqueue(new Tuple<int, int, int>(sx, sy, 0));
            //定义初始状态，从起点出发，无钥匙
            dist[sx][sy][0] = 0;
            while (queue.Count > 0)
            {
                Tuple<int, int, int> tuple = queue.Dequeue();
                int x = tuple.Item1, y = tuple.Item2, mask = tuple.Item3;
                for (int i = 0; i < 4; ++i)
                {
                    int nx = x + dirs[i][0];
                    int ny = y + dirs[i][1];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] != '#')
                    {
                        if (grid[nx][ny] == '.' || grid[nx][ny] == '@')
                        {
                            if (dist[nx][ny][mask] == -1)
                            {
                                //从来没有到达过，步数+1，坐标入队
                                dist[nx][ny][mask] = dist[x][y][mask] + 1;
                                queue.Enqueue(new Tuple<int, int, int>(nx, ny, mask));
                            }
                        }
                        else if (char.IsLower(grid[nx][ny]))
                        {
                            int idx = keyToIndex[grid[nx][ny]];
                            if (dist[nx][ny][mask | (1 << idx)] == -1)
                            {
                                //坐标为钥匙且没有到达过，步数+1
                                dist[nx][ny][mask | (1 << idx)] = dist[x][y][mask] + 1;
                                //已经拿到所有钥匙，返回结果
                                if ((mask | (1 << idx)) == (1 << keyToIndex.Count) - 1)
                                {
                                    return dist[nx][ny][mask | (1 << idx)];
                                }
                                //坐标入队，更新钥匙状态
                                queue.Enqueue(new Tuple<int, int, int>(nx, ny, mask | (1 << idx)));
                            }
                        }
                        else
                        {
                            int idx = keyToIndex[char.ToLower(grid[nx][ny])];
                            if ((mask & (1 << idx)) != 0 && dist[nx][ny][mask] == -1)
                            {
                                //坐标为锁，拥有对应的锁且没有到达过，步数+1，坐标入队
                                dist[nx][ny][mask] = dist[x][y][mask] + 1;
                                queue.Enqueue(new Tuple<int, int, int>(nx, ny, mask));
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}
