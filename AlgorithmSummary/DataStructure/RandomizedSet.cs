using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// O(1) 时间插入、删除和获取随机元素
    /// </summary>
    public class RandomizedSet
    {
        private Dictionary<int, int> dict;
        private List<int> list;
        Random r;
        public RandomizedSet()
        {
            dict = new Dictionary<int, int>();
            list = new List<int>();
            r = new Random();
        }

        public bool Insert(int val)
        {
            if (!dict.ContainsKey(val))
            {
                dict.Add(val, list.Count);
                list.Add(val);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除数据时，交换最后一个元素和被删除的元素
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Remove(int val)
        {
            if (dict.ContainsKey(val))
            {
                list[dict[val]] = list[list.Count - 1];
                dict[list[list.Count - 1]] = dict[val];
                list.RemoveAt(list.Count - 1);
                dict.Remove(val);

                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetRandom()
        {
            int randomNum = r.Next(list.Count);
            return list[randomNum];
        }
    }
}
