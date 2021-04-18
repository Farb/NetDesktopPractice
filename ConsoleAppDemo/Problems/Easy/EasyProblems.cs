using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppDemo.Problems.Easy
{
    class EasyProblems
    {
        //1470. 重新排列数组
        public int[] Shuffle(int[] nums, int n)
        {
            var newNums = new int[2 * n];
            for (int i = 0, j = n; i < n; i++, j++)
            {
                newNums[2 * i] = nums[i];
                newNums[2 * i + 1] = nums[j];
            }
            return newNums;
        }
        //5734. 判断句子是否为全字母句
        public bool CheckIfPangram(string sentence)
        {
            int alphabetCount = 26;
            var results = new bool[alphabetCount];
            foreach (var c in sentence)
            {
                results[c - 'a'] = true;
            }
            return results.Count(r => r) == alphabetCount;
        }
        //26. 删除有序数组中的重复项  V2
        public int RemoveDuplicatesV2(int[] nums)
        {
            if (nums.Length <= 0) return 0;
            //fast 快指针  ，slow 慢指针
            int fast, slow;
            for (fast = 1, slow = 0; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[slow])
                {
                    nums[slow + 1] = nums[fast];
                    slow++;
                }
            }
            return slow + 1;
        }
        //26. 删除有序数组中的重复项
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 0) return 0;
            //fast 快指针  ，slow 慢指针
            int fast, slow;
            for (fast = 1, slow = 1; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[fast - 1])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
            }
            return slow + 1;
        }
        //1431. 拥有最多糖果的孩子
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var res = new List<bool>(candies.Length);
            int max = candies.Max();
            foreach (var candy in candies)
            {
                res.Add(candy + extraCandies > max);
            }
            return res;
        }

        //1512. 好数对的数目
        public int NumIdenticalPairs(int[] nums)
        {
            /*//v1
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (nums[i] == nums[j])
                        res++;
                }
            }
            return res;
            */
            /*//v2 如果一个数字出现的次数是n，那么好数对数量为(n-1)+...+2+1=n*(n-1)/2;
            
            var dict = new Dictionary<int, int>();
            int res = 0;
            foreach (var item in nums)
            {
                if (!dict.ContainsKey(item))
                    dict.Add(item, 1);
                else
                {
                    res += dict[item];
                    dict[item] += 1;
                }
            }
            return res;
            */

            //v3
            int ans = 0;
            //因为 1<= nums[i] <= 100  所以申请大小为100的数组
            //temp用来记录num的个数
            int[] temp = new int[100];
            /*
            从前面开始遍历nums
            假设nums = [1,1,1,1]
            第一遍
            temp是[0,0,0,0]
            ans+=0;
            temp[0]++;
            第二遍
            temp是[1,0,0,0]
            ans+=1;
            temp[0]++;
            第三遍
            temp=[2,0,0,0]
            ans+=2;
            temp[0]++;
            第四遍
            temp=[3,0,0,0]
            ans+=3;
            temp[0]++;
            */
            foreach (int num in nums)
            {
                /*
                这行代码可以写成
                ans+=temp[num - 1];
                temp[num - 1]++;
                */
                ans += temp[num - 1]++;
            }
            return ans;
        }
        //1672. 最富有客户的资产总量
        public int MaximumWealth(int[][] accounts)
        {
            int richest = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                int temp = accounts[i].Sum();
                if (temp > richest)
                    richest = temp;
            }
            return richest;
        }

        //
        public int ArraySign(int[] nums)
        {
            int result = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                    result *= -1;
                else if (nums[i] > 0)
                    result *= 1;
                else return 0;
            }
            return result;
        }

    }
}
