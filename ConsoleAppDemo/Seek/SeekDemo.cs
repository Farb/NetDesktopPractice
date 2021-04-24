using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.Seek
{
    class SeekDemo
    {
        //剑指 Offer 03. 数组中重复的数字
        public int FindRepeatNumber(int[] nums)
        {
            //v1 字典法
            //var dict = new Dictionary<int, int>();
            //foreach (var n in nums)
            //{
            //    if (dict.ContainsKey(n))
            //        return n;
            //    dict.Add(n,n);
            //}
            //return -1;

            //v2 原地交换法
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] == i)
                    i++;
                else if (nums[i] == nums[nums[i]])
                    return nums[i];
                else
                {
                    var tmp = nums[i];
                    nums[i] = nums[tmp];
                    nums[tmp] = tmp;
                }
            }
            return -1;
        }
    }
}
