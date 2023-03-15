using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.DataStructure
{
    /// <summary>
    /// 实现一个 MyCalendar 类来存放你的日程安排。如果要添加的时间内不会导致三重预订时，则可以存储这个新的日程安排。
    /// MyCalendar 有一个 book(int start, int end)方法。
    /// 它意味着在 start 到 end 时间内增加一个日程安排，注意，这里的时间是半开区间，即 [start, end), 实数 x 的范围为，  start <= x < end。
    /// 当三个日程安排有一些时间上的交叉时（例如三个日程安排都在同一时间内），就会产生三重预订。
    /// 每次调用 MyCalendar.book方法时，如果可以将日程安排成功添加到日历中而不会导致三重预订，返回 true。否则，返回 false 并且不要将该日程安排添加到日历中。
    /// </summary>
    public class MyCalendarII
    {
        //线段树，value数组的第一个元素表示时间区间的最大预定次数，第二个元素表示时间区间的累计预定次数
        Dictionary<int, int[]> tree;
        public MyCalendarII()
        {
            tree = new Dictionary<int, int[]>();
        }

        public bool Book(int start, int end)
        {
            Update(start, end - 1, 1, 0, 1000000000, 1);
            if (!tree.ContainsKey(1))
            {
                tree.Add(1, new int[2]);
            }
            //最大预定次数超过2，回溯
            if (tree[1][0] > 2)
            {
                Update(start, end - 1, -1, 0, 1000000000, 1);
                return false;
            }
            return true;
        }

        private void Update(int start, int end, int val, int l, int r, int idx)
        {
            if (r < start || end < l)
            {
                return;
            }
            if (!tree.ContainsKey(idx))
            {
                tree.Add(idx, new int[2]);
            }
            if (start <= l && r <= end)
            {
                tree[idx][0] += val;
                tree[idx][1] += val;
            }
            else
            {
                int mid = (l + r) >> 1;
                Update(start, end, val, l, mid, 2 * idx);
                Update(start, end, val, mid + 1, r, 2 * idx + 1);
                if (!tree.ContainsKey(2 * idx))
                {
                    tree.Add(2 * idx, new int[2]);
                }
                if (!tree.ContainsKey(2 * idx + 1))
                {
                    tree.Add(2 * idx + 1, new int[2]);
                }
                tree[idx][0] = tree[idx][1] + Math.Max(tree[2 * idx][0], tree[2 * idx + 1][0]);
            }
        }
    }
}
