﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppDemo.Problems.Easy
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class EasyProblems
    {
        //剑指 Offer 59 - I. 滑动窗口的最大值
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var result = new List<int>();
            if (nums.Length <= 0) return result.ToArray();

            for (int i = 0; i < nums.Length - k + 1; i++)
            {
                result.Add(nums[i..(i + k)].Max());
            }
            return result.ToArray();
        }
        //1688. 比赛中的配对次数
        public int NumberOfMatches(int n)
        {
            int count = 0;
            while (n != 1)
            {
                if ((n & 1) == 0)
                {
                    n /= 2;
                    count += n;
                }
                else
                {
                    n = (n - 1) / 2 + 1;
                    count += (n - 1) / 2;
                }
            }
            return count;
        }
        //1450. 在既定时间做作业的学生人数
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int length = startTime.Length;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (startTime[i] <= queryTime && queryTime <= endTime[i])
                    count++;
            }
            return count;
        }
        //137. 只出现一次的数字 II
        public int SingleNumber(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], 1);
                else
                    dict[nums[i]] += 1;
            }
            return dict.Where(d => d.Value == 1).Select(d => d.Key).FirstOrDefault();
        }
        //1572. 矩阵对角线元素的和
        public int DiagonalSum(int[][] mat)
        {
            //v1
            //int sum = 0;
            //for (int i = 0; i < mat.Length; i++)
            //{
            //    for (int j = 0; j < mat.Length; j++)
            //    {
            //        if (i == j || i + j == mat.Length - 1)
            //            sum += mat[i][j];
            //    }
            //}
            //return sum;

            //v2
            var sum = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                sum += mat[i][i] + mat[i][mat.Length - 1 - i];
            }
            //如果矩阵有奇数行的话，应该减去中间重复计算的元素
            int mid = mat.Length / 2;
            sum -= mat[mid][mid] * (mat.Length & 1);
            return sum;
        }
        //1290. 二进制链表转整数
        public int GetDecimalValue(ListNode head)
        {
            //v1
            //var list = new List<int>();
            //while (head!=null)
            //{
            //    list.Add(head.val);
            //    head = head.next;
            //}
            //return Convert.ToInt32(string.Concat(list),fromBase:2);

            //v2
            int anwser = 0;
            while (head != null)
            {
                anwser <<= 1;
                anwser |= head.val;
                head = head.next;
            }
            return anwser;
        }
        //1295. 统计位数为偶数的数字
        public int FindNumbers(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                int counter = 0;
                while (num > 0)
                {
                    num /= 10;
                    counter++;
                }
                if ((counter & 1) == 0)
                    sum++;
            }
            return sum;
        }
        //1662. 检查两个字符串数组是否相等
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string str1 = string.Concat(word1);
            string str2 = string.Concat(word2);
            return str1 == str2;
        }
        //1827. 最少操作使数组递增
        public int MinOperations(int[] nums)
        {
            if (nums.Length <= 1) return 0;
            int count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] >= nums[i])
                {
                    count += nums[i - 1] + 1 - nums[i];
                    nums[i] = nums[i - 1] + 1;
                }
            }
            return count;
        }
        //938. 二叉搜索树的范围和
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            int sum = 0;
            Dfs(root);

            void Dfs(TreeNode node)
            {
                if (node is null) return;

                if (node.val < low)
                    Dfs(node.right);
                else if (node.val > high)
                    Dfs(node.left);
                else
                {
                    sum += node.val;
                    Dfs(node.left);
                    Dfs(node.right);
                }
            }
            return sum;
        }
        //1313. 解压缩编码列表
        public int[] DecompressRLElist(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                int freq = nums[i];
                int value = nums[i + 1];
                for (int j = 0; j < freq; j++)
                {
                    result.Add(value);
                }
            }
            return result.ToArray();
        }
        //1342. 将数字变成 0 的操作次数
        public int NumberOfSteps(int num)
        {
            int count = 0;
            while (num > 0)
            {
                if ((num & 1) == 0)//偶数
                    num /= 2;
                else
                    num -= 1;
                count++;
            }
            return count;
        }
        //1365. 有多少小于当前数字的数字
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            //v1 暴力破解
            int length = nums.Length;
            int[] res = new int[length];
            //for (int i = 0; i < length; i++)
            //{
            //    int count = 0;
            //    for (int j = 0; i!=j&&j < length; j++)
            //    {
            //        if (i == j) continue;
            //        if (nums[i] > nums[j])
            //            count++;
            //    }
            //    res[i] = count;
            //}

            //v2 词频统计
            var dict = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (!dict.ContainsKey(n))
                    dict.Add(n, 1);
                else
                    dict[n] = ++dict[n];
            }
            for (int i = 0; i < length; i++)
            {
                int count = 0;
                foreach (var pair in dict)
                {
                    if (pair.Key < nums[i])
                        count += pair.Value;
                }
                res[i] = count;
            }
            return res;
        }
        //1684. 统计一致字符串的数目
        public int CountConsistentStrings(string allowed, string[] words)
        {
            int sum = 0;
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!allowed.Contains(word[i]))
                        break;
                    if (i == word.Length - 1)
                        sum++;
                }
            }
            return sum;
        }
        //1389. 按既定顺序创建目标数组
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            var list = new List<int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                list.Insert(index[i], nums[i]);
            }
            return list.ToArray();
        }
        //1281. 整数的各位积和之差
        public int SubtractProductAndSum(int n)
        {
            int multiply = 1, sum = 0, tmp = 0;
            while (n > 0)
            {
                tmp = n % 10;
                n /= 10;
                multiply *= tmp;
                sum += tmp;
            }
            return multiply - sum;
        }
        //91. 解码方法
        public int NumDecodings(string s)
        {
            if (s[0] == '0') return 0;//很明显，如果首位为0，则无法解码

            //dp[-1] = dp[0] = 1,解释dp[0]=1好理解，一个!0数字就只有1种解法；
            /*
             * dp[-1]=1直接看很难理解；但是可以推算，比如第2位为0，那么第1位只能为1或2才能解码，因为dp[i]=dp[i-2],
             *此时，应该只有1种解法，即dp[1]=1,所以dp[1]=dp[-1]=1。或者可以理解为没有元素时只有一种解法，那就是没有解法。（玄学，个人理解）
             */
            int pre = 1, curr = 1;
            for (int i = 1; i < s.Length; i++)
            {
                int tmp = curr;//记录当前解法数量
                if (s[i] == '0')//如果当前为0，则前一个数字必须为1或2，否则无法解码（如00,30等），返回0
                {
                    //dp[i]=dp[i-2];解释第i-1位和第i位必须看做一个整体才能解码，故解码方法和第i-2位的解码方法相同
                    if (s[i - 1] == '1' || s[i - 1] == '2')
                        curr = pre;
                    else return 0;
                }
                //如果前1位为1，则dp[i]=dp[i-1]+dp[i-2]; 解释：s[i-1]和s[i]分开译码为dp[i-1]；合在一起译码为dp[i-2]
                //或者如果前1位为2，且当前位为1-6 ，则dp[i]=dp[i-1]+dp[i-2]; 解释同上
                else if (s[i - 1] == '1' || (s[i - 1] == '2' && '1' <= s[i] && s[i] <= '6'))
                {
                    curr = curr + pre;
                }
                pre = tmp;
            }
            return curr;
        }
        //1678. 设计 Goal 解析器
        public string Interpret(string command)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'G')
                    sb.Append('G');
                else
                {
                    if (command[i++] == '(' && command[i] == ')')
                        sb.Append('o');
                    else
                    {
                        sb.Append("al");
                        i += 2;
                    }
                }
            }
            return sb.ToString();
        }
        //LCP 06. 拿硬币
        public int MinCount(int[] coins)
        {
            int sum = 0;
            int coinsCount = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                coinsCount = coins[i];
                sum += (coinsCount % 2 == 0) ? coinsCount / 2 : coinsCount / 2 + 1;
            }
            return sum;
        }
        //1773. 统计匹配检索规则的物品数量
        public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int index = -1;
            switch (ruleKey)
            {
                case "type":
                    index = 0;
                    break;
                case "color":
                    index = 1;
                    break;
                case "name":
                    index = 2;
                    break;
            }
            int sum = 0;
            foreach (var item in items)
            {
                sum += (item[index] == ruleValue) ? 1 : 0;
            }
            return sum;
        }
        //1720. 解码异或后的数组
        public int[] Decode(int[] encoded, int first)
        {
            int[] arr = new int[encoded.Length + 1];
            arr[0] = first;
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = encoded[i - 1] ^ arr[i - 1];
            }
            return arr;
        }
        public string DefangIPaddr(string address)
        {
            //return address.Replace(".", "[.]");
            var sb = new StringBuilder(address.Length);
            foreach (var c in address)
            {
                if (c == '.')
                    sb.Append("[.]");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
        //28. 实现 strStr()
        public int StrStr(string haystack, string needle)
        {
            if (needle.Trim().Length <= 0) return 0;
            int fast, slow, k = 0;
            for (fast = 0, slow = 0; fast < haystack.Length; fast++)
            {
                if (haystack[fast] != needle[k])
                {
                    fast = slow;
                    slow++;
                    k = 0;
                }
                else
                    k++;
                if (k == needle.Length)
                    return slow;
            }
            return -1;
        }
        //27. 移除元素
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length <= 0) return 0;
            //快指针每次遍历一个元素，慢指针指向被移除的元素
            int fast = 0, slow = 0;
            for (fast = 0, slow = 0; fast < nums.Length; fast++)
            {
                if (val != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
            }
            return slow;
        }
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
