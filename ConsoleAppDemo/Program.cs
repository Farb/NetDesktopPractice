using System;
using System.Collections.Generic;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //GenericTest.ShowDemo();
            //ReflectionDemo.Show();
            //MessageAttack.Attack("13606542369");
            string s = "078332e437";
            s = s.TrimStart('0');
            double d;
            bool isNumber=double.TryParse(s, out d);

            


        }

        private bool IsNumber(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            int plusIndex = s.IndexOf('+');
            if (plusIndex >= 1)//+号位于数字之间不是数值
                return false;
            if (plusIndex==0)
            {

            }
            return true;
        }
    }
}
