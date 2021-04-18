using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppDemo.HwOd
{

    class HwOdTest
    {
        //Q4.
        /*

            输入n个数组，每次取出k项添加到空数组，最后打印这个数组
            例子：3个数组 每次2位
               3
               2
               1,2,3,4,5
               6,7,8,9,10
               11,12,13
            
            第一轮1 2 6 7 11 12
            第二轮  3 4 8 9 13
            第三轮  5 10
            结果就是 1,2,6,7,11,12,3,4,8,9,13,5,10
         */
        public static int[] PrintArray()
        {
            int arrCount = 3,k=2;
            string[] strs = 
            {
                "1,2,3,4,5",
                "6,7,8,9,10",
                "11,12,13"
            };
            var inputList = new List<int[]>();
            foreach (var str in strs)
            {
                inputList.Add(str.Split(',').Select(s=>int.Parse(s)).ToArray());
            }
            var res = new List<int>();
            for (int i = 0; i < arrCount; i++)
            {
                foreach (var inputs in inputList)
                {
                    res.AddRange(inputs.ToList().Skip(k * i).Take(k));
                }
            }
            return res.ToArray();
        }
        //Q3.
        /*
         任给一个数组，元素有20M，1T，300G之类的，其中1T=1000G，1G=1000M
            按从小到大输出结果
            例如：输入：3
            20M
            1T
            300G
            输出：
            20M
            300G
            1T
         */

        public static void SortSize()
        {
            int count = int.Parse(Console.ReadLine());
            if (count <= 0) return;

            var sizes = new string[count];
            for (int i = 0; i < count; i++)
            {
                sizes[i] = Console.ReadLine();
            }

            //冒泡排序
            for (int i = 0; i < sizes.Length - 1; i++)//趟数
            {
                for (int j = i; j < sizes.Length - 1; j++)//比较次数
                {
                    if (GetIntSize(sizes[j]) > GetIntSize(sizes[j + 1]))
                    {
                        var tmp = sizes[j];
                        sizes[j ] = sizes[j+1];
                        sizes[j+1] = tmp;
                    }
                }
            }
            foreach (var item in sizes)
            {
                Console.WriteLine(item);
            }
        }

        private static int GetIntSize(string sizeStr)
        {
            if (sizeStr.EndsWith("G"))
                return int.Parse(sizeStr.TrimEnd('G')) * 1000;
            if (sizeStr.EndsWith("T"))
                return int.Parse(sizeStr.TrimEnd('T')) * 1000_000;
            return int.Parse(sizeStr.TrimEnd('M'));
        }

        //Q2.拼接url，给定一个字符串，中间存在“，”隔开前后两个url，要求拼接这两个url，且中间有且只有一个“/”。 （例如 abc/,/bdd 输出abc/bdd）
        public static string ConcatUrl(string toProcessUrl)
        {
            if (string.IsNullOrEmpty(toProcessUrl))
                return null;
            string[] urlArr = toProcessUrl.Split(',');

            if (urlArr.Length != 2)
                return null;

            return string.Concat(urlArr[0].TrimEnd('/'), "/", urlArr[1].TrimStart('/'));
        }
        //Q1.给定一个数组，求是否存在满足A=B+2C等式的三个元素A、B、C
        public static bool IsExistInArray(int[] nums, int a, int b, int c)
        {

            //v1
            bool cChecked = nums.Any(n => n == c);
            if (!cChecked) return false;

            bool bChecked = nums.Any(n => n == b);
            if (!bChecked) return false;

            bool aChecked = nums.Any(n => n == (b + 2 * c));
            return aChecked;


            //v2  这种做法对于b,c相同的元素且只有一个不通过
            //bool aChcked = false;
            //bool bChcked = false;
            //bool cChcked = false;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (!aChcked && nums[i] == a)
            //    {
            //        aChcked = true;
            //    }
            //    else if (!bChcked && nums[i] == b)
            //    {
            //        bChcked = true;
            //    }
            //    else if (!cChcked && nums[i] == c)
            //    {
            //        cChcked = true;
            //    }
            //}
            //return aChcked && bChcked && cChcked;
        }
    }
}
