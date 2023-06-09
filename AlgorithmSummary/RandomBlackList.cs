﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给定一个整数 n 和一个 无重复 黑名单整数数组 blacklist 。设计一种算法，从 [0, n - 1] 范围内的任意整数中选取一个 未加入 黑名单 blacklist 的整数。
    /// 任何在上述范围内且不在黑名单 blacklist 中的整数都应该有 同等的可能性 被返回。
    /// 优化你的算法，使它最小化调用语言 内置 随机函数的次数。
    /// </summary>
    public class RandomBlackList
    {
        private Random random;
        private Dictionary<int, int> dict;
        private int bount;
        public RandomBlackList(int n, int[] blacklist)
        {
            random = new Random();
            dict = new Dictionary<int, int>();
            HashSet<int> set = new HashSet<int>();
            int m = blacklist.Length;
            bount = n - m;
            for (int i = 0; i < m; i++)
            {
                if (blacklist[i] >= bount)
                {
                    set.Add(blacklist[i]);
                }
            }

            int w = bount;
            //将黑名单中小于bount的元素映射到下标大于bount的部分
            for (int i = 0; i < m; i++)
            {
                if (blacklist[i] < bount)
                {
                    while (set.Contains(w))
                    {
                        w++;
                    }
                    dict.Add(blacklist[i], w);
                    w++;
                }
            }
        }

        public int Pick()
        {
            int r = random.Next(bount);
            //映射表中存在，返回映射的值，否则返回原值
            return dict.ContainsKey(r) ? dict[r] : r;
        }
    }
}
