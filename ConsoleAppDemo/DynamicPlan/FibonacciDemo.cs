using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.DynamicPlan
{
    public class FibonacciDemo
    {
        public int Fib(int n)
        {
            int max = 1000000007;
            int a = 0, b = 1, sum = 1;
            for (int i = 1; i < n; i++)
            {
                if (n == 0) return a;
                if (n == 1) return b;
                //n==2 进入转移方程 f(n)=f(n-1)+f(n-2)
                //sum=a+b,a=b,b=sum
                //特别公式：f(n)%p=[f(n-1)%p+f(n-2)%p]%p;
                sum = (a + b) % max;
                a = b;
                b = sum;
            }
            return sum;
        }
        //青蛙跳台阶问题
        public int NumWays(int n)
        {
            if (n == 0 || n == 1) return 1;
            if (n == 2) return 2;

            int a = 1, b = 2, sum = 0, max = 1000000007;
            for (int i = 3; i <= n; i++)
            {
                sum = (a + b) % max;
                a = b;
                b = sum;
            }
            return sum;
        }
    }
}
