using ConsoleAppDemo.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var leftSpin = new LeftSpin();
            leftSpin.ReverseLeftWords("abcdefg", 2);



        }
        public static int StrToInt(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            //定义字符位置，符号位，结果变量
            int i = 0, sign = 1, res = 0;
            //1.先处理首部空格
            while (str[i] == ' ')
            {
                i++;
                if (i == str.Length)//全部为空格
                    return 0;
            }
            //2.首位非符号位，非数字立即返回
            char firstChar = str[i];
            if (!char.IsDigit(firstChar) && firstChar != '+' && firstChar != '-')
                return 0;
            if (firstChar == '-')
                sign = -1;
            if ("+-".Contains(firstChar))//如果首位为符号位，需要从下个位置遍历
                i++;
            int boundry = int.MaxValue / 10;//边界
            for (int j = i; j < str.Length; j++)
            {
                if (str[j] < '0' || str[j] > '9')//首位非数字直接返回
                    break;
                //3.越界处理res=res*10+str[j]
                if (res > boundry || (res == boundry && str[j] > '7'))
                    return sign == -1 ? int.MinValue : int.MaxValue;
                res = res * 10 + (str[j] - '0');
            }
            return sign * res;
        }


        private bool IsNumber(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            int plusIndex = s.IndexOf('+');
            if (plusIndex >= 1)//+号位于数字之间不是数值
                return false;
            if (plusIndex == 0)
            {

            }
            return true;
        }
    }
}
