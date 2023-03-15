using System;

namespace AlgorithmSummary
{
    /// <summary>
    /// 求两个正序数组的中位数
    /// 转换为求两个正序数组第K大问题
    /// 各取两个数组的前k/2 - 1个元素，若nums1[k/2 - 1] <= nums2[k/2 - 1]，则将nums1[k/2 - 1]排除
    /// 否则将nums2[k/2 - 1]排除，k = k - (k/2 - 1)继续求第K大
    /// 中断条件 
    /// 1.某个数组长度为0，直接取另一数组第K大元素
    /// 2.k = 1,返回nums1[0]和nums2[0]中最小的那个
    /// 注意k/2 - 1越界的情况
    /// </summary>
    public class FindMedianSortedArrays
    {
        public double FindMedianSortedArray(int[] nums1, int[] nums2)
        {
            int length = nums1.Length + nums2.Length;
            if (length % 2 == 0)
            {
                return (FindKthNumber(nums1, nums2, length / 2) + FindKthNumber(nums1, nums2, length / 2 + 1))/ 2.0;
            }
            else
            {
                return FindKthNumber(nums1, nums2, length / 2 + 1);
            }
        }

        /// <summary>
        /// 两个正序数组求第K大
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int FindKthNumber(int[] nums1, int[] nums2, int k)
        {
            int i = 0;
            int j = 0;

            while (true)
            {
                if (i == nums1.Length)
                {
                    return nums2[j + k - 1];
                }
                else if (j == nums2.Length)
                {
                    return nums1[i + k - 1];
                }

                if (k == 1)
                {
                    return Math.Min(nums1[i], nums2[j]);
                }

                int key = k / 2 - 1;
                int newIndex1 = Math.Min(i + key, nums1.Length - 1);
                int newIndex2 = Math.Min(j + key, nums2.Length - 1);
                int num1 = nums1[newIndex1];
                int num2 = nums2[newIndex2];
                if (num1 <= num2)
                {
                    k -= (newIndex1 - i + 1);
                    i = newIndex1 + 1;
                }
                else
                {
                    k -= (newIndex2 - j + 1);
                    j = newIndex2 + 1;
                }
            }
        }
    }
}
