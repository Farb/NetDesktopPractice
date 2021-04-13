using System;
using System.Linq;

namespace ConsoleAppDemo.DynamicPlan
{
    class MaxSunArray
    {
        //最大子数组和
        public int MaxSubArray(int[] nums)
        {
            //设dp[i]是数组末尾元素nums[i]的最大子数组之和
            //转移方程为：
            //初始元素dp[0]=nums[0]
            //1.dp[i]=dp[i-1]+nums[i]; dp[i-1]>0
            //2.dp[i]=nums[i];dp[i-1]<=0
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i-1]>0)
                    nums[i] += nums[i - 1] ;
            }

            return nums.ToList().Max();
        }
    }
}
