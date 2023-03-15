namespace AlgorithmSummary
{
    /// <summary>
    /// 下一个更大的元素
    /// 给你一个正整数 n ，请你找出符合条件的最小整数，其由重新排列 n 中存在的每位数字组成，并且其值大于 n 。如果不存在这样的正整数，则返回 -1 。
    /// </summary>
    public class NextGreaterElement
    {
        public int Next_Greater_Element(int n)
        {
            char[] nums = n.ToString().ToCharArray();
            int i = nums.Length - 2;
            //找到左边较小的数，尽量靠右
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i < 0)
            {
                return -1;
            }

            int j = nums.Length - 1;
            //找到右边较大的数，值尽量小
            while (j >= 0 && nums[i] >= nums[j])
            {
                j--;
            }
            Swap(nums, i, j);
            Reverse(nums, i + 1);
            long ans = long.Parse(new string(nums));
            return ans > int.MaxValue ? -1 : (int)ans;
        }

        /// <summary>
        /// 序列为递减，直接反转序列
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="begin"></param>
        public void Reverse(char[] nums, int begin)
        {
            int i = begin, j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }

        public void Swap(char[] nums, int i, int j)
        {
            char temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
