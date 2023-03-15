using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.DataStructure
{
    /// <summary>
    /// 实现一个 MyCalendar 类来存放你的日程安排。如果要添加的日程安排不会造成 重复预订 ，则可以存储这个新的日程安排。
    /// 当两个日程安排有一些时间上的交叉时（例如两个日程安排都在同一时间内），就会产生 重复预订 。
    /// 日程可以用一对整数 start 和 end 表示，这里的时间是半开区间，即 [start, end), 实数 x 的范围为，  start <= x < end 。
    /// </summary>
    public class MyCalendarI
    {
        //线段树
        ISet<int> tree;
        //懒标记
        ISet<int> lazy;

        public MyCalendarI()
        {
            tree = new HashSet<int>();
            lazy = new HashSet<int>();
        }

        /// <summary>
        /// 线段树，动态开点 + lazy标记
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool Book(int start, int end)
        {
            if (Query(start, end - 1, 0, 1000000000, 1))
            {
                return false;
            }
            Update(start, end - 1, 0, 1000000000, 1);
            return true;
        }

        /// <summary>
        /// 查询线段树，指定时间段是否已经被预定
        /// </summary>
        /// <param name="start">日程开始时间</param>
        /// <param name="end">日程结束时间</param>
        /// <param name="l">时间区间左</param>
        /// <param name="r">时间区间右</param>
        /// <param name="idx">线段树索引，利用二分法，使用一个int类型数值表示一个时间区间</param>
        /// <returns></returns>
        public bool Query(int start, int end, int l, int r, int idx)
        {
            //无交集
            if (start > r || end < l)
            {
                return false;
            }
            /* 如果该区间已被预订，则直接返回 */
            if (lazy.Contains(idx))
            {
                return true;
            }
            //查询时间区间包含指定时间区间，检测指定时间是否存在日程安排
            if (start <= l && r <= end)
            {
                return tree.Contains(idx);
            }
            else
            {
                int mid = (l + r) >> 1;
                if (end <= mid)
                {
                    return Query(start, end, l, mid, 2 * idx);
                }
                else if (start > mid)
                {
                    return Query(start, end, mid + 1, r, 2 * idx + 1);
                }
                else
                {
                    return Query(start, end, l, mid, 2 * idx) | Query(start, end, mid + 1, r, 2 * idx + 1);
                }
            }
        }

        /// <summary>
        /// 更新线段树
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="idx"></param>
        public void Update(int start, int end, int l, int r, int idx)
        {
            //无交集
            if (r < start || end < l)
            {
                return;
            }
            //时间区间被包含在日程安排时间段内，同时在线段树和懒标记中添加该时间段
            if (start <= l && r <= end)
            {
                tree.Add(idx);
                //表示这个时间段已经被全部占用
                lazy.Add(idx);
            }
            //存在交集
            else
            {
                int mid = (l + r) >> 1;
                Update(start, end, l, mid, 2 * idx);
                Update(start, end, mid + 1, r, 2 * idx + 1);
                //表示这个时间区间存在日程安排
                tree.Add(idx);
            }
        }
    }
}
