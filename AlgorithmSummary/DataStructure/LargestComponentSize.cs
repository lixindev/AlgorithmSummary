using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.DataStructure
{
    /// <summary>
    /// 给定一个由不同正整数的组成的非空数组 nums ，考虑下面的图：
    /// 有 nums.length 个节点，按从 nums[0] 到 nums[nums.length - 1] 标记；
    /// 只有当 nums[i] 和 nums[j] 共用一个大于 1 的公因数时，nums[i] 和 nums[j]之间才有一条边。
    /// 返回 图中最大连通组件的大小 。
    /// </summary>
    public class LargestComponentSize
    {
        /// <summary>
        /// 并查集 + 按秩合并 + 质因数分解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Largest_Component_Size(int[] nums)
        {
            int m = nums.Max();
            UnionFind uf = new UnionFind(m + 1);
            foreach (int num in nums)
            {
                //质因数分解
                for (int i = 2; i * i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        uf.Union(num, i);
                        uf.Union(num, num / i);
                    }
                }
            }
            int[] counts = new int[m + 1];
            int ans = 0;
            foreach (int num in nums)
            {
                int root = uf.Find(num);
                counts[root]++;
                ans = Math.Max(ans, counts[root]);
            }
            return ans;
        }
    }

    /// <summary>
    /// 并查集实现
    /// </summary>
    public class UnionFind
    {
        //使用数组表达树的结构
        int[] parent;
        //树的秩
        int[] rank;

        public UnionFind(int n)
        {
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
            rank = new int[n];
        }

        public void Union(int x, int y)
        {
            int rootx = Find(x);
            int rooty = Find(y);
            //未合并
            if (rootx != rooty)
            {
                //按秩合并
                //两棵树秩大小不同，合并后秩的大小为较大的秩
                if (rank[rootx] > rank[rooty])
                {
                    parent[rooty] = rootx;
                }
                else if (rank[rootx] < rank[rooty])
                {
                    parent[rootx] = rooty;
                }
                //两棵树秩大小相同，秩大小加一
                else
                {
                    parent[rooty] = rootx;
                    rank[rootx]++;
                }
            }
        }

        //查找根节点
        public int Find(int x)
        {
            //路径压缩
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }
    }
}
